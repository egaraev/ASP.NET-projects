using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)  //загрузка страницы, выполняется перед любым другим событием(нажатие кнопки, Ф5 и т.д)
    {
        Error_lb.ForeColor = Color.Red;
        Error_lb.Text = "";
        Error2_lb.ForeColor = Color.Red;
        Error2_lb.Text = "";     // ustanovka svoystv elementov po umolchaniyu

        Headers_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;  
        Menu_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;  // prisvoenie datasoursam ix connection string 


        Headers_sds.SelectCommand = "SELECT ID, NAMERU, NAMEAZ FROM HEADERS WHERE ACTIVE='TRUE'";  // istochniku dannix daetsa comanda
        Headers_grid.DataSourceID = "Headers_sds";   //tablice prisvaevaetsa istochnik dannix

    }
    protected void Headers_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")
        {
            Panel1.Visible = false;
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "SELECT NAMERU, NAMEAZ FROM HEADERS WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Headers_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        NameRU_edt.Text = reader[0].ToString();
                        NameAZ_edt.Text = reader[1].ToString();
                        ViewState["headerid"] = Headers_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    }
                    else
                    {
                        Error_lb.Text = "Произошла ошибка";
                        return;
                    }

                    Add_btn.Visible = false;
                    Update_btn.Visible = true;
                    Cancel_btn.Visible = true;


                    
                }
                catch (SqlException E)
                {
                    Error_lb.Text = E.Message;
                    return;
                }
            }
        }
        else if (e.CommandName == "Delete1")
        {
            Panel1.Visible = false;
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "UPDATE HEADERS SET ACTIVE='FALSE' WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Headers_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

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
        else if (e.CommandName == "Add1")
        {
            Panel1.Visible = true;
            ViewState["newheaderid"] = Headers_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();


            Menu_sds.SelectParameters.Clear();
            Menu_sds.SelectParameters.Add("HEADERID", TypeCode.Int32, Headers_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            Menu_sds.SelectCommand = "SELECT ID, NAMERU, NAMEAZ FROM MENU WHERE HEADERID=@HEADERID AND ACTIVE='TRUE'";
            Menu_grid.DataSourceID = "Menu_sds";
            Menu_grid.DataBind();
        }
        else if (e.CommandName == "Content")
        {
            Response.Redirect(string.Format("Contentheader.aspx?id={0}",Headers_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
        }
    }


    protected void Headers_grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.Cells[2].Controls[0]).Text = "Добавить";
            ((LinkButton)e.Row.Cells[3].Controls[0]).Text = "Наполнение";
            ((LinkButton)e.Row.Cells[4].Controls[0]).Text = "Редактировать";
            ((LinkButton)e.Row.Cells[5].Controls[0]).Text = "Удалить";
        }
    }
    protected void Add_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "INSERT INTO HEADERS (NAMERU,NAMEAZ,ACTIVE) VALUES (@NAMERU,@NAMEAZ,'TRUE')";
                Comm.Parameters.Add("@NAMERU", SqlDbType.NVarChar);
                Comm.Parameters["@NAMERU"].Value = NameRU_edt.Text.Trim();
                Comm.Parameters.Add("@NAMEAZ", SqlDbType.NVarChar);
                Comm.Parameters["@NAMEAZ"].Value = NameAZ_edt.Text.Trim();

                Comm.ExecuteNonQuery();
                Headers_grid.DataBind();

                NameRU_edt.Text = "";
                NameAZ_edt.Text = "";

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
    protected void Update_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "UPDATE HEADERS SET NAMERU=@NAMERU,NAMEAZ=@NAMEAZ WHERE ID=@ID ";
                Comm.Parameters.Add("@NAMERU", SqlDbType.NVarChar);
                Comm.Parameters["@NAMERU"].Value = NameRU_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@NAMEAZ", SqlDbType.NVarChar);
                Comm.Parameters["@NAMEAZ"].Value = NameAZ_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ViewState["headerid"].ToString();

                Comm.ExecuteNonQuery();

                Add_btn.Visible = true;
                Cancel_btn.Visible = false;
                Update_btn.Visible = false;
                NameRU_edt.Text = "";
                NameAZ_edt.Text = "";

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
    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
        Add_btn.Visible = true;
        Cancel_btn.Visible = false;
        Update_btn.Visible = false;
        NameRU_edt.Text = "";
        NameAZ_edt.Text = "";

    }
    protected void add2_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                
                Comm.CommandText = "INSERT INTO MENU (HEADERID,NAMERU,NAMEAZ,ACTIVE) VALUES (@HEADERID,@NAMERU,@NAMEAZ,'TRUE')";
                
                Comm.Parameters.Add("@HEADERID", SqlDbType.Int);
                Comm.Parameters["@HEADERID"].Value = ViewState["newheaderid"].ToString();
                Comm.Parameters.Add("@NAMERU", SqlDbType.NVarChar);
                Comm.Parameters["@NAMERU"].Value = NameRU2_edt.Text.Trim();
                Comm.Parameters.Add("@NAMEAZ", SqlDbType.NVarChar);
                Comm.Parameters["@NAMEAZ"].Value = NameAZ2_edt.Text.Trim();

                Comm.ExecuteNonQuery(); 
                
                Menu_sds.SelectParameters.Clear();
                Menu_sds.SelectParameters.Add("HEADERID", TypeCode.Int32, ViewState["newheaderid"].ToString());
                Menu_sds.SelectCommand = "SELECT ID, NAMERU, NAMEAZ FROM MENU WHERE HEADERID=@HEADERID AND ACTIVE='TRUE'";
                Menu_grid.DataSourceID = "Menu_sds";
                Menu_grid.DataBind();



                NameRU2_edt.Text = "";
                NameAZ2_edt.Text = "";


                Error2_lb.ForeColor = Color.Green;
                Error2_lb.Text = "Данные добавлены";
            }
            catch (SqlException E)
            {
                Error2_lb.Text = E.Message;
                return;
            }
        }


    }
    protected void Menu_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")
        {
            
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "SELECT NAMERU, NAMEAZ FROM MENU WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Menu_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        NameRU2_edt.Text = reader[0].ToString();
                        NameAZ2_edt.Text = reader[1].ToString();
                        ViewState["menuid"] = Menu_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    }
                    else
                    {
                        Error2_lb.Text = "Произошла ошибка";
                        return;
                    }

                    add2_btn.Visible = false;
                    update2_btn.Visible = true;
                    cancel2_btn.Visible = true;



                }
                catch (SqlException E)
                {
                    Error_lb.Text = E.Message;
                    return;
                }
            }
        }
        else if (e.CommandName == "Delete1")
        {
          
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "UPDATE MENU SET ACTIVE='FALSE' WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Menu_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Menu_sds.SelectParameters.Clear();
                    Menu_sds.SelectParameters.Add("HEADERID", TypeCode.Int32, ViewState["newheaderid"].ToString());
                    Menu_sds.SelectCommand = "SELECT ID, NAMERU, NAMEAZ FROM MENU WHERE HEADERID=@HEADERID AND ACTIVE='TRUE'";
                    Menu_grid.DataSourceID = "Menu_sds";
                    Menu_grid.DataBind();
                    Error2_lb.ForeColor = Color.Green;
                    Error2_lb.Text = "Данные удалены";
                }
                catch (SqlException E)
                {
                    Error2_lb.Text = E.Message;
                    return;
                }
            }
        }
        
        else if (e.CommandName == "Content")
        {
            Response.Redirect(string.Format("Contentmenu.aspx?cat={0}", Menu_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
        }
    }
    protected void update2_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "UPDATE MENU SET NAMERU=@NAMERU,NAMEAZ=@NAMEAZ WHERE ID=@ID ";
                Comm.Parameters.Add("@NAMERU", SqlDbType.NVarChar);
                Comm.Parameters["@NAMERU"].Value = NameRU2_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@NAMEAZ", SqlDbType.NVarChar);
                Comm.Parameters["@NAMEAZ"].Value = NameAZ2_edt.Text.Trim().Replace("&nbsp;", "");
                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ViewState["menuid"].ToString();

                Comm.ExecuteNonQuery();
                Menu_sds.SelectParameters.Clear();
                Menu_sds.SelectParameters.Add("HEADERID", TypeCode.Int32, ViewState["newheaderid"].ToString());
                Menu_sds.SelectCommand = "SELECT ID, NAMERU, NAMEAZ FROM MENU WHERE HEADERID=@HEADERID AND ACTIVE='TRUE'";
                Menu_grid.DataSourceID = "Menu_sds";
                Menu_grid.DataBind();




                add2_btn.Visible = true;
                cancel2_btn.Visible = false;
                update2_btn.Visible = false;
                NameRU2_edt.Text = "";
                NameAZ2_edt.Text = "";

                Error2_lb.ForeColor = Color.Green;
                Error2_lb.Text = "Данные обновлены";
            }
            catch (SqlException E)
            {
                Error2_lb.Text = E.Message;
                return;
            }
        }


    }
    protected void cancel2_btn_Click(object sender, EventArgs e)
    {
        add2_btn.Visible = true;
        cancel2_btn.Visible = false;
        update2_btn.Visible = false;
        NameRU2_edt.Text = "";
        NameAZ2_edt.Text = "";
    }
}