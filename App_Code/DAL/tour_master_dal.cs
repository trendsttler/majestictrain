using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for tour_master_dal
/// </summary>
public class tour_master_dal
{
    MyConnection Mycon = new MyConnection();
	public tour_master_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public virtual int Inserttour_master(tour_master_prp prp)
    {

        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_tours_master_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_name", prp.tour_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_days", prp.tour_day);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_night", prp.tour_night);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_des", prp.tour_dec);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_price", prp.tour_price);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_img", prp.tour_img);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_theme", prp.tour_theme);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@status", prp.IsActive);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@popular", prp.tour_most_popular);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {
                
            }
            return i;

        }
        catch (Exception ex)
        {
            return 0;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }
    }
    public virtual int Delete(tour_master_prp prp)
    {
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.cmd.CommandText = "control_tours_delete_master";
            Mycon.cmd.CommandType = CommandType.StoredProcedure;
            Mycon.cmd.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.open();
            int cnt = Mycon.cmd.ExecuteNonQuery();
            return cnt;
        }
        catch (Exception ex)
        {
            Mycon.open();
            return 0;
        }
        finally
        { Mycon.open(); }
    }
    public virtual int Inserttour_sector(tour_master_prp prp)
    {

        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_tours_sector_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.stid);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec_name", prp.tour_sec);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@sec_name1", prp.tour_sec1);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ord_id", prp.sec_order);
            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {

            }
            return i;

        }
        catch (Exception ex)
        {
            return 0;
            Mycon.close();
        }
        finally
        {
            Mycon.close();
        }
    }


    public DataTable Display(tour_master_prp prp)
    {
        MyConnection Mycon = new MyConnection();

        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_select_tours_master_display]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
        }
    }
}