﻿using System;
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

public partial class targetcatmgmt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Targetcatmgmt_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_targetcat")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM TARGETCATEGORY WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Targetcatmgmt_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Targetcatmgmt_grid.DataBind();

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

    protected void Targetcatmgmt_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlDataSource1.UpdateCommand = @"UPDATE TARGETCATEGORY SET NAME = @NAME WHERE ID = @ID";
        Targetcatmgmt_grid.DataBind();
    }
    protected void add_btn_Click1(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

            try
            {
                Comm.CommandText = "INSERT INTO TARGETCATEGORY(NAME) VALUES (@NAME)";
                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = Targetcat_edt.Text.Trim();


                Comm.ExecuteNonQuery();
                Targetcatmgmt_grid.DataBind();

                Targetcat_edt.Text = "";



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
    protected void add_btn_Click(object sender, EventArgs e)
    {

    }
}