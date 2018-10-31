<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RadioButtonChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your Note Taking Preferences<br />
            <br />
            <asp:RadioButton ID="pencilRadio" runat="server" GroupName="noteTakeGroup" Text="Pencil" />
            <br />
            <asp:RadioButton ID="penRadio" runat="server" GroupName="noteTakeGroup" Text="Pen" />
            <br />
            <asp:RadioButton ID="phoneRadio" runat="server" GroupName="noteTakeGroup" Text="Phone" />
            <br />
            <asp:RadioButton ID="tabletRadio" runat="server" GroupName="noteTakeGroup" Text="Tablet" />
            <br />
            <br />
            <asp:Button ID="okayButton" runat="server" OnClick="okayButton_Click" Text="OK" />
            <br />
            <br />
            <asp:Image ID="resultImage" runat="server" />
            <br />
            <br />
            <asp:Label ID="prefLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
