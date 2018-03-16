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

Namespace bondi

    Public Class o_memberController
        Inherits System.Web.Mvc.Controller
        Public rowinterval As Integer = 0

        Function Index() As ActionResult
            'Return RedirectToAction("blank", "member")
            Return View()
        End Function

        Function Blank() As ActionResult
            Return View()
        End Function

        Function profile() As ActionResult
            Return View()
        End Function

        Function settings() As ActionResult
            Return View()
        End Function

        ' ********************  HARVESTING SECTION  ********************

        <HttpPost> _
        Function harvestbot(ByVal testdata As String, ByVal robotsymbol As String, ByVal robotwidth As Double, ByVal rowid As Integer) As ActionResult      'rowid: minuteinterval,

            'MsgBox(live)

            ' This will stop the function & javascript when the last interval has completed.
            'If rowid > 391 Then
            'Return RedirectToAction("automate", "member")
            'End If
            ' Get current timestamp for posting reference
            Dim currenttime As New DateTime
            currenttime = Now()

            ' Get time 1 minute ago for the closed interval
            Dim oneMinAgo As DateTime
            oneMinAgo = currenttime.Subtract(New TimeSpan(0, 1, 0)).ToLocalTime

            Dim checktime As New DateTime
            checktime = Now().ToShortTimeString

            Dim markettime As New DateTime
            Dim sym As String = robotsymbol.ToUpper()
            Dim qurl As String = ""
            Dim csvdata As String = ""
            Dim rowdata As String = ""
            Dim cntr As Integer = 0
            Dim stockaction As String = ""
            Dim hedgeaction As String = ""
            Dim strike As Double = 0
            Dim mark As Double = 0.0
            Dim width As Double = 0.0
            Dim newmark As String = ""
            Dim interval As Integer = 0
            Dim username As String = "csquared20"



            If IsNothing(robotwidth) Then
                robotwidth = 0.25 - 0.01
            Else
                width = robotwidth
                robotwidth = robotwidth - 0.01
            End If

            ' PULL DATA FOR PRODUCT FROM THE INTERNET - THE FREQUENCY OF THE PULL IS SET IN THE VIEW USING JAVASCRIPT.  Pulls Yahoo as it is more consistent in various products.
            ' TODO: build out conditional checks 1. nonMarket days. 2. time period before market opens. 3. time period after market closes. 4. failure in link 1 to pull link 2.
            Using web As New WebClient()

                ' For testing the text file comment the variable qurl out.
                'qurl = "http://chartapi.finance.yahoo.com/instrument/1.0/" & sym.ToUpper
                'qurl = qurl & "/chartdata;type=quote;range=1d/csv"

                'qurl = "https://www.google.com/finance/getprices?i=60&p=1d&f=d,o,h,l,c,v&df=cpct&q=" & sym

                ' Uncomment this after testing  
                'csvdata = web.DownloadString(qurl)

                ' this is used for testing - reads from a text file and will parse like the web read.  It should be commented out after testing.
                Using textReader As New System.IO.StreamReader("C:\Users\Prime\Desktop\symbols\" & robotsymbol & "-12132016.txt")
                    csvdata = textReader.ReadToEnd
                End Using

            End Using

            ' Parses the CSV data into fields based on 
            Dim prices As List(Of Price) = ParseYahoo(csvdata)

            ' Get the trigger for the current product to set the trades in motion.
            Using db As New wavesDataContext

                ' Get Userid from Username
                Dim uID As Guid = db.GetUserIdForUserName(username)
                'Dim uID As Guid = db.GetUserIdForUserName(User.Identity.Name)

                ' First query the table to determine if a trigger exists for the user (NOTE: once in Prod the user must be signed in.)
                'Dim model As New wavesViewModel With { _
                '                                                   .getTrigger = db.getTrigger(sym) _
                '                                                }

                'mark = (model.getTrigger.priceTrigger)

                ' Set the triggers to flag buy or sell of stock.
                Dim lowerTrigger = mark - robotwidth
                Dim higherTrigger = mark + robotwidth


                ' Once the CSV file has been parsed it needs to be added to the table if it doesn't already exist.
                For Each price As Price In prices
                    ' Determine the market time to add to the row data
                    markettime = String.Format("{0:t}", price.MarketDate)
                    markettime = markettime.Subtract(New TimeSpan(0, 0, 0)).ToLocalTime()
                    checktime = price.MarketDate

                    ' WHEN USING TEXT FILE UNCOMMENT - LIVE COMMENT THIS IF THEN OUT.   Check interval against the rowid  ********************************************
                    If interval = rowid Then

                        ' COMENT OUT FOR TESTING - Determine if the price has moved setting the trigger off.   ***********************************************************
                        'If String.Format("{0:t}", markettime) = (String.Format("{0:t}", oneMinAgo.ToLocalTime)) Then

                        ' This section determines whether the interval (OHLC) data exists in the table for the symbol if it does it will bypass adding it if it does not it will add it to the bot price table by minute.
                        Dim a = From c In db.HarvestIntervals Where c.symbol = sym And c.Interval = interval And c.Date = price.MarketDate Select c    'DateTime.Now() Select c
                        Dim intervalcount = a.Count()

                        ' This is the check for the existance of the record.
                        If intervalcount = 0 Then

                            Using ds As New wavesDataContext
                                Dim newInterval As New HarvestInterval

                                TryUpdateModel(newInterval)                                 'ctime
                                Dim newintervals As New HarvestInterval With { _
                                                                                .symbol = Trim$(sym.ToUpper()), _
                                                                                .Date = DateTime.Parse(price.MarketDate), _                                                                             
                                                                                .OpenPrice = price.OpenPrice, _
                                                                                .HighPrice = price.HighPrice, _
                                                                                .LowPrice = price.LowPrice, _
                                                                                .ClosePrice = price.ClosePrice, _
                                                                                .Interval = interval, _
                                                                                .Volume = price.Volume _
                                                            }

                                db.HarvestIntervals.InsertOnSubmit(newintervals)
                                db.SubmitChanges()
                            End Using

                        End If

                        'rowdata = "Market Interval:  " & String.Format("{0:t}", markettime) & "  " & sym & "  " & "Open:  " & (String.Format("{0:C}", price.OpenPrice)) & "  " & "High:  " & (String.Format("{0:C}", price.HighPrice)) & "  " & "Low:  " &
                        '   (String.Format("{0:C}", price.LowPrice)) & "  " & "Close:  " & (String.Format("{0:C}", price.ClosePrice)) & " | " & "New Mark:  " & (String.Format("{0:C}", mark)) & stockaction & hedgeaction


                        ' Check if stock should be bought or sold.
                        ' First check if open sets the trigger for a new day or pull.
                        If price.OpenPrice < lowerTrigger Then
                            stockaction = " | Stock: BOT | "
                            hedgeaction = ""
                            mark = Math.Round(price.OpenPrice / width, 0) * width ' Int(price.LowPrice)

                            ' Update the trigger based on the prive movement.
                            ' Dim su = db.getTrigger(sym)

                            ' su.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                            ' su.priceTrigger = mark

                            ' This section will add the data to the Harvest table and works when there is a fresh open.  Will need to add user and symbol to the table  | ********************************************************
                            Dim newHarvestPosition As New HarvestPosition
                            TryUpdateModel(newHarvestPosition)                                 'ctime
                            'Dim newpos As New HarvestPosition With { _
                            '                                                .opendate = DateTime.Parse(price.MarketDate), _                                                                            
                            '                                                .symbol = sym, _
                            '                                                .userid = uID, _
                            '                                                .openprice = mark _
                            '                            }

                            'db.HarvestPositions.InsertOnSubmit(newpos)

                            'db.SubmitChanges()

                            'rowdata = String.Format("{0:t}", markettime) & "  " & sym & "  " & "Open:  " & (String.Format("{0:C}", price.OpenPrice)) & "  " & "High:  " & (String.Format("{0:C}", price.HighPrice)) & "  " & "Low:  " &
                            '(String.Format("{0:C}", price.LowPrice)) & "  " & "Close:  " & (String.Format("{0:C}", price.ClosePrice)) & " | " & "Mark:  " & (String.Format("{0:C}", mark)) & stockaction & hedgeaction

                        ElseIf price.OpenPrice > higherTrigger Then
                            mark = Math.Round(price.OpenPrice / width, 0) * width ' Int(price.LowPrice)
                            stockaction = " | Stock: SOLD  | "
                            If mark - Int(mark) = 0.0 Then
                                hedgeaction = " Hedge at: " & String.Format("{0:C}", (Int(mark) - 2.0))
                                strike = String.Format("{0:C}", (Int(mark) - 2.0))
                            ElseIf mark - Int(mark) = 0.5 Then
                                hedgeaction = " Hedge at: " & String.Format("{0:C}", (Int(mark) - 2.0))
                                strike = String.Format("{0:C}", (Int(mark) - 2.0))
                            Else
                                hedgeaction = ""
                                strike = String.Format("{0:C}", (0))
                            End If

                            ' Update the trigger based on the prive movement.
                            ' Dim tu = db.getTrigger(sym)

                            ' Determine if there is a gap up in price overnight and how significant that gap is based on your width.
                            'Dim gap As Double = (price.OpenPrice - tu.priceTrigger) / width
                            'If gap > 1.99 Then
                            '    MsgBox("Gap Up")
                            'End If

                            'Dim su = db.positionexists(mark - width, "o")
                            ' tu.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                            ' tu.priceTrigger = mark

                            db.SubmitChanges()

                            'rowdata = String.Format("{0:t}", markettime) & "  " & sym & "  " & "Open:  " & (String.Format("{0:C}", price.OpenPrice)) & "  " & "High:  " & (String.Format("{0:C}", price.HighPrice)) & "  " & "Low:  " &
                            '(String.Format("{0:C}", price.LowPrice)) & "  " & "Close:  " & (String.Format("{0:C}", price.ClosePrice)) & " | " & "Mark:  " & (String.Format("{0:C}", mark)) & stockaction & hedgeaction

                        Else
                            stockaction = ""
                        End If

                        ' This checks current high & low against the triggers to determine actions.
                        If price.LowPrice < lowerTrigger Then
                            stockaction = " | Stock: BOT | "
                            hedgeaction = ""
                            mark = Math.Round(price.LowPrice / width, 0) * width ' Int(price.LowPrice)

                            ' Update the trigger based on the prive movement.
                            ' Dim tu = db.getTrigger(sym)
                            ' tu.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                            'tu.priceTrigger = mark

                            ' Determine if the position already exists in the table.  If not then add if exists do not add.
                            'If db.posExists(sym, mark, "o") = False Then

                            '    ' Will need to add user and symbol to the table  | ********************************************************
                            '    Dim newHarvestPosition As New harvest
                            '    TryUpdateModel(newHarvestPosition)                                 'ctime
                            '    Dim newpos As New harvest With { _
                            '                                                    .status = "o", _
                            '                                                    .opendate = DateTime.Parse(price.MarketDate), _
                            '                                                    .opentime = DateTime.Parse(price.MarketDate), _
                            '                                                    .symbol = sym, _
                            '                                                    .userid = uID, _
                            '                                                    .openprice = mark _
                            '                                }

                            '    db.harvests.InsertOnSubmit(newpos)
                            'End If

                            db.SubmitChanges()

                            ' rowdata = String.Format("{0:t}", markettime) & "  " & sym & "  " & "Open:  " & (String.Format("{0:C}", price.OpenPrice)) & "  " & "High:  " & (String.Format("{0:C}", price.HighPrice)) & "  " & "Low:  " &
                            '(String.Format("{0:C}", price.LowPrice)) & "  " & "Close:  " & (String.Format("{0:C}", price.ClosePrice)) & " | " & "Mark:  " & (String.Format("{0:C}", mark)) & stockaction & hedgeaction

                        ElseIf price.HighPrice > higherTrigger Then
                            Dim hedge As Boolean = False
                            mark = Math.Round(price.HighPrice / width, 0) * width ' Int(price.LowPrice)
                            stockaction = " | Stock: SOLD | "
                            If mark - Int(mark) = 0.0 Then
                                hedgeaction = " Hedge at: " & String.Format("{0:C}", (Int(mark) - 2.0))
                                strike = String.Format("{0:C}", (Int(mark) - 2.0))
                                hedge = True
                            ElseIf mark - Int(mark) = 0.5 Then
                                hedgeaction = " Hedge at: " & String.Format("{0:C}", (Int(mark) - 2.0))
                                strike = String.Format("{0:C}", (Int(mark) - 2.0))
                                hedge = True
                            Else
                                hedgeaction = ""
                                hedge = False
                            End If

                            ' Update the trigger based on the prive movement.
                            ' Dim tu = db.getTrigger(sym)
                            ' tu.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                            ' tu.priceTrigger = mark

                            'Dim pe As Boolean = db.posExists(mark - width, "0")

                            'If db.posExists(sym, mark - width, "o") = True Then
                            '    Dim su = db.positionexists(sym, mark - width, "o")

                            '    su.closedate = DateTime.Parse(price.MarketDate)
                            '    su.closetime = DateTime.Parse(price.MarketDate)
                            '    su.closeprice = mark
                            '    su.status = "c"
                            '    su.hedge = hedge
                            '    If hedge = True Then
                            '        su.strike = strike
                            '    End If
                            'End If

                            'db.SubmitChanges()

                            ' rowdata = String.Format("{0:t}", markettime) & "  " & sym & "  " & "Open:  " & (String.Format("{0:C}", price.OpenPrice)) & "  " & "High:  " & (String.Format("{0:C}", price.HighPrice)) & "  " & "Low:  " &
                            '(String.Format("{0:C}", price.LowPrice)) & "  " & "Close:  " & (String.Format("{0:C}", price.ClosePrice)) & " | " & "Mark:  " & (String.Format("{0:C}", mark)) & stockaction & hedgeaction

                        Else
                            stockaction = ""
                        End If


                        ' This area is where the row data is built one area at a time to ease editing later.   & String.Format("{0:T}", currenttime) & " | " & "Market Time:  "
                        rowdata = String.Format("{0:t}", markettime) & "  " & sym & "  " & "Open:  " & (String.Format("{0:C}", price.OpenPrice)) & "  " & "High:  " & (String.Format("{0:C}", price.HighPrice)) & "  " & "Low:  " &
                       (String.Format("{0:C}", price.LowPrice)) & "  " & "Close:  " & (String.Format("{0:C}", price.ClosePrice)) & " | " & "Mark:  " & (String.Format("{0:C}", mark)) & stockaction & hedgeaction
                        'End If
                    End If
                    ' Increase the interval to find the time based on interval --> Comment it out when live.
                    interval = interval + 1

                Next

            End Using
            'If rowdata = "" Then
            '    Return RedirectToAction("viewharvest", "member")
            'End If
            Dim datastring As String = rowdata & "  " & (String.Format("{0:T}", currenttime.Subtract(New TimeSpan(0, 0, 0)).ToLocalTime)) '& " Timestamp:  " & (String.Format("{0:t}", oneMinAgo.ToLocalTime))

            Return Content(datastring)
        End Function

        Function Automate() As ActionResult

            ' **********************************************************************************************************************************************************
            ' Function:         Automate - Robot Base Functions 
            ' Written By:       Troy Belden
            ' Date Written:     November, 17 2016
            ' Last Updated:     November, 17 2016
            ' Details:          This function initiate the trading robot. It pulls (scrapes) one of two sites to make sure that the data is available. It stores each record per 
            '                   minute in the database tables and performs the analytics on the variables that it pulls. In phase I the robot will alert the user to perform   
            '                   an action based on the strategy and triggers. In phase II the robot will carry out those actions in either an API format or sendkeys.
            '                   All of the data as well as the results will be logged in the tables with associated profit and loss calculations made in the views.
            ' **********************************************************************************************************************************************************
            ' MsgBox(pd & "|" & wid.ToString())
            Dim symbol As String = "VXX"
            Dim width As Double = 0.25
            Dim priceDate As DateTime = Today.Date

            ' Pull all prices for today 
            'Using db As New wavesDataContext

            'Dim model As New wavesViewModel With { _
            '                                         .getTrigger = db.getTrigger(symbol), _
            '                                         .AllPrices = db.GetPriceList(symbol, priceDate) _
            '                                       }

            '    ViewData("width") = width
            '    ViewData("symbol") = symbol

            '    For Each item In model.AllPrices
            '        If item.Interval = 0 Then
            '            ViewData("Trigger") = model.getTrigger.priceTrigger
            '            ' ViewData("Trigger") = Int(item.OpenPrice) + width
            '        End If
            '    Next

            '    Return View(model)

            'End Using

            Return View()
        End Function
        <HttpGet> _
        Function dataset() As ActionResult
            Return View()
        End Function
        <HttpPost> _
        Function CreateText(ByVal symbol As String, ByVal filedate As DateTime) As ActionResult

            ' Define variables
            Dim sym As String = symbol.ToUpper()
            Dim qurl As String = ""
            Dim csvdata As String = ""
            Dim filemonth As String = Month(filedate).ToString()
            Dim fileday As String = Day(filedate).ToString()
            Dim fileyear As String = Year(filedate).ToString()
            Dim filedte As String = filemonth & fileday & fileyear

            ' PULL DATA FOR PRODUCT FROM THE INTERNET - THE FREQUENCY OF THE PULL IS SET IN THE VIEW USING JAVASCRIPT.  Pulls Yahoo as it is more consistent in various products.
            ' TODO: build out conditional checks 1. nonMarket days. 2. time period before market opens. 3. time period after market closes. 4. failure in link 1 to pull link 2.
            Using web As New WebClient()

                qurl = "http://chartapi.finance.yahoo.com/instrument/1.0/" & sym.ToUpper
                qurl = qurl & "/chartdata;type=quote;range=1d/csv"

                'qurl = "https://www.google.com/finance/getprices?i=60&p=1d&f=d,o,h,l,c,v&df=cpct&q=" & sym

                ' Uncomment this after testing
                csvdata = web.DownloadString(qurl)

                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter("c:\Users\Prime\Desktop\symbols\" & sym & "-" & filedte & ".txt", False)
                file.WriteLine(csvdata)
                file.Close()

            End Using
            ' MsgBox("Done")

            Return RedirectToAction("dataset", "member")

        End Function

        Function startbot(ByVal testdata As String, ByVal pos As String) As ActionResult
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
                        MsgBox("in")
                        Dim test As String = ""
                        If price.LowPrice < lTrigger Then
                            datastring = (String.Format("{0:T}", Now().Subtract(New TimeSpan(0, 1, 0)).ToLocalTime)) & "    Symbol: " & sym & "    Mark: " & (String.Format("{0:C}", mark)) & "    Open: " & (String.Format("{0:C}", price.OpenPrice)) & "    High: " & (String.Format("{0:C}", price.HighPrice)) & "    Low: " & (String.Format("{0:C}", price.LowPrice)) & "    Close: " & (String.Format("{0:C}", price.ClosePrice)) & "    Vol: " & (String.Format("{0:##,##0}", price.Volume)) & "   BOT"
                            mark = Math.Round(price.LowPrice / width, 0) * width ' Int(price.LowPrice)

                            ' Update the trigger based on the prive movement.
                            'Dim su = db.getTrigger(sym)

                            'su.DateAndTime = DateTime.Parse(Now()).ToUniversalTime()
                            'su.priceTrigger = mark

                            'db.SubmitChanges()

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
                    Else
                        'datastring = (String.Format("{0:T}", Now().ToShortTimeString)) & "    Symbol: " & sym & "   Market Closed."
                    End If

                End Using

            Next

            ' Check current time and determine if market is still open or not.

            Return Content(datastring)
        End Function

        Function GetData(ByVal sym As String) As ActionResult

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
            Dim interval As Integer = 0 'String = ""
            Dim csvData As String
            Dim qurl As String
            Dim loops As Integer = 0

            Dim odate As Date = #8:30:00 AM#
            Dim curdate As Date = Now()
            Dim cldate As Date = #3:00:00 PM#
            Dim datastring As String = ""
            Dim postmin As Date = #8:30:00 AM#
            Dim ctime As Date = Now()

            ' Pull all prices for today 


            ' PULL DATA FOR PRODUCT FROM THE INTERNET - First check google finance for the data. If the data does not exist there then pull the Yahoo 
            ' TODO: build out conditional checks 1. nonMarket days. 2. time period before market opens. 3. time period after market closes. 4. failure in link 1 to pull link 2.
            Using web As New WebClient()

                qurl = "http://chartapi.finance.yahoo.com/instrument/1.0/" & sym.ToUpper()
                qurl = qurl & "/chartdata;type=quote;range=1d/csv"

                'qurl = "https://www.google.com/finance/getprices?i=60&p=1d&f=d,o,h,l,c,v&df=cpct&q=" & sym.ToUpper()

                csvData = web.DownloadString(qurl)
                'MsgBox(csvData)
            End Using

            ' MsgBox(Len(sym).ToString())


            ' Parses the CSV data into fields based on 
            Dim prices As List(Of Price) = ParseYahoo(csvData)
            'Dim prices As List(Of Price) = ParseGoogle(csvData)

            ' Once the CSV file has been parsed it needs to be added to the table if it doesn't already exist.
            For Each price As Price In prices
                ' If Mid(price.MarketDate, 1, 1) = "a" Then
                'interval = "0"
                'Else
                'interval = price.MarketDate.ToString()
                'End If

                ' Determine the minute interval that is being added.

                'ctime = odate.AddMinutes(interval)


                Using db As New wavesDataContext

                    '    ' Get total members and load it to a ViewData variable.
                    '  Dim a = From c In db.botPrices Where c.symbol = sym And c.Interval = interval And c.Date = DateTime.Now() Select c
                    ' Dim intervalcount = a.Count()

                    ' If intervalcount = 0 then record does not already exist add the record else loop.
                    'If intervalcount = 0 Then
                    ' Add the new record.
                    'If symbolexists = false add the symbol and set today as the firstissued date value
                    Dim newInterval As New HarvestInterval

                    TryUpdateModel(newInterval)                                 'ctime
                    Dim newintervals As New HarvestInterval With { _
                                                                    .symbol = Trim$(sym.ToUpper()), _
                                                                    .Date = DateTime.Parse(price.MarketDate).ToShortDateString(), _
                                                                    .OpenPrice = price.OpenPrice, _
                                                                    .HighPrice = price.HighPrice, _
                                                                    .LowPrice = price.LowPrice, _
                                                                    .ClosePrice = price.ClosePrice, _
                                                                    .Interval = interval, _
                                                                    .Volume = price.Volume _
                                                }

                    db.HarvestIntervals.InsertOnSubmit(newintervals)
                    db.SubmitChanges()
                    'End If
                End Using
                interval = interval + 1
            Next

            MsgBox("Records Added")
            Return RedirectToAction("automate", "member")
            'Return View()
        End Function

        Function viewHarvest() As ActionResult
            ' **********************************************************************************************************************************************************
            ' Function:         Display data 
            ' Written By:       Troy Belden
            ' Date Written:     November, 17 2016
            ' Last Updated:     November, 17 2016
            ' Details:          This function initiate the trading robot. It pulls (scrapes) one of two sites to make sure that the data is available. It stores each record per 
            '                   minute in the database tables and performs the analytics on the variables that it pulls. In phase I the robot will alert the user to perform   
            '                   an action based on the strategy and triggers. In phase II the robot will carry out those actions in either an API format or sendkeys.
            '                   All of the data as well as the results will be logged in the tables with associated profit and loss calculations made in the views.
            ' **********************************************************************************************************************************************************
            ' MsgBox(pd & "|" & wid.ToString())
            Dim symbol As String = "VXX"
            Dim width As Double = 0.25
            Dim profit As Double = 0.0
            ' Dim priceDate As DateTime = viewdate '#11/25/2016#

            ' Pull all prices for today 
            Using db As New wavesDataContext

                'Dim model As New wavesViewModel With { _
                '                                         .getTrigger = db.getTrigger(symbol), _
                '                                         .AllHarvestPrices = db.GetHarvestList(symbol) _
                '                                       }

                ' This section determines whether the interval (OHLC) data exists in the table for the symbol if it does it will bypass adding it if it does not it will add it to the bot price table by minute.
                'Dim a = From c In db.harvests Where c.symbol = symbol And c.status = "c" Select c
                'Dim b = From c In db.harvests Where c.symbol = symbol Select c
                'Dim harvestcount = a.Count()

                'ViewData("closed") = a.Count
                'ViewData("total") = b.Count
                'ViewData("open") = b.Count - a.Count
                'ViewData("symbol") = symbol

                'For Each item In model.AllHarvestPrices
                '    If item.status = "c" Then
                '        profit = profit + (item.closeprice - item.openprice) * 100
                '        '        ViewData("Trigger") = model.getTrigger.priceTrigger
                '        '        ' ViewData("Trigger") = Int(item.OpenPrice) + width
                '    End If
                'Next
                'ViewData("profit") = profit
                ''Return PartialView("_list", model)
                'Return View(model)

            End Using
            Return View()
        End Function

        Function DisplayData(ByVal sym As String, ByVal wid As Double, ByVal viewdate As DateTime) As ActionResult

            ' **********************************************************************************************************************************************************
            ' Function:         Display data 
            ' Written By:       Troy Belden
            ' Date Written:     November, 17 2016
            ' Last Updated:     November, 17 2016
            ' Details:          This function initiate the trading robot. It pulls (scrapes) one of two sites to make sure that the data is available. It stores each record per 
            '                   minute in the database tables and performs the analytics on the variables that it pulls. In phase I the robot will alert the user to perform   
            '                   an action based on the strategy and triggers. In phase II the robot will carry out those actions in either an API format or sendkeys.
            '                   All of the data as well as the results will be logged in the tables with associated profit and loss calculations made in the views.
            ' **********************************************************************************************************************************************************
            ' MsgBox(pd & "|" & wid.ToString())
            Dim symbol As String = sym '"FCX"
            Dim width As Double = wid ' 0.25
            Dim priceDate As DateTime = viewdate '#11/25/2016#

            ' Pull all prices for today 
            Using db As New wavesDataContext

                'Dim model As New wavesViewModel With { _
                '                                         .getTrigger = db.getTrigger(symbol), _
                '                                         .AllPrices = db.GetPriceList(symbol, priceDate) _
                '                                       }

                'ViewData("width") = width
                'ViewData("symbol") = sym

                'For Each item In model.AllPrices
                '    If item.Interval = 0 Then
                '        ViewData("Trigger") = model.getTrigger.priceTrigger
                '        ' ViewData("Trigger") = Int(item.OpenPrice) + width
                '    End If
                'Next

                ' Return PartialView("_list", model)
                Return View()
            End Using

        End Function

        Function backdata() As ActionResult

            ' Variables to be used in this function
            Dim csvdata As String
            Dim mktdate As DateTime


            ' Text Reader that reads the CSV file to be extracted and loaded into the table.   TODO: Do I want to use a file selector for this?
            Using textReader As New System.IO.StreamReader("C:\Users\Prime\Desktop\stockprices\allstocks_20161101\" & "table_" & "vxx.csv")
                csvdata = textReader.ReadToEnd
            End Using

            ' Parses the CSV data into fields based on 
            Dim backprices As List(Of backPrice) = ParseBackData(csvdata)

            ' Once the CSV file has been parsed it needs to be added to the table if it doesn't already exist.
            For Each price As backPrice In backprices

                ' Extract and format market date and time from the file into table format.
                mktdate = DateTime.Parse(Left(Right(price.MarketDate, 4), 2) & "/" & Right(price.MarketDate, 2) & "/" & Left(price.MarketDate, 4))

                If price.MarketTime.Length < 4 Then
                    mktdate = DateTime.Parse(mktdate & " " & (Left(price.MarketTime, 1) & ":" & (Right(price.MarketTime, 2))))
                    If Left(price.MarketTime, 1) & ":" & (Right(price.MarketTime, 2)) > #8:29:00 AM# Then
                        MsgBox(mktdate)
                    End If
                Else
                    mktdate = DateTime.Parse(mktdate & " " & (Left(price.MarketTime, 2) & ":" & (Right(price.MarketTime, 2))))
                    If Left(price.MarketTime, 2) & ":" & (Right(price.MarketTime, 2)) > #8:29:00 AM# Then
                        MsgBox(mktdate)
                    End If
                End If


                'MsgBox(mktdate) ' & " " & price.MarketTime & " " & price.OpenPrice & " " & price.HighPrice & " " & price.LowPrice & " " & price.ClosePrice & " " & price.Volume)

            Next

            Return RedirectToAction("automate", "member")
        End Function

        Private Function ParseYahoo(csvData As String) As List(Of Price)
            Dim rowcntr As String = 1
            Dim prices As New List(Of Price)()
            Dim nTimestamp As Double = 0.0
            Dim nDateTime As DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)

            For Each row As String In rows
                ' Determine if the data exists for the google data pull.
                If rowcntr > 17 Then

                    'MsgBox(row)

                    If String.IsNullOrEmpty(row) Then
                        'MsgBox("NEED TO PULL YAHOO DATA")
                        Continue For
                    End If

                    Dim cols As String() = row.Split(","c)

                    If cols(0) = "Date" Then
                        Continue For
                    End If

                    nTimestamp = cols(0)
                    nDateTime = nDateTime.AddSeconds(nTimestamp)

                    Dim p As New Price()
                    p.MarketDate = nDateTime
                    p.ClosePrice = Convert.ToDecimal(cols(1))
                    p.HighPrice = Convert.ToDecimal(cols(2))
                    p.LowPrice = Convert.ToDecimal(cols(3))
                    p.OpenPrice = Convert.ToDecimal(cols(4))
                    p.Volume = Convert.ToDecimal(cols(5))

                    prices.Add(p)

                End If

                rowcntr = rowcntr + 1
                nDateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
            Next

            Return prices
        End Function

        Private Function Parse(csvData As String) As List(Of Price)
            Dim rowcntr As String = 1
            Dim prices As New List(Of Price)()

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)

            For Each row As String In rows
                ' Determine if the data exists for the google data pull.
                If rowcntr > 7 Then

                    If String.IsNullOrEmpty(row) Then
                        'MsgBox("NEED TO PULL YAHOO DATA")
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

        Private Function ParseBackData(csvData As String) As List(Of backPrice)
            Dim rowcntr As String = 1
            Dim backprices As New List(Of backPrice)()

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)

            For Each row As String In rows

                If String.IsNullOrEmpty(row) Then
                    Continue For
                End If

                Dim cols As String() = row.Split(","c)

                If cols(0) = "Date" Then
                    Continue For
                End If

                Dim p As New backPrice()
                p.MarketDate = cols(0)
                p.MarketTime = cols(1)
                p.OpenPrice = Convert.ToDecimal(cols(2))
                p.HighPrice = Convert.ToDecimal(cols(3))
                p.LowPrice = Convert.ToDecimal(cols(4))
                p.ClosePrice = Convert.ToDecimal(cols(5))
                p.Volume = Convert.ToDecimal(cols(6))

                backprices.Add(p)

                rowcntr = rowcntr + 1

            Next

            Return backprices
        End Function

    End Class
End Namespace
