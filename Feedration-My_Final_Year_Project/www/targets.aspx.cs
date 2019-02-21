using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.Security;
using System.Configuration;
using System.Data;

public partial class targets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void add_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();
            try
            {
                Comm.CommandText = @"INSERT INTO TARGETINCREASE (NAME, TARGETCATEGORYID, TARGETNAMEID, TARGETVALUEID) VALUES (@NAME, @TARGETCATEGORYID, @TARGETNAMEID, @TARGETVALUEID )";
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Target_edt.Text.Trim();
                Comm.Parameters.Add("@TARGETCATEGORYID", SqlDbType.Int);
                Comm.Parameters["@TARGETCATEGORYID"].Value = Targetcat_ddl.SelectedValue;
                Comm.Parameters.Add("@TARGETNAMEID", SqlDbType.Int);
                Comm.Parameters["@TARGETNAMEID"].Value = Targetname_ddl.SelectedValue;
                Comm.Parameters.Add("@TARGETVALUEID", SqlDbType.Int);
                Comm.Parameters["@TARGETVALUEID"].Value = targetval_ddl.SelectedValue;

                Comm.ExecuteNonQuery();
                Targetmgmt_grid.DataBind();

                Target_edt.Text = "";
                Targetcat_ddl.SelectedIndex = 0;
                Targetname_ddl.SelectedIndex = 0;
                targetval_ddl.SelectedIndex = 0;


                Error_lb.ForeColor = Color.Green;
                Error_lb.Text = "Data added successfully";
            }
            catch (SqlException E)
            {
                Error_lb.Text = E.Message;
                return;
            }
        }

    }
    protected void Targetmgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_target")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM TARGETINCREASE WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Targetmgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Targetmgmt_grid.DataBind();

                    Error_lb.ForeColor = Color.Green;
                    Error_lb.Text = "Data deleted";
                }
                catch (SqlException E)
                {
                    Error_lb.Text = E.Message;
                    return;
                }
            }
        }
    }
    protected void Targetmgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        DropDownList DDL = (DropDownList)Targetmgmt_grid.Rows[e.RowIndex].FindControl("Targetcat_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["TARGETCATNAME"] = DDL.SelectedItem.Value;
        SqlDataSource1.UpdateCommand = @"UPDATE TARGETINCREASE SET NAME = @NAME, TARGETCATEGORYID = @TARGETCATNAME, TARGETNAMEID = @TARGETNAMENAME, TARGETVALUEID = @TARGETVALUENAME WHERE TARGETINCREASE.ID = @ID";
        }


        DropDownList DDL1 = (DropDownList)Targetmgmt_grid.Rows[e.RowIndex].FindControl("Targetname_grid_ddl");

        if (DDL1 != null)
        {
            e.NewValues["TARGETNAMENAME"] = DDL1.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE TARGETINCREASE SET NAME = @NAME, TARGETCATEGORYID = @TARGETCATNAME, TARGETNAMEID = @TARGETNAMENAME, TARGETVALUEID = @TARGETVALUENAME WHERE TARGETINCREASE.ID = @ID";
        }

        DropDownList DDL2 = (DropDownList)Targetmgmt_grid.Rows[e.RowIndex].FindControl("Targetvalue_grid_ddl");

        if (DDL2 != null)
        {
            e.NewValues["TARGETVALUENAME"] = DDL2.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE TARGETINCREASE SET NAME = @NAME, TARGETCATEGORYID = @TARGETCATNAME, TARGETNAMEID = @TARGETNAMENAME, TARGETVALUEID = @TARGETVALUENAME WHERE TARGETINCREASE.ID = @ID";
        }

        
        Targetmgmt_grid.DataBind();
    }
}