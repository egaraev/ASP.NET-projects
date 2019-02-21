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

public partial class Prodadminfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Admininfo_sds.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        Admininfo_sds.SelectCommand = @"SELECT P.ID AS ID, C.SURNAME+' '+C.NAME AS INITIALS, C.PHONE,  P.MODELNAME,
                     P.TIMESPENT AS TIMESPENT, P.WARANTY,  P.SELFPRICE, P.HEIGHT, P.WEIGHT, P.VOLTAGE, P.RPM , P.PERFORMANCE,  P.ENGINEPOWER , P.HUMMERS, P.COMMENT 
                    FROM CATEGORIES CA, CUSTOMERS C, PRODUCTS P WHERE  P.CUSTOMERSID=C.ID AND P.CATEGORIESID=CA.ID AND P.ACTIVE='TRUE' AND CA.ACTIVE='TRUE' AND C.ACTIVE='TRUE'";
        
        Admininfo_grid.DataSourceID = "Admininfo_sds";
        Admininfo_grid.EmptyDataText = "Ни одной продажи";


        Panel2.Visible = true;
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = @"SELECT P.ID AS ID, C.SURNAME+' '+C.NAME AS INITIALS, C.PHONE,  P.MODELNAME,
                     P.TIMESPENT AS TIMESPENT,   P.SELFPRICE, P.HEIGHT, P.WEIGHT, P.VOLTAGE, P.RPM , P.PERFORMANCE,  P.ENGINEPOWER , P.HUMMERS, P.COMMENT 
                    FROM CATEGORIES CA, CUSTOMERS C, PRODUCTS P WHERE  P.CUSTOMERSID=C.ID AND P.CATEGORIESID=CA.ID AND P.ACTIVE='TRUE' AND CA.ACTIVE='TRUE' AND C.ACTIVE='TRUE'";

                SqlDataReader reader = Comm.ExecuteReader();
            }
            catch (SqlException E)
            {
                Error2_lb.Text = E.Message;
                return;
            }

        }

    }
    protected void Admininfo_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
}