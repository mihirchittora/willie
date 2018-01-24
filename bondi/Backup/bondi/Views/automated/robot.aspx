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
                        <li class="nav-item  "><a href="javascript:;" class="nav-link nav-toggle"><i class="fa fa-gears"></i><span class="title"> Harvest Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item">
                                    <a href='<%:Url.Action("index", "garden")%>' class="nav-link ">
                                        <span class="title"> Current Positions</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>
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
                            <h3 class="uppercase">Automated Trading</h3>
                        </li>                        
                        <li class="nav-item  active open"><a href="javascript:;" class="nav-link nav-toggle"><i class="icon-bar-chart"></i><span class="title"> Automated Activity</span></a>
                            <ul class="sub-menu">
                                <li class="nav-item active selected">
                                    <a href='<%:Url.Action("index", "automated")%>' class="nav-link ">
                                        <span class="title"> Trading Bot</span>
                                        <span class="selected"></span>                                        
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href='<%:Url.Action("dataset", "member")%>' class="nav-link ">
                                        <span class="title"> Get Dataset</span>
                                        <%--<span class="selected"></span>--%>                                        
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
                <div class="page-bar" style="margin-bottom: 5px;">
                    <ul class="page-breadcrumb">
                        <li><h5 class="page-title"><i class="fa fa-spinner"></i> Trading Robot </h5></li>                   
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
           
                <!-- START CONTENT BODY -->                 
                
                <!-- BEGIN PORTLET-->                
                <div class="portlet box dark">
                    <!-- BEGIN PORTLET TITLE -->
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-gears"></i> Robot Controls </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"> </a>                            
                            <a href="javascript:;" class="remove"> </a>
                        </div>
                    </div>
                    <!-- / END PORTLET TITTLE -->
                    <!-- BEGIN PORTLET BODY -->
                    <div class="portlet-body">  <!-- to hide add display-hide after portlet-body -->                         
                        <div class="form-body">
                            <form class="form-inline" role="form">
                                <button type="submit" id="startrobot" name="startrobot" class="btn btn-default blue-hoki">Start Robot</button> 
                                
                                <%--<div class="form-group col-lg-2">                                    
                                    <div class=" actions">                                        
                                        <input type="checkbox" id="checkbox"> Text File?
                                    </div>                                                                                                                       
                                </div>  --%>                                                                                             
                            </form>
                        </div>  
                    </div>  
                    <!-- /END PORTLET BODY -->                                  
                </div>
                <!-- END PORTLET--> 
                  
                <!-- BEGIN PORTLET-->                                       
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-share font-dark"></i>
                            <span class="caption-subject font-dark bold uppercase">Robot Results</span>
                        </div>                                    
                    </div>
                                
                    <div class="portlet-body" style="height: 100%;">                                                                       
                                    
                        <div class="row">

                            <div class="metric-content metric-icon">                       
                                <div id="botlist">                            
                                    <ul>
		  
	                                </ul>
                                </div>                         
                            </div>

                        </div> <br />        
                                                                                                                               
                    </div>
                </div>
                <!-- /END PORTLET-->
            <!-- /END CONTENT BODY -->

        </div>
            <!-- /END CONTENT Body -->

        </div>
        <!-- /END CONTENT -->

        <script>

            // script definitions
            var controller = 'automated';                                                       // Name of the controller                
            var action = 'backdata';                                                            // Name of the action                
            var timeout = 02;                                                                   // This handles the timeout between calls in seconds                        
            var intervalID = null;                                                              // Holds the interval id                
            var minuteinterval = 0                                                              // Hold the rowID
            var rowint = 0
            var keeprunning = 0
            var UTCoffset = { hours: -6, minutes: 0 };                                          // Store the UTC offset here                
            var open = { hours: 8, minutes: 25 };                                               // Stores the market open time                
            var close = { hours: 16, minutes: 00 };                                             // Stores the market close time

            $(function () {
                
                // script operation initiated by button click
                btn = $('#startrobot');                                                             // Sets the value of BTN to the html button
                
                $(btn).click(function (e) {                                                         // Click function for the button                    
                    e.preventDefault();                                                             // Prevent default bubbling                    
                    $(btn).prop('disabled', true);                                                  // Disable the button to prevent further clicks
                    
                    getResults();                                                                   // Get first result
                    rowint = rowint + 1;

                    // Get results after each timeout
                    intervalID = setInterval(function () {
                        getResults();
                        rowint = rowint + 1;
                    }, timeout * 1000);
                });
            });

            function getResults() {
                
                $.ajax({
                    method: 'POST',
                    url: "/" + controller + "/" + action,
                    
                    data: {
                        robotsymbol: "VXX",                 //$("#robotsymbol").val(),
                        robotwidth: 0.25,                   //$("#robotwidth").val(),
                        rowid: rowint,
                        //live: document.getElementById("checktest").checked,
                        testdata: new Date().toISOString()
                    }
                })

                .done(function (result) {
                    // Add the result from the controller action to the page                
                    var mindata = result
                   
                    $("#botlist ul").append('<li style="list-style-type: none;">' + "   " + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "

                    //if (mindata = "end") {
                    //    $(btn).prop('disabled', false);
                    //    alert(mindata)
                    //    //return;
                    //}

                    //if (keeprunning = 0) {
                    //    alert(keeprunning)
                    //}
                    //if (keeprunning = 0) {
                    //    $(btn).prop('disabled', false);
                    //    alert("done")
                    //    return;
                    //    }

                    // $(btn).prop('disabled', false); 
                })

               // function exitapp() {
               //     return;
              //  }

            }

            //function getNowMinutes() {
            //    var now = new Date();
            //    return (now.getUTCHours() + UTCoffset.hours) * 60 + (now.getUTCMinutes() + UTCoffset.minutes);
            //}


        </script>

</asp:Content>
