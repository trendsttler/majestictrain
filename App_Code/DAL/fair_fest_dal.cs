using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for fair_fest_dal
/// </summary>
public class fair_fest_dal
{
    
	public fair_fest_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getfair()
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindFairsType]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
         
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }
    
    
    }

    public DataTable getfestival()
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindFestivalType]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }

    public DataTable getfairfestival()
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindDefaultData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }

    public DataTable getfestivaldata(string fairname)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindFestivalData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@EventName", fairname);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }


    public DataTable getdestdata(string fairname)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindDestinationData1]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@TourDestination", fairname);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }

    public DataTable getdatedata(string startdate, string enddate)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindEndDateData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@StartDate", startdate);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@TourEndDate", enddate);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }

    public DataTable getmnthdata(string fairname)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindYearMonthData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@TourYearMonth", fairname);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }

    public DataTable getfairdata(string fairname)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[BindFairsData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@EventName", fairname);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }



    public DataTable getfairfestdesc(string id)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[Sp_Bind_GridViewDropDown_data]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@Tour_Name_1", id);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }


    }

}