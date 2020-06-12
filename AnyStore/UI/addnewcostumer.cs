using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnyStore.BLL;
using AnyStore.DAL;
namespace AnyStore.UI
{
    public partial class addnewcostumer : Form
    {

        public void clear()
        {
            txtu_Name.Text = "";
            textmobile.Text = "";
            texttyp.Text = "";
            textemail.Text = "";
            textcompany.Text = "";
        }
        companysDAL pDAL = new companysDAL();
        custDAL tDAL = new custDAL();
        public addnewcostumer()
        {
            InitializeComponent();
        }

        private void txtu_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            companysBLL tc = new companysBLL();
            custBLL c = new custBLL();
            string keyword = textcompany.Text;
            bool sucess = pDAL.chkcompanybyname(keyword);
            if (sucess == true)

            {
                MessageBox.Show("company found");
                tc = pDAL.GetcompanysForTransaction(keyword);
                int id = tc.id;
                c.cid = id;
                c.nquery = 0;
            }
            else
            {
               addcompanys  ca = new addcompanys();
                ca.Show();
            }
            c.name = txtu_Name.Text;
            c.mobile = textmobile.Text;
            c.type = texttyp.Text;
            c.email = textemail.Text;
            tc = pDAL.Search(textcompany.Text);
            sucess = tDAL.Insert(c);

            if (sucess == true)
            {
                MessageBox.Show("costumer  added sucessfully");
                clear();
            }
            else
            {
                MessageBox.Show("costumer can not be added");
            }




        }
    }
}
