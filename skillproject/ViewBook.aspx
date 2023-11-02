<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBook.aspx.cs" Inherits="skillproject.ViewBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
        <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Books List</h4>
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
      
   
</asp:Content>
