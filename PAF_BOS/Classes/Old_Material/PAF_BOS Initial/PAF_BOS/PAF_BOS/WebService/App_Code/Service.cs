using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

[WebService(Namespace = "http://vu.edu.pk/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AttendanceAPI : WebService
{ 
    [WebMethod]
    public bool CreateClient(string ClientName, string BusinessNature, string OwnerName, string ContactNo, string Address, string LoginUserName, string Password, out string StatusDetails)
    {
        bool Status = false;
        StatusDetails = null;

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("CreateClient", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientName", ClientName);
            cmd.Parameters.AddWithValue("@BusinessNature", BusinessNature);
            cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@LoginUserName", LoginUserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
            StatusParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusParm);

            SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 100);
            StatusDetailsParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusDetailsParm);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Status = (bool)StatusParm.Value;
            StatusDetails = (string)StatusDetailsParm.Value;
            return Status;
        }
        catch (Exception ex)
        {
            Status = false;
            StatusDetails = ex.Message;
            return Status;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public bool UpdateClient(int ClientID, string ClientName, string BusinessNature, string OwnerName, string ContactNo, string Address, string LoginUser, string Password, bool ClientStatus, out string StatusDetails)
    {
        bool Status = false;
        StatusDetails = null;

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("UpdateClient", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientID", ClientID);
            cmd.Parameters.AddWithValue("@ClientName", ClientName);
            cmd.Parameters.AddWithValue("@BusinessNature", BusinessNature);
            cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@LoginUser", LoginUser);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@ClientStatus", ClientStatus);

            SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
            StatusParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusParm);

            SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 100);
            StatusDetailsParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusDetailsParm);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Status = (bool)StatusParm.Value;
            StatusDetails = (string)StatusDetailsParm.Value;
            return Status;
        }
        catch (Exception ex)
        {
            Status = false;
            StatusDetails = ex.Message;
            return Status;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void CreateShift(int Client_ID, string ShiftName, DateTime FromTime, DateTime ToTime)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("CreateShift", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Client_ID", Client_ID);
            cmd.Parameters.AddWithValue("@ShiftName", ShiftName);
            cmd.Parameters.AddWithValue("@FromTime", FromTime);
            cmd.Parameters.AddWithValue("@ToTime", ToTime);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void UpdateShift(int ShiftID, string ShiftName, DateTime FromTime, DateTime ToTime)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("UpdateShift", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
            cmd.Parameters.AddWithValue("@ShiftName", ShiftName);
            cmd.Parameters.AddWithValue("@FromTime", FromTime);
            cmd.Parameters.AddWithValue("@ToTime", ToTime);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void CreateDepartment(string DepartmentName)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("CreateDepartment", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void UpdateDepartment(int DepartmentID, string DepartmentName)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("UpdateDepartment", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void CreateUser(string LFMD, string LImage, string RFMD, string RImage, string UserPicture, int Client_ID, int Department_ID, int Shift_ID, string UserName, string MobileNumber, string Address, string Designation, string Gender, bool Status)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("CreateUser", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Client_ID", Client_ID);
            cmd.Parameters.AddWithValue("@Department_ID", Department_ID);
            cmd.Parameters.AddWithValue("@Shift_ID", Shift_ID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@LFMD", LFMD);
            cmd.Parameters.AddWithValue("@LIMG", LImage);
            cmd.Parameters.AddWithValue("@RFMD", RFMD);
            cmd.Parameters.AddWithValue("@RIMG", RImage);
            cmd.Parameters.AddWithValue("@UserPicture", UserPicture);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void UpdateUser(string LFMD, string LImage, string RFMD, string RImage, string UserPicture, int UserID, int Department_ID, int Shift_ID, string UserName, string MobileNumber, string Address, string Designation, string Gender, bool Status)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("UpdateUser", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Department_ID", Department_ID);
            cmd.Parameters.AddWithValue("@Shift_ID", Shift_ID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@LFMD", LFMD);
            cmd.Parameters.AddWithValue("@LIMG", LImage);
            cmd.Parameters.AddWithValue("@RFMD", RFMD);
            cmd.Parameters.AddWithValue("@RIMG", RImage);
            cmd.Parameters.AddWithValue("@UserPicture", UserPicture);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public string CreateAttendance(int Client_ID, int User_ID, out bool Status, out string StatusDetails)
    {
        Status = false;
        StatusDetails = null;
        string AttendanceType = null;

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("CreateAttendance", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Client_ID", Client_ID);
            cmd.Parameters.AddWithValue("@User_ID", User_ID);
            

            SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
            StatusParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusParm);

            SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 255);
            StatusDetailsParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusDetailsParm);

            SqlParameter AttendanceTypeParm = new SqlParameter("@AttendanceType", SqlDbType.VarChar, 255);
            AttendanceTypeParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AttendanceTypeParm);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Status = (bool)StatusParm.Value;
            StatusDetails = (string)StatusDetailsParm.Value;
            AttendanceType = (string)AttendanceTypeParm.Value;
            return AttendanceType;
        }
        catch (Exception ex)
        {
            Status = false;
            StatusDetails = ex.Message;
            AttendanceType = "";
            return AttendanceType;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public void UpdateUserShift(int UserID, int Shift_ID)
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("UpdateUserShift", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Shift_ID", Shift_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetDepartments()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetDepartments", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


            conn.Open();
            Adapter.Fill(dt);
            conn.Close(); 

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {

            //Return Value
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetShiftsByClientID(int ClientID)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetShiftsByClientID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetUsersByClientID(int ClientID)
    {


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetUsersByClientID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();


            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {

            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetUserByUserID(int UserID)
    {


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetUserByUserID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {

            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetUserAttendance(int UserID, DateTime FromDate, DateTime ToDate)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetUserAttendance", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();


            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet AuthenticateUser(string UserName, string Password, out bool Status, out string StatusDetails)
    {
        Status = false;
        StatusDetails = null;

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("AuthenticateUser", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

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

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            Status = false;
            StatusDetails = ex.Message;

            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetClients()
    {


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetClients", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


            conn.Open();
            Adapter.Fill(dt);
            conn.Close();


            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {

            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public bool ChangePassword(string UserName, string NewPassword, string OldPassword, out string StatusDetails)
    {
        bool Status = false;
        StatusDetails = null;

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("ChangePassword", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
            cmd.Parameters.AddWithValue("@OldPassword", OldPassword);

            SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
            StatusParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusParm);

            SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 250);
            StatusDetailsParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(StatusDetailsParm);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Status = (bool)StatusParm.Value;
            StatusDetails = (string)StatusDetailsParm.Value;
            return Status;
        }
        catch (Exception ex)
        {
            Status = false;
            StatusDetails = ex.Message;
            return Status;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetClientByClientID(int ClientID)
    {


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetClientByClientID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetDepartmentByDepartmentID(int DepartmentID)
    {


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetDepartmentByDepartmentID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetShiftByShiftID(int ShiftID)
    {


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FinalProjectConnectionString"].ToString();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("GetShiftByShiftID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@ShiftID", ShiftID);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetClientsDetailsReport(int ClientID)
    {


        DataSet ds = new DataSet();
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

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetClientUsersAttendanceByClientIDReport(int ClientID, int UserID, DateTime FromDate, DateTime ToDate)
    {


        DataSet ds = new DataSet();
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
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);

            conn.Open();
            Adapter.Fill(dt);
            conn.Close();


            ds.Tables.Add(dt);
            return ds;

        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;

        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

    [WebMethod]
    public DataSet GetUserDetailsByClientIDReport(int ClientID)
    {

        DataSet ds = new DataSet();
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

            ds.Tables.Add(dt);
            return ds;
        }
        catch (Exception ex)
        {
            ds.Tables.Add(dt);
            return ds;
        }
        finally
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }

}