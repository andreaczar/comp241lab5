<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Headers.aspx.cs" Inherits="lab5.Headers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <% if (Authenticated) { %>
            <input id="Logout" runat="server" value="Logout" type="submit" OnServerClick="LogoutUser"/>
        <%} %>

    </div>
    </form>

</body>
</html>
