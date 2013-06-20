namespace TimeSheetControl.Forms
{
    partial class F_Job
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
            this.b_job_cancel = new System.Windows.Forms.Button();
            this.b_job_ok = new System.Windows.Forms.Button();
            this.tb_job_name = new System.Windows.Forms.MaskedTextBox();
            this.tb_job_number = new System.Windows.Forms.MaskedTextBox();
            this.l_job_name = new System.Windows.Forms.Label();
            this.l_job_number = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_job_cancel);
            this.groupBox1.Controls.Add(this.b_job_ok);
            this.groupBox1.Controls.Add(this.tb_job_name);
            this.groupBox1.Controls.Add(this.tb_job_number);
            this.groupBox1.Controls.Add(this.l_job_name);
            this.groupBox1.Controls.Add(this.l_job_number);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job";
            // 
            // b_job_cancel
            // 
            this.b_job_cancel.Location = new System.Drawing.Point(186, 111);
            this.b_job_cancel.Name = "b_job_cancel";
            this.b_job_cancel.Size = new System.Drawing.Size(93, 24);
            this.b_job_cancel.TabIndex = 5;
            this.b_job_cancel.Text = "Cancel";
            this.b_job_cancel.UseVisualStyleBackColor = true;
            this.b_job_cancel.Click += new System.EventHandler(this.b_job_cancel_Click);
            // 
            // b_job_ok
            // 
            this.b_job_ok.Location = new System.Drawing.Point(56, 111);
            this.b_job_ok.Name = "b_job_ok";
            this.b_job_ok.Size = new System.Drawing.Size(89, 25);
            this.b_job_ok.TabIndex = 4;
            this.b_job_ok.Text = "Ok";
            this.b_job_ok.UseVisualStyleBackColor = true;
            this.b_job_ok.Click += new System.EventHandler(this.b_job_ok_Click);
            // 
            // tb_job_name
            // 
            this.tb_job_name.Location = new System.Drawing.Point(97, 72);
            this.tb_job_name.Name = "tb_job_name";
            this.tb_job_name.Size = new System.Drawing.Size(171, 20);
            this.tb_job_name.TabIndex = 3;
            this.tb_job_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_job_name_KeyPress);
            // 
            // tb_job_number
            // 
            this.tb_job_number.Location = new System.Drawing.Point(97, 39);
            this.tb_job_number.Mask = "999999";
            this.tb_job_number.Name = "tb_job_number";
            this.tb_job_number.Size = new System.Drawing.Size(171, 20);
            this.tb_job_number.TabIndex = 2;
            this.tb_job_number.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.tb_job_number_MaskInputRejected);
            this.tb_job_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_job_number_KeyPress);
            // 
            // l_job_name
            // 
            this.l_job_name.AutoSize = true;
            this.l_job_name.Location = new System.Drawing.Point(53, 75);
            this.l_job_name.Name = "l_job_name";
            this.l_job_name.Size = new System.Drawing.Size(38, 13);
            this.l_job_name.TabIndex = 1;
            this.l_job_name.Text = "Name:";
            // 
            // l_job_number
            // 
            this.l_job_number.AutoSize = true;
            this.l_job_number.Location = new System.Drawing.Point(44, 42);
            this.l_job_number.Name = "l_job_number";
            this.l_job_number.Size = new System.Drawing.Size(47, 13);
            this.l_job_number.TabIndex = 0;
            this.l_job_number.Text = "Number:";
            // 
            // F_Job
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 158);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "F_Job";
            this.Text = "Add Job";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_job_name;
        private System.Windows.Forms.Label l_job_number;
        private System.Windows.Forms.MaskedTextBox tb_job_name;
        private System.Windows.Forms.MaskedTextBox tb_job_number;
        private System.Windows.Forms.Button b_job_ok;
        private System.Windows.Forms.Button b_job_cancel;
    }
}