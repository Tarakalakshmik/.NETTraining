<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Page</title>


</head>
<body>
    <form id="form1" runat="server">
    <div></div>
    <asp:Label ID="Label1" runat="server" Text="Insert your Details"></asp:Label>
    <p>
        Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Txtname" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtname" ErrorMessage="Name Cannot be Blank" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Family Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Txtfname" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtfname" ErrorMessage="Family name cannot be blank" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="Txtfname" Display="Dynamic" ErrorMessage="Differs from Name" ForeColor="Red" OnServerValidate="ValidateNameAndFamily" ValidationGroup="M" ></asp:CustomValidator>
    </p>
    <p>
        Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Txtaddr" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtaddr" ErrorMessage="Address Required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator_Adr" runat="server" ControlToValidate="Txtaddr" ErrorMessage="Address Invalid" ForeColor="Red" OnServerValidate="ValidateAddress" ValidationGroup="M" Display="Dynamic" ></asp:CustomValidator>
    </p>
    <p>
        City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcity" ErrorMessage="City Required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidate_City" runat="server" ControlToValidate="txtcity" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="ValidateCity" ValidationGroup="M" Display="Dynamic" >Invalid City</asp:CustomValidator>
    </p>
    <p>
        Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtzip" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtzip" ErrorMessage="Zip code is required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        &nbsp;<asp:CustomValidator ID="CustomValidator_Zip" runat="server" ControlToValidate="txtzip" Display="Dynamic" ErrorMessage="Invalid ZipCode" ForeColor="Red" OnServerValidate="ValidateZipCode" ValidationGroup="M" ></asp:CustomValidator>
    </p>
    <p>
        Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Txtphone" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Txtphone" ErrorMessage="Phone number is required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator_Phone" runat="server" ControlToValidate="Txtphone" Display="Dynamic" ErrorMessage="Invalid Phone" ForeColor="Red" OnServerValidate="ValidatePhoneNumber" ValidationGroup="M" ></asp:CustomValidator>
    </p>
    <p>
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemail" ErrorMessage="Email is required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator_email" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid Email" ForeColor="Red" OnServerValidate="ValidateEmail" ValidationGroup="M" Display="Dynamic" ></asp:CustomValidator>
    </p>
    <p>
        <asp:Button ID="btncheck" runat="server" OnClick="OnCheckButtonClick" Text="Check" ValidationGroup="M" />
        &nbsp;&nbsp;&nbsp;
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="M" />
    <asp:Label ID="txtmsg" runat="server"></asp:Label>
</form>
</body>
</html>
