using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheetControl.Object;
using TimeSheetControl.DTO;
using System.Data;

namespace TimeSheetControl.Repository
{
    public sealed class ReportRepository
    {
         // L’instance du singleton. Cette instance doit être privée et statique.
        private static ReportRepository instance = null; 
        // Pour éviter, lors de l’utilisation de multiple thread, que plusieurs singleton soit instanciés.
        private static readonly object myLock = new object();

       
        // Le constructeur d’un singleton est TOUJOURS privée. 
        private ReportRepository()
        {
             projectRepository = ProjectRepository.getInstance();
        }

        // La méthode qui va nous permettre de récupérer l’unique instance de notre singleton.
        // La méthode doit être statique pour être appelé depuis le nom de la classe maClasse.getInstance();
        public static ReportRepository getInstance() 
        { 
            //lock permet de s’assurer qu’un thread n’entre pas dans une section critique du code pendant qu’un autre thread s’y trouve.  
            //Si un autre thread tente d’entrer dans un code verrouillé, il attendra, bloquera, jusqu’à ce que l’objet soit libéré.
            lock (myLock) 
            { 
                // Si on demande une instance qui n’existe pas, alors on crée notre RessourceManager.
                if (instance == null) instance = new ReportRepository();
                // Dans tous les cas on retourne l’unique instance de notre RessourceManager.
                return instance; 
            } 
        }

        public ISet<Project> projects { get; set; }
        public ISet<Task> tasks { get; set; }
        public ISet<Job> jobs { get; set; }

        private IDictionary<Decimal, TimeSpan> totalTimePojects { get; set; }
        private IDictionary<Decimal, TimeSpan> totalTimeTasks { get; set; }
        private Dictionary<Decimal, TimeSpan> totalTimeJobs { get; set; }

        private ProjectRepository projectRepository { get; set; }
        public IList<ReportDTO> reportsDTO { get; set; }

        public void fillSelectedProject(DateTime startDate, DateTime endDate)
        {
            DateTime scanDate = startDate;
            projects = new HashSet<Project>();
            totalTimePojects = new Dictionary<Decimal, TimeSpan>();

            tasks = new HashSet<Task>();
            totalTimeTasks = new Dictionary<Decimal, TimeSpan>();

            jobs = new HashSet<Job>();
            totalTimeJobs = new Dictionary<Decimal, TimeSpan>();


            do
            {
                IList<Sheet> monthSheets = projectRepository.loadMonthXmlSheets(scanDate.Month, scanDate.Year);
                foreach (Sheet monthSheet in monthSheets)
                {
                    if (monthSheet.start >= startDate && monthSheet.start < endDate.AddDays(1))
                    {
                        TimeSpan sheetTime = monthSheet.end.Subtract(monthSheet.start);

                        projects.Add(monthSheet.job.task.project);
                        if (totalTimePojects.ContainsKey(monthSheet.job.task.project.number))
                        {
                            totalTimePojects[monthSheet.job.task.project.number] = totalTimePojects[monthSheet.job.task.project.number].Add(sheetTime);
                        }
                        else
                        {
                            totalTimePojects.Add(monthSheet.job.task.project.number, sheetTime);
                        }

                        tasks.Add(monthSheet.job.task);
                        if (totalTimeTasks.ContainsKey(monthSheet.job.task.number))
                        {
                            totalTimeTasks[monthSheet.job.task.number] = totalTimeTasks[monthSheet.job.task.number].Add(sheetTime);
                        }
                        else
                        {
                            totalTimeTasks.Add(monthSheet.job.task.number, sheetTime);
                        }

                        jobs.Add(monthSheet.job);
                        if (totalTimeTasks.ContainsKey(monthSheet.job.number))
                        {
                            totalTimeTasks[monthSheet.job.number] = totalTimeTasks[monthSheet.job.number].Add(sheetTime);
                        }
                        else
                        {
                            totalTimeTasks.Add(monthSheet.job.number, sheetTime);
                        }
                    }

                }
                scanDate = scanDate.AddMonths(1);

            } while (scanDate.Month < endDate.Month || scanDate.Year < endDate.Year);
        }

        public void fillReportDTO()
        {
            reportsDTO = new List<ReportDTO>();

            foreach (Project project in projects)
            {
                ReportDTO p_DTO = new ReportDTO(project.number, project.name, 1, totalTimePojects[project.number]);
                reportsDTO.Add(p_DTO);

                foreach (Task task in project.tasks)
                {
                    if (totalTimeTasks.ContainsKey(task.number)){ 
                        ReportDTO t_dto = new ReportDTO(task.number, task.name, 2, totalTimeTasks[task.number]);
                        reportsDTO.Add(t_dto);
                    }
                    
               /*     foreach (Job job in task.jobs)
                    {
                        ReportDTO j_dto = new ReportDTO(job.number, job.name, 3);
                        reportsDTO.Add(j_dto);
                    }
                */
                }
                
            }
        }

  

      
    }
    
}
