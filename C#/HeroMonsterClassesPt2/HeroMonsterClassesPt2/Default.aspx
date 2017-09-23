<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeroMonsterClassesPt2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="startRoundButton" runat="server" OnClick="startRoundButton_Click" Text="New Battle" />
            <br />
            <br />
            <asp:Label ID="battleRoundLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="resultsLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
