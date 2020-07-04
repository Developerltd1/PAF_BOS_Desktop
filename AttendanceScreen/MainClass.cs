using System;
using System.Data.SqlClient;
using System.Data;

namespace AttendanceScreen
{
    public class MainClass
    {
        
        public static class MngPAFBOS
        {
         

            public static DataTable GetCadetsByCardNumber(string CardNumber)
            {

                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT * FROM Cadets WHERE RFIDCardNumber=@CardNumber", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@CardNumber", CardNumber); 

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
            public static DataTable GetCadets()
            {
              
                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT CadetID,LFMD,RFMD FROM Cadets", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);  

                     
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
            public static DataTable GetCadetsByCadetID(int CadetID)
            {
                
                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT * FROM Cadets WHERE CadetID=@CadetID", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@CadetID", CadetID); 

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
            public static void CreateAttendance(int Cadet_ID, out string SessionInformation, out string AttendanceType, out bool Status, out string StatusDetails)
            {
                SessionInformation = null;
                AttendanceType = null;
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CreateAttendanceUpdated", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cadet_ID", Cadet_ID);

                    SqlParameter SessionInformationParm = new SqlParameter("@SessionInformation", SqlDbType.VarChar, 50);
                    SessionInformationParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SessionInformationParm);

                    SqlParameter AttendanceTypeParm = new SqlParameter("@AttendanceType", SqlDbType.VarChar, 20);
                    AttendanceTypeParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(AttendanceTypeParm);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    SessionInformation = (string)SessionInformationParm.Value;
                    AttendanceType = (string)AttendanceTypeParm.Value;
                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                { 
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable CheckPunishments(int CadetID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("CheckPunsihment", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@CadetID", CadetID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

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
}
