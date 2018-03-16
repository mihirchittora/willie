<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage(Of bondi.wavesviewmodel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
       
        <!-- CSS -->         
        <%--<link rel="stylesheet" href="http://localhost:1295/cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.css">--%>
    
        <%--<script src="../../Content/assets/code/highcharts.js"></script>--%>
        <%--<script src="../../Content/assets/code/highcharts-more.js"></script>--%>
        <%-- %><script src="../../Content/assets/code/modules/exporting.js"></script>--%>
        
        <link rel="stylesheet" href="../../content/assets/demo/css/cstyle.css">
        <script src="../../Content/assets/demo/js/easypiechart.js"></script>

        <aside class="sidebar sidebar-default">
            <div class="sidebar-profile">
                <img class="img-circle profile-image" src="../../img/profile.jpg">

                <div class="profile-body">
                    <h4> <%= Page.User.Identity.Name %></h4>
                    <div class="sidebar-user-links">
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("profile", "Member")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Profile"><i class="fa fa-user"></i></a>
                        <a class="btn btn-link btn-xs" href="javascript:;"       data-placement="bottom" data-toggle="tooltip" data-original-title="Messages"><i class="fa fa-envelope"></i></a>
                        <a class="btn btn-link btn-xs" href="javascript:;"       data-placement="bottom" data-toggle="tooltip" data-original-title="Settings"><i class="fa fa-cog"></i></a>
                        <a class="btn btn-link btn-xs" href='<%: Url.Action("logoff", "account")%>' data-placement="bottom" data-toggle="tooltip" data-original-title="Logout"><i class="fa fa-sign-out"></i></a>
                    </div>
                </div>
            </div>
            
            <nav>
                <h5 class="sidebar-header thin">Member Navigation</h5>
                <ul class="nav nav-pills nav-stacked">
                    <li class="active open"><a href='<%: Url.Action("blank", "Member")%>'><i class="fa fa-lg fa-fw fa-home"></i> Dashboard</a></li>
                    
                    <li class="nav-dropdown"><a href="#" title="automation"><i class="fa fa-lg fa-fw fa-gears"></i> Automation</a>
                        <ul class="nav-sub">
                            <li><a href='<%: Url.Action("experimentsettings", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Experiment Settings</a></li>
                            <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                            <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                            <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                            <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                            <li><a href='<%: Url.Action("blackscholes", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Black Scholes</a></li>
                            <li><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> IB API Test</a></li>
                            <li><a href='<%: Url.Action("robot", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Harvest Robot "Willie"</a></li>
                            <%--<li><a href='<%: Url.Action("", "Member")%>'><i class="fa fa-lg fa-fw fa-check-circle-o"></i> Test</a></li> --%>                               
                        </ul>
                    </li> 
                    <li class="nav-dropdown"><a href="#" title="development"><i class="fa fa-lg fa-fw fa-code"></i> Development</a>
                        <ul class="nav-sub">                            
                            <li><a href='<%: Url.Action("index", "test")%>'><i class="fa fa-lg fa-fw fa-spinner"></i> Test</a></li> 
                            <li><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> IB API Test</a></li>
                        </ul>
                    </li>
                </ul>                       
            </nav>
        </aside>

        <div class="page-content">
            <div class="page-subheading page-subheading-md">
                <ol class="breadcrumb"><li class="active"><a href="javascript:;">Dashboard</a></li></ol>
            </div>

            <div class="container-fluid-md">               
                
                <div class="row">
                                                                    
                    <div class="col-md-6">
                        <div class="panel panel-default">
                        
                            <div class="panel-heading">
                                <h4 class="panel-title">System Performance</h4>                                    
                            </div>
                            <div class="panel-body">
                                <%--<div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>--%>
                                <%--<div id="myfirstchart" style="height: 300px"></div>--%>
                            </div>
                        
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="panel panel-default" style="height: 468px;">                                
                            <div class="panel-heading">
                                <h4 class="panel-title">Average Monthly Return On Capital</h4>                                    
                            </div>

                            <div class="panel-body">
                                <div class="metric-content metric-icon"  style="padding-left: 3em;">                                                       
                                    <span class="chart" data-percent=<%= Html.Encode(String.Format("{0:##.#}", "5.6"))%>>                                        
                                        <span class="percent"><%= Html.Encode(String.Format("{0:##.#}", "5.6"))%></span>                                        
                                    </span>                                        
                                </div>
                                <h3 style="padding-top: 5em;">Monthly $: <span class="bold" style="float: right; padding-right: 10px;">$ 75</span></h3>
                                <h3>Annual ROC: <span class="bold" style="float: right; padding-right: 10px;">66.67%</span></h3> 
                                <h3>Annual $: <span class="bold" style="float: right; padding-right: 10px;">$ 75</span></h3>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="panel panel-default" style="height: 468px;">
                                
                            <div class="panel-heading">
                                <h4 class="panel-title">Account Detail</h4>                                    
                            </div>

                            <div class="panel-body ">
                                <div class="metric-content metric-icon">                       
                                                                    
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Active orders:   <span style="float: right; padding-right: 10px;"><%: ViewData("openOrderCount")%></span></h3>
                                    <h3>Last Order Id:   <span style="float: right; padding-right: 10px;"><%: ViewData("orderid")%></span></h3>
                                    <%--<h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Active orders:   <span style="float: right; padding-right: 10px;"><%: ViewData("Message")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>
                                    <h3>Status:   <span class="bold" style="float: right; padding-right: 10px;"><%: ViewData("connected")%></span></h3>--%>

                                </div>
                            </div>
                        </div>
                    </div>
            
                </div>

                <div class="row">
                                                
                            <div class="col-md-6">
                                <div class="panel panel-default" style="height: 468px;">
                        
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Open Stock Orders</h4>                                    
                                    </div>
                                
                                    <div class="panel-body">
                                    
                                        <div id="Div3" style="width: 100%; height: 100%;">

                                            <table class="table table-striped">
                                        
                                                <thead>
                                                    <tr>
                                                        <th class="subtitle mb5">OrderId</th>
                                                        <th class="subtitle mb5">PermId</th>
                                                        <th class="subtitle mb5">symbol</th>
                                                        <th class="subtitle mb5">action</th>
                                                        <th class="subtitle mb5">price</th> 
                                                        <th class="subtitle mb5">status</th> 
                                                        <th class="subtitle mb5"><i class="fa fa-check"></i></th> 
                                                    </tr>
                                                </thead>
                                                   <%For Each item In Model.OrderList%>
                                                        <% If item.secType <> "OPT" Then%>
                                                            <tr>
                                                                <td><%: item.OId%></td>
                                                                <td><%: item.PermId%></td>
                                                                <td><%: item.Symbol%></td>
                                                                <td><%: item.OAction%></td>
                                                                <td><%= Html.Encode(String.Format("{0:C}", item.LmtPrice))%></td>
                                                                <td><%: item.Status%></td>
                                                                <% If item.Check = True Then %>
                                                                    <td><i class="fa fa-check-circle-o"></i></td>
                                                                <%Else %>
                                                                    <td style="align-content: center;"><i class="fa fa-circle-o"></i></td>
                                                                <%End if %>
                                                            </tr>
                                                        <% End If%>
                                                    <% Next %>
                                                <tbody>
                                                </tbody>                                    
                                            </table>
                                        
                                        </div>

                                    </div>

                        
                                </div>
                            </div>
                                                                    
                            <div class="col-md-6">
                                <div class="panel panel-default" style="height: 468px;">
                        
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Open Option Orders</h4>                                    
                                    </div>
                                
                                    <div class="panel-body">
                                    
                                        <div id="Div2" style="width: 100%; height: 100%;">

                                            <table class="table table-striped">
                                        
                                                <thead>
                                                    <tr>
                                                        <th class="subtitle mb5">id</th>
                                                        <th class="subtitle mb5">symbol</th>
                                                        <th class="subtitle mb5">action</th>
                                                        <th class="subtitle mb5">price</th>
                                                        <th class="subtitle mb5">status</th>                                                    
                                                    </tr>
                                                </thead>
                                                   <%For Each item In Model.OrderList%>
                                                    <% If item.secType = "OPT" Then%>    
                                                        <tr>
                                                            <td><%: item.PermId%></td>
                                                            <td><%: item.Symbol%></td>
                                                            <td><%: item.OAction%></td>
                                                            <td><%= Html.Encode(String.Format("{0:C}", item.LmtPrice))%></td>
                                                            <td><%: item.status%></td>
                                                        </tr>
                                                    <% End If%>
                                                    <% Next %>
                                                <tbody>
                                                </tbody>                                    
                                            </table>
                                        
                                        </div>

                                    </div>

                        
                                </div>
                            </div>

                        </div>

            </div>
        </div>

    </div>

    <!-- Scripts -->  
    
    <%--<script type="text/javascript">


            Highcharts.chart('container', {
                chart: {
                    zoomType: 'xy'
                },
                title: {
                    text: '2017 - Monthly Performance Overview'
                },
                subtitle: {
                    text: 'Harvest Strategy - Product: VXX'
                },
                xAxis: [{
                    categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
			            'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],

                    crosshair: true

                }],

                yAxis: [{ // Primary yAxis
                    labels: {
                        format: '',
                        style: {
                            color: Highcharts.getOptions().colors[7]
                        }
                    },
                    title: {
                        text: 'ROC',
                        style: {
                            color: Highcharts.getOptions().colors[7]
                        }
                    },
                    opposite: true

                }, { // Secondary yAxis
                    gridLineWidth: 0,
                    title: {
                        text: 'Total Profit',
                        style: {
                            color: Highcharts.getOptions().colors[0]
                        }
                    },
                    labels: {
                        format: '',
                        style: {
                            color: Highcharts.getOptions().colors[0]
                        }
                    }

                }, { // Tertiary yAxis
                    gridLineWidth: 0,
                    title: {
                        text: 'Shares Traded',
                        style: {
                            color: Highcharts.getOptions().colors[1]
                        }
                    },
                    labels: {
                        format: '',
                        style: {
                            color: Highcharts.getOptions().colors[1]
                        }
                    },
                    opposite: true
                }],
                tooltip: {
                    shared: true
                },
                legend: {
                    layout: 'vertical',
                    align: 'left',
                    x: 80,
                    verticalAlign: 'top',
                    y: 55,
                    floating: true,
                    backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
                },
                series: [{
                    name: 'Profit / Loss',
                    type: 'column',
                    yAxis: 1,
                    data: [549, 10324, 20084, 13091, 14983, 9635, 7217, 20315, 5517, 0, 0, 0],
                    tooltip: {
                        valueSuffix: ''
                    }

                }, {
                    name: 'Shares Traded',
                    type: 'spline',
                    yAxis: 2,
                    data: [9200, 54800, 98000, 89400, 69700, 54600, 37100, 110300, 24600, 0, 0, 0],
                    marker: {
                        enabled: false
                    },
                    dashStyle: 'shortdot',
                    tooltip: {
                        valueSuffix: ''
                    }

                }, {
                    name: 'ROC',
                    color: '#131252',
                    type: 'spline',
                    data: [2.8, 15.4, 32.6, 20.8, 26.5, 17.9, 19.9, 45.6, 14.1, 0, 0, 0],

                    dashStyle: 'longdash',
                    //color: Highcharts.getOptions().colors[7]
                    tooltip: {
                        valueSuffix: ' %'
                    }
                }]
            });

		</script>--%>

    <script>

        var element = document.querySelector('.chart');
        new EasyPieChart(element, {
            // your options goes here
            barColor: '#69c',
            trackColor: '#ace',
            scaleColor: false,
            lineWidth: 40,
            trackWidth: 40,
            size: 225,            
            lineCap: 'round',
            onStep: function (from, to, percent) {
                this.el.children[0].innerHTML = Math.round(percent);
            }
        });

    </script>

    //<script>
        //$(function () {
        //    var myChart = Highcharts.chart('container', {
        //        chart: {
        //            type: 'bar'
        //        },
        //        title: {
        //            text: 'Fruit Consumption'
        //        },
        //        xAxis: {
        //            categories: ['Apples', 'Bananas', 'Oranges']
        //        },
        //        yAxis: {
        //            title: {
        //                text: 'Fruit eaten'
        //            }
        //        },
        //        series: [{
        //            name: 'Jane',
        //            data: [1, 0, 4]
        //        }, {
        //            name: 'John',
        //            data: [5, 7, 3]
        //        }]
        //    });
        //});
    //</script>
    

</asp:Content>
