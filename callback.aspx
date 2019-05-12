<%@ Page Language="C#" AutoEventWireup="true" CodeFile="callback.aspx.cs" Inherits="maharajas_callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />

    
<style>
body{font:12px arial;}
.contact_form .row{margin:10px 10px;}
   .g-recaptcha iframe {
    width: 220px;
}
</style>
</head>
<body>
    <form id="form1" runat="server" class="contact_form">
   <div class="required_t" style="width:100%">* Indicates Required Field</div>

				<div class="row">
                  <label><B>Name</B><span class="required">*</span></label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="txtfld" placeholder="Full Name"></asp:TextBox>            
                </div>
				 <div class="row">
                  <label><B>Mobile</B><span class="required">*</span></label>
                     <asp:TextBox ID="txtContact" runat="server" CssClass="txtfld" placeholder="Mobile No."></asp:TextBox> 
                </div>
                <div class="row">
                  <label><B>Email</B><span class="required">*</span></label>  
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtfld" placeholder="Email"></asp:TextBox>                 
                </div> 
        <div class="row captcha">
                  <div class="g-recaptcha"
       data-sitekey="6LdfsmoUAAAAAKrbqvudJOWlxcUlTvp_JCNTxNdJ"
       data-callback="onSubmit"
       data-size="invisible">
  </div>
                </div>  
				<div class="row btn">
                    <asp:Button ID="btn_EnquiryMaster" runat="server" Text="Call Back" OnClick="btn_EnquiryMaster_Click" OnClientClick="return clientFunction()" CssClass="submit-btn"></asp:Button>
				 <!--  <input type="reset" class="button"  value="RESET" name="reset"> -->
				 
                </div>        
         <div class="row btn">
          
		  </div>
		  <input type="hidden" name="submitForm" value="insert" />
    </form>
      <script src=https://www.google.com/recaptcha/api.js></script>

</body>
</html>
