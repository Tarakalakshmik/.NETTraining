<%--<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Electricity_Project.LoginForm" %>--%>


<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Electricity_Project.LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Login</h2>
    <asp:Label ID="lblUser" runat="server" Text="Username:" />
    <asp:TextBox ID="txtUser" runat="server" /><br /><br />

    <asp:Label ID="lblPass" runat="server" Text="Password:" />
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" /><br /><br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
</asp:Content>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Admin Login</h2>
        <asp:Label ID="lblUser" runat="server" Text="Username:" />
        <asp:TextBox ID="txtUser" runat="server" /><br /><br />

        <asp:Label ID="lblPass" runat="server" Text="Password:" />
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" /><br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    </form>
</body>
</html>--%>

