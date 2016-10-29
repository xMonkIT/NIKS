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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bCalc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxUptime = new System.Windows.Forms.NumericUpDown();
            this.tbLambda = new System.Windows.Forms.TextBox();
            this.tbMu = new System.Windows.Forms.TextBox();
            this.tbPrices = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
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
            this.dgvTable.Size = new System.Drawing.Size(958, 277);
            this.dgvTable.TabIndex = 0;
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
            this.label2.Location = new System.Drawing.Point(157, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "μ:";
            // 
            // bCalc
            // 
            this.bCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCalc.Location = new System.Drawing.Point(895, 12);
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
            this.label3.Location = new System.Drawing.Point(447, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "MaxUptime:";
            // 
            // nudMaxUptime
            // 
            this.nudMaxUptime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxUptime.DecimalPlaces = 5;
            this.nudMaxUptime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudMaxUptime.Location = new System.Drawing.Point(516, 12);
            this.nudMaxUptime.Name = "nudMaxUptime";
            this.nudMaxUptime.Size = new System.Drawing.Size(373, 20);
            this.nudMaxUptime.TabIndex = 6;
            this.nudMaxUptime.Value = new decimal(new int[] {
            9999,
            0,
            0,
            262144});
            // 
            // tbLambda
            // 
            this.tbLambda.Location = new System.Drawing.Point(34, 13);
            this.tbLambda.Name = "tbLambda";
            this.tbLambda.Size = new System.Drawing.Size(117, 20);
            this.tbLambda.TabIndex = 8;
            this.tbLambda.Text = "0,01 0,02 0,001";
            // 
            // tbMu
            // 
            this.tbMu.Location = new System.Drawing.Point(179, 13);
            this.tbMu.Name = "tbMu";
            this.tbMu.Size = new System.Drawing.Size(117, 20);
            this.tbMu.TabIndex = 9;
            this.tbMu.Text = "0,1 0,2 0,3";
            // 
            // tbPrices
            // 
            this.tbPrices.Location = new System.Drawing.Point(324, 13);
            this.tbPrices.Name = "tbPrices";
            this.tbPrices.Size = new System.Drawing.Size(117, 20);
            this.tbPrices.TabIndex = 11;
            this.tbPrices.Text = "150 200 500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "₽:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 330);
            this.Controls.Add(this.tbPrices);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMu);
            this.Controls.Add(this.tbLambda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMaxUptime);
            this.Controls.Add(this.bCalc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTable);
            this.Name = "MainForm";
            this.Text = "o_O";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxUptime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCalc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxUptime;
        private System.Windows.Forms.TextBox tbLambda;
        private System.Windows.Forms.TextBox tbMu;
        private System.Windows.Forms.TextBox tbPrices;
        private System.Windows.Forms.Label label4;
    }
}

