using System;
using System.Collections.Generic;
using System.Data;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for overview_bal
/// </summary>
public class overview_bal
{
    
	public overview_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public virtual int InsertDataH(overview_prp prp)
    {
        overview_dal dal = new overview_dal();
        DataTable dt = new DataTable();
        int cnt = dal.InsertDataH(prp);
        return cnt;

    }
    public virtual int InsertDataIn(overview_prp prp)
    {
        overview_dal dal = new overview_dal();
        DataTable dt = new DataTable();
        int cnt = dal.InsertDataIn(prp);
        return cnt;

    }
    public virtual int InsertDataEx(overview_prp prp)
    {
        overview_dal dal = new overview_dal();
        DataTable dt = new DataTable();
        int cnt = dal.InsertDataEx(prp);
        return cnt;

    }
    public DataTable TourDD(overview_prp prp)
    {
        overview_dal dal = new overview_dal();
        DataTable dt = new DataTable();
        dt = dal.TourDD(prp);
        
        return dt;
    }
    public DataTable Display(overview_prp prp)
    {
        overview_dal dal = new overview_dal();
         DataTable dt = new DataTable();
        dt = dal.Display(prp);
        return dt;
    }
    public DataTable GridvwHg()
    {
        overview_dal dal = new overview_dal();

        DataTable dt = new DataTable();
        dt = dal.GridvwHg();
        return dt;
    }
    public DataTable GridvwIn()
    {
        overview_dal dal = new overview_dal();

        DataTable dt = new DataTable();
        dt = dal.GridvwIn();
        return dt;
    }
    public DataTable GridvwEx()
    {
        overview_dal dal = new overview_dal();

        DataTable dt = new DataTable();
        dt = dal.GridvwEx();
        return dt;
    }

    //public DataTable Display(overview_prp prp)
    //{
    //    overview_dal dal = new overview_dal();

    //    DataTable dt = new DataTable();
    //    dt = dal.Display(prp);
    //    return dt;
    //}
    public virtual int Delete(overview_prp prp)
    {
        overview_dal dal = new overview_dal();
        return dal.Delete(prp);
    }
}