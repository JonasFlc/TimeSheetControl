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
    public partial class F_Job : Form
    {
        public F_Job()
        {
            InitializeComponent();
        }

        private void b_job_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_job_ok_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_job_number.Text) && !String.IsNullOrEmpty(tb_job_name.Text))
            {
                ProjectRepository repository = ProjectRepository.getInstance();

                Task selectedTask = repository.findTaskFromSelectedNode();

                try
                {
                    Decimal jobNumber = Decimal.Parse(tb_job_number.Text);
                     repository.addJob(tb_job_name.Text, jobNumber, selectedTask.number, selectedTask.project.number);

                     ((Form1)this.Owner).displayTreeView();
                     ((Form1)this.Owner).FocusJob(jobNumber);
                
                }
                catch (FormatException)
                {

                    MessageBox.Show("Error: number must be a numeric", "Error", MessageBoxButtons.OK);
                }
                
                 //MessageBox.Show("Project number: " + projectNumber, "debug", MessageBoxButtons.OK);
                 
                 this.Close();
                
                
                
            }
            else
            {
                MessageBox.Show("Error: name and number cannot be null", "Error", MessageBoxButtons.OK);
            }
        }

        private void tb_job_number_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Error: number must be a numeric", "Error", MessageBoxButtons.OK);
        }

        private void tb_job_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.tb_job_name.Focus();
            }

        }

        private void tb_job_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.b_job_ok.Focus();
            }
        }

       

      
    }
}
