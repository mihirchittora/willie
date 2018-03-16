<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

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
                                <li><a href='<%: Url.Action("loaddata", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Load Dataset</a></li>
                                <li class="active"><a href='<%: Url.Action("Index", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Get Dataset</a></li>                               
                                <li><a href='<%: Url.Action("backtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Backtest Bot</a></li>
                                <li><a href='<%: Url.Action("forwardtest", "Member")%>'><i class="fa fa-lg fa-fw fa-caret-right"></i> Forward Test Bot</a></li>
                            </ul>
                        </li>                        
                    </ul>                       
                </nav>
            </aside>

            <div class="page-content">
                
                <div class="page-heading page-heading-md">
                    <h2>Get Dataset</h2>
                </div>

                <div class="container-fluid-md">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">Pull Dataset</h4>
                        
                                    <div class="panel-options">
                                        <a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                                        <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>
                                        <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <% Using Html.BeginForm("loaddataset", "member")%>
                                        <form class="form-inline" role="form">
                                            <div class="form-group col-md-4">                                    
                                                <input type="text" class="form-control" id="symbol" name="symbol" placeholder="Enter Symbol">
                                            </div>
                                            <div class="form-group col-md-4">                                    
                                                <input type="text" class="form-control" id="filedate" name="filedate" placeholder="YYYYMMDD">
                                            </div>
                                            
                                            <button type="submit" class="btn btn-primary">Load Dataset</button>
                                        </form>
                                    <% End Using%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

</asp:Content>
