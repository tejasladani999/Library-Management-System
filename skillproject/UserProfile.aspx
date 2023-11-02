<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="skillproject.UserProfile" %>
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
            <%-- User Information card(Section) --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/generaluser.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label class="badge badge-pill badge-success" ID="Label1" runat="server" Text="Your Status"></asp:Label>
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
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFullName" runat="server" ErrorMessage="Full Name Required!" ControlToValidate="TextBox1" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                <label>Date of  Birth</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Date of  Birth" TextMode="date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDBO" runat="server" ErrorMessage="Date of Birth Required!" ControlToValidate="TextBox2" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredContactNo" runat="server" ErrorMessage="contactNo Required!" ControlToValidate="TextBox3" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="Email Required!" ControlToValidate="TextBox4" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="State" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredState" runat="server" ErrorMessage="state Required!" ControlToValidate="TextBox5" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredCity" runat="server" ErrorMessage="city Required!" ControlToValidate="TextBox6" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredPincode" runat="server" ErrorMessage="Pincode Required!" ControlToValidate="TextBox7" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>FullAddress</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="FullAddress" TextMode="Multiline"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFullAddress" runat="server" ErrorMessage="Full Address Required!" ControlToValidate="TextBox8" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                                <div class="col">
                                    <center>
                                    <span class="badge badge-pill badge-info">Login Credentials</span>
                                    </center>
                                </div>
                         </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Old Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                    <asp:Button class="btn- btn-primary btn-block  btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                    </div>
                                </center>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx"><< Back to home</a><br><br>
            </div>

            <%-- User Issued Books Information card(section) --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/books1.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False">
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
</asp:Content>
