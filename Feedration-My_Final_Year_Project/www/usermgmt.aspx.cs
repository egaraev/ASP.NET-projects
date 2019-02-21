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

public partial class usermgmt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
    protected void Usermgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList DDL = (DropDownList)Usermgmt_grid.Rows[e.RowIndex].FindControl("Group_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["USER_GROUP_ID"] = DDL.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE USERS SET
                                            LOGIN = @LOGIN,PASSWORD = @PASSWORD, USER_GROUP_ID=@USER_GROUP_ID
                                         WHERE
                                            ID = @ID";
        }
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
                Comm.CommandText = @"INSERT INTO USERS (LOGIN, PASSWORD, USER_GROUP_ID) VALUES (@LOGIN, @PASSWORD, @USER_GROUP_ID)";
                Comm.Parameters.Add("@LOGIN", SqlDbType.NVarChar);
                Comm.Parameters["@LOGIN"].Value = Login_edt.Text.Trim();
                Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
                Comm.Parameters["@PASSWORD"].Value = Password_edt0.Text.Trim();
                Comm.Parameters.Add("@USER_GROUP_ID", SqlDbType.Int);
                Comm.Parameters["@USER_GROUP_ID"].Value = Group_ddl.SelectedValue;

                Comm.ExecuteNonQuery();
                Usermgmt_grid.DataBind();

                Login_edt.Text = "";
                Password_edt0.Text = "";
                Group_ddl.SelectedIndex = 0;



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


    protected void Usermgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Delete_user")
        {
            
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM USERS WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Usermgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Usermgmt_grid.DataBind();

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





}