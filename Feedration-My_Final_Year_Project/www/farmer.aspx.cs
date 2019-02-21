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
using System.Collections;

public partial class farmer : System.Web.UI.Page
{
    private string USERID()
    {
        // Извлекаем куку с аутентификационными данными
        HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

        // Дешифруем ее в тикет
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

        // Создаем пользовательский контекст
        FormsIdentity identity = new FormsIdentity(ticket);


        //System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity, new string[] { AuthCookieParce.UserID(identity.Name).ToString() });
        return AuthCookieParce.UserID(identity.Name).ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
            SqlDataSource8.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlDataSource8.SelectCommand = "SELECT F.ID AS ID, F.QUANTITY AS QUANTITY, F.RATIONGROUP AS RATIONGROUP, AG.NAME AS BREED, AW.NAME AS WEIGHT, AA.NAME AS AGE, T.NAME AS TARGET FROM FARM F, ANIMALS A, ANIMALGROUP AG, ANIMALWEIGHT AW, ANIMALAGE AA, TARGETINCREASE TI,TARGETCATEGORY T WHERE F.ANIMALSID=A.ID AND A.ANIMALWEIGHTID=AW.ID AND A.ANIMALAGEID=AA.ID AND F.TARGETINCREASEID=TI.ID AND AG.ID=ANIMALGROUPID AND TI.TARGETCATEGORYID=T.ID";
            SqlDataSource5.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlDataSource5.SelectCommand = "SELECT A.ID AS ID, 'ANIMAL: '+ AG.NAME + ' AGE: ' + AA.NAME + ' WEIGHT: ' + AW.NAME AS NAME FROM ANIMALS A, ANIMALAGE AA, ANIMALWEIGHT AW, ANIMALGROUP AG WHERE A.ANIMALGROUPID=AG.ID AND A.ANIMALWEIGHTID=AW.ID AND A.ANIMALAGEID=AA.ID";

            SqlDataSource7.SelectCommand = "select t.name +' - '+ ti.name as name, ti.id as id from targetcategory t, targetincrease ti, ENERGYCHANGE EC WHERE TI.ID=EC.TARGETINCREASEID and ti.targetcategoryid=t.id";

            SqlDataSource1.SelectCommand = "SELECT FEED_STOCK.FEEDID, FEED_STOCK.WEIGHT, FEED.NAME AS FEEDNAME, FEED_STOCK.ID, FEED.ID AS FEED_ID FROM FEED_STOCK INNER JOIN FEED ON FEED_STOCK.FEEDID = FEED.ID AND USER_ID=@USER_ID";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("USER_ID", TypeCode.Int32, USERID());
           

        
        Farm_grid.DataBind();
    }
   
    
    protected void add_btn_Click(object sender, EventArgs e)
    {
        
    }
    protected void stock_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_stock")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM FEED_STOCK WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = stock_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    stock_grid.DataBind();

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
    protected void stock_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList DDL = (DropDownList)stock_grid.Rows[e.RowIndex].FindControl("Feed_grid_ddl");

        if (DDL != null)
        {
            e.NewValues["FEEDNAME"] = DDL.SelectedItem.Value;
            SqlDataSource1.UpdateCommand = @"UPDATE FEED_STOCK SET FEEDID = @FEEDNAME , WEIGHT = @WEIGHT , USER_ID = @USER_ID  WHERE ID = @ID";
            SqlDataSource1.UpdateParameters.Clear();
            SqlDataSource1.UpdateParameters.Add("USER_ID", TypeCode.Int32, USERID());
        }
        

        stock_grid.DataBind();
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
                Comm.CommandText = @"INSERT INTO FEED_STOCK (FEEDID, WEIGHT, USER_ID) VALUES (@FEEDID, @WEIGHT, @USERID)";
                Comm.Parameters.Add("@FEEDID", SqlDbType.Int);
                Comm.Parameters["@FEEDID"].Value = Feedcat_ddl1.SelectedValue;
                Comm.Parameters.Add("@WEIGHT", SqlDbType.NVarChar);
                Comm.Parameters["@WEIGHT"].Value = Feedweight_edt0.Text.Trim();
                Comm.Parameters.Add("@USERID", SqlDbType.Int);
                Comm.Parameters["@USERID"].Value = USERID();


                Comm.ExecuteNonQuery();
                stock_grid.DataBind();


                Feedweight_edt0.Text = "";
                Feedcat_ddl1.SelectedIndex = 0;



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
    
    
    
    
    
    protected void add_btn1_Click(object sender, EventArgs e)
    {
        Error_lb.Visible = true;
        Error_lb.Text = "Popka durak";
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Conn.Open();
            try
            {
                /*Comm.CommandText = @"INSERT INTO FARM (ANIMALSID, QUANTITY, RATIONGROUP, USER_ID) VALUES (@ANIMALSID, @QUANTITY, @RATIONGROUP, 2); INSERT INTO ANIMALS (ANIMALWEIGHTID, ANIMALAGEID) VALUES (@ANIMALWEIGHTID, @ANIMALAGEID); INSERT INTO TARGETCATEGORY (ID) VALUES (@TARGETCATEGORYID)";
                Comm.Parameters.Add("@RATIONGROUP", SqlDbType.NVarChar);
                Comm.Parameters["@RATIONGROUP"].Value = ration_edt.Text.Trim();
                Comm.Parameters.Add("@ANIMALSID", SqlDbType.Int);
                Comm.Parameters["@ANIMALSID"].Value = Breed_ddl.SelectedValue;
                Comm.Parameters.Add("@ANIMALAGEID", SqlDbType.Int);
                Comm.Parameters["@ANIMALAGEID"].Value = Age_ddl.SelectedValue;
                Comm.Parameters.Add("@ANIMALWEIGHTID", SqlDbType.Int);
                Comm.Parameters["@ANIMALWEIGHTID"].Value = Weight_ddl.SelectedValue;
                Comm.Parameters.Add("@TARGETCATEGORYID", SqlDbType.Int);
                Comm.Parameters["@TARGETCATEGORYID"].Value = Grow_ddl.SelectedValue;               
                Comm.Parameters.Add("@QUANTITY", SqlDbType.Int);
                Comm.Parameters["@QUANTITY"].Value = Quantity_edt.Text.Trim();

                try
                {

                    Comm.ExecuteNonQuery();
                    stock_grid.DataBind();
                }

                catch (SqlException E)
                {
                    Label19.Text = E.Message;
                }
                */

                //Begin Выбор ID животного с выбранными параметрами
               
               
                  
                  
               
                //End выбор ID животного

                //Внесение данных в базу

                Comm.CommandText = @"INSERT INTO FARM (ANIMALSID, QUANTITY, RATIONGROUP, USER_ID, TARGETINCREASEID) VALUES (@ANIMALSID,@QUANTITY, @RATIONGROUP, @USERID, @TARGETINCREASEID)";
                Comm.Parameters.Add("@RATIONGROUP", SqlDbType.NVarChar);
                Comm.Parameters["@RATIONGROUP"].Value = ration_edt.Text.Trim();
                Comm.Parameters.Add("@ANIMALSID", SqlDbType.Int);
                Comm.Parameters["@ANIMALSID"].Value = animal_ddl.SelectedValue;
                Comm.Parameters.Add("@TARGETINCREASEID", SqlDbType.Int);
                Comm.Parameters["@TARGETINCREASEID"].Value = Grow_ddl.SelectedValue;
                Comm.Parameters.Add("@QUANTITY", SqlDbType.Int);
                Comm.Parameters["@QUANTITY"].Value = Quantity_edt.Text.Trim();
                Comm.Parameters.Add("@USERID", SqlDbType.Int);
                Comm.Parameters["@USERID"].Value = USERID();
                

               
                    Comm.ExecuteNonQuery();
                    Farm_grid.DataBind();
              


                ration_edt.Text = "";
                
                animal_ddl.SelectedIndex = 0;
              
                Grow_ddl.SelectedIndex = 0;
                Quantity_edt.Text = "";


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
    protected void farm_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void farm_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_farm")
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Conn.Open();

                try
                {
                    Comm.CommandText = "DELETE FROM FARM WHERE ID=@ID";
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = Farm_grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                    Comm.ExecuteNonQuery();
                    Farm_grid.DataBind();

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
    protected void calc_btn0_Click(object sender, EventArgs e)
    {
        int animalid = Convert.ToInt32(Grow_ddl5.SelectedValue);
        int targetincrease = Convert.ToInt32(Grow_ddl6.SelectedValue);
        bool season = Convert.ToBoolean(season_ddl0.SelectedValue);
        bool type = Convert.ToBoolean(keepgrp_ddl.SelectedValue);
        ArrayList feedidss = new ArrayList();
        ArrayList drymatter = new ArrayList();
        ArrayList crudefiber = new ArrayList();
        ArrayList protein = new ArrayList();
        ArrayList energy = new ArrayList();
        ArrayList ca = new ArrayList();
        ArrayList p = new ArrayList();
        ArrayList feed = new ArrayList();
        ArrayList feedcategory = new ArrayList();
        ArrayList feedids = new ArrayList();
        ArrayList feedweights= new ArrayList();
        Dictionary<string, object> energychange = new Dictionary<string, object>();
        Dictionary<string, object> ratio = new Dictionary<string, object>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            conn.Open();

           
          
            int count = 0;
            comm.Parameters.Clear();
            comm.CommandText = "SELECT FEED_STOCK.FEEDID, FEED_STOCK.WEIGHT AS WEIGHT, FEED.NAME AS FEEDNAME, FEED_STOCK.ID, FEED.ID AS FEED_ID FROM FEED_STOCK INNER JOIN FEED ON FEED_STOCK.FEEDID = FEED.ID";

            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read()) 
            {
                feedids.Add(reader["FEED_ID"]);
                feedweights.Add(reader["WEIGHT"]);
            }
            reader.Close();
            string feedid = feedids[0].ToString();
            for (int i = 1; i <= feedids.Count - 1; i++)
            {
                feedid += "," + feedids[i].ToString();
            }
            int animalsid = 0;
            int quantity = 0;
            comm.Parameters.Clear();
            comm.CommandText = string.Format("SELECT E.ANIMALSID,F.QUANTITY AS QUANTITY,E.DRYMATTER,E.CRUDEFIBER,E.PROTEIN,E.ENERGY,E.CA,E.P, R.COPERCENT,R.ROPERCENT,R.SUPERCENT FROM ENERGYCHANGE E, FEEDRATIO R, FARM F WHERE E.TARGETINCREASEID={0} AND E.SEASON='{2}' AND E.TYPE='{3}' AND E.RATIOID=R.ID AND E.ANIMALSID=F.ANIMALSID AND E.TARGETINCREASEID=F.TARGETINCREASEID AND F.RATIONGROUP={1}", targetincrease, animalid, season, type);
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    energychange["DRYMATTER"] = reader["DRYMATTER"].ToString();
                    energychange["CRUDEFIBER"] = reader["CRUDEFIBER"].ToString();
                    energychange["PROTEIN"] = reader["PROTEIN"].ToString();
                    energychange["ENERGY"] = reader["ENERGY"].ToString();
                    energychange["CA"] = reader["CA"].ToString();
                    energychange["P"] = reader["P"].ToString();
                    ratio["COPERCENT"] = reader["COPERCENT"].ToString();
                    ratio["ROPERCENT"] = reader["ROPERCENT"].ToString();
                    ratio["SUPERCENT"] = reader["SUPERCENT"].ToString();
                    animalsid = Convert.ToInt32(reader[0]);
                    quantity = Convert.ToInt32(reader["QUANTITY"]);
                    ratio_lb.Text = string.Format("<tr><td>Concentrated (15% H20)</td><td>{0}</td></tr><tr><td>Roughages (15% H20)</td><td>{1}</td></tr><tr><td>Succulent	(75% H20)</td><td>{2}</td></tr>", reader["COPERCENT"].ToString() + "%", reader["ROPERCENT"].ToString() + "%", reader["SUPERCENT"].ToString() + "%");

                }
            }

            reader.Dispose();
            conn.Close();


            string new123 = comm.CommandText;



            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = string.Format("SELECT F.ID, F.NAME AS FEED, F.DRYMATTER as DRYMATTER,F.CRUDEFIBER,F.PROTEIN,F.ENERGY,F.CA,F.P,FC.NAME AS CATEGORY FROM FEED F, ANIMALFEEDTYPE FT, ANIMALS A, ANIMALGROUP AG, FEEDCATEGORY FC WHERE FT.FEEDID=F.ID AND FT.ANIMALGROUPID=AG.ID AND A.ID={1} AND F.ID in ({0}) and F.CATEGORYID=FC.ID AND A.ANIMALGROUPID=AG.ID", feedid, animalsid);

            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                feedidss.Add(reader["ID"].ToString());
                drymatter.Add(reader["DRYMATTER"].ToString());
                crudefiber.Add(reader["CRUDEFIBER"].ToString());
                protein.Add(reader["PROTEIN"].ToString());
                energy.Add(reader["ENERGY"].ToString());
                ca.Add(reader["CA"].ToString());
                p.Add(reader["P"].ToString());
                feedcategory.Add(reader["CATEGORY"].ToString());
                feed.Add(reader["FEED"].ToString());
            }
            ArrayList feedkoef = new ArrayList();


            double cocrudefibersum = 0;
            double coproteinsum = 0;
            double coenergysum = 0;
            double cocasum = 0;
            double copsum = 0;
            double codrymattersum = 0;

            double rocrudefibersum = 0;
            double roproteinsum = 0;
            double roenergysum = 0;
            double rocasum = 0;
            double ropsum = 0;
            double rodrymattersum = 0;

            double sucrudefibersum = 0;
            double suproteinsum = 0;
            double suenergysum = 0;
            double sucasum = 0;
            double supsum = 0;
            double sudrymattersum = 0;


            double koefco = 0;
            double koefsu = 0;
            double koefro = 0;
            double koefficentco = 0;
            double koefficentro = 0;
            double koefficentsu = 0;
            double maxco = 0;
            double maxro = 0;
            double maxsu = 0;

           

            for (int i = 0; i <= feedidss.Count - 1; i++)
            {
                if (feedcategory[i].ToString().Substring(0, 2) == "Co")
                {

                    //drymattersum =drymattersum+ Convert.ToDecimal(drymatter[i]);
                    energy[i] = energy[i];
                    coenergysum += Convert.ToDouble(energy[i]);
                    cocrudefibersum += Convert.ToDouble(crudefiber[i]);
                    coproteinsum += Convert.ToDouble(protein[i]);
                    cocasum += Convert.ToDouble(ca[i]);
                    copsum += Convert.ToDouble(p[i]);
                    codrymattersum += Convert.ToDouble(drymatter[i]);
                    co_lb.Text = feed[i].ToString();
                    int k = 1;
                    koefficentco = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["COPERCENT"]) / 100 * quantity / codrymattersum;
                    for (int j = 0; j <= feedids.Count - 1; j++)
                    {
                        if (Convert.ToInt32(feedids[j]) == Convert.ToInt32(feedidss[i]))
                        {
                            k = j;

                        }
                    }
                    maxco = Convert.ToDouble(feedweights[k]);


                    if (maxco < koefficentco)
                    {

                        Button b = sender as Button;
                        if (b != null)
                        {
                            Literal c = (Literal)b.Parent.FindControl(string.Format("error{0}_lb", k.ToString()));
                            if (c != null)
                            {
                                c.Text = string.Format("Please add {0} category feed", feedcategory[i].ToString());

                            }
                        }

                    }



                }
                if (feedcategory[i].ToString().Substring(0, 2) == "Ro")
                {
                    //drymattersum =drymattersum+ Convert.ToDecimal(drymatter[i]);
                    crudefiber[i] = crudefiber[i];
                    roenergysum += Convert.ToDouble(energy[i]);
                    rocrudefibersum += Convert.ToDouble(crudefiber[i]);
                    roproteinsum += Convert.ToDouble(protein[i]);
                    rocasum += Convert.ToDouble(ca[i]);
                    ropsum += Convert.ToDouble(p[i]);
                    rodrymattersum += Convert.ToDouble(drymatter[i]);
                    ro_lb.Text = feed[i].ToString();


                    int k = 1;
                    koefficentro = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["ROPERCENT"]) / 100 * quantity / rodrymattersum;
                    for (int j = 0; j <= feedids.Count - 1; j++)
                    {
                        if (Convert.ToInt32(feedids[j]) == Convert.ToInt32(feedidss[i]))
                        {
                            k = j;

                        }
                    }
                    maxro = Convert.ToDouble(feedweights[k]);


                    if (maxro < koefficentro)
                    {

                        Button b = sender as Button;
                        if (b != null)
                        {
                            Literal c = (Literal)b.Parent.FindControl(string.Format("error{0}_lb", k.ToString()));
                            if (c != null)
                            {
                                c.Text = string.Format("Please add {0} category feed", feedcategory[i].ToString());

                            }
                        }

                    }


                }
                if (feedcategory[i].ToString().Substring(0, 2) == "Su")
                {
                    //drymattersum =drymattersum+ Convert.ToDecimal(drymatter[i]);
                    crudefiber[i] = crudefiber[i];
                    suenergysum += Convert.ToDouble(energy[i]);
                    sucrudefibersum += Convert.ToDouble(crudefiber[i]);
                    suproteinsum += Convert.ToDouble(protein[i]);
                    sucasum += Convert.ToDouble(ca[i]);
                    supsum += Convert.ToDouble(p[i]);
                    sudrymattersum += Convert.ToDouble(drymatter[i]);
                    su_lb.Text = feed[i].ToString();


                    int k = 1;
                    koefficentsu = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["SUPERCENT"]) / 100 * quantity / sudrymattersum;
                    for (int j = 0; j <= feedids.Count - 1; j++)
                    {
                        if (Convert.ToInt32(feedids[j]) == Convert.ToInt32(feedidss[i]))
                        {
                            k = j;

                        }
                    }
                    maxsu = Convert.ToDouble(feedweights[k]);


                    if (maxsu < koefficentsu)
                    {

                        Button b = sender as Button;
                        if (b != null)
                        {
                            Literal c = (Literal)b.Parent.FindControl(string.Format("error{0}_lb", k.ToString()));
                            if (c != null)
                            {
                                c.Text = string.Format("Please add {0} category feed", feedcategory[i].ToString());

                            }
                        }

                    }


                }
            }
            try
            {
                koefco = ((Convert.ToDouble(ratio["COPERCENT"]) / 100) * coenergysum * Convert.ToDouble(energychange["DRYMATTER"]));
                koefficentco = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["COPERCENT"]) / 100;

                co_energy.Text = koefco.ToString();
                co_p.Text = (koefficentco * copsum).ToString();
                co_ca.Text = (koefficentco * cocasum).ToString();
                co_crudefiber.Text = (koefficentco * cocrudefibersum).ToString();
                co_protein.Text = (koefficentco * coproteinsum).ToString();
                co_weight.Text = Math.Round((koefficentco / codrymattersum), 2).ToString();


                koefro = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["ROPERCENT"]) / 100;
                //ec_energy.Text = Math.Round(koefco, 2).ToString();
                ro_crudefiber.Text = (koefro * rocrudefibersum).ToString();
                ro_ca.Text = (koefro * rocasum).ToString(); ;
                ro_energy.Text = (koefro * roenergysum).ToString();
                ro_p.Text = (koefro * ropsum).ToString();
                ro_protein.Text = (koefro * roproteinsum).ToString();
                ro_weight.Text = Math.Round((koefro / rodrymattersum), 2).ToString();


                ec_ca.Text = energychange["CA"].ToString();
                ec_crudefiber.Text = energychange["CRUDEFIBER"].ToString();
                ec_protein.Text = energychange["PROTEIN"].ToString();
                ec_energy.Text = energychange["ENERGY"].ToString();
                ec_ca.Text = energychange["CA"].ToString();
                ec_p.Text = energychange["P"].ToString();



                koefsu = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["SUPERCENT"]) / 100;
                //ec_energy.Text = Math.Round(koefco, 2).ToString();
                su_crudefiber.Text = (koefsu * sucrudefibersum).ToString();
                su_ca.Text = (koefsu * sucasum).ToString();
                su_energy.Text = (koefsu * suenergysum).ToString();
                su_p.Text = (koefsu * supsum).ToString();
                su_protein.Text = (koefsu * suproteinsum).ToString();
                if (sudrymattersum == 0)
                {
                    su_weight.Text = "0";
                    total_lb.Text = string.Format("<tr><td>{0}</td><td>{1}</td></tr><tr><td>{2}</td><td>{3}</td></tr>", co_lb.Text, Convert.ToDouble(co_weight.Text) * quantity, ro_lb.Text, Convert.ToDouble(ro_weight.Text) * quantity);
                }
                else
                {
                    su_weight.Text = Math.Round((koefsu / sudrymattersum), 2).ToString();
                    total_lb.Text = string.Format("<tr><td>{0}</td><td>{1}</td></tr><tr><td>{2}</td><td>{3}</td></tr><tr><td>{4}</td><td>{5}</td></tr>", co_lb.Text, Convert.ToDouble(co_weight.Text) * quantity, ro_lb.Text, Convert.ToDouble(ro_weight.Text) * quantity, su_lb.Text, Convert.ToDouble(su_weight.Text) * quantity);
                }







                oq_ca.Text = Math.Round(((koefro * rocasum) + (koefficentco * cocasum) + (koefsu * sucasum) - Convert.ToDouble(energychange["CA"])), 3).ToString();
                oq_ca.ForeColor = System.Drawing.Color.Red;

                oq_energy.Text = Math.Round(((koefro * roenergysum) + (koefficentco * coenergysum) + (koefsu * suenergysum) - Convert.ToDouble(energychange["ENERGY"])), 3).ToString();
                oq_energy.ForeColor = System.Drawing.Color.Red;

                oq_protein.Text = Math.Round(((koefro * roproteinsum) + (koefficentco * coproteinsum) + (koefsu * suproteinsum) - Convert.ToDouble(energychange["PROTEIN"])), 3).ToString();
                oq_protein.ForeColor = System.Drawing.Color.Red;

                oq_crudefiber.Text = Math.Round(((koefro * rocrudefibersum) + (koefficentco * cocrudefibersum) + (koefsu * sucrudefibersum) - Convert.ToDouble(energychange["CRUDEFIBER"])), 3).ToString();
                oq_crudefiber.ForeColor = System.Drawing.Color.Red;

                oq_p.Text = Math.Round(((koefro * ropsum) + (koefficentco * copsum) + (koefsu * supsum) - Convert.ToDouble(energychange["P"])), 3).ToString();
                oq_p.ForeColor = System.Drawing.Color.Red;




                // ro_lbl.Text = Math.Round(koefro, 2).ToString();
                // co_energy.Text = "energy change " + Convert.ToDouble(energychange["ENERGY"]).ToString() + " COPERCENT " + (Convert.ToDouble(ratio["COPERCENT"]) / 100).ToString() + " energy sum "+ coenergysum.ToString() + " drymatter " + Convert.ToDouble(energychange["DRYMATTER"]).ToString();
            }
            catch
            {
              //  Label1.Text = new123;
                return;
            }







        }
    }
    protected void animal_ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataSource7.SelectCommand="SELECT TI.ID AS ID, TI.NAME AS NAME FROM TARGETINCREASE TI, ENERGYCHANGE EC WHERE TI.ID=EC.TARGETINCREASEID AND EC.ANIMALSID=@ANIMALS";
        SqlDataSource7.SelectParameters.Clear();
        SqlDataSource7.SelectParameters.Add("ANIMALS", TypeCode.Int32, animal_ddl.SelectedValue);

    }
    protected void Grow_ddl5_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataSource10.SelectCommand = "SELECT TI.ID, TI.NAME FROM TARGETINCREASE TI, FARM F WHERE F.TARGETINCREASEID=TI.ID AND F.RATIONGROUP=@RATIONGROUPID";
        SqlDataSource10.SelectParameters.Clear();
        SqlDataSource10.SelectParameters.Add("RATIONGROUPID", Grow_ddl5.SelectedValue);
    }
}