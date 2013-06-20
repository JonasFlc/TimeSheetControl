namespace TimeSheetControl.Forms
{
    partial class F_Sheet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_task = new System.Windows.Forms.ComboBox();
            this.c_project = new System.Windows.Forms.ComboBox();
            this.t_task = new System.Windows.Forms.Label();
            this.t_project = new System.Windows.Forms.Label();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_ok = new System.Windows.Forms.Button();
            this.c_job = new System.Windows.Forms.ComboBox();
            this.tb_note = new System.Windows.Forms.TextBox();
            this.dt_end_time = new System.Windows.Forms.DateTimePicker();
            this.dt_end_date = new System.Windows.Forms.DateTimePicker();
            this.dt_start_time = new System.Windows.Forms.DateTimePicker();
            this.dt_start_date = new System.Windows.Forms.DateTimePicker();
            this.t_note = new System.Windows.Forms.Label();
            this.t_end = new System.Windows.Forms.Label();
            this.t_start = new System.Windows.Forms.Label();
            this.t_job = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c_task);
            this.groupBox1.Controls.Add(this.c_project);
            this.groupBox1.Controls.Add(this.t_task);
            this.groupBox1.Controls.Add(this.t_project);
            this.groupBox1.Controls.Add(this.b_cancel);
            this.groupBox1.Controls.Add(this.b_ok);
            this.groupBox1.Controls.Add(this.c_job);
            this.groupBox1.Controls.Add(this.tb_note);
            this.groupBox1.Controls.Add(this.dt_end_time);
            this.groupBox1.Controls.Add(this.dt_end_date);
            this.groupBox1.Controls.Add(this.dt_start_time);
            this.groupBox1.Controls.Add(this.dt_start_date);
            this.groupBox1.Controls.Add(this.t_note);
            this.groupBox1.Controls.Add(this.t_end);
            this.groupBox1.Controls.Add(this.t_start);
            this.groupBox1.Controls.Add(this.t_job);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 356);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sheet";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // c_task
            // 
            this.c_task.FormattingEnabled = true;
            this.c_task.Location = new System.Drawing.Point(72, 49);
            this.c_task.Name = "c_task";
            this.c_task.Size = new System.Drawing.Size(265, 21);
            this.c_task.TabIndex = 15;
            this.c_task.SelectedIndexChanged += new System.EventHandler(this.c_task_SelectedIndexChanged);
            // 
            // c_project
            // 
            this.c_project.FormattingEnabled = true;
            this.c_project.Location = new System.Drawing.Point(72, 22);
            this.c_project.Name = "c_project";
            this.c_project.Size = new System.Drawing.Size(265, 21);
            this.c_project.TabIndex = 14;
            this.c_project.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // t_task
            // 
            this.t_task.AutoSize = true;
            this.t_task.Location = new System.Drawing.Point(21, 52);
            this.t_task.Name = "t_task";
            this.t_task.Size = new System.Drawing.Size(34, 13);
            this.t_task.TabIndex = 13;
            this.t_task.Text = "Task:";
            // 
            // t_project
            // 
            this.t_project.AutoSize = true;
            this.t_project.Location = new System.Drawing.Point(12, 25);
            this.t_project.Name = "t_project";
            this.t_project.Size = new System.Drawing.Size(43, 13);
            this.t_project.TabIndex = 12;
            this.t_project.Text = "Project:";
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(292, 320);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(105, 23);
            this.b_cancel.TabIndex = 11;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(182, 320);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(104, 23);
            this.b_ok.TabIndex = 10;
            this.b_ok.Text = "Ok";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // c_job
            // 
            this.c_job.FormattingEnabled = true;
            this.c_job.Location = new System.Drawing.Point(72, 77);
            this.c_job.Name = "c_job";
            this.c_job.Size = new System.Drawing.Size(265, 21);
            this.c_job.TabIndex = 9;
            // 
            // tb_note
            // 
            this.tb_note.AcceptsReturn = true;
            this.tb_note.Location = new System.Drawing.Point(65, 171);
            this.tb_note.Multiline = true;
            this.tb_note.Name = "tb_note";
            this.tb_note.Size = new System.Drawing.Size(332, 123);
            this.tb_note.TabIndex = 8;
            // 
            // dt_end_time
            // 
            this.dt_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_end_time.Location = new System.Drawing.Point(256, 131);
            this.dt_end_time.Name = "dt_end_time";
            this.dt_end_time.Size = new System.Drawing.Size(81, 20);
            this.dt_end_time.TabIndex = 7;
            // 
            // dt_end_date
            // 
            this.dt_end_date.Location = new System.Drawing.Point(72, 131);
            this.dt_end_date.Name = "dt_end_date";
            this.dt_end_date.Size = new System.Drawing.Size(178, 20);
            this.dt_end_date.TabIndex = 6;
            // 
            // dt_start_time
            // 
            this.dt_start_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_start_time.Location = new System.Drawing.Point(256, 105);
            this.dt_start_time.Name = "dt_start_time";
            this.dt_start_time.Size = new System.Drawing.Size(81, 20);
            this.dt_start_time.TabIndex = 5;
            // 
            // dt_start_date
            // 
            this.dt_start_date.Location = new System.Drawing.Point(72, 105);
            this.dt_start_date.Name = "dt_start_date";
            this.dt_start_date.Size = new System.Drawing.Size(178, 20);
            this.dt_start_date.TabIndex = 4;
            // 
            // t_note
            // 
            this.t_note.AutoSize = true;
            this.t_note.Location = new System.Drawing.Point(22, 174);
            this.t_note.Name = "t_note";
            this.t_note.Size = new System.Drawing.Size(33, 13);
            this.t_note.TabIndex = 3;
            this.t_note.Text = "Note:";
            // 
            // t_end
            // 
            this.t_end.AutoSize = true;
            this.t_end.Location = new System.Drawing.Point(26, 137);
            this.t_end.Name = "t_end";
            this.t_end.Size = new System.Drawing.Size(29, 13);
            this.t_end.TabIndex = 2;
            this.t_end.Text = "End:";
            // 
            // t_start
            // 
            this.t_start.AutoSize = true;
            this.t_start.Location = new System.Drawing.Point(23, 111);
            this.t_start.Name = "t_start";
            this.t_start.Size = new System.Drawing.Size(32, 13);
            this.t_start.TabIndex = 1;
            this.t_start.Text = "Start:";
            // 
            // t_job
            // 
            this.t_job.AutoSize = true;
            this.t_job.Location = new System.Drawing.Point(28, 80);
            this.t_job.Name = "t_job";
            this.t_job.Size = new System.Drawing.Size(27, 13);
            this.t_job.TabIndex = 0;
            this.t_job.Text = "Job:";
            // 
            // F_Sheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 356);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "F_Sheet";
            this.Text = "Edit sheet";
            this.Load += new System.EventHandler(this.F_Sheet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.ComboBox c_job;
        private System.Windows.Forms.TextBox tb_note;
        private System.Windows.Forms.DateTimePicker dt_end_time;
        private System.Windows.Forms.DateTimePicker dt_end_date;
        private System.Windows.Forms.DateTimePicker dt_start_time;
        private System.Windows.Forms.DateTimePicker dt_start_date;
        private System.Windows.Forms.Label t_note;
        private System.Windows.Forms.Label t_end;
        private System.Windows.Forms.Label t_start;
        private System.Windows.Forms.Label t_job;
        private System.Windows.Forms.ComboBox c_project;
        private System.Windows.Forms.Label t_task;
        private System.Windows.Forms.Label t_project;
        private System.Windows.Forms.ComboBox c_task;
    }
}