using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;


/// <summary>
/// Summary description for itinerary_bal
/// </summary>
public class itinerary_bal
{
	public itinerary_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable selecttestitdata()
    {
        itinerary_dal dal = new itinerary_dal();
        DataTable dt = new DataTable();
        dt = dal.selecttesittdata();
        return dt;
    }

    public DataTable getimages(string imgid)
    {
        itinerary_dal dal = new itinerary_dal();
        DataTable dt = new DataTable();
        dt = dal.getimages(imgid);
        return dt;
    
    }
    public DataTable tourdatadisplya(string tour_id)
    {
        itinerary_dal dal = new itinerary_dal();
        DataTable dt = new DataTable();
        dt = dal.tourdatadisplya(tour_id);
        return dt;

    }
    public DataTable tour_overview(string tour_id)
    {
        itinerary_dal dal = new itinerary_dal();
        DataTable dt = new DataTable();
        dt = dal.tour_overview(tour_id);
        return dt;

    }
    public DataTable tour_daynnotes(string tour_id)
    {
        itinerary_dal dal = new itinerary_dal();
        DataTable dt = new DataTable();
        dt = dal.tour_daynnotes(tour_id);
        return dt;

    }
}