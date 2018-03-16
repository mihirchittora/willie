<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl (Of bondi.wavesViewModel)" %>

   

    <%--<div id="botlist">
        <h5> Position List</h5><br />
        <ul>
		  
	    </ul>
    </div>--%>
    

         <div class="table-responsive" id="testdiv" style="margin-top: -50px;">
            <table class="table table-striped">
                            
            <thead>
                <tr>
                    <th></th>                                            
                    <%--<th class="subtitle mb5"><%: Ajax.ActionLink("Date Opened", "Garden", New With {.sortBy = "DateOpened", .ascending = False}, New AjaxOptions With {.UpdateTargetId = "testdiv"})%> <i class="fa fa-sort-asc"></i></th>--%>
                    <th class="subtitle mb5">Open Date</th>
                    <th class="subtitle mb5">Open Time</th>
                    <%--<th class="subtitle mb5">Interval</th>--%>
                    <th class="subtitle mb5">Symbol</th>
                    <%--<th class="subtitle mb5"><%: Html.ActionLink("Symbol", "Garden", New With {.sortBy = "Symbol", .ascending = False})%>   <i class="fa fa-unsorted"></i></th>--%>
                    <th class="subtitle mb5">Price</th>
                    <%--<th class="subtitle mb5"><%: Html.ActionLink("Exp. Date", "Garden", New With {.sortBy = "ExpDate", .ascending = False})%> <i class="fa fa-unsorted"></i></th>--%>                                    
                    <th class="subtitle mb5">Close Date</th>
                    <th class="subtitle mb5">Close Time</th>
                    <th class="subtitle mb5">Price</th>
                    <th class="subtitle mb5">P / L</th>
                    <th class="subtitle mb5">Hedge?</th>                    
                    <th class="subtitle mb5">Strike</th>                                    
                    <th></th>                                                                                                                    
                </tr>
            </thead>

            <tbody>
                <%Dim trigger As Double = ViewData("trigger")%>
                <%Dim width As Double = ViewData("width")%>
                <%Dim bflag As Boolean = False%>
                <%Dim sflag As Boolean = False%>
            <%For Each item In Model.AllHarvestPrices%>
                
                <%Dim opentime As DateTime%> 
                <%Dim closetime As String%>               
                <%opentime = DateTime.Parse(item.opentime).ToLocalTime()%>
                <%If item.closedate.HasValue Then%>                    
                    <%closetime = DateTime.Parse(item.closetime).ToLocalTime()%>
                <% Else%>
                    <%closetime = ""%>
                <% End If%>
                <tr>
                    <td><i class="fa fa-plus-circle tooltips" data-toggle="tooltip" title="Open Position"></i></td>
                    <td><%= Html.Encode(String.Format("{0:d}", item.opendate))%></td>
                    <td><%= Html.Encode(String.Format("{0:t}", opentime))%></td>
                    <%--<td><%: item.Interval%></td>--%>
                    <td><%: item.symbol%></td>
                    <td><%= Html.Encode(String.Format("{0:C}", item.OpenPrice))%></td>
                    <%If item.closedate.HasValue Then%>
                        <td><%= Html.Encode(String.Format("{0:d}", DateTime.Parse(item.closedate).ToLocalTime()))%></td>                    
                        <td><%= Html.Encode(String.Format("{0:t}", DateTime.Parse(item.closetime).ToLocalTime()))%></td>
                    <%End If%>
                    <td><%= Html.Encode(String.Format("{0:C}", item.ClosePrice))%></td>
                    <td><%= Html.Encode(String.Format("{0:C}", (item.closeprice - item.openprice)*100))%></td>
                    <% If item.hedge = True Then%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.hedge))%></td>
                        <td><%= Html.Encode(String.Format("{0:C}", item.strike))%></td>
                    <%Else%>
                        <td><%= Html.Encode(String.Format(" "))%></td>
                        <td><%= Html.Encode(String.Format(" "))%></td>
                    <%End If%>
                    
                    <%--<%If item.HighPrice > trigger + width - 0.01 Then%>
                        <td style="border: solid 1px black; font-weight: bolder;"><%= Html.Encode(String.Format("{0:C}", item.HighPrice))%></td>
                        <%trigger = trigger + width%>
                        <%sflag = True%>
                    <%Else%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.HighPrice))%></td>
                        <%sflag = False%>
                    <%End If%>--%>
                    <%--<%If item.LowPrice < trigger - width - 0.01 Then%>
                        <td style="border: solid 1px black; font-weight: bolder;"><%= Html.Encode(String.Format("{0:C}", item.LowPrice))%></td>
                        <%trigger = trigger - width%>
                        <%bflag = True%>
                    <%Else%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.LowPrice))%></td>
                        <%bflag = False%>
                    <%End If%>--%>
                    
                    <%--<td><%= Html.Encode(String.Format("{0:##,##0}", item.Volume))%></td>--%>
                    <%--<td><%= Html.Encode(String.Format("{0:C}", trigger))%></td>
                    <td><%If sflag = True Then%>
                        SOLD
                        <%ElseIf bflag = True Then%>
                        BOT
                        <%Else%>
                        <%End If%>
                    </td>--%>
                    

                </tr>                                    

            <%Next%>

            </tbody>

        </table>

    </div>