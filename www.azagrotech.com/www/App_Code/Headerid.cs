using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Headerid
/// </summary>
public class Headerid
{
    static public string get_headerid()
    {
        return get_headerid(false);
    }

    static public string get_headerid(bool withdeleted)
    {
        try
        {
            string id = "";

            if (HttpContext.Current.Request.QueryString["id"] == null)
            {
                return "";
            }
            else
            {
                id = HttpContext.Current.Request.QueryString["id"];
            }
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                if (withdeleted)
                {
                    Comm.CommandText = @"SELECT ID FROM HEADERS";
                }
                else
                {
                    Comm.CommandText = @"SELECT ID FROM HEADERS WHERE ACTIVE='TRUE'";
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

    static public string get_headerid(string param)
    {
        return get_headerid(param,false);
    }

    static public string get_headerid(string param, bool withdeleted)
    {
        try
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                if (withdeleted)
                {
                    Comm.CommandText = @"SELECT ID FROM HEADERS";
                }
                else
                {
                    Comm.CommandText = @"SELECT ID FROM HEADERS WHERE ACTIVE='TRUE'";
                }
                SqlDataReader reader = Comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == param)
                    {
                        return param;
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