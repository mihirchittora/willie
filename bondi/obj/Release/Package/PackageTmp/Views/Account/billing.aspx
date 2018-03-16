<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/member.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper" style="margin-top: 20px;">

        <!-- BEGIN CONTENT BODY -->
        <div class="page-content">
            
            <!-- BEGIN PAGE BAR -->
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <h5 class="page-title"><i class="fa fa-signal"></i> Billing  <small>  </small></h5>
                        <%--<a href="index.html">Home</a>
                        --%>
                    </li>
                    <%--<li>
                        <span>Dashboard</span>
                    </li>--%>
                </ul>
                <div class="page-toolbar">
                    <div id="dashboard-report-range" class="pull-right tooltips btn btn-sm" data-container="body" data-placement="bottom" data-original-title="Change dashboard date range">
                        <i class="icon-calendar"></i>&nbsp;
                        <span class="thin uppercase hidden-xs"></span>&nbsp;
                        <i class="fa fa-angle-down"></i>
                    </div>
                </div>
            </div>
            <!-- END PAGE BAR -->
           




        </div>
        <!-- /END CONTENT BODY -->

    </div>
    <!-- /END CONTENT -->
</asp:Content>
