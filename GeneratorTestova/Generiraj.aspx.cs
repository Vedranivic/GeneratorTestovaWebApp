using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Generator
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String Title1
        {
            get
            {
                return TextBox7.Text;
            }
        }

        public String Info
        {
            get
            {
                return TextBox8.Text;
            }
        }

        public String Type
        {
            get
            {
                return DropDownList1.SelectedValue.ToString();
            }
        }

        public String Topic
        {
            get
            {
                return DropDownList2.SelectedValue.ToString();
            }
        }

        public int Total
        {
            get
            {
                return int.Parse(TextBox1.Text);
            }
        }

        public bool Bodovi
        {
            get
            {
                if (CheckBox1.Checked) return true;
                else return false;
            }
        }

        public int Long
        {
            get
            {
                return int.Parse(TextBox2.Text);
            }
        }

        public int Short
        {
            get
            {
                return int.Parse(TextBox3.Text);
            }
        }

        public int Multiple
        {
            get
            {
                return int.Parse(TextBox4.Text);
            }
        }

        public int TF
        {
            get
            {
                return int.Parse(TextBox5.Text);
            }
        }

        public int Choice
        {
            get
            {
                return int.Parse(TextBox6.Text);
            }
        }

        bool IsDigits(string str)                                            //pomoćna funkcija za ispitivanje unosa brojčanih vrijednosti
        {
            if (str.Length < 1) return false;
            foreach (char c in str)
            {
                if (c < '0' || c > '9' || str == "") return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (IsDigits(TextBox1.Text) && IsDigits(TextBox2.Text) && IsDigits(TextBox3.Text) && IsDigits(TextBox4.Text) && IsDigits(TextBox5.Text) && IsDigits(TextBox6.Text) && TextBox7.Text.Length != 0)
            {
                if (int.Parse(TextBox1.Text) == int.Parse(TextBox2.Text) + int.Parse(TextBox3.Text) + int.Parse(TextBox4.Text) + int.Parse(TextBox5.Text) + int.Parse(TextBox6.Text))
                    Server.Transfer("~/Test.aspx");
                else Label1.Text = "Ukupan zbroj pojedinačnih pitanja se ne podudara s ukupnim brojem pitanja!";

            }
            else
            {
                Label1.Text = "Potrebno je unijeti sve parametre!";
            }

            /*string s = "\t\t" + TextBox7.Text;

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=testfile.txt");
            Response.AddHeader("content-type", "text/plain");

            using (StreamWriter writer = new StreamWriter(Response.OutputStream))
            {
                writer.WriteLine(s);
            }
            Response.End();*/
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}