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


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            Error_lb.Text = "";
            Error_lb.ForeColor = Color.Red;
            Error2_lb.Text = "";
            Error2_lb.ForeColor = Color.Red;



            Orders_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            Date_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            Date_sds.SelectCommand = @"SELECT DISTINCT YEAR(DATE) AS YEAR FROM ORDERS ORDER BY YEAR";

            Orders_sds.SelectParameters.Clear();
            if (year_ddl.SelectedIndex > 0)
            {
                if (month_ddl.SelectedIndex > 0)
                {
                    Orders_sds.SelectParameters.Add("YEAR", TypeCode.Int32, year_ddl.SelectedValue);
                    Orders_sds.SelectParameters.Add("MONTH", TypeCode.Int32, month_ddl.SelectedValue);
                    Orders_sds.SelectCommand = "SELECT ID, DATE, TIME, COMPANY, CN, PCS, ADDRESS, PH, CLIENTNAME, LOCAL, INTERN, TYPE, DESTINATION FROM ORDERS WHERE YEAR(DATE)=@YEAR AND MONTH(DATE)=@MONTH ORDER BY ID DESC";
                }
                else
                {
                    Orders_sds.SelectParameters.Add("YEAR", TypeCode.Int32, year_ddl.SelectedValue);
                    Orders_sds.SelectCommand = "SELECT ID, DATE, TIME, COMPANY, CN, PCS, ADDRESS, PH, CLIENTNAME, LOCAL, INTERN, TYPE, DESTINATION FROM ORDERS WHERE YEAR(DATE)=@YEAR ORDER BY ID DESC";
                }
            }
            else if (month_ddl.SelectedIndex > 0)
            {
                Orders_sds.SelectParameters.Add("MONTH", TypeCode.Int32, month_ddl.SelectedValue);
                Orders_sds.SelectCommand = "SELECT ID, DATE, TIME, COMPANY, CN, PCS, ADDRESS, PH, CLIENTNAME, LOCAL, INTERN, TYPE, DESTINATION FROM ORDERS WHERE MONTH(DATE)=@MONTH ORDER BY ID DESC";
            }
            else
            {
                Orders_sds.SelectCommand = "SELECT ID, DATE, TIME, COMPANY, CN, PCS, ADDRESS, PH, CLIENTNAME, LOCAL, INTERN, TYPE, DESTINATION FROM ORDERS ORDER BY ID DESC";
            }

            Orders_sds.UpdateCommand = @"UPDATE ORDERS SET DATE=@DATE, TIME=@TIME, COMPANY=@COMPANY, CN=@CN, PCS=@PCS, ADDRESS=@ADDRESS, PH=@PH, CLIENTNAME=@CLIENTNAME,
            LOCAL=@LOCAL, INTERN=@INTERN, TYPE=@TYPE, DESTINATION=@DESTINATION WHERE ID=@ID";
            Orders_grid.EmptyDataText = "Нет доставок в этом интервале времени";
            Orders_grid.DataSourceID = "Orders_sds";

            if (!Page.IsPostBack)
            {
                Date_edt.SelectedDate = Convert.ToDateTime(DateTime.Today.ToString());
            }
        }
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }




    protected void Orders_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
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
                        Comm.CommandText = "SELECT  ID, DATE, TIME, COMPANY, CN, PCS, ADDRESS, PH, CLIENTNAME, LOCAL, INTERN, TYPE, DESTINATION FROM ORDERS WHERE ID=@ID";
                        Comm.Parameters.Add("@ID", SqlDbType.Int);
                        Comm.Parameters["@ID"].Value = Orders_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                        SqlDataReader reader = Comm.ExecuteReader();

                        if (reader.Read())
                        {

                            ViewState["id"] = Orders_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                        }
                        else
                        {
                            Error_lb.Text = "Произошла ошибка";
                            return;
                        }
                        add_btn.Visible = false;



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
                Panel1.Visible = true;
                using (SqlConnection Conn = new SqlConnection())
                {
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = Conn;
                    Conn.Open();

                    try
                    {
                        Comm.CommandText = "DELETE FROM ORDERS WHERE ID=@ID";
                        Comm.Parameters.Add("@ID", SqlDbType.Int);
                        Comm.Parameters["@ID"].Value = Orders_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

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
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }


    protected void add_btn_Click(object sender, EventArgs e)
    {
        try
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

                    Comm.CommandText = "INSERT INTO ORDERS (DATE,TIME,COMPANY,CN,PCS,ADDRESS,PH,CLIENTNAME,LOCAL,INTERN,TYPE,DESTINATION) VALUES (@DATE,@TIME,@COMPANY,@CN,@PCS,@ADDRESS,@PH,@CLIENTNAME,@LOCAL,@INTERN,@TYPE,@DESTINATION)";

                    if (Date_edt.SelectedDate == null)
                    {
                        Date_edt.SelectedDate = Convert.ToDateTime(DateTime.Today.ToString());
                        Comm.Parameters.Add("@DATE", SqlDbType.DateTime);
                        Comm.Parameters["@DATE"].Value = Date_edt.SelectedDate.Value;
                    }
                    else
                    {
                        Comm.Parameters.Add("@DATE", SqlDbType.DateTime);
                        Comm.Parameters["@DATE"].Value = Date_edt.SelectedDate.Value;
                    }


                    Comm.Parameters.Add("@TIME", SqlDbType.NVarChar);
                    Comm.Parameters["@TIME"].Value = Hours_ddl.SelectedValue + ":" + Minutes_ddl.SelectedValue;
                    Comm.Parameters.Add("@COMPANY", SqlDbType.NVarChar);
                    Comm.Parameters["@COMPANY"].Value = Company_edt.Text.Trim();
                    Comm.Parameters.Add("@CN", SqlDbType.NVarChar);
                    Comm.Parameters["@CN"].Value = Cn_edt.Text.Trim();
                    Comm.Parameters.Add("@PCS", SqlDbType.NVarChar);
                    Comm.Parameters["@PCS"].Value = Pcs_edt.Text.Trim();
                    Comm.Parameters.Add("@ADDRESS", SqlDbType.NVarChar);
                    Comm.Parameters["@ADDRESS"].Value = Address_edt.Text.Trim();
                    Comm.Parameters.Add("@PH", SqlDbType.NVarChar);
                    Comm.Parameters["@PH"].Value = Ph_edt.Text.Trim();
                    Comm.Parameters.Add("@CLIENTNAME", SqlDbType.NVarChar);
                    Comm.Parameters["@CLIENTNAME"].Value = Contact_edt.Text.Trim();
                    Comm.Parameters.Add("@LOCAL", SqlDbType.NVarChar);
                    Comm.Parameters["@LOCAL"].Value = Local_ddl.SelectedValue;
                    Comm.Parameters.Add("@INTERN", SqlDbType.NVarChar);
                    Comm.Parameters["@INTERN"].Value = Intern_edt.Text.Trim();
                    Comm.Parameters.Add("@TYPE", SqlDbType.NVarChar);
                    Comm.Parameters["@TYPE"].Value = Type_ddl.SelectedValue;
                    Comm.Parameters.Add("@DESTINATION", SqlDbType.NVarChar);
                    Comm.Parameters["@DESTINATION"].Value = Destination_edt.Text.Trim();



                    Comm.ExecuteNonQuery();
                    Orders_grid.DataBind();

                    string dat = DateTime.Today.ToString();

                    Date_edt.SelectedDate = Convert.ToDateTime(DateTime.Today.ToString());
                    Hours_ddl.SelectedIndex = 0;
                    Minutes_ddl.SelectedIndex = 0;
                    Company_edt.Text = "";
                    Cn_edt.Text = "";
                    Pcs_edt.Text = "";
                    Address_edt.Text = "";
                    Ph_edt.Text = "";
                    Contact_edt.Text = "";
                    Local_ddl.SelectedIndex = 0;
                    Intern_edt.Text = "";
                    Type_ddl.SelectedIndex = 0;
                    Destination_edt.Text = "";




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
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }
    protected void update_btn_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }



    protected void refresh_btn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(Request.Url.PathAndQuery);
        }
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }

    protected void year_ddl_DataBound(object sender, EventArgs e)
    {
        try
        {
            ListItem item = new ListItem(" - Выберите год - ", "0");
            year_ddl.Items.Insert(0, item);
        }
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception E)
        {
            Error_lb.Text = E.Message;
            return;
        }
    }
}