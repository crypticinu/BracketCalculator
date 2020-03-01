using BracketCalculator;
using System;
using System.IO;
using System.Windows.Forms;

namespace TournamentBracketCalculator
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();

        private string TournamentAttendancePath = "";
        private string TournamentRankingPath = "";

        private ExcelService ExcelService = new ExcelService();

        public Form1()
        {
            InitializeComponent();
        }

        private void openTournamentRankingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TournamentRankingPath = ofd.InitialDirectory + ofd.FileName;
            }
        }

        private void openTournamentAttendanceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TournamentAttendancePath = ofd.InitialDirectory + ofd.FileName;

                string ext = Path.GetExtension(ofd.FileName);

                ExcelService.ReadTournamentAttendance(TournamentAttendancePath, ext.ConvertToExcelType());
            }
        }

    }
}
