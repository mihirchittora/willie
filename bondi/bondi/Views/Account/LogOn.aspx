<%@ Page Language="VB" MasterPageFile="~/Views/Shared/frontend.Master" Inherits="System.Web.Mvc.ViewPage(Of bondi.LogOnModel)" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<section id="content">--%>
        <div class="content-wrap">

		    <div class="container clearfix">

			    <div class="accordion accordion-lg divcenter nobottommargin clearfix" style="max-width: 550px;">

				    <div class="acctitle"><i class="acc-closed icon-lock3"></i><i class="acc-open icon-unlock"></i>Login to your Account</div>
				    <div class="acc_content clearfix">
                        <% Using Html.BeginForm("LogOn", "Account")%>
					    <form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">
						    <div class="col_full">
							    <label for="login-form-username">Username:</label>
                                <%: Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control", .id = "login-form-username", .placeholder = "your_email@dot.com", .name = "login-form-username", .required = True})%>
							    <%--<input type="text" id="login-form-username" name="login-form-username" value="" class="form-control" />--%>
						    </div>

						    <div class="col_full">
							    <label for="login-form-password">Password:</label>
                                <%: Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control", .id = "login-form-password", .placeholder = "your password", .type = "password", .name = "login-form-password", .required = True})%>
							    <%--<input type="password" id="login-form-password" name="login-form-password" value="" class="form-control" />--%>
						    </div>

						    <div class="col_full nobottommargin">
							    <button class="button button-3d button-green nomargin" id="login-form-submit" name="login-form-submit" value="login">Login</button>
							    <a href="#" class="fright" style="padding-right: 5px;">Forgot Password?</a>
						    </div>
					    </form>
                        <% End Using%>
				    </div>

				    <div class="acctitle"><i class="acc-closed icon-user4"></i><i class="acc-open icon-ok-sign"></i>New Signup? Register for an Account</div>
				    <div class="acc_content clearfix">
                        <% Using Html.BeginForm("Register", "Account")%>
					    <form id="register-form" name="register-form" class="nobottommargin" action="#" method="post">
						    <%--<div class="col_full">
							    <label for="register-form-name">Name:</label>
							    <input type="text" id="register-form-name" name="register-form-name" value="" class="form-control" />
						    </div>--%>

						    <div class="col_full">
							    <label for="register-form-email">Email Address:</label>
                                <%: Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control", .id = "login-form-username", .placeholder = "your_email@dot.com", .name = "login-form-username", .required = True})%>
							    <%--<input type="text" id="register-form-email" name="register-form-email" value="" class="form-control" />--%>
						    </div>

						   <%-- <div class="col_full">
							    <label for="register-form-username">Choose a Username:</label>
							    <input type="text" id="register-form-username" name="register-form-username" value="" class="form-control" />
						    </div>--%>

						    <%--<div class="col_full">
							    <label for="register-form-phone">Phone:</label>
							    <input type="text" id="register-form-phone" name="register-form-phone" value="" class="form-control" />
						    </div>--%>

						    <div class="col_full">
							    <label for="register-form-password">Choose Password:</label>
                                <%: Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control", .id = "register-form-password", .placeholder = "your password", .type = "password", .name = "register-form-password", .required = True})%>
							    <%--<input type="password" id="register-form-password" name="register-form-password" value="" class="form-control" --%>/>
						    </div>

						    <div class="col_full">
							    <label for="register-form-repassword">Re-enter Password:</label>
                                <%: Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control", .id = "register-form-repassword", .placeholder = "your password", .type = "password", .name = "register-form-repassword", .required = True})%>
							    <%--<input type="password" id="register-form-repassword" name="register-form-repassword" value="" class="form-control" />--%>
						    </div>

						    <div class="col_full nobottommargin">
							    <button class="button button-3d button-green nomargin" id="register-form-submit" name="register-form-submit" value="register">Register Now</button>
						    </div>
					    </form>
                        <% End Using%>
				    </div>

			    </div>

		    </div>

	    </div>


    <%--</section>--%>

    <%--<h2>Log On</h2>
    <p>
        Please enter your user name and password. <%: Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% Using Html.BeginForm() %>
        <%: Html.ValidationSummary(True, "Login was unsuccessful. Please correct the errors and try again.")%>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.UserName) %>
                    <%: Html.ValidationMessageFor(Function(m) m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(Function(m) m.Password) %>
                    <%: Html.ValidationMessageFor(Function(m) m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.CheckBoxFor(Function(m) m.RememberMe) %>
                    <%: Html.LabelFor(Function(m) m.RememberMe) %>
                </div>
                <p>
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <% End Using %>--%>
</asp:Content>
