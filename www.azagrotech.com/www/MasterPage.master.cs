using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Add_Language_To_Link(HyperLink Link, string lngname)
    {
        string outquery = Request.Url.Query;
        string outpathandquery = Request.Url.PathAndQuery;
        string lngvalues = "";
        int cursor = 0;
        int index = 0;
        int length = 0;
        int difference = outpathandquery.Length - outquery.Length;

        if (outpathandquery.IndexOf('?') == -1)
        {
            outpathandquery += string.Format("?lng={0}", lngname);
        }
        else if (outpathandquery.IndexOf("lng=") == -1)
        {
            outpathandquery += string.Format("&lng={0}", lngname);
        }
        else
        {
            lngvalues = Request.QueryString["lng"];
            while (outpathandquery.IndexOf("&lng=") != -1)
            {
                outpathandquery = outpathandquery.Remove(outpathandquery.IndexOf("&lng="), 1);
            }

            while (outpathandquery.IndexOf("lng=") != -1)
            {
                index = lngvalues.IndexOf(',');
                if (index == -1)
                {
                    length = lngvalues.Length;
                    lngvalues = "";
                }
                else
                {
                    length = lngvalues.Substring(0, index).Length;
                    lngvalues = lngvalues.Remove(0, index + 1);
                }

                cursor = outpathandquery.IndexOf("lng=");
                if (cursor + 4 + length < outpathandquery.Length && outpathandquery.Substring(cursor + 4 + length, 1) == "&")
                {
                    outpathandquery = outpathandquery.Remove(cursor, 5 + length);
                }
                else
                {
                    outpathandquery = outpathandquery.Remove(cursor, 4 + length);
                }
            }
            outquery = outpathandquery.Substring(difference);

            if (outquery == "")
            {
                outpathandquery += string.Format("?lng={0}", lngname);
            }
            else if (outquery != "?")
            {
                outpathandquery += string.Format("&lng={0}", lngname);
            }
            else if (outquery == "?")
            {
                outpathandquery += string.Format("lng={0}", lngname);
            }

        }
        Link.NavigateUrl = outpathandquery;
    }

    protected void Controls_Language()
    {
        if (HyperLinkRu != null)
            Add_Language_To_Link(HyperLinkRu, "ru");
        if (HyperLinkAz != null)
            Add_Language_To_Link(HyperLinkAz, "az");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Controls_Language();

        string Lang = "ru";
        string currentid = "";

        if (Session["lng"] == null)
        {
            Session["lng"] = "ru";
        }
        if (Session["lng"] != null)
        {
            string Str = Session["lng"].ToString();
            if (Str == "az") Lang = "az";
            else if (Str == "ru") Lang = "ru";
        }
        if (Request.QueryString["lng"] != null)
        {
            string Str = Request.QueryString["lng"];
            if (Str == "az") Lang = "az";
            else if (Str == "ru") Lang = "ru";
            Session["lng"] = Str;
        }

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();

           /* if (Lang == "ru")
            {
                Comm.CommandText = @"SELECT ID, NAMERU FROM HEADERS WHERE ACTIVE='TRUE'";
            }
            else if (Lang == "az")
            {
                Comm.CommandText = @"SELECT ID, NAMEAZ FROM HEADERS WHERE ACTIVE='TRUE'";
            }
            else
            {
                Comm.CommandText = @"SELECT ID, NAMERU FROM HEADERS WHERE ACTIVE='TRUE'";
            }*/

            Comm.CommandText=string.Format("SELECT ID, NAME{0} FROM HEADERS WHERE ACTIVE='TRUE'",Lang);

            SqlDataReader reader = Comm.ExecuteReader();
            //Header_lb.Text = "<table  border='1px solid black'  cellpadding='0' cellspacing='0' width='1020px' height='40px'><tr class='style7'>";
            bool hasmenus = false;
      /*      while (reader.Read())
            {
                hasmenus = true;
                Header_lb.Text += string.Format("<td><a  href='Default.aspx?id={0}'><label style='margin-bottom:15px; width:120px;height:40px; position:relative; color:white;text-decoration:none;cursor:pointer;'>{1}</label></a></td>", reader[0].ToString(), reader[1].ToString());
            }
            reader.Close();
            if (hasmenus)
            {
                Header_lb.Text += "<td>&nbsp;</td>";
            }
            Header_lb.Text += "</tr></table>";

            */
            Literal1.Text = "<table  border='0'  cellpadding='0' cellspacing='0' width='1020px' height='40px'><tr>";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Literal1.Text += string.Format("<td><a href=\"Default.aspx?id={0}\" class=\"style7\">{1}</a></td>", reader[0].ToString(), reader[1].ToString());
                }
            }
            Literal1.Text += "</tr></table>";
            reader.Close();
            if (Request.QueryString["id"] != null)
            {
                currentid = Request.QueryString["id"];
            }
                
            else
            {
                Comm.CommandText = @"SELECT MIN(ID) FROM HEADERS WHERE ACTIVE='TRUE'";
                reader = Comm.ExecuteReader();
                if (reader.Read())
                {
                    if (reader[0].ToString() != "")
                    {
                        currentid = reader[0].ToString();
                    }
                }
                reader.Close();
            }


            if (Headerid.get_headerid(currentid) != "")
            {
                if (Lang == "ru")
                {
                    Comm.CommandText = @"SELECT ID, NAMERU FROM MENU WHERE ACTIVE='TRUE' AND HEADERID=@HEADERID";
                }
                else if (Lang == "az")
                {
                    Comm.CommandText = @"SELECT ID, NAMEAZ FROM MENU WHERE ACTIVE='TRUE' AND HEADERID=@HEADERID";
                }
                else
                {
                    Comm.CommandText = @"SELECT ID, NAMERU FROM MENU WHERE ACTIVE='TRUE' AND HEADERID=@HEADERID";
                }
                Comm.Parameters.Add("@HEADERID", SqlDbType.Int);
                Comm.Parameters["@HEADERID"].Value = currentid;

                reader = Comm.ExecuteReader();
                Sidebar_lb.Text = "<table border='0' cellpadding='0' cellspacing='0' width='120px'>";
                hasmenus = false;
                while (reader.Read())
                {
                    hasmenus = true;
                    Sidebar_lb.Text += string.Format("<tr><td><a href='Default.aspx?id={2}&cat={0}'>{1}</a></td></tr>", reader[0].ToString(), reader[1].ToString(),currentid);
                }
                reader.Close();
          
                Sidebar_lb.Text += "</table>";


                if (Contentid.get_contentid() != "")
                {
                    if (Lang == "ru")
                    {
                        Comm.CommandText = @"SELECT NAMERU FROM CONTENT WHERE MENUID=@MENUID";
                    }
                    else if (Lang == "az")
                    {
                        Comm.CommandText = @"SELECT NAMEAZ FROM CONTENT WHERE MENUID=@MENUID";
                    }
                    else
                    {
                        Comm.CommandText = @"SELECT NAMERU FROM CONTENT WHERE MENUID=@MENUID";
                    }
                    Comm.Parameters.Add("@MENUID", SqlDbType.Int);
                    Comm.Parameters["@MENUID"].Value = Request.QueryString["cat"];
                    reader = Comm.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader[0].ToString() != "")
                        {
                            Content_lb.Text = reader[0].ToString();
                        }
                    }
                    reader.Close();
                }
                else
                {
                    if (Lang == "ru")
                    {
                        Comm.CommandText = @"SELECT CONTENTRU FROM HEADERS WHERE ACTIVE='TRUE' AND ID=@ID";
                    }
                    else if (Lang == "az")
                    {
                        Comm.CommandText = @"SELECT CONTENTAZ FROM HEADERS WHERE ACTIVE='TRUE' AND ID=@ID";
                    }
                    else
                    {
                        Comm.CommandText = @"SELECT CONTENTRU FROM HEADERS WHERE ACTIVE='TRUE' AND ID=@ID";
                    }
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = currentid;
                    reader = Comm.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader[0].ToString() != "")
                        {
                            Content_lb.Text = reader[0].ToString();
                        }
                    }
                    reader.Close();
                }
            }

        }
    }
}
