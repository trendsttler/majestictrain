using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Seasonal_dal
/// </summary>
public class Seasonal_dal
{
	public Seasonal_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable bindGrid(string theme)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Season_bindgrid]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_theme", theme);
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
    public virtual int InsertData(Seasonal_prp prp)
    {
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_season_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("@hotel_id", SqlDbType.VarChar, 6);
            //p1.Value = prp.h_id;
            //p1.Direction = ParameterDirection.InputOutput;
            //Mycon.adp.SelectCommand.Parameters.Add(p1);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@heading", prp.heading);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_orderno", prp.tour_orderno);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_status", prp.tour_status);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_name", prp.tour_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_image", prp.tour_image);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_dur", prp.tour_dur);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_price", prp.tour_price);

            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            }
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
    public virtual int Delete(Seasonal_prp prp)
    {
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_season_Delete]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@heading", prp.heading);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {
                //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            }
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
    public DataTable Display(Seasonal_prp prp)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_season_display]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@heading", prp.heading);
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
    public DataTable DisplayList()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_season_list]";

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
}