<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="skillproject.MemberManagement" %>
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
            <%-- Member Information card(Section) --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/generaluser.png" alt="" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredMemberID" runat="server" ErrorMessage="Member ID Required!" ControlToValidate="TextBox1" Display="Dynamic" ForeColor="#990000"></asp:RequiredFieldValidator>
                                        <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>                                    
                                    </div>
                                </div>
                            </div>

                        
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                        
                                        <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" class="btn btn-warning" runat="server" OnClick="LinkButton2_Click"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" class="btn btn-danger" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>  
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Email</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="Email" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox9" runat="server" TextMode="Number" placeholder="Pincode" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>FullAddress</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="FullAddress" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                                <div class="col-12">
                                    <asp:Button class="btn btn-block btn-danger" ID="Button3" runat="server" Text="Delete User Permanently" OnClick="Button3_Click" />
                                </div>
                                
                         </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back to home</a><br><br>
            </div>

            <%--  Member Information card(section) --%>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [MemberDetails]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MemberID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="MemberID" HeaderText="MemberID" ReadOnly="True" SortExpression="MemberID" />
                                        <asp:BoundField DataField="FullName" HeaderText="Name" SortExpression="FullName" />
                                        <asp:BoundField DataField="AccountStatus" HeaderText="AccountStatus" SortExpression="AccountStatus" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" SortExpression="ContactNo" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
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
