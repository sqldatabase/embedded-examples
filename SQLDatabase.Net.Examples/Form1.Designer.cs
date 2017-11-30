namespace SQLDatabase.Net.Examples
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
            this.MultiRead = new System.Windows.Forms.Button();
            this.ParallelRead = new System.Windows.Forms.Button();
            this.ParallelInsert = new System.Windows.Forms.Button();
            this.MarsEnabled = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.ExtendedResults = new System.Windows.Forms.Button();
            this.ParallelInsertFile = new System.Windows.Forms.Button();
            this.SavePoint = new System.Windows.Forms.Button();
            this.MixedLanguages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MultiRead
            // 
            this.MultiRead.Location = new System.Drawing.Point(39, 13);
            this.MultiRead.Name = "MultiRead";
            this.MultiRead.Size = new System.Drawing.Size(82, 38);
            this.MultiRead.TabIndex = 1;
            this.MultiRead.Text = "Parallel Read";
            this.MultiRead.UseVisualStyleBackColor = true;
            this.MultiRead.Click += new System.EventHandler(this.MultiRead_Click);
            // 
            // ParallelRead
            // 
            this.ParallelRead.Location = new System.Drawing.Point(127, 13);
            this.ParallelRead.Name = "ParallelRead";
            this.ParallelRead.Size = new System.Drawing.Size(103, 38);
            this.ParallelRead.TabIndex = 2;
            this.ParallelRead.Text = "Parallel RecordSet";
            this.ParallelRead.UseVisualStyleBackColor = true;
            this.ParallelRead.Click += new System.EventHandler(this.ParallelRead_Click);
            // 
            // ParallelInsert
            // 
            this.ParallelInsert.Location = new System.Drawing.Point(236, 13);
            this.ParallelInsert.Name = "ParallelInsert";
            this.ParallelInsert.Size = new System.Drawing.Size(133, 38);
            this.ParallelInsert.TabIndex = 3;
            this.ParallelInsert.Text = "Parallel Insert @memory";
            this.ParallelInsert.UseVisualStyleBackColor = true;
            this.ParallelInsert.Click += new System.EventHandler(this.ParallelInsert_Click);
            // 
            // MarsEnabled
            // 
            this.MarsEnabled.Location = new System.Drawing.Point(39, 57);
            this.MarsEnabled.Name = "MarsEnabled";
            this.MarsEnabled.Size = new System.Drawing.Size(146, 38);
            this.MarsEnabled.TabIndex = 4;
            this.MarsEnabled.Text = "Multiple Active Result Sets";
            this.MarsEnabled.UseVisualStyleBackColor = true;
            this.MarsEnabled.Click += new System.EventHandler(this.MarsEnabled_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(191, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(409, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(193, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // ExtendedResults
            // 
            this.ExtendedResults.Location = new System.Drawing.Point(562, 12);
            this.ExtendedResults.Name = "ExtendedResults";
            this.ExtendedResults.Size = new System.Drawing.Size(114, 38);
            this.ExtendedResults.TabIndex = 7;
            this.ExtendedResults.Text = "Extended ResultSets";
            this.ExtendedResults.UseVisualStyleBackColor = true;
            this.ExtendedResults.Click += new System.EventHandler(this.ExtendedResults_Click);
            // 
            // ParallelInsertFile
            // 
            this.ParallelInsertFile.Location = new System.Drawing.Point(375, 12);
            this.ParallelInsertFile.Name = "ParallelInsertFile";
            this.ParallelInsertFile.Size = new System.Drawing.Size(99, 38);
            this.ParallelInsertFile.TabIndex = 8;
            this.ParallelInsertFile.Text = "Parallel Insert File";
            this.ParallelInsertFile.UseVisualStyleBackColor = true;
            this.ParallelInsertFile.Click += new System.EventHandler(this.ParallelInsertFile_Click);
            // 
            // SavePoint
            // 
            this.SavePoint.Location = new System.Drawing.Point(481, 13);
            this.SavePoint.Name = "SavePoint";
            this.SavePoint.Size = new System.Drawing.Size(75, 37);
            this.SavePoint.TabIndex = 9;
            this.SavePoint.Text = "SavePoint";
            this.SavePoint.UseVisualStyleBackColor = true;
            this.SavePoint.Click += new System.EventHandler(this.SavePoint_Click);
            // 
            // MixedLanguages
            // 
            this.MixedLanguages.Location = new System.Drawing.Point(39, 102);
            this.MixedLanguages.Name = "MixedLanguages";
            this.MixedLanguages.Size = new System.Drawing.Size(146, 32);
            this.MixedLanguages.TabIndex = 10;
            this.MixedLanguages.Text = "Mixed Languages";
            this.MixedLanguages.UseVisualStyleBackColor = true;
            this.MixedLanguages.Click += new System.EventHandler(this.MixedLanguages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 156);
            this.Controls.Add(this.MixedLanguages);
            this.Controls.Add(this.SavePoint);
            this.Controls.Add(this.ParallelInsertFile);
            this.Controls.Add(this.ExtendedResults);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.MarsEnabled);
            this.Controls.Add(this.ParallelInsert);
            this.Controls.Add(this.ParallelRead);
            this.Controls.Add(this.MultiRead);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MultiRead;
        private System.Windows.Forms.Button ParallelRead;
        private System.Windows.Forms.Button ParallelInsert;
        private System.Windows.Forms.Button MarsEnabled;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button ExtendedResults;
        private System.Windows.Forms.Button ParallelInsertFile;
        private System.Windows.Forms.Button SavePoint;
        private System.Windows.Forms.Button MixedLanguages;
    }
}

