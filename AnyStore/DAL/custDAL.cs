using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AnyStore.DAL
{
    class custDAL
    {
        //Creating STATI String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        #region Select method for custumers
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DAtaTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select all the companys from database
                String sql = "SELECT * FROM tbl_cust";

                //Creating SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the value from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open DAtabase Connection
                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
        #region  search method to search user

        public custBLL searchcustumer(string keyword)
        {
            //Create an object of companysBLL and return it
            custBLL p = new custBLL();
            // companysBLL q = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT * FROM tbl_cust WHERE  name LIKE '%" + keyword + "%'";
                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);


                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to companysBLL
                if (dt.Rows.Count > 0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.mobile = dt.Rows[0]["mobile"].ToString();
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.email = dt.Rows[0]["email"].ToString();
                    p.type = dt.Rows[0]["type"].ToString();
                    p.nquery=int.Parse(dt.Rows[0]["nquery"].ToString());
                    p.cid = int.Parse(dt.Rows[0]["cid"].ToString());


                };
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                 conn.Close();
            }

            return p;
        }
        #endregion
        #region chk costumer if exists
        public bool chkcustumer(string keyword)
        {
            //Create an object of companysBLL and return it
            custBLL p = new custBLL();
            bool sucess = false;
            // companysBLL q = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT id,name,mobile,email,type,nquery FROM tbl_cust WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' OR mobile LIKE '%" + keyword + "%'";
                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);


                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to companysBLL
                if (dt.Rows.Count > 0)
                {
                    sucess = true;

                }
                
     


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return sucess;
        }
        #endregion
        #region method to UPDATE NO OF QUERY
     
            public bool Increasenoofquery(custBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                int id = p.id;
                //SQL Query to insert company into database
                String sql = "UPDATE tbl_cust SET name=@name, email=@email, type=@type, mobile=@mobile, nquery=@nquery, cid=@cid WHERE id=@id";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn); 

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@email", p.email);
                cmd.Parameters.AddWithValue("@mobile", p.mobile);
                cmd.Parameters.AddWithValue("@type", p.type);
                int i = p.nquery;
                i++;
                p.nquery = i;
                cmd.Parameters.AddWithValue("@nquery", p.nquery);
                cmd.Parameters.AddWithValue("@cid", p.cid);

                //Opening the Database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //FAiled to Execute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region Method to iNSERT CUSTUMER
        public bool Insert(custBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {    
                //SQL Query to insert company into database
                String sql = "INSERT INTO tbl_cust ( name, email, mobile, type, nquery, cid) VALUES ( @name, @email, @mobile, @type , @nquery, @cid)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@name", p.name);
                //cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@email", p.email);
                cmd.Parameters.AddWithValue("@mobile", p.mobile);
                cmd.Parameters.AddWithValue("@type", p.type);
                cmd.Parameters.AddWithValue("@nquery", p.nquery);
                cmd.Parameters.AddWithValue("@cid", p.cid);

                //Opening the Database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //FAiled to Execute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        #endregion
    }

}