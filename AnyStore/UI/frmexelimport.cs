using AnyStore.BLL;
using AnyStore.DAL;
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
    public partial class frmexelimport : Form
    {
        public frmexelimport()
        {
            InitializeComponent();
        }
        exelimportDAL eDAL = new exelimportDAL();


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void locatefile_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();


            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = eDAL.ReadExcel(filePath, fileExt); //read excel file  
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        #region method to add company
        private void import_Click(object sender, EventArgs e)
        {
            queryBLL q = new queryBLL();
            companysBLL b = new companysBLL();
            companysDAL dc = new companysDAL();
            int i = dataGridView1.Rows.Count;
            i--;
            string add ="";
            string name;
            string mobile;
            string sub;
            string email;
            string subend = "12/12/2009";
            string cat = "na";

            for (int j = 1; j < i; j++)

            {
                name = dataGridView1.Rows[j].Cells[11].Value.ToString();
                bool sucess = dc.chkcompanybyname(name);
                if (sucess == false)

                {
                    
                    
                    
                        add =  dataGridView1.Rows[j].Cells[6].Value.ToString();
                        add = add + dataGridView1.Rows[j].Cells[7].Value.ToString();
                        add = add + dataGridView1.Rows[j].Cells[3].Value.ToString();
                        add = add + dataGridView1.Rows[j].Cells[8].Value.ToString();

                    b.c_location = add;
                    name = dataGridView1.Rows[j].Cells[11].Value.ToString();
                    mobile = dataGridView1.Rows[j].Cells[1].Value.ToString();
                    sub = dataGridView1.Rows[j].Cells[2].Value.ToString();
                    email = dataGridView1.Rows[j].Cells[0].Value.ToString();
                    sub = dataGridView1.Rows[j].Cells[2].Value.ToString();
                    b.c_name = name;
                    b.c_mobile = mobile;
                    b.c_email = email;
                    b.subend_date = sub;
                    b.substart_date = subend;
                    b.c_category = cat;

                    bool suck = dc.Insert(b);
                    add = " ";
                    if(suck!= true)
                    {
                        MessageBox.Show("nhi add hui");
                    }
                }
            }
          
        }
        #endregion
        private void frmexelimport_Load(object sender, EventArgs e)
        {

        }
        #region method to add user
        private void button1_Click(object sender, EventArgs e)
        {
            #region dal and bll
            custBLL c = new custBLL();
            custDAL cd = new custDAL();
            queryBLL q = new queryBLL();
            queryDAL qd = new queryDAL();
            companysBLL b = new companysBLL();
            companysDAL dc = new companysDAL();
            #endregion
            #region query variables
            string ques;
            string ans;
            int cid ;
            string cname;
            #endregion
            #region user details
            //int id;
            string type = "user";
            string email;
            string name = "";
            string mobile;
            //int nquery;
            #endregion

            int i = dataGridView1.Rows.Count;
            i--;
            for (int j = 1; j < i; j++)

            {
                cname = dataGridView1.Rows[j].Cells[4].Value.ToString();
                bool sucess = cd.chkcustumer(cname);

                if (sucess == false)

                { 
                    

                    #region get data from table
                    name = dataGridView1.Rows[j].Cells[4].Value.ToString();
                    mobile = dataGridView1.Rows[j].Cells[5].Value.ToString();
                    ans = dataGridView1.Rows[j].Cells[3].Value.ToString();
                    email = dataGridView1.Rows[j].Cells[6].Value.ToString();
                    cname = dataGridView1.Rows[j].Cells[1].Value.ToString();
                    ques = dataGridView1.Rows[j].Cells[2].Value.ToString();
                    #endregion
                    #region adding the user
                    bool isuser = cd.chkcustumer(name);
                    if (isuser == false)
                    {
                        c.name = name;
                        c.mobile = mobile;
                        c.email = email;
                        c.type = type;
                        b = dc.GetcompanysForTransaction(cname);
                        cid = b.id;
                        c.cid = cid;
                        c.nquery = 0;
                        bool useradded = cd.Insert(c);
                        bool qinc = cd.Increasenoofquery(c);
                        if (useradded == false) { MessageBox.Show("user adding failed"); }
                    }
 
                    #endregion
                    


                    
                 
                }
            }
        }
        #endregion

        #region method to update query
        private void button2_Click(object sender, EventArgs e)
        {

            custBLL c = new custBLL();
            custDAL cd = new custDAL();
            queryBLL q = new queryBLL();
            queryDAL qd = new queryDAL();
            companysBLL b = new companysBLL();
            companysDAL dc = new companysDAL();


            #region user details
            //int id;
            
            string email;
            string name = "";
            string mobile;
            //int nquery;
            #endregion
            #region query details
            string ques;
            string ans;
            int status = 1;
            int cid;
            string cname;
            int i = dataGridView1.Rows.Count;
            i--;
            #endregion

            for (int j = 1; j < i; j++)
            {   
                         


                #region get data from table
                name = dataGridView1.Rows[j].Cells[4].Value.ToString();
                mobile = dataGridView1.Rows[j].Cells[5].Value.ToString();
                ans = dataGridView1.Rows[j].Cells[3].Value.ToString();
                email = dataGridView1.Rows[j].Cells[6].Value.ToString();
                cname = dataGridView1.Rows[j].Cells[1].Value.ToString();
                ques = dataGridView1.Rows[j].Cells[2].Value.ToString();
                #endregion
                #region fill the query
                q.u_name = name;
                q.u_mobile = mobile;
                q.ques = ques;
                q.soln = ans;
                q.status = status;
                b = dc.GetcompanysForTransaction(cname);
                cid = b.id;
                q.c_id = cid;
                bool isuser1 = cd.chkcustumer(name);
                if (isuser1 == true) { c = cd.searchcustumer(name); }
                else { MessageBox.Show("user not found"); }
                q.cu_id = c.id;
                q.status = status;
                bool qadded = qd.Insert(q);
               if(qadded==false) { MessageBox.Show("query not added"); }
                #endregion

            }
        }
    }
    #endregion

}
