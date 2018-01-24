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
                    <th class="subtitle mb5">Date</th>
                    <th class="subtitle mb5">Time</th>
                    <%--<th class="subtitle mb5">Interval</th>--%>
                    <th class="subtitle mb5">Symbol</th>
                    <%--<th class="subtitle mb5"><%: Html.ActionLink("Symbol", "Garden", New With {.sortBy = "Symbol", .ascending = False})%>   <i class="fa fa-unsorted"></i></th>--%>
                    <th class="subtitle mb5">Open</th>
                    <%--<th class="subtitle mb5"><%: Html.ActionLink("Exp. Date", "Garden", New With {.sortBy = "ExpDate", .ascending = False})%> <i class="fa fa-unsorted"></i></th>--%>                                    
                    <th class="subtitle mb5">High</th>
                    <th class="subtitle mb5">Low</th>
                    <th class="subtitle mb5">Close</th>
                    <th class="subtitle mb5">Volume</th>
                    <th class="subtitle mb5">Trigger</th>                    
                    <th class="subtitle mb5">Action</th>                                    
                    <th></th>                                                                                                                    
                </tr>
            </thead>

            <tbody>
                <%Dim trigger As Double = ViewData("trigger")%>
                <%Dim width As Double = ViewData("width")%>
                <%Dim bflag As Boolean = False%>
                <%Dim sflag As Boolean = False%>
            <%For Each item In Model.AllPrices%>
                
                <tr>
                    <td><i class="fa fa-plus-circle tooltips" data-toggle="tooltip" title="Open Position"></i></td>
                    <td><%= Html.Encode(String.Format("{0:d}", item.Date))%></td>
                    <td><%= Html.Encode(String.Format("{0:t}", item.Time.ToLocalTime))%></td>
                    <%--<td><%: item.Interval%></td>--%>
                    <td><%: item.symbol%></td>
                    <td><%= Html.Encode(String.Format("{0:C}", item.OpenPrice))%></td>
                    <%If item.HighPrice > trigger + width - 0.01 Then%>
                        <td style="border: solid 1px black; font-weight: bolder;"><%= Html.Encode(String.Format("{0:C}", item.HighPrice))%></td>
                        <%trigger = trigger + width%>
                        <%sflag = True%>
                    <%Else%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.HighPrice))%></td>
                        <%sflag = False%>
                    <%End If%>
                    <%If item.LowPrice < trigger - width - 0.01 Then%>
                        <td style="border: solid 1px black; font-weight: bolder;"><%= Html.Encode(String.Format("{0:C}", item.LowPrice))%></td>
                        <%trigger = trigger - width%>
                        <%bflag = True%>
                    <%Else%>
                        <td><%= Html.Encode(String.Format("{0:C}", item.LowPrice))%></td>
                        <%bflag = False%>
                    <%End If%>
                    <td><%= Html.Encode(String.Format("{0:C}", item.ClosePrice))%></td>
                    <td><%= Html.Encode(String.Format("{0:##,##0}", item.Volume))%></td>
                    <td><%= Html.Encode(String.Format("{0:C}", trigger))%></td>
                    <td><%If sflag = True Then%>
                        SOLD
                        <%ElseIf bflag = True Then%>
                        BOT
                        <%Else%>
                        <%End If%>
                    </td>
                    

                </tr>                                    

            <%Next%>

            </tbody>

        </table>

    </div>