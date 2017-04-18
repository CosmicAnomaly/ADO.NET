using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class HelpDeskStaffUtil
    {
        private static string connectionStringName = "AltLab2.Properties.Settings.Database1Connect";

        public List<HelpDeskStaff> GetOnDutyHelpDeskStaff(string status)
        {
            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;
            HelpDeskStaff helpDeskStaff = null;
            List<HelpDeskStaff> helpStaff = new List<HelpDeskStaff>();

            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select HelpDeskStaffId, FirstName, LastName, Email, Phone, Status from HelpDeskStaff where Status =@hdsStatus";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                SqlParameter parHelpStaffStatus = new SqlParameter("@hdsStatus", status);
                parHelpStaffStatus.SqlDbType = System.Data.SqlDbType.VarChar;
                cmdRead.Parameters.Add(parHelpStaffStatus);
                rdrReader = cmdRead.ExecuteReader();
                while (rdrReader.Read())
                {
                    helpDeskStaff = new HelpDeskStaff(Convert.ToInt32(rdrReader[0].ToString()), rdrReader[1].ToString(), rdrReader[2].ToString(), rdrReader[3].ToString(), rdrReader[4].ToString(), rdrReader[5].ToString());
                    helpStaff.Add(helpDeskStaff);
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

            return helpStaff;
        }
    }
}
