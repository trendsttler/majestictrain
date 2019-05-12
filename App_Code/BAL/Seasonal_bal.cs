using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <
/// >
/// Summary description for Seasonal_bal
/// </summary>
public class Seasonal_bal
{
	public Seasonal_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable bindGrid(string theme)
    {
        Seasonal_dal dal = new Seasonal_dal();
        DataTable dt = new DataTable();
        dt = dal.bindGrid(theme);
        return dt;
    }
    public virtual int InsertData(Seasonal_prp prp)
    {
        Seasonal_dal dal=new Seasonal_dal();
        int i=dal.InsertData(prp);
        return i;
    }
    public DataTable Display(Seasonal_prp prp)
    {
        Seasonal_dal dal = new Seasonal_dal();
        DataTable dt = new DataTable();
        dt = dal.Display(prp);
        return dt;
    }
    public DataTable DisplayList()
    {
        Seasonal_dal dal = new Seasonal_dal();
        DataTable dt = new DataTable();
        dt = dal.DisplayList();
        return dt;
    }
    public virtual int Delete(Seasonal_prp prp)
    {
        Seasonal_dal dal = new Seasonal_dal();
        int i = dal.Delete(prp);
        return i;
    }
}