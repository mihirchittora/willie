<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

 <%= Html.ValidationSummary() %>
     
    <%--<% Using Html.BeginForm("AP", "Member")%>--%>
    <%--<% Using Ajax.BeginForm("APos", New AjaxOptions With {.OnSuccess = "createSuccess"})%>--%>
       
        <div class="panel panel-default">
            <div class="panel-heading">

                <%--<h4 class="panel-title">Add A Position (Plant a Trade)</h4>--%>
                                        
                <div class="panel-options">
                    <%--<a href="#" data-rel="collapse"><i class="fa fa-fw fa-minus"></i></a>
                    <a href="#" data-rel="reload"><i class="fa fa-fw fa-refresh"></i></a>--%>
                    <a href="#" data-rel="close"><i class="fa fa-fw fa-times"></i></a>
                </div>
                                
                <div class="panel-body">
                    
                        <div class="form-group">                                                                                                
                            <label class="col-sm-2 control-label">Symbol:</label>

                            <div class="controls col-sm-2">
                                <%: ViewData("symbol")%>
                            </div> 
                            <span style="margin-left: 10px;">Profit / (Loss):  </span><span class="counter"><%= Html.Encode(String.Format("{0:C}", ViewData("profit")))%> </span>                        
                            <span style="margin-left: 10px;">Total positions:  </span><span class="counter"><%: ViewData("total")%></span>
                            <span style="margin-left: 10px;">Total Open:  </span><span class="counter"><%: ViewData("open")%></span>           
                            <span style="margin-left: 10px;">Total Closed:  </span><span class="counter"><%: ViewData("closed")%></span>
                             



                        </div>
                                                              
                </div>                        
            </div>
        </div>

    <%--<%End Using%>--%>
       



   <%-- <script type="text/javascript">

        $(document).ready(function () {
            $("#submitButton").click(function () {
                $("#message").html("Working...");
                var data = {
                    "viewdate": $("#viewdate").val(),
                    "sym": $("#sym").val(),
                    "wid": $("#wid").val()
                };

                var viewdate = $("#viewdate").val()
                var sym = $("#sym").val()
                var wid = $("#wid").val()
                $.ajax({
                    url: '<%= Url.Action("displaydata", "member")%>', // "/member/DisplayData",
                   // type: "GET",
                    data: JSON.stringify(data),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    success: function (result) {

                        $("#message").html(result);
                        $("#viewdate").val("")
                        $("#sym").val("")
                        $("#wid").val("");

                        if (result = "Position successfully added.") {

                            // This is where the call to refresh the partial would be called.
                            //alert(result)


                            // Update the trade Count Chart - this should be the only one needed to update

                        }

                    },
                    error: function (result) {
                        //alert(result)
                        //$('#message').text("Error:" + error);
                        $("#message").html("An error occurred.");
                    }
                });
            });
        });

    </script>--%>

<%-- Save this code --%>

    <%--<script type="text/javascript">

    $(document).ready(function () {
        $("#submitButton").click(function () {
            $("#message").html("Logging in...");
            var data = {
                "tradedate": $("#tradedate").val(),
                "pos": $("#pos").val()
            };
            $.ajax({
                url: "/member/APos",
                type: "POST",
                data: JSON.stringify(data),
                dataType: "json",
                contentType: "application/json",
                success: function (status) {
                    $("#message").html(status.Message);
                    if (status.Success) {
                        $("#message").html("Success!");
                        window.location.href = status.TargetURL;
                    }
                },
                error: function () {
                    $("#message").html("Error while authenticating user credentials!");
                }
            });
        });
    });

    </script>--%>
