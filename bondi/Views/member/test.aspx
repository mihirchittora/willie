<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage(of bondi.wavesViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
TEST
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
                        <li class="active open"><a href='<%: Url.Action("blank", "Member")%>'><i class="fa fa-lg fa-fw fa-home"></i> Dashboard</a></li>
                        <%--<li class="nav-dropdown"><a href="#" title="automation"><i class="fa fa-lg fa-fw fa-check-circle-o"></i> Project Sprints</a>
                            <ul class="nav-sub">
                                <li><a href='<%: Url.Action("experimentsettings", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Sprint List</a></li>
                            </ul>
                        </li>--%>
                        <li class="nav-dropdown"><a href="#" title="automation"><i class="fa fa-lg fa-fw fa-gears"></i> Automation</a>
                            <ul class="nav-sub">
                                <li><a href='<%: Url.Action("experimentsettings", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Experiment Settings</a></li>
                                <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                                <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                                <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                                <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                                <li><a href='<%: Url.Action("blackscholes", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Black Scholes</a></li>
                                <li><a href='<%: Url.Action("IBtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> IB API Test</a></li>
                                <li><a href='<%: Url.Action("test", "Member")%>'><i class="fa fa-lg fa-fw fa-check-circle-o"></i> Test</a></li>                                
                            </ul>
                        </li>                        
                    </ul>                       
                </nav>
            </aside>

        <div class="page-content">
            <div class="page-subheading page-subheading-md">
                    <ol class="breadcrumb"><li class="active"><a href="javascript:;">TEST CODE</a></li></ol>
                </div>

            <div class="container-fluid-md">
                    <div class="row">
                        <div class="col-md-8">
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
                                    <%--//<label class="control-label pull-left" for="pullstatus" id="pullstatus"></label> <br /> <br /> --%>
                                    <form class="form-inline" role="form">                                        
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <label class="control-label" for="exampleInputName6">File Date</label>
                                                    <input type="text" class="form-control" id="fieldone"  placeholder="YYYYMMDD">
                                                </div>
                                            </div>
                                        
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <label class="control-label" for="exampleInputCompany6">Intervals</label>
                                                    <input type="text" class="form-control" id="fieldtwo" placeholder="390">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">  
                                            <div class="col-sm-4">                                       
                                                <div class="form-group"> 
                                                    <label class="control-label" for="exampleInputCompany6">Select Test</label>     
                                                    <%= Html.DropDownListFor(Function(x) x.SelectedIndex, New SelectList(Model.AllIndexes, "HarvestKey", "Name", Model.SelectedIndex), New With {.class = "form-control form-select2", .placeHolder = "Choose an experiment...", .id = "harvestIndex", .name = "harvestIndex"})%>
                                                </div>                
                                            </div>                                                                        
                                            <div class="col-sm-4">                                                                             
                                                <button type="submit" id="submitdata" name="submitdata" class="btn btn-primary pull-right margin-top">Submit </button>                                                                                                                                                                                                                                                                                                                              
                                            </div>
                                        </div>                   
                                    </form>                                    
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-10">
                            <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">Backtest Log</h4>
                                <p id="selectedList"></p>

                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="metric-content metric-icon">                       
                                       
                                    
                                    <%Html.RenderPartial("partialLogList")%> 
                                                       
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
            $("#submitdata").click(function () {
                $("#submitdata").prop('disabled', true);                                                                  // Disable the button to prevent further clicks 

                testcheck = document.getElementById('harvestIndex');
                harvestkey = testcheck.options[testcheck.selectedIndex].value;                
                //document.getElementById("#pullstatus").innerHTML = 'Pulling Data for: ' & $("#fieldone").val();

                $.ajax({
                    method: 'POST',
                    url: "/member/processTest",
                    data: {
                        fieldone: $("#fieldone").val(),
                        fieldtwo: $("#fieldtwo").val(),
                        robotindex: harvestkey,

                        success: function (result) {                            
                            //$("#expname").val("")                            
                            $("#submitdata").prop('disabled', false);                                                   // ENABLE THE SUBMIT BUTTON AS SCRIPT HAS COMPLETED 
                        }
                    }
                });
            });
        });

    </script>

</asp:Content>
