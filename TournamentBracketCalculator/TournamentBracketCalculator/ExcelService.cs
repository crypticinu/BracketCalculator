using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace BracketCalculator
{
    public class ExcelService
    {
        private string _filePath;
        private OleDbConnection _connection;

        public ExcelService(string filePath)
        {
            _filePath = filePath;
        }

        public void Connect(ExcelType excelType)
        {
            var _connectionString = excelType == ExcelType.xls ? $"Provider=Microsoft.ACE.OLEDB.4.0;Data Source='{_filePath}';Extended Properties=\"Excel 8.0;HDR=YES;\"" :  //xls
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{_filePath}';Extended Properties=\"Excel 12.0;HDR=YES;\""; //xlxs

            if (_connection?.State != ConnectionState.Open)
            {
                _connection = new OleDbConnection(_connectionString);

                OleDbDataAdapter objDA = new OleDbDataAdapter
                    ("select * from [Sheet1$]", _connection);
                DataSet excelDataSet = new DataSet();
                objDA.Fill(excelDataSet);
                //dataGridView1.DataSource = excelDataSet.Tables[0];
                var result = excelDataSet.Tables[0];
            }
        }

        public void Disconnect()
        {
            _connection.Close();
        }
    }
}
