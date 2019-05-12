using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for heading_bal
/// </summary>
public class heading_bal
{
	public heading_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TourDD()
    {
        heading_dal dal = new heading_dal();
        DataTable dt = new DataTable();
        dt = dal.TourDD();
        return dt;
    }
    public DataTable tourDetails(string tour_id)
    {
        heading_dal dal = new heading_dal();
        DataTable dt = new DataTable();
        dt = dal.tourDetails(tour_id);
        return dt;
    }
    public DataTable Display(heading_prp prp)
    {
        heading_dal dal = new heading_dal();
        DataTable dt = new DataTable();
        dt = dal.Display(prp);
        return dt;
    }
    public virtual int InsertHead(heading_prp prp)
    {
        heading_dal dal = new heading_dal();
        int i = dal.InsertHead(prp);
        return i;
    }
    public virtual int DeleteHead(heading_prp prp)
    {
        heading_dal dal = new heading_dal();
        int i = dal.DeleteHead(prp);
        return i;
    }
    public DataTable Displaylist()
    {
        heading_dal dal = new heading_dal();
        DataTable dt = new DataTable();
        dt = dal.Displaylist();
        return dt;
    }
}