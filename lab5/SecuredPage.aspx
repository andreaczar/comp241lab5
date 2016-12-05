<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecuredPage.aspx.cs" Inherits="lab5.SecuredPage" %>

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
                    <li>
                        <a href="Headers.aspx">Headers</a>
                    </li>
                    <li class="active">
                        <a href="SecuredPage.aspx">Sales</a>
                    </li>
                </ul>
                 <ul class="nav navbar-nav navbar-right">

                     <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                          <% Response.Write(customer.Firstname + " " + customer.Lastname); %>
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
                  
                    <div>
                        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                        
                        <div class="btn-group pull-right">
                            <a class="btn btn-default" runat="server" OnServerClick="Page_Load">
                                <i class="glyphicon glyphicon-refresh"></i>
                            </a>
                        </div>
                    </div>

                    <div style="margin-top: 20px;">
                        <asp:Table ID="SalesTable" runat="server" GridLines="Both" CellPadding="4" CssClass="table table-bordered table-condensed table-hover">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell Text="Store ID" />
                                <asp:TableHeaderCell Text="Order Number" />
                                <asp:TableHeaderCell Text="Order Date" />
                                <asp:TableHeaderCell Text="Quantity" />
                                <asp:TableHeaderCell Text="PayTerms" />
                                <asp:TableHeaderCell Text="Title Id" />
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                
            </div>
        </div>
    </div>

  </form>
</body>
</html>
