using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class TicketUtil
    {
        private static string connectionStringName = "AltLab2.Properties.Settings.Database1Connect";

        public List<Ticket> GetAllTickets()
        {

            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;

            List<Ticket> tickets = new List<Ticket>();
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select TicketId, Status, HelpDeskStaffId, ProblemDesc, ISNULL(Resolution,''), ISNULL(FollowUpRequired,''), ISNULL(FollowUpComplete,''), TicketDate, ISNULL(ResolvedDate,'') , CustomerId from Ticket";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                rdrReader = cmdRead.ExecuteReader();

                while (rdrReader.Read())
                {
                    tickets.Add(new Ticket(
                        (Convert.ToInt32(rdrReader[0].ToString())),
                        rdrReader[1].ToString(),
                        (Convert.ToInt32(rdrReader[9].ToString())),
                        (Convert.ToInt32(rdrReader[2].ToString())),
                        rdrReader[3].ToString(),
                        rdrReader[4].ToString(),
                        rdrReader[5].ToString(),
                        rdrReader[6].ToString(),
                        (Convert.ToDateTime(rdrReader[7])),
                        (Convert.ToDateTime(rdrReader[8]))));
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
            return tickets;
        }

        public List<Ticket> GetTicketsByStatus(string status)
        {
            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;
            Ticket ticketStatus = null;
            List<Ticket> ticketStatuses = new List<Ticket>();

            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select TicketId, Status, HelpDeskStaffId, ProblemDesc, ISNULL(Resolution,''), ISNULL(FollowUpRequired,''), ISNULL(FollowUpComplete,''), TicketDate, ISNULL(ResolvedDate,'') , CustomerId from Ticket where Status =@hdsStatus";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                SqlParameter parHelpStaffStatus = new SqlParameter("@hdsStatus", status);
                parHelpStaffStatus.SqlDbType = System.Data.SqlDbType.VarChar;
                cmdRead.Parameters.Add(parHelpStaffStatus);
                rdrReader = cmdRead.ExecuteReader();
                while (rdrReader.Read())
                {
                    ticketStatus = new Ticket(
                        (Convert.ToInt32(rdrReader[0].ToString())),
                        rdrReader[1].ToString(),
                        (Convert.ToInt32(rdrReader[9].ToString())),
                        (Convert.ToInt32(rdrReader[2].ToString())),
                        rdrReader[3].ToString(),
                        rdrReader[4].ToString(),
                        rdrReader[5].ToString(),
                        rdrReader[6].ToString(),
                        (Convert.ToDateTime(rdrReader[7])),
                        (Convert.ToDateTime(rdrReader[8])));               
                        ticketStatuses.Add(ticketStatus);

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

            return ticketStatuses;
        }

        public Ticket GetTicket(int id)
        {
            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;
            Ticket ticket = null;

            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select TicketId, Status, HelpDeskStaffId, ProblemDesc, ISNULL(Resolution,''), ISNULL(FollowUpRequired,''), ISNULL(FollowUpComplete,''), TicketDate, ISNULL(ResolvedDate,'') , CustomerId from Ticket where TicketId =@tickId";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                SqlParameter parTickId = new SqlParameter("@tickId", id);
                parTickId.SqlDbType = System.Data.SqlDbType.VarChar;
                cmdRead.Parameters.Add(parTickId);
                rdrReader = cmdRead.ExecuteReader();
                while (rdrReader.Read())
                {
                    ticket = (new Ticket(
                        (Convert.ToInt32(rdrReader[0].ToString())),
                        rdrReader[1].ToString(),
                        (Convert.ToInt32(rdrReader[9].ToString())),
                        (Convert.ToInt32(rdrReader[2].ToString())),
                        rdrReader[3].ToString(),
                        rdrReader[4].ToString(),
                        rdrReader[5].ToString(),
                        rdrReader[6].ToString(),
                        (Convert.ToDateTime(rdrReader[7])),
                        (Convert.ToDateTime(rdrReader[8]))));
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

            return ticket;
        }

        public Ticket UpdateTicket(int id, string status, int customerId, int helpDeskStaffId, string problemDesc, string resolution, string followUpRequired, string followUpComplete, DateTime ticketDate, DateTime resolvedDate)
        {
            Ticket ticket = new Ticket(id, status, customerId, helpDeskStaffId, problemDesc, resolution, followUpRequired, followUpComplete, ticketDate, resolvedDate);
            SqlCommand cmdInsert;
            SqlConnection conn = null;
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                string sql2 = "UPDATE Ticket SET Status = @Status, HelpDeskStaffId = @HelpDeskStaffId, ProblemDesc = @ProblemDesc, Resolution = @Resolution, FollowUpRequired = @FollowUpRequired, FollowUpComplete = @FollowUpComplete, TicketDate = @TicketDate, ResolvedDate = @ResolvedDate, CustomerId = @CustomerId WHERE TicketId=@id";
                conn.Open();
                cmdInsert = new SqlCommand(sql2, conn);
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.Parameters.AddWithValue("@Status", status);
                cmdInsert.Parameters.AddWithValue("@HelpDeskStaffId", helpDeskStaffId);
                cmdInsert.Parameters.AddWithValue("@ProblemDesc", problemDesc);
                cmdInsert.Parameters.AddWithValue("@Resolution", resolution);
                cmdInsert.Parameters.AddWithValue("@FollowUpRequired", followUpRequired);
                cmdInsert.Parameters.AddWithValue("@FollowUpComplete", followUpComplete);
                cmdInsert.Parameters.AddWithValue("@TicketDate", ticketDate);
                cmdInsert.Parameters.AddWithValue("@ResolvedDate", resolvedDate);
                cmdInsert.Parameters.AddWithValue("@CustomerId", customerId);
                cmdInsert.ExecuteNonQuery();

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
            return ticket;
        }

        public Ticket InsertTicket(Ticket ticket)
        {
            SqlCommand cmdInsert;
            String strSql;
            SqlConnection conn = null;
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "insert into Ticket(Status, HelpDeskStaffId, ProblemDesc, Resolution, FollowUpRequired, FollowUpComplete, TicketDate, ResolvedDate, CustomerId) values(@Status, @HelpDeskStaffId, @ProblemDesc, @Resolution, @FollowUpRequired, @FollowUpComplete, @TicketDate, @ResolvedDate, @CustomerId); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                SqlParameter parStatus = new SqlParameter("@Status", ticket.status);
                parStatus.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parHelpDeskStaffId = new SqlParameter("@HelpDeskStaffId", ticket.helpDeskStaffId);
                parHelpDeskStaffId.SqlDbType = System.Data.SqlDbType.Int;
                SqlParameter parProblemDesc = new SqlParameter("@ProblemDesc", ticket.problemDesc);
                parProblemDesc.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parResolution = new SqlParameter("@Resolution", ticket.resolution);
                parResolution.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parFollowUpRequired = new SqlParameter("@FollowUpRequired", ticket.followUpRequired);
                parFollowUpRequired.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parFollowUpComplete = new SqlParameter("@FollowUpComplete", ticket.followUpComplete);
                parFollowUpComplete.SqlDbType = System.Data.SqlDbType.VarChar;
                SqlParameter parTicketDate = new SqlParameter("@TicketDate", ticket.ticketDate);
                parTicketDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SqlParameter parResolvedDate = new SqlParameter("@ResolvedDate", ticket.resolvedDate);
                parResolvedDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SqlParameter parCustomerId = new SqlParameter("@CustomerId", ticket.customerId);
                parCustomerId.SqlDbType = System.Data.SqlDbType.Int;
                conn.Open();
                cmdInsert = new SqlCommand(strSql, conn);
                cmdInsert.Parameters.Add(parStatus);
                cmdInsert.Parameters.Add(parHelpDeskStaffId);
                cmdInsert.Parameters.Add(parProblemDesc);
                cmdInsert.Parameters.Add(parResolution);
                cmdInsert.Parameters.Add(parFollowUpRequired);
                cmdInsert.Parameters.Add(parFollowUpComplete);
                cmdInsert.Parameters.Add(parTicketDate);
                cmdInsert.Parameters.Add(parResolvedDate);
                cmdInsert.Parameters.Add(parCustomerId);
                ticket.ticketId = (int)cmdInsert.ExecuteScalar();
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
            return ticket;
        }

        public Ticket ReAssignTicket(int id, int helpDeskStaffId)
        {
            Ticket ticket = new Ticket(id, helpDeskStaffId);
            SqlCommand cmdInsert;
            SqlConnection conn = null;
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                string sql2 = "UPDATE Ticket SET HelpDeskStaffId = @HelpDeskStaffId WHERE TicketId=@id";
                conn.Open();
                cmdInsert = new SqlCommand(sql2, conn);
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.Parameters.AddWithValue("@HelpDeskStaffId", helpDeskStaffId);
                cmdInsert.ExecuteNonQuery();

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
            return ticket;
        }

        public Ticket StaffUpdateTicket(int id, string status, string resolution, string followUpRequired, string followUpComplete, DateTime resolvedDate)
        {
            Ticket ticket = new Ticket(status, resolution, followUpRequired, followUpComplete, resolvedDate);
            SqlCommand cmdInsert;
            SqlConnection conn = null;
            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                string sql2 = "UPDATE Ticket SET Status = @Status, Resolution = @Resolution, FollowUpRequired = @FollowUpRequired, FollowUpComplete = @FollowUpComplete, ResolvedDate = @ResolvedDate WHERE TicketId=@id";
                conn.Open();
                cmdInsert = new SqlCommand(sql2, conn);
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.Parameters.AddWithValue("@Status", status);
                cmdInsert.Parameters.AddWithValue("@Resolution", resolution);
                cmdInsert.Parameters.AddWithValue("@FollowUpRequired", followUpRequired);
                cmdInsert.Parameters.AddWithValue("@FollowUpComplete", followUpComplete);
                cmdInsert.Parameters.AddWithValue("@ResolvedDate", resolvedDate);
                cmdInsert.ExecuteNonQuery();

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
            return ticket;
        }

        public List<Ticket> GetTicketsByStaffId(int id)
        {
            SqlCommand cmdRead;
            SqlDataReader rdrReader;
            String strSql;
            SqlConnection conn = null;
            Ticket ticketStatus = null;
            List<Ticket> ticketStatuses = new List<Ticket>();

            try
            {
                string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                conn = new SqlConnection(connectString);
                strSql = "select TicketId, Status, HelpDeskStaffId, ProblemDesc, ISNULL(Resolution,''), ISNULL(FollowUpRequired,''), ISNULL(FollowUpComplete,''), TicketDate, ISNULL(ResolvedDate,'') , CustomerId from Ticket where HelpDeskStaffId =@hdsId";
                conn.Open();
                cmdRead = new SqlCommand(strSql, conn);
                SqlParameter parHelpStaffStatus = new SqlParameter("@hdsId", id);
                parHelpStaffStatus.SqlDbType = System.Data.SqlDbType.VarChar;
                cmdRead.Parameters.Add(parHelpStaffStatus);
                rdrReader = cmdRead.ExecuteReader();
                while (rdrReader.Read())
                {
                    ticketStatus = new Ticket(
                        (Convert.ToInt32(rdrReader[0].ToString())),
                        rdrReader[1].ToString(),
                        (Convert.ToInt32(rdrReader[9].ToString())),
                        (Convert.ToInt32(rdrReader[2].ToString())),
                        rdrReader[3].ToString(),
                        rdrReader[4].ToString(),
                        rdrReader[5].ToString(),
                        rdrReader[6].ToString(),
                        (Convert.ToDateTime(rdrReader[7])),
                        (Convert.ToDateTime(rdrReader[8])));
                    ticketStatuses.Add(ticketStatus);

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

            return ticketStatuses;
        }
    }
}
