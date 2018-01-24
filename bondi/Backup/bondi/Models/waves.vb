Partial Class wavesDataContext

    '****************************************************************************************************************************************************
    ' LANDING PAGE SECTION
    '****************************************************************************************************************************************************

    ' **********************************************************************************************************************************************************
    ' Function:         Get A Number Blog Posts
    ' Written By:       Troy Belden
    ' Date Written:     October, 27 2014
    ' Last Updated:     October, 27 2016
    ' Details:          This functon pulls a set number of active blog posts based on a passed variable from the controller. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetXPosts(bnum As Integer) As List(Of BlogEntry)
        Dim lastXblogs = From blog In Me.BlogEntries Where blog.Active = True Select blog Order By blog.id Descending
        Return lastXblogs.Take(bnum).ToList()
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get An Harvest Index
    ' Written By:       Troy Belden
    ' Date Written:     May, 28 2017
    ' Last Updated:     May, 28 2017
    ' Details:          This functon pulls the selected harvest index record to get width and trigger data. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetHarvestIndex(ByVal harvestkey As String, ByVal active As Boolean) As HarvestIndex
        Return HarvestIndexes.Single(Function(p) p.harvestKey = harvestkey And p.active = active)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get An Individual Post
    ' Written By:       Troy Belden
    ' Date Written:     October, 27 2016
    ' Last Updated:     October, 27 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetPost(ByVal id As Integer) As BlogEntry
        Return BlogEntries.Single(Function(p) p.id = id)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Pull all prices for the day 
    ' Written By:       Troy Belden
    ' Date Written:     November, 17 2016
    ' Last Updated:     November, 17 2016
    ' Details:          This functon pulls all prices logged for the current day and returns them for display in the view.
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetPriceList(ByVal sym As String, ByVal selDate As DateTime) As List(Of HarvestInterval)
        Dim allPrices = From price In Me.HarvestIntervals Where price.symbol = sym And price.Date = selDate Select price Order By price.Interval Ascending
        Return allPrices.ToList()
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get An Price Trigger
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    'Public Function getTrigger(ByVal sym As String) As trigger
    '   Return triggers.Single(Function(p) p.Symbol = sym)
    ' End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Pull all prices for the day 
    ' Written By:       Troy Belden
    ' Date Written:     November, 17 2016
    ' Last Updated:     November, 17 2016
    ' Details:          This functon pulls all prices logged for the current day and returns them for display in the view.
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetAllExperiments() As List(Of HarvestIndex)
        Dim allExperiments = From index In Me.HarvestIndexes Select index Order By index.timestamp Ascending
        Return allExperiments.ToList()
    End Function





















    ' **********************************************************************************************************************************************************
    ' Function:         Get harvestposition
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function getposition(ByVal harvestkey As String, ByVal price As String, ByVal open As Boolean) As HarvestPosition
        Return HarvestPositions.Single(Function(p) p.harvestkey = harvestkey And p.openprice = price And p.open = open)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Check if position Exists
    ' Written By:       Troy Belden
    ' Date Written:     December, 04 2016
    ' Last Updated:     December, 04 2016
    ' Details:          This utility function checks the harvestposition table to determine if the position exists. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function posExists(ByVal harvestkey As String, ByVal price As String, ByVal open As Boolean) As Boolean
        Return Me.HarvestPositions.Any(Function(u) u.harvestkey = harvestkey And u.openprice = price And u.open = open)
    End Function





















    'Public Function GroupedLogList() As List(Of HarvestLog)
    '    Dim groupedlog = From p In Me.HarvestLogs Select Year(p.marketdate)
    '    Return groupedlog.ToList()
    'End Function




    Public Function logExists(ByVal harvestkey As String, ByVal marketdate As Date) As Boolean
        Return Me.HarvestLogs.Any(Function(u) u.harvestkey = harvestkey And u.marketdate = Date.Parse(marketdate).ToUniversalTime().ToShortDateString)
    End Function

    Public Function getlog(ByVal harvestkey As String, ByVal marketdate As Date) As HarvestLog
        Return HarvestLogs.Single(Function(p) p.harvestkey = harvestkey And p.marketdate = marketdate.ToShortDateString)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Pull harvest list 
    ' Written By:       Troy Belden
    ' Date Written:     December, 06 2016
    ' Last Updated:     December, 06 2016
    ' Details:          This functon pulls the records for the selected symbol and displays them in the view.
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetHarvestList(ByVal sym As String) As List(Of HarvestPosition)
        Dim allPrices = From price In Me.HarvestPositions Where price.symbol = sym Select price Order By price.opendate Ascending
        Return allPrices.ToList()
    End Function


    ' **********************************************************************************************************************************************************
    ' Function:         Get UserId From User Name
    ' Written By:       Troy Belden
    ' Date Written:     January, 13 2015
    ' Last Updated:     January, 13 201
    ' Details:          This utility function gets the userid from the user table based on the username. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function GetUserIdForUserName(ByVal userName As String) As Guid
        Dim q = From user In Me.Users Where user.UserName = userName Select user.UserId
        Return q.Single()
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Check if Mark Exists
    ' Written By:       Troy Belden
    ' Date Written:     December, 18 2016
    ' Last Updated:     December, 18 2016
    ' Details:          This utility function checks the triggers table to determine if a mark exists for the product. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function CheckMark(ByVal harvestkey As String) As Boolean
        Return Me.HarvestMarks.Any(Function(u) u.harvestkey = harvestkey)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Check if Mark Exists
    ' Written By:       Troy Belden
    ' Date Written:     December, 18 2016
    ' Last Updated:     December, 18 2016
    ' Details:          This utility function checks the triggers table to determine if a mark exists for the product. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function markExists(ByVal symbol As String, ByVal harvestkey As String) As Boolean
        Return Me.HarvestMarks.Any(Function(u) u.symbol = symbol And u.harvestkey = harvestkey)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get An Mark
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function getmark(ByVal harvestkey As String) As HarvestMark
        Return HarvestMarks.Single(Function(p) p.harvestkey = harvestkey)
    End Function




    ' **********************************************************************************************************************************************************
    ' Function:         Get An Mark
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function getopenmark(ByVal symbol As String, ByVal harvestkey As String) As HarvestMark
        Return HarvestMarks.Single(Function(p) p.symbol = symbol And p.harvestkey = harvestkey And p.open = True)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get An Mark
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function pullmark(ByVal harvestkey As String) As HarvestMark
        Return HarvestMarks.Single(Function(p) p.harvestkey = harvestkey)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Check if Hedge Exists
    ' Written By:       Troy Belden
    ' Date Written:     April, 18 2017
    ' Last Updated:     April, 18 2017
    ' Details:          This utility function is triggered when a position is sold to determine if a hedge position is needed. The hedge is applied when a position 
    '                   is sold to get a discount in the amount of the width on the hedge option.  
    '                   
    ' **********************************************************************************************************************************************************

    Public Function hedgeexists(ByVal harvestkey As String, ByVal price As Double, ByVal open As Boolean) As Boolean
        Return Me.HarvestHedges.Any(Function(h) h.harvestkey = harvestkey And h.stockatopen = price And h.open = True)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Check if Hedge Exists
    ' Written By:       Troy Belden
    ' Date Written:     April, 18 2017
    ' Last Updated:     April, 18 2017
    ' Details:          This utility function is triggered when a position is sold to determine if a hedge position is needed. The hedge is applied when a position 
    '                   is sold to get a discount in the amount of the width on the hedge option.  
    '                   
    ' **********************************************************************************************************************************************************

    Public Function chedgeexists(ByVal harvestkey As String, ByVal pricetest As Double, ByVal open As Boolean) As Boolean
        Return Me.HarvestHedges.Any(Function(h) h.harvestkey = harvestkey And h.targetexit = pricetest And h.open = open)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get the hedge
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function gethedge(ByVal harvestkey As String, ByVal pricetest As Double, ByVal open As Boolean) As HarvestHedge
        Return HarvestHedges.Single(Function(h) h.harvestkey = harvestkey And h.stockatopen = pricetest And h.open = open)
    End Function

    ' **********************************************************************************************************************************************************
    ' Function:         Get the hedge
    ' Written By:       Troy Belden
    ' Date Written:     November, 20 2016
    ' Last Updated:     November, 20 2016
    ' Details:          This functon pulls the entered post selected and display it from the database. 
    '                     
    '                   
    ' **********************************************************************************************************************************************************

    Public Function gethedgelist(ByVal harvestkey As String, ByVal markcheck As Double, ByVal open As Boolean) As List(Of HarvestHedge)
        'Return HarvestHedges.Single(Function(h) h.harvestkey = harvestkey And h.stockatopen = stockatopen And h.open = open)
        Dim allhedges = From hedge In Me.HarvestHedges Where hedge.harvestkey = harvestkey And hedge.open = open And hedge.stockatopen > markcheck Select hedge Order By hedge.stockatopen Ascending
        Return allhedges.ToList()
    End Function

End Class




