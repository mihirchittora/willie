<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/frontend.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="~/Scripts/jquery-2.2.3.min.js"></script>

    <div class="content-wrap">
        <div class="container clearfix" style="margin-top: -35px;">
            <%--<h5>Trading Bot</h5>--%>
            <div class="col-md-6"> 
                            
                <button class="btn btn-primary col-sm-2" id="getData" value="Create">Start Robot</button><br />
                
            </div>
           
        </div> 
        <div class="container clearfix">
            <div class="col-md-12">  
                <%Html.RenderPartial("_blist")%>
            </div>
        </div>
    </div>
   
    <!-- Script to run the bot goes here -->

     <script>
         // Name of the controller
         var controller = 'member';
         // Name of the action
         var action = 'test';
         // This handles the timeout between calls in seconds
         var timeout = 60;

         // Holds the interval id
         var intervalID = null;

         $(function () {
             // Replace with the button's selector
             btn = $('#getData');

             //alert(controller + "/" + action)

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
                 }, timeout * 1000);

             });
         });

         function getResults() {
             $.ajax({
                 method: 'POST',
                 url: "/" + controller + "/" + action,
                 data: {
                     testdata: new Date().toISOString()
                 }
             })
             .done(function (result) {
                 // Add the result from the controller action to the page
                 //$('#result').html(result.dateTime);
                 var mindata = result
                 //alert(result)

                 var date = new Date();
                 $("#botlist ul").append('<li>' + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                 // $(btn).prop('disabled', false);
             })

         }

    </script>

    <%--<script>
        // Name of the controller
        var controller = 'bot';
        // Name of the action
        var action = 'test';
        // This handles the timeout between calls in seconds
        var timeout = 60;
        
        // Holds the interval id
        var intervalID = null;

        $(function () {
            // Replace with the button's selector
            btn = $('#getData');
            inp = $('#pos');

            $(btn).click(function (e) {
                // Prevent default bubbling
                e.preventDefault();

                // Disable the button to prevent further clicks
                $(this).prop('disabled', true);
                $(inp).prop('disabled', true);

                // Get first result
                getResults();

                // Get results after each timeout
                intervalID = setInterval(function () {
                    getResults();
                }, timeout * 1000);

            });
        });

        function getResults() {
            $.ajax({
                method: 'POST',
                url: "/" + controller + "/" + action,
                data: {
                    testdata: new Date().toISOString()
                }
            })
            .done(function (result) {
                // Add the result from the controller action to the page
                //$('#result').html(result.dateTime);
                var mindata = result
                // alert(result)

                var date = new Date();
                $("#botlist ul").append('<li>' + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + mindata + '</li>');  // Change to get data from the controller to append.   + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + " - Minute: "
                // $(btn).prop('disabled', false);
            })
           
        }
       
    </script>--%>

</asp:Content>
