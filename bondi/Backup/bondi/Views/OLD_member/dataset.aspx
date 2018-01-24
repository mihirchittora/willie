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

                        <li class="nav-item ">
                            <a href='<%:Url.Action("blank", "member")%>' class="nav-link nav-toggle">
                                <i class="icon-home"></i>
                                <span class="title">Dashboard</span>
                                <span class="selected"></span>                                    
                            </a>
                        </li>
                            <li class="heading">
                            <h3 class="uppercase">Automated Trading</h3>
                        </li>
                        
                        <li class="nav-item  active open">
                            <a href="javascript:;" class="nav-link nav-toggle">
                                <i class="icon-settings"></i>
                                <span class="title">Harvest Bot</span>
                                <span class="selected"></span>
                                <span class="arrow open"></span>
                            </a>
                            <ul class="sub-menu">
                                <li class="nav-item active">
                                    <a href='<%:Url.Action("dataset", "member")%>' class="nav-link ">
                                        <span class="title" style="color: #fff;">Get Dataset</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>
                                <li class="nav-item  ">
                                    <a href="form_controls_md.html" class="nav-link ">
                                        <span class="title">Material Design</span>
                                    </a>
                                </li>                               
                            </ul>
                        </li>
   
                    </ul>

            </div>
        </div>
        <!-- /END SIDEBAR -->
        
        <!-- BEGIN CONTENT WRAPPER -->
        <div class="page-content-wrapper">
        
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
            
                <!-- BEGIN PAGE BAR -->
                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li><h5 class="page-title"><i class="fa fa-circle"></i> Get Dataset </h5></li>                   
                    </ul>
                    <div class="page-toolbar">
                        <div id="Div1" class="pull-right tooltips btn btn-sm" data-container="body" data-placement="bottom" data-original-title="Change dashboard date range">
                            <i class="icon-calendar"></i>&nbsp;
                            <span class="thin uppercase hidden-xs"></span>&nbsp;
                            <i class="fa fa-angle-down"></i>
                        </div>
                    </div>
                </div>
                <!-- END PAGE BAR -->
           
                <!-- CONTENT GOES HERE -->

                <% Using Html.BeginForm("CreateText", "member")%>
                    <div class="row" style="margin-top: 20px;">
                    <div class="col-md-6" style="height: 100%;">
                        
                        <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-share font-dark"></i>
                                        <span class="caption-subject font-dark bold uppercase">Get Dataset</span>
                                    </div>                                    
                                </div>
                                
                                <div class="portlet-body" style="height: 150px;">                                                                       
                                    
                                    <div class="row">

                                        <div class="col-md-2">
                                            <input type="text" name="symbol" class="form-control" id="symbol" placeholder="Symbol"> 
                                        </div> 

                                    </div> <br />
                                        
                                    <div class="row">

                                        <div class="col-md-2">
                                            <input type="text" name="filedate" class="form-control" id="filedate" placeholder="mm/dd/yyyy"> 
                                        </div> 

                                    </div> <br />                                               
                                           
                                    <div class="row">

                                        <div class="col-md-2">
                                            <button type="submit" class="btn blue">Pull Data</button> 
                                        </div> 

                                    </div> <br />        
                                                                                                                               
                                </div>
                            </div>
                            <!-- END SAMPLE FORM PORTLET-->

                    </div>                                                
                </div>
                <% End Using%>
                
                <!-- /END CONTENT GOES HERE -->

            </div>
            <!-- /END CONTENT BODY -->
        </div>
        <!-- /END CONTENT WRAPPER -->



    <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../../content/member/assets/global/plugins/moment.min.js" type="text/javascript"></script>
        <script src="../../content/member/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js" type="text/javascript"></script>
        <script src="../../content/member/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
        <script src="../../content/member/assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
        <script src="../../content/member/assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
        <script src="../../content/member/assets/global/plugins/clockface/js/clockface.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
            <script src="../../content/member/assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->

    <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../../content/member/assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->

</asp:Content>
