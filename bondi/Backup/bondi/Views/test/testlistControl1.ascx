<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of bondi.wavesviewmodel)" %>

    <table class="table table-striped">
                            
        <thead>
            <tr>
                <th></th>
                <th class="subtitle mb5">Date Posted</th>
                <th class="subtitle mb5">Title</th>
                <th class="subtitle mb5">Description</th>
                <th class="subtitle mb5">Content</th>
                <th class="subtitle mb5">Date Updated</th>
                <th class="subtitle mb5">Active?</th>
                <th class="subtitle mb5"></th>                                    
            </tr>
        </thead>

            <tbody>

                                

                <%For Each item In Model.Price%>
                                    
                                   
                        <tr>
                            <td><i class="fa fa-tag tooltips" data-toggle="tooltip" title="Open Position"></i></td>

                            <td><%= Html.Encode(String.Format("{0:d}", item.DatePublished))%></td>
                            <td><%: item.Title%></td>
                            <td><%= Html.Encode(Mid$(item.Description, 1, 25))%></td>
                            <td><%= Html.Raw(Mid$(item.Text, 1, 100))%></td>
                            <td><%= Html.Encode(String.Format("{0:d}", item.Date_Modified))%></td>
                            <% If item.Active = True Then%>
                                <td><i class="fa fa-check-square-o"></i> <%: item.Active%></td>
                            <% Else%>
                                <td><i class="fa fa-square-o"></i> <%: item.Active%></td>
                            <% End If%>
                                             
                            <td>
                                <div class="btn-group">
                                    <a data-toggle="dropdown" class="dropdown-toggle">
                                        <i class="fa fa-cog"></i>
                                    </a>
                                    <ul role="menu" class="dropdown-menu pull-right">
                                        <li><%: Html.ActionLink("Edit Post", "EditPost", New With {.id = item.id})%></li>                                        
                                        <li><%: Html.ActionLink("Delete Post", "CloseTrade", New With {.id = item.id})%></li>                                                                                                                                                                               
                                    </ul>
                                </div>
                            </td>                                            
                        </tr>                                    
                                
                                    

                <%Next%>

            </tbody>

        </table>

                                                                        
                               