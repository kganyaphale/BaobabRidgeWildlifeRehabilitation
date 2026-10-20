namespace Project
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
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.btnGenerateSummary = new System.Windows.Forms.Button();
            this.lblTotalAnimalsTitle = new System.Windows.Forms.Label();
            this.lblTotalAnimals = new System.Windows.Forms.Label();
            this.lblAverageAgeTitle = new System.Windows.Forms.Label();
            this.lblAverageAge = new System.Windows.Forms.Label();
            this.lblAverageScoreTitle = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblCriticalCountTitle = new System.Windows.Forms.Label();
            this.lblCriticalCount = new System.Windows.Forms.Label();
            this.lblSeriousCountTitle = new System.Windows.Forms.Label();
            this.lblSeriousCount = new System.Windows.Forms.Label();
            this.lblStableCountTitle = new System.Windows.Forms.Label();
            this.lblStableCount = new System.Windows.Forms.Label();
            this.lblRecoveringCountTitle = new System.Windows.Forms.Label();
            this.lblRecoveringCount = new System.Windows.Forms.Label();
            this.lblReleaseReadyCountTitle = new System.Windows.Forms.Label();
            this.lblReleaseReadyCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.AllowUserToAddRows = false;
            this.dgvAnimals.AllowUserToDeleteRows = false;
            this.dgvAnimals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnimals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnimals.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvAnimals.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimals.Location = new System.Drawing.Point(12, 28);
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.ReadOnly = true;
            this.dgvAnimals.RowHeadersVisible = false;
            this.dgvAnimals.RowHeadersWidth = 82;
            this.dgvAnimals.RowTemplate.Height = 33;
            this.dgvAnimals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimals.Size = new System.Drawing.Size(1137, 330);
            this.dgvAnimals.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(969, 370);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 45);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Animal";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpSummary
            // 
            this.grpSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSummary.Controls.Add(this.btnGenerateSummary);
            this.grpSummary.Controls.Add(this.lblTotalAnimalsTitle);
            this.grpSummary.Controls.Add(this.lblTotalAnimals);
            this.grpSummary.Controls.Add(this.lblAverageAgeTitle);
            this.grpSummary.Controls.Add(this.lblAverageAge);
            this.grpSummary.Controls.Add(this.lblAverageScoreTitle);
            this.grpSummary.Controls.Add(this.lblAverageScore);
            this.grpSummary.Controls.Add(this.lblCriticalCountTitle);
            this.grpSummary.Controls.Add(this.lblCriticalCount);
            this.grpSummary.Controls.Add(this.lblSeriousCountTitle);
            this.grpSummary.Controls.Add(this.lblSeriousCount);
            this.grpSummary.Controls.Add(this.lblStableCountTitle);
            this.grpSummary.Controls.Add(this.lblStableCount);
            this.grpSummary.Controls.Add(this.lblRecoveringCountTitle);
            this.grpSummary.Controls.Add(this.lblRecoveringCount);
            this.grpSummary.Controls.Add(this.lblReleaseReadyCountTitle);
            this.grpSummary.Controls.Add(this.lblReleaseReadyCount);
            this.grpSummary.Location = new System.Drawing.Point(649, 430);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(500, 420);
            this.grpSummary.TabIndex = 2;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary Report";
            // 
            // btnGenerateSummary
            // 
            this.btnGenerateSummary.Location = new System.Drawing.Point(20, 40);
            this.btnGenerateSummary.Name = "btnGenerateSummary";
            this.btnGenerateSummary.Size = new System.Drawing.Size(240, 45);
            this.btnGenerateSummary.TabIndex = 0;
            this.btnGenerateSummary.Text = "Generate Summary";
            this.btnGenerateSummary.UseVisualStyleBackColor = true;
            this.btnGenerateSummary.Click += new System.EventHandler(this.btnGenerateSummary_Click);
            // 
            // lblTotalAnimalsTitle
            // 
            this.lblTotalAnimalsTitle.AutoSize = true;
            this.lblTotalAnimalsTitle.Location = new System.Drawing.Point(20, 100);
            this.lblTotalAnimalsTitle.Name = "lblTotalAnimalsTitle";
            this.lblTotalAnimalsTitle.Size = new System.Drawing.Size(182, 25);
            this.lblTotalAnimalsTitle.TabIndex = 1;
            this.lblTotalAnimalsTitle.Text = "Total animals:";
            // 
            // lblTotalAnimals
            // 
            this.lblTotalAnimals.AutoSize = true;
            this.lblTotalAnimals.Location = new System.Drawing.Point(330, 100);
            this.lblTotalAnimals.Name = "lblTotalAnimals";
            this.lblTotalAnimals.Size = new System.Drawing.Size(20, 25);
            this.lblTotalAnimals.TabIndex = 2;
            this.lblTotalAnimals.Text = "-";
            // 
            // lblAverageAgeTitle
            // 
            this.lblAverageAgeTitle.AutoSize = true;
            this.lblAverageAgeTitle.Location = new System.Drawing.Point(20, 138);
            this.lblAverageAgeTitle.Name = "lblAverageAgeTitle";
            this.lblAverageAgeTitle.Size = new System.Drawing.Size(260, 25);
            this.lblAverageAgeTitle.TabIndex = 3;
            this.lblAverageAgeTitle.Text = "Average age (years):";
            // 
            // lblAverageAge
            // 
            this.lblAverageAge.AutoSize = true;
            this.lblAverageAge.Location = new System.Drawing.Point(330, 138);
            this.lblAverageAge.Name = "lblAverageAge";
            this.lblAverageAge.Size = new System.Drawing.Size(20, 25);
            this.lblAverageAge.TabIndex = 4;
            this.lblAverageAge.Text = "-";
            // 
            // lblAverageScoreTitle
            // 
            this.lblAverageScoreTitle.AutoSize = true;
            this.lblAverageScoreTitle.Location = new System.Drawing.Point(20, 176);
            this.lblAverageScoreTitle.Name = "lblAverageScoreTitle";
            this.lblAverageScoreTitle.Size = new System.Drawing.Size(299, 25);
            this.lblAverageScoreTitle.TabIndex = 5;
            this.lblAverageScoreTitle.Text = "Average recovery score:";
            // 
            // lblAverageScore
            // 
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Location = new System.Drawing.Point(330, 176);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(20, 25);
            this.lblAverageScore.TabIndex = 6;
            this.lblAverageScore.Text = "-";
            // 
            // lblCriticalCountTitle
            // 
            this.lblCriticalCountTitle.AutoSize = true;
            this.lblCriticalCountTitle.Location = new System.Drawing.Point(20, 214);
            this.lblCriticalCountTitle.Name = "lblCriticalCountTitle";
            this.lblCriticalCountTitle.Size = new System.Drawing.Size(117, 25);
            this.lblCriticalCountTitle.TabIndex = 7;
            this.lblCriticalCountTitle.Text = "Critical:";
            // 
            // lblCriticalCount
            // 
            this.lblCriticalCount.AutoSize = true;
            this.lblCriticalCount.Location = new System.Drawing.Point(330, 214);
            this.lblCriticalCount.Name = "lblCriticalCount";
            this.lblCriticalCount.Size = new System.Drawing.Size(20, 25);
            this.lblCriticalCount.TabIndex = 8;
            this.lblCriticalCount.Text = "-";
            // 
            // lblSeriousCountTitle
            // 
            this.lblSeriousCountTitle.AutoSize = true;
            this.lblSeriousCountTitle.Location = new System.Drawing.Point(20, 252);
            this.lblSeriousCountTitle.Name = "lblSeriousCountTitle";
            this.lblSeriousCountTitle.Size = new System.Drawing.Size(104, 25);
            this.lblSeriousCountTitle.TabIndex = 9;
            this.lblSeriousCountTitle.Text = "Serious:";
            // 
            // lblSeriousCount
            // 
            this.lblSeriousCount.AutoSize = true;
            this.lblSeriousCount.Location = new System.Drawing.Point(330, 252);
            this.lblSeriousCount.Name = "lblSeriousCount";
            this.lblSeriousCount.Size = new System.Drawing.Size(20, 25);
            this.lblSeriousCount.TabIndex = 10;
            this.lblSeriousCount.Text = "-";
            // 
            // lblStableCountTitle
            // 
            this.lblStableCountTitle.AutoSize = true;
            this.lblStableCountTitle.Location = new System.Drawing.Point(20, 290);
            this.lblStableCountTitle.Name = "lblStableCountTitle";
            this.lblStableCountTitle.Size = new System.Drawing.Size(91, 25);
            this.lblStableCountTitle.TabIndex = 11;
            this.lblStableCountTitle.Text = "Stable:";
            // 
            // lblStableCount
            // 
            this.lblStableCount.AutoSize = true;
            this.lblStableCount.Location = new System.Drawing.Point(330, 290);
            this.lblStableCount.Name = "lblStableCount";
            this.lblStableCount.Size = new System.Drawing.Size(20, 25);
            this.lblStableCount.TabIndex = 12;
            this.lblStableCount.Text = "-";
            // 
            // lblRecoveringCountTitle
            // 
            this.lblRecoveringCountTitle.AutoSize = true;
            this.lblRecoveringCountTitle.Location = new System.Drawing.Point(20, 328);
            this.lblRecoveringCountTitle.Name = "lblRecoveringCountTitle";
            this.lblRecoveringCountTitle.Size = new System.Drawing.Size(143, 25);
            this.lblRecoveringCountTitle.TabIndex = 13;
            this.lblRecoveringCountTitle.Text = "Recovering:";
            // 
            // lblRecoveringCount
            // 
            this.lblRecoveringCount.AutoSize = true;
            this.lblRecoveringCount.Location = new System.Drawing.Point(330, 328);
            this.lblRecoveringCount.Name = "lblRecoveringCount";
            this.lblRecoveringCount.Size = new System.Drawing.Size(20, 25);
            this.lblRecoveringCount.TabIndex = 14;
            this.lblRecoveringCount.Text = "-";
            // 
            // lblReleaseReadyCountTitle
            // 
            this.lblReleaseReadyCountTitle.AutoSize = true;
            this.lblReleaseReadyCountTitle.Location = new System.Drawing.Point(20, 366);
            this.lblReleaseReadyCountTitle.Name = "lblReleaseReadyCountTitle";
            this.lblReleaseReadyCountTitle.Size = new System.Drawing.Size(182, 25);
            this.lblReleaseReadyCountTitle.TabIndex = 15;
            this.lblReleaseReadyCountTitle.Text = "Release-Ready:";
            // 
            // lblReleaseReadyCount
            // 
            this.lblReleaseReadyCount.AutoSize = true;
            this.lblReleaseReadyCount.Location = new System.Drawing.Point(330, 366);
            this.lblReleaseReadyCount.Name = "lblReleaseReadyCount";
            this.lblReleaseReadyCount.Size = new System.Drawing.Size(20, 25);
            this.lblReleaseReadyCount.TabIndex = 16;
            this.lblReleaseReadyCount.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 865);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvAnimals);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Button btnGenerateSummary;
        private System.Windows.Forms.Label lblTotalAnimalsTitle;
        private System.Windows.Forms.Label lblTotalAnimals;
        private System.Windows.Forms.Label lblAverageAgeTitle;
        private System.Windows.Forms.Label lblAverageAge;
        private System.Windows.Forms.Label lblAverageScoreTitle;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.Label lblCriticalCountTitle;
        private System.Windows.Forms.Label lblCriticalCount;
        private System.Windows.Forms.Label lblSeriousCountTitle;
        private System.Windows.Forms.Label lblSeriousCount;
        private System.Windows.Forms.Label lblStableCountTitle;
        private System.Windows.Forms.Label lblStableCount;
        private System.Windows.Forms.Label lblRecoveringCountTitle;
        private System.Windows.Forms.Label lblRecoveringCount;
        private System.Windows.Forms.Label lblReleaseReadyCountTitle;
        private System.Windows.Forms.Label lblReleaseReadyCount;
    }
}

