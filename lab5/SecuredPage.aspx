<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecuredPage.aspx.cs" Inherits="lab5.SecuredPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        
        <asp:Table ID="SalesTable" runat="server" GridLines="Both" CellPadding="4">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Text="Store ID" />
                <asp:TableHeaderCell Text="Order Number" />
                <asp:TableHeaderCell Text="Order Date" />
                <asp:TableHeaderCell Text="Quantity" />
                <asp:TableHeaderCell Text="PayTerms" />
                <asp:TableHeaderCell Text="Title Id" />
            </asp:TableHeaderRow>
        </asp:Table>

        <br />
            <a href="Headers.aspx">Headers</a>
        <br />
            <a href="Default.aspx">Default</a>
        <br />

        <input id="SignOut" type="submit" value="Sign Out" runat="server" OnServerClick="cmdSignOut_Click"/>
        <input id="Refresh" type="submit" value="Refresh" runat="server" OnServerClick="Page_Load"/>
    </div>
    </form>
</body>
</html>
