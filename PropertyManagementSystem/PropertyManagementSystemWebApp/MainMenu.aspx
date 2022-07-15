<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Main.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="PropertyManagementSystemWebApp.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container">
            <div class="row">
                <div class="col-4">
                    <div class="card text-center">
                        <img class="card-img-top" src="Images/login.jpg" alt="Card image"
                            style="width: 100%; height: 280px;">

                        <div class="card-body">
                            <h4 class="card-title">Login</h4>
                            <div class="login_form">
                                <asp:TextBox ID="TxtUserName" runat="server" class="form-control card_textbox" placeholder="Enter User Name"></asp:TextBox>
                                <asp:TextBox ID="TxtPassword" runat="server" class="form-control card_textbox" placeholder="Enter Password"></asp:TextBox>

                                <asp:Label ID="LblError" runat="server" Text="error" class="error_red"></asp:Label>
                                <br />

                                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-4">
                    <div class="card text-center">
                        <img class="card-img-top" src="Images/about.jpg" alt="Card image"
                            style="width: 100%; height: 280px;">

                        <div class="card-body" style="margin-top: 40px">
                            <h4 class="card-title">About Us</h4>
                            <asp:Button ID="btnAbout" runat="server" Text="Click Here" class="btn" />
                        </div>
                    </div>
                </div>

                <div class="col-4">
                    <div class="card text-center">
                        <img class="card-img-top" src="Images/services.jpg" alt="Card image"
                            style="width: 100%; height: 280px;">

                        <div class="card-body" style="margin-top: 40px">
                            <h4 class="card-title">Services</h4>
                            <asp:Button ID="btnServices" runat="server" Text="Click Here" class="btn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
