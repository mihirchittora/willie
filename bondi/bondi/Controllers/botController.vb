Imports System.Threading
Imports System.Collections.Generic
Imports System.Net
Imports bondi.wavesViewModel
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Text
Imports System
Imports System.Globalization
Imports System.Data.Linq

Public Class botController
    Inherits System.Web.Mvc.Controller
    Public Shared cntr As Integer = 0
    Function Index() As ActionResult

        ' **********************************************************************************************************************************************************
        ' Function:         Start Trading Robot Index function
        ' Written By:       Troy Belden
        ' Date Written:     November, 17 2016
        ' Last Updated:     November, 17 2016
        ' Details:          This function initiate the trading robot. It pulls (scrapes) one of two sites to make sure that the data is available. It stores each record per 
        '                   minute in the database tables and performs the analytics on the variables that it pulls. In phase I the robot will alert the user to perform   
        '                   an action based on the strategy and triggers. In phase II the robot will carry out those actions in either an API format or sendkeys.
        '                   All of the data as well as the results will be logged in the tables with associated profit and loss calculations made in the views.
        ' **********************************************************************************************************************************************************
        ' Pull all prices for today 
        Using db As New wavesDataContext
            Dim symbol As String = "VXX"
            Dim priceDate As DateTime = #11/18/2016#
            Dim model As New wavesViewModel With { _
                                                     .AllPrices = db.GetPriceList(symbol, priceDate) _
                                                   }
            For Each item In model.AllPrices
                If item.Interval = 0 Then
                    ViewData("Trigger") = Int(item.OpenPrice) + 0.25
                End If
            Next

            Return View(model)

        End Using

        'Return View()
    End Function

    <HttpPost> _
    Function test(ByVal testdata As String) As ActionResult

        Dim datastring As String = "test controller"

        Return Content(datastring)
    End Function

    Function NewSymbol(ByVal sym As String) As ActionResult

        ' **********************************************************************************************************************************************************
        ' Function:         Start Trading Robot Index function
        ' Written By:       Troy Belden
        ' Date Written:     November, 17 2016
        ' Last Updated:     November, 17 2016
        ' Details:          This function initiate the trading robot. It pulls (scrapes) one of two sites to make sure that the data is available. It stores each record per 
        '                   minute in the database tables and performs the analytics on the variables that it pulls. In phase I the robot will alert the user to perform   
        '                   an action based on the strategy and triggers. In phase II the robot will carry out those actions in either an API format or sendkeys.
        '                   All of the data as well as the results will be logged in the tables with associated profit and loss calculations made in the views.
        ' **********************************************************************************************************************************************************

        ' Process variables
        Dim interval As String = ""
        Dim csvData As String
        Dim qurl As String
        Dim loops As Integer = 0

        Dim odate As Date = #8:30:00 AM#
        Dim curdate As Date = Now()
        Dim cldate As Date = #3:00:00 PM#
        Dim datastring As String = ""
        Dim postmin As Date = #8:30:00 AM#
        Dim ctime As Date = Now()

        '' Pull all prices for today 

        ' Calculate the minute number of the current time against the opening of the market. total minutes the market is open is 390.
        '    Dim numMinutes = DateDiff(DateInterval.Minute, DateTime.Parse(odate), DateTime.Parse(curdate))

        ' PULL DATA FOR PRODUCT FROM THE INTERNET - THE FREQUENCY OF THE PULL IS SET IN THE VIEW USING JAVASCRIPT.
        ' TODO: build out conditional checks 1. nonMarket days. 2. time period before market opens. 3. time period after market closes. 4. failure in link 1 to pull link 2.
        Using web As New WebClient()
            'csvData = web.DownloadString("http://finance.yahoo.com/d/quotes.csv?s=AAPL+FAS+GOOG+MSFT&f=snbaopl1")

            '  http://chartapi.finance.yahoo.com/instrument/1.0/VXX/chartdata;type=quote;range=1d/csv
            'https://www.google.com/finance/getprices?i=300&p=1d&f=d,o,h,l,c,v&df=cpct&q=VXX

            'qurl = "http://chartapi.finance.yahoo.com/instrument/1.0/" & sym
            'qurl = qurl & "/chartdata;type=quote;range=1d/csv"

            qurl = "https://www.google.com/finance/getprices?i=60&p=1d&f=d,o,h,l,c,v&df=cpct&q=" & sym

            csvData = web.DownloadString(qurl)

        End Using

        MsgBox(sym.ToString())


        ' Parses the CSV data into fields based on 
        Dim prices As List(Of Price) = Parse(csvData)

        ' Once the CSV file has been parsed it needs to be added to the table if it doesn't already exist.
        For Each price As Price In prices
            If Mid(price.MarketDate, 1, 1) = "a" Then
                interval = "0"
            Else
                interval = price.MarketDate.ToString()
            End If

            ' Determine the minute interval that is being added.

            ctime = odate.AddMinutes(interval)


            Using db As New wavesDataContext

                '    ' Get total members and load it to a ViewData variable.
                Dim a = From c In db.HarvestIntervals Where c.symbol = sym And c.Interval = interval And c.Date = DateTime.Now() Select c
                Dim intervalcount = a.Count()

                ' If intervalcount = 0 then record does not already exist add the record else loop.
                If intervalcount = 0 Then
                    ' Add the new record.
                    'If symbolexists = false add the symbol and set today as the firstissued date value
                    Dim newInterval As New HarvestInterval

                    TryUpdateModel(newInterval)
                    Dim newintervals As New HarvestInterval With { _
                                                                    .symbol = Trim$(sym), _
                                                                    .Date = DateTime.Parse(Now()).ToUniversalTime(), _                                                                    
                                                                    .OpenPrice = price.OpenPrice, _
                                                                    .HighPrice = price.HighPrice, _
                                                                    .LowPrice = price.LowPrice, _
                                                                    .ClosePrice = price.ClosePrice, _
                                                                    .Interval = interval, _
                                                                    .Volume = price.Volume _
                                                }

                    db.HarvestIntervals.InsertOnSubmit(newintervals)
                    db.SubmitChanges()
                End If
            End Using

        Next

        MsgBox("Records Added")
        Return RedirectToAction("index", "bot")
    End Function

    '<Authorize()> _
    Function startbot(ByVal testdata As String) As ActionResult
        ' **********************************************************************************************************************************************************
        ' Function:         Start Trading Robot function
        ' Written By:       Troy Belden
        ' Date Written:     November, 17 2016
        ' Last Updated:     November, 17 2016
        ' Details:          This function initiate the trading robot. It pulls (scrapes) one of two sites to make sure that the data is available. It stores each record per 
        '                   minute in the database tables and performs the analytics on the variables that it pulls. In phase I the robot will alert the user to perform   
        '                   an action based on the strategy and triggers. In phase II the robot will carry out those actions in either an API format or sendkeys.
        '                   All of the data as well as the results will be logged in the tables with associated profit and loss calculations made in the views.
        ' **********************************************************************************************************************************************************

        ' **********************************************************************************************************************************************************
        ' Strategy:         This trading strategy is based on one of three event triggers, price. When the strategy is started on a new product a buy to open is placed  
        '                   at the nearest quarter dollar below the opening price. Once that order is filled a good to cancel order to sell to close is placed at the next 
        '                   quarter dollar (this is the default) or higher width above to make a profit. This then continues with a buy order and sell order as the products
        '                   natural price moves up and down. 
        '                   A hedge is established for each position entered. The hedge is established using Put option contracts. This affords the hedge and protects from a 
        '                   large downside run in the price of a product. The objective of the hedge in the target to sell to close is to obtain any costs of the hedge, any loss
        '                   in the price of the product, and the targeted profit of the original position. At a minimum the hedge should allow the trade to be exited at a scratch.
        '                   It should be noted that commission costs are considered to be part of the cost of the business and not accounted for in price targets. (yet)
        ' **********************************************************************************************************************************************************

        ' Define variables used in the function. These will not include variables that are part of calls to other functions and classes.
        ' Counters and Loops
        Dim cntr As Integer = 0
        Dim rcntr As Integer = 0
        Dim loops As Integer = 0

        ' Process variables
        Dim interval As String = ""
        Dim csvData As String
        Dim qurl As String
        Dim sym As String = "GDX"
        Dim odate As Date = #8:30:00 AM#
        Dim curdate As Date = Now()
        Dim cldate As Date = #3:00:00 PM#
        Dim datastring As String = ""
        Dim postmin As Date = #8:30:00 AM#
        Dim ctime As Date = Now()
        Dim twidth As Double = 0.05
        Dim width As Double = 0.05

        Dim mark As Double = 0.0

        ' Get the trigger for the current product to set the trades in motion.
        Using ds As New wavesDataContext

            ' First query the table to determine if a trigger exists for the user (NOTE: once in Prod the user must be signed in.)
            'Dim model As New wavesViewModel With { _
            '                                                   .getTrigger = ds.getTrigger(sym) _
            '                                                }

            'mark = (model.getTrigger.priceTrigger)

        End Using

      

        'MsgBox(mark.ToString())



        ' Calculate the minute number of the current time against the opening of the market. total minutes the market is open is 390.
        Dim numMinutes = DateDiff(DateInterval.Minute, DateTime.Parse(odate), DateTime.Parse(curdate))

        ' PULL DATA FOR PRODUCT FROM THE INTERNET - THE FREQUENCY OF THE PULL IS SET IN THE VIEW USING JAVASCRIPT.
        ' TODO: build out conditional checks 1. nonMarket days. 2. time period before market opens. 3. time period after market closes. 4. failure in link 1 to pull link 2.
        Using web As New WebClient()
            'csvData = web.DownloadString("http://finance.yahoo.com/d/quotes.csv?s=AAPL+FAS+GOOG+MSFT&f=snbaopl1")

            '  http://chartapi.finance.yahoo.com/instrument/1.0/VXX/chartdata;type=quote;range=1d/csv
            'https://www.google.com/finance/getprices?i=300&p=1d&f=d,o,h,l,c,v&df=cpct&q=VXX

            'qurl = "http://chartapi.finance.yahoo.com/instrument/1.0/" & sym
            'qurl = qurl & "/chartdata;type=quote;range=1d/csv"

            qurl = "https://www.google.com/finance/getprices?i=60&p=1d&f=d,o,h,l,c,v&df=cpct&q=" & sym

            csvData = web.DownloadString(qurl)

        End Using

        ' Parses the CSV data into fields based on 
        Dim prices As List(Of Price) = Parse(csvData)


        Dim lTrigger = mark - twidth + 0.01
        Dim hTrigger = mark + twidth - 0.01


        ' Once the CSV file has been parsed it needs to be added to the table if it doesn't already exist.
        For Each price As Price In prices
            If Mid(price.MarketDate, 1, 1) = "a" Then
                interval = "0"
            Else
                interval = price.MarketDate.ToString()
            End If

            ' Determine the minute interval that is being added.

            ctime = odate.AddMinutes(interval)


            Using db As New wavesDataContext

                ' This section of code will display or save the line for the current minute.  Can be used in the daily production real time.
                
                If interval = numMinutes.ToString() Then

                    If price.LowPrice < lTrigger Then
                        datastring = (String.Format("{0:T}", Now().Subtract(New TimeSpan(0, 1, 0)).ToLocalTime)) & "    Symbol: " & sym & "    Mark: " & (String.Format("{0:C}", mark)) & "    Open: " & (String.Format("{0:C}", price.OpenPrice)) & "    High: " & (String.Format("{0:C}", price.HighPrice)) & "    Low: " & (String.Format("{0:C}", price.LowPrice)) & "    Close: " & (String.Format("{0:C}", price.ClosePrice)) & "    Vol: " & (String.Format("{0:##,##0}", price.Volume)) & "   BOT"
                        mark = Math.Round(price.LowPrice / width, 0) * width ' Int(price.LowPrice)

                        ' Update the trigger based on the prive movement.
                        ' Dim su = db.getTrigger(sym)

                        ' su.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                        ' su.priceTrigger = mark

                        '                        db.SubmitChanges()

                    ElseIf price.HighPrice > hTrigger Then
                        datastring = (String.Format("{0:T}", Now().Subtract(New TimeSpan(0, 1, 0)).ToLocalTime)) & "    Symbol: " & sym & "    Mark: " & (String.Format("{0:C}", mark)) & "    Open: " & (String.Format("{0:C}", price.OpenPrice)) & "    High: " & (String.Format("{0:C}", price.HighPrice)) & "    Low: " & (String.Format("{0:C}", price.LowPrice)) & "    Close: " & (String.Format("{0:C}", price.ClosePrice)) & "    Vol: " & (String.Format("{0:##,##0}", price.Volume)) & "   SOLD"
                        mark = Math.Round(price.HighPrice / width, 0) * width ' price.HighPrice - Int(price.HighPrice)

                        ' Update the trigger based on the prive movement.
                        ' Dim su = db.getTrigger(sym)

                        'su.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                        'su.priceTrigger = mark

                        'db.SubmitChanges()

                    Else
                        datastring = (String.Format("{0:T}", Now().Subtract(New TimeSpan(0, 1, 0)).ToLocalTime)) & "    Symbol: " & sym & "    Mark: " & (String.Format("{0:C}", mark)) & "    Open: " & (String.Format("{0:C}", price.OpenPrice)) & "    High: " & (String.Format("{0:C}", price.HighPrice)) & "    Low: " & (String.Format("{0:C}", price.LowPrice)) & "    Close: " & (String.Format("{0:C}", price.ClosePrice)) & "    Vol: " & (String.Format("{0:##,##0}", price.Volume))
                    End If
                End If

            End Using

        Next



        Return Content(datastring)
    End Function

    Private Function Parse(csvData As String) As List(Of Price)
        Dim rowcntr As String = 1
        Dim prices As New List(Of Price)()


        Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)

        For Each row As String In rows
            If rowcntr > 7 Then

                If String.IsNullOrEmpty(row) Then
                    Continue For
                End If

                Dim cols As String() = row.Split(","c)

                If cols(0) = "Date" Then
                    Continue For
                End If


                Dim p As New Price()
                p.MarketDate = cols(0)
                p.ClosePrice = Convert.ToDecimal(cols(1))
                p.HighPrice = Convert.ToDecimal(cols(2))
                p.LowPrice = Convert.ToDecimal(cols(3))
                p.OpenPrice = Convert.ToDecimal(cols(4))
                p.Volume = Convert.ToDecimal(cols(5))

                prices.Add(p)

            End If



            rowcntr = rowcntr + 1

        Next

        Return prices
    End Function


End Class

