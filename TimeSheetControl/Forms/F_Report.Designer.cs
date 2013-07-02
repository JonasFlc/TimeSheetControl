using TimeSheetControl.Repository;
using Microsoft.Reporting.WinForms;
namespace TimeSheetControl.Forms
{
    partial class F_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.b_today = new System.Windows.Forms.Button();
            this.b_prev = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.b_Refresh = new System.Windows.Forms.Button();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.t_To = new System.Windows.Forms.Label();
            this.t_From = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.b_today);
            this.splitContainer1.Panel1.Controls.Add(this.b_prev);
            this.splitContainer1.Panel1.Controls.Add(this.b_next);
            this.splitContainer1.Panel1.Controls.Add(this.b_Refresh);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_to);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_from);
            this.splitContainer1.Panel1.Controls.Add(this.t_To);
            this.splitContainer1.Panel1.Controls.Add(this.t_From);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(783, 567);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 0;
            // 
            // b_today
            // 
            this.b_today.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_today.Location = new System.Drawing.Point(191, 66);
            this.b_today.Name = "b_today";
            this.b_today.Size = new System.Drawing.Size(87, 23);
            this.b_today.TabIndex = 7;
            this.b_today.Text = "Today";
            this.b_today.UseVisualStyleBackColor = true;
            this.b_today.Click += new System.EventHandler(this.b_today_Click);
            // 
            // b_prev
            // 
            this.b_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_prev.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.b_prev.Image = global::TimeSheetControl.Properties.Resources.backward_241;
            this.b_prev.Location = new System.Drawing.Point(147, 66);
            this.b_prev.Name = "b_prev";
            this.b_prev.Size = new System.Drawing.Size(40, 23);
            this.b_prev.TabIndex = 6;
            this.b_prev.UseVisualStyleBackColor = true;
            this.b_prev.Click += new System.EventHandler(this.b_prev_Click);
            // 
            // b_next
            // 
            this.b_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_next.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.b_next.Image = global::TimeSheetControl.Properties.Resources.forward_241;
            this.b_next.Location = new System.Drawing.Point(284, 66);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(39, 23);
            this.b_next.TabIndex = 5;
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_Refresh
            // 
            this.b_Refresh.Location = new System.Drawing.Point(385, 36);
            this.b_Refresh.Name = "b_Refresh";
            this.b_Refresh.Size = new System.Drawing.Size(91, 23);
            this.b_Refresh.TabIndex = 4;
            this.b_Refresh.Text = "Refresh";
            this.b_Refresh.UseVisualStyleBackColor = true;
            this.b_Refresh.Click += new System.EventHandler(this.b_Refresh_Click);
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(137, 40);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 20);
            this.dtp_to.TabIndex = 3;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(137, 12);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(200, 20);
            this.dtp_from.TabIndex = 2;
            // 
            // t_To
            // 
            this.t_To.AutoSize = true;
            this.t_To.Location = new System.Drawing.Point(108, 46);
            this.t_To.Name = "t_To";
            this.t_To.Size = new System.Drawing.Size(23, 13);
            this.t_To.TabIndex = 1;
            this.t_To.Text = "To:";
            // 
            // t_From
            // 
            this.t_From.AutoSize = true;
            this.t_From.Location = new System.Drawing.Point(98, 18);
            this.t_From.Name = "t_From";
            this.t_From.Size = new System.Drawing.Size(33, 13);
            this.t_From.TabIndex = 0;
            this.t_From.Text = "From:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.table1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TimeSheetControl.DTO.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(783, 470);
            this.reportViewer1.TabIndex = 0;
            // 
            // F_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 567);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "F_Report";
            this.Text = "Report timesheet";
            this.Load += new System.EventHandler(this.F_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label t_To;
        private System.Windows.Forms.Label t_From;
        private System.Windows.Forms.Button b_Refresh;
        private DTO.DataSet1 dataSet1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource1;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private System.Windows.Forms.Button b_prev;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_today;
    }
}