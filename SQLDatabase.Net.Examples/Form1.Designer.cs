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
            this.CreateDropTable = new System.Windows.Forms.Button();
            this.SIUDOperations = new System.Windows.Forms.Button();
            this.IndexAndVacuum = new System.Windows.Forms.Button();
            this.SimpleTransaction = new System.Windows.Forms.Button();
            this.ToInMemoryDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MultiRead
            // 
            this.MultiRead.Location = new System.Drawing.Point(52, 16);
            this.MultiRead.Margin = new System.Windows.Forms.Padding(4);
            this.MultiRead.Name = "MultiRead";
            this.MultiRead.Size = new System.Drawing.Size(109, 47);
            this.MultiRead.TabIndex = 1;
            this.MultiRead.Text = "Parallel Read";
            this.MultiRead.UseVisualStyleBackColor = true;
            this.MultiRead.Click += new System.EventHandler(this.MultiRead_Click);
            // 
            // ParallelRead
            // 
            this.ParallelRead.Location = new System.Drawing.Point(169, 16);
            this.ParallelRead.Margin = new System.Windows.Forms.Padding(4);
            this.ParallelRead.Name = "ParallelRead";
            this.ParallelRead.Size = new System.Drawing.Size(137, 47);
            this.ParallelRead.TabIndex = 2;
            this.ParallelRead.Text = "Parallel RecordSet";
            this.ParallelRead.UseVisualStyleBackColor = true;
            this.ParallelRead.Click += new System.EventHandler(this.ParallelRead_Click);
            // 
            // ParallelInsert
            // 
            this.ParallelInsert.Location = new System.Drawing.Point(315, 16);
            this.ParallelInsert.Margin = new System.Windows.Forms.Padding(4);
            this.ParallelInsert.Name = "ParallelInsert";
            this.ParallelInsert.Size = new System.Drawing.Size(177, 47);
            this.ParallelInsert.TabIndex = 3;
            this.ParallelInsert.Text = "Parallel Insert @memory";
            this.ParallelInsert.UseVisualStyleBackColor = true;
            this.ParallelInsert.Click += new System.EventHandler(this.ParallelInsert_Click);
            // 
            // MarsEnabled
            // 
            this.MarsEnabled.Location = new System.Drawing.Point(52, 70);
            this.MarsEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.MarsEnabled.Name = "MarsEnabled";
            this.MarsEnabled.Size = new System.Drawing.Size(195, 47);
            this.MarsEnabled.TabIndex = 4;
            this.MarsEnabled.Text = "Multiple Active Result Sets";
            this.MarsEnabled.UseVisualStyleBackColor = true;
            this.MarsEnabled.Click += new System.EventHandler(this.MarsEnabled_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(255, 82);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(269, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(545, 82);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(256, 24);
            this.comboBox2.TabIndex = 6;
            // 
            // ExtendedResults
            // 
            this.ExtendedResults.Location = new System.Drawing.Point(749, 15);
            this.ExtendedResults.Margin = new System.Windows.Forms.Padding(4);
            this.ExtendedResults.Name = "ExtendedResults";
            this.ExtendedResults.Size = new System.Drawing.Size(152, 47);
            this.ExtendedResults.TabIndex = 7;
            this.ExtendedResults.Text = "Extended ResultSets";
            this.ExtendedResults.UseVisualStyleBackColor = true;
            this.ExtendedResults.Click += new System.EventHandler(this.ExtendedResults_Click);
            // 
            // ParallelInsertFile
            // 
            this.ParallelInsertFile.Location = new System.Drawing.Point(500, 15);
            this.ParallelInsertFile.Margin = new System.Windows.Forms.Padding(4);
            this.ParallelInsertFile.Name = "ParallelInsertFile";
            this.ParallelInsertFile.Size = new System.Drawing.Size(132, 47);
            this.ParallelInsertFile.TabIndex = 8;
            this.ParallelInsertFile.Text = "Parallel Insert in Physical DB File";
            this.ParallelInsertFile.UseVisualStyleBackColor = true;
            this.ParallelInsertFile.Click += new System.EventHandler(this.ParallelInsertFile_Click);
            // 
            // SavePoint
            // 
            this.SavePoint.Location = new System.Drawing.Point(641, 16);
            this.SavePoint.Margin = new System.Windows.Forms.Padding(4);
            this.SavePoint.Name = "SavePoint";
            this.SavePoint.Size = new System.Drawing.Size(100, 46);
            this.SavePoint.TabIndex = 9;
            this.SavePoint.Text = "SavePoint";
            this.SavePoint.UseVisualStyleBackColor = true;
            this.SavePoint.Click += new System.EventHandler(this.SavePoint_Click);
            // 
            // MixedLanguages
            // 
            this.MixedLanguages.Location = new System.Drawing.Point(52, 126);
            this.MixedLanguages.Margin = new System.Windows.Forms.Padding(4);
            this.MixedLanguages.Name = "MixedLanguages";
            this.MixedLanguages.Size = new System.Drawing.Size(160, 53);
            this.MixedLanguages.TabIndex = 10;
            this.MixedLanguages.Text = "Mixed Languages";
            this.MixedLanguages.UseVisualStyleBackColor = true;
            this.MixedLanguages.Click += new System.EventHandler(this.MixedLanguages_Click);
            // 
            // CreateDropTable
            // 
            this.CreateDropTable.Location = new System.Drawing.Point(219, 124);
            this.CreateDropTable.Name = "CreateDropTable";
            this.CreateDropTable.Size = new System.Drawing.Size(145, 54);
            this.CreateDropTable.TabIndex = 11;
            this.CreateDropTable.Text = "Create Drop Table";
            this.CreateDropTable.UseVisualStyleBackColor = true;
            this.CreateDropTable.Click += new System.EventHandler(this.CreateDropTable_Click);
            // 
            // SIUDOperations
            // 
            this.SIUDOperations.Location = new System.Drawing.Point(370, 125);
            this.SIUDOperations.Name = "SIUDOperations";
            this.SIUDOperations.Size = new System.Drawing.Size(165, 54);
            this.SIUDOperations.TabIndex = 12;
            this.SIUDOperations.Text = "SELECT INSERT UPDATE DELETE";
            this.SIUDOperations.UseVisualStyleBackColor = true;
            this.SIUDOperations.Click += new System.EventHandler(this.SIUDOperations_Click);
            // 
            // IndexAndVacuum
            // 
            this.IndexAndVacuum.Location = new System.Drawing.Point(541, 127);
            this.IndexAndVacuum.Name = "IndexAndVacuum";
            this.IndexAndVacuum.Size = new System.Drawing.Size(123, 53);
            this.IndexAndVacuum.TabIndex = 13;
            this.IndexAndVacuum.Text = "Index and VACUUM";
            this.IndexAndVacuum.UseVisualStyleBackColor = true;
            this.IndexAndVacuum.Click += new System.EventHandler(this.IndexAndVacuum_Click);
            // 
            // SimpleTransaction
            // 
            this.SimpleTransaction.Location = new System.Drawing.Point(670, 127);
            this.SimpleTransaction.Name = "SimpleTransaction";
            this.SimpleTransaction.Size = new System.Drawing.Size(112, 53);
            this.SimpleTransaction.TabIndex = 14;
            this.SimpleTransaction.Text = "Transaction";
            this.SimpleTransaction.UseVisualStyleBackColor = true;
            this.SimpleTransaction.Click += new System.EventHandler(this.SimpleTransaction_Click);
            // 
            // ToInMemoryDatabase
            // 
            this.ToInMemoryDatabase.Location = new System.Drawing.Point(789, 124);
            this.ToInMemoryDatabase.Name = "ToInMemoryDatabase";
            this.ToInMemoryDatabase.Size = new System.Drawing.Size(112, 54);
            this.ToInMemoryDatabase.TabIndex = 15;
            this.ToInMemoryDatabase.Text = "To In-Memory";
            this.ToInMemoryDatabase.UseVisualStyleBackColor = true;
            this.ToInMemoryDatabase.Click += new System.EventHandler(this.ToInMemoryDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 192);
            this.Controls.Add(this.ToInMemoryDatabase);
            this.Controls.Add(this.SimpleTransaction);
            this.Controls.Add(this.IndexAndVacuum);
            this.Controls.Add(this.SIUDOperations);
            this.Controls.Add(this.CreateDropTable);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button CreateDropTable;
        private System.Windows.Forms.Button SIUDOperations;
        private System.Windows.Forms.Button IndexAndVacuum;
        private System.Windows.Forms.Button SimpleTransaction;
        private System.Windows.Forms.Button ToInMemoryDatabase;
    }
}

