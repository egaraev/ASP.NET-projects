using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for AuthCookieParse
/// </summary>
public class AuthCookieParce
{
    public static int UserID(string UserString)
    {
        Regex Regul = new Regex(@"\||\|");
        return Convert.ToInt32(Regul.Split(UserString)[0]);
    }

    public static string UserFIO(string UserString)
    {
        Regex Regul = new Regex(@"\||\|");
        return Regul.Split(UserString)[1];
    }

    public static string UserRole(string UserString)
    {
        Regex Regul = new Regex(@"\||\|");
        return Regul.Split(UserString)[2];
    }

    public static int UserRoleID(string UserString)
    {
        Regex Regul = new Regex(@"\||\|");
        return Convert.ToInt32(Regul.Split(UserString)[3]);
    }

    public static int UserInDate(string UserString)
    {
        Regex Regul = new Regex(@"\||\|");
        return Convert.ToInt32(Regul.Split(UserString)[4]);
    }

    public static int UserHostName(string UserString)
    {
        Regex Regul = new Regex(@"\||\|");
        return Convert.ToInt32(Regul.Split(UserString)[5]);
    }
}