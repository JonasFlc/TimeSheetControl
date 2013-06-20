namespace TimeSheetControl.Forms
{
    partial class F_Options
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_general = new System.Windows.Forms.TabPage();
            this.num_to_min = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.num_to_hour = new System.Windows.Forms.NumericUpDown();
            this.num_from_min = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.num_from_hour = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_retroactive = new System.Windows.Forms.CheckBox();
            this.t_idle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ck_autostart = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_general.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_to_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_to_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_from_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_from_hour)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(325, 284);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_general);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(325, 255);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_general
            // 
            this.tab_general.Controls.Add(this.ck_autostart);
            this.tab_general.Controls.Add(this.label8);
            this.tab_general.Controls.Add(this.num_to_min);
            this.tab_general.Controls.Add(this.label7);
            this.tab_general.Controls.Add(this.num_to_hour);
            this.tab_general.Controls.Add(this.num_from_min);
            this.tab_general.Controls.Add(this.label6);
            this.tab_general.Controls.Add(this.num_from_hour);
            this.tab_general.Controls.Add(this.label5);
            this.tab_general.Controls.Add(this.label4);
            this.tab_general.Controls.Add(this.label3);
            this.tab_general.Controls.Add(this.c_retroactive);
            this.tab_general.Controls.Add(this.t_idle);
            this.tab_general.Controls.Add(this.label2);
            this.tab_general.Controls.Add(this.label1);
            this.tab_general.Location = new System.Drawing.Point(4, 22);
            this.tab_general.Name = "tab_general";
            this.tab_general.Padding = new System.Windows.Forms.Padding(3);
            this.tab_general.Size = new System.Drawing.Size(317, 229);
            this.tab_general.TabIndex = 0;
            this.tab_general.Text = "General";
            this.tab_general.UseVisualStyleBackColor = true;
            // 
            // num_to_min
            // 
            this.num_to_min.Location = new System.Drawing.Point(176, 151);
            this.num_to_min.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_to_min.Name = "num_to_min";
            this.num_to_min.Size = new System.Drawing.Size(45, 20);
            this.num_to_min.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "h";
            // 
            // num_to_hour
            // 
            this.num_to_hour.Location = new System.Drawing.Point(111, 151);
            this.num_to_hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.num_to_hour.Name = "num_to_hour";
            this.num_to_hour.Size = new System.Drawing.Size(40, 20);
            this.num_to_hour.TabIndex = 23;
            // 
            // num_from_min
            // 
            this.num_from_min.Location = new System.Drawing.Point(176, 125);
            this.num_from_min.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_from_min.Name = "num_from_min";
            this.num_from_min.Size = new System.Drawing.Size(45, 20);
            this.num_from_min.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "h";
            // 
            // num_from_hour
            // 
            this.num_from_hour.Location = new System.Drawing.Point(111, 125);
            this.num_from_hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.num_from_hour.Name = "num_from_hour";
            this.num_from_hour.Size = new System.Drawing.Size(40, 20);
            this.num_from_hour.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "To: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "From: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Active period: ";
            // 
            // c_retroactive
            // 
            this.c_retroactive.AutoSize = true;
            this.c_retroactive.Location = new System.Drawing.Point(155, 62);
            this.c_retroactive.Name = "c_retroactive";
            this.c_retroactive.Size = new System.Drawing.Size(15, 14);
            this.c_retroactive.TabIndex = 16;
            this.c_retroactive.UseVisualStyleBackColor = true;
            // 
            // t_idle
            // 
            this.t_idle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_idle.Location = new System.Drawing.Point(155, 32);
            this.t_idle.Name = "t_idle";
            this.t_idle.Size = new System.Drawing.Size(60, 20);
            this.t_idle.TabIndex = 15;
            this.t_idle.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Retroactive idle time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Idle time (minutes)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Run application on windows start:";
            // 
            // ck_autostart
            // 
            this.ck_autostart.AutoSize = true;
            this.ck_autostart.Location = new System.Drawing.Point(202, 199);
            this.ck_autostart.Name = "ck_autostart";
            this.ck_autostart.Size = new System.Drawing.Size(15, 14);
            this.ck_autostart.TabIndex = 27;
            this.ck_autostart.UseVisualStyleBackColor = true;
            // 
            // F_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 284);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "F_Options";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.F_Options_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_general.ResumeLayout(false);
            this.tab_general.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_to_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_to_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_from_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_from_hour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_general;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown num_to_min;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_to_hour;
        private System.Windows.Forms.NumericUpDown num_from_min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_from_hour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox c_retroactive;
        private System.Windows.Forms.TextBox t_idle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_autostart;
        private System.Windows.Forms.Label label8;

    }
}