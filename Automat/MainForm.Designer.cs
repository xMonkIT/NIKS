namespace Automat
{
    partial class MainForm
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
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.nudLambda = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMu = new System.Windows.Forms.NumericUpDown();
            this.bCalc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxUptime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxUptime)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(12, 41);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.Size = new System.Drawing.Size(639, 277);
            this.dgvTable.TabIndex = 0;
            // 
            // nudLambda
            // 
            this.nudLambda.DecimalPlaces = 5;
            this.nudLambda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudLambda.Location = new System.Drawing.Point(33, 12);
            this.nudLambda.Name = "nudLambda";
            this.nudLambda.Size = new System.Drawing.Size(82, 20);
            this.nudLambda.TabIndex = 1;
            this.nudLambda.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "λ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "μ:";
            // 
            // nudMu
            // 
            this.nudMu.DecimalPlaces = 5;
            this.nudMu.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudMu.Location = new System.Drawing.Point(142, 12);
            this.nudMu.Name = "nudMu";
            this.nudMu.Size = new System.Drawing.Size(82, 20);
            this.nudMu.TabIndex = 3;
            this.nudMu.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // bCalc
            // 
            this.bCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCalc.Location = new System.Drawing.Point(576, 12);
            this.bCalc.Name = "bCalc";
            this.bCalc.Size = new System.Drawing.Size(75, 23);
            this.bCalc.TabIndex = 5;
            this.bCalc.Text = "Рассчитать";
            this.bCalc.UseVisualStyleBackColor = true;
            this.bCalc.Click += new System.EventHandler(this.bCalc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "MaxUptime:";
            // 
            // nudMaxUptime
            // 
            this.nudMaxUptime.DecimalPlaces = 5;
            this.nudMaxUptime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudMaxUptime.Location = new System.Drawing.Point(299, 12);
            this.nudMaxUptime.Name = "nudMaxUptime";
            this.nudMaxUptime.Size = new System.Drawing.Size(82, 20);
            this.nudMaxUptime.TabIndex = 6;
            this.nudMaxUptime.Value = new decimal(new int[] {
            9999,
            0,
            0,
            262144});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 330);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMaxUptime);
            this.Controls.Add(this.bCalc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudLambda);
            this.Controls.Add(this.dgvTable);
            this.Name = "MainForm";
            this.Text = "o_O";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxUptime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.NumericUpDown nudLambda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMu;
        private System.Windows.Forms.Button bCalc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxUptime;
    }
}

