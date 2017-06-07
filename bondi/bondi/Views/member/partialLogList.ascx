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
                        <th style="text-align: left;"># Trans.</th>
                        <th style="text-align: left;">Pos. Opened</th>                      
                        <th style="text-align: center;">Pos. Closed</th>
                        <th style="text-align: center;">Pos. Open</th>
                        <th style="text-align: center;">Closing Mark</th>
                        <th style="text-align: center;">Start Time</th>
                        <th style="text-align: center;">End Time Time</th>                                             
                    </tr>
                </thead>
                
                <tbody>

              
                <% For Each item In Model.AllLogs%>
                    
                    
                                    
                    <tr>
                        <td style="text-align: left;">
                            <%= Html.Encode(String.Format("{0:MM/dd/yy}", item.marketdate))%> 
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.trans))%>  
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.opens))%>  
                        </td>                      
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.closes))%> 
                        </td>
                         <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:#,##0}", item.opens - item.closes))%> 
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:C}", item.closingmark))%>                            
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:hh:mm:ss}", item.otimestamp))%>                                                     
                        </td>
                        <td style="text-align: center;">                            
                            <%= Html.Encode(String.Format("{0:hh:mm:ss}", item.timestamp))%>                                                     
                        </td>
                    </tr>
                <% Next%>
                    
                </tbody>                    
                </table>                    
                    
                </div>      
            </div>
        </section>      