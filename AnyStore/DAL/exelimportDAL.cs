using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using System.Data;
using AnyStore.DAL;
using System.Windows.Forms;

class exelimportDAL
    {
        public bool coppyquery()
        {
            bool sucess= true;
            excel.Application _app = new excel.Application();

            return sucess;
        }
    #region method to get the file location;
    public System.Data.DataTable ReadExcel(string fileName, string fileExt)
        {
        
        excel.Application _app = new excel.Application();

        string conn = string.Empty;
            System.Data.DataTable dt = new System.Data.DataTable();

            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dt); //fill excel data into dataTable  
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            return dt;
        }
    #endregion
}

