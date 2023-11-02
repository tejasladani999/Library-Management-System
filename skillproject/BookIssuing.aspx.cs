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
    public partial class BookIssuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // click on Go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getName();
        }

        // click on issue button 
        protected void Button3_Click(object sender, EventArgs e)
        {
            getName();

            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this Book');</script>");

                }
                else
                {
                    issueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid BookID or MemberID');</script>");
            }
        }

        // click on Return Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not Exist');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid BookID or MemberID');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                    Response.Write("<script>alert('FUNCTION CALLED');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //user Define function

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM BookDetails WHERE BookID = '" + TextBox1.Text.Trim() + "' AND CurrentStock > 0 ", con);

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
                return false;
            }

        }

        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT FullName FROM MemberDetails WHERE MemberID = '" + TextBox2.Text.Trim() + "' ", con);

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
                return false;
            }

        }

        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from BookIssueDetails WHERE MemberID='" + TextBox2.Text.Trim() + "' AND BookID='" + TextBox1.Text.Trim() + "'", con);
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
                return false;
            }

        }

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from BookIssueDetails WHERE BookID='" + TextBox1.Text.Trim() + "' AND MemberID='" + TextBox2.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("UPDATE BookDetails SET CurrentStock= CurrentStock + 1 WHERE BookID='"+ TextBox1.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Book Returned Successfully');</script>");
                    GridView1.DataBind();

                    con.Close();

                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid details');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM BookDetails WHERE BookID = '" + TextBox1.Text.Trim() + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["BookName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid BookID');</script>");
                }

                cmd = new SqlCommand("SELECT* FROM MemberDetails WHERE MemberID = '" + TextBox2.Text.Trim() + "' ", con);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["FullName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid MemberID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO BookIssueDetails (MemberId,MemberName,BookID,BookName,IssueDate,ReturnDate) values(@MemberId,@MemberName,@BookID,@BookName,@IssueDate,@ReturnDate)", con);

                cmd.Parameters.AddWithValue("@BookID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@MemberID", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@BookName", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@MemberName", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@IssueDate", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@ReturnDate", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                // Update Current stock of Book

                cmd = new SqlCommand("UPDATE BookDetails SET CurrentStock= CurrentStock -1 WHERE BookID='"+ TextBox1.Text.Trim() + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book Issued Successfully');</script>");

                //clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

    }
}