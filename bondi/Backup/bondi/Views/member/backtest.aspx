<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage(of bondi.wavesViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
blank
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">

        <aside class="sidebar sidebar-default">
            <div class="sidebar-profile">
                <img class="img-circle profile-image" src="../../content/member/demo/images/profile.jpg">

                <div class="profile-body">
                    <h4>Marlon Brice</h4>

                    <div class="sidebar-user-links">
                        <a class="btn btn-link btn-xs" href="pages-profile.html" data-placement="bottom" data-toggle="tooltip" data-original-title="Profile"><i class="fa fa-user"></i></a>
                        <a class="btn btn-link btn-xs" href="javascript:;"       data-placement="bottom" data-toggle="tooltip" data-original-title="Messages"><i class="fa fa-envelope"></i></a>
                        <a class="btn btn-link btn-xs" href="javascript:;"       data-placement="bottom" data-toggle="tooltip" data-original-title="Settings"><i class="fa fa-cog"></i></a>
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("logoff", "account")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Logout"><i class="fa fa-sign-out"></i></a>
                    </div>
                </div>
            </div>
            <nav>
                <h5 class="sidebar-header thin">Member Navigation</h5>
                <ul class="nav nav-pills nav-stacked">
                    <li><a href='<%: Url.Action("blank", "Member")%>'><i class="fa fa-lg fa-fw fa-home"></i> Dashboard</a></li>
                    <li class="nav-dropdown active open"><a href="#" title="automation"><i class="fa fa-lg fa-fw fa-gears"></i> Automation</a>
                        <ul class="nav-sub">
                            <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                            <li class="active"><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                            <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>                                
                        </ul>
                    </li>                        
                </ul>                       
            </nav>
        </aside>

        <div class="page-content">                
            
            <div class="page-heading page-heading-md">
                <h2>Backtest Bot</h2>
            </div>

            <div class="container-fluid-md">
                <div class="row">
                    <div class="col-md-7">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Backtest</h4>
                                
                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <p id="panelmsg"><%= ViewData("msg")%></p>   
                                <form class="form-inline" role="form">
                                        
                                    <div class="form-group col-sm-1">      
                                        <%= Html.DropDownListFor(Function(x) x.SelectedIndex, New SelectList(Model.AllIndexes, "HarvestKey", "Name", Model.SelectedIndex), New With {.class = "form-control form-select2", .placeHolder = "Choose an experiment...", .id = "harvestIndex", .name = "harvestIndex"})%>
                                    </div>
                                        
                                    <div class="form-group col-sm-3">                                    
                                        <%--<input type="text" class="form-control" id="symbol" name="symbol" placeholder="Enter Symbol"> --%>
                                    </div>                                           
                                        
                                    <div class="form-group col-sm-1">
                                        <input type="text" name="filedate" id="filedate" class="form-control"style="margin-left: 15px;" placeholder="YYYYMMDD">                                            
                                    </div>
                                                                               
                                    <%--<div class="form-group col-sm-4">
                                        <input type="checkbox" name="testcheck" id="testcheck" class="form-control" />   Use Yahoo Data
                                    </div>                   
                                                                                                   
                                    <div class="form-group col-sm-4">
                                        <span id="messagecenter">  </span> 
                                    </div> --%>                                       
                                                                                                                        
                                    <button type="submit" id="getData" name="getData" class="btn btn-primary col-md-2 pull-right" style="margin-right: 10px; margin-top: 5px;">Start Robot </button>
                                    <%--<button type="submit" id="stopBot" name="stopBot" class="btn btn-primary col-sm-2 pull-right" style="margin-right: 10px; margin-top: 5px;">Stop Bot </button>--%>
                                    
                                </form>
                                    
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Calendar</h4>
                                
                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">                                  
                                <%--<form class="form">--%>
                                        
                                    <div class="col-sm-4 col-md-4 col-lg-4 pull-left" >
                                        <input type="text" class="form-control" data-rel="datepicker">
                                    </div>
                                    
                                <%--</form>--%>
                                    
                            </div>
                        </div>
                    </div>
                </div>
                               
                <div class="row">
                    <div class="col-md-10">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Backtest Log</h4>
                        
                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="metric-content metric-icon">                       
                                    <%--<div id="botlist">                            
                                        <ul>
		                                        
	                                    </ul>
                                    </div> --%>     
                                    
                                    <%Html.RenderPartial("partialLogList")%> 
                                                       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

    <!--/Scripts-->  
	<%--<script src="../../content/member/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>--%>
    
    <%-- <script type="text/javascript">

         $(document).ready(function () {
             $("#getData").click(function () {

                 testcheck = document.getElementById('harvestIndex');
                 var harvestkey = testcheck.options[testcheck.selectedIndex].value;

                 $.ajax({
                     method: 'POST',
                     url: "/member/backtest",
                     data: {
                         robotdate: $("#filedate").val(),
                         robotindex: harvestkey,
                         testdata: new Date().toISOString()
                     }
                 })
                 .done(function (result) {                     
                     //var mindata = result
                     //$("#panelmsg").html(mindata);
                    // $("#panelmsg").html(result);
                 });

             });
         });

    </script>--%>
    
              
    <script>
        
        var controller = 'member';                                                                              // Name of the controller        
        var action = 'runbacktest';                                                                             // Name of the action       
        var timeout = 7200;                                                                                       //revert back to 60 for live system. This handles the timeout between calls in seconds      ONE HOUR = 3,600,000 MILISECONDS  
        var intervalID = null;                                                                                  // Holds the interval id        
        var minuteinterval = 0                                                                                  // Hold the rowID
        var rowint = 0
        var keeprunning = 0       
        var UTCoffset = { hours: -6, minutes: 0 };                                                              // Store the UTC offset here        
        var open = { hours: 8, minutes: 25 };                                                                   // Stores the market open time        
        var close = { hours: 16, minutes: 00 };                                                                 // Stores the market close time        
        var rows = 391                                                                                          // SET THE ROWS TO RUN - FULL DAY = 391 
        var harvestkey = ""
        var testcheck = ""

        $(function () {            
            btn = $('#getData');                                                                                // Replace with the button's selector
            stopbtn = $('#stopBot');                                                                            // Replace with the button's selector
           
           // var x = document.getElementById("checktest").checked;
            
            $(btn).click(function (e) {                
                e.preventDefault();                                                                             // Prevent default bubbling                                                                                                                                
                $(btn).prop('disabled', true);                                                                  // Disable the button to prevent further clicks  


                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                getResults();                                                                                   // Get first result
                rowint = rowint + 1;                                                                            // Increment row interval to set the correct row id
                $(btn).prop('disabled', false);
                //intervalID = setInterval(function () {
                    //getResults();
                    //rowint = rowint + 1;
                    //}, timeout * 1000);                                                                         // Get results after each timeout                

            });
            
            //$(stopbtn).click(function (e) {
            //    clearInterval(intervalID);
            //});

        });

        function getResults() {

            //alert(harvestkey);

            if (testcheck.checked) {

                $.ajax({
                    method: 'POST',
                    url: "/" + controller + "/" + "yahoodata",                
                    data: {
                        robotsymbol: $("#symbol").val(),
                        robotdate: $("#filedate").val(),
                        robotindex: harvestkey,
                        rowid: rowint,                        
                        testdata: new Date().toISOString()                    
                    }
                })

                .done(function (result) {
                    // Add the result from the controller action to the page 

                    if (rowint == rows) {
                        //alert("hit");
                        clearInterval(intervalID);
                        $(btn).prop('disabled', false);
                        $("filedate").val() == "";
                    };

                    var mindata = result;
                    $("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                    document.getElementById('messagecenter').innerHTML == result
                })

            } else {
                
                $.ajax({
                    method: 'POST',
                    url: "/" + controller + "/" + action,                
                    data: {
                        robotsymbol: $("#symbol").val(),
                        robotdate: $("#filedate").val(),
                        robotindex: harvestkey,
                        rowid: rowint,                        
                        testdata: new Date().toISOString()                    
                    }
                })

                .done(function (result) {
                    // Add the result from the controller action to the page 
                    
                    if (rowint == rows) {
                        //alert("hit");
                        clearInterval(intervalID);
                        $(btn).prop('disabled', false);
                        
                    };
                    
                    var mindata = result;
                    $("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "

                })

            }
           
        }

    </script>

    <script src="../../content/member/assets/libs/jquery/jquery.min.js"></script>
    <script src="../../content/member/assets/bs3/js/bootstrap.min.js"></script>
    <script src="../../content/member/assets/plugins/jquery-navgoco/jquery.navgoco.js"></script>
    <script src="../../content/member/js/main.js"></script>

    <!--[if lt IE 9]>
    <script src="assets/plugins/flot/excanvas.min.js"></script>
    <![endif]-->
    <script src="../../content/member/assets/plugins/jquery-sparkline/jquery.sparkline.js"></script>
    <script src="../../content/member/demo/js/demo.js"></script>

    <script src="../../content/member/assets/libs/jquery-ui/minified/jquery-ui.min.js"></script>
    <script src="../../content/member/assets/plugins/jquery-select2/select2.min.js"></script>
    <script src="../../content/member/assets/plugins/jquery-selectboxit/javascripts/jquery.selectBoxIt.min.js"></script>
    <%--<script src="../../content/member/assets/plugins/jquery-chosen/chosen.jquery.min.js"></script>--%>
    <%--<script src="../../content/member/assets/plugins/bootstrap-switch/js/bootstrap-switch.min.js"></script>--%>
    <%--<script src="../../content/member/assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput.min.js"></script>--%>
    <script src="../../content/member/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <%--<script src="../../content/member/assets/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>--%>
    <%--<script src="../../content/member/assets/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js"></script>--%>
    <%--<script src="../../content/member/demo/js/forms-advanced-components.js"></script>--%>
    <script src="../../content/member/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>



    <!--/Scripts-->




</asp:Content>
