using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Control_Login_Dal
/// </summary>
public class Control_Login_Dal
{
    mycon con = new mycon();
    SqlDataReader dr;

	public Control_Login_Dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable Login(string Uname, string Pass)
    {
       
        DataTable dt = new DataTable();
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.CommandText = "dbo.chief_master_sub_info";
        con.cmd.Parameters.AddWithValue("@adm_id", Uname);
        con.cmd.Parameters.AddWithValue("@adm_permission", Pass);
        con.open();
        dr=con.cmd.ExecuteReader();
        dt.Load(dr);
        dr.Close();
        con.close();
        return dt;
       

    }
    public DataTable superLogin(string Uname, string Pass)
    {

        DataTable dt = new DataTable();
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.CommandText = "dbo.chief_master_permission";
        con.cmd.Parameters.AddWithValue("@chief_id", Uname);
        con.cmd.Parameters.AddWithValue("@chief_permission", Pass);
        con.open();
        dr = con.cmd.ExecuteReader();
        dt.Load(dr);
        dr.Close();
        con.close();
        return dt;


    }

}