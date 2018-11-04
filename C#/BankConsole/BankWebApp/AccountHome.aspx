<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountHome.aspx.cs" Inherits="BankWebApp.AccountHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
        <asp:Label ID="Label1" runat="server" Text="Account Home"></asp:Label>
        </h1>
        <br />
        <asp:Button ID="ButtonDeposit" runat="server" OnClick="ButtonDeposit_Click" Text="Make a Deposit" />
&nbsp;&nbsp;&nbsp; $<asp:TextBox ID="TextBoxDeposit" runat="server" ></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelDeposit" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonWithdrawal" runat="server" OnClick="ButtonWithdrawal_Click" Text="Make a Withdrawal" />
&nbsp;&nbsp;&nbsp; $<asp:TextBox ID="TextBoxWithdrawal" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelWithdrawal" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonCheckBalance" runat="server" OnClick="ButtonCheckBalance_Click" Text="Check Balance" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelBalance" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonTransactions" runat="server" OnClick="ButtonTransactions_Click" Text="View Transaction History" />
        <br />
        <br />
        <asp:Label ID="LabelTransactions" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonLogOut" runat="server" OnClick="ButtonLogOut_Click" Text="Log Out" />
    </form>
</body>
</html>
