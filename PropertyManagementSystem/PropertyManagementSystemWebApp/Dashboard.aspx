<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Master_Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PropertyManagementSystemWebApp.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container-fluid">
            <div class="row">
                <div class="col-4">
                    <div class="card">
                        <img src="Images/Property.jpg" class="card-img-top" alt="...">
                        <div class="card-img-overlay">
                            <div class="card-title">
                                Property Detail
                            </div>
                            <div class="card-footer">
                                <button class="btn">CLICK HERE</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-4">
                    <div class="card">
                        <img src="Images/PropManage.jpg" class="card-img-top" alt="...">
                        <div class="card-img-overlay">
                            <div class="card-title">
                                Property Management Firm
                            </div>
                            <div class="card-footer">
                                <button class="btn">CLICK HERE</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-4">
                    <div class="card">
                        <img src="Images/Tenant.jpg" class="card-img-top" alt="...">
                        <div class="card-img-overlay">
                            <div class="card-title">
                                Tenant Detail
                            </div>
                            <div class="card-footer">
                                <button class="btn">CLICK HERE</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-4">
                    <div class="card">
                        <img src="Images/Rent.jpg" class="card-img-top" alt="...">
                        <div class="card-img-overlay">
                            <div class="card-title">
                                Rent Collection
                            </div>
                            <div class="card-footer">
                                <button class="btn">CLICK HERE</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-4">
                    <div class="card">
                        <img src="Images/Tax.jpg" class="card-img-top" alt="...">
                        <div class="card-img-overlay">
                            <div class="card-title">
                                Accountant & Taxation
                            </div>
                            <div class="card-footer">
                                <button class="btn">CLICK HERE</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-4">
                    <div class="card">
                        <img src="Images/Report.jpg" class="card-img-top" alt="...">
                        <div class="card-img-overlay">
                            <div class="card-title">
                                Reports
                            </div>
                            <div class="card-footer">
                                <button class="btn">CLICK HERE</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
