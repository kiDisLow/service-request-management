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
    public partial class queryfrm : Form
    {
        int qid = 0;
        queryDAL dcDAL = new queryDAL();
        companysDAL pDAL = new companysDAL();
        userDAL uDAL = new userDAL();
        custDAL tDAL = new custDAL();
        // transactionDetailDAL tdDAL = new transactionDetailDAL();
        emailDAL eDAL = new emailDAL();
        int qid1 = 0;
        string emailname;
        public static string companydeact;
        public queryfrm()
        {
            InitializeComponent();
        }


        public void Clear()
        {
            txtu_Name.Text = "";
            txtu_Contact.Text = "";
            txtcompany.Text = "";
            textqry.Text = "";
            
        }
        private void txtu_Name_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword fro the text box
            string keyword = txtu_Name.Text;
           

            if (keyword == "")
            {
                //Clear all the textboxes
                txtu_Name.Text = "";
                txtu_Contact.Text = "";
                txtcompany.Text = "";
                textqry.Text = "";
                return;
            }
            custBLL dc = tDAL.searchcustumer(keyword);
            //Write the code to get the details and set the value on text boxes

            //queryBLL q = new queryBLL();


            //Now transfer or set the value from DeCustBLL to textboxes
            // dc.name= txtu_Name.Text;
            txtu_Contact.Text = dc.mobile;
            int Cid = dc.cid;
            companysBLL c = pDAL.Searchfromid(Cid);
            txtcompany.Text=c.c_name;
            txtemail.Text = dc.email;
         
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string keyword = txtu_Name.Text;            
            queryBLL q = new queryBLL();
           
            bool qsucess = tDAL.chkcustumer(keyword);
            custBLL dc = tDAL.searchcustumer(keyword);
            if (qsucess == true)
            {
                keyword = txtcompany.Text;
                companysBLL c = pDAL.Search(keyword);
                q.ques = textqry.Text;
                q.soln = textsoln.Text;
                q.cu_id = dc.id;
                q.c_id = dc.cid;
                q.u_name = dc.name;
                emailname = q.u_name;
                q.u_mobile = dc.mobile;
                dc.nquery = dc.nquery++;
                bool incquery = tDAL.Increasenoofquery(dc);if (incquery == true) { MessageBox.Show("user and query updated"); } else { MessageBox.Show("user and query not updated"); }
                q.status = 1;
                bool success = dcDAL.Insert(q);
                q = dcDAL.Getqueryforsearch(q);
                qid = q.q_id;
                qid1 = q.q_id;
            }

            if (qsucess == false)
            {
                keyword = txtcompany.Text;
                bool csucess = pDAL.chkcompanybyname(keyword);
                    if(csucess==true)
                {
                    keyword = txtcompany.Text;
                    companysBLL c = pDAL.Search(keyword);
                    
                        custBLL ca = new custBLL();
                        ca.name = txtu_Name.Text;
                    emailname = q.u_name;
                    ca.mobile = txtu_Contact.Text;
                        string type = "user";
                        ca.type = type;
                        ca.email = txtemail.Text;
                        bool isadded = false;
                        int id = c.id;
                        ca.cid = id;
                        ca.nquery = 0;
                        isadded = tDAL.Insert(ca);
                    if (isadded == true)
                    {
                        MessageBox.Show("new user added");
                    }
                    else
                        MessageBox.Show("new user can not be added");
                }

                    else
                {
                    MessageBox.Show("plz add new company");
                    addcompanys ca = new addcompanys();
                    ca.Show();
                }
                
                //space to add new user(custumer)
                //addnewcostumer costumer = new addnewcostumer();
                //costumer.Show();
                //this.Hide();
                //MessageBox.Show("plz add new costumer");
                //Failed to Add New product
                //MessageBox.Show("new user added");
            }
           
         
            //if the product is added successfully then the value of success will be true else it will be false
            if (qsucess == true)
            {
                //Product Inserted Successfully
                MessageBox.Show("query Added Successfully");
                
                
                emailsBLL email = new emailsBLL();
                email.to = txtemail.Text;
                email.subject = "solidworks support query " + qid;
                string body = "<h3>" + "query- \n " + "</h3>" + "<b>" + textqry.Text + "</b>" + "<h3>" + " \n\n solution- \n" + "</h3>" + "<b>" + textsoln.Text + "</b>" + "\n\n\n\n\n";
                email.body = body;
                email.name = txtu_Name.Text;
                bool sucess = eDAL.sendemail(email);
                if (sucess == true)
                {
                    MessageBox.Show("email sent sucessfully");

                }
                else
                    MessageBox.Show("email not sent");
                //Calling the Clear Method



            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool sucess = dcDAL.Updatesoln(qid, textsoln.Text);
            emailsBLL email = new emailsBLL();
            email.to = txtemail.Text;
            email.subject = "Solidworks support query id =" + qid;
            string body = "<h3>" + "Query- \n " + "</h3>" + "<b>" + textqry.Text + "</b>" + "<h3>" + " \n\n Solution- \n" + "</h3>" + "<b>" + textsoln.Text + "</b>" + "\n\n\n\n\n";
            email.body = body;
            email.name = txtu_Name.Text;
            bool sucess1 = eDAL.sendemail(email);
            if (sucess1 == true)
            {
                MessageBox.Show("email sent sucessfully");

            }
            else
                MessageBox.Show("email not sent");
            //Calling the Clear Method

            if (sucess == true)
            {
                MessageBox.Show("query updated ");
            }
            else { MessageBox.Show("unable to update query"); }
        }

        private void queryfrm_Load(object sender, EventArgs e)
        {
           
            dgvpending.DataSource = dcDAL.Select(0);
            dgvpending.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        } 

        private void txtu_Contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string keyword = txtu_Name.Text;
            queryBLL q = new queryBLL();

            bool qsucess = tDAL.chkcustumer(keyword);//chking costumer
            custBLL dc = tDAL.searchcustumer(keyword);
            if (qsucess == true)// if costumer is found
            {
                keyword = txtcompany.Text;
                companysBLL c = pDAL.Search(keyword);
                q.ques = textqry.Text;
                q.soln = textsoln.Text;
                q.cu_id = dc.id;
                q.c_id = dc.cid;
                q.u_name = dc.name;
                emailname = q.u_name;
                q.u_mobile = dc.mobile;
                dc.nquery = dc.nquery++;
                q.status = 0;
                q.datetime = DateTime.Now;
                bool success = dcDAL.Insert(q);
                bool incquery = tDAL.Increasenoofquery(dc); if (incquery == true) { MessageBox.Show("user and query updated"); } else { MessageBox.Show("user and query not updated"); }
                emailname = q.u_name;
                q = dcDAL.Getqueryforsearch(q);
                qid = q.q_id;
                if (success == true)
                {
                    //Product Inserted Successfully
                    MessageBox.Show("query Added Successfully");
                    emailsBLL email = new emailsBLL();
                    email.to = txtemail.Text;
                    email.subject = "solidworks support query " + qid;
                    string body = "<h3>" + "SR NO."+DateTime.Today+ "  " +qid+"query- \n " + "</h3>" + "<b>" + textqry.Text + "</b>" + "<h3>" + " \n\n solution- \n" + "</h3>" + "<b>" + textsoln.Text + "</b>" + "\n\n\n\n\n";
                    email.body = body;
                    email.name = txtu_Name.Text;
                    bool sucess = eDAL.sendemail(email);
                    if (sucess == true)
                    {
                        MessageBox.Show("email sent sucessfully");

                    }
                    else
                        MessageBox.Show("email not sent");
                    //Calling the Clear Method
                }

            }

            if (qsucess == false)
            {
                keyword = txtcompany.Text;
                bool csucess = pDAL.chkcompanybyname(keyword);
                if (csucess == true)
                {
                    keyword = txtcompany.Text;
                    companysBLL c = pDAL.Search(keyword);

                    custBLL ca = new custBLL();
                    ca.name = txtu_Name.Text;
                    ca.mobile = txtu_Contact.Text;
                    string type = "user";
                    ca.type = type;
                    ca.email = txtemail.Text;
                    bool isadded = false;
                    int id = c.id;
                    ca.cid = id;
                    ca.nquery = 0;
                     
                    isadded = tDAL.Insert(ca);
                    if (isadded == true)
                    {
                        MessageBox.Show("new user added");
                    }
                    else
                        MessageBox.Show("new user can not be added");
                }

                else
                {
                    MessageBox.Show("plz add new company");
                    addcompanys ca = new addcompanys();
                    ca.Show();
                }
                
                }
            }

        private void textqry_TextChanged(object sender, EventArgs e)
        {
            string keyword = textqry.Text;
            if (textqry.Text=="#deactivation#")
            {
                MessageBox.Show("do you want to make new deactivation form");
                if (txtcompany.Text != "" && txtu_Name.Text =="")
                {
                    companydeact = txtcompany.Text;
                    deactivation ca = new deactivation();
                    string company = txtcompany.Text;
                    textqry.Text = "deactivation required for    " + company + DateTime.Now.ToString("dd mm yy" ) + "requested by   " + txtu_Name.Text;
                    textsoln.Text = "we will send you deactivation form shortly" ;                    
                    textqry.Text = "";
                    textsoln.Text = "";
                    dgvquery.DataSource = dcDAL.Select(0);
                    dgvquery.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    ca.Show();

                }
                if (txtcompany.Text != "" && txtu_Name.Text != "")
                {
                    companydeact = txtcompany.Text;
                    deactivation ca = new deactivation();
                   
                    textqry.Text = "deactivation required for " + txtcompany.Text + DateTime.Now + "requested by" + txtu_Name.Text;
                    textsoln.Text = "we will send you deactivation form shortly";
                   // button4_Click(this, new EventArgs());
                    textqry.Text = "";
                    textsoln.Text = "";
                    dgvquery.DataSource = dcDAL.Select(0);
                    dgvquery.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    ca.Show();

                }
                else
                {
                    MessageBox.Show("plz add company name in account box");
                }
            }
            dgvquery.DataSource = dcDAL.Getsoln(keyword);
            dgvquery.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void textsoln_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvquery_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e1)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvquery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvpending_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvpending_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvpending_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowinde = e.RowIndex;
            if (dgvquery.Rows.Count > rowinde)
            { 
                textqry.Text = dgvpending.Rows[rowinde].Cells[3].Value.ToString();
                txtu_Name.Text = dgvpending.Rows[rowinde].Cells[1].Value.ToString();
                textsoln.Text= dgvpending.Rows[rowinde].Cells[4].Value.ToString();         
                qid = int.Parse(dgvpending.Rows[rowinde].Cells[0].Value.ToString());
            }
            dgvquery.DataSource = dcDAL.Select(0);
            dgvquery.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryBLL q = new queryBLL();
            q = dcDAL.updatestatusandreturn(txtu_Name.Text, textqry.Text,textsoln.Text, txtu_Contact.Text);
            dgvpending.DataSource = dcDAL.Select(0);
        }

        private void dgvquery_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            { textsoln.Text = dgvquery.Rows[rowindex].Cells[1].Value.ToString(); }
        }
    }
    
}

