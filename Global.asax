<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    public void Application_BeginRequest(object sender, EventArgs e)
    {
        string sPath = Context.Request.Path;
        //To overcome Postback issues, stored the real URL.
        String WebsiteURL = Request.Url.ToString();
        String[] SplitedURL = WebsiteURL.Split('/');
        String[] Temp = SplitedURL[SplitedURL.Length - 1].Split('.');

        // This is for aspx page
        if (!WebsiteURL.Contains(".aspx") && Temp.Length == 1)
        {
            if (!string.IsNullOrEmpty(Temp[0].Trim()))
                if (Temp.Length == 1)
                {
                    Context.RewritePath(Temp[0] + ".aspx");
                }

        }
        if (WebsiteURL.Contains(".aspx"))
        {
            return;
        }

        if (sPath.Contains("/admin/"))
            return;

        Context.Items["VirtualURL"] = sPath;
        Regex oReg;
        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        xmlDoc.Load(Server.MapPath("~/XML/XMLFile.xml"));
        System.Xml.XmlNode _oRules;
        _oRules = xmlDoc.DocumentElement;
        foreach (System.Xml.XmlNode oNode in _oRules.SelectNodes("rule"))
        {
            oReg = new Regex(oNode.SelectSingleNode("url/text()").Value);
            Match oMatch = oReg.Match(sPath);
            if (oMatch.Success)
            {
                sPath = oReg.Replace(sPath,
                  oNode.SelectSingleNode("rewrite/text()").Value);
                break;
            }
        }
        Context.RewritePath(sPath);
    }


</script>
