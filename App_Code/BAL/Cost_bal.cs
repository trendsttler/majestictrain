using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Cost_bal
/// </summary>
public class Cost_bal
{
	public Cost_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TourDD(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();
        DataTable dt = new DataTable();
        dt = dal.TourDD(prp);
        return dt;
    }
    public DataTable EXTTourDD(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();
        DataTable dt = new DataTable();
        dt = dal.EXTTourDD(prp);
        return dt;
    }
    public DataTable DisplayCost(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();

        DataTable dt = new DataTable();
        dt = dal.DisplayCost(prp);
        return dt;
    }
    public DataTable DisplayExt(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();

        DataTable dt = new DataTable();
        dt = dal.DisplayExt(prp);
        return dt;
    }
    public DataTable Display_Costlist()
    {
        Cost_dal dal = new Cost_dal();

        DataTable dt = new DataTable();
        dt = dal.Display_Costlist();
        return dt;
    }
    public DataTable Display_Extlist()
    {
        Cost_dal dal = new Cost_dal();

        DataTable dt = new DataTable();
        dt = dal.Display_Extlist();
        return dt;
    }
    public virtual int InsertCostData(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();
        DataTable dt = new DataTable();
        return dal.InsertCostData(prp);
    }
    public virtual int delete(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();
        DataTable dt = new DataTable();
        return dal.delete(prp);
    }
    public virtual int InsertExtData(Cost_prp prp)
    {
        Cost_dal dal = new Cost_dal();
        DataTable dt = new DataTable();
        return dal.InsertExtData(prp);
    }
}