using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Text;

public partial class enquiry : System.Web.UI.Page
{
    string target = string.Empty;
    string strCountry = string.Empty;
    string strCity = string.Empty;
    string strLatitude = string.Empty;
    string strLongitude = string.Empty;
    string strIP = string.Empty;
    string HTMLBody;
    query_prp prp = new query_prp();
    query_bal bal = new query_bal();
    MyConnection Mycon = new MyConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindItenary("17");
            //BindSeason();
        }
    }
    public void BindSeason()
    {
        try
        {
            DataTable dt = new DataTable();
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandType = CommandType.Text;
            Mycon.adp.SelectCommand.CommandText = @"select '0' as DepartureID,'--Select--' as YearName from tbl_TrainDepartureDates_Master union select YearName,YearName from tbl_TrainDepartureDates_Master where TrainName=17 and Itienrary='" + ddltourTpe.SelectedValue + "'";
            Mycon.adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlSeason.DataSource = dt;
                ddlSeason.DataTextField = "YearName";
                ddlSeason.DataValueField = "DepartureID";
                ddlSeason.DataBind();
            }
            else
            {
                ddlSeason.DataSource = null;
                ddlSeason.DataBind();
            }
        }
        catch { }
    }
    public void BindItenary(string id)
    {
        try
        {
            DataTable dt = new DataTable();
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.SelectCommand.Connection = Mycon.con;
            Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            Mycon.adp.SelectCommand.CommandText = "[BindItinerary_TrainWise]";
            Mycon.adp.SelectCommand.Parameters.AddWithValue("@TrainId", id);
            Mycon.adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddltourTpe.DataSource = dt;
                ddltourTpe.DataTextField = "ItineraryName";
                ddltourTpe.DataValueField = "ItineraryID";
                ddltourTpe.DataBind();
            }
            else
            {
                ddltourTpe.DataSource = null;
                ddltourTpe.DataBind();
            }
        }
        catch { }
    }
    public void BindMonth()
    {
        try
        {
            DataTable dt = new DataTable();
            Mycon.adp.SelectCommand.CommandType = CommandType.Text;
            Mycon.adp.SelectCommand.CommandText = "select MonthName,MonthName from dbo.tbl_TrainDepartureDates_Master where TrainName=17 and Itienrary='" + ddltourTpe.SelectedValue + "' and YearName ='" + ddlSeason.SelectedItem.Text + "' order by OrderId";
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlMonths.DataSource = dt;
                ddlMonths.DataTextField = "MonthName";
                ddlMonths.DataValueField = "MonthName";
                ddlMonths.DataBind();
                ddlMonths.Items.Insert(0, "Select");
            }
        }
        catch { }
    }
    public void BindDay(string MonthName)
    {
        try
        {
            string days = "";
            DataTable dt = new DataTable();
            Mycon.adp.SelectCommand.CommandType = CommandType.Text;
            Mycon.adp.SelectCommand.CommandText = "select MultiDates from dbo.tbl_TrainDepartureDates_Master where MonthName like '%" + MonthName + "%' and Itienrary='" + ddltourTpe.SelectedValue + "' order by DepartureID asc";
            Mycon.adp.SelectCommand.Parameters.Clear();
            Mycon.adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                string datecheck = dt.Rows[i]["MultiDates"].ToString();
                    DataTable dtnav = new DataTable();
                    Mycon.adp.SelectCommand.CommandType = CommandType.Text;
//                    Mycon.adp.SelectCommand.CommandText = "select Item from luxettrrain.SplitDayString('" + dt.Rows[i]["MultiDates"].ToString() + "',',')";
                    Mycon.adp.SelectCommand.CommandText = "select Item from dbo.SplitDayString('" + datecheck + "',',')";
				    Mycon.adp.SelectCommand.Parameters.Clear();
                    Mycon.adp.Fill(dtnav);
                    if (dtnav.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtnav.Rows.Count; j++)
                        {
                            Mycon.open();
                            Mycon.cmd.CommandType = CommandType.Text;
                            Mycon.cmd.CommandText = "insert into tbl_TempMultiDates(MultiDates)values('" + dtnav.Rows[j]["Item"].ToString() + "')";
                            Mycon.cmd.ExecuteNonQuery();
                            Mycon.close();
                        }
                    }
                }
                DataTable dtnavv = new DataTable();
                Mycon.adp.SelectCommand.CommandType = CommandType.Text;
                Mycon.adp.SelectCommand.CommandText = "select  Left(MultiDates,2) as MultiDates from dbo.tbl_TempMultiDates  where MultiDates<>'' order by convert(datetime, MultiDates, 103) ASC";
                Mycon.adp.SelectCommand.Parameters.Clear();
                Mycon.adp.Fill(dtnavv);
                if (dtnavv.Rows.Count > 0)
                {
                    ddlReservationDate.DataSource = dtnavv;
                    ddlReservationDate.DataTextField = "MultiDates";
                    ddlReservationDate.DataValueField = "MultiDates";
                    ddlReservationDate.DataBind();
                    ddlReservationDate.Items.Insert(0, "--Select--");

                    Mycon.open();
                    Mycon.cmd.CommandType = CommandType.Text;
                    Mycon.cmd.CommandText = "delete from tbl_TempMultiDates";
                    Mycon.cmd.ExecuteNonQuery();
                    Mycon.close();
                }
                else
                {
                    ddlReservationDate.DataSource = null;
                    ddlReservationDate.DataBind();

                    Mycon.open();
                    Mycon.cmd.CommandType = CommandType.Text;
                    Mycon.cmd.CommandText = "delete from tbl_TempMultiDates";
                    Mycon.cmd.ExecuteNonQuery();
                    Mycon.close();
                }
            }
        }
        catch { }
    }
    protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMonth();
        ddlMonths.SelectedIndex = 0;
    }
    protected void tourTpe_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSeason();
        ddlSeason.SelectedIndex = 0;
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (ddltourTpe.SelectedIndex == 0)
        {
            ddltourTpe.Style.Add("border-bottom", "2px solid red");
            ddltourTpe.Focus();
            return;
        }
        else
        {
            ddltourTpe.Style.Add("border-bottom", "");
        }
        if (ddlSeason.SelectedIndex == 0)
        {         
            ddlSeason.Style.Add("border-bottom", "2px solid red");
            ddlSeason.Focus();
            return;
        }
        else
        {
            ddlSeason.Style.Add("border-bottom", "");
        }
        if (ddlMonths.SelectedIndex == 0)
        {          
            ddlMonths.Style.Add("border-bottom", "2px solid red");
            ddlMonths.Focus();
            return;
        }
        else
        {
            ddlMonths.Style.Add("border-bottom", "");
        }
        if (ddlReservationDate.SelectedIndex == 0)
        {
            ddlReservationDate.Style.Add("border-bottom", "2px solid red");
            ddlReservationDate.Focus();
            return;
        }
        else
        {
            ddlReservationDate.Style.Add("border-bottom", "");
        }
        if (ddlareacode.SelectedIndex == 0)
        {
            ddlareacode.Style.Add("border-bottom", "2px solid red");
            ddlareacode.Focus();
            return;
        }
        else
        {
            ddlareacode.Style.Add("border-bottom", "");
        }
        if (ddlrooms.SelectedIndex == 0)
        {
            ddlrooms.Style.Add("border-bottom", "2px solid red");
            ddlrooms.Focus();
            return;
        }
        else
        {
            ddlrooms.Style.Add("border-bottom", "");
        }
        if (ddlclassac.SelectedIndex == 0)
        {
            ddlclassac.Style.Add("border-bottom", "2px solid red");
            ddlclassac.Focus();
            return;
        }
        else
        {
            ddladult1.Style.Add("border-bottom", "");
        }
        if (ddladult1.SelectedIndex == 0)
        {
            ddladult1.Style.Add("border-bottom", "2px solid red");
            ddladult1.Focus();
            return;
        }
        else
        {
            ddladult1.Style.Add("border-bottom", "");
        }
        if (ddlTitle.SelectedIndex == 0)
        {
            ddlTitle.Style.Add("border-bottom", "2px solid red");
            ddlTitle.Focus();
            return;
        }
        else
        {
            ddlTitle.Style.Add("border-bottom", "");
        }
        if (txtfirstName.Text == "")
        {
            txtfirstName.Style.Add("border-bottom", "2px solid red");
            txtfirstName.Focus();
            return;
        }
        else
        {
            txtfirstName.Style.Add("border-bottom", "");
        }
        
        if (ddlnationality.SelectedIndex == 0)
        {
            ddlnationality.Style.Add("border-bottom", "2px solid red");
            ddlnationality.Focus();
            return;
        }
        else
        {
            ddlnationality.Style.Add("border-bottom", "");
        }
        if (ddlcountry.SelectedIndex == 0)
        {
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Country');", true);
            ddlcountry.Style.Add("border-bottom", "2px solid red");
            ddlcountry.Focus();
            return;
        }
        else
        {
            ddlcountry.Style.Add("border-bottom", "");
        }

        if (txtmobNo.Text == "")
        {
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Mobile No.');", true);
            txtmobNo.Style.Add("border-bottom", "2px solid red");
            txtmobNo.Focus();
            return;
        }
        else
        {
            txtmobNo.Style.Add("border-bottom", "");
        }
        if (txtemail.Text == "")
        {            
            txtemail.Style.Add("border-bottom", "2px solid red");
            txtemail.Focus();
            return;
        }
        else
        {
            txtemail.Style.Add("border-bottom", "");
        }
        string pattern = null;
        pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        if (Regex.IsMatch(txtemail.Text, pattern))
        {
            LbltxtEmail.Style.Add("display", "none");
            txtemail.Style.Add("border-bottom", "");
        }
        else
        {
            LbltxtEmail.Style.Add("display", "block");
            txtemail.Style.Add("border-bottom", "2px solid red");
            txtemail.Focus();
            return;
        }
       if (Validate())
       {
           string checkList = string.Empty;
           for (int n = 0; n < chkList.Items.Count; n++)
           {
               if (chkList.Items[n].Selected)
               {
                   checkList += chkList.Items[n].Value + ",";
               }
           }
          getip();
           prp.queryfor = "Majestic Tourist Train";
           prp.querydest = txtrirtlspecial_Req.Text;
           prp.arrival_date = ddlReservationDate.SelectedItem.Text;
           prp.dep_date = "";
           prp.t_adults = ddladult1.SelectedItem.Text;
          // prp.t_Accabin = ddlclassac.SelectedItem.Text;
           prp.t_childs = ddlchild1.SelectedItem.Text;
           prp.t_infants = ddlInfents.SelectedItem.Text;
           prp.t_dblroom = ddlrooms.SelectedItem.Text;
           prp.t_sglroom = "";
           prp.t_extrabeds = "";
           prp.bgt_crncy = "";
           prp.bgt_amt = "";
           prp.planreq = checkList;
           prp.name = txtfirstName.Text;
           prp.gender = "";
           prp.address = "";
           prp.city = "";
           prp.state = "";
           prp.country = ddlcountry.SelectedItem.Text;
           prp.pincode = "";
           prp.phno = ddlareacode.SelectedItem.Text;
           prp.mblno = txtmobNo.Text;
           prp.email = txtemail.Text;
           prp.ipadress = strIP;
           prp.ipcountry = strCountry;
           prp.ipcity = strCity;
           prp.iplong = strLongitude;
           prp.iplat = strLatitude;
           int i = bal.insert_query(prp);
           if (i > 0)
           {
               try
               {
                   mailfun();
                   Autoresponse();
                   System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your booking request has been received and you will receive a reply shortly from sales@luxetrains.com');", true);
                   clearControle();
               }
               catch { }
           }
           else
           {
               
           }
       }
       else
       {
           ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Invalid Captcha!!!');", true);
           //ScriptManager.RegisterStartupScript(this, GetType(), " Message", "alert('Invalid Captcha!!!');", true);
           //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Invalid Captcha!!!');", true);
       }
    }
    public void clearControle()
    {
        try
        {
            //txtaddress.Text = "";
            txtemail.Text = "";
            txtfirstName.Text = "";
            txtlastName.Text = "";
            txtmobNo.Text = "";
            txtrirtlspecial_Req.Text = "";
            ddlTitle.SelectedIndex = 0;
            ddltourTpe.SelectedIndex = 0;
            try
            {
                ddlSeason.SelectedIndex = 0;
            }
            catch { }
            try
            {
                ddlMonths.SelectedIndex = 0;
            }
            catch { }
            try
            {
                ddlReservationDate.SelectedIndex = 0;
            }
            catch { }
            ddladult1.SelectedIndex = 0;
            ddlclassac.SelectedIndex = 0;
            ddlInfents.SelectedIndex = 0;
            ddlchild1.SelectedIndex = 0;
            ddlareacode.SelectedIndex = 0;
            ddlcountry.SelectedIndex = 0;
            ddldietaryRequirements.SelectedIndex = 0;
            ddlnationality.SelectedIndex = 0;
            ddlrooms.SelectedIndex = 0;
        }
        catch { }
    }
    protected void HTMLData(string Name, string Value)
    {
        HTMLBody += "<b>" + Name + "</b> : " + Value + "<br>";
    }
    void mailfun()
    {
        try
        {
            string checkList = string.Empty;
            for (int n = 0; n < chkList.Items.Count; n++)
            {
                if (chkList.Items[n].Selected)
                {
                    checkList += chkList.Items[n].Value + ",";
                }
            }
            string Body = null;
            //MailMessage mail = new MailMessage("sales@luxetrains.com", "sales@luxetrains.com"); 
            MailMessage mail = new MailMessage();
            MailAddress from = new MailAddress("noreply@majestictrainindia.com", "Majestic Tourist Train");
            MailAddress to = new MailAddress("enquiry@majestictrainindia.com");
            mail.From = from;
            mail.To.Add(to);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.majestictrainindia.com";
            smtp.Credentials = new NetworkCredential("noreply@majestictrainindia.com", "D3u$3$tm@gn@");
            smtp.EnableSsl = false;
            smtp.Port = 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            mail.Subject = "Enquiry from Majestic Tourist Train";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            //Body = htmlemailbody(ddlSeason.SelectedItem.Text, ddltourTpe.SelectedItem.Text, ddlReservationDate.SelectedItem.Text, ddlrooms.SelectedItem.Text, ddlcabinroom1.SelectedItem.Text, ddladult1.SelectedItem.Text, ddlchild1.SelectedItem.Text, ddlTitle.SelectedItem.Text + " " + txtfirstName.Text + " " + txtlastName.Text, ddlnationality.SelectedItem.Text, ddlcountry.SelectedItem.Text, txtaddress.Text, txtmobNo.Text, txtemail.Text, ddldietaryRequirements.SelectedItem.Text, txtrirtlspecial_Req.Text);
            Body = this.PopulateBody(ddltourTpe.SelectedItem.Text, ddlSeason.SelectedItem.Text, ddlMonths.SelectedItem.Text, ddlReservationDate.SelectedItem.Text, ddlrooms.SelectedItem.Text, ddlInfents.SelectedItem.Text, ddlclassac.SelectedItem.Text, ddladult1.SelectedItem.Text, ddlchild1.SelectedItem.Text, checkList, txtDiscountCoupon.Text, ddlTitle.SelectedItem.Text, txtfirstName.Text, ddlnationality.SelectedItem.Text, ddlcountry.SelectedItem.Text, ddlareacode.SelectedItem.Text, txtmobNo.Text, txtemail.Text, ddldietaryRequirements.SelectedItem.Text, txtrirtlspecial_Req.Text, strIP, strCountry, strCity, strLongitude, strLatitude);
            mail.Body = Body;
            smtp.Send(mail);
            //Autoresponse();
        }
        catch { }
    }
    protected void Autoresponse()
    {
        try
        {
            string email = txtemail.Text;
            //if (email.Contains("gmail.com") == true)
            //{
            //    sendsmsandmessage(email);
            //}
            //else
            //{
            MailMessage mail = new MailMessage();
            MailAddress from = new MailAddress("noreply@majestictrainindia.com", "Majestic Tourist Train");
            MailAddress to = new MailAddress(email);
            mail.From = from;
            mail.To.Add(to);
            SmtpClient oSmtp = new SmtpClient();
            oSmtp.Host = "mail.majestictrainindia.com";
            oSmtp.Credentials = new NetworkCredential("noreply@majestictrainindia.com", "D3u$3$tm@gn@");
            oSmtp.EnableSsl = false;
            oSmtp.Port = 25;
            string confirm = "Auto-Response to Enquiry from Majestic Tourist Train";
            mail.Subject = confirm;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            HTMLBody1 = string.Empty;
            HTMLData1("This message was created by Majestic Tourist Train Site Administration");
            HTMLData1("*** PLEASE DO NOT REPLY TO THIS MESSAGE *** ");
            HTMLData1("Your enquiry has been submitted successfully!");
            HTMLData1("Our sales team, sales@luxetrains.com, will revert back to you very shortly...");
			HTMLData1("In case you don't find our e-mail in your inbox, please check your spam/junk folder as well.");
            HTMLData1("Thank You & Have a Nice Day!");
            HTMLData1("Yours Sincerely,");
            HTMLData1("Majestic Tourist Train");
            HTMLData1("www.majestictrainindia.com");
            mail.Body = HTMLBody1;
            oSmtp.Send(mail);
            //}
        }
        catch (Exception EX)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('" + EX.Message.ToString() + "');", true);
        }
    }
    string HTMLBody1;
    protected void HTMLData1(string Name)
    {
        HTMLBody1 += "<b>" + Name + "</b> " + "<br>";
    }
/*    private void sendsmsandmessage(string email)
    {
        try
        {
            string checkList = string.Empty;
            for (int n = 0; n < chkList.Items.Count; n++)
            {
                if (chkList.Items[n].Selected)
                {
                    checkList += chkList.Items[n].Value + ",";
                }
            }
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("noreply@palace-onwheels.com", "Palace on Wheels");
            mail.Subject = "Auto-Response to Enquiry from Palace on Wheels";
            string Body = null;
            //Body = htmlemailbody(txtname.Text, txtmob.Text, txtemail.Text, txtcountry.Text, txtplan.Text, ddcurrency.SelectedItem.Text,ddamt.SelectedItem.Text);
            Body = this.PopulateBody(ddlSeason.SelectedItem.Text, ddlMonths.SelectedItem.Text, ddlReservationDate.SelectedItem.Text, ddlrooms.SelectedItem.Text, ddlInfents.SelectedItem.Text, ddladult1.SelectedItem.Text, ddlchild1.SelectedItem.Text, checkList, txtDiscountCoupon.Text, ddlTitle.SelectedItem.Text, txtfirstName.Text, txtlastName.Text, ddlnationality.SelectedItem.Text, ddlcountry.SelectedItem.Text, txtmobNo.Text, txtemail.Text, ddldietaryRequirements.SelectedItem.Text, txtrirtlspecial_Req.Text, strIP, strCountry, strCity, strLongitude, strLatitude);
            HTMLBody1 = string.Empty;
            HTMLData1("This message was created by Palace on Wheels Site Administration");
            HTMLData1("*** PLEASE DO NOT REPLY TO THIS MESSAGE ***");
            HTMLData1("Your enquiry has been submitted successfully!");
            HTMLData1("We will revert back to you very shortly...");
            HTMLData1("Thank You & Have a Nice Day!");
            HTMLData1("Yours Sincerely,");
            HTMLData1("Palace on Wheels");
            HTMLData1("http://palace-onwheels.com/");
            HTMLData1("<b>Legal Disclaimer :</b> This Website/ E-mail are vulnerable to data corruption, interception, tampering, viruses as well as  delivery errors and we do not accept liability for any consequence that may arise there from.");
            //mail.Body = HTMLBody1;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("noreply.luxetrains@gmail.com", "Admin_@#123");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message.ToString() + "');", true);
        }
    }*/
    private string PopulateBody(string Journey, string TravelSeason, string TravelMonth, string DepartureDate, string NoofRooms, string Cabin, string Accabin, string Adult, string Child, string AdditionalServices, string vouchercode, string Title, string FirstName, string Nationality, string Country, string Areacode, string MobileNo, string EmailID, string DietaryRequirements, string OtherInformation, string strIP, string strCountry, string strCity, string strLongitude, string strLatitude)
    {
        //getip();
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailBody.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{PackageTours}", Journey);
        body = body.Replace("{TravelSeason}", TravelSeason);
        body = body.Replace("{TravelMonths}", TravelMonth);
        body = body.Replace("{DepartureDate}", DepartureDate);
        body = body.Replace("{NoofRooms}", NoofRooms);
        body = body.Replace("{Cabin}", "");
        body = body.Replace("{Accabin}", Accabin);
        body = body.Replace("{Adult}", Adult);
        body = body.Replace("{Child}", Child);
        body = body.Replace("{Infents}", Cabin);
        body = body.Replace("{AdditionalServices}", AdditionalServices);
        body = body.Replace("{vouchercode}", vouchercode);
        body = body.Replace("{Title}", Title);
        body = body.Replace("{FirstName}", FirstName);
        body = body.Replace("{Nationality}", Nationality);
        body = body.Replace("{Country}", Country);
        //body = body.Replace("{Address}", Address);
        body = body.Replace("{Areacode}", Areacode);
        body = body.Replace("{MobileNo}", MobileNo);
        body = body.Replace("{EmailID}", EmailID);
        body = body.Replace("{DietaryRequirements}", DietaryRequirements);
        body = body.Replace("{Specialrequirements}", OtherInformation);
        body = body.Replace("{strIP}", strIP);
        body = body.Replace("{strCountry}", strCountry);
        body = body.Replace("{strCity}", strCity);
        body = body.Replace("{strLatitude}", strLatitude);
        body = body.Replace("{strLongitude}", strLongitude);
        return body;
    }
    private string htmlemailbody(string Journey, string TravelSeason, string PackageTours, string DepartureDate, string NoofRooms, string Cabin, string Accabin, string Adult, string Child, string Name, string Nationality, string Country, string Address, string Areacode, string MobileNo, string EmailID, string DietaryRequirements, string OtherInformation)
    {
        StringBuilder body = new StringBuilder();        
        body.Append(" <span >Enquiry from <span >Luxe Train</span><SPAN style=\"COLOR: rgb(0,0,0)\"><B>:</B></SPAN></span><BR><BR>");
        body.Append(" <SPAN style=\"COLOR: rgb(0,0,0)\"><B> Name : ");
        body.Append("</B></SPAN>" + Name + "<BR><SPAN ");        
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Date : </B><SPAN");
        body.Append(" </B></SPAN>" + System.DateTime.Now.ToString("dd/MMM/yyyy") + " <BR><SPAN");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Ip : </B><SPAN");
        body.Append(" </B></SPAN>" + strIP + " <BR><SPAN");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Country : </B><SPAN");
        body.Append(" </B></SPAN>" + strCountry + " <BR><SPAN");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>City : </B><SPAN");
        body.Append(" </B></SPAN>" + strCity + " <BR><SPAN");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Latitude : </B><SPAN");
        body.Append(" </B></SPAN>" + strLatitude + " <BR><SPAN");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Longitude : </B><SPAN");
        body.Append(" </B></SPAN>" + strLongitude + " <BR><SPAN");
        body.Append("<BR>Regard's<BR/></DIV><DIV>");
        body.Append("<A style=\"COLOR: rgb(51,102,255);font-weight:bold;\"  href=\"http://www.majestictrainindia.com/\" target=_blank>Buddhist Circuit  Tourist Train</A><BR/><BR/><b>Legal Disclaimer :</b> This Website/ E-mail are");
        body.Append("  vulnerable to data corruption, interception, tampering, viruses as well as  delivery errors and we do not accept liability for any consequence that may arise there from. <BR><BR></DIV></TD></TR></TBODY></TABLE> ");
        return body.ToString();

    }
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindDay(ddlMonths.SelectedValue);
            ddlReservationDate.SelectedIndex = 0;
        }
        catch { }
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        clearControle();
    }
    protected void getip()
    {
        string myIP = HttpContext.Current.Request.UserHostAddress;
        string strQuery;
        HttpWebRequest HttpWReq;
        HttpWebResponse HttpWResp;

        strQuery = "https://extreme-ip-lookup.com/json/" + myIP;
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        HttpWReq = (HttpWebRequest)WebRequest.Create(strQuery);
        HttpWReq.Method = "GET";
        HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();

        System.IO.StreamReader reader = new System.IO.StreamReader(HttpWResp.GetResponseStream());
        string content = reader.ReadToEnd();

        dynamic item = serializer.Deserialize<object>(content);

        strIP = myIP;
        strCountry = item["country"];
        strCity = item["city"];
        strLatitude = item["lat"];
        strLongitude = item["lon"];

    }

    public class MyObject
    {
        public string success { get; set; }
    }
    public bool Validate()
    {
        var secret = "6LdfsmoUAAAAANITEqX_qx0rVTI7fXk9RQtcRqGN";
        string url = "https://www.google.com/recaptcha/api/siteverify";
        WebRequest request = WebRequest.Create(url);
        string postData = string.Format("secret={0}&response={1}&remoteip={2}", secret, Request["g-recaptcha-response"], Request.UserHostAddress);

        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = postData.Length;

        StreamWriter writer = new StreamWriter(request.GetRequestStream());
        writer.Write(postData);
        writer.Close();

        using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
        {
            string responseData = reader.ReadToEnd();

            if (!responseData.Contains("\"success\": false"))
                return true;
        }

        return true;
    }
}