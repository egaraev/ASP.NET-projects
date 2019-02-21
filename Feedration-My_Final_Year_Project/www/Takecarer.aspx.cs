using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Globalization;



public partial class Takecarer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT A.ID AS ID, 'ANIMAL: '+ AG.NAME + ' AGE: ' + AA.NAME + ' WEIGHT: ' + AW.NAME AS NAME FROM ANIMALS A, ANIMALAGE AA, ANIMALWEIGHT AW, ANIMALGROUP AG WHERE A.ANIMALGROUPID=AG.ID AND A.ANIMALWEIGHTID=AW.ID AND A.ANIMALAGEID=AA.ID";
            SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlDataSource3.SelectCommand = "select t.name +' - '+ ti.name as name, ti.id as id from targetcategory t, targetincrease ti where ti.targetcategoryid=t.id";
        }

    }
    protected void add_btn_Click(object sender, EventArgs e)
    {
        if (!Panel1.Visible)
        {
            Panel1.Visible = true;
            return;
        }
        if (!Panel2.Visible)
        {
            Panel2.Visible = true;
            return;
        }
        if (!Panel3.Visible)
        {
            Panel3.Visible = true;
            return;
        }
        if (!Panel4.Visible)
        {
            Panel4.Visible = true;
            return;
        }
        if (!Panel5.Visible)
        {
            Panel5.Visible = true;
            return;
        }

    }
    protected void calc_btn0_Click(object sender, EventArgs e)
    {
        int animalid = Convert.ToInt32(herd_ddl1.SelectedValue);
        int targetincrease = Convert.ToInt32(Growgrp_ddl3.SelectedValue);
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
        error0_lb.Text = "";
        error1_lb.Text = "";
        error2_lb.Text = "";
        error3_lb.Text = "";
        error4_lb.Text = "";
        error5_lb.Text = "";
        Dictionary<string, object> energychange = new Dictionary<string, object>();
        Dictionary<string, object> ratio = new Dictionary<string, object>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            conn.Open();

            ArrayList feedids = new ArrayList();
            feedids.Insert(0, Weightgrp_ddl9.SelectedValue);
            ArrayList feedweights = new ArrayList();
            feedweights.Insert(0, Quantity_edt2.Text);
            if (Panel1.Visible)
            {
                feedids.Insert(feedids.Count, Weightgrp_ddl1.SelectedValue);
                feedweights.Insert(feedweights.Count, TextBox1.Text);
            }
            if (Panel2.Visible)
            {
                feedids.Insert(feedids.Count, Weightgrp_ddl2.SelectedValue);
                feedweights.Insert(feedweights.Count, TextBox2.Text);
            }
            if (Panel3.Visible)
            {
                feedids.Insert(feedids.Count, Weightgrp_ddl3.SelectedValue);
                feedweights.Insert(feedweights.Count, TextBox3.Text);
            }
            if (Panel4.Visible)
            {
                feedids.Insert(feedids.Count, Weightgrp_ddl4.SelectedValue);
                feedweights.Insert(feedweights.Count, TextBox4.Text);
            }
            if (Panel5.Visible)
            {
                feedids.Insert(feedids.Count, Weightgrp_ddl5.SelectedValue);
                feedweights.Insert(feedweights.Count, TextBox5.Text);
            }
            string feedid = feedids[0].ToString();
            for (int i = 1; i <= feedids.Count - 1; i++)
            {
                feedid += "," + feedids[i].ToString();
            }
            int count = 0;
            comm.Parameters.Clear();
            comm.CommandText = String.Format("SELECT COUNT(DISTINCT CATEGORYID) FROM FEED WHERE ID IN ({0}) AND CATEGORYID IN (1,2)", feedid);
            try
            {
                count = Convert.ToInt32(comm.ExecuteScalar());
                //count = 2;
            }
            catch (SqlException E)
            {
            }

            if (count < 2)
            {
                Label1.Text = "Select at least 2 different feed types";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                
            }

            comm.Parameters.Clear();
            comm.CommandText = string.Format("SELECT E.DRYMATTER,E.CRUDEFIBER,E.PROTEIN,E.ENERGY,E.CA,E.P, R.COPERCENT,R.ROPERCENT,R.SUPERCENT FROM ENERGYCHANGE E, FEEDRATIO R WHERE E.TARGETINCREASEID={0} AND E.ANIMALSID={1} AND E.SEASON='{2}' AND E.TYPE='{3}' AND E.RATIOID=R.ID", targetincrease, animalid,season,type);
            SqlDataReader reader = comm.ExecuteReader();
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
                    ratio_lb.Text = string.Format("<tr><td>Concentrated (15% H20)</td><td>{0}</td></tr><tr><td>Roughages (15% H20)</td><td>{1}</td></tr><tr><td>Succulent	(75% H20)</td><td>{2}</td></tr>", reader["COPERCENT"].ToString() + "%", reader["ROPERCENT"].ToString() + "%", reader["SUPERCENT"].ToString() + "%");

                }
            }
   
            reader.Dispose();
            conn.Close();


            string new123 = comm.CommandText;



            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = string.Format("SELECT F.ID, F.NAME AS FEED, F.DRYMATTER as DRYMATTER,F.CRUDEFIBER,F.PROTEIN,F.ENERGY,F.CA,F.P,FC.NAME AS CATEGORY FROM FEED F, ANIMALFEEDTYPE FT, ANIMALS A, ANIMALGROUP AG, FEEDCATEGORY FC WHERE FT.FEEDID=F.ID AND FT.ANIMALGROUPID=AG.ID AND A.ID={1} AND F.ID in ({0}) and F.CATEGORYID=FC.ID AND A.ANIMALGROUPID=AG.ID", feedid,herd_ddl1.SelectedValue);
            
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


            double koefco=0;
            double koefsu = 0;
            double koefro = 0;
            double koefficentco = 0;
            double koefficentro = 0;
            double koefficentsu = 0;
            double maxco=0;
            double maxro=0;
            double maxsu = 0;
            
            int quantity = 0;
                try
                {
                    quantity = Convert.ToInt32(Quantity_edt1.Text);
                }
                catch
                {
                    Label1.Text = "Please indicate the quantity of animals";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            for (int i = 0; i <= feedidss.Count - 1; i++)
            {
                if (feedcategory[i].ToString().Substring(0, 2) == "Co")
                {
                    
                    //drymattersum =drymattersum+ Convert.ToDecimal(drymatter[i]);
                    //energy[i] = energy[i];
                    coenergysum +=Convert.ToDouble(energy[i]);
                    cocrudefibersum += Convert.ToDouble(crudefiber[i]);
                    coproteinsum += Convert.ToDouble(protein[i]);
                    cocasum += Convert.ToDouble(ca[i]);
                    copsum += Convert.ToDouble(p[i]);
                    codrymattersum += Convert.ToDouble(drymatter[i]);
                    co_lb.Text = feed[i].ToString();
                    int k = 1;
                    koefficentco = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["COPERCENT"]) / 100 * quantity / codrymattersum;
                      for (int j=0; j<=feedids.Count-1; j++)
                
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
                    koefficentro = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["ROPERCENT"]) / 100 * quantity/rodrymattersum;
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
                //koefco = coenergysum;
                koefficentco = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["COPERCENT"].ToString().Replace(".",",")) / 100;
                
                co_energy.Text = koefco.ToString();
                co_p.Text = (koefficentco * copsum).ToString();
                co_ca.Text = (koefficentco * cocasum).ToString();
                co_crudefiber.Text = (koefficentco * cocrudefibersum).ToString();
                co_protein.Text = (koefficentco * coproteinsum).ToString();
                co_weight.Text = Math.Round((koefficentco/codrymattersum),2).ToString();


                koefro = Convert.ToDouble(energychange["DRYMATTER"]) * Convert.ToDouble(ratio["ROPERCENT"])/100;
                //ec_energy.Text = Math.Round(koefco, 2).ToString();
                ro_crudefiber.Text = (koefro * rocrudefibersum).ToString();
                ro_ca.Text= (koefro * rocasum).ToString();;
                ro_energy.Text= (koefro * roenergysum).ToString();
                ro_p.Text= (koefro * ropsum).ToString();
                ro_protein.Text = (koefro * roproteinsum).ToString();
                ro_weight.Text = Math.Round((koefro/rodrymattersum),2).ToString();
                
                
                ec_ca.Text = energychange["CA"].ToString();
                ec_crudefiber.Text = energychange["CRUDEFIBER"].ToString();
                ec_protein.Text = energychange["PROTEIN"].ToString();
                ec_energy.Text=energychange["ENERGY"].ToString();
                ec_ca.Text=energychange["CA"].ToString();
                ec_p.Text=energychange["P"].ToString();



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

                oq_energy.Text = Math.Round(((koefro * roenergysum) + (koefficentco * coenergysum) + (koefsu * suenergysum) - Convert.ToDouble(energychange["ENERGY"])),3).ToString();
                oq_energy.ForeColor = System.Drawing.Color.Red;

                oq_protein.Text = Math.Round(((koefro * roproteinsum) + (koefficentco * coproteinsum) + (koefsu * suproteinsum) - Convert.ToDouble(energychange["PROTEIN"])),3).ToString();
                oq_protein.ForeColor = System.Drawing.Color.Red;

                oq_crudefiber.Text =  Math.Round(((koefro * rocrudefibersum) + (koefficentco * cocrudefibersum) + (koefsu * sucrudefibersum) - Convert.ToDouble(energychange["CRUDEFIBER"])),3).ToString();
                oq_crudefiber.ForeColor = System.Drawing.Color.Red;

                oq_p.Text = Math.Round(((koefro * ropsum) + (koefficentco * copsum) + (koefsu * supsum) - Convert.ToDouble(energychange["P"])),3).ToString();
                oq_p.ForeColor = System.Drawing.Color.Red;


                

               // ro_lbl.Text = Math.Round(koefro, 2).ToString();
               // co_energy.Text = "energy change " + Convert.ToDouble(energychange["ENERGY"]).ToString() + " COPERCENT " + (Convert.ToDouble(ratio["COPERCENT"]) / 100).ToString() + " energy sum "+ coenergysum.ToString() + " drymatter " + Convert.ToDouble(energychange["DRYMATTER"]).ToString();
            }
            catch
            {
                Label1.Text = new123;
                return;
            }







        }

        
    }
    protected void remove_btn_Click(object sender, EventArgs e)
    {
        if (Panel5.Visible)
        {
            Panel5.Visible = false;
            return;
        }
        else
        {
            if (Panel4.Visible)
            {
                Panel4.Visible = false;
                return;
            }
            else
            {
                if (Panel3.Visible)
                {
                    Panel3.Visible = false;
                    return;
                }
                else
                {
                    if (Panel2.Visible)
                    {
                        Panel2.Visible = false;
                        return;
                    }
                    else
                    {
                        if (Panel1.Visible)
                        {
                            Panel1.Visible = false;
                            return;
                        }
                    }
                }
            }
        }
    }
    protected void herd_ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataSource3.SelectCommand = "select t.name +' - '+ ti.name as name, ti.id as id from targetcategory t, targetincrease ti, ENERGYCHANGE EC WHERE TI.ID=EC.TARGETINCREASEID AND EC.ANIMALSID=@ANIMALS and ti.targetcategoryid=t.id";
        SqlDataSource3.SelectParameters.Clear();
        SqlDataSource3.SelectParameters.Add("ANIMALS", TypeCode.Int32, herd_ddl1.SelectedValue);
    }
}