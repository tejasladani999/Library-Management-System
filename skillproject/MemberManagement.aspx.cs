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
    public partial class MemberManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
         //Go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        // Status = Active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Active");
        }

        // Status = Pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Pending");
        }

        // status = deactive
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Deactive");
        }

        //delete User
        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }

        // user define function
        void getMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("select * from MemberDetails where MemberID='" + TextBox1.Text.Trim() + "' ", con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr.GetValue(0).ToString();
                            TextBox7.Text = dr.GetValue(10).ToString();
                            TextBox3.Text = dr.GetValue(1).ToString();
                            TextBox4.Text = dr.GetValue(2).ToString();
                            TextBox8.Text = dr.GetValue(3).ToString();
                            TextBox5.Text = dr.GetValue(4).ToString();
                            TextBox6.Text = dr.GetValue(5).ToString();
                            TextBox9.Text = dr.GetValue(6).ToString();
                            TextBox10.Text = dr.GetValue(7).ToString();
                            //TextBox11.Text = dr.GetValue(8).ToString();

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid credentials');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<Script>alert('Invalid MemberID')</Script>");
            }
        }

        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE MemberDetails SET AccountStatus= '" + status + "' WHERE MemberID='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Status Updated');</script>");

                    GridView1.DataBind();
                    clearform();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<Script>alert('Invalid MemberID')</Script>");
            }
        }

        void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM  MemberDetails  WHERE MemberID='" + TextBox1.Text.Trim() + "' ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");

                    clearform();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(' " + ex.Message + " ');</script>");

                }

            }
            else
            {
                Response.Write("<Script>alert('Invalid MemberID')</Script>");

            }
        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM MemberDetails WHERE MemberID = '" + TextBox1.Text.Trim() + "' ", con);

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


    }
}