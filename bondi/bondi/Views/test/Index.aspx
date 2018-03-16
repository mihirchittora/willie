<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage(of bondi.wavesViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Development Environment
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">                                                                                                                     <%-- PAGE-WRAPPER START --%>

        <aside class="sidebar sidebar-default">                                                         <%-- ASIDE-WRAPPER END --%>
            <div class="sidebar-profile">                                                               <%-- PROFILE-WRAPPER START --%>
                <img class="img-circle profile-image" src="../../img/profile.jpg">
                <div class="profile-body">                                                              <%-- PROFILE BOBY-WRAPPER START --%>
                    <h4> <%= Page.User.Identity.Name %></h4>
                    <div class="sidebar-user-links">                                                    <%-- SIDEBAR-WRAPPER END --%>
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("profile", "Member")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Profile"><i class="fa fa-user"></i></a>
                        <a class="btn btn-link btn-xs" href="javascript:;"       data-placement="bottom" data-toggle="tooltip" data-original-title="Messages"><i class="fa fa-envelope"></i></a>
                        <a class="btn btn-link btn-xs" href="javascript:;"       data-placement="bottom" data-toggle="tooltip" data-original-title="Settings"><i class="fa fa-cog"></i></a>
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("logoff", "account")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Logout"><i class="fa fa-sign-out"></i></a>
                    </div>                                                                              <%-- SIDEBAR-WRAPPER END --%>
                </div>                                                                                  <%-- PROFILE BODY-WRAPPER END --%>
            </div>                                                                                      <%-- PROFILE-WRAPPER END --%>
            
            <nav>
                <h5 class="sidebar-header thin">Member Navigation</h5>
                <ul class="nav nav-pills nav-stacked">
                    <li><a href='<%: Url.Action("index", "Member")%>'><i class="fa fa-lg fa-fw fa-home"></i> Dashboard</a></li>
                    
                    <li class="nav-dropdown"><a href="#" title="automation"><i class="fa fa-lg fa-fw fa-gears"></i> Automation</a>
                        <ul class="nav-sub">
                            <li><a href='<%: Url.Action("experimentsettings", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Experiment Settings</a></li>
                            <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                            <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                            <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                            <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                            <li><a href='<%: Url.Action("blackscholes", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Black Scholes</a></li>
                            <%--<li><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> IB API Test</a></li>--%>
                            <li><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Harvest Robot "Willie"</a></li>
                            <%--<li><a href='<%: Url.Action("", "Member")%>'><i class="fa fa-lg fa-fw fa-check-circle-o"></i> Test</a></li> --%>                               
                        </ul>
                    </li> 
                    <li  class="active open"><a href="#" title="development"><i class="fa fa-lg fa-fw fa-code"></i> Development</a>
                        <ul class="nav-sub">                            
                            <li class="active"><a href='<%: Url.Action("index", "test")%>'><i class="fa fa-lg fa-fw fa-spinner"></i> Test</a></li> 
                            <li><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> IB API Test</a></li>
                        </ul>
                    </li>
                </ul>                       
            </nav>
        </aside>                                                                                         <%-- ASIDE-WRAPPER END --%>

        <div class="page-content">                                                                                                                 <%-- PAGE-CONTENT START --%>           
            <div class="page-subheading page-subheading-md">                                            <%-- PAGE sUBHEADING-WRAPPER START --%>
                <ol class="breadcrumb"><li class="active"><a href="javascript:;"><h3> Testing Enrironment</h3></a></li></ol>
                <p>Test new code, strategies, site functionality, and layouts here.</p>
            </div>                                                                              <%-- PAGE SUBHEADING-WRAPPER END --%>
        
            <div class="container-fluid-md">
               
                <div class="row">
                    <div class="col-md-10">                
                    <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Current Test:  Willie - Submit order & record all data for order.</h4>
                                <p style="float: left; padding-left: 10px; font-weight: normal;" >Select strategy to start the process. Last Order Id:<span style="float: right; padding-right: 10px;">  <%: ViewData("orderid")%></span></p>
                                <%--<p style="float: left; padding-left: 10px; font-weight: normal;" id="tickprice"></p>--%>                                                                                                      
                            </div>
                            <br />
                            <div class="panel-body">                                                              
                                <div class="form-inline">
                                    <div class="form-group"> 
                                        <%= Html.DropDownListFor(Function(x) x.SelectedIndex, New SelectList(Model.AllIndexes, "HarvestKey", "Name", Model.SelectedIndex), New With {.class = "form-control form-select", .placeHolder = "Choose an experiment...", .id = "harvestIndex", .name = "harvestIndex"})%>
                                        <%--<input type="text"class="form-control" id="expsymbol" placeholder="AAPL">--%>
                                    </div>
                                                                            
                                    <input type="text"class="form-control" id="primebuy" placeholder="primebuy">
                                    <button type="submit"id="buyorder" name="buyorder" class="btn btn-success">BUY</button>
                                    <input type="text"class="form-control" id="sellamount" placeholder="00.00">
                                    <button type="submit"id="sellorder" name="sellorder" class="btn btn-danger">SELL</button>
                                    <button type="submit"id="checkorder" name="checkorder" class="btn btn-primary">WILLIE</button>
                                    <button type="submit"id="calcprice" name="calcprice" class="btn btn-primary">Calc Price</button>
                                    
                                    <%--<button type="submit"id="getprice" name="getprice" class="btn btn-primary">Get Price</button>--%>

                                    <%--<input type="text"class="form-control" id="expsymbol" placeholder="AAPL">--%>                                    
                                    <%--<button type="submit"id="apiOrder" name="apiOrder" class="btn btn-primary">ORDER</button>--%>
                                    <%--<button type="submit"id="apiHistorical" name="apiHistorical" class="btn btn-primary">History</button>--%>
                                    <%--<button type="submit"id="apiOption" name="apiOption" class="btn btn-primary">OPTION</button>--%>
                                    <%--<button type="submit"id="apiOrderStatus" name="apiOrderStatus" class="btn btn-primary">ORDER STATUS</button>--%>
                                    <%--<button type="submit"id="apiStarting" name="apiStarting" class="btn btn-primary">SHELL</button>--%>
                                    <%--<button type="submit"id="apiPosition" name="apiPosition" class="btn btn-primary">PORTFOLIO</button> --%>                                     
                                    <%--<input type="text"class="form-control" id="cancelnum" placeholder="1">--%>
                                    <%--<button type="submit"id="cancelorder" name="cancelorder" class="btn btn-default">Cancel</button>--%>



                                    <div class="row" style="padding-top: 1em;">
                                        <div class="form-inline">
                                            <div class="form-group">
                                                <%--<label class="control-label" style="padding-left: 20px;" for="experimentName"> Name</label>--%>
                                                <%--<input type="text" disabled class="form-control" id="expname" name="expname" placeholder="AAPL" />--%>
                                            </div>
                                        </div>                                                                    
                                    </div>

                                </div>
                                    
                                    <div class="row" style="padding-right: 5em;">
                                        <%--<button type="submit"id="runRobot" name="runRobot" class="btn btn-primary pull-right">START</button>--%>                                                                    
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
                                    <ul></ul>
                                </div>                      
                            </div>                
                        </div>                    
                    </div>               
                </div>
            </div>
        </div>                                                                                                                                      <%-- PAGE-CONTENT END --%>

    </div>                                                                                                                                          <%-- PAGE-WRAPPER END --%>

    <%--<script type="text/javascript">
        $(function () {
            $('#harvestindex').change(function () {
                $.ajax({
                    url: "/test/dropselection",
                    data: {
                        roboindex: $(this).val()
                    },
                    success: function (data) {
                        $('#txt1').val(data);
                    }
                });
            });
        });
    </script>--%>
    
    <script type="text/javascript">

        //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

        // SET THE VARIABLES USED IN THE SCRIPT
        var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
        var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
        var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

        $(document).ready(function () {
            btn1 = $('#buyorder');
            $("#buyorder").click(function () {
                $(btn1).prop('disabled', true);

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                $("#connectStatus").html("Working");
                $.ajax({
                    method: 'POST',
                    url: "/test/sendorder",

                    data: {
                        primebuy: $("#primebuy").val(),
                        robotindex: harvestkey,
                        rowid: rowint,                           
                    }
                })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                        // Add the result from the controller action to the page 

                        $(btn1).prop('disabled', false);

                        //var mindata = result;
                        //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                        //document.getElementById('messagecenter').innerHTML == result
                    });

            });
        });

    </script>

    <script type="text/javascript">

        //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

        // SET THE VARIABLES USED IN THE SCRIPT
        var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
        var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
        var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

        $(document).ready(function () {
            btn4 = $('#sellorder');
            $("#sellorder").click(function () {
                $(btn4).prop('disabled', true);

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                $("#connectStatus").html("Working");
                $.ajax({
                    method: 'POST',
                    url: "/test/sellorder",

                    data: {
                        primebuy: $("#sellamount").val(),
                        robotindex: harvestkey,
                        rowid: rowint,
                    }
                })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                        // Add the result from the controller action to the page 

                        $(btn4).prop('disabled', false);

                        //var mindata = result;
                        //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                        //document.getElementById('messagecenter').innerHTML == result
                    });

            });
        });

    </script>

    <script type="text/javascript">

        //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

        // SET THE VARIABLES USED IN THE SCRIPT
        var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
        var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
        var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

        $(document).ready(function () {
            btn2 = $('#cancelorder');
            $("#cancelorder").click(function () {
                $(btn2).prop('disabled', true);

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                $("#connectStatus").html("Working");
                $.ajax({
                    method: 'POST',
                    url: "/test/cancelorder",

                    data: {
                        primebuy: $("#cancelnum").val(),
                        robotindex: harvestkey,
                        rowid: rowint,
                    }
                })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                        // Add the result from the controller action to the page 

                        $(btn1).prop('disabled', false);

                        //var mindata = result;
                        //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                        //document.getElementById('messagecenter').innerHTML == result
                    });

            });
        });

    </script>

    <script type="text/javascript">

        //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

        // SET THE VARIABLES USED IN THE SCRIPT
        var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
        var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
        var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

        $(document).ready(function () {
            btn3 = $('#checkorder');
            $("#checkorder").click(function () {
                $(btn3).prop('disabled', true);

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                $("#connectStatus").html("Working");
                $.ajax({
                    method: 'POST',
                    url: "/test/willie",

                    data: {
                        primebuy: $("#primebuy").val(),
                        robotindex: harvestkey,
                        rowid: rowint,
                    }
                })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                        // Add the result from the controller action to the page 

                        $(btn3).prop('disabled', false);

                        //var mindata = result;
                        //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                        //document.getElementById('messagecenter').innerHTML == result
                    });

            });
        });

    </script>

    <script type="text/javascript">

        //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

        // SET THE VARIABLES USED IN THE SCRIPT
        var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
        var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
        var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

        $(document).ready(function () {
            btn9 = $('#calcprice');
            $("#calcprice").click(function () {
                $(btn9).prop('disabled', true);

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                $("#connectStatus").html("Working");
                $.ajax({
                    method: 'POST',
                    url: "/test/calcprice",

                    data: {
                        primebuy: $("#primebuy").val(),
                        robotindex: harvestkey,
                        rowid: rowint,
                    }
                })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                        // Add the result from the controller action to the page 

                        $(btn9).prop('disabled', false);

                        //var mindata = result;
                        //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                        //document.getElementById('messagecenter').innerHTML == result
                    });

            });
        });

    </script>

    <script type="text/javascript">

        //ORIGINAL WORKING CODE FOR PULLING DATA VIA THE API ONE TIME -> KEEP THIS CODE!

        // SET THE VARIABLES USED IN THE SCRIPT
        var timeout = 60;                                                                                       // SETS THE TIME BETWEEN LOOPS IN SECONDS
        var intervalID = null;                                                                                  // HOLDS THE INTERVAL ID FOR THE LOOPS
        var rowint = 0                                                                                          // HOLDS THE ROW ID. INITIALIZED AT 0

        $(document).ready(function () {
            btn10 = $('#getprice');
            $("#getprice").click(function () {
                $(btn10).prop('disabled', true);

                testcheck = document.getElementById('harvestIndex');
                //var value = testcheck.options[testcheck.selectedIndex].value;
                harvestkey = testcheck.options[testcheck.selectedIndex].value;

                $("#connectStatus").html("Working");
                $.ajax({
                    method: 'POST',
                    url: "/test/getprice",

                    data: {
                        primebuy: $("#primebuy").val(),
                        robotindex: harvestkey,
                        rowid: rowint,
                    }
                })
                    .done(function (result) {
                        $("#connectStatus").html(result);
                        // Add the result from the controller action to the page 

                        $(btn10).prop('disabled', false);

                        //var mindata = result;
                        //$("#botlist ul").append('<li style="list-style-type: none;">' + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                        //document.getElementById('messagecenter').innerHTML == result
                    });

            });
        });

    </script>

</asp:Content>
