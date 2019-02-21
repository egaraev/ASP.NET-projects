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
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Request.Url.PathAndQuery);
            return;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"SELECT U.ID, U.ROLESID, U.NAME+' '+U.SURNAME AS INITIALS, R.ROLESNAME 
                    FROM USERS U, ROLES R WHERE U.ROLESID=R.ID AND LOGIN=@LOGIN AND PASSWORD=@PASSWORD";

                Comm.Parameters.Add("@LOGIN", SqlDbType.NVarChar);
                Comm.Parameters["@LOGIN"].Value = Login_edt.Text;

                Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
                Comm.Parameters["@PASSWORD"].Value = Password_edt.Text;

                Conn.Open();

                string Role = "";
                int RoleID = 0;
                string FIO = "";
                int ID = 0;

                try
                {
                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        ID = Convert.ToInt32(reader[0].ToString());
                        RoleID = Convert.ToInt32(reader[1].ToString());
                        FIO = reader[2].ToString();
                        Role = reader[3].ToString();
                    }
                    else
                    {
                        Error_lb.Text = "Неправильный логин или пароль";
                        return;
                    }
                    reader.Close();
                }
                catch (Exception E)
                {
                    Error_lb.Text = "Ошибка";
                    return;
                }

                string InfoString = ID.ToString() + "|" + FIO + "|" + Role + "|" + RoleID + "|" + DateTime.Now + "|" + Request.UserHostName + "|";

                FormsAuthentication.SetAuthCookie(InfoString, false);

                if (Request.QueryString["ReturnUrl"] == null)
                {
                    Response.Redirect("Products.aspx");
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(InfoString, false);
                }
            }
        }
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
        }
    }
}