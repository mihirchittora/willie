<%@ Page Language="VB" MasterPageFile="~/Views/Shared/frontend.Master" Inherits="System.Web.Mvc.ViewPage(Of bondi.RegisterModel)" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="content-wrap">

				<div class="container clearfix">

					<div class="col_one_third nobottommargin">

						<div class="well well-lg nobottommargin">
                            <% Using Html.BeginForm("LogOn", "Account")%>
							    <form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">

								    <h3>Login to your Account</h3>

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
									    <button class="button button-3d nomargin" id="login-form-submit" name="login-form-submit" value="login">Login</button>
									    <a href="#" class="fright">Forgot Password?</a>
								    </div>

							    </form>
                            <%End Using%>
						</div>

					</div>

					<div class="col_two_third col_last nobottommargin">


						<h3>Don't have an Account? Register Now.</h3>

						<p>Who are you? Who? Who? We really wanna know!</p>

                        <% Using Html.BeginForm("register", "Account")%>
						    <form id="register-form" name="register-form" class="nobottommargin" action="#" method="post">

							   <%-- <div class="col_half">
								    <label for="register-form-name">Name:</label>
								    <input type="text" id="register-form-name" name="register-form-name" value="" class="form-control" />
							    </div>--%>

							    <div class="col_half">
								    <label for="register-form-email">User id (Email Address):</label>
                                    <%: Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control", .id = "login-form-username", .placeholder = "your_email@dot.com", .name = "login-form-username", .required = True})%>
								    <%--<input type="text" id="register-form-email" name="register-form-email" value="" class="form-control" />--%>
							    </div>

							    <div class="clear"></div>

							   <%-- <div class="col_half">
								    <label for="register-form-username">Choose a Username:</label>
								    <input type="text" id="register-form-username" name="register-form-username" value="" class="form-control" />
							    </div>

							    <div class="col_half col_last">
								    <label for="register-form-phone">Phone:</label>
								    <input type="text" id="register-form-phone" name="register-form-phone" value="" class="form-control" />
							    </div>--%>

							    <div class="clear"></div>

							    <div class="col_half">
								    <label for="register-form-password">Choose Password:</label>
                                    <%: Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control", .id = "register-form-password", .placeholder = "your password", .type = "password", .name = "register-form-password", .required = True})%>
								    <%--<input type="password" id="register-form-password" name="register-form-password" value="" class="form-control" />--%>
							    </div>

                                <div class="clear"></div>

							    <div class="col_half">
								    <label for="register-form-repassword">Re-enter Password:</label>
                                    <%: Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control", .id = "register-form-repassword", .placeholder = "your password", .type = "password", .name = "register-form-repassword", .required = True})%>
								    <%--<input type="password" id="register-form-repassword" name="register-form-repassword" value="" class="form-control" />--%>
							    </div>

							    <div class="clear"></div>

							    <div class="col_full nobottommargin">
								    <button class="button button-3d button-black nomargin" id="register-form-submit" name="register-form-submit" value="register">Register Now</button>
							    </div>

						    </form>
                        <%End Using%>

					</div>

				</div>

			</div>
    
    <%--<h2>Create a New Account</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
    </p>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% Using Html.BeginForm() %>
        <%: Html.ValidationSummary(True, "Account creation was unsuccessful. Please correct the errors and try again.")%>
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
                    <%: Html.LabelFor(Function(m) m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.Email) %>
                    <%: Html.ValidationMessageFor(Function(m) m.Email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(Function(m) m.Password) %>
                    <%: Html.ValidationMessageFor(Function(m) m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(Function(m) m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(Function(m) m.ConfirmPassword) %>
                </div>
                
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% End Using %>--%>
</asp:Content>
