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
        
        <% if (!Authenticated) {%>
            <label>Username:</label>
            <asp:TextBox ID="Username" MaxLength="16" runat="server"></asp:TextBox>
            <br />
            <label>Password:</label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
        
            <input id="Submit1" type="submit" value="Login" runat="server" OnServerClick="ValidateUser"/>
        <% } %>
        
        <% if (Authenticated) { %>
            <p>
                <b>First Name:</b> <% Response.Write(RequestCustomer.Firstname); %>
            </p>
            
            <p>
                <b>Last Name:</b> <% Response.Write(RequestCustomer.Lastname); %>
            </p>
            
            <p>
                <b>Customer ID:</b> <% Response.Write(RequestCustomer.Customerid); %>
            </p>
            
            <p>
                <b>Session ID:</b> <% Response.Write(RequestCustomer.Cookie); %>
            </p>
            
            <input id="Logout" runat="server" value="Logout" type="submit" OnServerClick="LogoutUser"/>
        <%} %>



    </div>
    </form>

        <% if (Authenticated) { %>
        <a href="Headers.aspx">Headers</a>
        <%  } %>

    

        <% if (InvalidLogin) { %>
        Invalid login.  Please try again.
        <%  } %>

</body>
</html>
