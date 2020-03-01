using BracketCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketCalculator
{
    public static class ExtensionMethods
    {
        public static ExcelType ConvertToExcelType(this string test)
        {
            switch (test)
            {
                case ".xlsx":
                    return ExcelType.xlxs;
                default:
                    return ExcelType.xls;
            }
        }
    }
}
