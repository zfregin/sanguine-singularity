<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EpicSpiesChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            margin-bottom: 15px;
        }
        .auto-style4 {
            width: 190px;
            height: 238px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img alt="" class="auto-style4" src="epic-spies-logo.jpg" /><h2 class="auto-style3">Spy New Assignment Form</h2>
            Spy Code Name:&nbsp;
            <asp:TextBox ID="spyNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:&nbsp;
            <asp:TextBox ID="assignmentNameTextBox" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment:<asp:Calendar ID="previousEndCal" runat="server"></asp:Calendar>
            <br />
            Start Date of New Assignment:<asp:Calendar ID="startCal" runat="server"></asp:Calendar>
            <br />
            Projected End Date of New Assignment:<asp:Calendar ID="projectedEndCal" runat="server"></asp:Calendar>
            <br />
            <br />
            <asp:Button ID="assignButton" runat="server" OnClick="assignButton_Click" Text="Assign Spy" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
