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
/// Summary description for carrer_dal
/// </summary>
public class carrer_dal
{
	public carrer_dal()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public virtual int insertcarrerdata(carrer_prp prp)
    {
        MyConnection Mycon = new MyConnection();
        try
        {
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandText = "[insercareerdata]";
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@name", prp.name);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@email", prp.email);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@phone", prp.mobile);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@src", prp.source);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@POS", prp.job);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@coverltr", prp.coverletter);
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@resume", prp.document);
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