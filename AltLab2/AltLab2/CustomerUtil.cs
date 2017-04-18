using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class CustomerUtil
    {
        private static string connectionStringName = "AltLab2.Properties.Settings.Database1Connect";

        public List<Customer> GetAllCustomers()
        {

            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;

            List<Customer> customers = new List<Customer>();
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select CustomerId, FirstName, LastName, Department, Email, Phone, RoomNumber from Customer";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                rdrReader = cmdRead.ExecuteReader();
                while (rdrReader.Read())
                {
                    customers.Add(new Customer( Convert.ToInt32(rdrReader[0].ToString() ), rdrReader[1].ToString(), rdrReader[2].ToString(), rdrReader[3].ToString(), rdrReader[4].ToString(), rdrReader[5].ToString(), ( Convert.ToInt32(rdrReader[6].ToString() ) )));
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;
            Customer customer = null;

            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select CustomerId, FirstName, LastName, Department, Email, Phone, RoomNumber from Customer where CustomerId =@custId";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                SqlParameter parHelpStaffStatus = new SqlParameter("@custId", id);
                parHelpStaffStatus.SqlDbType = System.Data.SqlDbType.VarChar;
                cmdRead.Parameters.Add(parHelpStaffStatus);
                rdrReader = cmdRead.ExecuteReader();
                while (rdrReader.Read())
                {
                    customer = (new Customer(Convert.ToInt32(rdrReader[0].ToString()), rdrReader[1].ToString(), rdrReader[2].ToString(), rdrReader[3].ToString(), rdrReader[4].ToString(), rdrReader[5].ToString(), (Convert.ToInt32(rdrReader[6].ToString()))));
                }

            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return customer;
        }

        public Customer InsertCustomer(Customer customer)
        {
            SqlCommand cmdInsert;
            String strSql;
            SqlConnection conn = null;
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "insert into Customer(FirstName, LastName, Department, Email, Phone, RoomNumber) values(@FirstName, @LastName, @Department, @Email, @Phone, @RoomNumber); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                SqlParameter parFirstName = new SqlParameter("@FirstName", customer.firstName);
                parFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parLastName = new SqlParameter("@LastName", customer.lastName);
                parLastName.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parDepartment = new SqlParameter("@Department", customer.department);
                parDepartment.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parEmail = new SqlParameter("@Email", customer.email);
                parEmail.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parPhone = new SqlParameter("@Phone", customer.phone);
                parPhone.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parRoomNumber = new SqlParameter("@RoomNumber", customer.roomNumber);
                parRoomNumber.SqlDbType = System.Data.SqlDbType.Int;
                conn.Open();
                cmdInsert = new SqlCommand(strSql, conn);
                cmdInsert.Parameters.Add(parFirstName);
                cmdInsert.Parameters.Add(parLastName);
                cmdInsert.Parameters.Add(parDepartment);
                cmdInsert.Parameters.Add(parEmail);
                cmdInsert.Parameters.Add(parPhone);
                cmdInsert.Parameters.Add(parRoomNumber);
                customer.CustomerId = (int)cmdInsert.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return customer;
        }

    }
}
