using System.Windows.Forms;
using outlook= Microsoft.Office.Interop.Outlook;
using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnyStore.DAL
{
    class emailDAL
    {
        #region to send query email
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
          
        }




        private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }
            else
            {
                appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signaturer";
                signature = string.Empty;
                diInfo = new DirectoryInfo(appDataDir);

                if (diInfo.Exists)
                {
                    FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                    if (fiSignature.Length > 0)
                    {
                        StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                        signature = sr.ReadToEnd();

                        if (!string.IsNullOrEmpty(signature))
                        {
                            string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                            signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                        }
                    }
                }
            }

            return signature;
        }

        public bool  sendemail(emailsBLL m )
        {
            bool sucess = true;
            string signature = ReadSignature();

            try
            {
                outlook._Application _app = new outlook.Application();
                outlook.MailItem mail = (outlook.MailItem)_app.CreateItem(outlook.OlItemType.olMailItem);
                mail.BodyFormat = outlook.OlBodyFormat.olFormatHTML;
                
                mail.To = m.to;
                mail.Subject = m.subject;
                string body = "<html><body>" + "Kind attention  Mr. " + "<b>" + m.name + "\n\n thank you for contacting Iris Hightech Technical support. A seervice request has been genrated as below:" + "</b>"  + m.body + "<span style='font-size:10.0pt;color:#578a90'>this is a system generated mail and query will be closed by itself in the next 24 hours if no response is received by recipients\n\n</span>" + "<span style='color:#1F497D'> Regards</span> \n <span style='font-size:14.0pt;color:#1F497D'>SOLIDWORKS Technical Support</span> \n <span style='color:#1F497D'>Phone no: 011 - 48175001, 011 - 47005616 </span>\n <span style='color:#1F497D'>Email: swsupport@irishightech.com </span>\n<span style='font-size:13.0pt;color:#C00000'> Iris Hightech Private Limited </span>\n <span style='font-size:10.0pt;color:#C00000'>(Authorized Value Added Reseller & Training Centre - SolidWorks - CAM - MakerBot 3D Printer)</span>" + "</body></html>" + "";
                body = body.Replace("\n", "<br/>");
                mail.HTMLBody = body;
                mail.Importance = outlook.OlImportance.olImportanceNormal;                
                ((outlook.MailItem)mail).Send();
                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sucess = false;
            }
            finally
            {
                
            }
            return sucess;
        }




        #endregion
        #region
        public bool senddeactivationform(emailsBLL m)
        {
            bool sucess = true;
            string signature = ReadSignature();

            try
            {
                outlook._Application _app = new outlook.Application();
                outlook.MailItem mail = (outlook.MailItem)_app.CreateItem(outlook.OlItemType.olMailItem);
                mail.BodyFormat = outlook.OlBodyFormat.olFormatHTML;
                
                mail.To = m.to;
                mail.Subject = m.subject;
                string body = "<html><body>"  + m.body + "<span style='font-size:10.0pt;color:#578a90'>this is a system generated mail and query will be closed by itself in the next 24 hours if no response is received by recipients\n\n</span>";
                body = body.Replace("\n", "<br/>");
                mail.HTMLBody = body;
                if (string.IsNullOrEmpty(m.attachment) == false)
                {
                    // need to check to see if file exists before we attach !
                    if (!File.Exists(m.attachment))
                        MessageBox.Show("Attached document " + m.attachment + " does not exist", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        mail.Attachments.Add(m.attachment,outlook.OlAttachmentType.olByValue,1,"vaibhav.pdf");
                    }
                }
                //mail.Display();     // display the email
                mail.Importance = outlook.OlImportance.olImportanceNormal;
                ((outlook.MailItem)mail).Send();

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
        #endregion



    }
}
