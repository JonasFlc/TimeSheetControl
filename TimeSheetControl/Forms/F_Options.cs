using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TimeSheetControl.Forms
{
    public partial class F_Options : Form
    {

        string keyName = "TimeSheetControl";
        string assemblyLocation = Assembly.GetExecutingAssembly().Location;  

        public F_Options()
        {
            InitializeComponent();
            t_idle.Text = Properties.Settings.Default.idelTime.ToString();
            c_retroactive.Checked = Properties.Settings.Default.retroactive;
            num_from_hour.Value = Properties.Settings.Default.activeTimeFrom.Hours;
            num_from_min.Value = Properties.Settings.Default.activeTimeFrom.Minutes;
            num_to_hour.Value = Properties.Settings.Default.activeTimeTo.Hours;
            num_to_min.Value = Properties.Settings.Default.activeTimeTo.Minutes;
            ck_autostart.Checked = Util.IsAutoStartEnabled(keyName, assemblyLocation);
        }

        private void num_from_hour_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.idelTime = int.Parse(this.t_idle.Text);
            Properties.Settings.Default.retroactive = this.c_retroactive.Checked;
            Properties.Settings.Default.activeTimeFrom = new TimeSpan(int.Parse(num_from_hour.Value.ToString()), int.Parse(num_from_min.Value.ToString()),0);
            Properties.Settings.Default.activeTimeTo = new TimeSpan(int.Parse(num_to_hour.Value.ToString()), int.Parse(num_to_min.Value.ToString()), 0);
            if (ck_autostart.Checked)
            {
                Util.SetAutoStart(keyName, assemblyLocation);
            }
            else
            {
                Util.UnSetAutoStart(keyName);
            }
            this.Close();
        }

        private void F_Options_Load(object sender, EventArgs e)
        {
            
                
        }
    }
}
