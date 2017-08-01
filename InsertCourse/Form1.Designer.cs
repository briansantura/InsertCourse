namespace InsertCourse
{
    partial class Form1
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.collegeId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathToCSV = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.collegeId.Location = new System.Drawing.Point(700, 292);
            this.collegeId.Name = "collegeId";
            this.collegeId.Size = new System.Drawing.Size(100, 31);
            this.collegeId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(712, 264);
            this.label1.Name = "collegeIdLabel";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "College Id";
            // 
            // textBox2
            // 
            this.pathToCSV.Location = new System.Drawing.Point(400, 424);
            this.pathToCSV.Name = "pathToCSV";
            this.pathToCSV.Size = new System.Drawing.Size(713, 31);
            this.pathToCSV.TabIndex = 2;
            // 
            // button1
            // 
            this.loadButton.Location = new System.Drawing.Point(675, 475);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(125, 59);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "LOAD";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(loadButton_Click);
            //
            //Background worker 1
            //
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(insertCourse_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1674, 1139);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.pathToCSV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.collegeId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox collegeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathToCSV;
        private System.Windows.Forms.Button loadButton;
    }
}

