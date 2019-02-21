using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings[Login_edt.Text] != Password_edt.Text)
        {
            Error_lb.Text = "Wrong login or password";
            return;
        }
        else
        {
            FormsAuthentication.SetAuthCookie(Login_edt.Text, false);
            Response.Redirect("admin/default.aspx");
        }
    }
}