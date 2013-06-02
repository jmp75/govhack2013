using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel;
using System.Data;

namespace ATO.Dig.Data
{
    /// <summary>
    /// A helper class to extract MS Excel spreadsheet data for processing in e.g. R
    /// </summary>
    public class AtoExcelAccess
    {

        public static string[,] GetSpreadsheet(int number, string filePath)
        {
            string[,] result = null;
            using (var reader = OpenRead(filePath))
            {
                result = ToStringArray(reader.AsDataSet().Tables[number - 1]);
            }
            return result;
        }

        public static string[,] ToStringArray(DataTable table)
        {
            int ncol = table.Columns.Count;
            int nrow = table.Rows.Count;
            var result = new string[nrow, ncol];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    result[i, j] = table.Rows[i][j].ToString();
                }
            }
            return result;
        }

        public static IExcelDataReader OpenRead(string filePath = @"C:\tmp\2010-11-datasets\2010-11 datasets\cor00345977_2011CGT1.xls") 
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            if (filePath.EndsWith(".xls"))
                return ExcelReaderFactory.CreateBinaryReader(stream);
            else if (filePath.EndsWith(".xlsx"))
                return ExcelReaderFactory.CreateOpenXmlReader(stream);
            else
                throw new NotSupportedException();
        }


    }
}
