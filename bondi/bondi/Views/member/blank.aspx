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
                    <ol class="breadcrumb"><li class="active"><a href="javascript:;">Dashboard</a></li></ol>
                </div>
            </div>
        </div>

</asp:Content>
