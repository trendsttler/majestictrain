using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <
/// >
/// Summary description for tourl2_bal
/// </summary>
public class tourl2_bal
{
	public tourl2_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable get_image(string l3)
    {
        DataTable dt = new DataTable();
        tourl2_dal dal = new tourl2_dal();
        dt = dal.Get_images(l3);
        return dt;
    }
    public DataTable get_data(string l3)
    {
        DataTable dt = new DataTable();
        tourl2_dal dal = new tourl2_dal();
        dt = dal.Get_Data(l3);
        return dt;
    }
}