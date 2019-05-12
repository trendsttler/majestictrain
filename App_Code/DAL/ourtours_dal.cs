using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ourtours_dal
/// </summary>
public class ourtours_dal
{

    public ourtours_dal()
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
    public DataTable Current_toursid(string touid)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "Select * from dbo.Tours_master where tour_id='" + touid + "'";
            Mycon.adp.SelectCommand.CommandType = CommandType.Text;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable NightRadioBtn(string value)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt=new DataTable();
        try
        {
             Mycon.adp.SelectCommand.Parameters.Clear();
             Mycon.adp.SelectCommand.CommandText = "[filter_getNights]";
             Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
             Mycon.adp.SelectCommand.Parameters.AddWithValue("@filter", value);
             Mycon.adp.Fill(dt);
             return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
     }
    public DataTable ThemeFilter(string value)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[filter_theme]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@theme", value);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable tourFilter(string value)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[filter_toursbyl2]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@l2id", value);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable gettourl2()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[gettoursl2_Cursor]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable getstate()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[gethotelstate]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable getcity(string sid)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[gethotelcity]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sid", sid);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable SearchData(string clm_name, string ord)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_serch_order]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@clm_name", clm_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ordby", ord);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }


    public DataTable selectby_sec_thm_dur(string sec,string thm, string dur)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_selectby_sec_thm_dur]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec", sec);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@thm", thm);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@dur", dur);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }



    public DataTable selectpopulartour()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_popular_tours1]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }



    public DataTable selectseasonaltour()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_seasonal_tours]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable selectData()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_select_menu2]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable selecthomepanel1data()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_home_panel1]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }



     public DataTable selecttestdata()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[SelectTestimonialData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

     public DataTable selectContactusTestData()
     {
         MyConnection Mycon = new MyConnection();
         DataTable dt = new DataTable();
         try
         {
             Mycon.adp.SelectCommand.Parameters.Clear();
             Mycon.adp.SelectCommand.CommandText = "[SelectContactusTestData]";
             Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
             Mycon.adp.Fill(dt);
             return dt;
         }
         catch (Exception ex)
         {
             return dt;
         }
     }

    public DataTable selecttestimonialdata()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[SelectTestimonialData]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable sectorFilter(string str)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_searchby_sector]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sname", str);

            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable Distinctsector(string str)
    {
        string serch = str + '%';
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_sector_list]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sname", serch);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable Distinctcity(string str)
    {
        string serch = str + '%';
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_city_list]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sname", serch);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable Distincthotel(string str)
    {
        string serch = str + '%';
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_hotels_list]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sname", serch);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable Distincttheme(string str)
    {
        string serch = str + '%';
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_theme_list]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sname", serch);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }


    public DataTable GetTour_Sector(string str1,string str2,string str3,string str4,string str5,string str6)
    {
        //string serch = str + '%';
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[filter_getdestination]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec1", str1);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec2", str2);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec3", str3);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec4", str4);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec5", str5);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec6", str6);
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable MostPopular()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_popular_tours]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
    public DataTable TestimonialData()
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_testimonial]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }
}