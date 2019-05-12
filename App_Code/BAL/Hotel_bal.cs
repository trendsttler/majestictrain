using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Hotel_bal
/// </summary>
public class Hotel_bal
{
	public Hotel_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TourDD(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        dt = dal.TourDD(prp);
        return dt;
    }
    public DataTable CategoryDD(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        dt = dal.CategoryDD(prp);
        return dt;
    }
    public DataTable displayGrid(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();

        DataTable dt = new DataTable();
        dt = dal.displayGrid(prp);
        return dt;
    }
    public DataTable Display(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();

        DataTable dt = new DataTable();
        dt = dal.Display(prp);
        return dt;
    }
    public virtual int hotelupdate(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        return dal.hotelupdate(prp);
    }
    
    public virtual int hotelinsert(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        return dal.hotelinsert(prp);
    }
    public virtual int Delete(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        return dal.Delete(prp);
    }
    public DataTable Displaybyseach(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();

        DataTable dt = new DataTable();
        dt = dal.Displaybysearch(prp);
        return dt;
    }
    public DataTable Gridvw()
    {
        Hotel_dal dal = new Hotel_dal();

        DataTable dt = new DataTable();
        dt = dal.Gridvw();
        return dt;
    }
    public DataTable Display_list()
    {
        Hotel_dal dal = new Hotel_dal();

        DataTable dt = new DataTable();
        dt = dal.Display_list();
        return dt;
    }
    public DataTable GCatDD(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        dt = dal.GCatDD(prp);
        return dt;
    }
    public virtual int updataHdata(Hotel_prp prp)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        return dal.updataHdata(prp);
    }
    public DataTable extrcatCatID(string catname)
    {
        Hotel_dal dal = new Hotel_dal();
        DataTable dt = new DataTable();
        return dal.extrcatCatID(catname);
    }
}