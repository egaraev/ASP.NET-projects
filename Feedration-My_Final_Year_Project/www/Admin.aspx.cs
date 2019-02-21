using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void add_btn_Click(object sender, EventArgs e)
    {
        
        if (selectmodule_ddl.SelectedIndex == 1)
        {
         Response.Redirect("Usermgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 2)
        {
            Response.Redirect("Groupmgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 3)
        {
            Response.Redirect("Breedmgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 4)
        {
            Response.Redirect("Animals.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 5)
        {
            Response.Redirect("Agemgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 6)
        {
            Response.Redirect("Feedtypemgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 7)
        {
            Response.Redirect("Feedmgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 8)
        {
            Response.Redirect("Weightmgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 9)
        {
            Response.Redirect("Targetcatmgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 10)
        {
            Response.Redirect("Targetnamemgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 11)
        {
            Response.Redirect("Targetvaluemgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 12)
        {
            Response.Redirect("Targets.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 13)
        {
            Response.Redirect("Feedratio.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 14)
        {
            Response.Redirect("Animalfeedmgmt.aspx");
        }

        else if (selectmodule_ddl.SelectedIndex == 15)
        {
            Response.Redirect("Feedingtables.aspx");
        }



    }
}