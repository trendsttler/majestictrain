using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for query_dal
/// </summary>
public class query_dal
{
   	public query_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public virtual int insert_query(query_prp prp)
    {
        myconnectionenquery Mycon = new myconnectionenquery();
        try
        {

            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[dbo].[control_insert_query]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@query_for", prp.queryfor);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@query_dest", prp.querydest);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@arrival_date", prp.arrival_date);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@dep_date", prp.dep_date);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t_adults", prp.t_adults);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t_childs", prp.t_childs);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t_infants", prp.t_infants);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t_dblrooms", prp.t_dblroom);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t_snglrooms", prp.t_sglroom);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@t_extabeds", prp.t_extrabeds);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@b_currncy", prp.bgt_crncy);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@b_amt", prp.bgt_amt);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@query_plan", prp.planreq);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@name", prp.name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@gender", prp.gender);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@address", prp.address);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@city", prp.city);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@state", prp.state);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@country", prp.country);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@pincode", prp.pincode);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@phone", prp.phno);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@mobile", prp.mblno);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@email", prp.email);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ip_address", prp.ipadress);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ip_country", prp.ipcountry);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ip_city", prp.ipcity);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ip_lat", prp.iplat);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ip_long", prp.iplong);
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
}