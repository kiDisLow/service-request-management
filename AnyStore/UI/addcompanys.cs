using AnyStore.BLL;
using AnyStore.DAL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
namespace AnyStore.UI
{
    public partial class addcompanys : Form
    {
        public void clear()
        {
            txtcname.Text = "";
            txtcemail.Text = "";
            txtcmobile.Text = "";
            txtclocation.Text = "";
            txtcsubend.Text = "";
        }
        public addcompanys()
        {
            InitializeComponent();
        }
        DeaCustDAL dcDAL = new DeaCustDAL();
        companysDAL pDAL = new companysDAL();
        userDAL uDAL = new userDAL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();
        companysBLL dc = new companysBLL();
        DataTable company = new DataTable();
 
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword fro the text box
            string keyword = txtcSearch.Text;

            if (keyword == "")
            {
                //Clear all the textboxes
                txtcname.Text = "";
                txtcemail.Text = "";
                txtcmobile.Text = "";
                txtclocation.Text = "";
                txtcsubend.Text = "";
                return;
            }

            //Write the code to get the details and set the value on text boxes 
            companysBLL dc = pDAL.Search(keyword);

            //Now transfer or set the value from DeCustBLL to textboxes
            txtcname.Text = dc.c_name;
            txtcemail.Text = dc.c_email;
            txtcmobile.Text = dc.c_mobile;
            txtclocation.Text = dc.c_location;
            txtccatogary.Text = dc.c_category;           
            txtcsubend.Text = dc.subend_date;

         




        }

        private void btnAdd_Click(object sender, EventArgs e)


        {


           dc.c_name = txtcname.Text;
           dc.c_email = txtcemail.Text;
           dc.c_mobile= txtcmobile.Text;
           dc.c_location = txtclocation.Text;
           dc.c_category= txtccatogary.Text;
           dc.subend_date= txtcsubend.Text;
           dc.substart_date = "vaibhav";

            pDAL.Insert( dc);
            bool success = pDAL.Insert(dc);
            if(success==true)
            {
                MessageBox.Show("company added sucessfully");
                clear();
            }
            else
            {
                MessageBox.Show("company can not be added");
            }

        }

        private void txtcmobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void dvgcinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = pDAL.Select();
            dvgcinfo.DataSource = dt;
        }

        private void addcompanys_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = pDAL.Select();
            dvgcinfo.DataSource = dt;
        }

        private void dvgcinfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            cidtxt.Text = dvgcinfo.Rows[RowIndex].Cells[0].Value.ToString();
            txtcname.Text = dvgcinfo.Rows[RowIndex].Cells[1].Value.ToString();
            txtcmobile.Text = dvgcinfo.Rows[RowIndex].Cells[4].Value.ToString();
            txtccatogary.Text = dvgcinfo.Rows[RowIndex].Cells[2].Value.ToString();
            txtcsubend.Text = dvgcinfo.Rows[RowIndex].Cells[6].Value.ToString();
            txtcsubstart.Text = dvgcinfo.Rows[RowIndex].Cells[7].Value.ToString();
            txtclocation.Text = dvgcinfo.Rows[RowIndex].Cells[3].Value.ToString();
            txtcemail.Text = dvgcinfo.Rows[RowIndex].Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            companysBLL dc =new companysBLL();
            dc.id= Convert.ToInt32(cidtxt.Text);
         

            pDAL.Update(dc);
            bool success = pDAL.Update(dc);
            if (success == true)
            {
                MessageBox.Show("company updated sucessfully");
                clear();
                DataTable dt = new DataTable();
                dt = pDAL.Select();
                dvgcinfo.DataSource = dt;
            }
            else
            {
                MessageBox.Show("company can not be updated");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            companysBLL dc = new companysBLL();
            dc.id = Convert.ToInt32(cidtxt.Text);
            
            dc.c_name = txtcname.Text;
            dc.c_email = txtcemail.Text;
            dc.c_mobile = txtcmobile.Text;
            dc.c_location = txtclocation.Text;
            dc.c_category = txtccatogary.Text;
            dc.subend_date = txtcsubend.Text;
            dc.substart_date = "vaibhav";

        
            bool success = pDAL.Delete(dc);
            if (success == true)
            {
                MessageBox.Show("company deleted sucessfully" );
                clear();
                DataTable dt = new DataTable();
                dt = pDAL.Select();
                dvgcinfo.DataSource = dt;
            }
            else
            {
                MessageBox.Show("company can not be deleted");
            }
        }

        private void cidtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcname_TextChanged(object sender, EventArgs e)
        {

        }
    }

   
}
