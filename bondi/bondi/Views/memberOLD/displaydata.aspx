<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="~/Scripts/jquery-2.2.3.min.js"></script>
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
                        <li><a href='<%: Url.Action("Index", "Member")%>'><i class="fa fa-lg fa-fw fa-home"></i> Dashboard</a></li>                                                          
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
                        <li class="nav-dropdown active open"><a href="#" title="Positions"><i class="fa fa-lg fa-fw fa-bank"></i> Automation</a>
                            <ul class="nav-sub">
                                <li><a href='<%: Url.Action("automate", "Member")%>' title="Harvest"><i class="fa fa-lg fa-fw fa-leaf"></i> Harvest Robot</a></li>                                                    
                                <li><a href='<%: Url.Action("displaydata", "Member", New With {.sym = "GDX", .wid = 0.25, .pd = Today.Date})%>' title="Harvest"><i class="fa fa-lg fa-fw fa-leaf"></i> View Data</a></li>
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
            
            <% Html.RenderPartial("_viewfirstrow")%> <br />

            <% Html.RenderPartial("_list")%>
           
        </div>

    </div>       


    <!--/Scripts-->
    
   <%-- <script>
        // Name of the controller
        var controller = 'home';
        var date = new Date();
        // Name of the action
        var action = 'test';
        // This handles the timeout between calls
        var timeout = 60;
        var step;


        

        $(function () {
            // Replace with the button's selector
            btn = $('#getData');
            inp = $('#pos');

            $(btn).click(function (e) {
                // Prevent default bubbling
                e.preventDefault();

                // Disable the button to prevent further clicks
                $(this).prop('disabled', true);
                $(inp).prop('disabled', true);

                // Get first result
                getResults();


                // Get results after each timeout
                intervalID = setInterval(function () {
                    getResults();
                }, timeout * 1000);

            });
        });

        function getResults() {
            //alert("made get results" + "/" + controller + "/" + action);
            var input = document.getElementById('pos').value;
            //alert(input)

            $.ajax({
                url: '<%= Url.Action("startbot", "member")%>',
                type: 'GET',
               
                data: "pos=" + input, //+ new Date().toISOString(),        //If I need to pass data to the controller this is where that would need to occur.
                
                success: function (data) {
                    // if (data = "END") {
                    //   $(btn).prop('disabled', false);
                    //   return;
                    // }

                    var mindata = data
                    // alert(data)

                    var date = new Date();
                    $("#botlist ul").append('<li>' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                    // $(btn).prop('disabled', false);
                },

            })

        }
    </script>--%>
    
        <script src="../../Content/Member/assets/libs/jquery/jquery.min.js"></script>
        <script src="../../Content/Member/assets/bs3/js/bootstrap.min.js"></script>
        <script src="../../Content/Member/assets/plugins/jquery-navgoco/jquery.navgoco.js"></script>
        <script src="../../Content/Member/js/main.js"></script>

        <!--[if lt IE 9]>
        <script src="../../Content/Member/assets/plugins/flot/excanvas.min.js"></script>
        <![endif]-->
        <script src="../../Content/Member/assets/plugins/jquery-sparkline/jquery.sparkline.js"></script>
        <script src="../../Content/Member/demo/js/demo.js"></script>

        <script src="../../Content/Member/assets/libs/jquery-ui/minified/jquery-ui.min.js"></script>
        <script src="../../Content/Member/assets/plugins/jquery-select2/select2.min.js"></script>
        <script src="../../Content/Member/assets/plugins/jquery-selectboxit/javascripts/jquery.selectBoxIt.min.js"></script>
        <script src="../../Content/Member/assets/plugins/jquery-chosen/chosen.jquery.min.js"></script>
        <script src="../../Content/Member/assets/plugins/bootstrap-switch/js/bootstrap-switch.min.js"></script>
        <script src="../../Content/Member/assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput.min.js"></script>
        <script src="../../Content/Member/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
        <script src="../../Content/Member/assets/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
        <script src="../../Content/Member/assets/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js"></script>
        <script src="../../Content/Member/demo/js/forms-advanced-components.js"></script> 

</asp:Content>
