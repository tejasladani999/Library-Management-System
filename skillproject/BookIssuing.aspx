<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookIssuing.aspx.cs" Inherits="skillproject.BookIssuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <%-- Publisher Information card(Section) --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books1.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredMemberID" runat="server" ErrorMessage="Member ID Required!" ControlToValidate="TextBox2" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>                                                                                
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredBookID" runat="server" ErrorMessage="Book ID Required!" ControlToValidate="TextBox1" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>                                                                                
                                        <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Issue Date</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" textmode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredIssueDate" runat="server" ErrorMessage="Issue Date Required!" ControlToValidate="TextBox5" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>                                                                                
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Due Date</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox6" runat="server" textmode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDueDate" runat="server" ErrorMessage="Due Date Required!" ControlToValidate="TextBox6" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>                                                                                                                        
                                </div>
                            </div>
                        </div>
                         <div class="row">
                                <div class="col-6">
                                    <asp:Button class="btn btn-block btn-success" ID="Button3" runat="server" Text="Issue" OnClick="Button3_Click" />
                                </div>
                                <div class="col-6">
                                    <asp:Button class="btn btn-block btn-primary" ID="Button4" runat="server" Text="Return" OnClick="Button4_Click" />
                                </div>
                         </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back to home</a><br><br>
            </div>

            <%--  Issued Books Information card(section) --%>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [BookIssueDetails]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="MemberId" HeaderText="MemberId" SortExpression="MemberId" />
                                        <asp:BoundField DataField="MemberName" HeaderText="MemberName" SortExpression="MemberName" />
                                        <asp:BoundField DataField="BookID" HeaderText="BookID" SortExpression="BookID" />
                                        <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" SortExpression="IssueDate" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="ReturnDate" SortExpression="ReturnDate" />
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
