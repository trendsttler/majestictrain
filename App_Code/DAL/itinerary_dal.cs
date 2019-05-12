using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for itinerary_dal
/// </summary>
public class itinerary_dal
{
   
	public itinerary_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable selecttesittdata()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[SelectItineraryTestimonialData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable getimages(string imgid)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();

        try
        {
                Mycon.adp.SelectCommand.Parameters.Clear();
                Mycon.adp.SelectCommand.Connection = Mycon.con;
                Mycon.adp.SelectCommand.CommandText = "[gen_itinerary_images]";
                Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                Mycon.adp.SelectCommand.Parameters.AddWithValue("@menuid", imgid);
                Mycon.adp.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
                Mycon.close();
            }
            finally
            {
                Mycon.close();
            }

       
    }
    public DataTable tourdatadisplya( string tour_id)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();

        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_select_itenarydata]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tourid", tour_id);

            Mycon.adp.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }


    }
    public DataTable tour_overview(string tour_id)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();

        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_overview_data]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", tour_id);

            Mycon.adp.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }


    }
    public DataTable tour_daynnotes(string tour_id)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();

        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_select_dayandnotes]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", tour_id);

            Mycon.adp.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }


    }
}