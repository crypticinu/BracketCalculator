using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using TournamentBracketCalculator.Models;

namespace BracketCalculator
{
    public class ExcelService
    {
        private OleDbConnection _connection;

        public List<Player> ReadTournamentAttendance(string path, ExcelType extension)
        {
            Connect(path, extension);

            OleDbDataAdapter objDA = new OleDbDataAdapter("select * from [List x1$]", _connection);

            DataSet excelDataSet = new DataSet();
            objDA.Fill(excelDataSet);

            Disconnect();

            var result = excelDataSet.Tables[0];

            var attendingPlayers = new Dictionary<string, Player>();

            foreach (DataRow row in result.Rows)
            {
                for (int i = 0; i < result.Columns.Count; i++)
                {
                    var column = result.Columns[i];

                    var cellValue = row[result.Columns[i]].ToString();

                    if (cellValue != "" && cellValue != "PAID" && !cellValue.Contains("Category"))
                    {
                        attendingPlayers.Add(cellValue, new Player { FullName = cellValue });
                    }

                }
            }

            return attendingPlayers.Values.ToList();
        }

        public Dictionary<Category, List<Player>> ReadPlayerList(string path, ExcelType extension)
        {
            Connect(path, extension);

            OleDbDataAdapter objDA = new OleDbDataAdapter("select * from [Sheet1$]", _connection);

            DataSet excelDataSet = new DataSet();
            objDA.Fill(excelDataSet);

            Disconnect();

            var result = excelDataSet.Tables[0];

            var goldPlayers = new Dictionary<string, Player>();
            var silverPlayers = new Dictionary<string, Player>();
            var bronzeAPlayers = new Dictionary<string, Player>();
            var bronzeBPlayers = new Dictionary<string, Player>();

            foreach (DataRow row in result.Rows)
            {
                for (int i = 0; i < result.Columns.Count; i++)
                {
                    var column = result.Columns[i];
                    var columnName = column.ToString();

                    var player = new Player();

                    var cellValue = row[result.Columns[i]].ToString();

                    if (cellValue != "")
                    {
                        switch (columnName)
                        {
                            case "Gold":
                                player.Category = Category.Gold;
                                player.FullName = cellValue;
                                player.Points = Convert.ToInt32(row[result.Columns[i + 1]].ToString());
                                goldPlayers.Add(player.FullName, player);
                                break;
                            case "Silver":
                                player.Category = Category.Silver;
                                player.FullName = cellValue;
                                player.Points = Convert.ToInt32(row[result.Columns[i + 1]].ToString());
                                silverPlayers.Add(player.FullName, player);
                                break;
                            case "Bronze A":
                                player.Category = Category.Bronze_A;
                                player.FullName = cellValue;
                                player.Points = Convert.ToInt32(row[result.Columns[i + 1]].ToString());
                                bronzeAPlayers.Add(player.FullName, player);
                                break;
                            case "Bronze B":
                                player.Category = Category.Brone_B;
                                player.FullName = cellValue;
                                player.Points = Convert.ToInt32(row[result.Columns[i + 1]].ToString());
                                bronzeBPlayers.Add(player.FullName, player);
                                break;
                        }
                    }
                }
            }

            var categories = new Dictionary<Category, List<Player>>
            {
                { Category.Gold,  goldPlayers.Values.ToList() },
                { Category.Silver, silverPlayers.Values.ToList() },
                { Category.Bronze_A, bronzeAPlayers.Values.ToList() },
                { Category.Brone_B, bronzeBPlayers.Values.ToList() },
            };

            return categories;
        }



        private void Connect(string path, ExcelType extension)
        {
            var _connectionString = extension == ExcelType.xls ? $"Provider=Microsoft.ACE.OLEDB.4.0;Data Source='{path}';Extended Properties=\"Excel 8.0;HDR=YES;\"" :  //xls
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{path}';Extended Properties=\"Excel 12.0;HDR=YES;\""; //xlxs

            if (_connection?.State != ConnectionState.Open)
            {
                _connection = new OleDbConnection(_connectionString);

                _connection.Open();
            }
        }

        private void Disconnect()
        {
            _connection.Close();
        }
    }
}
