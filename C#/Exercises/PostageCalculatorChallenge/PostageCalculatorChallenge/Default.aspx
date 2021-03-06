﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PostageCalculatorChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Postage Calculator<br />
            <br />
            Width:&nbsp;
            <asp:TextBox ID="widthTextBox" runat="server" AutoPostBack="True" OnTextChanged="handleChange"></asp:TextBox>
            <br />
            Height:&nbsp;
            <asp:TextBox ID="heightTextBox" runat="server" AutoPostBack="True" OnTextChanged="handleChange"></asp:TextBox>
            <br />
            Length:&nbsp;
            <asp:TextBox ID="lengthTextBox" runat="server" AutoPostBack="True" OnTextChanged="handleChange"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="groundRadio" runat="server" GroupName="Shipping Radio" OnCheckedChanged="handleChange" Text="Ground" AutoPostBack="True" />
            <br />
            <asp:RadioButton ID="airRadio" runat="server" GroupName="Shipping Radio" OnCheckedChanged="handleChange" Text="Air" AutoPostBack="True" />
            <br />
            <asp:RadioButton ID="nextDayRadio" runat="server" GroupName="Shipping Radio" OnCheckedChanged="handleChange" Text="Next Day" AutoPostBack="True" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
