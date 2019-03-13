using GenericFramework.Enum;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFramework.GenericMethod
{
    public class ExcelReaderUsingNPOI
    {
        public string path;
        public FileStream fs = null;
        private XSSFWorkbook workbook = null;
        private ISheet sheet = null;
        private IRow row = null;
        private ICell cell = null;
       
        public ExcelReaderUsingNPOI(string path)
        {
            try
            {
                this.path = path;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook(fs);
                    sheet = workbook.GetSheetAt(0);
                    fs.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int getRowCount(string sheetName)
        {
            try
            {
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return 0;
                else
                {
                    sheet = workbook.GetSheetAt(index);
                    int number = sheet.LastRowNum + 1;
                    return number;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int getColumnCount(string sheetName)
        {
            try
            {
                if (!isSheetExist(sheetName))
                    return -1;
                sheet = workbook.GetSheet(sheetName);
                row = sheet.GetRow(0);
                if (row == null)
                    return -1;
                return row.LastCellNum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public int getRowNumber(string sheetName, int colNum, string value)
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                int d = 0;
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return 0;

                sheet = workbook.GetSheetAt(index);
                for (int rw = 0; rw < sheet.LastRowNum; rw++)
                {
                    if (sheet.GetRow(rw) != null)
                    {
                        row = sheet.GetRow(rw);
                    }
                }
                return row.RowNum;
            }
            catch (Exception)
            {
                return row.RowNum;
            }
        }
        public string getCellData(string sheetName, int colNum, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = row.GetCell(colNum);
                if (cell == null)
                    return "";
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {
                    string cellText = Convert.ToString(cell.NumericCellValue);
                    return cellText;
                }
                else if (cell.CellType == CellType.Blank)
                    return "";
                else
                    return cell.BooleanCellValue.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string getCellData(string sheetName, string colName, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";
                int colNum = -1;
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(0);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (row.GetCell(i).StringCellValue.Trim().Equals(colName.Trim()))
                    {
                        colNum = i;
                    }
                }
                if (colNum == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = row.GetCell(colNum);
                if (cell == null)
                    return "";
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {
                    string cellText = Convert.ToString(cell.NumericCellValue);
                    return cellText;
                }
                else if (cell.CellType == CellType.Blank)
                    return "";
                else
                    return cell.BooleanCellValue.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string getCellDatabydataid(ExcelReaderUsingNPOI xls,string sheetName,string dataid)
        {
            try
            {
               
                int index = workbook.GetSheetIndex(sheetName);
                sheet = workbook.GetSheetAt(index);
				int rcount = xls.getRowCount(sheetName);

				for (int i=2;i<= rcount;i++)
                {
			
					
					if (xls.getCellData(sheetName,0,i) == dataid)
                    {
						return xls.getCellData(sheetName, 1, i);
					}
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string [] getCellDatabyTCandTS(ExcelReaderUsingNPOI xls,string sheetName, string tcName)
        {
            try
            {
                List<string> tsmethods= new List<string>();
				
				int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    return null;
                }
               sheet = workbook.GetSheetAt(index);
               int  rowcount = xls.getRowCount(sheetName);
                for (int k = 2; k <= rowcount; k++)
                {
                    if (xls.getCellData(sheetName, 1, k).ToLower() == tcName.ToLower())
                    {
                        tsmethods.Add(xls.getCellData(sheetName, 3, k)+","+xls.getCellData(sheetName, 4, k));
                    }
                }
                return tsmethods.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string setCellData(string sheetName, string colName, int rowNum, string data)
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                workbook = new XSSFWorkbook(fs);
                if (rowNum <= 0)
                    return "";
                int colNum = -1;
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(0);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (row.GetCell(i).StringCellValue.Equals(colName))
                    {
                        colNum = i;
                    }
                }
                if (colNum == -1)
                    return "";
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    row = sheet.CreateRow(rowNum - 1);
                cell = row.GetCell(colNum);
                if (cell == null)
                    cell = row.CreateCell(colNum);

                ICellStyle cs = workbook.CreateCellStyle();
                cs.WrapText = true;
                cell.CellStyle = cs;
                cell.SetCellValue(data);

                FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return data;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string setCellData(string sheetName, int colNum, int rowNum, string data)
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                try
                {

                    if (rowNum <= 0)
                        return "";
                    int index = workbook.GetSheetIndex(sheetName);
                    if (index == -1)
                        return "";
                    sheet = workbook.GetSheetAt(index);
                    row = sheet.GetRow(rowNum - 1);
                    if (row == null)
                        row = sheet.CreateRow(rowNum - 1);
                    cell = row.GetCell(colNum);
                    if (cell == null)
                        cell = row.CreateCell(colNum);
                    ICellStyle cs = workbook.CreateCellStyle();
                    cs.WrapText = true;
                    cell.CellStyle = cs;
                    cell.SetCellValue(data);

                    workbook.Write(f);
                    workbook.Close();
                    f.Close();
                    fs.Close();
                    return data;
                }
                catch (Exception)
                {
                    workbook.Write(f);
                    workbook.Close();
                    f.Close();
                    fs.Close();
                    return "";
                }
            }
            catch (Exception)
            {
              
                return "";
            }
        }
        public bool addSheet(string sheetName)
        {
            try
            {
                workbook.CreateSheet(sheetName);
                fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool removeSheet(string sheetName)
        {
            int index = workbook.GetSheetIndex(sheetName);
            if (index == -1)
                return false;
            try
            {
                workbook.RemoveSheetAt(index);
                fs = new FileStream(path, FileMode.Truncate);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool addColumn(string sheetName, string colName)
        {
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return false;
                ICellStyle cs = workbook.CreateCellStyle();
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(0);
                if (row == null)
                    row = sheet.CreateRow(0);
                cell = row.GetCell(0);
                if (cell == null)
                    cell = row.CreateCell(0);
                else
                    cell = row.CreateCell(row.LastCellNum);
                cell.SetCellValue(colName);
                cell.CellStyle = cs;

                FileStream f = new FileStream(path, FileMode.Create);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool removeColumn(string sheetName, int colNum)
        {
            try
            {
                if (!isSheetExist(sheetName))
                    return false;
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                sheet = workbook.GetSheet(sheetName);
                ICellStyle cs = workbook.CreateCellStyle();
                for (int i = 0; i < getRowCount(sheetName); i++)
                {
                    row = sheet.GetRow(i);
                    if (row != null)
                    {
                        cell = row.GetCell(colNum - 1);
                        if (cell != null)
                        {
                            cell.CellStyle = cs;
                            row.RemoveCell(cell);
                        }
                    }
                }
                FileStream f = new FileStream(path, FileMode.Truncate);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool isSheetExist(string sheetName)
        {
            try
            {
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    index = workbook.GetSheetIndex(sheetName.ToUpper());
                    if (index == -1)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int getCellRowNum(string sheetName, string colName, string cellValue)
        {
            try
            {
                for (int i = 0; i < getRowCount(sheetName); i++)
                {
                    if (getCellData(sheetName, colName, i).Equals(cellValue))
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// Desc:Method is used to get data from excel using NPOI
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static object[] getData(ExcelReaderUsingNPOI xls, string sheetName)
        {
            try
            {
                int rows = xls.getRowCount(sheetName);
                Console.WriteLine("Total rows :" + rows);
                int cols = xls.getColumnCount(sheetName);
                Console.WriteLine("Total cols :" + cols);
                object[][] data = new object[rows - 1][];
                int dataRow = 0;
                Dictionary<string, string> table = null;
                for (int rNum = 2; rNum <= rows; rNum++)
                {
                    data[rNum - 2] = new object[1];
                    table = new Dictionary<string, string>();
                    for (int cNum = 0; cNum < cols; cNum++)
                    {
                        string key = xls.getCellData(sheetName, cNum, 1);
                        string value = xls.getCellData(sheetName, cNum, rNum);
                        table.Add(key, value);
                    }
                    data[dataRow][0] = table;
                    dataRow++;
                }
                return data;

                
            }
            catch (Exception)
            {
                throw;
            }
        }




        public Dictionary<string, string> getData(ExcelReaderUsingNPOI xls, string sheetName,int rNum)
        {
            try
            {
                int rows = xls.getRowCount(sheetName);
                Console.WriteLine("Total rows :" + rows);
                int cols = xls.getColumnCount(sheetName);
                Console.WriteLine("Total cols :" + cols);
                object[] data = new object[rows - 1][];
                int dataRow = 0;
                Dictionary<string, string> table = null;
                if(rNum <= rows)
                {
                    data[rNum - 2] = new object[1];
                    table = new Dictionary<string, string>();
                    for (int cNum = 0; cNum < cols; cNum++)
                    {
                        string key = xls.getCellData(sheetName, cNum, 1);
                        string value = xls.getCellData(sheetName, cNum, rNum);
                        table.Add(key, value);
                    }

                }
                return table;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> getDataByDataID(ExcelReaderUsingNPOI xls, string sheetName,string dataid)
        {
            try
            {
                int rows = xls.getRowCount(sheetName);
                Console.WriteLine("Total rows :" + rows);
                int cols = xls.getColumnCount(sheetName);
                Console.WriteLine("Total cols :" + cols);
                object[] data = new object[rows - 1][];
                int dataRow = 0;
                Dictionary<string, string> table = null;

                for(int i=0;i<=rows;i++)
                {
                    if (xls.getCellData(sheetName, 0, i) == dataid)
                    {
                        data[0] = new object[1];
                        table = new Dictionary<string, string>();
                        for (int cNum = 0; cNum < cols; cNum++)
                        {
                            string key = xls.getCellData(sheetName, cNum, 1);
                            string value = xls.getCellData(sheetName, cNum, i);
                            table.Add(key, value);
                        }
                    }

                }
                return table;


            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string getResponseData(ExcelReaderUsingNPOI xls, string apiType)
        {
            string statusCode = null;
            int rows = xls.getRowCount(EnumClass.APIDataSheet.ResponseData.ToString());
            for (int rNUm = 2; rNUm <= rows; rNUm++)
            {
                string currentApiType = xls.getCellData(EnumClass.APIDataSheet.ResponseData.ToString(), "Type", rNUm);
                if (currentApiType.Equals(apiType))
                {
                    statusCode = xls.getCellData(EnumClass.APIDataSheet.ResponseData.ToString(), "StatusCode", rNUm);

                }
            }
            return statusCode;
        }

        public  DataTable GetDataInTable()
        {
            fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            workbook = new XSSFWorkbook(fs);
            ISheet sheet = workbook.GetSheet("TestSuit"); // zero-based index of your target sheet
            DataTable dt = new DataTable(sheet.SheetName);

            // write header row
            IRow headerRow = sheet.GetRow(0);
            foreach (ICell headerCell in headerRow)
            {
                dt.Columns.Add(headerCell.ToString());
            }

            // write the rest
            int rowIndex = 0;
            foreach (IRow row in sheet)
            {
                // skip header row
                if (rowIndex++ == 0) continue;
                DataRow dataRow = dt.NewRow();
                dataRow.ItemArray = row.Cells.Select(c => c.ToString()).ToArray();
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

       

    }
}
