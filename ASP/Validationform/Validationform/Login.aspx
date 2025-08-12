<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Validationform.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Validation</title>
     <script type="text/javascript">
        function Length(source, args) {
            
            
                if ((args.Value.Length < 8) ) {
                    args.IsValid = false;
                    alert("validation failed..")
                }
                else {
                    args.IsValid = true;
                    alert("Validation succeeded..");
                    }
         }
         function Range(source, args) {
             if ((args.Value.Length > 6) || (args.Value.Length < 8)) {
                 args.IsValid = false;
                 alert("Validation failed..");
             } else {
                 args.IsValid = true;
                 alert("validation succeeded..")
             }
         }
        
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        </div>
        <asp:Label ID="labuser" runat="server" Text="UserName"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Length should be greater than 8" OnServerValidate="CustomValidator1_ServerValidate" ClientValidationFunction="Length"></asp:CustomValidator>
&nbsp;<p>
            <asp:Label ID="Labpass" runat="server" Text="Password"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Should be in range 6 to 8" OnServerValidate="CustomValidator2_ServerValidate" ClientValidationFunction="Range"></asp:CustomValidator>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    </form>
</body>
</html>
