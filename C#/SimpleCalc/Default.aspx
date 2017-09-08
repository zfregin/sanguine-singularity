<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleCalc.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="margin-bottom: 0px">Simple Calculator</h2>
            <br />
            <span class="auto-style1">First Value: </span>&nbsp;<asp:TextBox ID="val1TextBox" runat="server"></asp:TextBox>
            <br />
            <span class="auto-style1">Second Value:</span>&nbsp;
            <asp:TextBox ID="val2TextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text=" + " />
&nbsp;
            <asp:Button ID="subtractButton" runat="server" Text=" - " OnClick="subtractButton_Click" />
&nbsp;
            <asp:Button ID="multiplyButton" runat="server" Text=" * " OnClick="multiplyButton_Click" />
&nbsp;
            <asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text=" / " />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server" BackColor="#3399FF" Font-Bold="True" Font-Size="Large"></asp:Label>
        </div>
    </form>
</body>
</html>
