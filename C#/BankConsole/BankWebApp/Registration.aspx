<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BankWebApp.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: Arial;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 50px;
        }
        .auto-style3 {
            width: 178px;
            text-align: right;
        }
        .auto-style4 {
            height: 50px;
            width: 178px;
            text-align: right;
        }
        .auto-style5 {
            width: 62px;
        }
        .auto-style6 {
            height: 50px;
            width: 62px;
        }
        .auto-style7 {
            width: 178px;
            text-align: right;
            height: 61px;
        }
        .auto-style8 {
            width: 62px;
            height: 61px;
        }
        .auto-style9 {
            height: 61px;
        }
        .auto-style10 {
            width: 178px;
            text-align: right;
            height: 29px;
        }
        .auto-style11 {
            width: 62px;
            height: 29px;
        }
        .auto-style12 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1><span class="newStyle1">Registration</span></h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
                    :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="ValidatorUsernameReq" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Username Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="ValidatorUsernameRegEx" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Only alphanumeric characters allowed" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                    :</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextboxPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="ValidatorPWReq" runat="server" ControlToValidate="TextboxPassword" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="LabelPWConf" runat="server" Text="Confirm Password:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextboxPWConf" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style12">
                    <asp:RequiredFieldValidator ID="ValidatorPWConfReq" runat="server" ControlToValidate="TextboxPWConf" ErrorMessage="Confirm Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="ValidatorPWCompare" runat="server" ControlToCompare="TextboxPassword" ControlToValidate="TextboxPWConf" ErrorMessage="Passwords do not match" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
&nbsp;<asp:HyperLink ID="HyperLinkLogIn" runat="server" NavigateUrl="~/Default.aspx">Click to Return to Log In</asp:HyperLink>
    </form>
</body>
</html>
