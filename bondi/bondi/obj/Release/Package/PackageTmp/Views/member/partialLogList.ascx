<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of bondi.wavesViewModel)" %>

<section id="tables">
            
            <%--<div class="page-header">
                <h1><small>All active Harvest Experiments.</small></h1>
            </div>--%>
    
            <div class="row">
                <div class="span12">
                <table class="table table-bordered table-striped">
                    <colgroup>
                        <%--<col class="span1">
                        <col class="span12">--%>
                    </colgroup>
                <thead>
                    <tr>
                        <th style="text-align: left;">Date</th>
                        <%--<th style="text-align: left;">#Trans</th>--%>
                        <th style="text-align: left;">Open</th>                      
                        <th style="text-align: center;">Closed</th>
                        <th style="text-align: center;">Remain</th>
                        <%--<th style="text-align: center;">Roll O</th>--%>
                        <th style="text-align: center;">Mark</th>
                        <th style="text-align: center;">S P/L</th>
                        <th style="text-align: center;">H P/L</th>
                        <th style="text-align: center;">Days P/L</th>
                        <th style="text-align: center;">Roll P/L</th>
                        <%--<th style="text-align: center;">Start</th>
                        <th style="text-align: center;">End</th> --%>                                            
                        <th style="text-align: center;">Cycle</th>
                        <th style="text-align: center;">Action</th>
                    </tr>
                </thead>
                
                <tbody>

                    <%Dim rollopen As Integer = 0%>
                    <% Dim rollPL As Double = 0%>
              
                
                <% For Each item In Model.AllLogs%> 
                        <% rollopen = rollopen + item.opens - item.closes%>  
                        <% rollPL = rollPL + item.stockprofit + item.hedgeprofit%>                                                                          
                    <tr>
                        <td style="text-align: left;">
                            <%= Html.Encode(String.Format("{0:MM/dd/yy}", item.marketdate))%> 
                        </td>
                        <%--<td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.trans))%>  
                        </td>--%>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.opens))%>  
                        </td>                      
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.closes))%> 
                        </td>
                         <%--<td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.opens - item.closes))%>                             
                        </td>--%>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", rollopen))%>                            
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:C}", item.closingmark))%>                            
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:$###,##0}", item.stockprofit))%>                                                       
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:$###,##0}", item.hedgeprofit))%>                                                       
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:$##0,000}", item.stockprofit + item.hedgeprofit))%>                            
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:$##0,000}", rollPL))%>                            
                        </td>
                        <%--<td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:h:mm}", DateTime.Parse(item.otimestamp).ToLocalTime()))%>                                                     
                        </td>
                        <td style="text-align: center;">                            
                            <%= Html.Encode(String.Format("{0:h:mm}", DateTime.Parse(item.timestamp).ToLocalTime()))%>                                                     
                        </td>--%>
                         <td style="text-align: center;">       
                             <% Dim duration As TimeSpan = item.timestamp - item.otimestamp%>                     
                            <%= Html.Encode(String.Format("{0:mm:ss}", duration.ToString()))%>                                                     
                        </td>

                        <td>
                            <div class="btn-group">
                                <a data-toggle="dropdown" class="dropdown-toggle">
                                    <i class="fa fa-cog"></i>
                                </a>
                                <ul role="menu" class="dropdown-menu pull-right">
                                    <%--<li><%: Html.ActionLink("View Ticket", "TicketDetail", New With {.id = item.tradeID})%></li>--%>                                        
                                    <li><%: Html.ActionLink("View Detail", "viewdetail", New With {.id = item.marketdate})%></li>                                                                                
                                    <%--<li><%: Html.ActionLink("Edit Trade", "EditTrade", New With {.id = item.tradeID})%></li>
                                    <li><%: Html.ActionLink("Delete Trade", "DeleteTrade", New With {.id = item.tradeID})%></li>--%>
                                    <li class="divider"></li>
                                    <li><%: Html.ActionLink("Undo Test", "EditTicket", New With {.id = item.marketdate})%></li>
                                    <%--<li><a data-toggle="modal" data-target=".bs-example-modal-lg">Comment</a></li>--%>
                                        
                                </ul>
                            </div>
                        </td>


                    </tr>
                <% Next%>
                    
                </tbody>                    
                </table>                    
                    
                </div>      
            </div>
        </section>      