<%@ Page Language="VB" MasterPageFile="~/Views/Shared/account.Master" Inherits="System.Web.Mvc.ViewPage(Of bondi.LogOnModel)" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
              
    <div class="body-sign-in">
        <div class="container">
            <div class="panel panel-default form-container">
                <div class="panel-body">
                    <form role="form">
                        <h3 class="text-center margin-xl-bottom">Welcome Back!</h3>

                        <div class="form-group text-center">
                            <label class="sr-only" for="email">Email Address</label>
                            <input type="email" class="form-control input-lg" id="email" placeholder="Email Address">
                        </div>
                        <div class="form-group text-center">
                            <label class="sr-only" for="password">Password</label>
                            <input type="password" class="form-control input-lg" id="password" placeholder="Password">
                        </div>

                        <a href="index.html" class="btn btn-primary btn-block btn-lg">SIGN IN</a>
                    </form>
                </div>
                <div class="panel-body text-center">
                    <div class="margin-bottom">
                        <a class="text-muted text-underline" href='<%: Url.Action("forgotpassword", "account")%>'>Forgot Password?</a>
                    </div>
                    <div>
                        Don't have an account? <a class="text-primary-dark" href="pages-sign-up.html">Sign up here</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
</asp:Content>
