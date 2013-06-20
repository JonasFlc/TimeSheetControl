using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheetControl.Object;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;
using TimeSheetControl.DTO;

namespace TimeSheetControl.Repository
{
    public sealed class ProjectRepository
    {

         // L’instance du singleton. Cette instance doit être privée et statique.
        private static ProjectRepository instance = null; 
        // Pour éviter, lors de l’utilisation de multiple thread, que plusieurs singleton soit instanciés.
        private static readonly object myLock = new object();

       
        // Le constructeur d’un singleton est TOUJOURS privée. 
        private ProjectRepository() {
             projects = new List<Project>();
             sheets = new List<Sheet>();
        }

        // La méthode qui va nous permettre de récupérer l’unique instance de notre singleton.
        // La méthode doit être statique pour être appelé depuis le nom de la classe maClasse.getInstance();
        public static ProjectRepository getInstance() 
        { 
            //lock permet de s’assurer qu’un thread n’entre pas dans une section critique du code pendant qu’un autre thread s’y trouve.  
            //Si un autre thread tente d’entrer dans un code verrouillé, il attendra, bloquera, jusqu’à ce que l’objet soit libéré.
            lock (myLock) 
            { 
                // Si on demande une instance qui n’existe pas, alors on crée notre RessourceManager.
                if (instance == null) instance = new ProjectRepository();
                // Dans tous les cas on retourne l’unique instance de notre RessourceManager.
                return instance; 
            } 
        }

        public enum screenMode { newMode, editMode }

        public IList<Project> projects {get;set;}
        public IList<Sheet> sheets { get; set; }
        public TreeNode selectedNode { get; set; }
        public Sheet actualSheet { get; set; }
        public Sheet selectedSheet { get; set; }
        public Int32 currentMonth { get; set; }
        public Int32 currentYear { get; set; }
        public screenMode currentScreenMode { get; set; }
        public TimeSpan dailyTime { get; set; }


        public TreeNode treeNode { get; set; }

        public void loadXmlTree()
        {
            projects = new List<Project>();
            sheets = new List<Sheet>();

            FileStream fs = new FileStream(FileRepository.getInstance().appData+@"Project_task_d.xml", FileMode.Open, FileAccess.ReadWrite);
            XmlDocument tsfile = new XmlDocument();
            tsfile.Load(fs);

           try
           {

                // XmlNodeList nodeList = tsfile.SelectNodes("/TimeSheets");
                foreach (XmlElement project in tsfile.SelectNodes(@"TimeSheet/Project"))
                {
                    String v_project_name = project.GetAttribute("name");
                    Decimal v_project_number;
                    Decimal.TryParse(project.GetAttribute("number"), out v_project_number);

                    Project v_project = new Project() { name = v_project_name, number = v_project_number };
                    List<Task> v_project_task = new List<Task>();

                    foreach (XmlElement task in project.ChildNodes)
                    {
                        //TODO: test if childNode is really a task
                        String v_task_name = task.GetAttribute("name");
                        Decimal v_task_number;
                        Decimal.TryParse(task.GetAttribute("number"), out v_task_number);

                        Task v_task = new Task() { name = v_task_name, number = v_task_number, project = v_project };
                        List<Job> v_task_job = new List<Job>();
                        foreach (XmlElement job in task.ChildNodes)
                        {
                            //TODO: test if the childNode is really a job

                            String v_job_name = job.GetAttribute("name");
                            Decimal v_job_number;
                            Decimal.TryParse(job.GetAttribute("number"), out v_job_number);

                            Job v_job = new Job() { name = v_job_name, number = v_job_number, task = v_task };
                            v_task_job.Add(v_job);

                        }
                        v_task.jobs = v_task_job;
                        v_project_task.Add(v_task);
                    }

                    v_project.tasks = v_project_task;
                    projects.Add(v_project);
                }



           }
           catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }

            fs.Close();
            this.loadTreeNode();

        }

        public void loadTreeNode()
        {
            TreeNode projectNode = new TreeNode("Projects");
            this.projects = this.projects.OrderBy(p => p.number).ToList<Project>();

            try
            {
                foreach (var project in this.projects)
                {
                    projectNode.Nodes.Add(project.number.ToString(), project.number + " - " + project.name);
                    project.tasks = project.tasks.OrderBy(t => t.number).ToList<Task>();

                    foreach (var task in project.tasks)
                    {
                        projectNode.Nodes[project.number.ToString()].Nodes.Add(task.number.ToString(), task.number + " - " + task.name);
                        task.jobs = task.jobs.OrderBy(j => j.number).ToList<Job>();

                        foreach (var job in task.jobs)
                        {
                            projectNode.Nodes[project.number.ToString()].Nodes[task.number.ToString()].Nodes.Add(job.number.ToString(), job.number + " - " + job.name);
                        }
                    }

                }

            }
            catch (Exception)
            {
                Console.WriteLine("error in parsing treeView");
            }

            this.treeNode = projectNode;

        }

        public void loadMonthXml(Int32 month, Int32 year)
        {
            sheets = new List<Sheet>();

            if (File.Exists(FileRepository.getInstance().appData + year.ToString("0000") + month.ToString("00") + @".xml"))
            {
                FileStream fs = new FileStream(FileRepository.getInstance().appData + year.ToString("0000") + month.ToString("00") + @".xml", FileMode.Open, FileAccess.ReadWrite);
                XmlDocument tsfile = new XmlDocument();
                tsfile.Load(fs);

                try
                {

                    foreach (XmlElement sheet in tsfile.SelectSingleNode(@"TimeSheet").ChildNodes)
                    {
                        Decimal v_sheet_job_id = Decimal.Parse(sheet.GetAttribute("ma"));
                        DateTime v_sheet_start = DateTime.Parse(sheet.SelectSingleNode("start").FirstChild.Value);
                        DateTime v_sheet_stop = DateTime.Parse(sheet.SelectSingleNode("end").FirstChild.Value);
                        String v_sheet_note = (sheet.SelectSingleNode("note").FirstChild == null ? null : sheet.SelectSingleNode("note").FirstChild.Value);

                        Sheet loadedSheet = new Sheet() { start = v_sheet_start, end = v_sheet_stop, note = v_sheet_note };
                        loadedSheet.job = findJobFromId(v_sheet_job_id);

                        this.sheets.Add(loadedSheet);

                    }



                }
                catch (Exception)
                {
                    Console.WriteLine("error");
                    throw;
                }

                fs.Close();
            }
            this.loadTreeNode();

        }

        public void loadDailyTime(DateTime date)
        {
            TimeSpan result = new TimeSpan();
            foreach (var sheet in sheets.Where(s => s.start.Date.Equals(date.Date) && s.job != null))
            {
                result = result.Add(sheet.end.Subtract(sheet.start));
            }
            this.dailyTime = result;
        }

        public AdvancedList<SheetDTO> GetSheetDTOByDate(DateTime date)
        {

            AdvancedList<SheetDTO> sheetsDTO = new AdvancedList<SheetDTO>();


            foreach (var sheet in sheets.Where(s => s.start.Date.Equals(date.Date) && s.job != null))
            {
                    SheetDTO sheetDTO = new SheetDTO();
                    sheetDTO.JobName = sheet.job.name;
                    sheetDTO.JobNum = sheet.job.number.ToString();
                    sheetDTO.TaskNum = sheet.job.task.number.ToString();
                    sheetDTO.TaskName = sheet.job.task.name;
                    sheetDTO.ProjectNum = sheet.job.task.project.number.ToString();
                    sheetDTO.ProjectName = sheet.job.task.project.name;
                    sheetDTO.Start = sheet.start.ToLongTimeString();
                    sheetDTO.End = sheet.end.ToLongTimeString();
                    sheetDTO.Duration = sheet.end.Subtract(sheet.start).ToString();
                    sheetDTO.Note = sheet.note;

                    sheetsDTO.Add(sheetDTO);
                
            }
            if (actualSheet != null && actualSheet.start.Date.Equals(date.Date))
            {
                SheetDTO sheetDTO = new SheetDTO();
                sheetDTO.JobNum = actualSheet.job.number.ToString();
                sheetDTO.JobName = actualSheet.job.name;
                sheetDTO.TaskNum = actualSheet.job.task.number.ToString();
                sheetDTO.TaskName = actualSheet.job.task.name;
                sheetDTO.ProjectNum = actualSheet.job.task.project.number.ToString();
                sheetDTO.ProjectName = actualSheet.job.task.project.name;
                sheetDTO.Start = actualSheet.start.ToLongTimeString();
                sheetsDTO.Add(sheetDTO);
            }

            return sheetsDTO;
        }


        #region Add_Remove_Treeview
        public void addProject(String name, Decimal number)
        {

            if (projects.Count(p => p.number == number) > 0)
            {
                MessageBox.Show("An existing project exists with this number", "Error", MessageBoxButtons.OK);
                return;
            }

            FileStream fs = new FileStream(FileRepository.getInstance().appData + @"Project_task_d.xml", FileMode.Open, FileAccess.ReadWrite);
            XmlDocument tsfile = new XmlDocument();
            tsfile.Load(fs);

            try
            {
                XmlNode rootNode = tsfile.DocumentElement.SelectSingleNode(@"/TimeSheet");
                fs.Close();

                XmlElement projectNode = tsfile.CreateElement("", "Project", "");
                projectNode.SetAttribute("name", name);
                projectNode.SetAttribute("number", number.ToString());

                rootNode.AppendChild(projectNode);
                this.fileSave(tsfile, @"Project_task_d.xml");
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }

            this.loadXmlTree();

        }

        public void addTask(String name, Decimal taskNumber, Decimal projectNumber)
        {
            if (projects.First(p => p.number == projectNumber).tasks.Count(t => t.number == taskNumber) > 0)
            {
                MessageBox.Show("An existing project exists with this number", "Error", MessageBoxButtons.OK);
                return;
            }

            FileStream fs = new FileStream(FileRepository.getInstance().appData + @"Project_task_d.xml", FileMode.Open, FileAccess.ReadWrite);
            XmlDocument tsfile = new XmlDocument();
            tsfile.Load(fs);

            try
            {
                XmlNode rootNode = tsfile.DocumentElement.SelectSingleNode("/TimeSheet/Project[@number='" + projectNumber + "']");
                fs.Close();

                XmlElement projectNode = tsfile.CreateElement("", "Task", "");
                projectNode.SetAttribute("name", name);
                projectNode.SetAttribute("number", taskNumber.ToString());

                rootNode.AppendChild(projectNode);
                this.fileSave(tsfile, @"Project_task_d.xml");

            }
            catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }

           this.loadXmlTree();

        }

        public void addJob(String name, Decimal jobNumber, Decimal taskNumber, Decimal projectNumber)
        {

            if (findJobFromId(jobNumber) != null)
            {
                MessageBox.Show("An existing job exists with this number", "Error", MessageBoxButtons.OK);
                return;
            }

            FileStream fs = new FileStream(FileRepository.getInstance().appData + @"Project_task_d.xml", FileMode.Open, FileAccess.ReadWrite);
            XmlDocument tsfile = new XmlDocument();
            tsfile.Load(fs);

            try
            {
                XmlNode rootNode = tsfile.DocumentElement.SelectSingleNode("/TimeSheet/Project[@number='" + projectNumber + "']/Task[@number='"+taskNumber+"']");
                fs.Close();

                XmlElement projectNode = tsfile.CreateElement("", "ma", "");
                projectNode.SetAttribute("name", name);
                projectNode.SetAttribute("number", jobNumber.ToString());

                rootNode.AppendChild(projectNode);
                this.fileSave(tsfile, @"Project_task_d.xml");

            }
            catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }

            this.loadXmlTree();

        }

        private void fileSave(XmlDocument tsfile, String filename)
        {
            try
            {

                FileStream WRITER = new FileStream(FileRepository.getInstance().appData + filename, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                tsfile.Save(WRITER);
                WRITER.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void deleteProject(Decimal projectNumber)
        {
            try
            {
                if (projects.Count(p => p.number == projectNumber) == 0)
                {
                    MessageBox.Show("No project exists with this number", "Error", MessageBoxButtons.OK);
                    return;
                }

                FileStream fs = new FileStream(FileRepository.getInstance().appData + @"Project_task_d.xml", FileMode.Open, FileAccess.ReadWrite);
                XmlDocument tsfile = new XmlDocument();
                tsfile.Load(fs);

                try
                {
                    XmlNode rootNode = tsfile.DocumentElement.SelectSingleNode("/TimeSheet");
                    fs.Close();

                    XmlNode deleteNode = rootNode.SelectSingleNode("Project[@number='" + projectNumber + "']");
                    rootNode.RemoveChild(deleteNode);
                    this.fileSave(tsfile, @"Project_task_d.xml");

                }
                catch (Exception)
                {
                    Console.WriteLine("error");
                    throw;
                }

                this.loadXmlTree();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void deleteTask(Decimal taskNumber, Decimal projectNumber)
        {
            try
            {
                if (projects.First(p => p.number == projectNumber).tasks.Count(t => t.number == taskNumber) == 0)
                {
                    MessageBox.Show("No task exists with this number on this project", "Error", MessageBoxButtons.OK);
                    return;
                }

                FileStream fs = new FileStream(FileRepository.getInstance().appData + @"Project_task_d.xml", FileMode.Open, FileAccess.ReadWrite);
                XmlDocument tsfile = new XmlDocument();
                tsfile.Load(fs);

                try
                {
                    XmlNode rootNode = tsfile.DocumentElement.SelectSingleNode("/TimeSheet/Project[@number='" + projectNumber + "']");
                    fs.Close();

                    XmlNode taskNode = rootNode.SelectSingleNode("Task[@number='" + taskNumber + "']");
                    rootNode.RemoveChild(taskNode);
                    this.fileSave(tsfile, @"Project_task_d.xml");

                }
                catch (Exception)
                {
                    Console.WriteLine("error");
                    throw;
                }

                this.loadXmlTree();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void updateJob(Job job)
        {
        }


        #endregion

        #region find_Treeview

        public Decimal findProjectNumberFromSelectedNode()
        {
            int level = selectedNode.Level;

            int projectIndex = -1;

            switch (level)
            {
                case 0:
                    projectIndex = selectedNode.Index;
                    break;
                case 1:
                    projectIndex = selectedNode.Parent.Index;
                    break;
                case 2:
                    projectIndex = selectedNode.Parent.Parent.Index;
                    break;
                default:
                    break;
            }

            return this.projects[projectIndex].number;
        }

        public Task findTaskFromSelectedNode()
        {
            int level = selectedNode.Level;

            int taskIndex = -1;

            switch (level)
            {
                case 0:
                    return null;
                case 1:
                    taskIndex = selectedNode.Index;
                    return this.projects[selectedNode.Parent.Index].tasks[selectedNode.Index];

                case 2:
                    taskIndex = selectedNode.Parent.Index;
                    return this.projects[selectedNode.Parent.Parent.Index].tasks[selectedNode.Parent.Index];
                default:
                    break;
            }
            return null;
            
        }

        public Task findTaskFromJobId(Decimal jobId)
        {

            return (Task) this.projects.Select(p => p.tasks.FirstOrDefault(t => t.jobs.Count(j => j.number == jobId)>0)).FirstOrDefault();
        }

        public Job findJobFromSelectedNode()
        {
            int level = selectedNode.Level;

            int jobIndex = -1;

            switch (level)
            {
                case 0:
                    return null;
                case 1:
                    return null;
                case 2:
                    jobIndex = selectedNode.Index;
                    break;
                default:
                    break;
            }

            return this.projects[selectedNode.Parent.Parent.Index].tasks[selectedNode.Parent.Index].jobs[jobIndex];
         }

        public Job findJobFromId(Decimal jobId)
        {
            foreach (var project in this.projects)
            {
                foreach (var task in project.tasks)
                {
                    foreach (var job in task.jobs)
                    {
                        if (job.number == jobId)
                        {
                            return job;
                        }
                    }
                }
            }
            return null;
        }
 
        #endregion

        #region Add_Del_Upd_Sheet

        public void addSheet(Sheet sheet)
        {
            DateTime jobDate = sheet.start;
            FileStream fs;
            if (!File.Exists(FileRepository.getInstance().appData + jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml"))
            {
                fs = File.Create(FileRepository.getInstance().appData + jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml");
                               
                StreamWriter m_streamWriter = new StreamWriter(fs);
                // Write to the file using StreamWriter class
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(@"<?xml version=""1.0"" encoding=""ISO-8859-1""?>");
                m_streamWriter.WriteLine(@"<TimeSheet>");
                m_streamWriter.WriteLine(@"</TimeSheet>");
                m_streamWriter.Flush();
                fs.Close();
                
            }

            fs = new FileStream(FileRepository.getInstance().appData + jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml", FileMode.Open, FileAccess.ReadWrite);
            XmlDocument tsfile = new XmlDocument();
            tsfile.Load(fs);

            try
            {
                XmlNode rootNode = tsfile.SelectSingleNode(@"/TimeSheet");
                XmlElement sheetNode = tsfile.CreateElement("", "sheet", "");
                sheetNode.SetAttribute("ma", sheet.job.number.ToString());

                XmlNode startAttr = tsfile.CreateNode(XmlNodeType.Element, "start", "");
                startAttr.InnerText = sheet.start.ToShortDateString()+ " " + sheet.start.ToLongTimeString();
                sheetNode.AppendChild(startAttr);

                XmlNode endAttr = tsfile.CreateNode(XmlNodeType.Element, "end", "");
                endAttr.InnerText = sheet.end.ToShortDateString()+ " " + sheet.end.ToLongTimeString();
                sheetNode.AppendChild(endAttr);

                XmlNode noteAttr = tsfile.CreateNode(XmlNodeType.Element, "note", "");
                noteAttr.InnerText = sheet.note;
                sheetNode.AppendChild(noteAttr);
                

                rootNode.AppendChild(sheetNode);
                fs.Close();
                this.fileSave(tsfile, jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml");

            }
            catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }

            this.loadMonthXml(jobDate.Month, jobDate.Year);


        }

        public void deleteSheet(Sheet sheet)
        {

                if (sheets.Count(s => s == sheet) == 0)
                {
                    MessageBox.Show("No sheet exists with this number on this project", "Error", MessageBoxButtons.OK);
                    return;
                }

                DateTime jobDate = sheet.start;
                FileStream fs = new FileStream(FileRepository.getInstance().appData + jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml", FileMode.Open, FileAccess.ReadWrite);
                XmlDocument tsfile = new XmlDocument();

                    tsfile.Load(fs);
                    fs.Close();

                    foreach (XmlElement sheetElem in tsfile.SelectSingleNode(@"TimeSheet").ChildNodes)
                    {
                        //TODO: test if the childNode is really a sheet
                        Decimal v_sheet_job_id = Decimal.Parse(sheetElem.GetAttribute("ma"));
                        DateTime v_sheet_start = DateTime.Parse(sheetElem.SelectSingleNode("start").FirstChild.Value);
                        DateTime v_sheet_stop = DateTime.Parse(sheetElem.SelectSingleNode("end").FirstChild.Value);
                        String v_sheet_note = (sheetElem.SelectSingleNode("note").FirstChild == null ? null : sheetElem.SelectSingleNode("note").FirstChild.Value);  

                        Sheet loadedSheet = new Sheet() {job = this.findJobFromId(v_sheet_job_id), start = v_sheet_start, end = v_sheet_stop, note = v_sheet_note };

                        if (sheet == loadedSheet)
                        {
                            tsfile.SelectSingleNode(@"TimeSheet").RemoveChild(sheetElem);
                            break;
                        }

                    }
                    this.fileSave(tsfile, jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml");


                this.loadMonthXml(jobDate.Month, jobDate.Year);
        }

        public void updateSheet(Sheet newSheet, Sheet oldSheet)
        {

            if (sheets.Count(s => s == oldSheet) == 0)
            {
                MessageBox.Show("No sheet exists with this number on this project", "Error", MessageBoxButtons.OK);
                return;
            }

            DateTime jobDate = oldSheet.start;
            FileStream fs = new FileStream(FileRepository.getInstance().appData + jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml", FileMode.Open, FileAccess.ReadWrite);
            XmlDocument tsfile = new XmlDocument();

             

            tsfile.Load(fs);
            fs.Close();

            foreach (XmlElement sheetElem in tsfile.SelectSingleNode(@"TimeSheet").ChildNodes)
            {
                //TODO: test if the childNode is really a sheet
                Decimal v_sheet_job_id = Decimal.Parse(sheetElem.GetAttribute("ma"));
                DateTime v_sheet_start = DateTime.Parse(sheetElem.SelectSingleNode("start").FirstChild.Value);
                DateTime v_sheet_stop = DateTime.Parse(sheetElem.SelectSingleNode("end").FirstChild.Value);
                String v_sheet_note = (sheetElem.SelectSingleNode("note").FirstChild == null ? null : sheetElem.SelectSingleNode("note").FirstChild.Value);

                Sheet loadedSheet = new Sheet() { job = this.findJobFromId(v_sheet_job_id), start = v_sheet_start, end = v_sheet_stop, note = v_sheet_note };

                if (oldSheet == loadedSheet)
                {
                    XmlNode rootNode = tsfile.SelectSingleNode(@"/TimeSheet");
                  
                    XmlElement newSheetNode = tsfile.CreateElement("", "sheet", "");
                    newSheetNode.SetAttribute("ma", newSheet.job.number.ToString());

                    XmlNode startAttr = tsfile.CreateNode(XmlNodeType.Element, "start", "");
                    startAttr.InnerText = newSheet.start.ToShortDateString()+ " " + newSheet.start.ToLongTimeString();
                    newSheetNode.AppendChild(startAttr);

                    XmlNode endAttr = tsfile.CreateNode(XmlNodeType.Element, "end", "");
                    endAttr.InnerText = newSheet.end.ToShortDateString()+ " " + newSheet.end.ToLongTimeString();
                    newSheetNode.AppendChild(endAttr);

                    XmlNode noteAttr = tsfile.CreateNode(XmlNodeType.Element, "note", "");
                    noteAttr.InnerText = newSheet.note;
                    newSheetNode.AppendChild(noteAttr);

                    rootNode.ReplaceChild(newSheetNode, sheetElem);
                    break;
                }

            }
            this.fileSave(tsfile, jobDate.Year.ToString("0000") + jobDate.Month.ToString("00") + @".xml");


            this.loadMonthXml(jobDate.Month, jobDate.Year);
        }


        #endregion
    }


}
