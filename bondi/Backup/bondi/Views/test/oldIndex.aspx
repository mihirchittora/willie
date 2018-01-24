<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/frontend.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
test page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
       
</asp:Content>
