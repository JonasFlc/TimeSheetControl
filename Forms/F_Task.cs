using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeSheetControl.Repository;

namespace TimeSheetControl.Forms
{
    public partial class F_Task : Form
    {
        public F_Task()
        {
            InitializeComponent();
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(t_number.Text) && !String.IsNullOrEmpty(t_name.Text))
            {
                ProjectRepository repository = ProjectRepository.getInstance();

                Decimal projectNumber = repository.findProjectNumberFromSelectedNode();
                try
                {
                    Decimal taskNumber = Decimal.Parse(t_number.Text);
                     repository.addTask(t_name.Text, taskNumber, projectNumber);
                
                }
                catch (FormatException)
                {

                    MessageBox.Show("Error: number must be a numeric", "Error", MessageBoxButtons.OK);
                }
                
                 //MessageBox.Show("Project number: " + projectNumber, "debug", MessageBoxButtons.OK);
                 ((Form1)this.Owner).displayTreeView();
                 this.Close();
                
                
                
            }
            else
            {
                MessageBox.Show("Error: name and number cannot be null", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
