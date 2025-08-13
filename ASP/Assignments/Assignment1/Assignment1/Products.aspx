<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Assignment1.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
  <style>
     

        h2 {
            color: #333;
            margin-bottom: 20px;
        }

        .dropdown, .button {
            margin: 15px 0;
        }

        .button {
            padding: 10px 20px;
            background-color:aqua;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

       .price-label {
            font-size: 18px;
            font-weight: bold;
            color:coral;
            margin-top: 20px;
            display: block;
        }

     
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Select a Product</h2>
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" CssClass="dropdown"></asp:DropDownList>
            <br />
            <asp:Image ID="imgProduct" runat="server" Width="400px" Height="400px" />
            <br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click"  CssClass="button"/>
            <br />
            <asp:Label ID="lblPrice" runat="server"  CssClass="price-label"></asp:Label>
        </div>
    </form>
</body>
</html>
