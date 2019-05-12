using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <
/// >
/// Summary description for tour_master_bal
/// </summary>
public class tour_master_bal
{
	public tour_master_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public virtual int Inserttour_master(tour_master_prp prp)
    {
        tour_master_dal dal = new tour_master_dal();
        return dal.Inserttour_master(prp);

    }
    public virtual int Delete(tour_master_prp prp)
    {
        tour_master_dal dal = new tour_master_dal();
        return dal.Delete(prp);
    }
    public virtual int Inserttour_sector(tour_master_prp prp)
    {
        tour_master_dal dal = new tour_master_dal();
        return dal.Inserttour_sector(prp);

    }

    public DataTable Display(tour_master_prp prp)
    {

        tour_master_dal dal = new tour_master_dal();
        DataTable dt = new DataTable();

        dt = dal.Display(prp);
        return dt;
    
    }

}