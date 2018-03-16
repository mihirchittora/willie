<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of bondi.wavesViewModel)" %>

<section id="tables">
            
            <div class="page-header">
                <h1><small>All active Harvest Experiments.</small></h1>
            </div>
    
            <div class="row">
                <div class="span12">
                <table class="table table-bordered table-striped">
                    <colgroup>
                        <%--<col class="span1">
                        <col class="span12">--%>
                    </colgroup>
                <thead>
                    <tr>
                        <th style="text-align: left;">Experiment Name</th>
                        <th style="text-align: left;">Symbol</th>                      
                        <th style="text-align: center;">Open Trigger</th>
                        <th style="text-align: center;">Width</th>
                        <th style="text-align: center;">Date Created</th>
                        <th style="text-align: center;">Active</th>                                             
                    </tr>
                </thead>
                
                <tbody>

              
                <% For Each item In Model.AllExperiments%>                
                    <tr>
                        <td style="text-align: left;">
                            <%: item.name%>
                        </td>
                        <td style="text-align: center;">
                            <%: item.product%>                        
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:C}", item.opentrigger))%> 
                        </td>
                         <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:C}", item.width))%> 
                        </td>
                        <td style="text-align: center;">
                            <%= Html.Encode(String.Format("{0:MM/dd/yy}", item.timestamp))%>                            
                        </td>
                        <td style="text-align: center;">
                            <% If item.active = True Then%>
                            Yes
                            <%Else%>
                            No
                            <%End If%>                            
                        </td>
                        
                    </tr>
                <% Next%>
                    
                </tbody>                    
                </table>                    
                    
                </div>      
            </div>
        </section>      