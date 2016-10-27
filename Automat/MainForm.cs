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
        private const int ServerCount = 3;

        public MainForm()
        {
            InitializeComponent();
        }

        public void MatrixToDgv(IEnumerable<IEnumerable<double>> data)
        {
            var matrix = data.Select(x => x.ToList()).ToList();

            dgvTable.Rows.Clear();
            dgvTable.Columns.Clear();

            Enumerable.Range(0, matrix.Count > 0 ? matrix[0].Count : 0).ToList().ForEach(i => dgvTable.Columns.Add("", ""));

            dgvTable.Columns.Add("sum", "sum");

            matrix.ForEach(row =>
            {
                var dgvRow = dgvTable.Rows.Add();
                Enumerable.Range(0, row.Count).ToList().ForEach(cell => dgvTable[cell, dgvRow].Value = $"{row[cell]:0.####}");
                dgvTable[dgvTable.ColumnCount - 1, dgvRow].Value = $"{row.Sum():0.####}";
            });
        }

        public void UptimesToDgv(IEnumerable<Tuple<int, double>> uptimes)
        {
            dgvTable.Rows.Clear();
            dgvTable.Columns.Clear();

            dgvTable.Columns.Add("count", "count");
            dgvTable.Columns.Add("uptime", "uptime");

            uptimes.ToList().ForEach(x =>
            {
                var row = dgvTable.Rows.Add();
                dgvTable[0, row].Value = x.Item1;
                dgvTable[1, row].Value = $"{x.Item2}";
            });
        }

        private void bCalc_Click(object sender, EventArgs e)
        {
            UptimesToDgv(Calculator.GetUptimes((double) nudMaxUptime.Value, (double) nudLambda.Value, (double) nudMu.Value));
        }
    }
}
