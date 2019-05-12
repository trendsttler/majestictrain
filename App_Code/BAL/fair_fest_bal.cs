using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for fair_fest_bal
/// </summary>
public class fair_fest_bal
{
    
	public fair_fest_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getfair()
    {
        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getfair();
        return dt;
    }

    public DataTable getfestival()
    {
    
        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getfestival();
        return dt;
    
    }


    public DataTable getfairfestival()
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getfairfestival();
        return dt;

    }

    public DataTable getfestivaldata(string fairname)
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getfestivaldata(fairname);
        return dt;

    }

    public DataTable getfairdata(string fairname)
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getfairdata(fairname);
        return dt;

    }

    public DataTable getdestdata(string fairname)
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getdestdata(fairname);
        return dt;

    }

    public DataTable getdatedata(string startdate, string enddate)
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getdatedata(startdate,enddate);
        return dt;

    }

    public DataTable getmnthdata(string fairname)
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getmnthdata(fairname);
        return dt;

    }


    public DataTable getfairfestdesc(string id)
    {

        DataTable dt = new DataTable();
        fair_fest_dal dal = new fair_fest_dal();
        dt = dal.getfairfestdesc(id);
        return dt;

    }
}