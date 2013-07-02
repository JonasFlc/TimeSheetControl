using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeSheetControl.Repository;
using Microsoft.Reporting.WinForms;
using TimeSheetControl.DTO;

namespace TimeSheetControl.Forms
{
    public partial class F_Report : Form
    {
        ProjectRepository repository;
        ReportRepository reportRepository;

        public F_Report()
        {
            InitializeComponent();
        }

        private void F_Report_Load(object sender, EventArgs e)
        {
            repository = ProjectRepository.getInstance();
            reportRepository = ReportRepository.getInstance();

            this.dtp_from.Value = new DateTime(repository.currentYear, repository.currentMonth, 1);
            this.dtp_to.Value = new DateTime(repository.currentYear, repository.currentMonth, DateTime.DaysInMonth(repository.currentYear, repository.currentMonth));
            loadReport();
        }

       

        private void b_Refresh_Click(object sender, EventArgs e)
        {
            loadReport();
        }
     

        private void loadReport() {
           
            reportRepository.fillSelectedProject(this.dtp_from.Value, this.dtp_to.Value);
            reportRepository.fillReportDTO();

            DataSet ds1 = DsUtil.ToDataSet<ReportDTO>(reportRepository.reportsDTO);
            this.table1BindingSource.DataSource = ds1.Tables[0];

            this.reportViewer1.RefreshReport();
        }

    
        private void b_next_Click(object sender, EventArgs e)
        {
            dtp_from.Value = dtp_from.Value.AddDays(1);
            dtp_to.Value = dtp_to.Value.AddDays(1);
            loadReport();
        }

        private void b_today_Click(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Today;
            dtp_to.Value = DateTime.Today;
            loadReport();
        }

        private void b_prev_Click(object sender, EventArgs e)
        {
            dtp_from.Value = dtp_from.Value.AddDays(-1);
            dtp_to.Value = dtp_to.Value.AddDays(-1);
            loadReport();
        }


    }
}
