<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyFirstChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            How old are you?&nbsp;
            <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            How much money do you have in your pocket?&nbsp;
            <asp:TextBox ID="cashTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="calloutButton" runat="server" OnClick="calloutButton_Click" Text="Click Me for Callout" />
            <br />
            <br />
            <asp:Label ID="calloutLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
