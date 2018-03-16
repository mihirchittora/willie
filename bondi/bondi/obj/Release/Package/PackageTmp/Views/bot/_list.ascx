<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl (Of bondi.wavesViewModel)" %>

   

    <%--<div id="botlist">
        <h5> Position List</h5><br />
        <ul>
		  
	    </ul>
    </div>--%>
    

         <div class="table-responsive" id="testdiv">
            <table class="table table-striped">
                            
            <thead>
                <tr>
                    <th></th>                                            
                    <%--<th class="subtitle mb5"><%: Ajax.ActionLink("Date Opened", "Garden", New With {.sortBy = "DateOpened", .ascending = False}, New AjaxOptions With {.UpdateTargetId = "testdiv"})%> <i class="fa fa-sort-asc"></i></th>--%>
                    <th class="subtitle mb5">Date</th>
                    <th class="subtitle mb5">Time</th>
                    <th class="subtitle mb5">Interval</th>
                    <%--<th class="subtitle mb5"><%: Html.ActionLink("Symbol", "Garden", New With {.sortBy = "Symbol", .ascending = False})%>   <i class="fa fa-unsorted"></i></th>--%>
                    <th class="subtitle mb5">Open</th>
                    <%--<th class="subtitle mb5"><%: Html.ActionLink("Exp. Date", "Garden", New With {.sortBy = "ExpDate", .ascending = False})%> <i class="fa fa-unsorted"></i></th>--%>                                    
                    <th class="subtitle mb5">High</th>
                    <th class="subtitle mb5">Low</th>
                    <th class="subtitle mb5">Close</th>
                    <th class="subtitle mb5">Volume</th>                                    
                    <th></th>                                                                                                                    
                </tr>
            </thead>

            <tbody>
                <%Dim trigger As Double = ViewData("trigger")%>

            <%For Each item In Model.AllPrices%>
                
                <tr>
                    <td><i class="fa fa-plus-circle tooltips" data-toggle="tooltip" title="Open Position"></i></td>
                    <td><%= Html.Encode(String.Format("{0:d}", item.Date))%></td>
                    <td><%= Html.Encode(String.Format("{0:t}", item.Time.ToLocalTime))%></td>
                    <td><%: item.Interval%></td>
                    <td><%= Html.Encode(String.Format("{0:C}", item.OpenPrice))%></td>
                    <%If item.HighPrice > trigger + 0.25 Then%>
                        <td style="background-color: green; color: white;"><%= Html.Encode(String.Format("{0:C}", item.HighPrice))%></td>
                        <%trigger = trigger + 0.25%>
                    <%Else%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.HighPrice))%></td>
                    <%End If%>
                    <%If item.LowPrice < trigger - 0.25 Then%>
                        <td style="background-color: green; color: white;"><%= Html.Encode(String.Format("{0:C}", item.LowPrice))%></td>
                        <%trigger = trigger - 0.25%>
                    <%Else%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.LowPrice))%></td>
                    <%End If%>
                    <td><%= Html.Encode(String.Format("{0:C}", item.ClosePrice))%></td>
                    <td><%= Html.Encode(String.Format("{0:C}", trigger))%></td>
                    <%--<td><%= Html.Encode(String.Format("{0:##,##0}", item.Volume))%></td>--%>
                    <%--<td><%: Html.ActionLink(item.symbol, "EditTrade", New With {.id = item.HighPrice})%></td>--%>
                    <%--<td><%: Html.Encode(String.Format("{0:C}", item.shortCALL))%> /<%: Html.Encode(String.Format("{0:C}", item.longCALL))%> / <%: Html.Encode(String.Format("{0:C}", item.shortPUT))%> / <%: Html.Encode(String.Format("{0:C}", item.longPUT))%></td> --%>                                      
                    <%--<td><%= Html.Encode(String.Format("{0:d}", item.expirationDATE))%></td>--%>
                   <%-- <td><%= Html.Encode(String.Format("{0:C}", item.creditreceived))%></td>--%>
                    <%--<td><%= Html.Encode(String.Format("{0:C}", (item.creditreceived - 0.12) * 0.75))%></td>--%>
                    <%--<td><%= Html.Encode(String.Format("{0:C}", (item.creditreceived - 0.12) * 0.25))%></td>--%>
                   <%-- <td><%= Html.Encode(String.Format("{0}", (DateDiff(DateInterval.Day, item.openDATE, Now()))))%></td>--%>
                                        
                   <%-- <td>
                        <div class="btn-group">
                            <a data-toggle="dropdown" class="dropdown-toggle">
                                <i class="fa fa-cog"></i>
                            </a>
                            <ul role="menu" class="dropdown-menu pull-right">
                                                                        
                                <li><%: Html.ActionLink("Close Trade", "CloseTrade", New With {.id = item.tradeID})%></li>                                                                                
                                <li><%: Html.ActionLink("Edit Trade", "EditTrade", New With {.id = item.tradeID})%></li>
                                <li><%: Html.ActionLink("Delete Trade", "DeleteTrade", New With {.id = item.tradeID})%></li>
                                <li class="divider"></li>
                                
                                <li><a data-toggle="modal" data-target=".bs-example-modal-lg">Comment</a></li>
                                        
                            </ul>
                        </div>
                    </td>--%>

                </tr>                                    

            <%Next%>

            </tbody>

        </table>

    </div>