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

public partial class animals : System.Web.UI.Page
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
                Comm.CommandText = @"INSERT INTO ANIMALS (NAME, ANIMALGROUPID, ANIMALWEIGHTID, ANIMALAGEID) VALUES (@NAME, @ANIMALGROUPID, @ANIMALWEIGHTID, @ANIMALAGEID)";
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Herdname_edt2.Text.Trim();
                Comm.Parameters.Add("@ANIMALGROUPID", SqlDbType.Int);
                Comm.Parameters["@ANIMALGROUPID"].Value = Animalcat_ddl.SelectedValue;
                Comm.Parameters.Add("@ANIMALAGEID", SqlDbType.Int);
                Comm.Parameters["@ANIMALAGEID"].Value = Animalage_ddl0.SelectedValue;
                Comm.Parameters.Add("@ANIMALWEIGHTID", SqlDbType.Int);
                Comm.Parameters["@ANIMALWEIGHTID"].Value = Weight_ddl1.SelectedValue;

                Comm.ExecuteNonQuery();
                Herdmgmt_grid.DataBind();

                Herdname_edt2.Text = "";
                Animalcat_ddl.SelectedIndex = 0;
                Animalage_ddl0.SelectedIndex = 0;
                Weight_ddl1.SelectedIndex = 0;


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
    protected void Herdmgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_herd")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM ANIMALS WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Herdmgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Herdmgmt_grid.DataBind();

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
    protected void Herdmgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList DDL = (DropDownList)Herdmgmt_grid.Rows[e.RowIndex].FindControl("Animalcat_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["ANIMALGROUPID"] = DDL.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ANIMALS SET NAME = @NAME, ANIMALGROUPID = @ANIMALGROUPID, ANIMALWEIGHTID = @ANIMALWEIGHTID, ANIMALAGEID = @ANIMALAGEID WHERE ANIMALS.ID = @ID";
        }


        DropDownList DDL1 = (DropDownList)Herdmgmt_grid.Rows[e.RowIndex].FindControl("Animalage_grid_ddl");

        if (DDL1 != null)
        {
            e.NewValues["ANIMALAGEID"] = DDL1.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ANIMALS SET NAME = @NAME, ANIMALGROUPID = @ANIMALGROUPID, ANIMALWEIGHTID = @ANIMALWEIGHTID, ANIMALAGEID = @ANIMALAGEID WHERE ANIMALS.ID = @ID";
        }

        DropDownList DDL2 = (DropDownList)Herdmgmt_grid.Rows[e.RowIndex].FindControl("Animalweight_grid_ddl");

        if (DDL2 != null)
        {
            e.NewValues["ANIMALWEIGHTID"] = DDL2.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ANIMALS SET NAME = @NAME, ANIMALGROUPID = @ANIMALGROUPID, ANIMALWEIGHTID = @ANIMALWEIGHTID, ANIMALAGEID = @ANIMALAGEID WHERE ANIMALS.ID = @ID";
        }


        Herdmgmt_grid.DataBind();
    }
}