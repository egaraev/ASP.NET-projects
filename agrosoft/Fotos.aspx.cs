using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Fotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        string y = "";
        if (Request.QueryString["id"] != null)
        {
            y = Request.QueryString["id"];
        }
        else
        {
            Error_lb.Text = "Нет ID";
            return;
        }



        if (!Directory.Exists(Server.MapPath("~/files/fotos/") + y + "/"))
        {
            Error_lb.Text = "Нет Фото";
            return;
        }


        if (Directory.GetFiles(Server.MapPath("~/files/fotos/") + y + "/").Length == 0)
        {
            Error_lb.Text = "Нет Фото";
            return;
        }

        int z = 0;
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/files/fotos/") + y + "/");
        foreach(FileInfo file in dir.GetFiles())
        {
            if(file.Extension == ".jpg")
            {
                z++;
            }
        }

        for (int i = 1; i <= z; i++)
        {
            Image img = (Image)Page.FindControl("Foto" + i.ToString() + "_img");
            HyperLink hyp = (HyperLink)Page.FindControl("Hyper" + i.ToString() + "_hl");
            img.Visible = true;
            img.ImageUrl = "files/fotos/" + y + "/" + i.ToString() + ".jpg";
            //hyp.Attributes.Add("rel", "lightbox");
            hyp.NavigateUrl = "files/fotos/" + y + "/" + i.ToString() + ".jpg";
        }


    }
}