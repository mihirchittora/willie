<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/frontend.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="~/Scripts/jquery-2.2.3.min.js"></script>

    <div class="content-wrap">
        <div class="container clearfix" style="margin-top: -35px;">
            <h5>Trading Bot</h5>
            <div class="row">                
                <button class="btn btn-primary col-sm-1" id="getData" value="Create"><i class="fa fa-fw fa-plus"></i>Start Robot</button><br />
            </div>
            <div class="row">
                <% Using Html.BeginForm("NewSymbol", "bot")%>
                    <input type="text" id="sym" name="sym" class="form-control" placeholder="Enter New Symbol Here">
                    <button class="btn btn-success col-sm-1" id="newSymbol" value="newSymbol">Pull Data</button><br />
                <%End Using%>
            </div>
            <%Html.RenderPartial("list")%>

        </div>
    </div>

    <script>
        // Name of the controller
        var controller = 'home';
        var date = new Date();
        // Name of the action
        var action = 'test';
        // This handles the timeout between calls
        var timeout = 60;
        var step;

        $(function () {
            // Replace with the button's selector
            btn = $('#getData');

            $(btn).click(function (e) {
                // Prevent default bubbling
                e.preventDefault();

                // Disable the button to prevent further clicks
                $(this).prop('disabled', true);

                // Get first result
                getResults();


                // Get results after each timeout
                intervalID = setInterval(function () {
                    getResults();
                }, timeout * 100000);

            });
        });

        function getResults() {
            //alert("made get results" + "/" + controller + "/" + action);
            $.ajax({
                url: '<%= Url.Action("startbot", "bot")%>',
                type: 'GET',

                data: "testdata=" + new Date().toISOString(),

                success: function (data) {
                    var mindata = data
                    // alert(data)

                    // var date = new Date();
                    // $("#botlist ul").append('<li>' + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + "  " + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "

                    $(btn).prop('disabled', false);
                },

            })

        }
    </script>

</asp:Content>
