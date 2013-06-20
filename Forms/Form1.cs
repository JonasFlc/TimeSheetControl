using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using TimeSheetControl.Object;
using TimeSheetControl.Repository;
using TimeSheetControl.DTO;
using TimeSheetControl.Forms;

namespace TimeSheetControl
{
    public partial class Form1 : Form
    {

        private ProjectRepository projectRepository;
        private FileRepository fileRepository;
        private TimeSpan passedTime;
        private IdleManagment idleManagment;
        private TreeNode dragNode;

        public Form1()
        {
            InitializeComponent();

            idleTimer.Interval = 1000; // 1sec 
            idleTimer.Start(); 
            idleManagment = IdleManagment.getInstance();

            this.projectRepository = ProjectRepository.getInstance();

            this.fileRepository = FileRepository.getInstance();
            this.fileRepository.initialiseApp();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            projectRepository.currentMonth = DateTime.Today.Month;
            projectRepository.currentYear = DateTime.Today.Year;
            projectRepository.loadXmlTree();
            

            this.displayTreeView();

            projectRepository.loadMonthXml(DateTime.Today.Month, DateTime.Today.Year);
            
            this.displayDataGrid(DateTime.Today);
            this.setupDataGrid();
            this.dateTimePicker1.Value = DateTime.Today;

            t_start.Enabled = false;
            t_stop.Enabled = false;
            

        }

        public void displayTreeView()
        {
            treeView1.Nodes.Clear();

            foreach (var treenode in projectRepository.treeNode.Nodes)
            {
                treeView1.Nodes.Add((TreeNode)treenode);
            }

            
        }

        private void setupDataGrid()
        {
            //projetc id
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //project name
            dataGridView1.Columns[1].HeaderText = "Project";
            dataGridView1.Columns[3].Width = 200;

            //Task id
            dataGridView1.Columns[2].HeaderText = "";
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Task name
            dataGridView1.Columns[3].HeaderText = "Task";
            dataGridView1.Columns[3].Width = 150;

            //Job id
            dataGridView1.Columns[4].HeaderText = "";
            dataGridView1.Columns[4].Width = 40;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Job name
            dataGridView1.Columns[5].HeaderText = "Job";
            dataGridView1.Columns[5].Width = 250;

            //start time
            dataGridView1.Columns[6].HeaderText = "Start time";
            dataGridView1.Columns[6].Width = 85;
            dataGridView1.Columns[6].ValueType = typeof(DateTime);
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //end time
            dataGridView1.Columns[7].HeaderText = "End time";
            dataGridView1.Columns[7].Width = 85;
            dataGridView1.Columns[7].ValueType = typeof(DateTime);
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //duration
            dataGridView1.Columns[8].HeaderText = "Duration";
            dataGridView1.Columns[8].Width = 85;
            dataGridView1.Columns[8].ValueType = typeof(TimeSpan);
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //notes
            dataGridView1.Columns[9].HeaderText = "Notes";
        }

        private void displayDataGrid(DateTime date)
        {
            AdvancedList<SheetDTO> sheetDTOs = projectRepository.GetSheetDTOByDate(date);
            if (sheetDTOs == null)
            {
                return;
            }
            dataGridView1.DataSource = sheetDTOs;        

            if (projectRepository.actualSheet != null && dateTimePicker1.Value.Date.Equals(DateTime.Today))
            {
                int lastrow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None);

                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new Font(dataGridView1.Font, FontStyle.Bold);

                dataGridView1.Rows[lastrow].DefaultCellStyle = style;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            projectRepository.selectedNode = e.Node;
            this.switchStartStop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Month != projectRepository.currentMonth || dateTimePicker1.Value.Year != projectRepository.currentMonth)
            {
                projectRepository.currentMonth = dateTimePicker1.Value.Month;
                projectRepository.currentYear = dateTimePicker1.Value.Year;
                projectRepository.loadMonthXml(projectRepository.currentMonth, projectRepository.currentYear);
            }
           
            displayDataGrid(dateTimePicker1.Value);
            dataGridView1.ClearSelection();
            projectRepository.selectedSheet = null;

            projectRepository.loadDailyTime(dateTimePicker1.Value);
            displayDailyTime(null);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
            F_Project add_project_form = new F_Project();
            add_project_form.ShowDialog(this);
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            displayTreeView();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            F_Task add_task_form = new F_Task();
            add_task_form.ShowDialog(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectRepository.selectedNode.Level == 0)
            {

                DialogResult result = MessageBox.Show("Are you sure you want delete this project ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Decimal projectNumber = projectRepository.findProjectNumberFromSelectedNode();
                    projectRepository.deleteProject(projectNumber);
                }
            }
            else if (projectRepository.selectedNode.Level == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want delete this task ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Decimal projectNumber = projectRepository.findProjectNumberFromSelectedNode();
                    Decimal taskNumber = projectRepository.findTaskFromSelectedNode().number;
                    //MessageBox.Show("project: "+projectNumber+" | task: "+taskNumber);
                    projectRepository.deleteTask(taskNumber, projectNumber);
                }
            }

            this.displayTreeView();
        }

        private void displayDailyTime(TimeSpan? tick)
        {
            TimeSpan currentTick;

            if (tick == null)
            {
                currentTick  = new TimeSpan();
            }
            else
            {
                currentTick = (TimeSpan)tick;
            }

            if (projectRepository.actualSheet != null && dateTimePicker1.Value.Date.Equals(DateTime.Today)) {
              
                t_total_daily.Text = "Total daily: " + projectRepository.dailyTime.Add(currentTick).ToString();
            }
            else
            {
                t_total_daily.Text = "Total daily: " + projectRepository.dailyTime.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.passedTime = this.passedTime.Add(new TimeSpan(0, 0, 1));
            t_time.Text = this.passedTime.ToString();

            displayDailyTime(this.passedTime);
        }
           
        private void switchStartStop(Boolean canStop = true) {

            //STOP
            if (isCurrentlySheetActive())
            {
                t_stop.Enabled = true;
            }
            else
            {
                t_stop.Enabled = false;
            }

            //START
            if (projectRepository.selectedNode.Level == 2 && !timer1.Enabled)
            {
                t_start.Enabled = true;
            }

            if (projectRepository.selectedNode.Level <= 1 )
            {
                t_start.Enabled = false;
            }
        }     

        

        public Boolean isCurrentlySheetActive()
        {
            if (timer1.Enabled) return true;
            else return false;
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            IdleManagment.getInstance().idleManage(sender, e, this);
        }

        public void setDebutMessage(String message) {
            debug_label.Text = message;
        }

        public void stopCurrentSheet(int idleTimePassed = 0)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                t_active_task.Text = "";
                t_title_active.Text = "No Active job";
                projectRepository.actualSheet.end = projectRepository.actualSheet.start.Add(this.passedTime).Subtract(new TimeSpan(0,idleTimePassed,0));

                this.switchStartStop();

                projectRepository.addSheet(projectRepository.actualSheet);
                projectRepository.actualSheet = null;
                this.displayDataGrid(dateTimePicker1.Value);
            }
        }

        public void startSheet(Sheet actualSheet)
        {
            projectRepository.actualSheet = actualSheet;
            t_active_task.Text = actualSheet.job.task.project.number + " - " + actualSheet.job.task.number + " " + actualSheet.job.task.name + " - " + actualSheet.job.number + " " + actualSheet.job.name;
            t_title_active.Text = "Active job:";
            this.passedTime = new TimeSpan(0, 0, 0);

            t_time.Text = this.passedTime.ToString();

            timer1.Interval = 1000;
            timer1.Start();

            t_start.Enabled = false;
            t_stop.Enabled = true;

            this.displayDataGrid(dateTimePicker1.Value);

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Options f_options = new F_Options();
            f_options.Show(this);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
            if (dataGridView1.SortedColumn!= null && dataGridView1.SortedColumn.Index == e.ColumnIndex)
            {
                if (dataGridView1.SortOrder == SortOrder.Ascending)
                {
                    dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                }
                else
                {
                    dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                }
            }
            else
            {
                
                dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.stopCurrentSheet();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (projectRepository.actualSheet != null)
            {
                notifyIcon1.BalloonTipText = "Active task: " + projectRepository.actualSheet.job.task.number + " " + projectRepository.actualSheet.job.task.name;
            }
            else
            {
                notifyIcon1.BalloonTipText = "No Active Task";
            }
            notifyIcon1.BalloonTipTitle = "Time Sheet Control";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info; 

            if (FormWindowState.Minimized == WindowState)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(500);
            }

        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;

        }

        private void t_start_Click_1(object sender, EventArgs e)
        {
            Sheet actualSheet = new Sheet();
            actualSheet.start = DateTime.Now;
            actualSheet.job = projectRepository.findJobFromSelectedNode();

            this.startSheet(actualSheet);
        }

        private void t_stop_Click_1(object sender, EventArgs e)
        {
            this.stopCurrentSheet();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (projectRepository.selectedSheet != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want delete this sheet ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    projectRepository.deleteSheet(projectRepository.selectedSheet);
                    this.displayDataGrid(dateTimePicker1.Value);
                    dataGridView1.ClearSelection();
                    projectRepository.selectedSheet = null;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Sheet selectedSheet = new Sheet();
                selectedSheet.job = projectRepository.findJobFromId(Decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
                selectedSheet.start = dateTimePicker1.Value.Date + TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null)
                    selectedSheet.end = dateTimePicker1.Value.Date + TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                
                projectRepository.selectedSheet = projectRepository.sheets.SingleOrDefault(s => s == selectedSheet);
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

          
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (timer1.Enabled)
            {
                this.stopCurrentSheet();
            }

            projectRepository.selectedNode = e.Node;

            if (projectRepository.selectedNode.Level == 2)
            {
                Sheet actualSheet = new Sheet();
                actualSheet.start = DateTime.Now;
                actualSheet.job = projectRepository.findJobFromSelectedNode();

                this.startSheet(actualSheet);
            }
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (projectRepository.selectedNode.Level >= 1)
            {
                F_Job add_job_form = new F_Job();
                add_job_form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Error: You have to choose at least a Task", "Error", MessageBoxButtons.OK);
            }
        }

        public void FocusJob(Decimal jobNumber)
        {
            Job job = projectRepository.findJobFromId(jobNumber);
            treeView1.CollapseAll();
            treeView1.Nodes[job.task.project.number.ToString()].Expand();
            treeView1.Nodes[job.task.project.number.ToString()].Nodes[job.task.number.ToString()].Expand();
            treeView1.HideSelection = false;
            treeView1.SelectedNode = treeView1.Nodes[job.task.project.number.ToString()].Nodes[job.task.number.ToString()].Nodes[job.number.ToString()];

            projectRepository.selectedNode = treeView1.SelectedNode;
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            F_Sheet add_sheet_form = new F_Sheet();
            projectRepository.currentScreenMode = ProjectRepository.screenMode.newMode;
            add_sheet_form.ShowDialog(this);
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[7].Value == null || dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == String.Empty)
            {
                return;
            }
            else
            {
                F_Sheet edit_sheet_form = new F_Sheet();
                projectRepository.currentScreenMode = ProjectRepository.screenMode.editMode;
                edit_sheet_form.ShowDialog(this);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.dragNode = (TreeNode) e.Item;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point position = new Point(0, 0);
            position.X = e.X;
            position.Y = e.Y;
            position = treeView1.PointToClient(position);

            TreeNode dropNode = this.treeView1.GetNodeAt(position);
            Job dragJob;
            Job dropJob;

            if (this.dragNode.Level == 2 && dropNode.Level == 2 ){
                dragJob = projectRepository.findJobFromId(Decimal.Parse(dragNode.Name));
                dropJob = projectRepository.findJobFromId(Decimal.Parse(dropNode.Name));


                if (dragJob.task.number != dropJob.task.number)
                {
                    dragJob.task = dropJob.task;
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



    }

}
