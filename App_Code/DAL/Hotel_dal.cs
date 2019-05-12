using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Hotel_dal
/// </summary>
public class Hotel_dal
{
    MyConnection Mycon = new MyConnection();
    public Hotel_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TourDD(Hotel_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
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
    public DataTable CategoryDD(Hotel_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_CatDD]";
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
    public DataTable displayGrid(Hotel_prp prp)
    {
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_gridvw_hotel]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.t_id);
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
    public DataTable Display(Hotel_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_HotelDisplay]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.h_id);
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
    public virtual int hotelinsert(Hotel_prp prp)
    {
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_Hotel_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("@hotel_id", SqlDbType.VarChar, 6);
            //p1.Value = prp.h_id;
            //p1.Direction = ParameterDirection.InputOutput;
            //Mycon.adp.SelectCommand.Parameters.Add(p1);

            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.t_id);
           Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_desc", prp.h_des);

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
    public virtual int hotelupdate(Hotel_prp prp)
    {
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_hotel_update]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("@hotel_id", SqlDbType.VarChar, 6);
            //p1.Value = prp.h_id;
            //p1.Direction = ParameterDirection.InputOutput;
            //Mycon.adp.SelectCommand.Parameters.Add(p1);

            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.t_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_desc1", prp.h_olddes);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_desc", prp.h_des);

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
    public virtual int Delete(Hotel_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.cmd.CommandText = "[control_Hotel_delete]";
            Mycon.cmd.CommandType = CommandType.StoredProcedure;
            Mycon.cmd.Parameters.AddWithValue("@tour_id", prp.t_id);
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
    public DataTable Displaybysearch(Hotel_prp prp)
    {
        //MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_hotel_search]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
           // Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_name", prp.h_name);
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
    public DataTable Gridvw()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_gridvw_hotel]";

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
    public DataTable Display_list()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_hotel_list]";

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
    public DataTable GCatDD(Hotel_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_CatDD]";
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
    public virtual int updataHdata(Hotel_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Hotel_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.t_id);
           // Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_id", prp.h_id);
           // Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_cat_id", prp.h_cat);
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
    public DataTable extrcatCatID(string catname)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_hotel_getcatID]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@hotel_cat_name", catname);
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