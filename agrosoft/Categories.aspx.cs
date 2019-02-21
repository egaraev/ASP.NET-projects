using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.Security;
using System.Configuration;
using System.Data;

public partial class Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Categories_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Categories_sds.SelectCommand = "SELECT ID, NAME FROM CATEGORIES WHERE ACTIVE='TRUE'";


        Categories_grid.DataSourceID = "Categories_sds";


        Panel1.Visible = true;
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "SELECT ID, NAME FROM CATEGORIES WHERE ACTIVE='TRUE'";
                SqlDataReader reader = Comm.ExecuteReader();
            }
            catch (SqlException E)
            {
                Error_lb.Text = E.Message;
                return;
            }

        }

    }



    protected void Categories_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editcategory")
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
                    Comm.CommandText = "SELECT ID, NAME FROM CATEGORIES WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Categories_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        Name_edt.Text = reader[1].ToString();
                        ViewState["id"] = Categories_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
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

        else if (e.CommandName == "Deletecategory")
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
                    Comm.CommandText = "UPDATE CATEGORIES SET ACTIVE='FALSE' WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Categories_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

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







    protected void Logout_btn_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
        return;
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
                Comm.CommandText = "INSERT INTO CATEGORIES (NAME,ACTIVE) VALUES (@NAME, 'TRUE')";
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Name_edt.Text.Trim();
                Comm.ExecuteNonQuery();
                Categories_grid.DataBind();

                Name_edt.Text = "";



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
                Comm.CommandText = "UPDATE CATEGORIES SET NAME=@NAME WHERE ID=@ID ";
                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ViewState["id"].ToString();
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Name_edt.Text.Trim().Replace("&nbsp;", "");



                Comm.ExecuteNonQuery();

                add_btn.Visible = true;
                cancel_btn.Visible = false;
                update_btn.Visible = false;
                Name_edt.Text = "";




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
}

