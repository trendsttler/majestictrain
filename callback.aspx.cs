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
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;

public partial class maharajas_callback : System.Web.UI.Page
{
    MyConnection Mycon = new MyConnection();
    string target = string.Empty;
    string strCountry = string.Empty;
    string strCity = string.Empty;
    string strLatitude = string.Empty;
    string strLongitude = string.Empty;
    string strIP = string.Empty;
    string HTMLBody;
    query_prp prp = new query_prp();
    query_bal bal = new query_bal();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_EnquiryMaster_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter First Name');", true);
            txtName.Style.Add("border-bottom", "2px solid red");
            txtName.Focus();
            return;
        }
        else
        {
            txtName.Style.Add("border-bottom", "");
        }
        if (txtContact.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Mobile No.');", true);
            txtContact.Style.Add("border-bottom", "2px solid red");
            txtContact.Focus();
            return;
        }
        else
        {
            txtContact.Style.Add("border-bottom", "");
        }
        if (txtEmail.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Email ID');", true);
            txtEmail.Style.Add("border-bottom", "2px solid red");
            txtEmail.Focus();
            return;
        }
        else
        {
            txtEmail.Style.Add("border-bottom", "");
        }

        //this.mp1.Show();
        try
        {            
            if (Validate())
            {
                getip();
                prp.queryfor = "Majestic Tourist Train";
                prp.querydest = "";
                prp.arrival_date = System.DateTime.Now.ToString("dd/MMM/yyyy");
                prp.dep_date = "";
                prp.t_adults = "";
                prp.t_childs = "";
                prp.t_infants = "";
                prp.t_dblroom = "";
                prp.t_sglroom = "";
                prp.t_extrabeds = "";
                prp.bgt_crncy = "";
                prp.bgt_amt = "";
                prp.planreq = "";
                prp.name = txtName.Text;
                prp.gender = "";
                prp.address = "";
                prp.city = "";
                prp.state = "";
                prp.country = "";
                prp.pincode = "";
                prp.phno = "";
                prp.mblno = txtContact.Text;
                prp.email = txtEmail.Text;
                prp.ipadress = strIP;
                prp.ipcountry = strCountry;
                prp.ipcity = strCity;
                prp.iplong = strLongitude;
                prp.iplat = strLatitude;
                int i = bal.insert_query(prp);
                if (i > 0)
                {
                    mailfun();
                    Autoresponse();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your booking request has been received and you will receive a reply shortly from sales@luxetrains.com');", true);                   
                    ClearControle();                    
                    //this.mp1.Hide();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "uniqueId" + Guid.NewGuid(), "<script>alert('Invalid Captcha!!!');</script>", false); 
            }           
        }
        catch { ClearControle(); }
    }
    void ClearControle()
    {        
        txtContact.Text = "";
        txtName.Text = "";
        txtEmail.Text = "";       
    }
    protected void btn_ClearMaster_Click(object sender, EventArgs e)
    {
        //this.mp1.Show();
        txtContact.Text = "";
        txtName.Text = "";
        txtEmail.Text = "";
    }
    protected void HTMLData(string Name, string Value)
    {
        HTMLBody += "<span>" + Name + "</span> : " + Value + "<br>";
    }
    void mailfun()
    {
        try
        {
            getip();
            string Body = null;
            MailMessage mail = new MailMessage();
            MailAddress from = new MailAddress("noreply@buddhisttrainindia.com", "Majestic Tourist Train");
            MailAddress to = new MailAddress("enquiry@buddhisttrainindia.com");
            mail.From = from;
            mail.To.Add(to);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.buddhisttrainindia.com";
            smtp.Credentials = new NetworkCredential("noreply@buddhisttrainindia.com", "Majestic Tourist Train");
            smtp.EnableSsl = false;
            smtp.Port = 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            mail.Subject = "Enquiry from Majestic Tourist Train";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            Body = htmlemailbody(txtName.Text, txtContact.Text, txtEmail.Text, strIP,strCountry,strCity,strLongitude,strLatitude);
            mail.Body = Body;
            smtp.Send(mail);            
        }
        catch { }
    }
    protected void Autoresponse()
    {
        try
        {
            string email = txtEmail.Text;
            //if (email.Contains("gmail.com") == true)
            //{
            //    sendsmsandmessage(email);
            //    ClearControle();
            //}
            //else
            //{
                MailMessage mail = new MailMessage();
                MailAddress from = new MailAddress("noreply@buddhisttrainindia.com", "Majestic Tourist Train");
                MailAddress to = new MailAddress(email);
                mail.From = from;
                mail.To.Add(to);
                SmtpClient oSmtp = new SmtpClient();
                oSmtp.Host = "mail.buddhisttrainindia.com";
                oSmtp.Credentials = new NetworkCredential("noreply@buddhisttrainindia.com", "Majestic Tourist Train");
                oSmtp.EnableSsl = false;
                oSmtp.Port = 25;
                string confirm = "Auto-Response to Query from Majestic Tourist Train";
                mail.Subject = confirm;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                HTMLBody1 = string.Empty;
                HTMLData1("This message was created by Majestic Tourist Train Site Administration");
                HTMLData1("*** PLEASE DO NOT REPLY TO THIS MESSAGE *** ");
                HTMLData1("Your query has been submitted successfully!");
                HTMLData1("Our sales team (sales@luxetrains.com) will revert back to you very shortly...");
                 HTMLData1("In case you don't find our e-mail in your inbox, please check your spam/junk folder as well.");
                HTMLData1("Thank You & Have a Nice Day!");
                HTMLData1("Yours Sincerely,");
                HTMLData1("Majestic Tourist Train");
                HTMLData1("www.majestictrainindia.com");
                mail.Body = HTMLBody1;
                oSmtp.Send(mail);
                ClearControle();
            }
        //}
        catch (Exception EX) { EX.Message.ToString(); }
    }
    string HTMLBody1;
    protected void HTMLData1(string Name)
    {
        HTMLBody1 += "<b>" + Name + "</b> " + "<br>";
    }
    private void sendsmsandmessage(string email)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("noreply@luxetrains.com", "Luxe Train");
            mail.Subject = "Auto-Response to Query from Luxe Train";
            string Body = null;
            //Body = htmlemailbody(txtname.Text, txtmob.Text, txtemail.Text, txtcountry.Text, txtplan.Text, ddcurrency.SelectedItem.Text,ddamt.SelectedItem.Text);
            HTMLBody1 = string.Empty;
            HTMLData1("This message was created by Luxe Train Site Administration");
            HTMLData1("*** PLEASE DO NOT REPLY TO THIS MESSAGE *** ");
            HTMLData1("Your query has been submitted successfully!");
            HTMLData1("We will revert back to you very shortly...");
            HTMLData1("Thank You & Have a Nice Day!");
            HTMLData1("Yours Sincerely,");
            HTMLData1("Luxe Train");
            HTMLData1("http://luxetrains.com/");
            mail.Body = HTMLBody1;
            //mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("noreply.luxetrains@gmail.com", "Admin_@#123");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
           
        }
    }
    private string htmlemailbody(string Name, string Phoneno, string Email, string strIP, string strCountry, string strCity, string strLongitude, string strLatitude)
    {
        StringBuilder body = new StringBuilder();
        body.Append("<TABLE border=1 cellSpacing=0 cellPadding=0 width=650 bgColor=#ffffff align=center> <TBODY>");
        body.Append(" <TR><TD style=\"PADDING-LEFT: 15px; PADDING-RIGHT: 15px; FONT-FAMILY: Arial,Helvetica,sans-serif; COLOR: rgb(112,110,110); FONT-SIZE: 12px\" >");
        body.Append("<DIV> ");
        body.Append("<BR>");
        body.Append(" <span >Call Back from <span >Majestic Tourist Train</span><SPAN style=\"COLOR: rgb(0,0,0)\"><B>:</B></SPAN></span><BR><BR>");
        body.Append(" <SPAN style=\"COLOR: rgb(0,0,0)\"><B> Name : ");
        body.Append("</B></SPAN>" + Name + "<BR><SPAN ");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Email : </B><SPAN");
        body.Append(" </B></SPAN>" + Email + " <BR><SPAN");
        body.Append(" style=\"FONT-FAMILY: verdana; COLOR: rgb(0,0,0)\"><B>Mobile No : </B><SPAN");
        body.Append(" </B></SPAN>" + Phoneno + " <BR><SPAN");      
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
        body.Append(" </B></SPAN>" + strLongitude + " <BR><SPAN>");
        body.Append("</DIV><DIV>");
        body.Append("</DIV></TD></TR></TBODY></TABLE> ");
        return body.ToString();

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
