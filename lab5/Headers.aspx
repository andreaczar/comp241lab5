<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Headers.aspx.cs" Inherits="lab5.Headers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-default">
            <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">Lab 5</a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="Default.aspx">Home</a>
                        </li>
                        <li class="active">
                            <a href="Headers.aspx">Headers</a>
                        </li>
                        <li class="">
                            <a href="SecuredPage.aspx">Sales</a>
                        </li>
                    </ul>
                     <ul class="nav navbar-nav navbar-right">

                         <li class="dropdown">
                          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                              <% Response.Write(HttpContext.Current.User.Identity.Name); %>
                              <span class="caret"></span>
                          </a>
                          <ul class="dropdown-menu">
                            <li>
                                <a id="Submit1" type="submit" value="Sign Out" runat="server" OnServerClick="cmdSignOut_Click">Sign Out</a>
                            </li>
                          </ul>
                        </li>
                    </ul>
                </div><!-- /.navbar-collapse -->
            </div><!-- /.container -->
        </nav>

        <div class="container">
            <div class="row">
                <div class="col-lg-12">

                    <div style="margin-top: 20px;">
                        <asp:Table ID="HeadersTable" runat="server" GridLines="Both" CellPadding="4" CssClass="table table-bordered table-condensed table-hover" style="table-layout: fixed; word-wrap:break-word;">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell Text="Header" />
                                <asp:TableHeaderCell Text="Value" Width="50%" />
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>

    </form>

</body>
</html>
