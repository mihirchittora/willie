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

                        <li class="nav-item">
                            <a href='<%:Url.Action("blank", "member")%>' class="nav-link nav-toggle">
                                <i class="icon-home"></i>
                                <span class="title">Dashboard</span>                                                                    
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
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-bar-chart"></i><span class="title"> Harvest Activity</span><span class="selected"></span></a>
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
                        <li class="nav-item active open">
                            <a href='<%:Url.Action("blank", "member")%>' class="nav-link nav-toggle">
                                <i class="icon-home"></i>
                                <span class="title">Harvest Activity</span>
                                <span class="selected"></span>                                    
                            </a>
                        </li>                      
                        <li class="nav-item active open"><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-bar-chart"></i><span class="title"> Harvest Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item">
                                    <a href='<%:Url.Action("index", "harvest")%>' class="nav-link ">
                                        <span class="title"> Trading Bot</span>
                                        <span></span>                                        
                                    </a>
                                </li>
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
                        <li><h5 class="page-title"><i class="fa fa-circle"></i> Harvest Index </h5></li>                   
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
           
                    <div class="row" style="margin-top: 25px;">
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
                    </div>
                


            </div>
            <!-- /END CONTENT BODY -->

    </div>
        <!-- /END CONTENT -->
     </div>
    <!-- /END CONTAINER -->

</asp:Content>
