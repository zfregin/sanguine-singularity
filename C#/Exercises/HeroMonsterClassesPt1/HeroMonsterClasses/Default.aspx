<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeroMonsterClassesPt1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="startRoundButton" runat="server" OnClick="startRoundButton_Click" Text="Begin Round" />
            <br />
            <br />
            <asp:Label ID="heroStatsLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="monsterStatsLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
