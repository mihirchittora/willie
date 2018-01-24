<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
        
        <!-- BEGIN SIDEBAR -->
        <div class="page-sidebar-wrapper">
            <!-- END SIDEBAR -->
            <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
            <!-- DOC: Change data-auto-speed="200" to adjust the sub menu slide up/down speed -->
            <div class="page-sidebar navbar-collapse collapse">

                <ul class="page-sidebar-menu  page-header-fixed page-sidebar-menu-light " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
                        <!-- DOC: To remove the sidebar toggler from the sidebar you just need to completely remove the below "sidebar-toggler-wrapper" LI element -->
                        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                        <%-- <li class="sidebar-toggler-wrapper hide">
                            <div class="sidebar-toggler">
                                <span></span>
                            </div>
                        </li>--%>
                        <!-- END SIDEBAR TOGGLER BUTTON -->
                        <!-- DOC: To remove the search box from the sidebar you just need to completely remove the below "sidebar-search-wrapper" LI element -->
                        <li class="sidebar-search-wrapper">
                            <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
                            <!-- DOC: Apply "sidebar-search-bordered" class the below search form to have bordered search box -->
                            <!-- DOC: Apply "sidebar-search-bordered sidebar-search-solid" class the below search form to have bordered & solid search box -->
                            <form class="sidebar-search  " action="page_general_search_3.html" method="POST">  <!-- NEED TO BUILD THIS OUT / HOW WOULD I USE THIS??  -->
                                <a href="javascript:;" class="remove"><i class="icon-close"></i></a>
                                <div class="input-group">
                                    <input style="color: #FAFAFA;" type="text" class="form-control" placeholder="Search...">
                                    <span class="input-group-btn">
                                        <a href="javascript:;" class="btn submit">
                                            <i style="color: #FAFAFA;" class="icon-magnifier"></i>
                                        </a>
                                    </span>
                                </div>
                            </form>
                            <!-- END RESPONSIVE QUICK SEARCH FORM -->
                        </li>

                        <li class="nav-item active">
                            <a href='<%:Url.Action("blank", "member")%>' class="nav-link nav-toggle">
                                <i class="icon-home"></i>
                                <span class="title">Dashboard</span>
                                <span class="selected"></span>                                    
                            </a>
                        </li>
                            
                        <li class="heading">
                            <h3 class="uppercase">Learning The System</h3>
                        </li>
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-graduation"></i><span class="title"> Learning Activity</span></a></li>
                        
                        <li class="heading">
                            <h3 class="uppercase">Gardening System</h3>
                        </li>
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="fa fa-leaf"></i><span class="title"> Garden Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item">
                                    <a href='<%:Url.Action("index", "garden")%>' class="nav-link ">
                                        <span class="title"> Current Positions</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>                                                              
                            </ul>
                        </li>

                        <li class="heading">
                            <h3 class="uppercase">Harvest System</h3>
                        </li>                        
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-bar-chart"></i><span class="title"> Harvest Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item">
                                    <a href='<%:Url.Action("dataset", "member")%>' class="nav-link ">
                                        <span class="title"> Get Dataset</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>
                                <li class="nav-item  ">
                                    <a href="form_controls_md.html" class="nav-link ">
                                        <span class="title"> Material Design</span>
                                    </a>
                                </li>                               
                            </ul>
                        </li>

                        <li class="heading">
                            <h3 class="uppercase">Automated Trading</h3>
                        </li>                        
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-bar-chart"></i><span class="title"> Automated Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item">
                                    <a href='<%:Url.Action("dataset", "member")%>' class="nav-link ">
                                        <span class="title"> Get Dataset</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>
                                <li class="nav-item  ">
                                    <a href="form_controls_md.html" class="nav-link ">
                                        <span class="title"> Material Design</span>
                                    </a>
                                </li>                               
                            </ul>
                        </li>
                        <li class="heading">
                            <h3 class="uppercase">Member Settings</h3>
                        </li>
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-settings"></i><span class="title"> Member Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item">
                                    <a href='<%:Url.Action("profile", "account")%>' class="nav-link ">
                                        <span class="title"> Profile</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href='<%:Url.Action("settings", "account")%>' class="nav-link ">
                                        <span class="title"> Settings</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>   
                                <li class="nav-item">
                                    <a href='<%:Url.Action("billing", "account")%>' class="nav-link ">
                                        <span class="title"> Account</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>                         
                            </ul>
                        </li>

                   <%-- <% If Page.User.Identity.Name = "csquared20" Then%>--%>

                        <li class="heading">
                            <h3 class="uppercase">Administrative Settings</h3>
                        </li>
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-wrench"></i><span class="title"> Administrative Activity</span></a></li>

                    <%--<% End If%>--%>


                    </ul>
                    
            </div>
        </div>
        <!-- /END SIDEBAR -->
        
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
        
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
            
                <!-- BEGIN PAGE BAR -->
                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li><h5 class="page-title"><i class="fa fa-circle"></i> Garden Dashboard </h5></li>                   
                    </ul>
                    <div class="page-toolbar">
                        <div id="dashboard-report-range" class="pull-right tooltips btn btn-sm" data-container="body" data-placement="bottom" data-original-title="Change dashboard date range">
                            <i class="icon-calendar"></i>&nbsp;
                            <span class="thin uppercase hidden-xs"></span>&nbsp;
                            <i class="fa fa-angle-down"></i>
                        </div>
                    </div>
                </div>
                <!-- END PAGE BAR -->
           
                   <%-- <div class="row" style="margin-top: 25px;">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="dashboard-stat2 ">
                                    <div class="display">
                                        <div class="number">
                                            <h3 class="font-green-sharp">
                                                <span data-counter="counterup" data-value="7800">0</span>
                                                <small class="font-green-sharp">$</small>
                                            </h3>
                                            <small>TOTAL PROFIT</small>
                                        </div>
                                        <div class="icon">
                                            <i class="icon-pie-chart"></i>
                                        </div>
                                    </div>
                                    <div class="progress-info">
                                        <div class="progress">
                                            <span style="width: 76%;" class="progress-bar progress-bar-success green-sharp">
                                                <span class="sr-only">76% progress</span>
                                            </span>
                                        </div>
                                        <div class="status">
                                            <div class="status-title"> progress </div>
                                            <div class="status-number"> 76% </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>--%>
                <br />
               
                
                <!-- BEGIN Portlet PORTLET-->
                <div class="portlet box dark">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-plus"></i>Add a Position </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"> </a>                            
                            <a href="javascript:;" class="remove"> </a>
                        </div>
                    </div>
                    <div class="portlet-body">  <!-- to hide add display-hide after portlet-body -->
                         
                         <div class="form-body">

                            <%--<% Using Html.BeginForm("addposition", "garden")%>--%>

                                <form class="form-inline" role="form">
                                                                
                                    <div class="form-group">                                    
                                        <div class="input-icon date">
                                            <i class="fa fa-calendar"></i>
                                            <input class="form-control" id="tradedate" value=<%: DateTime.Parse(Now()).ToLocalTime()%> placeholder=<%: Html.Encode(String.Format("{0:d}", DateTime.Parse(Now()).ToLocalTime()))%>></div>
                                    </div>
                                
                                    <div class="form-group">
                                        <div class="input-icon">
                                            <i class="fa fa-check-circle"></i><input style="width: 700px;" type="text" class="form-control" id="tradedata" placeholder="Paste trade details here."> 
                                        </div>
                                    </div>
                               
                                    <button type="submit" id="submitButton" class="btn btn-default dark">Add Trade</button>

                                </form>

                           <%-- <%End Using%>--%>

                        </div>
                    </div>
                <!-- END Portlet PORTLET-->

            </div>
            <!-- /END CONTENT BODY -->

    </>
        <!-- /END CONTENT -->
     </div>
    <!-- /END CONTAINER -->


    <script type="text/javascript">

        $(document).ready(function () {
            $("#submitButton").click(function () {

                //alert("made it")
                var tradedate = $("#tradedate").val()
                var tradedata = $("#tradedata").val()

                var data = {
                    "tradedate": $("#tradedate").val(),
                    "tradedata": $("#tradedata").val()
                };
                
                $.ajax({
                    url: "/garden/addposition",
                    type: "POST",
                    data: JSON.stringify(data),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    success: function (result) {

                        $("#message").html(result);
                        $("#tradedate").val("")
                        $("#tradedata").val("");

                        if (result = "Position successfully added.") {
                            // This is where the call to refresh the partial would be called.
                            //alert(result)
                            // Update the trade Count Chart - this should be the only one needed to update
                        }

                    },
                    error: function (result) {
                        //alert(result)
                        //$('#message').text("Error:" + error);
                        $("#message").html("Please enter the Date and Position data.");
                    }
                });
            });
        });

    </script>


        <!-- BEGIN CORE PLUGINS -->
        <%--<script src="../../content/member/assets/global/plugins/jquery.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>--%>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <%--<script src="../../content/member/assets/global/plugins/moment.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js" type="text/javascript"></script>--%>
        <script src="../../content/member/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
        <%--<script src="../../content/member/assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/global/plugins/clockface/js/clockface.js" type="text/javascript"></script>--%>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <%--<script src="../../content/member/assets/global/scripts/app.min.js" type="text/javascript"></script>--%>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <%--<script src="../../content/member/assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>--%>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <%--<script src="../../content/member/assets/layouts/layout/scripts/layout.min.js" type="text/javascript"></script>--%>
        <script src="..../content/member//assets/layouts/layout/scripts/demo.min.js" type="text/javascript"></script>
        <%--<script src="../../content/member/assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>--%>
        <%--<script src="../../content/member/assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>--%>
        <!-- END THEME LAYOUT SCRIPTS -->
        

</asp:Content>
