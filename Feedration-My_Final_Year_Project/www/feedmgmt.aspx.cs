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


public partial class feedmgmt : System.Web.UI.Page
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
                Comm.CommandText = @"INSERT INTO FEED (NAME, CATEGORYID, DRYMATTER, CRUDEFIBER, PROTEIN, ENERGY, CA, P) VALUES (@NAME, @CATEGORYID, @DRYMATTER, @CRUDEFIBER, @PROTEIN, @ENERGY, @CA, @P)";
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Feedname_edt.Text.Trim();
                Comm.Parameters.Add("@CATEGORYID", SqlDbType.Int);
                Comm.Parameters["@CATEGORYID"].Value = Feedcat_ddl1.SelectedValue;
                Comm.Parameters.Add("@DRYMATTER", SqlDbType.NVarChar);
                Comm.Parameters["@DRYMATTER"].Value = Drymatter_edt.Text.Trim();
                Comm.Parameters.Add("@CRUDEFIBER", SqlDbType.NVarChar);
                Comm.Parameters["@CRUDEFIBER"].Value = Crudefiber_edt.Text.Trim();
                Comm.Parameters.Add("@PROTEIN", SqlDbType.NVarChar);
                Comm.Parameters["@PROTEIN"].Value = Protein_edt.Text.Trim();
                Comm.Parameters.Add("@ENERGY", SqlDbType.NVarChar);
                Comm.Parameters["@ENERGY"].Value = Energy_edt.Text.Trim();
                Comm.Parameters.Add("@CA", SqlDbType.NVarChar);
                Comm.Parameters["@CA"].Value = Ca_edt.Text.Trim();
                Comm.Parameters.Add("@P", SqlDbType.NVarChar);
                Comm.Parameters["@P"].Value = P_edt.Text.Trim();

                Comm.ExecuteNonQuery();
                Feedmgmt_grid.DataBind();

                Feedname_edt.Text = "";
                Feedcat_ddl1.SelectedIndex = 0;
                Drymatter_edt.Text = "";
                Crudefiber_edt.Text = "";
                Energy_edt.Text = "";
                Protein_edt.Text = "";
                Ca_edt.Text = "";
                P_edt.Text = "";


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
    protected void Feedmgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_feed")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM FEED WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Feedmgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Feedmgmt_grid.DataBind();

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
    protected void Feedmgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
                
        DropDownList DDL = (DropDownList)Feedmgmt_grid.Rows[e.RowIndex].FindControl("Feedcat_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["FEEDCATNAME"] = DDL.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE FEED SET  NAME = @NAME, CATEGORYID = @FEEDCATNAME, DRYMATTER = @DRYMATTER, CRUDEFIBER = @CRUDEFIBER, PROTEIN = @PROTEIN, ENERGY = @ENERGY, CA = @CA, P = @P   WHERE ID = @ID";
        }

        Feedmgmt_grid.DataBind();
    }

}