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
    class companysDAL
    {
        //Creating STATI String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select method for company Module
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DAtaTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select all the companys from database
                String sql = "SELECT * FROM tbl_companys";

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
        #region Method to Insert company in database
        public bool Insert(companysBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert company into database
                String sql = "INSERT INTO tbl_companys (c_name, c_category, c_location, c_mobile, c_email, substart_date, subend_date) VALUES (@c_name, @c_category, @c_location, @c_mobile, @c_email, @substart_date, @subend_date)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@c_name", p.c_name);
                cmd.Parameters.AddWithValue("@c_category", p.c_category);
                cmd.Parameters.AddWithValue("@c_location", p.c_location);
                cmd.Parameters.AddWithValue("@c_mobile", p.c_mobile);
                cmd.Parameters.AddWithValue("@c_email", p.c_email);
                cmd.Parameters.AddWithValue("@substart_date", p.substart_date);
                cmd.Parameters.AddWithValue("@subend_date", p.subend_date);

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
        #region Method to Update company in Database
        public bool Update(companysBLL p)
        {
            //create a boolean variable and set its initial value to false
            bool isSuccess = false;

            //Create SQL Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to Update Data in dAtabase
                String sql = "UPDATE tbl_companys SET c_name=@c_name, c_category=@c_category, c_location=@c_location, c_mobile=@c_mobile, substart_date=@substart_date, subend_date=@subend_date WHERE id=@id";

                //Create SQL Cmmand to pass the value to query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the values using parameters and cmd
                cmd.Parameters.AddWithValue("@c_name", p.c_name);
                cmd.Parameters.AddWithValue("@c_category", p.c_category);
                cmd.Parameters.AddWithValue("@c_location", p.c_location);
                cmd.Parameters.AddWithValue("@c_mobile", p.c_mobile);
                cmd.Parameters.AddWithValue("@c_email", p.c_email);
                cmd.Parameters.AddWithValue("@substart_date", p.substart_date);
                cmd.Parameters.AddWithValue("@subend_date", p.subend_date);
                cmd.Parameters.AddWithValue("@id", p.id);

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
        #region Method to Delete company from Database
        public bool Delete(companysBLL p)
        {
            //Create Boolean Variable and Set its default value to false
            bool isSuccess = false;

            //SQL Connection for DB connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write Query company from DAtabase
                String sql = "DELETE FROM tbl_companys WHERE id=@id";

                //Sql Command to Pass the Value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values using cmd
                cmd.Parameters.AddWithValue("@id", p.id);

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
        #region SEARCH Method for company Module
        public companysBLL Search(string keywords)

        {
            //SQL Connection fro DB Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating DAtaTable to hold value from dAtabase
            companysBLL p = new companysBLL();
            DataTable dt = new DataTable();
            try
            {
                //SQL query to search company
                string sql = "SELECT * FROM tbl_companys WHERE id LIKE '%" + keywords + "%' OR c_name LIKE '%" + keywords + "%' OR c_category LIKE '%" + keywords + "%' OR c_mobile LIKE '%" + keywords + "%'";
                //Sql Command to execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();
                adapter.Fill(dt);

                p.c_name = dt.Rows[0]["c_name"].ToString();
                p.c_mobile = dt.Rows[0]["c_mobile"].ToString();
                p.id = int.Parse(dt.Rows[0]["id"].ToString());
                p.c_email = dt.Rows[0]["c_email"].ToString();
                p.c_category = dt.Rows[0]["c_category"].ToString();
                p.c_location = (dt.Rows[0]["c_location"].ToString());
                p.id = int.Parse(dt.Rows[0]["id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return p;
        }
        #endregion
        #region SEARCH Method for company based on id
        public companysBLL Searchfromid(int keywords)

        {
            //SQL Connection fro DB Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating DAtaTable to hold value from dAtabase
            companysBLL p = new companysBLL();
            DataTable dt = new DataTable();
            try
            {
                //SQL query to search company
                string sql = "SELECT * FROM tbl_companys WHERE id LIKE '%" + keywords + "%' ";
                //Sql Command to execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                //Open Database Connection
                conn.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.c_name = dt.Rows[0]["c_name"].ToString();
                    p.c_mobile = dt.Rows[0]["c_mobile"].ToString();
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.c_email = dt.Rows[0]["c_email"].ToString();
                    p.c_category = dt.Rows[0]["c_category"].ToString();
                    p.c_location = (dt.Rows[0]["c_location"].ToString());
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return p;
        }
        #endregion
        #region METHOD TO SEARCH company IN TRANSACTION MODULE
        public companysBLL GetcompanysForTransaction(string keyword)
        {
            //Create an object of companysBLL and return it
            companysBLL p = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT id FROM tbl_companys WHERE c_name LIKE '%" + keyword + "%' OR c_mobile LIKE '%" + keyword + "%'";
                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to companysBLL
                if (dt.Rows.Count > 0)
                {

                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return p;
        }
        #endregion
        #region METHOD TO GET company ID BASED ON company c_name
        public companysBLL GetcompanyIDFromc_name(int c_id)
        {
            //First Create an Object of DeaCust BLL and REturn it
            companysBLL p = new companysBLL();

            //SQL Conection here
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Data TAble to Holdthe data temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Get id based on c_name
                string sql = "SELECT id FROM tbl_companys WHERE id='" + c_id + "'";
                //Create the SQL Data Adapter to Execute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //Passing the CAlue from Adapter to DAtatable
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Pass the value from dt to DeaCustBLL dc
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return p;
        }
        #endregion
        #region METHOD TO GET CURRENT QUantity from the Database based on company ID
        public decimal Getcompanyc_email(int companyID)
        {
            //SQl Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Create a Decimal Variable and set its default value to 0
            decimal c_email = 0;

            //Create Data Table to save the data from database temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write WQL Query to Get Quantity from Database
                string sql = "SELECT c_email FROM tbl_companys WHERE id = " + companyID;

                //Cec_mobile A SqlCommand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create a SQL Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open DAtabase Connection
                conn.Open();

                //PAss the calue from Data Adapter to DataTable
                adapter.Fill(dt);

                //Lets check if the datatable has value or not
                if (dt.Rows.Count > 0)
                {
                    c_email = decimal.Parse(dt.Rows[0]["c_email"].ToString());
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

            return c_email;
        }
        #endregion
        #region METHOD TO UPDATE QUANTITY
        public bool UpdateQuantity(int companyID, decimal c_email)
        {
            //Create a Boolean Variable and Set its value to false
            bool success = false;

            //SQl Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write the SQL Query to Update c_email
                string sql = "UPDATE tbl_companys SET c_email=@c_email WHERE id=@id";

                //Create SQL Command to Pass the calue into Queyr
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the VAlue trhough parameters
                cmd.Parameters.AddWithValue("@c_email", c_email);
                cmd.Parameters.AddWithValue("@id", companyID);

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
        #region METHOD TO INCREASE company
        public bool Increasecompany(int companyID, decimal Increasec_email)
        {
            //Create a Boolean Variable and SEt its value to False
            bool success = false;

            //Create SQL Connection To Connect DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Get the Current c_email From dAtabase based on id
                decimal currentc_email = Getcompanyc_email(companyID);

                //Increase the Current Quantity by the c_email purchased from Dealer
                decimal Newc_email = currentc_email + Increasec_email;

                //Update the Prudcty Quantity Now
                success = UpdateQuantity(companyID, Newc_email);
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
        #region METHOD TO DECREASE company
        public bool Decreasecompany(int companyID, decimal c_email)
        {
            //Create Boolean Variable and SEt its Value to false
            bool success = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Get the Current company Quantity
                decimal currentc_email = Getcompanyc_email(companyID);

                //Decrease the company Quantity based on company sales
                decimal Newc_email = currentc_email - c_email;

                //Update company in Database
                success = UpdateQuantity(companyID, Newc_email);
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
        #region DESPLAY companyS BASED ON CATEGORIES
        public DataTable DisplaycompanysByc_category(string c_category)
        {
            //Sql Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Display company Based on c_category
                string sql = "SELECT * FROM tbl_companys WHERE c_category='" + c_category + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection Here
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
        #region method to chk if company exist
        public bool chkcompanybyname(string keyword)
        {
            bool sucess=false;
            //Create an object of companysBLL and return it
            companysBLL p = new companysBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT c_name, c_mobile, c_email FROM tbl_companys WHERE c_name LIKE '%" + keyword + "%' OR c_mobile LIKE '%" + keyword + "%'";
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
        #region DESPLAY companyS  all
        public DataTable Displaycompanys()
        {
            //Sql Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Display company Based on c_category
                string sql = "SELECT * FROM tbl_companys ";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection Here
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
