using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skillproject
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select* from MemberDetails where MemberID='" + TextBox1.Text.Trim() + "' AND Password='" + TextBox2.Text.Trim() + "' ", con);
                
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('" + dr.GetValue(8).ToString() + "');</script>");
                        Session["UserID"] = dr.GetValue(8).ToString();
                        Session["FullName"] = dr.GetValue(0).ToString();
                        Session["role"] = "User";
                        Session["AccountStatus"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

    }
}