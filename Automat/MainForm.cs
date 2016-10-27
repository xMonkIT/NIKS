using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            MatrixToDgv(Calculator.GetMatrix(0.01, 0.1, 3));
        }

        public void MatrixToDgv(IEnumerable<IEnumerable<double>> data)
        {
            var matrix = data.Select(x => x.ToList()).ToList();

            dgvTable.Rows.Clear();
            dgvTable.Columns.Clear();

            Enumerable.Range(0, matrix.Count > 0 ? matrix[0].Count : 0).ToList().ForEach(i => dgvTable.Columns.Add("", ""));

            matrix.ForEach(row =>
            {
                var dgvRow = dgvTable.Rows.Add();
                Enumerable.Range(0, row.Count).ToList().ForEach(cell => dgvTable[cell, dgvRow].Value = $"{row[cell]:0.####}");
            });
        }
    }
}
