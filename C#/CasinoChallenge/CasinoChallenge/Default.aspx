<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CasinoChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="reel1" runat="server" Height="145px" Width="156px" />
            <asp:Image ID="reel2" runat="server" Height="145px" Width="156px" />
            <asp:Image ID="reel3" runat="server" Height="145px" Width="156px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull The Lever!" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
&nbsp;<asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - x2 Your Bet<br />
            2 Cherries - x3 Your Bet<br />
            3 Cherries - x4 Your Bet<br />
            3 7&#39;s - Jackpot - x100 Your Bet<br />
            HOWEVER ... If there&#39;s even one bar you win nothing.</div>
    </form>
</body>
</html>
