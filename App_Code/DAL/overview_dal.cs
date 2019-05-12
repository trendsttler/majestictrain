using System;
using System.Collections.Generic;
using System.Data;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for overview_dal
/// </summary>
public class overview_dal
{
    MyConnection Mycon = new MyConnection();
	public overview_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public virtual int InsertDataH(overview_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_overview_insert]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@high_id", prp.high_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@head", prp.heading);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@high_des", prp.high_des);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            //}
            return i;

        }
        catch (Exception ex)
        {
            return 0;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }
    }
    public virtual int InsertDataIn(overview_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_overview_insertIn]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@incl_id", prp.incl_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@incl_des", prp.incl_des);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@head", prp.heading);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            //}
            return i;

        }
        catch (Exception ex)
        {
            return 0;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }
    }
    public virtual int InsertDataEx(overview_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_overview_insertEx]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@excl_id", prp.excl_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@excl_des", prp.excl_des);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@head", prp.heading);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            //}
            return i;

        }
        catch (Exception ex)
        {
            return 0;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }
    }
    public DataTable TourDD(overview_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_overview_select_data]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Mycon.adp.SelectCommand.Parameters.AddWithValue("@id", prp.course_id);
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
    public DataTable Display(overview_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
            DataTable dt = new DataTable();
            try
            {
                Mycon.adp.SelectCommand.Parameters.Clear();
                Mycon.adp.SelectCommand.CommandText = "[control_overview_display]";
                Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
                Mycon.adp.SelectCommand.Parameters.AddWithValue("@head", prp.heading);
                Mycon.open();
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
    public DataTable GridvwHg()
    {
        //MyConnection Mycon = new MyConnection();
       DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Highlight_list]";
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
    public DataTable GridvwIn()
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Include_list]";
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
    
    public DataTable GridvwEx()
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Exclude_list]";
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
    public virtual int Delete(overview_prp prp)
    {
        try
        {
            Mycon.cmd.CommandText = "[control_overview_delete]";
            Mycon.cmd.CommandType = CommandType.StoredProcedure;
            Mycon.cmd.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.cmd.Parameters.AddWithValue("@heading", prp.heading);
            if (prp.heading == "Highlights")
            {
                Mycon.cmd.Parameters.AddWithValue("@id",prp.high_id);
            }
            else if (prp.heading == "Inclusions")
            {
                Mycon.cmd.Parameters.AddWithValue("@id",prp.incl_id);
            }
            else
            {
                Mycon.cmd.Parameters.AddWithValue("@id",prp.excl_id);
            }
            
            Mycon.open();
            int cnt = Mycon.cmd.ExecuteNonQuery();
            return cnt;
        }
        catch (Exception ex)
        {
            Mycon.open();
            return 0;
        }
        finally
        { Mycon.open(); }
    }
}