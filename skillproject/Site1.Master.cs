using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skillproject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //user login button
                    LinkButton2.Visible = true; // user singup button
                    LinkButton3.Visible = false; // user logout button
                    LinkButton4.Visible = false; //View Book
                    LinkButton5.Visible = false; //hello user button
                    LinkButton6.Visible = true;  //admin login
                    LinkButton7.Visible = false; // Author management button
                    LinkButton8.Visible = false; //publisher management
                    LinkButton9.Visible = false; //book inventory
                    LinkButton10.Visible =false; //book issuing
                    LinkButton11.Visible = false; //member management
                }
                else if (Session["role"].Equals("User"))
                {
                    LinkButton1.Visible = false; //user login button
                    LinkButton2.Visible = false; // user singup button
                    LinkButton3.Visible = true; // user logout button
                    LinkButton4.Visible = true; //View Book
                    LinkButton5.Visible = true; //hello user button
                    LinkButton5.Text = "hello " +Session["UserID"].ToString(); //hello message to USer after login
                    LinkButton6.Visible = true; //admin login 
                    LinkButton7.Visible = false; // Author management button
                    LinkButton8.Visible = false; //publisher management
                    LinkButton9.Visible = false; //book inventory
                    LinkButton10.Visible =false; //book issuing
                    LinkButton11.Visible = false; //member management
                }
                else if (Session["role"].Equals("Admin"))
                {
                    LinkButton1.Visible = false; //user login button
                    LinkButton2.Visible = false; // user singup button
                    LinkButton3.Visible = true; // user logout button
                    LinkButton4.Visible = true; //View Book
                    LinkButton5.Visible = true; //hello user button
                    LinkButton5.Text = "hello Admin"; //hello message to Admin after login
                    LinkButton6.Visible = false; //admin login 
                    LinkButton7.Visible = true; // Author management button
                    LinkButton8.Visible = true; //publisher management
                    LinkButton9.Visible = true; //book inventory
                    LinkButton10.Visible = true; //book issuing
                    LinkButton11.Visible = true; //member management
                }

            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookINventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBook.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignuppage.aspx");
        }

        // logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session["UserID"] = null;
            Session.RemoveAll();

            LinkButton1.Visible = true; //user login button
            LinkButton2.Visible = true; // user singup button
            LinkButton3.Visible = false; // user logout button
            LinkButton4.Visible = false; //View Book
            LinkButton5.Visible = false; //hello user button
            LinkButton6.Visible = true; //admin login
            LinkButton7.Visible = false; // Author management button
            LinkButton8.Visible = false; //publisher management
            LinkButton9.Visible = false; //book inventory
            LinkButton10.Visible = false; //book issuing
            LinkButton11.Visible = false; //member management

            Response.Redirect("UserLogin.aspx");

        }
            
        //View profile
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}