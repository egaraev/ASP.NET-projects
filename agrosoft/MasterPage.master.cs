using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string name = "";

        if (Context.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            FormsIdentity identity = new FormsIdentity(ticket);
            name = AuthCookieParce.UserFIO(identity.Name);
        }
        else
        {
            Response.Redirect("Default.aspx");
            return;
        }
        if (name != "") 
        {
            welcome_lb.Text = string.Format("<marquee loop='1' behavior='slide' direction='left' style='color:#00aa00'>Добро пожаловать, {0}</marquee>", name);
        }
        
       
    }
}
