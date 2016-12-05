<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lab5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
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
                        <li class="active">
                            <a href="Default.aspx">Home</a>
                        </li>
                        <li class="">
                            <a href="Headers.aspx">Headers</a>
                        </li>
                        <li class="">
                            <a href="SecuredPage.aspx">Sales</a>
                        </li>
                    </ul>
                     <ul class="nav navbar-nav navbar-right">

                         <li class="dropdown">
                          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                              
                               <% Response.Write(customer.GetFullName()); %> <!-- Display customers First and Last name (based off of custom cookie)-->
                              
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
                <div class="col-md-12">
                    <h2>WELCOME! TO THE SUPER COOL WEBPAGE!</h2>
                    <i class="fa fa-reddit-alien fa-4x fa-spin" aria-hidden="true"></i>
                    <i class="fa fa-reddit-alien fa-10x fa-spin" aria-hidden="true"></i>
                    <i class="fa fa-reddit-alien fa-500px fa-spin" aria-hidden="true"></i>
                    <i class="fa fa-reddit-alien fa-4x fa-spin" aria-hidden="true"></i>
                    <i class="fa fa-reddit-alien fa-4x fa-flip-vertical text-info" aria-hidden="true"></i>
                    <i class="fa fa-reddit-alien fa-500x fa-spin" aria-hidden="true"></i>
                    <i class="fa fa-rebel fa-5x fa-spin" aria-hidden="true"></i>

                    Weeeeeeeeeee....

                    <%if (customer.IsCached) { %>
                        <div class="alert alert-warning">
                            This is a cached customer! Cache HIT!
                        </div>
                    <% } else { %>
                        <div class="alert alert-info">
                            Cache miss! :(
                        </div>
                    <% } %>
                </div>
            </div>
        </div>

    </form>

</body>
</html>
