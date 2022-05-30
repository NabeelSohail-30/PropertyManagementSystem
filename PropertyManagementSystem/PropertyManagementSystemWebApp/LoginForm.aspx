<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PropertyManagementSystemWebApp.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form - Property Management System</title>
    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/Global.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <div class="loginbox">
            <img src="Images/Avatar.png" alt="" class="avatar">

            <div class="header">
                <h1>Login Form</h1>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label3" runat="server" Text="User Name" CssClass="loginbox-label"></asp:Label>
                        <asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control loginbox-textbox"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label4" runat="server" Text="Password" CssClass="loginbox-label"></asp:Label>
                        <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control loginbox-textbox"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col d-flex justify-content-center">
                        <asp:Label ID="LblError" runat="server" Text="Error" CssClass="label-error"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col d-flex justify-content-center">
                        <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="button" OnClick="BtnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
