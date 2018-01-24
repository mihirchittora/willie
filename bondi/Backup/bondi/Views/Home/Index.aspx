<%@ Page Language="VB" MasterPageFile="~/Views/Shared/frontend.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content-wrap">        
        <div class="container clearfix">
    <%
    If Request.IsAuthenticated Then
    %>
        Welcome <strong><%: Page.User.Identity.Name %></strong>!
        [ <%: Html.ActionLink("Log Off", "LogOff", "Account")%> ]
    <%
    Else
    %>
       
    <%        
    End If
    %>
    
    <img src="http://placehold.it/350x750">
        </div>
    </div>       
</asp:Content>
