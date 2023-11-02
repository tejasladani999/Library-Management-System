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
    public partial class PublisherManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add author details
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                Response.Write("<script>alert('Publisher with this ID already exist.');</script>");

            }
            else
            {
                addNewPublisher();
            }
        }
        //update author details
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID already exist.');</script>");
            }
        }
        //delete author details
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID already exist.');</script>");
            }
        }
        // Go author Id search button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }

        //user define function

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO PublisherDetails (PublisherID,PublisherName) values(@PublisherID,@PublisherName)", con);

                cmd.Parameters.AddWithValue("@PublisherID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PublisherName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Added Successfully');</script>");

                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE  PublisherDetails SET PublisherName = @PublisherName WHERE PublisherID='" + TextBox1.Text.Trim() + "' ", con);

                cmd.Parameters.AddWithValue("@PublisherName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Updated Successfully');</script>");

                clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM  PublisherDetails  WHERE PublisherID='" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully');</script>");

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

        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM PublisherDetails WHERE PublisherID = '" + TextBox1.Text.Trim() + "' ", con);

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
        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM PublisherDetails WHERE PublisherID = '" + TextBox1.Text.Trim() + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }
        }
    }
}