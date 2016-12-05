<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lab5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Super cool data</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>
<body>
    <div class="container">

        
             
        <div class="row" style="margin-top: 40px;">

            <div class="col-md-4 col-md-offset-4 col-sm-12">

                <h2>Super Cool Login Page</h2>
                <% if (InvalidLogin) { %>
                    <div class="alert alert-danger">
                        Invalid login.  Please try again.
                    </div>
                <% } else { %>
                    <div class="spacer" style="margin-top:60px;">
                    
                    </div>
                <% } %>


                <div class="panel panel-default">
                    <div class="panel-heading">
                        Super Cool - Sign In
                    </div>
                    <div class="panel-body">
                        <form id="form1" runat="server">
                       
                            <div class="form-group<% if (InvalidLogin) { %> has-error<% } %> ">
                                <label class="control-label">Username</label>
                                <asp:TextBox ID="Username" MaxLength="16" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group<% if (InvalidLogin) { %> has-error<% } %> ">
                                <label class="control-label">Password</label>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="RememberMe" runat="server" /> Remember Me
                                </label>
                            </div>
                        
                            <div class="form-group">
                                <input id="Submit1" type="submit" value="Login" runat="server" class="btn btn-primary btn-block" OnServerClick="ValidateUser"/>
                            </div>
                        </form>
                    </div>
                </div>
                    
            </div>
           

<%--            <% if (Authenticated) { %>
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
            <% } %>--%>



<%--        </div>

            <% if (Authenticated) { %>
            <a href="Headers.aspx">Headers</a>
            <%  } %>

     </div>--%>
</body>
</html>
