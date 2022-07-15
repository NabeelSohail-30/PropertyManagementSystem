<%@ Page Title="Login Form" Language="C#" MasterPageFile="~/Master_Main.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PropertyManagementSystemWebApp.LoginForm  " %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="login-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-6 login_box">
                        <div class="container">
                            <div class="row">
                                <div class="col d-flex justify-content-center mt-3">
                                    <h1>Login</h1>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="Label1" runat="server" Text="User Name" class="lbl_foreWhite"></asp:Label>
                                    <asp:TextBox ID="TxtUserName" runat="server" class="txt_box_foreRed form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="Label2" runat="server" Text="User Name" class="lbl_foreWhite"></asp:Label>
                                    <asp:TextBox ID="TxtPassword" runat="server" class="txt_box_foreRed form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col d-flex justify-content-center">
                                    <asp:Label ID="LblError" runat="server" Text="ERROR" class="error_white"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col d-flex justify-content-center">
                                    <asp:Button ID="BtnLogin" runat="server" Text="Login" class="btn_red" OnClick="BtnLogin_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-6 login_img">
                        <img src="Images/logo.png">
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
