using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tour_master_prp
/// </summary>
public class tour_master_prp
{
	public tour_master_prp()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string stid { get; set; }
    public string tour_id { get; set; }
    public string tour_name { get; set; }
    public string tour_day { get; set; }
    public string tour_night { get; set; }
    public string tour_dec { get; set; }
    public string tour_price { get; set; }
    public string tour_img { get; set; }
    public string tour_theme { get; set; }
    public int IsActive { get; set; }
    public string tour_sec { get; set; }
    public string tour_sec1 { get; set; }
    public string sec_order { get; set; }
    public int tour_most_popular { set; get; }
}