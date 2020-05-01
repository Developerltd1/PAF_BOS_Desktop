using System; 
using System.Data;
using System.Data.SqlClient; 

namespace PAF_BOS
{
    class ReportClass
    {  
        public static DataTable GetClientsDetailsReport(int ClientID)
        {

            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetClientsDetailsReport", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@ClientID", ClientID);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();


                return dt;
            }
            catch (Exception )
            {

                //Return Value
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public static DataTable GetClientUsersAttendanceByClientIDReport(int ClientID, DateTime FromDate, DateTime ToDate)
        {


            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetClientUsersAttendanceByClientIDReport", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@ClientID", ClientID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();


                return dt;
            }
            catch (Exception ex)
            {

                //Return Value
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public static DataTable GetUserAttendanceReport(int UserID, DateTime FromDate, DateTime ToDate)
        {


            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetUserAttendanceReport", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();


                return dt;
            }
            catch (Exception ex)
            {

                //Return Value
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public static DataTable GetUserDetailsByClientIDReport(int ClientID)
        {


            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetUserDetailsByClientIDReport", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@ClientID", ClientID);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();


                return dt;
            }
            catch (Exception ex)
            {

                //Return Value
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        } 
    }
}
