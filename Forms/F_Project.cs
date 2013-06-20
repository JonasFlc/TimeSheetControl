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
    public partial class F_Project : Form
    {
        public F_Project()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

                try
                {
                    Decimal projectNumber = Decimal.Parse(t_number.Text);
                       if (repository.projects.Count(p => p.number == projectNumber) == 0 && projectNumber != 0)
                    {
                        repository.addProject(t_name.Text, projectNumber);
                    }
                    else
                    {
                        MessageBox.Show("Error: a task with this number already exists or task number cannot be 0", "Error", MessageBoxButtons.OK);
                    }

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
