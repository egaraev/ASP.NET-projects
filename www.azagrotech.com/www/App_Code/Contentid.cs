using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Contentid
/// </summary>
public class Contentid
{
    static public string get_contentid()
    {
        return get_contentid(false);
    }

    static public string get_contentid(bool withdeleted)
    {
        try
        {
            string id = "";

            if (HttpContext.Current.Request.QueryString["cat"] == null)
            {
                return "";
            }
            else
            {
                id = HttpContext.Current.Request.QueryString["cat"];
            }
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                if (withdeleted)
                {
                    Comm.CommandText = @"SELECT ID FROM MENU";
                }
                else
                {
                    Comm.CommandText = @"SELECT ID FROM MENU WHERE ACTIVE='TRUE'";
                }
                SqlDataReader reader = Comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == id)
                    {
                        return id;
                    }
                }
                return "";
            }
        }
        catch
        {
            return "";
        }
    }
}