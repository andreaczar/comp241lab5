<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lab5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser"></asp:Login>--%>

    <div>
        <label>Username:</label>
        <asp:TextBox ID="Username" MaxLength="16" runat="server" ></asp:TextBox>
        <br />
        <label>Password:</label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        
        <input id="Submit1" type="submit" value="Login" runat="server" OnServerClick="ValidateUser"/>

        <% if (Authenticated) { %>
            <input id="Logout" runat="server" value="Logout" type="submit" OnServerClick="LogoutUser"/>
        <%} %>

    </div>
    </form>

        <% if (Authenticated) { %>
        <a href="Headers.aspx">Headers</a>
        <%  } %>

</body>
</html>
