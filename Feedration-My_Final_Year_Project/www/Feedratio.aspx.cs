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

public partial class Feedratio : System.Web.UI.Page
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


                Comm.CommandText = @"INSERT INTO FEEDRATIO (NAME, COPERCENT, ROPERCENT, SUPERCENT) VALUES (@NAME, @COPERCENT, @ROPERCENT, @SUPERCENT)";
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Name_edt.Text.Trim();
                Comm.Parameters.Add("@COPERCENT", SqlDbType.Int);
                Comm.Parameters["@COPERCENT"].Value = Copercent_edt.Text.Trim();
                Comm.Parameters.Add("@ROPERCENT", SqlDbType.Int);
                Comm.Parameters["@ROPERCENT"].Value = Ropercent_edt.Text.Trim();
                Comm.Parameters.Add("@SUPERCENT", SqlDbType.Int);
                Comm.Parameters["@SUPERCENT"].Value = Supercent_edt.Text.Trim();
                
                
                Comm.ExecuteNonQuery();
                Ratiomgmt_grid.DataBind();



                Name_edt.Text = "";
                Copercent_edt.Text = "";
                Ropercent_edt.Text = "";
                Supercent_edt.Text = "";




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
    protected void Ratiomgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_ratio")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM FEEDRATIO WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Ratiomgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Ratiomgmt_grid.DataBind();

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

    protected void Ratiomgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlDataSource1.UpdateCommand = @"UPDATE FEEDRATIO SET NAME = @NAME, COPERCENT = @COPERCENT, ROPERCENT = @ROPERCENT, SUPERCENT = @SUPERCENT WHERE ID = @ID";
        Ratiomgmt_grid.DataBind();
    }
}