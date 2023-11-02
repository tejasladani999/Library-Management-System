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
    public partial class UserProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
             
             try
             {
                 if (Session["UserID"].ToString() == "" || Session["UserID"] == null)
                 {
                     Response.Write("<script>alert('Session Expired Login Again');</script>");
                     Response.Redirect("UserLogin.aspx");

                 }
                 else
                 {
                    getUserBookData();


                     if (!Page.IsPostBack)
                     {
                        getUserDetails();
                     }
                 }
             }
             catch(Exception ex)
             {
                 Response.Write("<script>alert('" + ex.Message + "');</script>");
                 Response.Redirect("UserLogin.aspx");
             }
             
        }
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        // update button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["UserID"].ToString() == "" || Session["UserID"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserDetails();

            }
        }

        //user define function

        void getUserDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from MemberDetails where MemberID='" + Session["UserID"].ToString() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                
                TextBox1.Text = dt.Rows[0]["FullName"].ToString();
                TextBox2.Text = dt.Rows[0]["DOB"].ToString();
                TextBox3.Text = dt.Rows[0]["ContactNo"].ToString();
                TextBox4.Text = dt.Rows[0]["Email"].ToString();
                TextBox5.Text = dt.Rows[0]["State"].ToString();
                TextBox6.Text = dt.Rows[0]["City"].ToString();
                TextBox7.Text = dt.Rows[0]["Pincode"].ToString();
                TextBox8.Text = dt.Rows[0]["FullAddress"].ToString();
                TextBox11.Text = dt.Rows[0]["Password"].ToString();
                TextBox9.Text = dt.Rows[0]["MemberID"].ToString();
                TextBox10.Text = dt.Rows[0]["Password"].ToString();

                Label1.Text = dt.Rows[0]["AccountStatus"].ToString().Trim();

                if (dt.Rows[0]["AccountStatus"].ToString().Trim() == "Active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["AccountStatus"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["AccountStatus"].ToString().Trim() == "Deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from BookIssueDetails where MemberID='" + Session["UserID"].ToString() + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void updateUserDetails()
        {
            string Password = "";
            if (TextBox11.Text.Trim() == "")
            {
                Password = TextBox10.Text.Trim();
            }
            else
            {
                Password = TextBox11.Text.Trim();
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("UPDATE  MemberDetails SET FullName=@FullName,DOB=@DOB,ContactNo=@ContactNo,Email=@Email,State=@State,City=@City,Pincode=@Pincode,FullAddress=@FullAddress,MemberID=@MemberID,Password=@Password,AccountStatus=@AccountStatus WHERE MemberID='" + TextBox9.Text.Trim() + "' ", con);

                cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@State", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@City", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@FullAddress", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@MemberID", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@AccountStatus", "Pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invalid MemberID');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


    }
}