<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="skillproject.BookInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        // search enable table fuction
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        //image load fuction
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0])
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <%-- Book Information card(Section) --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img  width="100" id="imgview" src="imgs/books1.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" Class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredBookID" runat="server" ErrorMessage="Book ID Required!" ControlToValidate="TextBox1" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Book Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredBookName" runat="server" ErrorMessage="Book Name Required!" ControlToValidate="TextBox2" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" Class="form-control" runat="server">
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marathi" Value="Marathi" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Gujarati" Value="Gujarati" />
                                        <asp:ListItem Text="Sanskrit" Value="Sanskrit" />
                                        <asp:ListItem Text="Tamil" Value="Tamil" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList2" Class="form-control" runat="server">
                                        <asp:ListItem Text="Publisher1" Value="Publisher1" />
                                        <asp:ListItem Text="Publisher2" Value="Publisher2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList3" Class="form-control" runat="server">
                                        <asp:ListItem Text="Author Name1" Value="Author Name1" />
                                        <asp:ListItem Text="Author Name2" Value="Author Name2" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" Class="form-control" runat="server" TextMode="Date" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredPublishDate" runat="server" ErrorMessage="PublishDate Required!" ControlToValidate="TextBox3" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem text="Adventure" Value="Adventure"/>
                                        <asp:ListItem text="Comic Book" Value="Comic Book"/>
                                        <asp:ListItem text="Self Help" Value="Self Help"/>
                                        <asp:ListItem text="Fianace" Value="Fianace"/>
                                        <asp:ListItem text="Economics" Value="Economics"/>
                                        <asp:ListItem text="Health" Value="Health"/>
                                        <asp:ListItem text="Bio-graphy" Value="Bio-graphy"/>
                                        <asp:ListItem text="Poetry" Value="Poetry"/>

                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="Edition"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredEdition" runat="server" ErrorMessage="Edition Required!" ControlToValidate="TextBox11" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox12" runat="server" placeholder="Book Cost"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredBookCost" runat="server" ErrorMessage="Book Cost Required!" ControlToValidate="TextBox12" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>                                        
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox13" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredPages" runat="server" ErrorMessage="Pages Required!" ControlToValidate="TextBox13" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" TextMode="Number" placeholder="Actual Stock"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredActualStock" runat="server" ErrorMessage="ActualStock Required!" ControlToValidate="TextBox5" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox6" runat="server" TextMode="Number" placeholder="Current Stock" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox9" runat="server" TextMode="Number" placeholder="Issued Books" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Book Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredBookDescription" runat="server" ErrorMessage="Book Description Required!" ControlToValidate="TextBox10" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>                                        
                                </div>
                            </div>
                        </div>

                       <div class="row">
                                <div class="col-4">
                                    <asp:Button class="btn btn-block btn-success" ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
                                </div>
                                <div class="col-4">
                                    <asp:Button class="btn btn-block btn-warning" ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
                                </div>
                                <div class="col-4">
                                    <asp:Button class="btn btn-block btn-danger" ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click" />
                                </div>
                         </div>


                    </div>
                </div>
                <a href="homepage.aspx"><< Back to home</a><br><br>
            </div>

            <%--  book Information card(section) --%>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Books Inventory List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [BookDetails]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BookID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="BookID" HeaderText="BookID" ReadOnly="True" SortExpression="BookID" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("BookName") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Author-<asp:Label ID="Label2" runat="server" Text='<%# Eval("AuthorName") %>'></asp:Label>
                                                                    &nbsp;| Genre-<asp:Label ID="Label3" runat="server" Text='<%# Eval("Genre") %>'></asp:Label>
                                                                    &nbsp;| Language-<asp:Label ID="Label4" runat="server" Text='<%# Eval("Language") %>'></asp:Label>
                                                                 </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher-<asp:Label ID="Label5" runat="server" Text='<%# Eval("PublisherName") %>'></asp:Label>
                                                            &nbsp;| Publishing Date-<asp:Label ID="Label6" runat="server" Text='<%# Eval("PublishDate") %>'></asp:Label>
                                                            &nbsp;| Pages-<asp:Label ID="Label7" runat="server" Text='<%# Eval("Pages") %>'></asp:Label>
                                                            &nbsp;| Edition-<asp:Label ID="Label8" runat="server" Text='<%# Eval("Edition") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Cost-<asp:Label ID="Label9" runat="server" Text='<%# Eval("BookCost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock-<asp:Label ID="Label10" runat="server" Text='<%# Eval("ActualStock") %>'></asp:Label>
                                                                    &nbsp;| Available-<asp:Label ID="Label11" runat="server" Text='<%# Eval("CurrentStock") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description-<asp:Label ID="Label12" runat="server" Text='<%# Eval("BookDescription") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("BookImage") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        
                </div>
            </div>
            
        </div>
    </div>
    </div>

</asp:Content>
