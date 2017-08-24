using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Generator_testova
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //funkcija za dohvat podataka na osnovu zadanog queryja
        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public void InsertData(DataRow Row, string TableName)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            string query = "INSERT INTO " + TableName + " VALUES(";
            for (int i = 1; i < Row.Table.Columns.Count; i++) {
                query =  query + "@" + Row.Table.Columns[i].ColumnName + ((i == 12) ? "" : ",");
            }
            query = query + ")";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        for (int i = 1; i < Row.Table.Columns.Count; i++)
                        {
                        cmd.Parameters.AddWithValue(("@"+Row.Table.Columns[i].ColumnName), Row[i]);
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null)
            {
                DataTable Q = GetData("SELECT TOP " + PreviousPage.Long.ToString() + " * FROM Questions WHERE qtype = 'Long Answer' AND topic = '" + PreviousPage.Topic.ToString().ToLower() + "' ORDER BY newid();");
                Q.Merge(GetData("SELECT TOP " + PreviousPage.Short.ToString() + " * FROM Questions WHERE qtype = 'Short Answer' AND topic = '" + PreviousPage.Topic.ToString().ToLower() + "' ORDER BY newid();"));
                Q.Merge(GetData("SELECT TOP " + PreviousPage.Choice.ToString() + " * FROM Questions WHERE qtype = 'Choice' AND topic = '" + PreviousPage.Topic.ToString().ToLower() + "' ORDER BY newid();"));
                Q.Merge(GetData("SELECT TOP " + PreviousPage.Multiple.ToString() + " * FROM Questions WHERE qtype = 'Multiple Choice' AND topic = '" + PreviousPage.Topic.ToString().ToLower() + "' ORDER BY newid();"));
                Q.Merge(GetData("SELECT TOP " + PreviousPage.TF.ToString() + " * FROM Questions WHERE qtype = 'True False' AND topic = '" + PreviousPage.Topic.ToString().ToLower() + "' ORDER BY newid();"));
                GridView1.DataSource = Q;
                GridView1.DataBind();

                GridView4.DataSource = GetData("select * from Answers");
                GridView4.DataBind();

                GridView1.DataSource = Q;
                GridView1.DataBind();

                Label1.Text = PreviousPage.Title1;
                Label2.Text = PreviousPage.Info;

                //Popunjavanje testa pitanjima
                int i;
                String Popis = "";
                int MaxPoints = 0;
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    Popis = Popis + (i + 1).ToString() + ". " + GridView1.Rows[i].Cells[2].Text + "<br />";
                    if (GridView1.Rows[i].Cells[1].Text == "True False")
                    {
                        Popis = Popis + "<pre style =\"text-align:center;font:bold;background-color:white;border:none;margin-bottom:-30px;font-family:Calibri; font-size:16px;\" > TOČNO      NETOČNO </pre>";
                    }

                    if (GridView1.Rows[i].Cells[1].Text.ToLower() == "long answer")
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            Popis = Popis + "<div style =\"height:0px; width:550px;margin-left:25px; padding-top:25px; border-bottom-style:solid; border-bottom-width:0.5px;\"> </div>";
                        }
                    }

                    if (GridView1.Rows[i].Cells[1].Text.ToLower() == "short answer")
                    {
                        Popis = Popis.Substring(0, Popis.Length - 6) + "<div style =\"display:inline-block; height:30px; margin-left:2px; width:110px; border-bottom-style:solid; border-bottom-width:0.5px;\"> </div>";
                    }

                    if (GridView1.Rows[i].Cells[1].Text.ToLower() == "choice" || GridView1.Rows[i].Cells[1].Text.ToLower() == "multiple choice")
                    {
                        char c = 'a';
                        foreach (GridViewRow R in GridView4.Rows)
                        {
                            if (R.Cells[2].Text == GridView1.Rows[i].Cells[0].Text)
                            {
                                string[] ans = R.Cells[1].Text.Split(',').Select(sValue => sValue.Trim()).ToArray();
                                for (int k = 0; k < int.Parse(R.Cells[0].Text); k++)
                                {
                                    Popis = Popis + "<pre style =\"text-align:left;font-family:Calibri; font-size:16px; background-color:white;border:none;margin-bottom:-15px;\" > " + (char)(c + k) + ") " + ans[k] + "</pre>";
                                }
                                break;
                            }
                        }
                    }
                    // Prikaz bodova pojedinih pitanja ovisno o chekiranom parametru
                    Popis = Popis + ((PreviousPage.Bodovi == true) ? "<div style =\"height:25px; width:550px;margin-left:25px; text-align:right; font-family:Calibri; font-size:14px;\">" + GridView1.Rows[i].Cells[3].Text + "</div>" : "<br />");
                    MaxPoints += int.Parse(GridView1.Rows[i].Cells[3].Text);
                }
                Popis = Popis + "<div style =\"height:25px; width:550px;margin-left:25px; margin-top:20px; text-align:right; font-family:Calibri; font-size:14px;\">/" + MaxPoints.ToString() + "</div>";
                Label3.Text = Popis;

                //Stvaranje novog Testa za unos u bazu

                DataTable T = GetData("SELECT * FROM Tests;");
                DataRow Rt = T.NewRow();
                Rt["title"] = PreviousPage.Title1;
                Rt["last_used"] = DateTime.Now;
                Rt["number_of_q"] = PreviousPage.Total;
                Rt["maxpoint"] = MaxPoints;
                Rt["Nlong"] = PreviousPage.Long;
                Rt["Nshort"] = PreviousPage.Short;
                Rt["Nchoice"] = PreviousPage.Choice;
                Rt["Nmultiple"] = PreviousPage.Multiple;
                Rt["Ntruefalse"] = PreviousPage.TF;
                Rt["ttype"] = PreviousPage.Type;
                Rt["ttopic"] = PreviousPage.Topic;
                Rt["info"] = PreviousPage.Info;
                InsertData(Rt, "Tests");

                T.Rows.Add(Rt);
                GridView5.DataSource = T;
                GridView5.DataBind();

            }
            else
            {
                if (!Page.IsPostBack)
                {
                    Label1.Text = "<span style=\"font-weight:400; color:crimson;\"> Potrebno unijeti parametre za generiranje testa! <span>";
                    Panel1.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = false;
                    Button1.Text = "Unesi parametre";
                }
                else
                    Response.Redirect("~/WebForm3.aspx");

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Response.Redirect("~/Generiraj.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "application/pdf");
            response.AddHeader("Content-Disposition", "inline; filename=" + Label1.Text + "; size=" + "4");

            response.Flush();
            response.Flush();
            response.End();
        }
        public void Button_test(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm3.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm3.aspx");
        }
    }
}