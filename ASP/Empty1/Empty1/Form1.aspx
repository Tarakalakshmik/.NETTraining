<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Empty1.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div>
        </div>
        <p>
            <asp:TextBox ID="txt1" runat="server"></asp:TextBox><br />
              <asp:Button ID="btnclick" text="click" runat="server" Height="96px" OnClick="btnclick_Click" Width="201px" />
        </p>
    </form>
</body>
</html>
