using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skillproject
{
    public partial class BookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string globalfilepath;
        static int globalActualStock, globalCurrentStock, globalIssuedBook;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValue();

            }
            GridView1.DataBind();
        }

        // go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        // add button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book already exists.');</script>");

            }
            else
            {
                addNewBook();
            }
        }

        //update button
        protected void Button4_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        // delete button 
        protected void Button5_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        //user defined function

       

        void getBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("select * from BookDetails where BookID='" + TextBox1.Text.Trim() + "' ", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0]["BookName"].ToString();
                        TextBox3.Text = dt.Rows[0]["PublishDate"].ToString().Trim();
                        TextBox11.Text = dt.Rows[0]["Edition"].ToString();
                        TextBox12.Text = dt.Rows[0]["BookCost"].ToString();
                        TextBox13.Text = dt.Rows[0]["Pages"].ToString().Trim();
                        TextBox5.Text = dt.Rows[0]["ActualStock"].ToString().Trim();
                        TextBox10.Text = dt.Rows[0]["BookDescription"].ToString();
                        TextBox6.Text = dt.Rows[0]["CurrentStock"].ToString().Trim();
                        TextBox9.Text = "" + (Convert.ToInt32(dt.Rows[0]["ActualStock"].ToString().Trim()) - Convert.ToInt32(dt.Rows[0]["CurrentStock"].ToString().Trim()));
                       
                         
                        DropDownList1.SelectedValue = dt.Rows[0]["Language"].ToString().Trim();
                        DropDownList2.SelectedValue = dt.Rows[0]["PublisherName"].ToString().Trim();
                        DropDownList3.SelectedValue = dt.Rows[0]["AuthorName"].ToString().Trim();
                        
                        ListBox1.ClearSelection();
                        string[] Genre = dt.Rows[0]["Genre"].ToString().Trim().Split(',');
                        for(int i=0; i< Genre.Length; i++)
                        {
                            for(int j=0; j<ListBox1.Items.Count; j++)
                            {
                                if(ListBox1.Items[j].ToString() == Genre[i])
                                {
                                    ListBox1.Items[j].Selected = true;
                                }
                            }
                        }

                        globalActualStock = Convert.ToInt32(dt.Rows[0]["ActualStock"].ToString().Trim());
                        globalCurrentStock = Convert.ToInt32(dt.Rows[0]["CurrentStock"].ToString().Trim());
                        globalIssuedBook = globalActualStock - globalCurrentStock;
                        globalfilepath = dt.Rows[0]["BookImage"].ToString();


                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid BookID');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<Script>alert('Invalid BookID')</Script>");
            }
        }

        void addNewBook()
        {
            try
            {
                // Genre selected
                string Genre = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    Genre = Genre +ListBox1.Items[i] + ",";

                }
                // Genre Remove
                Genre = Genre.Remove(Genre.Length - 1);

                string filepath = "~/imgs/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("imgs/" + filename));
                filepath = "~/imgs/" + filename;

                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO BookDetails (BookID,BookName,Genre,AuthorName,PublisherName,PublishDate,Language,Edition,BookCost,Pages,BookDescription,ActualStock,Currentstock,BookImage) values(@BookID,@BookName,@Genre,@AuthorName,@PublisherName,@PublishDate,@Language,@Edition,@BookCost,@Pages,@BookDescription,@ActualStock,@Currentstock,@BookImage)", con);

                cmd.Parameters.AddWithValue("@BookID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@BookName", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Genre", Genre);
                cmd.Parameters.AddWithValue("@AuthorName", DropDownList3.Text.Trim());
                cmd.Parameters.AddWithValue("@PublisherName", DropDownList2.Text.Trim());
                cmd.Parameters.AddWithValue("@PublishDate", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Language", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@Edition", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@BookCost", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@Pages", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@BookDescription", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@ActualStock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@CurrentStock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@BookImage", filepath);



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Uploaded Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void fillAuthorPublisherValue()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select AuthorName from AuthorDetails ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField ="AuthorName";
                DropDownList3.DataBind();

                SqlCommand cmd1 = new SqlCommand("select PublisherName from PublisherDetails ", con);

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.DataValueField = "PublisherName";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* FROM BookDetails WHERE BookID = '" + TextBox1.Text.Trim() + "' OR BookName = '" + TextBox2.Text.Trim() + "' ", con);

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

        void updateBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    int ActualStock = Convert.ToInt32(TextBox5.Text.Trim());
                    int CurrentStock = Convert.ToInt32(TextBox6.Text.Trim());

                    if(globalActualStock == ActualStock)
                    {

                    }
                    else
                    {
                        if(ActualStock < globalIssuedBook)
                        {
                            Response.Write("<script>alert('Actual Stock Value cannot be less than the Issued books');</script>");
                            return;
                        }
                        else
                        {
                            CurrentStock = ActualStock - globalIssuedBook;
                            TextBox6.Text = "" + CurrentStock;
                        }
                    }
                    // Genre selected
                    string Genre = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        Genre = Genre + ListBox1.Items[i] + ",";

                    }
                    // Genre Remove
                    Genre = Genre.Remove(Genre.Length - 1);

                    string filepath = "~/imgs/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if(filename == "" || filename == null)
                    {
                        filepath = globalfilepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("imgs/" + filename));
                        filepath = "~/imgs/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE  BookDetails SET BookName=@BookName,Genre=@Genre,AuthorName=@AuthorName,PublisherName=@PublisherName,PublishDate=@PublishDate,Language=@Language,Edition=@Edition,BookCost=@BookCost,Pages=@Pages,BookDescription=@BookDescription,ActualStock=@ActualStock,Currentstock=@Currentstock,BookImage=@BookImage  WHERE BookID='" + TextBox1.Text.Trim() + "' ", con);

                        cmd.Parameters.AddWithValue("@BookID", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@BookName", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Genre", Genre);
                        cmd.Parameters.AddWithValue("@AuthorName", DropDownList3.Text.Trim());
                        cmd.Parameters.AddWithValue("@PublisherName", DropDownList2.Text.Trim());
                        cmd.Parameters.AddWithValue("@PublishDate", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Language", DropDownList1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Edition", TextBox11.Text.Trim());
                        cmd.Parameters.AddWithValue("@BookCost", TextBox12.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pages", TextBox13.Text.Trim());
                        cmd.Parameters.AddWithValue("@BookDescription", TextBox10.Text.Trim());
                        cmd.Parameters.AddWithValue("@ActualStock", ActualStock);
                        cmd.Parameters.AddWithValue("@CurrentStock", CurrentStock);
                        cmd.Parameters.AddWithValue("@BookImage", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('BookDetails Updated Successfully');</script>");

                    //clearform();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(' " + ex.Message + " ');</script>");

                }

            }
            else
            {
                Response.Write("<script>alert('Invalid BookID');</script>");
            }
        }

        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM  BookDetails  WHERE BookID='" + TextBox1.Text.Trim() + "' ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    //clearform();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(' " + ex.Message + " ');</script>");

                }

            }
            else
            {
                Response.Write("<script>alert('Invalid BookID');</script>");
            }
        }

    }
}