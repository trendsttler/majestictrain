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
using System.Data.SqlClient;

/// <summary>
/// Created by Rahul Gupta
/// </summary>
public class Day_dal
{
  
	public Day_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   public virtual int insertdaydata(Day_prp prp)
    {
        MyConnection Mycon = new MyConnection();
        try {

            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[control_day_insert]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@day_id", prp.day_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id",prp.tour_id);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@day_name", prp.day_name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@day_loc",prp.day_loc);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@day_dist",prp.day_dist);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@day_des",prp.day_desc);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@ord_id", prp.day_order);
         
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

   public virtual int insertnotedata(Day_prp prp)
   {
       MyConnection Mycon = new MyConnection();
       try
       {

           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.Connection = Mycon.con;
           Mycon.adp.SelectCommand.CommandText = "[control_note_insert]";
           Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
           Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);
           Mycon.adp.SelectCommand.Parameters.AddWithValue("@note_id", prp.note_id);
           Mycon.adp.SelectCommand.Parameters.AddWithValue("@note_type", prp.note_type);
           Mycon.adp.SelectCommand.Parameters.AddWithValue("@note_desc", prp.note_desc);


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

   public DataTable bind_tour(Day_prp prp)
   {
       MyConnection Mycon = new MyConnection();
       DataTable dt = new DataTable();
       try { 

           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.CommandText = "[control_TourDD]";
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

   public DataTable displayday(Day_prp prp)
   {
       MyConnection Mycon = new MyConnection();

       DataTable dt = new DataTable();
       try
       {
           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.CommandText = "[control_DayDisplay]";

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

   public DataTable displaynote(Day_prp prp)
   {
       MyConnection Mycon = new MyConnection();

       DataTable dt = new DataTable();
       try
       {
           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.CommandText = "[control_NoteDisplay]";

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

   public DataTable displaylist()
   {

       MyConnection Mycon = new MyConnection();
       DataTable dt = new DataTable();
       try
       {
           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.CommandText = "[control_Day_list]";

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

   public DataTable displaylist1()
   {

       MyConnection Mycon = new MyConnection();
       DataTable dt = new DataTable();
       try
       {
           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.CommandText = "[control_Note_list]";

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

   public virtual int deletedaydata(Day_prp prp)
   {
       MyConnection Mycon = new MyConnection();
       try
       {

           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.Connection = Mycon.con;
           Mycon.adp.SelectCommand.CommandText = "[control_day_delete]";
           Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;

           Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);



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


   public virtual int deletenotedata(Day_prp prp)
   {
       MyConnection Mycon = new MyConnection();
       try
       {

           Mycon.adp.SelectCommand.Parameters.Clear();
           Mycon.adp.SelectCommand.Connection = Mycon.con;
           Mycon.adp.SelectCommand.CommandText = "[control_note_delete]";
           Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;

           Mycon.adp.SelectCommand.Parameters.AddWithValue("@tour_id", prp.tour_id);



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