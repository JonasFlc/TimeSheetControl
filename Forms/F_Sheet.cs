using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeSheetControl.Repository;
using TimeSheetControl.Object;

namespace TimeSheetControl.Forms
{
    public partial class F_Sheet : Form
    {
        private ProjectRepository projectRepository;
        private Sheet oldSheet;

        public F_Sheet()
        {
            InitializeComponent();
        }

        private void F_Sheet_Load(object sender, EventArgs e)
        {
            projectRepository = ProjectRepository.getInstance();
            c_project.DataSource = projectRepository.projects;
            c_project.DisplayMember = "projectName";
            c_project.ValueMember = "number";

            if (projectRepository.currentScreenMode == ProjectRepository.screenMode.editMode)
            {
                this.oldSheet = projectRepository.selectedSheet;

                c_project.SelectedValue = projectRepository.selectedSheet.job.task.project.number;
                this.comboBox1_SelectedIndexChanged(sender,e);

                c_task.SelectedValue = projectRepository.selectedSheet.job.task.number;
                this.c_task_SelectedIndexChanged(sender, e);

                c_job.SelectedValue = projectRepository.selectedSheet.job.number;

                dt_start_date.Value = projectRepository.selectedSheet.start.Date;
                dt_start_time.Value = projectRepository.selectedSheet.start;

                dt_end_date.Value = projectRepository.selectedSheet.end.Date;
                dt_end_time.Value = projectRepository.selectedSheet.end;

                tb_note.Text = projectRepository.selectedSheet.note;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_task.DataSource =((Project)c_project.SelectedItem).tasks;
            c_task.DisplayMember = "taskName";
            c_task.ValueMember = "number";
        }

        private void c_task_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_job.DataSource = ((Task)c_task.SelectedItem).jobs;
            c_job.DisplayMember = "jobName";
            c_job.ValueMember = "number";
        }


        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
          
            Sheet newSheet = new Sheet()
            {
                job = (Job)c_job.SelectedItem,
                start = (dt_start_date.Value.Date).Add(dt_start_time.Value.TimeOfDay),
                end = (dt_end_date.Value.Date).Add(dt_end_time.Value.TimeOfDay),
                note = tb_note.Text
            };

          if (projectRepository.currentScreenMode == ProjectRepository.screenMode.newMode)
           {
                projectRepository.addSheet(newSheet);
            }
            else if (projectRepository.currentScreenMode == ProjectRepository.screenMode.editMode)
            {
                projectRepository.updateSheet(newSheet, oldSheet);

            }
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
