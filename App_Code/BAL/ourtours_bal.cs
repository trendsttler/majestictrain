using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <
/// >
/// Summary description for ourtours_bal
/// </summary>
public class ourtours_bal
{
	public ourtours_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable selecttestitdata()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selecttesittdata();
        return dt;
    }
    public DataTable Current_toursid(string touid)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.Current_toursid(touid);
        return dt;
    }
    public DataTable NightRadioBtn(string value)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.NightRadioBtn(value);
        return dt;
    }
    public DataTable ThemeFilter(string value)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.ThemeFilter(value);
        return dt;
    }
    public DataTable tourFilter(string value)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.tourFilter(value);
        return dt;
    }
    public DataTable gettourl2()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.gettourl2();
        return dt;
    }
    public DataTable getstate()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.getstate();
        return dt;
    }
    public DataTable getcity(string sid)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.getcity(sid);
        return dt;
    }
    public DataTable SearchData(string clm_name, string ord)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.SearchData(clm_name, ord);
        return dt;
    }

    public DataTable selectby_sec_thm_dur(string sec, string thm, string dur)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selectby_sec_thm_dur(sec, thm, dur);
        return dt;
    }


    public DataTable selectpopulartour()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selectpopulartour();
        return dt;
    }

    public DataTable selectseasonaltour()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selectseasonaltour();
        return dt;
    }


    public DataTable selectData()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selectData();
        return dt;
    }
    public DataTable sectorFilter(string str)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.sectorFilter(str);
        return dt;
    }

    public DataTable selecthomepanel1data()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selecthomepanel1data();
        return dt;
    }
   
    public DataTable selecttestdata()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selecttestdata();
        return dt;
    }

  

    public DataTable selecttestimonialdata()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.selecttestimonialdata();
        return dt;
    }

    
    public DataTable Distinctsector(string str )
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.Distinctsector(str);
        return dt;
    }

    public DataTable Distinctcity(string str)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.Distinctcity(str);
        return dt;
    }

    public DataTable Distincthotel(string str)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.Distincthotel(str);
        return dt;
    }

    public DataTable Distincttheme(string str)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.Distincttheme(str);
        return dt;
    }

    public DataTable GetTour_sector(string str1,string str2,string str3,string str4,string str5,string str6)
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.GetTour_Sector(str1, str2, str3, str4, str5, str6);
        return dt;
    }
    public DataTable MostPopular()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt=dal.MostPopular();
        return dt;
    }
    public DataTable TestimonialData()
    {
        ourtours_dal dal = new ourtours_dal();
        DataTable dt = new DataTable();
        dt = dal.TestimonialData();
        return dt;
    }
}