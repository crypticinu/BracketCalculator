using BracketCalculator;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TournamentBracketCalculator.Models;

namespace TournamentBracketCalculator
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();

        private string TournamentAttendancePath = "";
        private string PlayerRankings = "";

        private ExcelService ExcelService = new ExcelService();

        List<Player> PlayerList;
        List<Player> AttendingPlayers;

        public Form1()
        {
            InitializeComponent();
        }

        private void openPlayerRankingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayerRankings = ofd.InitialDirectory + ofd.FileName;

                string ext = Path.GetExtension(ofd.FileName);

                var result = ExcelService.ReadPlayerList(PlayerRankings, ext.ConvertToExcelType());

                if (result != null)
                    openTournamentAttendanceListToolStripMenuItem.Enabled = true;
                
                PlayerList = new List<Player>();

                foreach (var category in result.Values)
                {
                    PlayerList.AddRange(category);
                }

                PlayersPanel.Visible = true;

            }
        }

        private void openTournamentAttendanceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TournamentAttendancePath = ofd.InitialDirectory + ofd.FileName;

                string ext = Path.GetExtension(ofd.FileName);

               var result = ExcelService.ReadTournamentAttendance(TournamentAttendancePath, ext.ConvertToExcelType());

                AttendingPlayers = result;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Test");
        }

        private void allPlayersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_generate_brackets_Click(object sender, EventArgs e)
        {
            if (PlayerList == null || AttendingPlayers == null)
            {

            }
        }
    }
}
