
<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="Electricity_Project.AdminForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Enter Electricity Bill Details</h2>

     <asp:Label ID="lblConsumerCount" runat="server" Text="Enter number of consumers to add:" />
<asp:TextBox ID="txtConsumerCount" runat="server" /><br /><br />
<asp:Button ID="btnStartEntry" runat="server" Text="Start Entry" OnClick="btnStartEntry_Click" /><br /><br />

<asp:Panel ID="pnlEntry" runat="server" Visible="false">
    <asp:Label ID="lblNumber" runat="server" Text="Consumer Number:" />
    <asp:TextBox ID="txtNumber" runat="server" /><br /><br />

    <asp:Label ID="lblName" runat="server" Text="Consumer Name:" />
    &nbsp;&nbsp;
    <asp:TextBox ID="txtName" runat="server" /><br /><br />

    <asp:Label ID="lblUnits" runat="server" Text="Units Consumed:" />
    &nbsp;
    <asp:TextBox ID="txtUnits" runat="server" /><br /><br />

    <asp:Button ID="btnSubmitOne" runat="server" Text="Submit Consumer" OnClick="btnSubmitOne_Click" /><br /><br />
</asp:Panel>

<asp:Label ID="lblResult" runat="server" ForeColor="Green" />



        <br />



       <asp:Label ID="lblRetrieve" runat="server" Text="Enter number of bills to retrieve:" />
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtRetrieve" runat="server" /><br />
<asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Bills" OnClick="btnRetrieve_Click" /><br /><br />

<asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />
    
</asp:Content>

