<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobPizza.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-family: Arial;
            font-size: large;
        }
        .auto-style3 {
            color: #FF0000;
        }
        .auto-style4 {
            font-size: xx-large;
            font-family: Arial;
        }
        .auto-style5 {
            font-family: Arial;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" CssClass="auto-style5" ImageUrl="~/PapaBob.png" />
            <span class="auto-style4"><strong>Papa Bob&#39;s Pizza and Software</strong></span><br />
            <br />
            <asp:RadioButton ID="babyRadio" runat="server" GroupName="sizeGroup" Text="Baby Bob Size (10&quot;) - $10" />
            <br />
            <asp:RadioButton ID="mamaRadio" runat="server" Checked="True" GroupName="sizeGroup" Text="Mama Bob Size (13&quot;) - $13" />
            <br />
            <asp:RadioButton ID="papaRadio" runat="server" GroupName="sizeGroup" Text="Papa Bob Size (16&quot;) - $16" />
            <br />
            <br />
            <asp:RadioButton ID="thinCrustRadio" runat="server" Checked="True" GroupName="crustGroup" Text="Thin Crust" />
            <br />
            <asp:RadioButton ID="deepDishRadio" runat="server" GroupName="crustGroup" Text="Deep Dish (+$2)" />
            <br />
            <br />
            <asp:CheckBox ID="pepperoniCheckBox" runat="server" Text="Pepperoni (+$1.50)" />
            <br />
            <asp:CheckBox ID="onionsCheckBox" runat="server" Text="Onions (+$0.75)" />
            <br />
            <asp:CheckBox ID="greenPeppersCheckBox" runat="server" Text="Green Peppers (+$0.50)" />
            <br />
            <asp:CheckBox ID="redPeppersCheckBox" runat="server" Text="Red Peppers (+$0.75)" />
            <br />
            <asp:CheckBox ID="anchoviesCheckBox" runat="server" Text="Anchovies (+$2)" />
            <br />
            <br />
            <span class="auto-style2"><strong>Papa Bob&#39;s <span class="auto-style3">Special Deal</span></strong></span><br />
            <br />
            Save $2.00 when you add Pepperoni, Green Peppers and Anchovies OR Pepperoni, Red Peppers and Onions to your pizza.<br />
            <br />
            <asp:Button ID="purchaseButton" runat="server" OnClick="purchaseButton_Click" Text="Purchase" />
            <br />
            <br />
            Total:&nbsp; <asp:Label ID="totalLabel" runat="server"></asp:Label>
            <br />
            <br />
            Sorry, at this time you can only order one pizza online, and pick-up only ... we need a better website!</div>
    </form>
</body>
</html>
