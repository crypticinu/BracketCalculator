using System.Data;
using System.Data.OleDb;

namespace BracketCalculator
{
    public class ExcelService
    {
        private OleDbConnection _connection;

        public  void ReadTournamentAttendance(string path, ExcelType extension)
        {
            Connect(path, extension);

            OleDbDataAdapter objDA = new OleDbDataAdapter("select * from [List x1$]", _connection);

            DataSet excelDataSet = new DataSet();
            objDA.Fill(excelDataSet);
            var result = excelDataSet.Tables[0];

            Disconnect();
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
