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
    public partial class UserSignuppage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // signUP btn Click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkMemberExists())
            {
                Response.Write("<script>alert('Member Alreaady Exist with this MemberID');</script>");

            }
            else
            {
                signupNewUser();
            }

        }
        //User Define Method
        
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM MemberDetails WHERE MemberID = '" + TextBox9.Text.Trim() +"' ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();
                Response.Write("<script>alert('SignUp Successful. Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");
                return false;


            }

        }

        void signupNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO MemberDetails (FullName,DOB,ContactNo,Email,State,City,Pincode,FullAddress,MemberID,Password,AccountStatus) values(@FullName,@DOB,@ContactNo,@Email,@State,@City,@Pincode,@FullAddress,@MemberID,@Password,@AccountStatus)", con);

                cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@State", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@FullAddress", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@MemberID", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountStatus", "Pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('SignUp Successful. Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }
    }
}