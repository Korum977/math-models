namespace WinFormsApp1
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
            lblMatrixSize = new Label();
            nudMatrixSize = new NumericUpDown();
            btnCreateMatrix = new Button();
            pnlMatrix = new Panel();
            txtOutput = new TextBox();
            btnSortByDiagonal = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMatrixSize).BeginInit();
            SuspendLayout();
            
            // lblMatrixSize
            // 
            lblMatrixSize.AutoSize = true;
            lblMatrixSize.Location = new Point(12, 15);
            lblMatrixSize.Name = "lblMatrixSize";
            lblMatrixSize.Size = new Size(133, 15);
            lblMatrixSize.TabIndex = 0;
            lblMatrixSize.Text = "Размер матрицы (n×n):";
            
            // nudMatrixSize
            // 
            nudMatrixSize.Location = new Point(151, 13);
            nudMatrixSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMatrixSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudMatrixSize.Name = "nudMatrixSize";
            nudMatrixSize.Size = new Size(60, 23);
            nudMatrixSize.TabIndex = 1;
            nudMatrixSize.Value = new decimal(new int[] { 3, 0, 0, 0 });
            
            // btnCreateMatrix
            // 
            btnCreateMatrix.Location = new Point(217, 12);
            btnCreateMatrix.Name = "btnCreateMatrix";
            btnCreateMatrix.Size = new Size(132, 23);
            btnCreateMatrix.TabIndex = 2;
            btnCreateMatrix.Text = "Создать матрицу";
            btnCreateMatrix.UseVisualStyleBackColor = true;
            btnCreateMatrix.Click += btnCreateMatrix_Click;
            
            // pnlMatrix
            // 
            pnlMatrix.BorderStyle = BorderStyle.FixedSingle;
            pnlMatrix.Location = new Point(12, 50);
            pnlMatrix.Name = "pnlMatrix";
            pnlMatrix.Size = new Size(450, 300);
            pnlMatrix.TabIndex = 3;
            
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 356);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(450, 100);
            txtOutput.TabIndex = 4;
            
            // btnSortByDiagonal
            // 
            btnSortByDiagonal.Enabled = false;
            btnSortByDiagonal.Location = new Point(355, 12);
            btnSortByDiagonal.Name = "btnSortByDiagonal";
            btnSortByDiagonal.Size = new Size(132, 23);
            btnSortByDiagonal.TabIndex = 5;
            btnSortByDiagonal.Text = "Сортировать";
            btnSortByDiagonal.UseVisualStyleBackColor = true;
            btnSortByDiagonal.Click += btnSortByDiagonal_Click;
            
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 471);
            Controls.Add(btnSortByDiagonal);
            Controls.Add(txtOutput);
            Controls.Add(pnlMatrix);
            Controls.Add(btnCreateMatrix);
            Controls.Add(nudMatrixSize);
            Controls.Add(lblMatrixSize);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сортировка матрицы по диагонали";
            ((System.ComponentModel.ISupportInitialize)nudMatrixSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMatrixSize;
        private NumericUpDown nudMatrixSize;
        private Button btnCreateMatrix;
        private Panel pnlMatrix;
        private TextBox txtOutput;
        private Button btnSortByDiagonal;
    }
}
