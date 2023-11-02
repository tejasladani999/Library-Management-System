<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="skillproject.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
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
                                    <h3>Mebmer Login</h3>
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
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredMemberID" runat="server" ErrorMessage="MemberID Required!" ControlToValidate="TextBox1" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Password Required!" ControlToValidate="TextBox2" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn- btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="UserSignuppage.aspx"> 
                                    <input type="button" class="btn btn-info btn-block btn-lg" value="Sign Up" id="button2" />
                                    </a>
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
