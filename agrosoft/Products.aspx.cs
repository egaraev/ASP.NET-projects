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

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int i = 0;
        int a = 0;

        if (Context.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            FormsIdentity identity = new FormsIdentity(ticket);
            i = AuthCookieParce.UserID(identity.Name);
            a = AuthCookieParce.UserRoleID(identity.Name);
        }
        else
        {
            Response.Redirect("Default.aspx");
            return;
        }

        Error1_lb.Text = "";
        Error1_lb.ForeColor = Color.Red;
        Error2_lb.Text = "";
        Error2_lb.ForeColor = Color.Red;



        Categories_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Categories_sds.SelectCommand = "SELECT ID, NAME FROM CATEGORIES WHERE ACTIVE='TRUE'";

        Clients_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Clients_sds.SelectCommand = "SELECT ID, SURNAME+' '+NAME AS FIO FROM CUSTOMERS WHERE ACTIVE='TRUE'";

        Admingrid_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Admingrid_sds.SelectCommand = @"SELECT P.ID AS ID, P.SERIAL AS SERIAL, C.SURNAME+' '+C.NAME AS INITIALS, CA.NAME AS CATEGORYNAME, P.DATESOLD AS DATESOLD, P.PRICE AS PRICE FROM CATEGORIES CA, CUSTOMERS C, PRODUCTS P
                                         WHERE  P.CUSTOMERSID=C.ID AND P.CATEGORIESID=CA.ID AND C.ACTIVE='TRUE' AND CA.ACTIVE='TRUE' AND P.ACTIVE='TRUE'";

        Admin_grid.DataSourceID = "Admingrid_sds";
        Admin_grid.EmptyDataText = "Ни одной продажи";



        Clientsgrid_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Clientsgrid_sds.SelectCommand = @"SELECT P.ID AS ID, C.SURNAME+' '+C.NAME AS INITIALS, C.PHONE, CA.NAME AS CATEGORY, P.MODELNAME,
                    P.DATESOLD, P.TIMESPENT AS TIMESPENT, P.PRICE,  P.SELFPRICECLIENT, P.HEIGHT, P.WEIGHT, 
                    P.VOLTAGE, P.RPM , P.PERFORMANCE,  P.ENGINEPOWER , P.HUMMERS, P.COMMENT 
                    FROM CATEGORIES CA, CUSTOMERS C, PRODUCTS P WHERE  P.CUSTOMERSID=C.ID AND P.CATEGORIESID=CA.ID AND P.ACTIVE='TRUE' AND CA.ACTIVE='TRUE' AND C.ACTIVE='TRUE'";

       Clients_grid.DataSourceID = "Clientsgrid_sds";
       Clients_grid.EmptyDataText = "Ни одной продажи";




       if (a == 1)
       {
           Panel1.Visible = true;
           Panel2.Visible = false;
           Panel3.Visible = true;
       }

       else
       {
           Customers_mgmt.Visible = false;
           Users_mgmt.Visible = false;
           Cat_mgmt.Visible = false;
           Products_lb.Visible = false;

           Panel1.Visible = false;
           Panel2.Visible = true;
           Panel3.Visible = false;
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
        if (Modelname_edt.Text.Trim() != "" && Categories_ddl.SelectedIndex > 0 &&
            Waranty_ddl.SelectedIndex > 0 && Datesold_edt.SelectedDate != null &&
            Clients_ddl.SelectedIndex > 0 && Serial_edt.Text.Trim() != "" &&
            Price_edt.Text.Trim() != "" && Selfprice_edt.Text.Trim() != "" &&
            Selfpriceclient_edt.Text.Trim() != "")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                SqlTransaction tran = Conn.BeginTransaction(IsolationLevel.Serializable);
                Comm.Transaction = tran;
                Panel1.Visible = true;
                try
                {
                    Comm.CommandText = @"INSERT INTO PRODUCTS (CATEGORIESID, CUSTOMERSID, MODELNAME, WARANTY, DATESOLD, SERIAL,
                    TIMESPENT, PRICE, SELFPRICE, SELFPRICECLIENT, HEIGHT, WEIGHT, VOLTAGE, RPM, PERFORMANCE, ENGINEPOWER, HUMMERS,
                    COMMENT, ACTIVE) VALUES (@CATEGORIESID, @CUSTOMERSID, @MODELNAME, @WARANTY, @DATESOLD, @SERIAL,
                    @TIMESPENT, @PRICE, @SELFPRICE, @SELFPRICECLIENT, @HEIGHT, @WEIGHT, @VOLTAGE, @RPM, @PERFORMANCE, @ENGINEPOWER, @HUMMERS,
                    @COMMENT, 'TRUE');SELECT SCOPE_IDENTITY()";


                    Comm.Parameters.Add("@CATEGORIESID", SqlDbType.Int);
                    Comm.Parameters["@CATEGORIESID"].Value = Categories_ddl.SelectedValue;
                    Comm.Parameters.Add("@CUSTOMERSID", SqlDbType.Int);
                    Comm.Parameters["@CUSTOMERSID"].Value = Clients_ddl.SelectedValue;
                    Comm.Parameters.Add("@MODELNAME", SqlDbType.NVarChar);
                    Comm.Parameters["@MODELNAME"].Value = Modelname_edt.Text.Trim();
                    Comm.Parameters.Add("@WARANTY", SqlDbType.Int);
                    Comm.Parameters["@WARANTY"].Value = Waranty_ddl.SelectedValue;
                    Comm.Parameters.Add("@DATESOLD", SqlDbType.DateTime);
                    Comm.Parameters["@DATESOLD"].Value = Datesold_edt.SelectedDate.Value;
                    Comm.Parameters.Add("@SERIAL", SqlDbType.NVarChar);
                    Comm.Parameters["@SERIAL"].Value = Serial_edt.Text.Trim();
                    if (Timespent_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@TIMESPENT", SqlDbType.Int);
                        Comm.Parameters["@TIMESPENT"].Value = Timespent_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@TIMESPENT", SqlDbType.Int);
                        Comm.Parameters["@TIMESPENT"].Value = DBNull.Value;
                    }

                    Comm.Parameters.Add("@PRICE", SqlDbType.Int);
                    Comm.Parameters["@PRICE"].Value = Price_edt.Text.Trim();
                    Comm.Parameters.Add("@SELFPRICE", SqlDbType.Int);
                    Comm.Parameters["@SELFPRICE"].Value = Selfprice_edt.Text.Trim();
                    Comm.Parameters.Add("@SELFPRICECLIENT", SqlDbType.Int);
                    Comm.Parameters["@SELFPRICECLIENT"].Value = Selfpriceclient_edt.Text.Trim();

                    if (Height_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@HEIGHT", SqlDbType.Int);
                        Comm.Parameters["@HEIGHT"].Value = Height_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@HEIGHT", SqlDbType.Int);
                        Comm.Parameters["@HEIGHT"].Value = DBNull.Value;
                    }

                    if (Weight_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@WEIGHT", SqlDbType.Int);
                        Comm.Parameters["@WEIGHT"].Value = Weight_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@WEIGHT", SqlDbType.Int);
                        Comm.Parameters["@WEIGHT"].Value = DBNull.Value;
                    }

                    if (Voltage_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@VOLTAGE", SqlDbType.Int);
                        Comm.Parameters["@VOLTAGE"].Value = Voltage_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@VOLTAGE", SqlDbType.Int);
                        Comm.Parameters["@VOLTAGE"].Value = DBNull.Value;
                    }

                    if (Rpm_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@RPM", SqlDbType.Int);
                        Comm.Parameters["@RPM"].Value = Rpm_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@RPM", SqlDbType.Int);
                        Comm.Parameters["@RPM"].Value = DBNull.Value;
                    }

                    if (Performance_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@PERFORMANCE", SqlDbType.Int);
                        Comm.Parameters["@PERFORMANCE"].Value = Performance_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@PERFORMANCE", SqlDbType.Int);
                        Comm.Parameters["@PERFORMANCE"].Value = DBNull.Value;
                    }

                    if (Enginepower_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@ENGINEPOWER", SqlDbType.Int);
                        Comm.Parameters["@ENGINEPOWER"].Value = Enginepower_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@ENGINEPOWER", SqlDbType.Int);
                        Comm.Parameters["@ENGINEPOWER"].Value = DBNull.Value;
                    }

                    if (Hummers_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@HUMMERS", SqlDbType.Int);
                        Comm.Parameters["@HUMMERS"].Value = Hummers_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@HUMMERS", SqlDbType.Int);
                        Comm.Parameters["@HUMMERS"].Value = DBNull.Value;
                    }


                    if (Comment_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@COMMENT", SqlDbType.NVarChar);
                        Comm.Parameters["@COMMENT"].Value = Comment_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@COMMENT", SqlDbType.NVarChar);
                        Comm.Parameters["@COMMENT"].Value = DBNull.Value;
                    }


                    string y = Convert.ToString(Comm.ExecuteScalar());

                    if (!Directory.Exists(Server.MapPath("~/files/fotos/") + y + "/"))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/files/fotos/") + y + "/");
                    }
                    else
                    {
                        foreach (string file in Directory.GetFiles(Server.MapPath("~/files/fotos/") + y + "/"))
                        {
                            File.Delete(file);
                        }
                    }

                    if (Foto1_upl.HasFile && (Foto1_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto1_upl.PostedFile.ContentType == "image/bmp" || Foto1_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto1_upl.PostedFile.ContentType == "image/gif" || Foto1_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto1_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto1_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/1.jpg");
                    }
                    if (Foto2_upl.HasFile && (Foto2_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto2_upl.PostedFile.ContentType == "image/bmp" || Foto2_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto2_upl.PostedFile.ContentType == "image/gif" || Foto2_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto2_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto2_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/2.jpg");
                    }
                    if (Foto3_upl.HasFile && (Foto3_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto3_upl.PostedFile.ContentType == "image/bmp" || Foto3_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto3_upl.PostedFile.ContentType == "image/gif" || Foto3_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto3_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto3_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/3.jpg");
                    }
                    if (Foto4_upl.HasFile && (Foto4_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto4_upl.PostedFile.ContentType == "image/bmp" || Foto4_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto4_upl.PostedFile.ContentType == "image/gif" || Foto4_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto4_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto4_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/4.jpg");
                    }
                    if (Foto5_upl.HasFile && (Foto5_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto5_upl.PostedFile.ContentType == "image/bmp" || Foto5_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto5_upl.PostedFile.ContentType == "image/gif" || Foto5_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto5_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto5_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/5.jpg");
                    }


                    Categories_ddl.SelectedIndex = 0;
                    Clients_ddl.SelectedIndex = 0;
                    Modelname_edt.Text = "";
                    Waranty_ddl.SelectedIndex = 0;
                    Datesold_edt.SelectedDate = null;
                    Serial_edt.Text = "";
                    Timespent_edt.Text = "";
                    Price_edt.Text = "";
                    Selfprice_edt.Text = "";
                    Selfpriceclient_edt.Text = "";
                    Height_edt.Text = "";
                    Weight_edt.Text = "";
                    Voltage_edt.Text = "";
                    Rpm_edt.Text = "";
                    Performance_edt.Text = "";
                    Enginepower_edt.Text = "";
                    Hummers_edt.Text = "";
                    Comment_edt.Text = "";

                    tran.Commit();
                    Admin_grid.DataBind();
                    Error1_lb.ForeColor = Color.Green;
                    Error1_lb.Text = "Данные добавлены";
                }
                catch (SqlException E)
                {
                    tran.Rollback();
                    Error1_lb.Text = E.Message;
                    return;
                }
            }
        }
        else
        {
            Error1_lb.Text = "Не все обязательные поля заполненны";
        }

    }



    protected void update_btn_Click(object sender, EventArgs e)
    {

        if (Modelname_edt.Text.Trim() != "" && Categories_ddl.SelectedIndex > 0 &&
            Waranty_ddl.SelectedIndex > 0 && Datesold_edt.SelectedDate != null &&
            Clients_ddl.SelectedIndex > 0 && Serial_edt.Text.Trim() != "" &&
            Price_edt.Text.Trim() != "" && Selfprice_edt.Text.Trim() != "" &&
            Selfpriceclient_edt.Text.Trim() != "")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();
                SqlTransaction tran = Conn.BeginTransaction(IsolationLevel.Serializable);
                Comm.Transaction = tran;

                Panel1.Visible = true;
                try
                {
                    Comm.CommandText = @"UPDATE PRODUCTS  SET CATEGORIESID=@CATEGORIESID, CUSTOMERSID=@CUSTOMERSID, MODELNAME=@MODELNAME, WARANTY=@WARANTY, DATESOLD=@DATESOLD, SERIAL=@SERIAL,
                    TIMESPENT=@TIMESPENT, PRICE=@PRICE, SELFPRICE=@SELFPRICE, SELFPRICECLIENT=@SELFPRICECLIENT, HEIGHT=@HEIGHT, WEIGHT=@WEIGHT, VOLTAGE=@VOLTAGE, RPM=@RPM, PERFORMANCE=@PERFORMANCE, ENGINEPOWER=@ENGINEPOWER, HUMMERS=@HUMMERS,
                    COMMENT=@COMMENT WHERE ID=@ID";


                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ViewState["id"].ToString();
                    Comm.Parameters.Add("@CATEGORIESID", SqlDbType.Int);
                    Comm.Parameters["@CATEGORIESID"].Value = Categories_ddl.SelectedValue;
                    Comm.Parameters.Add("@CUSTOMERSID", SqlDbType.Int);
                    Comm.Parameters["@CUSTOMERSID"].Value = Clients_ddl.SelectedValue;
                    Comm.Parameters.Add("@MODELNAME", SqlDbType.NVarChar);
                    Comm.Parameters["@MODELNAME"].Value = Modelname_edt.Text.Trim();
                    Comm.Parameters.Add("@WARANTY", SqlDbType.Int);
                    Comm.Parameters["@WARANTY"].Value = Waranty_ddl.SelectedValue;
                    Comm.Parameters.Add("@DATESOLD", SqlDbType.DateTime);
                    Comm.Parameters["@DATESOLD"].Value = Datesold_edt.SelectedDate.Value;
                    Comm.Parameters.Add("@SERIAL", SqlDbType.NVarChar);
                    Comm.Parameters["@SERIAL"].Value = Serial_edt.Text.Trim();
                    if (Timespent_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@TIMESPENT", SqlDbType.Int);
                        Comm.Parameters["@TIMESPENT"].Value = Timespent_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@TIMESPENT", SqlDbType.Int);
                        Comm.Parameters["@TIMESPENT"].Value = DBNull.Value;
                    }

                    Comm.Parameters.Add("@PRICE", SqlDbType.Int);
                    Comm.Parameters["@PRICE"].Value = Price_edt.Text.Trim();
                    Comm.Parameters.Add("@SELFPRICE", SqlDbType.Int);
                    Comm.Parameters["@SELFPRICE"].Value = Selfprice_edt.Text.Trim();
                    Comm.Parameters.Add("@SELFPRICECLIENT", SqlDbType.Int);
                    Comm.Parameters["@SELFPRICECLIENT"].Value = Selfpriceclient_edt.Text.Trim();

                    if (Height_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@HEIGHT", SqlDbType.Int);
                        Comm.Parameters["@HEIGHT"].Value = Height_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@HEIGHT", SqlDbType.Int);
                        Comm.Parameters["@HEIGHT"].Value = DBNull.Value;
                    }

                    if (Weight_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@WEIGHT", SqlDbType.Int);
                        Comm.Parameters["@WEIGHT"].Value = Weight_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@WEIGHT", SqlDbType.Int);
                        Comm.Parameters["@WEIGHT"].Value = DBNull.Value;
                    }

                    if (Voltage_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@VOLTAGE", SqlDbType.Int);
                        Comm.Parameters["@VOLTAGE"].Value = Voltage_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@VOLTAGE", SqlDbType.Int);
                        Comm.Parameters["@VOLTAGE"].Value = DBNull.Value;
                    }

                    if (Rpm_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@RPM", SqlDbType.Int);
                        Comm.Parameters["@RPM"].Value = Rpm_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@RPM", SqlDbType.Int);
                        Comm.Parameters["@RPM"].Value = DBNull.Value;
                    }

                    if (Performance_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@PERFORMANCE", SqlDbType.Int);
                        Comm.Parameters["@PERFORMANCE"].Value = Performance_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@PERFORMANCE", SqlDbType.Int);
                        Comm.Parameters["@PERFORMANCE"].Value = DBNull.Value;
                    }

                    if (Enginepower_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@ENGINEPOWER", SqlDbType.Int);
                        Comm.Parameters["@ENGINEPOWER"].Value = Enginepower_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@ENGINEPOWER", SqlDbType.Int);
                        Comm.Parameters["@ENGINEPOWER"].Value = DBNull.Value;
                    }

                    if (Hummers_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@HUMMERS", SqlDbType.Int);
                        Comm.Parameters["@HUMMERS"].Value = Hummers_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@HUMMERS", SqlDbType.Int);
                        Comm.Parameters["@HUMMERS"].Value = DBNull.Value;
                    }


                    if (Comment_edt.Text.Trim() != "")
                    {
                        Comm.Parameters.Add("@COMMENT", SqlDbType.NVarChar);
                        Comm.Parameters["@COMMENT"].Value = Comment_edt.Text.Trim();
                    }
                    else
                    {
                        Comm.Parameters.Add("@COMMENT", SqlDbType.NVarChar);
                        Comm.Parameters["@COMMENT"].Value = DBNull.Value;
                    }

                    Comm.ExecuteNonQuery();
                    string y = ViewState["id"].ToString();

                    if (!Directory.Exists(Server.MapPath("~/files/fotos/") + y + "/"))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/files/fotos/") + y + "/");
                    }
                    else
                    {
                        foreach (string file in Directory.GetFiles(Server.MapPath("~/files/fotos/") + y + "/"))
                        {
                            File.Delete(file);
                        }
                    }

                    if (Foto1_upl.HasFile && (Foto1_upl.PostedFile.ContentType=="image/jpeg" || 
                     Foto1_upl.PostedFile.ContentType=="image/bmp" || Foto1_upl.PostedFile.ContentType=="image/x-windows-bmp" || 
                     Foto1_upl.PostedFile.ContentType=="image/gif" || Foto1_upl.PostedFile.ContentType=="image/pjpeg" ||
                     Foto1_upl.PostedFile.ContentType=="image/png" ))
                    {
                        Foto1_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/1.jpg");
                    }
                    if (Foto2_upl.HasFile && (Foto2_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto2_upl.PostedFile.ContentType == "image/bmp" || Foto2_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto2_upl.PostedFile.ContentType == "image/gif" || Foto2_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto2_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto2_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/2.jpg");
                    }
                    if (Foto3_upl.HasFile && (Foto3_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto3_upl.PostedFile.ContentType == "image/bmp" || Foto3_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto3_upl.PostedFile.ContentType == "image/gif" || Foto3_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto3_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto3_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/3.jpg");
                    }
                    if (Foto4_upl.HasFile && (Foto4_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto4_upl.PostedFile.ContentType == "image/bmp" || Foto4_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto4_upl.PostedFile.ContentType == "image/gif" || Foto4_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto4_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto4_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/4.jpg");
                    }
                    if (Foto5_upl.HasFile && (Foto5_upl.PostedFile.ContentType == "image/jpeg" ||
                     Foto5_upl.PostedFile.ContentType == "image/bmp" || Foto5_upl.PostedFile.ContentType == "image/x-windows-bmp" ||
                     Foto5_upl.PostedFile.ContentType == "image/gif" || Foto5_upl.PostedFile.ContentType == "image/pjpeg" ||
                     Foto5_upl.PostedFile.ContentType == "image/png"))
                    {
                        Foto5_upl.SaveAs(Server.MapPath("~/files/fotos/") + y + "/5.jpg");
                    }

                    Categories_ddl.SelectedIndex = 0;
                    Clients_ddl.SelectedIndex = 0;
                    Modelname_edt.Text = "";
                    Waranty_ddl.SelectedIndex = 0;
                    Datesold_edt.SelectedDate = null;
                    Serial_edt.Text = "";
                    Timespent_edt.Text = "";
                    Price_edt.Text = "";
                    Selfprice_edt.Text = "";
                    Selfpriceclient_edt.Text = "";
                    Height_edt.Text = "";
                    Weight_edt.Text = "";
                    Voltage_edt.Text = "";
                    Rpm_edt.Text = "";
                    Performance_edt.Text = "";
                    Enginepower_edt.Text = "";
                    Hummers_edt.Text = "";
                    Comment_edt.Text = "";

                    Add_btn.Visible = true;
                    Cancel_btn.Visible = false;
                    Update_btn.Visible = false;

                    tran.Commit();
                    Admin_grid.DataBind();
                    Error1_lb.ForeColor = Color.Green;
                    Error1_lb.Text = "Данные обновлены";
                }
                catch (Exception E)
                {
                    tran.Rollback();
                    Error1_lb.Text = E.Message;
                    return;
                }
            }
        }
        else
        {
            Error1_lb.Text = "Не все обязательные поля заполненны";
        }



    }
    protected void cancel_btn_Click(object sender, EventArgs e)
    {
        Add_btn.Visible = true;
        Cancel_btn.Visible = false;
        Update_btn.Visible = false;

        Categories_ddl.SelectedIndex = 0;
        Clients_ddl.SelectedIndex = 0;
        Modelname_edt.Text = "";
        Waranty_ddl.SelectedIndex = 0;
        Datesold_edt.SelectedDate = null;
        Serial_edt.Text = "";
        Timespent_edt.Text = "";
        Price_edt.Text = "";
        Selfprice_edt.Text = "";
        Selfpriceclient_edt.Text = "";
        Height_edt.Text = "";
        Weight_edt.Text = "";
        Voltage_edt.Text = "";
        Rpm_edt.Text = "";
        Performance_edt.Text = "";
        Enginepower_edt.Text = "";
        Hummers_edt.Text = "";
        Comment_edt.Text = "";


    }


    protected void Categories_ddl_DataBound(object sender, EventArgs e)
    {
        ListItem item = new ListItem("Выберите категорию", "-1");
        Categories_ddl.Items.Insert(0, item);

    }



    protected void Clients_ddl_DataBound(object sender, EventArgs e)
    {
        ListItem item = new ListItem("Выберите клиента", "-1");
        Clients_ddl.Items.Insert(0, item);
    }


    protected void Admin_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editproduct")
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
                    Comm.CommandText = @"SELECT CATEGORIESID, CUSTOMERSID,  MODELNAME,WARANTY ,
                        DATESOLD, SERIAL, TIMESPENT, PRICE,   SELFPRICE , SELFPRICECLIENT , HEIGHT , WEIGHT , VOLTAGE , RPM , PERFORMANCE ,
                        ENGINEPOWER , HUMMERS, COMMENT, ID FROM PRODUCTS WHERE ACTIVE='TRUE' AND ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Admin_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        if (Categories_ddl.Items.FindByValue(reader[0].ToString()) != null)
                        {
                            Categories_ddl.SelectedIndex = -1;
                            Categories_ddl.Items.FindByValue(reader[0].ToString()).Selected = true;
                        }
                        if (Clients_ddl.Items.FindByValue(reader[1].ToString()) != null)
                        {
                            Clients_ddl.SelectedIndex = -1;
                            Clients_ddl.Items.FindByValue(reader[1].ToString()).Selected = true;
                        }
                        Modelname_edt.Text = reader[2].ToString();

                        if (Waranty_ddl.Items.FindByValue(reader[3].ToString()) != null)
                        {
                            Waranty_ddl.SelectedIndex = -1;
                            Waranty_ddl.Items.FindByValue(reader[3].ToString()).Selected = true;
                        }
                        Datesold_edt.SelectedDate = Convert.ToDateTime(reader[4].ToString());

                        Serial_edt.Text = reader[5].ToString();
                        Timespent_edt.Text = reader[6].ToString();
                        Price_edt.Text = reader[7].ToString();
                        Selfprice_edt.Text = reader[8].ToString();
                        Selfpriceclient_edt.Text = reader[9].ToString();
                        Height_edt.Text = reader[10].ToString();
                        Weight_edt.Text = reader[11].ToString();
                        Voltage_edt.Text = reader[12].ToString();
                        Rpm_edt.Text = reader[13].ToString();
                        Performance_edt.Text = reader[14].ToString();
                        Enginepower_edt.Text = reader[15].ToString();
                        Hummers_edt.Text = reader[16].ToString();
                        Comment_edt.Text = reader[17].ToString();
                        ViewState["id"] = reader[18].ToString();


                        Add_btn.Visible = false;
                        Update_btn.Visible = true;
                        Cancel_btn.Visible = true;
                    }
                    else
                    {
                        Error1_lb.Text = "Произошла ошибка";
                        return;
                    }

                }

                catch (SqlException E)
                {
                    Error1_lb.Text = E.Message;
                    return;
                }
            }
        }

        else if (e.CommandName == "Deleteproduct")
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
                    Comm.CommandText = "UPDATE PRODUCTS SET ACTIVE='FALSE' WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Admin_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    string id = Admin_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    Comm.ExecuteNonQuery();

                    Admin_grid.DataBind();
                    Error1_lb.ForeColor = Color.Green;
                    Error1_lb.Text = "Данные удалены";
                }
                catch (SqlException E)
                {
                    Error1_lb.Text = E.Message;
                    return;
                }
            }
        }
        else if (e.CommandName == "Info")
        {
            Response.Redirect("Prodadminfo.aspx?id=" + Admin_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        }
    }
}