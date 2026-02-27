namespace Lab_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            numSize = new NumericUpDown();
            label3 = new Label();
            numTarget = new NumericUpDown();
            btnGenerate = new Button();
            btnRun = new Button();
            gridResults = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colOps = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTarget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(402, 4);
            label1.Name = "label1";
            label1.Size = new Size(382, 46);
            label1.TabIndex = 0;
            label1.Text = "Поиск пары элементов";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(34, 66);
            label2.Name = "label2";
            label2.Size = new Size(207, 35);
            label2.TabIndex = 1;
            label2.Text = "Размер массива:";
            // 
            // numSize
            // 
            numSize.Font = new Font("Segoe UI", 12F);
            numSize.Location = new Point(236, 67);
            numSize.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSize.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numSize.Name = "numSize";
            numSize.Size = new Size(150, 34);
            numSize.TabIndex = 2;
            numSize.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(44, 116);
            label3.Name = "label3";
            label3.Size = new Size(197, 35);
            label3.TabIndex = 3;
            label3.Text = "Целевая сумма:";
            // 
            // numTarget
            // 
            numTarget.Font = new Font("Segoe UI", 12F);
            numTarget.Location = new Point(236, 117);
            numTarget.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numTarget.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numTarget.Name = "numTarget";
            numTarget.Size = new Size(150, 34);
            numTarget.TabIndex = 4;
            numTarget.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.Transparent;
            btnGenerate.Font = new Font("Segoe UI", 14F);
            btnGenerate.Location = new Point(458, 67);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(203, 84);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "Сгенерировать массив";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.Transparent;
            btnRun.Enabled = false;
            btnRun.Font = new Font("Segoe UI", 14F);
            btnRun.Location = new Point(737, 67);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(203, 84);
            btnRun.TabIndex = 6;
            btnRun.Text = "Запустить алгоритмы";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // gridResults
            // 
            gridResults.AllowUserToAddRows = false;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResults.Columns.AddRange(new DataGridViewColumn[] { colName, colTime, colOps, colResult });
            gridResults.Location = new Point(34, 227);
            gridResults.Name = "gridResults";
            gridResults.RowHeadersVisible = false;
            gridResults.RowHeadersWidth = 51;
            gridResults.Size = new Size(1078, 279);
            gridResults.TabIndex = 7;
            // 
            // colName
            // 
            colName.HeaderText = "Алгоритм";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            // 
            // colTime
            // 
            colTime.HeaderText = " Время (мс)";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            // 
            // colOps
            // 
            colOps.HeaderText = "Кол-во операций";
            colOps.MinimumWidth = 6;
            colOps.Name = "colOps";
            // 
            // colResult
            // 
            colResult.HeaderText = "Найденная пара";
            colResult.MinimumWidth = 6;
            colResult.Name = "colResult";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(34, 523);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(508, 23);
            lblStatus.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1156, 590);
            Controls.Add(lblStatus);
            Controls.Add(gridResults);
            Controls.Add(btnRun);
            Controls.Add(btnGenerate);
            Controls.Add(numTarget);
            Controls.Add(label3);
            Controls.Add(numSize);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTarget).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numSize;
        private Label label3;
        private NumericUpDown numTarget;
        private Button btnGenerate;
        private Button btnRun;
        private DataGridView gridResults;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colOps;
        private DataGridViewTextBoxColumn colResult;
        private Label lblStatus;
    }
}
