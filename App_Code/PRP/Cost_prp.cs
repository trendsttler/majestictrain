using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cost_prp
/// </summary>
public class Cost_prp
{
	public Cost_prp()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string cost_id { set; get; }
    public string tour_id { set; get; }
    public string cost_name { set; get; }
    public string cost_des { get; set; }
    public string ext_tour_name { set; get; }
    public string ext_tour_id { set; get; }
    public string order_id { set; get; }
}