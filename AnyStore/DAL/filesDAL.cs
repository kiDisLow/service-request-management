using AnyStore.BLL;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;

namespace AnyStore.DAL
{
    class filesDAL
    {
        public bool deactivate(findandreplaceBLL d)
        {
            bool sucess = false;
            try
            {
                word._Application _app = new word.Application();
                Document doc = _app.Documents.Open("template.docx");
                _app.Selection.Find.Execute(d.textToFind,d.matchCase,d.matchWholeWord,d.matchWildcards,d.matchSoundsLike,d.matchAllWordForms,d.forward,d.wrap,d.format,d.textToReplace,d.replace);
               // doc.SaveAs2("deactivation request" + .pdf", word.WdSaveFormat.wdFormatPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sucess = false;
            }

            finally
            { 

             }

            return sucess;
        }
    }
}
