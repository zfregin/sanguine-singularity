<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 90px;
        }
        .auto-style3 {
            width: 90px;
            text-align: right;
        }
        .auto-style4 {
            width: 177px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <asp:Label ID="LabelLedgerApp" runat="server" Text="Welcome to LedgerApp"></asp:Label>
        </h1>
        <h5>
            <asp:Label ID="Label1" runat="server" Text="Please log in"></asp:Label>
        </h5>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LabelUsername" runat="server" Text="Username:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxUserID" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ValidatorUsernameReq" runat="server" ControlToValidate="TextBoxUserID" ErrorMessage="Username Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ValidatorUsernameRegEx" runat="server" ControlToValidate="TextBoxUserID" ErrorMessage="Only alphanumeric characters allowed" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LabelPW" runat="server" Text="Password:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxPW" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ValidatorPWReq" runat="server" ControlToValidate="TextBoxPW" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="BtnLogIn" runat="server" OnClick="BtnLogIn_Click" Text="Log In" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:HyperLink ID="HyperLinkRegister" runat="server" NavigateUrl="~/Registration.aspx">Click Here to Register</asp:HyperLink>
    </form>
</body>
</html>
