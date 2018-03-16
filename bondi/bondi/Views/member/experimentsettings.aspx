<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Trade Settings
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
                            <li class="active"><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Experiment Settings</a></li>
                            <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                            <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                            <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                            <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                            <%--<li>
                                <a href="ui-buttons.html" title="Buttons">
                                    <i class="fa fa-fw fa-caret-right"></i> Buttons
                                </a>
                            </li>
                            <li>
                                <a href="ui-panels.html" title="Panels">
                                    <i class="fa fa-fw fa-caret-right"></i> Panels
                                </a>
                            </li>
                            <li>
                                <a href="ui-tabs-accordions.html" title="Tabs & Accordions">
                                    <i class="fa fa-fw fa-caret-right"></i> Tabs & Accordions
                                </a>
                            </li>
                            <li>
                                <a href="ui-tooltips-popovers.html" title="Tooltips & Popovers">
                                    <i class="fa fa-fw fa-caret-right"></i> Tooltips & Popovers
                                </a>
                            </li>
                            <li>
                                <a href="ui-alerts.html" title="Alerts">
                                    <i class="fa fa-fw fa-caret-right"></i> Alerts
                                </a>
                            </li>
                            <li>
                                <a href="ui-components.html" title="Components">
                                    <i class="fa fa-fw fa-caret-right"></i> Components
                                </a>
                            </li>
                            <li>
                                <a href="ui-icons.html" title="Icons">
                                    <i class="fa fa-fw fa-caret-right"></i> Icons
                                </a>
                            </li>--%>
                        </ul>
                    </li>                        
                </ul>                       
            </nav>
        </aside>

        <div class="page-content">
            <div class="page-subheading page-subheading-md">
                <ol class="breadcrumb"><li class="active"><a href="javascript:;"> Experiment Settings</a></li></ol>
            </div>
               
            <div class="container-fluid-md">
               
                <div class="row">
                    <%-- <% Using (Html.BeginForm("addexperiment", "member", FormMethod.Post, New With {.enctype = "multipart/form-data"}))%>--%>
                    <div class="col-md-6">                
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Experiment Settings</h4>
                                <p>Enter the required parameters to begin an experiment.</p>
                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">

                                <div class="row">
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentName">Experiment Name</label>
                                            <input type="text" class="form-control" id="expname" name="expname" placeholder="AAPL Test Quarters">
                                        </div>
                                    </div>
                                
                                </div>                               
                                <div class="row">
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Symbol</label>
                                            <input type="text" class="form-control" id="expsymbol" placeholder="AAPL">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentTrigger">Buy Every</label>
                                            <input type="text" class="form-control" id="buytrigger" placeholder="0.25">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentWidth">Sell Every</label>
                                            <input type="text" class="form-control" id="selltrigger" placeholder="0.25">
                                        </div>
                                    </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentWidth">Shares</label>
                                            <input type="text" class="form-control" id="shares" placeholder="100">
                                        </div>
                                    </div>
                                </div>                                
                                <div class="row">                                                                        
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Hedge</label>
                                            <input type="text" class="form-control" id="hedge" placeholder="True">
                                            <%--<input type="checkbox" id="hedge">--%>
                                            <%--<%= Html.DropDownListFor(Function(x) x.SelectedIndex, New SelectList(Model.AllIndexes, "HarvestKey", "Name", Model.SelectedIndex), New With {.class = "form-control form-select2", .placeHolder = "Choose an experiment...", .id = "harvestIndex", .name = "harvestIndex"})%>--%>
                                            <%--<input type="checkbox">--%> 

                                        </div>
                                    </div>                                    
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentTrigger">Hedge Width</label>
                                            <input type="text" class="form-control" id="hedgewidth" placeholder="2">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentWidth">Exp. Width</label>
                                            <input type="text" class="form-control" id="expwidth" placeholder="2">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentWidth">Lots</label>
                                            <input type="text" class="form-control" id="lots" placeholder="4">
                                        </div>
                                    </div>                                    
                                </div>
                           
                            </div>                        
                            <div class="form-group text-right" style="padding-bottom: 5px; padding-right: 5px;">
                                    <label class="control-label" style="float: left; padding-left: 10px; font-weight: normal;" for="savesettings" id="errormsg"></label>
                                    <button type="submit" id="savesettings" name="savesettings" class="btn btn-primary">Save Settings</button>
                                </div>                        
                        </div>                
                    </div>
                    <%-- <%End Using%>--%>
                </div>

                <div class="row">
                <div class="col-md-10">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">Existing Experiment List</h4>
                        
                            <div class="panel-options">
                                <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="metric-content metric-icon">                       
                                <%Html.RenderPartial("partialHarvestIndexList")%>                        
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
            $("#savesettings").click(function () {

                $.ajax({
                    method: 'POST',
                    url: "/member/addexperiment",
                    data: {
                        expname: $("#expname").val(),
                        expsymbol: $("#expsymbol").val(),
                        buytrigger: $("#buytrigger").val(),
                        selltrigger: $("#selltrigger").val(),
                        hedgewidth: $("#hedgewidth").val(),
                        expwidth: $("#expwidth").val(),
                        lots: $("#lots").val(),                        
                        hedge: $("#hedge").val(),


                        success: function (result) {
                            $("#errormsg").html("Record added under name:  " + $("#expname").val()),
                            $("#expname").val(""),
                            $("#expsymbol").val(""),
                            $("#buytrigger").val(""),
                            $("#selltrigger").val("")
                        }
                    }
                });
            });
        });

    </script>

</asp:Content>
