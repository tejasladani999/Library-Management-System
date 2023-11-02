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
    public partial class AuthorManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
                GridView1.DataBind();
        }
        //add author details
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                Response.Write("<script>alert('Author with this ID already exist.');</script>");

            }
            else
            {
                addNewAuthor();
            }
        }
        //update author details
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author with this ID already exist.');</script>");
            }
        }
        //delete author details
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author with this ID already exist.');</script>");
            }
        }
        // Go author Id search button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getAuthorById();
        }

        //user define function

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO AuthorDetails (AuthorID,AuthorName) values(@AuthorID,@AuthorName)", con);

                cmd.Parameters.AddWithValue("@AuthorID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@AuthorName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successfully');</script>");

                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE  AuthorDetails SET AuthorName = @AuthorName WHERE AuthorID='"+TextBox1.Text.Trim()+"' ", con);

                cmd.Parameters.AddWithValue("@AuthorName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successfully');</script>");

                clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM  AuthorDetails  WHERE AuthorID='" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Deleted Successfully');</script>");

                clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM AuthorDetails WHERE AuthorID = '" + TextBox1.Text.Trim() + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");
                return false;


            }

        }
        void getAuthorById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM AuthorDetails WHERE AuthorID = '" + TextBox1.Text.Trim() + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }
        }
    }
}