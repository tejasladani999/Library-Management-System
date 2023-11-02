<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PublisherManagement.aspx.cs" Inherits="skillproject.PublisherManagement" %>
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
            <%-- Publisher Information card(Section) --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/publisher.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredPublisherID" runat="server" ErrorMessage="Publisher ID Required!" ControlToValidate="TextBox1" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredPublisherName" runat="server" ErrorMessage="Publisher Name Required!" ControlToValidate="TextBox2" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        

                            <div class="row">
                                <div class="col-4">
                                    <asp:Button class="btn btn-success" ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
                                </div>
                                <div class="col-4">
                                    <asp:Button class="btn btn-warning" ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
                                </div>
                                <div class="col-4">
                                    <asp:Button class="btn btn-danger" ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click" />
                                </div>
                         </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back to home</a><br><br>
            </div>

            <%-- Authors Issued Books Information card(section) --%>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [PublisherDetails]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PublisherID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="PublisherID" HeaderText="PublisherID" ReadOnly="True" SortExpression="PublisherID" />
                                        <asp:BoundField DataField="PublisherName" HeaderText="PublisherName" SortExpression="PublisherName" />
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
