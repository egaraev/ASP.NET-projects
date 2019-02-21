using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

public partial class admin_Contentheader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RU_lb.Text = "";
        AZ_lb.Text = "";
        RU_edt.Visible = true;
        AZ_edt.Visible = true;
        Error_lb.Text = "";
        Error_lb.ForeColor = Color.Red;
        Add_btn.Visible = true;
        int ID = 0;
        if (Request.QueryString["id"] != null)
        {
            try
            {
                ID = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch
            {
                Add_btn.Visible = false;
                RU_edt.Visible = false;
                AZ_edt.Visible = false;
                Error_lb.Text = "Неверный ID";
                return;
            }
        }
        else
        {
            RU_edt.Visible = false;
            AZ_edt.Visible = false;
            Add_btn.Visible = false;
            Error_lb.Text = "Неверный ID";
            return;
        }

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            Comm.CommandText = @"SELECT CONTENTRU, CONTENTAZ, NAMERU, NAMEAZ FROM HEADERS WHERE ID = @ID";
            Comm.Parameters.Add("@ID", SqlDbType.Int);
            Comm.Parameters["@ID"].Value = ID;


            SqlDataReader reader = Comm.ExecuteReader();

            if (reader.Read())
            {
                if (reader[2].ToString() == "")
                {
                    RU_lb.Text = "Нет названия заголовка";
                }
                else
                {
                    RU_lb.Text = reader[2].ToString();
                    if (!Page.IsPostBack)
                        if (reader[0].ToString() != "")
                            RU_edt.Html = reader[0].ToString();
                }

                if (reader[3].ToString() == "")
                {
                    AZ_lb.Text = "Нет названия заголовка";
                }
                else
                {
                    AZ_lb.Text = reader[3].ToString();
                    if (!Page.IsPostBack)
                        if (reader[1].ToString() != "")
                            AZ_edt.Html = reader[1].ToString();
                }
            }
            else
            {
                Add_btn.Visible = false;
                Error_lb.Text = "Ошибка нахождения данных";
            }

            reader.Close();
        }
    }
    protected void Add_btn_Click(object sender, EventArgs e)
    {
        int ID = 0;
        if (Request.QueryString["id"] != null)
        {
            try
            {
                ID = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch
            {
                Add_btn.Visible = false;
                Error_lb.Text = "Неверный ID";
                return;
            }
        }
        else
        {
            Add_btn.Visible = false;
            Error_lb.Text = "Неверный ID";
            return;
        }

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();
            Comm.CommandText = @"UPDATE HEADERS SET CONTENTRU = @CONTENTRU, CONTENTAZ = @CONTENTAZ WHERE ID = @ID";

            Comm.Parameters.Add("@CONTENTRU", SqlDbType.NVarChar);
            Comm.Parameters["@CONTENTRU"].Value = RU_edt.Html;

            Comm.Parameters.Add("@CONTENTAZ", SqlDbType.NVarChar);
            Comm.Parameters["@CONTENTAZ"].Value = AZ_edt.Html;

            Comm.Parameters.Add("@ID", SqlDbType.Int);
            Comm.Parameters["@ID"].Value = ID;

            try
            {
                Comm.ExecuteNonQuery();

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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}