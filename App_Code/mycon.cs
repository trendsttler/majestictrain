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
using System.Web.Configuration;

/// <summary>
/// Summary description for mycon
/// </summary>
public class mycon
{
	public System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
    public System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter();
    public System.Data.SqlClient.SqlCommand cmd;
    public SqlTransaction trans;
    public System.Data.SqlClient.SqlCommandBuilder cb;
    public mycon()
    {
        
         cb = new System.Data.SqlClient.SqlCommandBuilder(adp);
        cmd = new System.Data.SqlClient.SqlCommand("", con);
        adp.SelectCommand = new System.Data.SqlClient.SqlCommand(" ", con);
        adp.UpdateCommand = new System.Data.SqlClient.SqlCommand(" ", con);
        adp.InsertCommand = new System.Data.SqlClient.SqlCommand(" ", con);
        adp.DeleteCommand = new System.Data.SqlClient.SqlCommand(" ", con);
    


        con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
    }

    public void open()
    {
        System.Data.ConnectionState state = default(System.Data.ConnectionState);
        state = con.State;
        if (state == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }

    }
    public void close()
    {
        System.Data.ConnectionState state = default(System.Data.ConnectionState);
        state = con.State;
        if (state == System.Data.ConnectionState.Open)
        {
            con.Close();
        }
    }
}