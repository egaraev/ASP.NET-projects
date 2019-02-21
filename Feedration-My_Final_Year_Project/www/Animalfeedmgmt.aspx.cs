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


public partial class animalfeedmgmt : System.Web.UI.Page
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
                Comm.CommandText = @"INSERT INTO ANIMALFEEDTYPE (FEEDID, ANIMALGROUPID) VALUES (@FEEDID, @ANIMALGROUPID)";
                Comm.Parameters.Add("@FEEDID", SqlDbType.Int);
                Comm.Parameters["@FEEDID"].Value = Feed_ddl.SelectedValue;
                Comm.Parameters.Add("@ANIMALGROUPID", SqlDbType.Int);
                Comm.Parameters["@ANIMALGROUPID"].Value = Animal_ddl.SelectedValue;
                

                Comm.ExecuteNonQuery();
                Animalfeedmgmt_grid.DataBind();

                Animal_ddl.SelectedIndex = 0;
                Feed_ddl.SelectedIndex = 0;
              
     
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
    protected void Animalfeedmgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_animalfeed")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM ANIMALFEEDTYPE WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Animalfeedmgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Animalfeedmgmt_grid.DataBind();

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
    protected void Animalfeedmgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        DropDownList DDL = (DropDownList)Animalfeedmgmt_grid.Rows[e.RowIndex].FindControl("Animal_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["ANIMALGROUP"] = DDL.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ANIMALFEEDTYPE  SET ANIMALGROUPID = @ANIMALGROUP , FEEDID = @FEEDNAME WHERE ID = @ID";
        }



        DropDownList DDL2 = (DropDownList)Animalfeedmgmt_grid.Rows[e.RowIndex].FindControl("Feed_grid_ddl");

        if (DDL2 != null)
        {
            e.NewValues["FEEDNAME"] = DDL2.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ANIMALFEEDTYPE  SET ANIMALGROUPID = @ANIMALGROUP , FEEDID = @FEEDNAME WHERE ID = @ID";
        }


       


        Animalfeedmgmt_grid.DataBind();
    }
}