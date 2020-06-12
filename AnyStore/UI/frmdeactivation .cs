using AnyStore.BLL;
using AnyStore.DAL;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class deactivation : Form
    {
        public deactivation()
        {
            InitializeComponent();
        }
        string filePath = string.Empty;
        string fileExt = string.Empty;
        string savepath = string.Empty;
        string filepathemail = string.Empty;
        string fileExtemail = string.Empty;
        string companydeact = queryfrm.companydeact;
        string createandsendpath = string.Empty;
        companysBLL c = new companysBLL();
        companysDAL dc = new companysDAL();
        emailDAL em = new emailDAL();


        private void Form1_Load(object sender, EventArgs e)
        {
            locationsBLL l = new locationsBLL();
            locationDAL ld = new locationDAL();
         

 
            c = dc.Search(companydeact);
            emailsBLL email = new emailsBLL();
            txtemail.Text = c.c_email;
            txtcompany.Text = c.c_name;
            l = ld.search("template");
            lbltemplate.Text =l.location ;
            filePath = lbltemplate.Text;
            l = ld.search("save deactivation");
            lblsave.Text = l.location;
            filepathemail = lblsave.Text;           
            savepath = lblsave.Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string serial = txtserial.Text;
            string cid = txtcomputer_id.Text;          
            
                locationsBLL l = new locationsBLL();
                locationDAL l1 = new locationDAL();
                OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
                {
                    l.location= file.FileName; //get the path of the file  
                    l.type = "template";
                if (l1.Insert(l)) { MessageBox.Show("file location saved"); }
                else { MessageBox.Show("file can not be added"); }
                }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button4_Click(this, new EventArgs());
            await System.Threading.Tasks.Task.Delay(2000);
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            //if there is a file choosen by the user  
            {
               
                c = dc.Search(companydeact);
                emailsBLL email = new emailsBLL();
               // txtemail.Text = c.c_email;
                email.to = txtemail.Text;
                email.subject = "solidworks deactivation form ";
                string body = "<span style='color:#1F497D'>Dear Sir,</span> \n<span style='color:#1F497D'>As per our discussion, please find the attached deactivation form.</span><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>Please sign and stamp and revert it asap.<o:p></o:p></span></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>It will take 24-48 hours to process the request.</span><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><o:p>&nbsp;</o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><b><span style='color:#1F497D'>In case of any query, feel free to contact us.</span></b><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><b><span style='color:#1F497D'>&nbsp;</span></b><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><b><span style='color:#1F497D'>Technical Support Team</span></b><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>IRIS HIGHTECH PRIVATE LIMITED</span><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>Contact: mailto swsupport@irishightech.com" +"<span style='color:#6666FF'>swsupport@irishightech.com</span></a><span style='color:#1F497D'> || 011-48175001, 011- 47005616</span><o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p></div> " + "\n\n\n\n\n";
                email.body = body;
                email.name = companydeact;
                email.attachment = createandsendpath;
                bool sucess = em.senddeactivationform(email);
                if (sucess == true)
                {
                    MessageBox.Show("email sent sucessfully");

                }
                else
                    MessageBox.Show("email not sent");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog(); //open dialog to choose file  
            path.ShowNewFolderButton = true;
            if (path.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                locationsBLL l = new locationsBLL();
                locationDAL l1 = new locationDAL();
                OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file                
                
                    l.location = path.SelectedPath; //get the path of the file  
                    l.type = "save deactivation";
                    if (l1.Insert(l)) { MessageBox.Show("file location saved"); }
                    else { MessageBox.Show("file can not be added"); }
                
               

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string serial = txtserial.Text;
            string cid = txtcomputer_id.Text;
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };

            Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(filePath, ReadOnly: false, Visible: true);

            aDoc.Activate();

            Microsoft.Office.Interop.Word.Find fnd = wordApp.ActiveWindow.Selection.Find;

            fnd.ClearFormatting();
            fnd.Replacement.ClearFormatting();
            fnd.Forward = true;

            fnd.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;

            fnd.Text = "#cid#";
            fnd.Replacement.Text = cid;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);
            fnd.Text = "#serial#";
            fnd.Replacement.Text = serial;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);
            fnd.Text = "#company#";
            fnd.Replacement.Text = txtcompany.Text;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);
            string date = DateTime.Now.ToString("MMMMddyyyy");
            aDoc.SaveAs2(savepath + "\\" + "deactivation form " + companydeact + date, WdSaveFormat.wdFormatPDF);
            createandsendpath = savepath + "\\" + "deactivation form " + companydeact + date + ".pdf";
            aDoc.Close(SaveChanges: false);
            //Microsoft.Office.Interop.Word.Document aDoc1 = wordApp.Documents.Open(savepath + "\\" + "deactivation form " + companydeact, ReadOnly: true, Visible: true);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            string templ = file.FileName;
                c = dc.Search(companydeact);
                emailsBLL email = new emailsBLL();
                //txtemail.Text = c.c_email;
                email.to = txtemail.Text;
                email.subject = "solidworks deactivation form ";
                string body = "<span style='color:#1F497D'>Dear Sir,</span> \n<span style='color:#1F497D'>As per our discussion, please find the attached deactivation form.</span><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>Please sign and stamp and revert it asap.<o:p></o:p></span></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>It will take 24-48 hours to process the request.</span><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><o:p>&nbsp;</o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><b><span style='color:#1F497D'>In case of any query, feel free to contact us.</span></b><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><b><span style='color:#1F497D'>&nbsp;</span></b><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><b><span style='color:#1F497D'>Technical Support Team</span></b><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>IRIS HIGHTECH PRIVATE LIMITED</span><o:p></o:p></p><p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span style='color:#1F497D'>Contact: </span><a href=\"mailto:swsupport @irishightech.com\" target=\"_blank\"><span style='color:#6666FF'>swsupport@irishightech.com</span></a><span style='color:#1F497D'> || 011-48175001, 011- 47005616</span><o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p></div> " + "\n\n\n\n\n";
                email.body = body;
                email.name = companydeact;
                email.attachment = templ;
                bool sucess = em.senddeactivationform(email);
                if (sucess == true)
                {
                    MessageBox.Show("email sent sucessfully");

                }
                else
                    MessageBox.Show("email not sent");
            
        }
    }
}
