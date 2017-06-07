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
                                <li class="active"><a href='<%: Url.Action("automate", "Member")%>' title="Harvest"><i class="fa fa-lg fa-fw fa-leaf"></i> Harvest Robot</a></li>  
                                <li><a href='<%: Url.Action("viewharvest", "Member")%>' title="Harvest"><i class="fa fa-lg fa-fw fa-leaf"></i> View Harvest Data</a></li>
                                <%--<li><a href='<%: Url.Action("viewdata", "Member", New With {.sym = "GDX", .wid = 0.25, .pd = Today.Date})%>' title="Harvest"><i class="fa fa-lg fa-fw fa-paper"></i> View Data</a></li>--%>
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
            <div class="content-wrap">
                <div class="container clearfix" style="margin-top: 25px;">                    
                    <div class="row">
                        <div class="col-lg-12">
                            <ul class="nav nav-tabs">
                                <li class="active"><a data-toggle="tab" href="#tab1-1">Trading Robot</a></li>
                                <li><a data-toggle="tab" href="#tab1-2">Pull Data</a></li>
                                <li><a data-toggle="tab" href="#tab1-3">Write Text File</a></li> 
                                <li><a data-toggle="tab" href="#tab1-4">Back Data</a></li>                        
                            </ul>                        

                            <div class="tab-content">

                                <div id="tab1-1" class="tab-pane active">
                                    <div class="col-md-14">
                                        <div class="row" >                             
                                            <button class="btn btn-primary col-md-1" id="getData" value="1">Start Robot</button>
                                            <button style="margin-left: 50px;" class="btn btn-danger col-md-1" id="stopData" value="0">Stop Robot</button>                                            
                                            
                                            <input style="margin-left: 50px; width: 100px;" type="text" id="robotsymbol" name="sym" class="form-control col-md-2" placeholder="symbol" />
                                            <input style="margin-left: 50px; width: 125px;" type="text" id="robotwidth" name="width" class="form-control col-md-2" placeholder="width ex. 0.25" />
                                            <%--<input style="margin-left: 150px; width: 125px;" type="text" id="textfile" name="textfile" class="form-control col-md-2" placeholder="file date" /> --%>                                           
                                            <br />                
                                        </div>
                                        <%--<div class="row" style="margin-top: 10px;">
                                            <label class="control-label col-sm-3">Checkbox Inline</label>
                                            <div class="controls col-sm-6">
                                                <label class="checkbox-inline">
                                                    <input type="checkbox" id="checktest" checked>
                                                    Live
                                                </label>
                                                <p id="demo"></p>
                                            </div>  
                                        </div>--%>                                                                                                                                 
                                        
                                        <div class="row">  
                                            <p class="mb20"></p>
                                            <%Html.RenderPartial("zbotresultlog")%>  
                                        </div>

                                    </div><!-- col-md-6 -->
                                <%--</div>--%>
                                </div>

                                <div id="tab1-2" class="tab-pane">
                                    <div class="col-md-12">
                                        <% Using Html.BeginForm("getdata", "Member")%>
                                            <div class="form-group">                                                                                                                                                                                              
                                                <label class="col-sm-2 control-label">Symbol:</label>

                                                <div class="controls col-sm-2">
                                                    <input type="text" id="sym" name="sym" class="form-control" placeholder=<%: ViewData("symbol")%> />
                                                </div>                                     

                                            </div>
                                            <div style="padding-top: 10px; margin-bottom: 25px;">                                                   
                                                <button class="btn btn-primary col-sm-2" id="submitButton" value="Create"><i class="fa fa-fw fa-plus"></i> Get Data</button>                                                
                                            </div>                                                                                                                                                                                                         
                                        <%End Using%>                                                               
                                    </div><!-- table-responsive -->
                                </div><!-- col-md-6 -->
                                    
                                <div id="tab1-3" class="tab-pane">
                                    <div class="col-md-12">
                                        <% Using Html.BeginForm("createtext", "Member")%>
                                             <div class="row">   
                                                                                                                                                              
                                                <input style="margin-left: 10px; margin-right: 20px; width: 125px;" type="text" id="symbol" name="symbol" class="form-control col-md-2" placeholder="symbol" />
                                            
                                                <div style="margin-left: 50px; margin-bottom: 25px; width: 125px;" class="input-group date">
                                                    <input  type="text" name="filedate" id="filedate" class="form-control" data-rel="datepicker"><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>                                            
                                                    <%--<input style="margin-left: 50px; width: 125px;" type="text" id="Text2" name="width" class="form-control col-md-2" placeholder="make date pick" />--%>
                                                </div>
                                            
                                                 <button style="margin-left: 10px; margin-bottom: 50px;" class="btn btn-primary col-md-3" id="Button1" value="Create">Create Text File</button>
                                                <br />                
                                                <%: ViewData("status")%>
                                            </div>    
                                        <% End Using%>     
                                    </div><!-- col-md-6 -->                
                                </div>

                                <div id="tab1-4" class="tab-pane">
                                    <div class="col-md-12">
                                        <% Using Html.BeginForm("backdata", "Member")%>
                                             <div class="row">   
                                                                                                                                                              
                                                <input style="margin-left: 10px; margin-right: 20px; width: 125px;" type="text" id="Text1" name="symbol" class="form-control col-md-2" placeholder="symbol" />
                                            
                                                <div style="margin-left: 50px; margin-bottom: 25px; width: 125px;" class="input-group date">
                                                    <input  type="text" name="filedate" id="Text2" class="form-control" data-rel="datepicker"><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>                                            
                                                    <%--<input style="margin-left: 50px; width: 125px;" type="text" id="Text2" name="width" class="form-control col-md-2" placeholder="make date pick" />--%>
                                                </div>
                                            
                                                 <button style="margin-left: 10px; margin-bottom: 50px;" class="btn btn-primary col-md-2" id="backdate" value="backdate">Load Back Data</button>
                                                <br />                
                                                <%--<%: ViewData("status")%>--%>
                                            </div>    
                                        <% End Using%>     
                                    </div><!-- col-md-6 -->                
                                </div>

                            </div>
        
                        </div>                 
                    </div>                                                      
                </div>           
            </div>
        </div>       
    </div>
    <!--/Scripts-->  
	      
    <script>
        // Name of the controller
        var controller = 'member';
        // Name of the action
        var action = 'harvestbot';        
        // This handles the timeout between calls in seconds
        var timeout = 3;  //revert back to 60 for live system        
        // Holds the interval id
        var intervalID = null;
        // Hold the rowID
        var minuteinterval = 0
        var rowint = 0
        var keeprunning = 0
        // Store the UTC offset here
        var UTCoffset = { hours: -6, minutes: 0 };
        // Stores the market open time
        var open = { hours: 8, minutes: 25 };
        // Stores the market close time
        var close = { hours: 16, minutes: 00 };


        //startResultsPooling();

        $(function () {
            // Replace with the button's selector
            btn = $('#getData');                        
            stopbtn = $('#stopData');
            txtcheck = $('txtcheck');
            txtfile = $('txtfile');
            //checktest = $('checktest');

            // REVIEW THIS TO SEE IF YOU CAN SET THIS TO TRIGGER 
           // var live = document.getElementById("checktest").checked;
           // document.getElementById("demo").innerHTML = live;                //Great for displaying a value on the page dynamically
            // live = x

            //alert(document.getElementById("checktest").checked)

            $(stopbtn).click(function (e) {                                                
                keeprunning = 0
                $(btn).prop('disabled', false)
            })

            $(btn).click(function (e) {
                // Prevent default bubbling
                e.preventDefault();
                keeprunning = 1


            // Disable the button to prevent further clicks
            $(btn).prop('disabled', true);           

            // Get first result
            getResults();
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
                    robotsymbol: $("#robotsymbol").val(), 
                    robotwidth: $("#robotwidth").val(),
                    rowid: rowint,
                    //live: document.getElementById("checktest").checked,
                    testdata: new Date().toISOString()                    
                }
            })
            .done(function (result) {
                // Add the result from the controller action to the page                
                var mindata = result                                 
                $("#botlist ul").append('<li style="list-style-type: none;">' +  "   " + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                
                
                if (keeprunning = 0) {
                    alert(keeprunning)
                }
                //if (keeprunning = 0) {
                //    $(btn).prop('disabled', false);
                //    alert("done")
                //    return;
                //    }

                // $(btn).prop('disabled', false); 
            })

            function exitapp() {
                return;
            }

        }
       
        //function getNowMinutes() {
        //    var now = new Date();
        //    return (now.getUTCHours() + UTCoffset.hours) * 60 + (now.getUTCMinutes() + UTCoffset.minutes);
        //}

    </script>

    <!--/Scripts-->
</asp:Content>
