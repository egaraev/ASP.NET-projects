using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    private string USERFIO()
    {
        // Извлекаем куку с аутентификационными данными
        HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

        // Дешифруем ее в тикет
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

        // Создаем пользовательский контекст
        FormsIdentity identity = new FormsIdentity(ticket);


        //System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity, new string[] { AuthCookieParce.UserID(identity.Name).ToString() });
        return AuthCookieParce.UserFIO(identity.Name).ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        login_lb.Text = USERFIO();
    }
}
