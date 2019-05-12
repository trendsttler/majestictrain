using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Cost_dal
/// </summary>
public class Cost_dal
{
    MyConnection Mycon = new MyConnection();
	public Cost_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TourDD(Cost_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_TourDD]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Mycon.adp.SelectCommand.Parameters.AddWithValue("@id", prp.course_id);
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
    public DataTable EXTTourDD(Cost_prp prp)
    {
        DataTable dt = new DataTable();
        //MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_TourDD]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Mycon.adp.SelectCommand.Parameters.AddWithValue("@id", prp.course_id);
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
    public DataTable DisplayCost(Cost_prp prp)
    {

        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_CostDisplay]";

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
    public DataTable DisplayExt(Cost_prp prp)
    {

        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_ExtensionDisplay]";

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
    public DataTable Display_Costlist()
    {
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Cost_list]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataTable Display_Extlist()
    {
        DataTable dt = new DataTable();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.CommandText = "[control_Extension_list]";

            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public virtual int InsertCostData(Cost_prp prp)
    {
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_Cost_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("@hotel_id", SqlDbType.VarChar, 6);
            //p1.Value = prp.h_id;
            //p1.Direction = ParameterDirection.InputOutput;
            //Mycon.adp.SelectCommand.Parameters.Add(p1);

            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@cost_id", prp.cost_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@cost_name", prp.cost_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@cost_des", prp.cost_des);

            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            //}
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
    public virtual int delete(Cost_prp prp)
    {
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_delete_cost]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);

            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            //}
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
    public virtual int InsertExtData(Cost_prp prp)
    {
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_Ext_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("@hotel_id", SqlDbType.VarChar, 6);
            //p1.Value = prp.h_id;
            //p1.Direction = ParameterDirection.InputOutput;
            //Mycon.adp.SelectCommand.Parameters.Add(p1);

            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ext_id", prp.ext_tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ext_tourname", prp.ext_tour_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ord_id", prp.order_id);

            Mycon.open();
            int i = Mycon.adp.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    prp.h_id = Mycon.adp.SelectCommand.Parameters["@hotel_id"].Value.ToString();
            //}
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
}