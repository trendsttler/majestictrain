using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for heading_dal
/// </summary>
public class heading_dal
{
	public heading_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TourDD()
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_TourDD]";
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
    public DataTable tourDetails(string tour_id)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_heading_tour1]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", tour_id);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable Display(heading_prp prp)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_head_display]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@id", prp.id);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable Displaylist()
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_heading_list]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public virtual int InsertHead(heading_prp prp)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_heading_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar, 6);
            p1.Value = prp.id;
            p1.Direction = ParameterDirection.InputOutput;
            Mycon.adp.SelectCommand.Parameters.Add(p1);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@heading", prp.heading);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@orderno", prp.orderno);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@status", prp.status);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t1_id", prp.t1_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t1_name", prp.t1_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t1_image", prp.t1_image);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t1_dur", prp.t1_dur);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t1_price", prp.t1_price);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t2_id", prp.t2_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t2_name", prp.t2_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t2_image", prp.t2_image);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t2_dur", prp.t2_dur);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t2_price", prp.t2_price);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t3_id", prp.t3_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t3_name", prp.t3_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t3_image", prp.t3_image);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t3_dur", prp.t3_dur);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t3_price", prp.t3_price);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {
                prp.id = Mycon.adp.SelectCommand.Parameters["@id"].Value.ToString();
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
    public virtual int DeleteHead(heading_prp prp)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        try
        {

            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_heading_Delete]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@id", prp.id);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {
                
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
}