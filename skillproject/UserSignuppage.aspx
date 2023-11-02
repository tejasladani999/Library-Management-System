<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserSignuppage.aspx.cs" Inherits="skillproject.UserSignuppage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="imgs/generaluser.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Registration</h3>
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
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="FullName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFullName" runat="server" ErrorMessage="Full Name Required!" ControlToValidate="TextBox1" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                <label>Date of  Birth</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="DOB" TextMode="date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredDBO" runat="server" ErrorMessage="Date Of Birth Required!" ControlToValidate="TextBox2" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="ContactNo" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredConatctNo" runat="server" ErrorMessage="ConatctNo Required!" ControlToValidate="TextBox3" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="Requiredstate" runat="server" ErrorMessage="State Required!" ControlToValidate="TextBox5" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredcity" runat="server" ErrorMessage="City Required!" ControlToValidate="TextBox6" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>

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
                                    <asp:RequiredFieldValidator ID="RequiredFullAddress" runat="server" ErrorMessage="FullAddress Required!" ControlToValidate="TextBox8" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
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
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="MemberID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredMemberID" runat="server" ErrorMessage="MemberID Required!" ControlToValidate="TextBox9" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Password Required!" ControlToValidate="TextBox10" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                
                                <div class="form-group">
                                    <asp:Button class="btn- btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx"><< Back to home</a><br><br>
            </div>
        </div>
    </div>
</asp:Content>
