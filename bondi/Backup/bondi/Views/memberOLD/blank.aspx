<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <aside class="sidebar sidebar-default">
            <div class="sidebar-profile">
                <img class="img-circle profile-image" src="../../Content/Member/demo/images/profile.jpg">
                <div class="profile-body">
                    <h4><%: Page.User.Identity.Name %></h4>
                                            
                    <div class="sidebar-user-links">
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("Profile", "Member")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Profile"><i class="fa fa-user"></i></a>                        
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("Settings", "Member")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Settings"><i class="fa fa-cog"></i></a>
                        <a class="btn btn-link btn-xs" href='<%:Url.Action("logoff", "account")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Logout"><i class="fa fa-sign-out"></i></a>
                    </div>
                </div>
            </div>

            <nav>
                <h5 class="sidebar-header">Navigation</h5>
                    <ul class="nav nav-pills nav-stacked">
                        <li class="active open"><a href='<%: Url.Action("Index", "Member")%>'><i class="fa fa-lg fa-fw fa-home"></i> Dashboard</a></li>                                                          
                        <li class="nav-dropdown">
                            <% If User.Identity.Name.ToUpper = "BOSS" Then%>
                                <a href="#" title="Social"><i class="fa fa-lg fa-fw fa-cogs"></i> My Settings</a>
                           
                                 <ul class="nav-sub">
                                    <li><a href='<%: Url.Action("Profile", "Member")%>' title="Profile"><i class="fa fa-lg fa-fw fa-user"></i> Profile</a></li> 
                                    <li><a href='<%: Url.Action("Settings", "Member")%>' title="Settings"><i class="fa fa-lg fa-fw fa-gear"></i> Settings</a></li>                            
                                </ul>
                            <% End if %>
                            </li>
                        <li class="nav-dropdown"><a href="#" title="Positions"><i class="fa fa-lg fa-fw fa-bank"></i> My Positions</a>
                            <ul class="nav-sub">
                                <li><a href='<%: Url.Action("Garden", "Member")%>' title="Garden"><i class="fa fa-lg fa-fw fa-leaf"></i> Garden</a></li>                                                    
                                <% If User.Identity.Name.ToUpper = "CSQUARED20" Then%>                                                    
                                    <%--<li><a href='<%: Url.Action("SuperFly", "Member")%>' title="SuperFly"><i class="fa fa-lg fa-fw fa-paper-plane"></i> Super-Fly</a></li>--%>
                                    <%--<li><a href='<%: Url.Action("SuperFly", "Member")%>' title="SuperFly"><i class="fa fa-lg fa-fw fa-paper-plane"></i> The Strangle</a></li>--%>
                                    <%--<li><a href='<%: Url.Action("SuperFly", "Member")%>' title="SuperFly"><i class="fa fa-lg fa-fw fa-paper-plane"></i> Harvesting</a></li>--%>
                                <% End If%>                           
                            </ul>
                        </li>
                        <li class="nav-dropdown"><a href="#" title="Positions"><i class="fa fa-lg fa-fw fa-bank"></i> Automation</a>
                            <ul class="nav-sub">
                                <li><a href='<%: Url.Action("Garden", "Member")%>' title="Harvest"><i class="fa fa-lg fa-fw fa-leaf"></i> Harvest</a></li>                                                    
                                <% If User.Identity.Name.ToUpper = "CSQUARED20" Then%>                                                    
                                    <%--<li><a href='<%: Url.Action("SuperFly", "Member")%>' title="SuperFly"><i class="fa fa-lg fa-fw fa-paper-plane"></i> Super-Fly</a></li>--%>
                                    <%--<li><a href='<%: Url.Action("SuperFly", "Member")%>' title="SuperFly"><i class="fa fa-lg fa-fw fa-paper-plane"></i> The Strangle</a></li>--%>
                                    <%--<li><a href='<%: Url.Action("SuperFly", "Member")%>' title="SuperFly"><i class="fa fa-lg fa-fw fa-paper-plane"></i> Harvesting</a></li>--%>
                                <% End If%>                           
                            </ul>
                        </li>    
                        <% If User.Identity.Name.ToUpper = "BOSS" Then%>                                                        
                            <li><a href='<%: Url.Action("Index", "Admin")%>'><i class="fa fa-lg fa-fw fa-user"></i> Admin</a></li>
                            <%--<li><a href='<%:Url.Action("frontend", "Home")%>'><i class="fa fa-user"></i> <span>Front End</span></a></li>--%>
                            <%--<li><a href='<%:Url.Action("flot", "member")%>'><i class="fa fa-user"></i> <span>Flot</span></a></li>--%>
                        <%End If%>
                                                                
                    </ul>
                
                <%--<% Html.RenderPartial("zinfoSummary")%>--%>
            
            </nav>
        </aside>        


        <div class="page-content">           
 
            <!-- INSERT MAIN PANEL CONTENT HERE -->
          
        </div>

    </div>       

    <!--/Scripts-->
        <script src="../../Content/Member/assets/libs/jquery/jquery.min.js"></script>
        <script src="../../Content/Member/assets/bs3/js/bootstrap.min.js"></script>
        <script src="../../Content/Member/assets/plugins/jquery-navgoco/jquery.navgoco.js"></script>
        <script src="../../Content/Member/js/main.js"></script>

        <!--[if lt IE 9]>
        <script src="../../Content/Member/assets/plugins/flot/excanvas.min.js"></script>
        <![endif]-->
        <script src="../../Content/Member/assets/plugins/jquery-sparkline/jquery.sparkline.js"></script>                                                   

        <script src="../../Content/Member/assets/plugins/raphael/raphael-min.js"></script>

        <script src="../../Content/Member/assets/plugins/morris/morris.min.js"></script>
        <script src="../../Content/Member/demo/js/charts-morris.js"></script>

        <%--<script src="../../Content/Member/assets/plugins/flot/jquery.flot.js"></script>
        <script src="../../Content/Member/assets/plugins/flot/jquery.flot.categories.js"></script>
        <script src="../../Content/Member/assets/plugins/flot/jquery.flot.crosshair.js"></script>
        <script src="../../Content/Member/assets/plugins/flot/jquery.flot.pie.js"></script>
        <script src="../../Content/Member/assets/plugins/flot/jquery.flot.resize.js"></script>
        <script src="../../Content/Member/assets/plugins/flot/jquery.flot.stack.js"></script>--%>
        
    <%--<script src="../../Content/Member/demo/js/charts-flot.js"></script>--%>

</asp:Content>
