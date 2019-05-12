using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

/// <summary>
/// Created by SD. Rahul Gupta
/// </summary>
public class Day_bal
{
	public Day_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public virtual int insertdaydata(Day_prp prp)
    {

        Day_dal dal = new Day_dal();
        return dal.insertdaydata(prp);
    
    }

    public virtual int insertnotedata(Day_prp prp)
    {

        Day_dal dal = new Day_dal();
        return dal.insertnotedata(prp);

    }
  
    public DataTable bind_tour(Day_prp prp)
    {
        Day_dal dal = new Day_dal();
        DataTable dt = new DataTable();
        dt = dal.bind_tour(prp);
        return dt;
    
    }

    public DataTable displayday(Day_prp prp)
    {

        Day_dal dal = new Day_dal();
        DataTable dt = new DataTable();
        dt = dal.displayday(prp);
        return dt;
    }

    public DataTable displaynote(Day_prp prp)
    {

        Day_dal dal = new Day_dal();
        DataTable dt = new DataTable();
        dt = dal.displaynote(prp);
        return dt;
    }

    public DataTable displatlist( )
    {

        Day_dal dal = new Day_dal();
        DataTable dt = new DataTable();
        dt = dal.displaylist();
        return dt;
    
    }

    public DataTable displatlist1()
    {

        Day_dal dal = new Day_dal();
        DataTable dt = new DataTable();
        dt = dal.displaylist1();
        return dt;

    }

    public virtual int deletedaydata(Day_prp prp)
    {

        Day_dal dal = new Day_dal();
        return dal.deletedaydata(prp);

    }

    public virtual int deletenotedata(Day_prp prp)
    {

        Day_dal dal = new Day_dal();
        return dal.deletenotedata(prp);

    }

}