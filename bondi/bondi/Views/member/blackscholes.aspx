<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
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
                        <li class="nav-dropdown"><a href="#" title="automation"><i class="fa fa-lg fa-fw fa-gears"></i> Automation</a>
                            <ul class="nav-sub">
                                <li><a href='<%: Url.Action("experimentsettings", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Experiment Settings</a></li>
                                <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                                <li><a href='<%: Url.Action("dataset", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>
                                <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                                <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                                <li><a href='<%: Url.Action("blackscholes", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Black Scholes</a></li>                                
                            </ul>
                        </li>                        
                    </ul>                       
                </nav>
            </aside>

            <div class="page-content">
                <div class="page-subheading page-subheading-md">
                    <ol class="breadcrumb"><li class="active"><a href="javascript:;">Black Scholes Pricing Model</a></li></ol>
                </div>

                 <div class="container-fluid-md">
               
                <div class="row">
                    <% Using (Html.BeginForm("blackscholes", "member", FormMethod.Post, New With {.enctype = "multipart/form-data"}))%>
                        <div class="col-md-10">                
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                <h4 class="panel-title">Black-Scholes Options Pricing Model</h4>

                                <p>Enter the pricing data to calculate options prices.</p>
                                <div class="panel-options">
                                    <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                </div>
                            </div>
                                <div class="panel-body">
                                <div class="row">
                                    
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentName">Underlying Price</label>
                                            <input type="text" class="form-control" id="price" name="price" placeholder="12.90">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Strike Price</label>
                                            <input type="text" class="form-control" id="strike" name = "strike" placeholder= "12">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Volatility</label>
                                            <input type="text" class="form-control" id="vol" name="vol" placeholder=".7625">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Interest Rate</label>
                                            <input type="text" class="form-control" id="interest" name="interest" placeholder=".03">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Dividend Yield</label>
                                            <input type="text" class="form-control" id="dividend" name="dividend" placeholder="0.00">
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentSymbol">Pricing Date</label>
                                            <input type="text" class="form-control" id="pricedate" name="pricedate" placeholder="mm/dd/yyyy">
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label" for="experimentTrigger">Expiration Date</label>
                                            <input type="text" class="form-control" id="expdate" name="expdate" placeholder="mm/dd/yyyy">
                                        </div>
                                    </div>                                    
                                </div>

                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">                                            
                                            <label class="control-label" for="callprice">Estimated Call Price: </label> <%= Html.Encode(String.Format("{0:C}", ViewData("callprice")))%>                                          
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label class="control-label" for="putprice">Estimated Put Price:</label> <%= Html.Encode(String.Format("{0:C}", ViewData("putprice")))%>
                                            
                                        </div>
                                    </div>                                    
                                </div>
                           
                            </div>                        
                                <div class="form-group text-right" style="padding-bottom: 5px; padding-right: 5px;">
                                    <label class="control-label" style="float: left; padding-left: 10px; font-weight: normal;" for="calculate" id="errormsg"></label>
                                    <button type="submit" id="calculate" name="calculate" class="btn btn-primary">Calculate</button>
                                </div>                        
                            </div>                
                        </div>
                <%End Using%>
            </div>

               

            </div>

            </div>
        </div>


        <%--<script type="text/javascript">

            $(document).ready(function () {
                $("#calculate").click(function () {

                    $.ajax({
                        method: 'POST',
                        url: "/member/blackscholes",
                        data: {
                            price: $("#price").val(),
                            strike: $("#strike").val(),
                            vol: $("#vol").val(),
                            interest: $("#interest").val(),
                            dividend: $("#dividend").val(),
                            pricedate: $("#pricedate").val(),
                            expdate: $("#expdate").val(),

                            success: function (result) {
                                $("#cprice").html("Record added under name:  " + $("#expname").val()),
                                //$("#expname").val(""),
                                //$("#expsymbol").val(""),
                                //$("#exptrigger").val(""),
                                //$("#expwidth").val("")
                            }
                        }
                    });
                });
            });

    </script>--%>



</asp:Content>
