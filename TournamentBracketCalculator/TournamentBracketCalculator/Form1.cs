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
        private string PlayerRankingsPath = "";

        private ExcelService ExcelService = new ExcelService();

        List<Player> PlayerRankings;
        List<string> PlayersAttending;

        public Form1()
        {
            InitializeComponent();
        }

        private void openPlayerRankingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayerRankingsPath = ofd.InitialDirectory + ofd.FileName;

                string ext = Path.GetExtension(ofd.FileName);

                var result = ExcelService.ReadPlayerList(PlayerRankingsPath, ext.ConvertToExcelType());

                if (result != null)
                    openTournamentAttendanceListToolStripMenuItem.Enabled = true;

                PlayerRankings = new List<Player>();

                foreach (var category in result.Values)
                {
                    PlayerRankings.AddRange(category);
                }
            }
        }

        private void openTournamentAttendanceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TournamentAttendancePath = ofd.InitialDirectory + ofd.FileName;

                string ext = Path.GetExtension(ofd.FileName);

                PlayersAttending = ExcelService.ReadTournamentAttendance(TournamentAttendancePath, ext.ConvertToExcelType());

                PlayersPanel.Visible = true;
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
            if (PlayerRankings != null && PlayersAttending != null)
            {

                var uniquePlayerNames = PlayerRankings.Select(players => players.FullName).ToList();
                var missingPlayers = PlayersAttending.Except(uniquePlayerNames);
                if (!missingPlayers.Any())
                {
                    var playersAttendingTournament = PlayerRankings.Where(x => PlayersAttending.Contains(x.FullName)).ToList();

                    var goldPlayers = playersAttendingTournament.Where(x => x.Category == Category.Gold);
                    var silverPlayers = playersAttendingTournament.Where(x => x.Category == Category.Silver);
                    var bronzeAPlayers = playersAttendingTournament.Where(x => x.Category == Category.Bronze_A);
                    var bronzeBPlayers = playersAttendingTournament.Where(x => x.Category == Category.Bronze_B);
                }

            }
        }
    }
}
