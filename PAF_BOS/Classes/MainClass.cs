﻿using System;
using System.Data.SqlClient;
using System.Data;
using AQDBFramwork.Messageboxes;

namespace PAF_BOS
{
    class MainClass
    {
        public static bool IsLoginPageOpen { get; set; }
        public static int UserID { get; set; }
        public static int RoleID { get; set; }
        public static string UserName { get; set; }
        public static string CheckRole { get; set; }  
 
        public static DataTable GetCadetsByTapeAndCourseIDandSQN(int AllowedForUser,int CourseID, int TapeID, int SqnID, out bool Status, out string StatusDetails)
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
                cmd = new SqlCommand("usp_GetCadetsByTapeAndCourseID", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@AllowedForUser", AllowedForUser);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@TapeID", TapeID);
                cmd.Parameters.AddWithValue("@SQNID", SqnID);

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
        public static DataTable GetCadetDataByUserID(int UserID, out bool Status, out string StatusDetails)
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
                cmd = new SqlCommand("usp_GetCadetDataForAttendanceSession", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@UserID", UserID);

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
        public static DataTable GetSessionByOutDate(DateTime OutDate)
        {  
            // DataTable Declaration
            DataTable dt = new DataTable();
            DateTime TOOutDate = DateTime.Parse(string.Format("{0} 11:59:59 PM", OutDate.ToString("dd-MMM-yyyy")));

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("usp_GetCreatedSessionByCheckOUTDate", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@AllowedCheckOUTDateTime", OutDate);
                cmd.Parameters.AddWithValue("@TOAllowedCheckOUTDateTime", TOOutDate); 

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
 

                return dt;
            }
            catch (Exception ex)
            { 
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
         
 
        public static class MngPAFBOS
        {
            #region MODELS
            #region LoginUsers Class
            public class MdlLoginUsers
            {
                public int UserID { get; set; }
                public int SeniorOfficer_User_ID { get; set; }
                public DateTime EntryDateTime { get; set; }
                public bool IsActive { get; set; }
                public string FullName { get; set; }
                public string Designation { get; set; }
                public string PAKNumber { get; set; }
                public string UserName { get; set; }
                public string UserPassword { get; set; }
            }

            #endregion
            #endregion  //MODELS END

            #region OPERATIONS

            public static DataSet GetMainDashBoardData(out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataSet Declaration
                DataSet ds = new DataSet();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetMainDashBoardData", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(ds);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return ds;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return ds;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static void UpdatePunishments_with_InsertPunishmentsHistory(int PunishmentID, int Cadet_ID, int Category_ID, string Remarks, bool IsSpecialWaiver, bool IsPunishCompleted, int USER_ID, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_UpdatePunishments_with_InsertPunishmentsHistory", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PunishmentID", PunishmentID);
                    cmd.Parameters.AddWithValue("@Cadet_ID", Cadet_ID);
                    cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                    cmd.Parameters.AddWithValue("@Remarks", Remarks);
                    cmd.Parameters.AddWithValue("@IsSpecialWaiver", IsSpecialWaiver);
                    cmd.Parameters.AddWithValue("@IsPunishCompleted", IsPunishCompleted);
                    cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static void InsertRolesPermission(int Form_ID, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertRolesPermission", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static DataTable GetAssignFormsPermissionToUser(int UesrID, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetAssignFormsPermissionToUser", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@UesrID", UesrID);

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
            public static DataTable AuthenticateUser(string Role, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_AuthenticateUser", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Role", Role);

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
            public static void InsertAttendanceSessions(DateTime AllowedCheckOUTDateTime, DateTime AllowedCheckINDateTime, int Cadet_ID, int User_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertAttendanceSessions", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AllowedCheckOUTDateTime", AllowedCheckOUTDateTime);
                    cmd.Parameters.AddWithValue("@AllowedCheckINDateTime", AllowedCheckINDateTime); 
                    cmd.Parameters.AddWithValue("@Cadet_ID", Cadet_ID);
                    cmd.Parameters.AddWithValue("@User_ID", User_ID); 

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static void AddCadetPermission(int UserID, int CadetID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_AddCadetPermission", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@CadetID", CadetID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static void RemoveCadetPermission(int UserID, int CadetID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_RemoveCadetPermission", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@CadetID", CadetID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static void InsertPunishments_with_PunishmentsHistory(int Cadet_ID, int Category_ID, string Remarks, bool IsSpecialWaiver, bool IsPunishCompleted, int User_ID, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertPunishments_with_PunishmentsHistory", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cadet_ID", Cadet_ID);
                    cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                    cmd.Parameters.AddWithValue("@Remarks", Remarks);
                    cmd.Parameters.AddWithValue("@IsSpecialWaiver", IsSpecialWaiver);
                    cmd.Parameters.AddWithValue("@IsPunishCompleted", IsPunishCompleted);
                    cmd.Parameters.AddWithValue("@User_ID", User_ID);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static DataTable GetPunishments(string PakNo, string RFIDCardNumber, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetPunishments", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@PakNo", PakNo);
                    cmd.Parameters.AddWithValue("@RFIDCardNumber", RFIDCardNumber);

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
            public static DataTable GetCadetsPunishmentInformation(string PAKNumber, string RFIDCardNumber, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetCadetsPunishmentInformation", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@PAKNumber", PAKNumber);
                    cmd.Parameters.AddWithValue("@RFIDCardNumber", RFIDCardNumber);

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
            public static DataTable GetPunishmentCategories(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetPunishmentCategories", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable GetCadetRoles(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetCadetRoles", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static void RemoveRolesPermission(int Form_ID, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_RemoveRolesPermission", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static DataTable GetAssignForms(int RoleID, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetAssignForms", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@RoleID", RoleID);

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
            public static DataTable GetForms(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetForms", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable GetRoles( out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetLoginRoles", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 250);
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
            public static DataTable usp_GetSeniorOfficerByUserID(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetSeniorOfficerByUserID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable GetSeniorOfficerByFullName(int UserID, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetSeniorOfficerByFullName", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@UserID", UserID);

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
            public static DataTable GetCadetSQN(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetCadetSQN", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable GetCadetCourses(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetCadetCourses", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable GetCadetTapes(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetCadetTapes", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable GetPakNo_AND_RFIDNo_EXIST(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetPakNo_AND_RFIDNo_EXIST", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static void InsertCadetFromExcel_with_CadetHistory(string CadetName, string CadetFatherName, string PAKNumber, string Address, string CNIC, string BloodGroup, string ContactNumber, string MobileNumber, string RFIDCardNumber, int SQN_User_ID, int Course_ID, int Tape_ID, int CreatedBy_User_ID, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertCadetFromExcel_with_CadetHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CadetName", CadetName);
                    cmd.Parameters.AddWithValue("@CadetFatherName", CadetFatherName);
                    cmd.Parameters.AddWithValue("@PAKNumber", PAKNumber);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@CNIC", CNIC);
                    cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
                    cmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    cmd.Parameters.AddWithValue("@RFIDCardNumber", RFIDCardNumber);
                    cmd.Parameters.AddWithValue("@SQN_User_ID", SQN_User_ID);
                    cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
                    cmd.Parameters.AddWithValue("@Tape_ID", Tape_ID);
                    cmd.Parameters.AddWithValue("@CreatedBy_User_ID", CreatedBy_User_ID);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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


            public static void InsertCadet_with_CadetHistory(string Batch, string CadetName, string CadetFatherName, string PAKNumber, string Address, string CNIC, string BloodGroup, string ContactNumber, string MobileNumber, string Picture, string RFIDCardNumber, string LFMD, string RFMD, string LThumbImage, string RThumbImage, int SQN_User_ID, int Course_ID, int Tape_ID, int CreatedBy_User_ID, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertCadet_with_CadetHistory", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Batch", Batch);
                    cmd.Parameters.AddWithValue("@CadetName", CadetName);
                    cmd.Parameters.AddWithValue("@CadetFatherName", CadetFatherName);
                    cmd.Parameters.AddWithValue("@PAKNumber", PAKNumber);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@CNIC", CNIC);
                    cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
                    cmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    cmd.Parameters.AddWithValue("@Picture", Picture);
                    cmd.Parameters.AddWithValue("@RFIDCardNumber", RFIDCardNumber);
                    cmd.Parameters.AddWithValue("@LFMD", LFMD);
                    cmd.Parameters.AddWithValue("@RFMD", RFMD);
                    cmd.Parameters.AddWithValue("@LThumbImage", LThumbImage);
                    cmd.Parameters.AddWithValue("@RThumbImage", RThumbImage);
                    cmd.Parameters.AddWithValue("@SQN_User_ID", SQN_User_ID);
                    cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
                    cmd.Parameters.AddWithValue("@Tape_ID", Tape_ID);
                    cmd.Parameters.AddWithValue("@CreatedBy_User_ID", CreatedBy_User_ID);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static void InsertRegistrationUser(string FullName, string Designation, string PAKNumber, string UserName, string UserPassword, bool IsActive, int SeniorOfficer_User_ID, string UserPicture, int Role_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertRegisterUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@PAKNumber", PAKNumber);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@SeniorOfficer_User_ID", SeniorOfficer_User_ID);
                    cmd.Parameters.AddWithValue("@UserPicture", UserPicture);
                    cmd.Parameters.AddWithValue("@Role_ID", Role_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    int EffectedRows = 0;

                    conn.Open();
                    EffectedRows = (int)cmd.ExecuteNonQuery();
                    conn.Close();

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
            public static DataTable GetUserDesignation(out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_GetUserDesignation", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


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
            public static DataTable UsersLogin_With_Roles(string uName, string uPassword, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("usp_UsersLogin_With_Roles", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@uName", uName);
                    cmd.Parameters.AddWithValue("@uPassword", uPassword);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    //dt.Rows[0][0] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][0]);
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
            public static int CompareUNameUPassToGetRole(string UserName, string UserPassword, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;
                int  RoleID = 0;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CompareUNameUPassToGetRole", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@UserPassword", UserPassword);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    SqlParameter RoleIDParm = new SqlParameter("@RoleID", SqlDbType.Int);
                    RoleIDParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(RoleIDParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                    RoleID = (int)RoleIDParm.Value;


                    // Set Values for Object

                    //return Object
                    return RoleID;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    RoleID = 0;

                    // Set Values for Object

                    //return Object
                    return RoleID;

                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable GetCadetIdAndName()
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetCadetIdAndName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    JIMessageBox.ShowErrorMessage(ex.Message);
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable GetAttendanceReport(int CadetID,DateTime FromDate,DateTime ToDate, out bool Status, out string StatusDetails)
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
                    cmd = new SqlCommand("AttendanceReport", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@CadetID", CadetID);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);

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
            #endregion //OPERATIONS ENDOPERATIONS
        }
    }
}
