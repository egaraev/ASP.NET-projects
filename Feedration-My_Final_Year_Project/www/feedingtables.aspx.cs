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

public partial class energyexchange : System.Web.UI.Page
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


                Comm.CommandText = @"INSERT INTO ENERGYCHANGE (TARGETINCREASEID, ANIMALSID, DRYMATTER, CRUDEFIBER, PROTEIN, ENERGY, CA, P, RATIOID, TYPE, SEASON) VALUES (@TARGETINCREASEID, @ANIMALSID, @DRYMATTER, @CRUDEFIBER, @PROTEIN, @ENERGY, @CA, @P, @RATIOID, @TYPE, @SEASON)";
                Comm.Parameters.Add("@ANIMALSID", SqlDbType.Int);
                Comm.Parameters["@ANIMALSID"].Value = Herd_ddl.SelectedValue;
                Comm.Parameters.Add("@TARGETINCREASEID", SqlDbType.Int);
                Comm.Parameters["@TARGETINCREASEID"].Value = Target_ddl.SelectedValue;
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
                Comm.Parameters.Add("@RATIOID", SqlDbType.Int);
                Comm.Parameters["@RATIOID"].Value = Ratio_ddl.SelectedValue;
                Comm.Parameters.Add("@TYPE", SqlDbType.Int);
                Comm.Parameters["@TYPE"].Value = type_ddl.SelectedValue;
               // Comm.Parameters.Add("@WEIGHTPERCENT", SqlDbType.NVarChar);
             //   Comm.Parameters["@WEIGHTPERCENT"].Value = weight_edt.Text.Trim();
                Comm.Parameters.Add("@SEASON", SqlDbType.Int);
                Comm.Parameters["@SEASON"].Value = season_ddl.SelectedValue;
                             

                                 
                Comm.ExecuteNonQuery();
                Energymgmt_grid.DataBind();

               
                Herd_ddl.SelectedIndex = 0;
                Target_ddl.SelectedIndex = 0;
                Drymatter_edt.Text = "";
                Crudefiber_edt.Text = "";
                Energy_edt.Text = "";
                Protein_edt.Text = "";
                Ca_edt.Text = "";
                P_edt.Text = "";
                Ratio_ddl.SelectedIndex = 0;
                type_ddl.SelectedIndex = 0;
            //    weight_edt.Text = "";
                season_ddl.SelectedIndex = 0;


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
    protected void Energymgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_energy")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM ENERGYCHANGE WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Energymgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Energymgmt_grid.DataBind();

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
    protected void Energymgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList DDL = (DropDownList)Energymgmt_grid.Rows[e.RowIndex].FindControl("Animalcat_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["ANIMALSID"] = DDL.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ENERGYCHANGE SET  ANIMALSID = @ANIMALSID, TARGETINCREASEID = @TARGETINCREASENAME, DRYMATTER = @DRYMATTER, CRUDEFIBER = @CRUDEFIBER, PROTEIN = @PROTEIN, ENERGY = @ENERGY, CA = @CA, P = @P, RATIOID = @RATIONAME, TYPE = @TYPE,  SEASON = @SEASON   WHERE ENERGYCHANGE.ID = @ID";
        }


        DropDownList DDL1 = (DropDownList)Energymgmt_grid.Rows[e.RowIndex].FindControl("Targetcat_grid_ddl");

        if (DDL1 != null)
        {
            e.NewValues["TARGETINCREASENAME"] = DDL1.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ENERGYCHANGE SET  ANIMALSID = @ANIMALSID, TARGETINCREASEID = @TARGETINCREASENAME, DRYMATTER = @DRYMATTER, CRUDEFIBER = @CRUDEFIBER, PROTEIN = @PROTEIN, ENERGY = @ENERGY, CA = @CA, P = @P, RATIOID = @RATIONAME, TYPE = @TYPE,  SEASON = @SEASON   WHERE ENERGYCHANGE.ID = @ID";
        }


        DropDownList DDL2 = (DropDownList)Energymgmt_grid.Rows[e.RowIndex].FindControl("Ratio_grid_ddl");

        if (DDL2 != null)
        {
            e.NewValues["RATIONAME"] = DDL2.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE ENERGYCHANGE SET  ANIMALSID = @ANIMALSID, TARGETINCREASEID = @TARGETINCREASENAME, DRYMATTER = @DRYMATTER, CRUDEFIBER = @CRUDEFIBER, PROTEIN = @PROTEIN, ENERGY = @ENERGY, CA = @CA, P = @P, RATIOID = @RATIONAME, TYPE = @TYPE,  SEASON = @SEASON   WHERE ENERGYCHANGE.ID = @ID";
        }


          
        Energymgmt_grid.DataBind();
    }
}