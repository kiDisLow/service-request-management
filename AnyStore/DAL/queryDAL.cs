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
    class queryDAL
    {

        //Creating STATI String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        #region Select method for query 
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DAtaTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select all the companys from database
                String sql = "SELECT * FROM tbl_query";

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
        #region Method to Insert query in database
        public bool Insert(queryBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert company into database
                String sql = "INSERT INTO tbl_query ( c_id, cu_id, u_name,u_mobile,ques,soln,status,datetime) VALUES ( @c_id, @cu_id, @u_name, @u_mobile, @ques, @soln,@status,datetime)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@c_id", p.c_id);
                cmd.Parameters.AddWithValue("@cu_id", p.cu_id);
                cmd.Parameters.AddWithValue("@u_name", p.u_name);
                cmd.Parameters.AddWithValue("@u_mobile", p.u_mobile);
                cmd.Parameters.AddWithValue("@ques", p.ques);
                cmd.Parameters.AddWithValue("@soln", p.soln);
                cmd.Parameters.AddWithValue("@status", p.status);
                cmd.Parameters.AddWithValue("@datetime", p.datetime);


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
        #region Method to Update query in Database
        public bool Update(queryBLL p)
        {
            //create a boolean variable and set its initial value to false
            bool isSuccess = false;

            //Create SQL Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to Update Data in dAtabase
                String sql = "UPDATE tbl_companys SET q_id=@q_id, c_id=@c_id, cu_id=@cu_id, u_name=@u_name, ques=@ques, soln=@soln WHERE q_id=@q_id";

                //Create SQL Cmmand to pass the value to query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the values using parameters and cmd
                cmd.Parameters.AddWithValue("@q_id", p.q_id);
                cmd.Parameters.AddWithValue("@c_id", p.c_id);
                cmd.Parameters.AddWithValue("@cu_id", p.cu_id);
                cmd.Parameters.AddWithValue("@u_name", p.u_name);
                cmd.Parameters.AddWithValue("@u_mobile", p.u_mobile);
                cmd.Parameters.AddWithValue("@ques", p.ques);
                cmd.Parameters.AddWithValue("@soln", p.soln);

                //Open the Database connection
                conn.Open();

                //Create Int Variable to check if the query is executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                //if the query is executed successfully then the value of rows will be greater than 0 else it will be less than zero
                if (rows > 0)
                {
                    //Query ExecutedSuccessfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
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
        #region Method to Delete query from Database
        public bool Delete(queryBLL p)
        {
            //Create Boolean Variable and Set its default value to false
            bool isSuccess = false;

            //SQL Connection for DB connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write Query company from DAtabase
                String sql = "DELETE FROM tbl_companys WHERE q_id=@q_id";

                //Sql Command to Pass the Value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values using cmd
                cmd.Parameters.AddWithValue("@q_id", p.q_id);

                //Open Database Connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //If the query is executed successfullly then the value of rows will be greated than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
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
        #region SEARCH Method for query search Module
        public DataTable Search(string keywords)
        {
            //SQL Connection fro DB Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating DAtaTable to hold value from dAtabase
            DataTable dt = new DataTable();

            try
            {
                //SQL query to search company
                string sql = "SELECT * FROM tbl_query WHERE q_id LIKE '%" + keywords + "%' OR u_name LIKE '%" + keywords + "%' OR u_mobile LIKE '%" + keywords + "%'";
                //Sql Command to execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
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
        #region METHOD TO SEARCH QUERY AND GET QID IN TRANSACTION MODULE
        public queryBLL updatestatusandreturn(string uname,string ques,string soln,string umobile  )
        {
            //Create an object of companysBLL and return it
            queryBLL p = new queryBLL();  
           // companysBLL q = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();
            bool sucess = true;

            try
            {
                //Write the Query to Get the detaisl
                string sql = "UPDATE tbl_query SET status = 1  WHERE u_name LIKE '%" + uname + "%' AND ques LIKE '%" + ques + "%' AND u_mobile LIKE '%" + umobile + "%' AND soln Like '%" + soln + "%'";

                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                sql = " SELECT * FROM tbl_query WHERE u_name LIKE '%" + uname + "%' AND ques LIKE '%" + ques + "%' AND u_mobile LIKE '%" + umobile + "%' AND soln '%" + soln + "%'";
                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to companysBLL
                if (dt.Rows.Count > 0)
                {
                    p.u_name = dt.Rows[0]["u_name"].ToString();
                    p.u_mobile = dt.Rows[0]["u_mobile"].ToString();
                    p.c_id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.soln = dt.Rows[0]["soln"].ToString();
                    p.ques = dt.Rows[0]["ques"].ToString();
                    p.cu_id = int.Parse(dt.Rows[0]["cu_id"].ToString());
                    p.status = int.Parse(dt.Rows[0]["status"].ToString());
                };
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sucess = false;
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return p;
        }
        #endregion        
        #region METHOD TO UPDATE the soln 
        public bool Updatesoln(int q_id, string soln)
        {
            //Create a Boolean Variable and Set its value to false
            bool success = false;

            //SQl Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write the SQL Query to Update c_email
                string sql = "UPDATE tbl_query SET soln=@soln WHERE q_id =" + q_id;

                //Create SQL Command to Pass the calue into Queyr
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the VAlue trhough parameters
                cmd.Parameters.AddWithValue("@soln", soln);
                

                //Open Database Connection
                conn.Open();

                //Create Int Variable and Check whether the query is executed Successfully or not
                int rows = cmd.ExecuteNonQuery();
                //Lets check if the query is executed Successfully or not
                if (rows > 0)
                {
                    //Query Executed Successfully
                    success = true;
                }
                else
                {
                    //Failed to Execute Query
                    success = false;
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

            return success;
        }
        #endregion     
        #region METHOD TO SEARCH QUERY AND GET QID 
        public queryBLL Getqueryforsearch(queryBLL q)
        {
            //Create an object of companysBLL and return it
            queryBLL p = new queryBLL();
            // companysBLL q = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT q_id, c_id, cu_id,u_name,u_mobile FROM tbl_query WHERE c_id LIKE '%" + q.c_id + "%' OR u_name LIKE '%" + q.u_name + "%' OR u_mobile LIKE '%" + q.u_mobile+ "%' OR  ques LIKE '%" + q.ques + "%'";
                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);


                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to companysBLL
                if (dt.Rows.Count > 0)
                {
                    p.u_name = dt.Rows[0]["u_name"].ToString();
                    p.u_mobile = dt.Rows[0]["u_mobile"].ToString();
                    p.c_id = int.Parse(dt.Rows[0]["c_id"].ToString());
                    p.q_id = int.Parse(dt.Rows[0]["q_id"].ToString());
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
        #region METHOD TO SEARCH QUERY and get soln
        public DataTable Getsoln(string keyword)
        {
            //Create an object of companysBLL and return it
            queryBLL p = new queryBLL();
            // companysBLL q = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT ques,soln FROM tbl_query WHERE ques LIKE '%" + keyword + "%'";
                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);


                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to companysBLL
                
             
            
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

            return dt;
        }
        #endregion
        #region Select pending  method for query 
        public DataTable Select(int i)
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DAtaTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select all the companys from database
                String sql = "SELECT q_id,u_name,u_mobile,ques,soln FROM tbl_query WHERE status = " + i + "";

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
        #region method to update status of a query
        public bool Updatestatus(queryBLL p)
        {
            //create a boolean variable and set its initial value to false
            bool isSuccess = false;

            //Create SQL Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to Update Data in dAtabase
                String sql = "UPDATE tbl_companys SET status ="+1+" WHERE q_id=@q_id";

                //Create SQL Cmmand to pass the value to query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the values using parameters and cmd
                cmd.Parameters.AddWithValue("@status",1);
                

                //Open the Database connection
                conn.Open();

                //Create Int Variable to check if the query is executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                //if the query is executed successfully then the value of rows will be greater than 0 else it will be less than zero
                if (rows > 0)
                {
                    //Query ExecutedSuccessfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
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
        #region select for monthly report

        public DataTable Select(DateTime enddate,DateTime startdate,string user, string company)
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DAtaTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select all the companys from database
                String sql = "SELECT q_id,u_name,u_mobile,ques,soln FROM tbl_query WHERE  datetime >=" +startdate+ "AND datetime <=" +enddate+ "AND u_name LIKE" +user ;

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
        #region select for monthly reprt user and company

        public DataTable Select( string user, string company)
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);
            companysBLL qb = new companysBLL();
            companysDAL qd = new companysDAL();
            qb= qd.Search(company);
            //DAtaTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select all the companys from database
                String sql = "SELECT q_id,u_name,u_mobile,ques,soln FROM tbl_query WHERE c_id =" + qb.id + "AND  u_name LIKE '%" + user + "%'";

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
    }
}
