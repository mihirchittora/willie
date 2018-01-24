<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage(of bondi.wavesViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
IB API Test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <aside class="sidebar sidebar-default">
            <div class="sidebar-profile">
                <img class="img-circle profile-image" src="../../content/member/demo/images/profile.jpg">

                <div class="profile-body">
                    <h4> User Name</h4>

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
                            <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Experiment Settings</a></li>
                            <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                            <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                            <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                            <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                            <li><a href='<%: Url.Action("blackscholes", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Black Scholes</a></li>
                            <li class="active"><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> IB API Test</a></li>
                           
                        </ul>
                    </li>                        
                </ul>                       
            </nav>
        </aside>

        <div class="page-content">
            <div class="page-subheading page-subheading-md">
                <ol class="breadcrumb"><li class="active"><a href="javascript:;"> IB API Test</a></li></ol>
            </div>
               
            <div class="container-fluid-md">
               
                <div class="row">
                    <%--<div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Initiate Willie</h4>
                                <p style="float: left; padding-left: 10px; font-weight: normal;" id="connectStatus"></p>
                                <p style="float: left; padding-left: 10px; font-weight: normal;" id="tickprice"></p>
                                <p>Select and enter settings to start Willie</p>
                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                                <br />
                            </div>
                            <div class="panel-body">
                                <form class="form-inline" role="form">
                                    <div class="form-group">
                                        <label class="sr-only" for="expsymbol">Enter Symbol</label>
                                        <%--<input type="text" class="form-control" id="expsymbol" placeholder="AAPL">
                                    </div>
                                                                
                                    <button type="submit" id="getDataAPI" name="getDataAPI" class="btn btn-primary">Start Willie</button>
                                </form>
                            </div>
                        </div>
                    </div>--%>

                    <div class="col-md-8">                
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">Willie</h4>
                                    <p style="float: left; padding-left: 10px; font-weight: normal;" >Select strategy to start the process.</p>
                                    <%--<p style="float: left; padding-left: 10px; font-weight: normal;" id="tickprice"></p>--%>                                                                                                      
                                </div>
                                <br />
                                <div class="panel-body">                                                              
                                    <div class="form-inline">
                                        <div class="form-group"> 
                                            <%= Html.DropDownListFor(Function(x) x.SelectedIndex, New SelectList(Model.AllIndexes, "HarvestKey", "Name", Model.SelectedIndex), New With {.class = "form-control form-select2", .placeHolder = "Choose an experiment...", .id = "harvestIndex", .name = "harvestIndex"})%>
                                            <%--<input type="text"class="form-control" id="expsymbol" placeholder="AAPL">--%>
                                        </div>
                                        <button type="submit"id="getDataAPI" name="getDataAPI" class="btn btn-primary">START</button>
                                        
                                        <input type="text"class="form-control" id="primebuy" placeholder="00.00">
                                        <%--<button type="submit"id="apiOrder" name="apiOrder" class="btn btn-primary">ORDER</button>--%>
                                        <%--<button type="submit"id="apiHistorical" name="apiHistorical" class="btn btn-primary">History</button>--%>
                                        <%--<button type="submit"id="apiOption" name="apiOption" class="btn btn-primary">OPTION</button>--%>
                                        <%--<button type="submit"id="apiOrderStatus" name="apiOrderStatus" class="btn btn-primary">ORDER STATUS</button>--%>
                                        <%--<button type="submit"id="apiStarting" name="apiStarting" class="btn btn-primary">SHELL</button>--%>
                                        <%--<button type="submit"id="apiPosition" name="apiPosition" class="btn btn-primary">PORTFOLIO</button> --%>                                                                                       
                                    </div>
                                                                                                      
                                </div>                        
                                <%--<div class="form-group text-right" style="padding-bottom: 5px; padding-right: 5px;">                                    
                                    <button type="submit" id="connectAPI" name="connectAPI" class="btn btn-primary">Connect</button>
                                    <button type="submit" id="disconnectAPI" name="disconnectAPI" class="btn btn-danger">Disconnect</button>
                                </div>--%>
                                                      
                            </div>                
                        </div>                    
                </div>  
                
                <div class="row">                    
                    <div class="col-md-10">                
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Robot Results</h4>  
                                
                                <p style="float: left; padding-left: 10px; font-weight: normal;" id="connectStatus"></p>
                                <p style="float: left; padding-left: 10px; font-weight: normal;" id="tickprice"></p>
                                                                                                
                            </div>
                            <div class="panel-body">                                  
                                <div id="botlist">        
                                    <%--<h5>Output</h5>--%><br />
                                    <ul>
		  
	                                </ul>
                                </div>                      
                            </div>                
                        </div>                    
                    </div>               
                </div>

            </div>
        </div>

    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#apiStarting").click(function () {

                $.ajax({
                    method: 'POST',
                    url: "/member/apiStarting",
                    data: {
                        testdata: new Date().toISOString()
                    }
                })
                .done(function (result) {
                    $("#connectStatus").html(result);
                });

            });
        });

    </script>                                                                                                                               <%--// INITIAL BLANK SCRIPT TO GET YOU TO A FUNCTION IN THE CONTROLLER--%>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#apiOrder").click(function () {                

                //alert("here");

                $.ajax({
                    method: 'POST',
                    url: "/member/apiOrder",
                    data: {                                                
                        symbol: $("#expsymbol").val(),
                        rowid: 0,
                        testdata: new Date().toISOString()
                    }
                })
                .done(function (result) {                 
                    $("#connectStatus").html(result);
                    //var mindata = result;
                    //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                    
                    $(btn).prop('disabled', false);
                });
                    
            });
        });
        
    </script>                                                                                                                   <%--// CALL FUNCTION TO PLACE AN ORDER IN TRADER WORK STATION--%>

    <script type="text/javascript">

         $(document).ready(function () {
             $("#apiOrderStatus").click(function () {

                 $.ajax({
                     method: 'POST',
                     url: "/member/apiOrderStatus",
                     data: {
                         testdata: new Date().toISOString()
                     }
                 })
                 .done(function (result) {
                     $("#connectStatus").html(result);
                 });

             });
         });

    </script>                                                                                                                  <%--// CALL FUNCTION TO CHECK ORDER STATUSES IN TRADER WORK STATION--%>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#apiPosition").click(function () {
                
                $.ajax({
                    method: 'POST',
                    url: "/member/apiPosition",
                    data: {
                        testdata: new Date().toISOString()
                    }
                })
                .done(function (result) {
                    $("#connectStatus").html(result);
                });

            });
        });

    </script>      

    <script type="text/javascript">

        $(document).ready(function () {
            $("#apiOption").click(function () {

                $.ajax({
                    method: 'POST',
                    url: "/member/apiOption",
                    data: {
                        testdata: new Date().toISOString()
                    }
                })
                .done(function (result) {
                    $("#connectStatus").html(result);
                });

            });
        });

    </script>                                                                                                                   <%--// CALL FUNCTION TO CONNECT TO TRADER WORK STATION--%>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#disconnectAPI").click(function () {

                $.ajax({
                    method: 'POST',
                    url: "/member/disconnectAPI",
                    data: {
                        testdata: new Date().toISOString()
                    }
                })
                .done(function (result) {
                    $("#connectStatus").html(result);
                });

            });
        });

    </script>                                                                                                                   <%--// CALL FUNCTION TO DISCONNECT FROM TRADER WORK STATION--%>  

    <script type="text/javascript">

            $(document).ready(function () {
                $("#apiHistorical").click(function () {

                    $.ajax({
                        method: 'POST',
                        url: "/member/apiHistorical",
                        data: {
                            testdata: new Date().toISOString()
                        }
                    })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                    });

                });
            });

    </script>                                                                                                                   <%--// CALL FUNCTION THAT WILL PULL HISTORICAL DATA FOR SYMBOL--%>

    <%-- <script type="text/javascript">
        
         //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

         // SET THE VARIABLES USED IN THE SCRIPT
         var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
         var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
         var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

         $(document).ready(function () {
             $("#getDataAPI").click(function () {
                 $("#connectStatus").html("Working");
                 $.ajax({
                     method: 'POST',
                     url: "/member/getDATAAPI",

                     data: {
                         testdata: new Date().toISOString(),
                         symbol: $("#expsymbol").val()
                     }
                 })
                 .done(function (result) {
                     $("#connectStatus").html(result);
                 });

             });
         });

    </script>--%>

    <script>

        var controller = 'member';                                                                              // Name of the controller        
        var action = 'runRobot'                                                                                 // Name of the action //'apiOrderStatus';  'apiOrder'; 
        var timeout = 60;                                                                                       // revert back to 60 for live system. This handles the timeout between calls in seconds      ONE HOUR = 3,600,000 MILISECONDS  
        var intervalID = null;                                                                                  // Holds the interval id        
        var minuteinterval = 0                                                                                  // Hold the rowID
        var rowint = 0
        var keeprunning = 0        
        var rows = 1                                                                                          // SET THE ROWS TO RUN - FULL DAY = 391         

        $(function () {
            btn = $('#getDataAPI');                                                                             // Replace with the button's selector
            
            $(btn).click(function (e) {
                e.preventDefault();                                                                             // Prevent default bubbling                                                                                                                                
                $(btn).prop('disabled', true);                                                                  // Disable the button to prevent further clicks  

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                getResults();                                                                                   // Get first result
                rowint = rowint + 1;                                                                            // Increment row interval to set the correct row id
               // $(btn).prop('disabled', false);

                intervalID = setInterval(function () {
                getResults();
                rowint = rowint + 1;
                }, timeout * 1000);                                                                             // Get results after each timeout                

            });           
        });

        function getResults() {
            $.ajax({
                method: 'POST',
                url: "/" + controller + "/" + action,
                data: {
                    primebuy: $("#primebuy").val(),
                    robotindex: harvestkey,
                    rowid: rowint,
                    testdata: new Date().toISOString()
                        }
                    })

            .done(function (result) {
                // Add the result from the controller action to the page 
                if (rowint == rows) {                        
                    clearInterval(intervalID);
                    $(btn).prop('disabled', false);
                    $("filedate").val() == "";
                };

                var mindata = result;
                $("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                //document.getElementById('messagecenter').innerHTML == result
                })
                            
            }
       
    </script>



</asp:Content>
