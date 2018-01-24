<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="container-fluid-md">
    <div class="row">
        <div class="col-sm-2 col-lg-12">
            <div class="panel panel-metric panel-metric-sm">
                <div class="panel-body panel-body-white">
                    <header>
                        <h3 class="panel-title thin" style="text-align: center;">Control Panel</h3> <br />
                    </header>
                    <div class="metric-content metric-icon">
                                               
                        <div class="form-group col-lg-5">
                            <div class="row">
                                <%-- <div>
                                <h5 class="thin" style="text-align: center;">Bot Controls</h5>
                            </div>
                            </div>                                
                                                            
                            <label class="col-sm-2 control-label">Symbol:</label>

                            <div class="controls col-sm-5">
                                <input type="text" id="pos" name="pos" class="form-control" placeholder="Enter Symbol">
                            </div>  <br />  --%>
                                <div style="padding-top: 30px;">                                                   
                                
                                <button class="btn btn-primary col-sm-2" id="getData" value="Create"><i class="fa fa-fw fa-gears"></i>   Start Robot</button><br /><br />
              
                            </div>                                   

                            </div>
                           
                            <%--<div class="form-group col-lg-5">                                   ********** MOVE THIS TO ANOTHER PARTIAL VIEW TO ONLY PULL THE DATA. **********
                            <div class="row">
                                <div>
                                    <h5 class="thin" style="text-align: center;">Pull Symbol Data</h5>
                                </div>
                            </div>                                
                                                            
                            <label class="col-sm-2 control-label">Symbol:</label>                                                  
                            <% Using Html.BeginForm("PullData", "member")%>
                                <div class="controls col-sm-5">
                                    <input type="text" id="sym" name="sym" class="form-control" placeholder="Enter Symbol">
                                </div>  <br />  
                                <div style="padding-top: 30px;">                                                   
                                    <button class="btn btn-primary col-sm-4" id="Button1" value="Create"><i class="fa fa-fw fa-plus"></i>Pull Data</button><br /><br />                                
                                </div>                                   
                            <%End Using%>                           
                        </div>--%>                                                                       
                        </div>
                    </div>
                </div>
            </div>
    
        </div>
    </div>
</div>
