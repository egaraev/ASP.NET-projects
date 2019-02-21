using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Users_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Roles_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        Users_sds.SelectCommand = "SELECT  USERS.ID, USERS.NAME, USERS.SURNAME, USERS.LOGIN, USERS.PASSWORD, USERS.ROLESID, ROLES.ID, ROLES.ROLESNAME FROM USERS, ROLES WHERE ROLES.ID=USERS.ROLESID";    
        Users_grid.DataSourceID = "Users_sds";

        Roles_sds.SelectCommand = "SELECT ID, ROLESNAME FROM ROLES";
       

    }
    protected void Users_mgmt_Click(object sender, EventArgs e)
    {
        
        Panel1.Visible = true;
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "SELECT ID, ROLESID, NAME, SURNAME, LOGIN, PASSWORD FROM USERS";
                SqlDataReader reader = Comm.ExecuteReader();
            }
            catch (SqlException E)
            {
                Error_lb.Text = E.Message;
                return;
            }

        }


    }

    protected void Users_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editusr")
        {
            Panel1.Visible = true;
            using (SqlConnection Conn = new SqlConnection())
            {

                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "SELECT ID, ROLESID, NAME, SURNAME, LOGIN, PASSWORD FROM USERS WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Users_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        Name_edt.Text = reader[2].ToString();
                        Surname_edt.Text = reader[3].ToString();
                        Login_edt.Text = reader[4].ToString();
                        Password_edt.Text = reader[5].ToString();
                        ViewState["id"] = Users_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    }
                    else
                    {
                        Error_lb.Text = "Произошла ошибка";
                        return;
                    }
                    add_btn.Visible = false;
                    update_btn.Visible = true;
                    cancel_btn.Visible = true;

                }

                catch (SqlException E)
                {
                    Error_lb.Text = E.Message;
                    return;
                }
            }
        }

        else if (e.CommandName == "Deleteusr")
        {
            Panel1.Visible = true;
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM USERS WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Users_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();

                    Error_lb.ForeColor = Color.Green;
                    Error_lb.Text = "Данные удалены";
                }
                catch (SqlException E)
                {
                    Error_lb.Text = E.Message;
                    return;
                }
            }
        }


    }


    protected void add_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();
            Panel1.Visible = true;
            try
            {
                Comm.CommandText = "INSERT INTO USERS (ROLESID,NAME,SURNAME,LOGIN,PASSWORD) VALUES (@ROLESID,@NAME,@SURNAME,@LOGIN,@PASSWORD)";
                Comm.Parameters.Add("@ROLESID", SqlDbType.Int);
                Comm.Parameters["@ROLESID"].Value = Roles_ddl.SelectedValue;
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Name_edt.Text.Trim();
                Comm.Parameters.Add("@SURNAME", SqlDbType.NVarChar);
                Comm.Parameters["@SURNAME"].Value = Surname_edt.Text.Trim();
                Comm.Parameters.Add("@LOGIN", SqlDbType.NVarChar);
                Comm.Parameters["@LOGIN"].Value = Login_edt.Text.Trim();
                Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
                Comm.Parameters["@PASSWORD"].Value = Password_edt.Text.Trim();

                Comm.ExecuteNonQuery();
                Users_grid.DataBind();

                Name_edt.Text = "";
                Surname_edt.Text = "";
                Login_edt.Text = "";
                Password_edt.Text = "";


                Error_lb.ForeColor = Color.Green;
                Error_lb.Text = "Данные добавлены";
            }
            catch (SqlException E)
            {
                Error_lb.Text = E.Message;
                return;
            }
        }
    }


    protected void update_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();
            Panel1.Visible = true;
            try
            {
                Comm.CommandText = "UPDATE USERS SET ROLESID=@ROLESID,NAME=@NAME,SURNAME=@SURNAME,LOGIN=@LOGIN,PASSWORD=@PASSWORD WHERE ID=@ID ";
                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ViewState["id"].ToString();
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Name_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@SURNAME", SqlDbType.NVarChar);
                Comm.Parameters["@SURNAME"].Value = Surname_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@LOGIN", SqlDbType.NVarChar);
                Comm.Parameters["@LOGIN"].Value = Login_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
                Comm.Parameters["@PASSWORD"].Value = Password_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@ROLESID", SqlDbType.Int);
                Comm.Parameters["@ROLESID"].Value = Roles_ddl.SelectedValue;

                Comm.ExecuteNonQuery();

                add_btn.Visible = true;
                cancel_btn.Visible = false;
                update_btn.Visible = false;
                Name_edt.Text = "";
                Surname_edt.Text = "";
                Login_edt.Text = "";
                Password_edt.Text = "";

               

                Error_lb.ForeColor = Color.Green;
                Error_lb.Text = "Данные обновлены";
            }
            catch (SqlException E)
            {
                Error_lb.Text = E.Message;
                return;
            }
        }


    }
    protected void cancel_btn_Click(object sender, EventArgs e)
    {
        add_btn.Visible = true;
        cancel_btn.Visible = false;
        update_btn.Visible = false;
    }








    protected void Customers_mgmt_Click(object sender, EventArgs e)
    {
    
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "SELECT ID, ROLESID, NAME, SURNAME, LOGIN, PASSWORD FROM USERS";
                SqlDataReader reader = Comm.ExecuteReader();
            }
            catch (SqlException E)
            {
                Error_lb.Text = E.Message;
                return;
            }

        }


    }




    protected void Logout_btn_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
        return;
    }


}