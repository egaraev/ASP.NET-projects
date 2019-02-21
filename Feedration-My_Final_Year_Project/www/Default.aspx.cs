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
using System.Web.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string role = "";
        string user = "";
        string password = "";
        int ID = 0;

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT U.ID as ID,U.LOGIN AS LOGIN,U.PASSWORD AS PASSWORD, UG.NAME AS ROLE FROM USERS U, USER_GROUP UG WHERE U.LOGIN=@LOGIN AND U.PASSWORD=@PASSWORD AND U.USER_GROUP_ID=UG.ID";
            comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
            comm.Parameters["@PASSWORD"].Value = Password_edt.Text;
            comm.Parameters.Add("@LOGIN", SqlDbType.NVarChar);
            comm.Parameters["@LOGIN"].Value = Login_edt.Text;
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    ID = Convert.ToInt32(reader["ID"]);
                    user = reader["LOGIN"].ToString();
                    password = reader["PASSWORD"].ToString();
                    role = reader["ROLE"].ToString();
                
                   
                  //  else
                  //  FormsAuthentication.RedirectFromLoginPage(Login_edt.Text, false);
                }
            }
            else
            {
                 Error_lb.Text = "Wrong login or password";
                return;
            }
            string InfoString = ID.ToString() + "|" + user + "|" + role + "|" + DateTime.Now + "|" + Request.UserHostName + "|";
            FormsAuthentication.SetAuthCookie(InfoString, false);
            if (Request.QueryString["ReturnURL"] == null)
            {
                if (role == "administrator")
                    Response.Redirect("Admin.aspx");
                if (role == "farmer")
                    Response.Redirect("Farmer.aspx");
                if (role == "takecarer")
                    Response.Redirect("Takecarer.aspx");
            }
            else
                FormsAuthentication.RedirectFromLoginPage(InfoString, false);
           
                
                

//                Response.Redirect("default.aspx");
           
        }
       
       
    }
}