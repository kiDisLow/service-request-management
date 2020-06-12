using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using AnyStore.DAL;


namespace AnyStore.UI
     
        
{
 
 
public partial class frmgetcompanys : Form
    {

        
        public frmgetcompanys()
        {
            InitializeComponent();
        }

        private void webBrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void frmgetcompanys_Load(object sender, EventArgs e)

        {
            webBrowse.ObjectForScripting = true;
            int intIeVer = 11;
            WebBrowserHelper.FixBrowserVersion();
            WebBrowserHelper.FixBrowserVersion("AnyStore");
            WebBrowserHelper.FixBrowserVersion("AnyStore", intIeVer);


            webBrowse.Navigate("https://varportal.solidworks.com/siebel/app/partnerportal/enu?SWECmd=GotoView&SWEView=SW+OUI+Asset+Mgmt+-+Assets+View+(SCW)&SWERF=1&SWEHo=varportal");
            
          



        }




        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement username = webBrowse.Document.GetElementById("Ecom_User_ID");
            HtmlElement password = webBrowse.Document.GetElementById("Ecom_Password");
            string usename = "vdwivedii@irishightech.com";
            string passwrd = "Vaibhav123";
            username.SetAttribute("value", usename);
            password.SetAttribute("value", passwrd);
            webBrowse.ObjectForScripting = true;
            HtmlElement searchid = webBrowse.Document.GetElementById("s_swepi_22");
            //searchid.InvokeMember("Click");
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlElement username = webBrowse.Document.GetElementById("s_1_1_4_0_Ctrl");
             username.InvokeMember("Click");
        }
    }

}
