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
    Public Class memberController
        Inherits System.Web.Mvc.Controller

        Function Index() As ActionResult
            Return View()
        End Function

        Function experimentsettings() As ActionResult
            ' Use the datacontext to get the data needed.
            Using db As New wavesDataContext
                ' Get all of the symbols from the weeklys data table.
                Dim model As New wavesViewModel With { _
                                                       .AllExperiments = db.GetAllExperiments() _
                                                       }

                Return View(model)
                'Return View()
            End Using
        End Function

        <HttpPost()> _
        Function addexperiment(ByVal expname As String, ByVal expsymbol As String, ByVal exptrigger As Double, ByVal expwidth As Double) As ActionResult

            Dim harvestkey = New StringBuilder(12).AppendRandomString(12).ToString()                                                                                ' GENERATE A RANDOM STRING OF 12 CHARACTERS AS A KEY TO BE USED TO TAG EXPERIMENTS TO OUTCOMES.

            Using db As New wavesDataContext                                                                                                                        ' OPEN THE DATA CONTEXT FOR THE DATABASE.

                Dim userid = db.GetUserIdForUserName("csquared20")                                                                                                  ' GET THE USERID FROM USERNAME. (THIS WILL HAVE TO BE EDITED WHEN SECURITY IS INSTALLED.)

                Dim newHarvestIndex As New HarvestIndex                                                                                                             ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                TryUpdateModel(newHarvestIndex)                                                                                                                     ' TEST CONNECTION TO DATABASE TABLES.
                Dim newindex As New HarvestIndex With { _
                                                .active = True, _
                                                .product = expsymbol.ToUpper, _
                                                .userID = userid, _
                                                .name = expname, _
                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                .harvestKey = harvestkey, _
                                                .opentrigger = exptrigger, _
                                                .width = expwidth _
                                            }                                                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                db.HarvestIndexes.InsertOnSubmit(newindex)                                                                                                          ' INSERT THE NEW RECORD TO BE ADDED.
                db.SubmitChanges()                                                                                                                                  ' SUBMIT THE CHANGES TO THE TABLE.

            End Using

            Return RedirectToAction("member", "experimentsettings")
        End Function

        Function blank() As ActionResult
            Return View()
        End Function

        Function dataset() As ActionResult
            Return View()
        End Function

        Function loaddata() As ActionResult
            Return View()
        End Function

        <HttpPost> _
        Function loaddataset(ByVal symbol As String, ByVal filedate As String) As ActionResult

            ' **********************************************************************************************************************************************************
            ' Function:         backdata
            ' Written By:       Troy Belden
            ' Date Written:     December, 20 2016
            ' Last Updated:     December, 20 2016
            ' Details:          This functon receives the symbol and date information from the view. A text file is then read, parsed and intervals are added to the 
            '                   prices table by minute. The open high low close are checked to determine if an event is triggered and the mark reset. These events will
            '                   serve as tests until such time as the system connects to the API to trigger buy and sell orders and record closed trades.
            ' **********************************************************************************************************************************************************

            ' VAIRABLES USED IN THIS FUNCTION

            Dim csvdata As String                                                                                                                                               ' USED TO HOUSE THE TEXT FILE 
            Dim username As String = "csquared20"                                                                                                                               ' USERNAME TO GET USER ID.  ---> WHEN READY FOR PRODUCTION SET TO USER.IDENTITY.NAME (WILL HAVE TO SET TO <AUTHORIZED> _)
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                ' BASE PATH OF THE FILE TO BE READ INTO MEMORY.
            Dim loopcounter As Integer = 0                                                                                                                                      ' LOOPCOUNTER USED TO TRACK LOOPS AND SET INTERVAL COUNTER

            ' **********  OPEN THE DATABASE **********
            Using db As New wavesDataContext                                                                                                                                    ' OPEN THE DATA CONTEXT FOR THE DATABASE.

                Using textReader As New System.IO.StreamReader(path & filedate & "\table_" & symbol & ".csv")                                                                   ' TEXT READER PULLS AND READS THE FILE.
                    csvdata = textReader.ReadToEnd                                                                                                                              ' LOAD THE ENTIRE FILE INTO THE STRING.
                End Using                                                                                                                                                       ' CLOSE THE TEXT READER.

                Dim backprices As List(Of backPrice) = ParseBackData(csvdata)                                                                                                   ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.

                For Each price As backPrice In backprices                                                                                                                       ' LOOP THROUGH EACH ROW OF THE PRICES FOR THE DATE SELECTED.
                    ' ********** STEP 1: ADD THE RECORD TO THE INTERVAL PRICE TABLE IF IT DOES NOT ALREADY EXIST  ******************
                    Dim a = From c In db.HarvestIntervals Where c.symbol = symbol And c.Interval = loopcounter And c.Date = price.MarketDate Select c                             ' QUERY THE DATABASE TO DETERMINE IF THAT INTERVAL RECORD ALREADY EXISTS IN THE TABLE.

                    ' If the record does not exist then add it to the table.
                    If a.Count = 0 Then                                                                                                                                         ' IF THE RECORD DOES NOT EXIST THE COUNT WILL BE 0. IF 0 THEN ADD A NEW INTERVAL RECORD TO THE TABLE.

                        Dim newInterval As New HarvestInterval

                        TryUpdateModel(newInterval)
                        Dim newintervals As New HarvestInterval With { _
                                                                        .timestamp = DateTime.Parse(Now().ToUniversalTime()), _
                                                                        .Date = DateTime.Parse(price.MarketDate).ToUniversalTime(), _
                                                                        .Interval = loopcounter, _
                                                                        .symbol = symbol.ToUpper, _
                                                                        .OpenPrice = price.OpenPrice, _
                                                                        .HighPrice = price.HighPrice, _
                                                                        .LowPrice = price.LowPrice, _
                                                                        .ClosePrice = price.ClosePrice, _
                                                                        .Volume = price.Volume _
                                                    }                                                                                                                           ' POPULATE THE FILE STRUCTURE OF THE RECORD TO BE ADDED.

                        db.HarvestIntervals.InsertOnSubmit(newintervals)                                                                                                          ' PREPARES THE STRUCTURE TO INSERT THE NEW RECORD.
                        db.SubmitChanges()                                                                                                                                      ' SUBMITS THE RECORD TO THE DATA TABLES.
                    End If
                    loopcounter = loopcounter + 1
                Next
            End Using

            Return RedirectToAction("blank", "member")
        End Function
    
        Function backtest() As ActionResult

            Using db As New wavesDataContext

                Dim indexlist = (From m In db.HarvestIndexes Select m).ToList()
                Dim loglist = (From m In db.HarvestLogs Select m).ToList()

                Dim model As New wavesViewModel()
                model.AllIndexes = indexlist
                model.AllLogs = loglist

                Return View(model)

            End Using

            'Return View(model)
        End Function

        Function yahoodata(ByVal robotsymbol As String, ByVal robotdate As String, ByVal rowid As Integer) As ActionResult
            Dim datastring As String = "yahoo"
            Return Content(datastring)
        End Function

        <HttpPost> _
        Function runbacktest(ByVal robotsymbol As String, ByVal robotdate As String, ByVal robotindex As String, ByVal rowid As Integer) As ActionResult

            ' **********************************************************************************************************************************************************
            ' Function:         backdata
            ' Written By:       Troy Belden
            ' Date Written:     December, 20 2016
            ' Last Updated:     December, 20 2016
            ' Details:          This functon receives the symbol and date information from the view. A text file is then read, parsed and intervals are added to the 
            '                   prices table by minute. The open high low close are checked to determine if an event is triggered and the mark reset. These events will
            '                   serve as tests until such time as the system connects to the API to trigger buy and sell orders and record closed trades.
            ' **********************************************************************************************************************************************************

            ' MsgBox(robotindex.ToString())

            ' VAIRABLES USED IN THIS FUNCTION
            Dim userid As Guid                                                                                                                                                      ' USERID ADDED TO RECORDS FOR EACH USER
            Dim csvdata As String                                                                                                                                                   ' USED TO HOUSE THE TEXT FILE 
            Dim username As String = "csquared20"                                                                                                                                   ' USERNAME TO GET USER ID.  ---> WHEN READY FOR PRODUCTION SET TO USER.IDENTITY.NAME (WILL HAVE TO SET TO <AUTHORIZED> _)
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                    ' BASE PATH OF THE FILE TO BE READ INTO MEMORY.
            Dim datastring As String = ""
            Dim loopcounter As Integer = 0                                                                                                                                          ' COUNTER FOR THE ROWS TO BE PROCESSED.
            Dim mark As Double = 0                                                                                                                                                  ' HOLDS THE CURRENT PRICE OF THE MARK.
            Dim width As Double = 0                                                                                                                                             ' THE WIDTH OF THE TRIGGERS - THIS WILL BE PULLED FROM THE CONTROL CARD OF THE USER
            Dim trigger As Double = 0                                                                                                                                               ' HOLDS THE TRIGGER WHICH IS BASED ON THE WIDTH MINUS .01 
            Dim gap As Double = 0                                                                                                                                                   ' HOLDS THE DIFFERENCE BETWEEN THE PRICE AND THE MARK.
            Dim gappositions As Double = 0                                                                                                                                          ' DETERMINES THE NUMBER OF LEVELS THAT A PRICE HAS GAPPED.
            Dim gapcntr As Double = 0                                                                                                                                               ' LOOP COUNTER WHEN A GAP EXISTS.
            Dim hedgestatus As String = ""                                                                                                                                          ' INDICATOR FOR THE VIEW IF THE CLOSED POSITION TRIGGERS A HEDGE.
            ' Dim hedgeupdate As Boolean                                                                                                                                            ' HEDGE TRIGGER FOR THE TABLE BASED ON THE CLOSED POSITION TRIGGERING A NEED FOR A HEDGE.
            Dim strike As Double = 0                                                                                                                                                ' INDICATOR OF THE STRIKE TO SELECT FOR THE HEDGE.
            Dim direction As String = ""                                                                                                                                            ' INDICATOR OF THE INTERVAL GOING UP OR DOWN - OPEN TO CLOSE.
            Dim symbol As String = robotsymbol.ToUpper()                                                                                                                            ' SYMBOL OF THE PRODUCT SELECTED FOR THE AUTOMATED SYSTEM.
            Dim markettime As New DateTime
            Dim marketdate As New DateTime
            Dim openpricegreater As String = ""
            Dim highpricegreater As String = ""
            Dim closepricegreater As String = ""
            Dim openpricelower As String = ""
            Dim lowpricelower As String = ""
            Dim closepricelower As String = ""

            Dim checkOpenMark As Double = 0
            Dim OpenMark As Double = 0                                                                                                                                              ' HOLDS THE NEW MARK BASED ON THE MOVEMENT OF PRICE IN THE INTERVAL AND TRIGGER POINTS HIT.
            Dim HighMark As Double = 0
            Dim LowMark As Double = 0
            Dim CloseMark As Double = 0
            Dim EndMark As Double = 0
            Dim triggercounter As Integer = 0
            Dim buys As Integer = 0
            Dim sells As Integer = 0

            Dim openstatus As String = ""
            Dim highstatus As String = ""
            Dim lowstatus As String = ""
            Dim closestatus As String = ""

            Dim processReport As String = ""

            'robotdate = "20160104"
            'robotsymbol = "VXX"
            ' **********  OPEN THE DATABASE **********
            Using db As New wavesDataContext

                ' ********** STEP 1: READ DATA INTO PRICE OBJECT **********

                Using textReader As New System.IO.StreamReader(path & robotdate & "\table_" & robotsymbol & ".csv")                                                             ' TEXT READER PULLS AND READS THE FILE.
                    csvdata = textReader.ReadToEnd                                                                                                                              ' LOAD THE ENTIRE FILE INTO THE STRING.
                End Using                                                                                                                                                       ' CLOSE THE TEXT READER.

                userid = db.GetUserIdForUserName(username)                                                                                                                      ' GET THE USERID FROM USERNAME. (THIS WILL HAVE TO BE EDITED WHEN SECURITY IS INSTALLED.)

                Dim hi = db.GetHarvestIndex(robotindex, True)

                Dim backprices As List(Of backPrice) = ParseBackData(csvdata)                                                                                                   ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.

                ' ********** STEP 2: PROCESS EACH RECORD IN PRICE OBJECT **********

                For Each price As backPrice In backprices                                                                                                                       ' LOOP THROUGH EACH ROW OF THE PRICES FOR THE DATE SELECTED.

                    direction = checkdirection(price.OpenPrice, price.HighPrice, price.LowPrice, price.ClosePrice)                                                                              ' CALL FUNCTION TO CHECK DIRECTION AND RETURN THE INDICATOR.
                    markettime = String.Format("{0:t}", price.MarketDate)                                                                                                                       ' FORMAT MARKETTIME FOR PRESENTATION.

                    If rowid = 0 Then

                        Dim newHarvestLog As New HarvestLog
                        TryUpdateModel(newHarvestLog)                                                                                                                  ' TEST CONNECTION TO DATABASE TABLES.
                        Dim newlog As New HarvestLog With { _
                                                        .opens = 0, _
                                                        .closes = 0, _
                                                        .harvestkey = robotindex.ToUpper, _
                                                        .userid = userid, _
                                                        .marketdate = Date.Parse(price.MarketDate).ToUniversalTime(), _
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .otimestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .trans = 0 _
                                                   }                                                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.HarvestLogs.InsertOnSubmit(newlog)                                                                                                                  ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SubmitChanges()

                    End If

                    If loopcounter = rowid Then

                        ' CHECK TO SEE IF THIS INTERVAL HAS BEEN ADDED TO THE HARVESTINTERVALS TABLE.  IF NOT ADD IT, IF SO DO NOT ADD IT.
                        ' ADD THIS CODE ONCE THE TESTING OF THE OPEN, HIGH, LOW, AND CLOSE HAS BEEN COMPLETED.

                        datastring = String.Format("{0: hh:mm tt}", markettime)                                                                                                                 ' SETS THE TIME FOR THE ROW INTERVAL.
                        datastring = datastring & " " & robotsymbol.ToUpper() & " " & direction                                                                                                 ' SETS THE SYMBOL, AND DIRECTION FOR THE ROW INTERVAL.

                        OpenMark = getOpenMark(symbol, userid, price.OpenPrice, price.MarketDate, hi.harvestKey)                                                                               ' CALLED FUNCTION TO GO GET THE OPENING MARK PRICE VALUE.

                        datastring = datastring & " M: " & (String.Format("{0:C}", OpenMark))                                                                                                   ' SETS THE OPENING MARK FOR THE ROW INTERVAL.

                        If loopcounter = 0 Then
                            datastring = datastring & CheckOpenPrice(symbol, userid, price.OpenPrice, price.MarketDate, OpenMark, 0, hi.width, hi.harvestKey)
                        Else
                            datastring = datastring & CheckOpenPrice(symbol, userid, price.OpenPrice, price.MarketDate, OpenMark, 1, hi.width, hi.harvestKey)
                        End If

                        If direction = "U" Then

                            ' CHECK THE LOW PRICE
                            OpenMark = getOpenMark(symbol, userid, price.LowPrice, price.MarketDate, hi.harvestKey)                                                                            ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckLowPrice(symbol, userid, price.LowPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey)                                                 ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE HIGH PRICE
                            OpenMark = getOpenMark(symbol, userid, price.HighPrice, price.MarketDate, hi.harvestKey)                                                                           ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckHighPrice(symbol, userid, price.HighPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey)                                               ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE CLOSING PRICE
                            OpenMark = getOpenMark(symbol, userid, price.ClosePrice, price.MarketDate, hi.harvestKey)                                                                          ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckClosePrice(symbol, userid, price.ClosePrice, price.MarketDate, OpenMark, direction, hi.width, hi.harvestKey)                                  ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                        Else

                            ' CHECK THE HIGH PRICE
                            OpenMark = getOpenMark(symbol, userid, price.HighPrice, price.MarketDate, hi.harvestKey)                                                                           ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckHighPrice(symbol, userid, price.HighPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey)                                               ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE LOW PRICE
                            OpenMark = getOpenMark(symbol, userid, price.LowPrice, price.MarketDate, hi.harvestKey)                                                                            ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckLowPrice(symbol, userid, price.LowPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey)                                                 ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE CLOSING PRICE
                            OpenMark = getOpenMark(symbol, userid, price.ClosePrice, price.MarketDate, hi.harvestKey)                                                                          ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckClosePrice(symbol, userid, price.ClosePrice, price.MarketDate, OpenMark, direction, hi.width, hi.harvestKey)                                  ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                        End If

                    End If

                    loopcounter = loopcounter + 1
                    rowid = rowid + 1
                    marketdate = price.MarketDate
                Next

                'Dim om = db.getopenmark(symbol, userid, hi.harvestKey)                                                                                                                 ' PULL THE OPEN MARK RECORD.
                'mark = om.mark

                'Dim ul = db.getlog(hi.harvestKey, Date.Parse(marketdate).ToUniversalTime())
                'ul.closingmark = mark

                'db.SubmitChanges()

            End Using
            MsgBox("Done")
            Return RedirectToAction("backtest", "member")
            'Return Content(datastring)
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

        Private Function ParseBackData(csvData As String) As List(Of backPrice)
            Dim rowcntr As Integer = 0
            Dim backprices As New List(Of backPrice)()
            Dim marketdatetime As DateTime
            Dim marketdate As String

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
                'p.Volume = Convert.ToDecimal(cols(6))



                marketdate = DateTime.Parse(Left(Right(p.MarketDate, 4), 2) & "/" & Right(p.MarketDate, 2) & "/" & Left(p.MarketDate, 4))
                marketdatetime = getdatetime(marketdate, p.MarketTime)
                p.MarketDate = marketdatetime

                ' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
                If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then
                    If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then                                                                           ' CHANGE BACK TO 4:01:00 PM
                        p.interval = rowcntr
                        backprices.Add(p)
                        rowcntr = rowcntr + 1
                    End If
                End If



            Next

            Return backprices
        End Function

        Function getdatetime(ByVal marketdate As String, ByVal markettime As String) As String
            Dim dateandtime As String = ""
            If markettime.Length < 4 Then
                dateandtime = DateTime.Parse(marketdate & " " & Left(markettime, 1) & ":" & Right(markettime, 2))
            Else
                dateandtime = DateTime.Parse(marketdate & " " & Left(markettime, 2) & ":" & Right(markettime, 2))
            End If
            Return dateandtime
        End Function

        Function checkdirection(ByVal openprice As Double, ByVal highprice As Double, ByVal lowprice As Double, ByVal closeprice As Double) As String
            Dim direction As String = ""                                                                                                                                        ' CLEAR THE DIRECTION VARIABLE TO START THE FUNCTION.
            If closeprice > openprice Then                                                                                                                                      ' IF CLOSE PRICE GREATER THAN OPEN PRICE THEN OVERALL DIRECTION OF INTERVAL IS UP.
                direction = "U"                                                                                                                                                 ' SET DIRECTION VARIABLE TO UP LOWER.            
            Else
                direction = "D"                                                                                                                                                 ' SET THE DIRECTION VARIABLE TO LOW HIGHER.            
            End If

            Return direction                                                                                                                                                    ' RETURN THE DIRECTION VARIABLE WITH ITS SET VALUE.
        End Function

        Function getOpenMark(ByVal symbol As String, ByVal userid As Guid, ByVal openprice As Double, ByVal marketdate As Date, ByVal harvestkey As String) As Double
            Dim OpenMark As Double = 0

            Using db As New wavesDataContext

                If db.markExists(symbol, userid) = True Then                                                                                                            ' CALL FUNCTION TO DETERMINE IF A RECORD CONTAINING A MARK EXISTS FOR THIS PRODUCT & USER.
                    Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                             ' PULL THE OPEN MARK RECORD.
                    OpenMark = om.mark                                                                                                                                      ' SET THE VARIABLE MARK FOR COMPARISONS WITH THE PRICES.
                Else
                    OpenMark = Math.Round((openprice) * 4, MidpointRounding.ToEven) / 4                                                                               ' ROUND THE OPENING PRICE TO THE NEAREST QUARTER DOLLAR.
                    Dim newMark As New HarvestMark                                                                                                                      ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                    TryUpdateModel(newMark)
                    Dim new_mrk As New HarvestMark With { _
                                                    .timestamp = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                    .userid = userid, _
                                                    .symbol = symbol.ToUpper(), _
                                                    .mark = OpenMark, _
                                                    .turns = 1, _
                                                    .harvestkey = harvestkey, _
                                                    .open = True _
                                                    }                                                                                                                   ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                    db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                             ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                    db.SubmitChanges()                                                                                                                                  ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.
                End If

            End Using

            Return OpenMark
        End Function

        Function CheckOpenPrice(ByVal symbol As String, ByVal userid As Guid, ByVal openprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal indicator As Integer, ByVal width As Double, ByVal harvestkey As String) As String

            Dim datastring As String = ""
            Dim gap As Double = 0
            'Dim width As Double = 0.25
            Dim gapcntr As Integer = 0
            Dim openstatus As String = "S"
            Dim testprice As Double = 0

            Using db As New wavesDataContext

                If openprice - openMark > 0.24 Then                                                                                                               ' DETERMINES IF THE OPEN PRICE IS GREATER THAN THE CURRENT MARK.

                    ' IF THIS CONDITION IS MET THE SELL TO CLOSE ORDER(S) WILL BE FILLED. WILL NEED TO WRITE THE CODE TO DETECT THAT AS WELL AS SET A NEW
                    ' BUY TO OPEN ORDER ONE WIDTH LEVEL BELOW THE NEW MARK.

                    gap = Math.Round((openprice + 0.01 - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                                  ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width                                                                                                                      ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED DOWN                    
                    openstatus = " S "

                    ' BECAUSE THE PRICE IS GREATER THAN THE MARK PLUS THE WIDTH THERE NEEDS TO BE A NEW MARK ESTABLISHED.

                    '***** PROCESS HARVEST POSITIONS HERE *****
                    For i = gapcntr To 1 Step -1                                                                                                                        ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                        testprice = gap + (width * i)

                        '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                        If db.posExists(harvestkey, gap - (width * i), userid, True) = True Then                                                                            ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP
                            Dim su = db.positionexists(harvestkey, gap - (width * i), userid, True)                                                                         ' GET THE POSITION TO UPDATE THE RECORD.
                            su.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                 ' SET THE CLOSE DATE FOR THIS RECORD                                        
                            If indicator = 0 Then
                                su.closeprice = gap                                                                                                                         ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                            Else
                                su.closeprice = su.openprice + width
                            End If
                            su.open = False                                                                                                                             ' SET THE OPEN FLAG TO FALSE                            
                            su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                          ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        
                            su.closeflag = "O"

                            'db.SubmitChanges()                                                                                                                         ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                            Dim ul = db.getlog(harvestkey, marketdate)
                            ul.closes = ul.closes + 1
                            ul.trans = ul.trans + 1
                            ul.closingmark = gap
                            ul.timestamp = DateTime.Parse(Now).ToUniversalTime

                            db.SubmitChanges()

                            ' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                            If db.hedgeexists(harvestkey, gap, userid, True) = False Then                                                                               ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                                Dim expyear As Integer = marketdate.Year
                                Dim expmonth As Integer = marketdate.Month                                                                                              ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.
                                expmonth = expmonth + 2                                                                                                                 ' ADD 2 MONTHS TO THE HEDGE EXPIRATION                              ****  NEED TO MAKE THIS DYNAMIC FOR USER TO SET  ****
                                Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                    ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****

                                For d = 0 To 6                                                                                                                          ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
                                    If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                            ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                                        exp = exp.AddDays(14)                                                                                                           ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                                        Exit For
                                    End If
                                    exp = exp.AddDays(d)
                                Next

                                Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                                Dim newhedge As New HarvestHedge With { _
                                                                .symbol = symbol.ToUpper, _
                                                                .type = "P", _
                                                                .lots = 4, _
                                                                .strike = Int(gap - 2), _
                                                                .stockatopen = gap, _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .open = True, _
                                                                .exp = exp, _
                                                                .harvestkey = harvestkey, _
                                                                .userid = userid _
                                                            }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                                db.HarvestHedges.InsertOnSubmit(newhedge)

                                su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                                su.strike = Int(gap - width - 2)                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.
                            End If

                            db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                        End If

                    Next

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, userid, harvestKey)                                                                                                         ' PULL THE OPEN MARK RECORD.
                        om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                      ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                        om.turns = om.turns + 1                                                                                                                         ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                        om.mark = gap                                                                                                                                   ' SET THE MARK TO THE CURRENT PRICE.

                        db.SubmitChanges()                                                                                                                              ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                    End If

                    datastring = datastring & " O: " & (String.Format("{0:C}", openprice)) & openstatus & " M: " & (String.Format("{0:C}", gap))


                ElseIf openprice - openMark < -0.24 Then

                    gap = Math.Round((openprice - 0.01 + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                             ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width * -1                                                                                                                 ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED UP
                    'triggercounter = triggercounter + 1
                    'buys = buys + 1
                    openstatus = "B"

                    ' CHECK TO SEE IF POSITION EXISTS AT GAP DOWN PRICE. IF NOT THEN ADD A POSITION AT THE GAP PRICE - GAP COULD EQUAL 1 WIDTH LEVEL.
                    If db.posExists(symbol, gap, userid, True) = False Then                                                                                             ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP

                        Dim newHarvestPosition As New HarvestPosition                                                                                                               ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                        TryUpdateModel(newHarvestPosition)                                                                                                                  ' TEST CONNECTION TO DATABASE TABLES.
                        Dim newpos As New HarvestPosition With { _
                                                        .open = True, _
                                                        .symbol = symbol.ToUpper, _
                                                        .userid = userid, _
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                        .openflag = "O", _
                                                        .harvestkey = harvestkey, _
                                                        .openprice = gap _
                                                    }                                                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.HarvestPositions.InsertOnSubmit(newpos)                                                                                                                  ' INSERT THE NEW RECORD TO BE ADDED.                        

                        Dim ul = db.getlog(harvestkey, marketdate)
                        ul.opens = ul.opens + 1
                        ul.trans = ul.trans + 1
                        ul.closingmark = gap
                        ul.timestamp = DateTime.Parse(Now).ToUniversalTime

                        db.SubmitChanges()

                        ' ******************                                                  Because of a GAP DOWN need to loop this by the gap counter.

                        For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED. 
                            Dim pricetest As Double = openMark - (width * i)

                            If db.posExists(harvestkey, pricetest + 2, userid, True) = True Then                                                                                  ' CHECK IF THERE IS A POSITION TO CLOSE BASED ON THE DROP IN PRODUCT PRICE.

                                If db.hedgeexists(harvestkey, pricetest + 2, userid, True) = True Then                                                                            ' CHECK TO SEE IF THERE IS A HEDGE TO MATCH THE GAP PLUS SPREAD.

                                    Dim su = db.positionexists(harvestkey, pricetest + 2, userid, True)                                                                           ' GET THE POSITION TO UPDATE THE RECORD.
                                    su.closeprice = pricetest
                                    su.closeflag = "Z"                                                                                                                      ' SET CLOSEFLAG TO Z INDICATING THAT THIS POSITION WAS CLOSED VIA THE HEDGE CLOSE.
                                    su.open = 0
                                    su.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                    su.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                    ul.closes = ul.closes + 1

                                    Dim hu = db.gethedge(harvestkey, gap + 2, True)
                                    hu.open = False
                                    hu.stockatclose = pricetest
                                    hu.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                    hu.timestamp = DateTime.Parse(Now).ToUniversalTime()

                                    'Stop

                                End If

                            End If

                            db.SubmitChanges()

                        Next


                    End If

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
                        om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                        om.turns = om.turns + 1                                                                                                                         ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                        om.mark = gap                                                                                                                                   ' SET THE MARK TO THE CURRENT PRICE.

                        db.SubmitChanges()                                                                                                                              ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                    End If

                    datastring = datastring & " O: " & (String.Format("{0:C}", openprice)) & openstatus & " M: " & (String.Format("{0:C}", gap))
                Else
                    datastring = datastring & " O: " & (String.Format("{0:C}", openprice))
                End If

            End Using

            Return datastring
        End Function

        Function CheckLowPrice(ByVal symbol As String, ByVal userid As Guid, ByVal lowprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal width As Double, ByVal harvestkey As String) As String

            Dim datastring As String = ""
            Dim gap As Double = 0
            'Dim width As Double = 0.25
            Dim gapcntr As Integer = 0
            Dim lowstatus As String = "B"

            'If marketdate = #1/4/2016 10:17:00 AM# Then
            '    Dim stopme As String = ""
            'End If

            Using db As New wavesDataContext

                If lowprice - openMark < -0.24 Then
                    gap = Math.Round((lowprice - 0.01 + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                         ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width * -1                                                                                                             ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED UP                    
                    lowstatus = "B"

                    For i = 1 To gapcntr                                                                                                                        ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   
                        Dim pricetest As Double = openMark - (width * i)
                        '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                        If db.posExists(harvestkey, gap - (width * i), userid, True) = False Then                                                                            ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP
                            Dim newHarvestPosition As New HarvestPosition                                                                                                               ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                            TryUpdateModel(newHarvestPosition)                                                                                                                  ' TEST CONNECTION TO DATABASE TABLES.
                            Dim newpos As New HarvestPosition With { _
                                                            .open = True, _
                                                            .symbol = symbol.ToUpper, _
                                                            .userid = userid, _
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                            .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                            .openflag = "L",
                                                            .harvestkey = harvestkey, _
                                                            .openprice = pricetest _
                                                        }                                                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                            db.HarvestPositions.InsertOnSubmit(newpos)

                            Dim ul = db.getlog(harvestkey, marketdate)
                            ul.opens = ul.opens + 1
                            ul.trans = ul.trans + 1
                            ul.closingmark = gap
                            ul.timestamp = DateTime.Parse(Now).ToUniversalTime

                            If db.posExists(harvestkey, pricetest + 2, userid, True) = True Then                                                                                  ' CHECK IF THERE IS A POSITION TO CLOSE BASED ON THE DROP IN PRODUCT PRICE.

                                If db.hedgeexists(harvestkey, pricetest + 2, userid, True) = True Then                                                                            ' CHECK TO SEE IF THERE IS A HEDGE TO MATCH THE GAP PLUS SPREAD.

                                    Dim su = db.positionexists(harvestkey, gap + 2, userid, True)                                                                           ' GET THE POSITION TO UPDATE THE RECORD.
                                    su.closeprice = gap
                                    su.closeflag = "Z"                                                                                                                      ' SET CLOSEFLAG TO Z INDICATING THAT THIS POSITION WAS CLOSED VIA THE HEDGE CLOSE.
                                    su.open = 0
                                    su.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                    su.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                    ul.closes = ul.closes + 1

                                    Dim hu = db.gethedge(harvestkey, pricetest + 2, True)
                                    hu.open = False
                                    hu.stockatclose = gap
                                    hu.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                    hu.timestamp = DateTime.Parse(Now).ToUniversalTime()

                                    'Stop

                                End If

                            End If

                            db.SubmitChanges()

                        End If

                    Next

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
                        om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                        om.turns = om.turns + 1                                                                                                                         ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                        om.mark = gap                                                                                                                                   ' SET THE MARK TO THE CURRENT PRICE.
                        db.SubmitChanges()                                                                                                                              ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                    End If

                    datastring = datastring & "  " & "L: " & (String.Format("{0:C}", lowprice)) & " " & lowstatus & " M: " & (String.Format("{0:C}", gap))

                Else
                    datastring = datastring & "  " & " L: " & (String.Format("{0:C}", lowprice))
                End If

            End Using

            Return datastring
        End Function

        Function CheckHighPrice(ByVal symbol As String, ByVal userid As Guid, ByVal highprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal width As Double, ByVal harvestkey As String) As String
            Dim datastring As String = ""
            Dim gap As Double = 0
            'Dim width As Double = 0.25
            Dim gapcntr As Integer = 0
            Dim highstatus As String = "S"
            Dim pos As Double = 0
            Dim expiration As Date = Now()

            Using db As New wavesDataContext

                If highprice - openMark > 0.24 Then
                    gap = Math.Round((highprice + 0.01 - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                                 ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width
                    highstatus = "S"

                    '***** PROCESS HARVEST POSITIONS HERE *****
                    For i = gapcntr To 1 Step -1                                                                                                                        ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                        Dim pricetest As Double = openMark + (width * i)

                        '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                        If db.posExists(harvestkey, gap - (width * i), userid, True) = True Then                                                                        ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP.
                            Dim su = db.positionexists(harvestkey, gap - (width * i), userid, True)                                                                     ' GET THE POSITION TO UPDATE THE RECORD.
                            su.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                 ' SET THE CLOSE DATE FOR THIS RECORD                                        
                            su.closeprice = su.openprice + width                                                                                                        ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                            su.open = False                                                                                                                             ' SET THE OPEN FLAG TO FALSE
                            su.closeflag = "H"
                            su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                          ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                            Dim ul = db.getlog(harvestkey, marketdate)
                            ul.closes = ul.closes + 1
                            ul.trans = ul.trans + 1
                            ul.closingmark = gap
                            ul.timestamp = DateTime.Parse(Now).ToUniversalTime

                            db.SubmitChanges()


                            ' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                            If db.hedgeexists(harvestkey, gap, userid, True) = False Then                                                                               ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                                Dim expyear As Integer = marketdate.Year
                                Dim expmonth As Integer = marketdate.Month                                                                                              ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.
                                expmonth = expmonth + 2                                                                                                                 ' ADD 2 MONTHS TO THE HEDGE EXPIRATION                              ****  NEED TO MAKE THIS DYNAMIC FOR USER TO SET  ****
                                Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                    ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****

                                For d = 0 To 6                                                                                                                          ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
                                    If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                            ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                                        exp = exp.AddDays(14)                                                                                                           ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                                        Exit For
                                    End If
                                    exp = exp.AddDays(d)
                                Next

                                Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                                Dim newhedge As New HarvestHedge With { _
                                                                .symbol = symbol.ToUpper, _
                                                                .type = "P", _
                                                                .lots = 4, _
                                                                .strike = Int(gap - width - 2), _
                                                                .stockatopen = su.openprice + width, _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .open = True, _
                                                                .exp = exp, _
                                                                .harvestkey = harvestkey, _
                                                                .userid = userid _
                                                            }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                                db.HarvestHedges.InsertOnSubmit(newhedge)

                                su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                                su.strike = Int(gap - width - 2)                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.
                            End If

                            db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                        End If

                    Next

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
                        om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                      ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                        om.turns = om.turns + 1                                                                                                                         ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                        om.mark = gap                                                                                                                                   ' SET THE MARK TO THE CURRENT PRICE.

                        db.SubmitChanges()                                                                                                                              ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                    End If

                    datastring = datastring & "  " & "H: " & (String.Format("{0:C}", highprice)) & " " & highstatus & " M: " & (String.Format("{0:C}", gap))            ' ADD THE HIGH PRICE DATA WITH THE MARK TO THE DATASTRING TO DISPLAY ON THE PAGE.

                Else
                    datastring = datastring & "  " & " H: " & (String.Format("{0:C}", highprice))                                                                       ' ADD THE HIGH PRICE DATA TO THE DATASTRING TO DISPLAY ON THE PAGE.
                End If

            End Using

            Return datastring
        End Function

        Function CheckClosePrice(ByVal symbol As String, ByVal userid As Guid, ByVal closeprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal dir As String, ByVal width As Double, ByVal harvestkey As String) As String

            Dim datastring As String = ""                                                                                                                               ' HOLDS THE RESULT OF EXECUTED CODE PASSED BETWEEN FUNCTIONS AND PRESENTED IN THE VIEW.
            Dim gap As Double = 0                                                                                                                                       ' HOLDS THE DIFFERENCE BETWEEN THE PRICE AND THE MARK.
            'Dim width As Double = 0.25
            Dim gapcntr As Integer = 0
            Dim closestatus As String = "S"

            Using db As New wavesDataContext

                If dir = "U" Then

                    If closeprice - openMark < -0.24 Then
                        gap = Math.Round((closeprice - 0.01 + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                      ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                        gapcntr = (gap - openMark) / width * -1                                                                                                         ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED UP                        
                        closestatus = "B"

                        For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   
                            Dim pricetest As Double = openMark - (width * i)                                                                                            ' SET THE OPENPRICE TO EACH LEVEL BELOW THE MARK. ACCOUNTS FOR OPEN TO BUY GTC ORDERS IN THE PLATFORM.
                            '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                            If db.posExists(harvestkey, gap - (width * i), userid, True) = False Then                                                                       ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP

                                Dim newHarvestPosition As New HarvestPosition                                                                                           ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                TryUpdateModel(newHarvestPosition)                                                                                                      ' TEST CONNECTION TO DATABASE TABLES.
                                Dim newpos As New HarvestPosition With { _
                                                                .open = True, _
                                                                .symbol = symbol.ToUpper, _
                                                                .userid = userid, _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .openflag = "C", _
                                                                .harvestkey = harvestkey, _
                                                                .openprice = pricetest _
                                                            }                                                                                                           ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                                db.HarvestPositions.InsertOnSubmit(newpos)

                                Dim ul = db.getlog(harvestkey, marketdate)
                                ul.opens = ul.opens + 1
                                ul.trans = ul.trans + 1
                                ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                                ul.closingmark = gap

                                If db.posExists(harvestkey, pricetest + 2, userid, True) = True Then                                                                                  ' CHECK IF THERE IS A POSITION TO CLOSE BASED ON THE DROP IN PRODUCT PRICE.

                                    If db.hedgeexists(harvestkey, gap + 2, userid, True) = True Then                                                                            ' CHECK TO SEE IF THERE IS A HEDGE TO MATCH THE GAP PLUS SPREAD.

                                        Dim su = db.positionexists(harvestkey, gap + 2, userid, True)                                                                           ' GET THE POSITION TO UPDATE THE RECORD.
                                        su.closeprice = gap
                                        su.closeflag = "Z"                                                                                                                      ' SET CLOSEFLAG TO Z INDICATING THAT THIS POSITION WAS CLOSED VIA THE HEDGE CLOSE.
                                        su.open = 0
                                        su.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                        su.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                        ul.closes = ul.closes + 1
                                        Dim hu = db.gethedge(harvestkey, pricetest + 2, True)
                                        hu.open = False
                                        hu.stockatclose = pricetest
                                        hu.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                        hu.timestamp = DateTime.Parse(Now).ToUniversalTime()

                                        'Stop

                                    End If

                                End If

                                db.SubmitChanges()

                            End If

                        Next

                        '***** UPDATE THE MARK POSITION *****     
                        If gapcntr > 0 Then
                            Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                     ' PULL THE OPEN MARK RECORD.
                            om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                  ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                            om.turns = om.turns + 1                                                                                                                     ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                            om.mark = gap                                                                                                                               ' SET THE MARK TO THE CURRENT PRICE.

                            db.SubmitChanges()                                                                                                                          ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                        End If

                        datastring = datastring & "  " & "C: " & (String.Format("{0:C}", closeprice)) & " " & closestatus & " M: " & (String.Format("{0:C}", gap))      ' ADD CLOSE PRICE DATA IF THERE WAS A CHANGE THAT OCCURRED TO THE DATASTRING.

                    Else
                        datastring = datastring & "  " & " C: " & (String.Format("{0:C}", closeprice))                                                                  ' ADD CLOSE PRICE DATA WITHOUT A CHANGE TO THE DATASTRING.
                    End If

                Else

                    If closeprice - openMark > 0.24 Then
                        gap = Math.Round((closeprice + 0.01 - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                            ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                        gapcntr = (gap - openMark) / width
                        closestatus = "S"

                        '***** PROCESS HARVEST POSITIONS HERE *****
                        For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                            '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                            If db.posExists(harvestkey, gap - (width * i), userid, True) = True Then                                                                        ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP
                                Dim su = db.positionexists(harvestkey, gap - (width * i), userid, True)                                                                     ' GET THE POSITION TO UPDATE THE RECORD.
                                su.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                             ' SET THE CLOSE DATE FOR THIS RECORD                                        
                                su.closeprice = su.openprice + width                                                                                                    ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                                su.open = False                                                                                                                         ' SET THE OPEN FLAG TO FALSE
                                ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.
                                su.closeflag = "C"
                                su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                      ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                                'db.SubmitChanges()                                                                                                                      ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                                Dim ul = db.getlog(harvestkey, marketdate)
                                ul.closes = ul.closes + 1
                                ul.trans = ul.trans + 1
                                ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                                ul.closingmark = gap

                                db.SubmitChanges()

                                ' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                                If db.hedgeexists(harvestkey, gap, userid, True) = False Then                                                                               ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                                    Dim expyear As Integer = marketdate.Year
                                    Dim expmonth As Integer = marketdate.Month                                                                                              ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.
                                    expmonth = expmonth + 2                                                                                                                 ' ADD 2 MONTHS TO THE HEDGE EXPIRATION                              ****  NEED TO MAKE THIS DYNAMIC FOR USER TO SET  ****
                                    Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                    ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****

                                    For d = 0 To 6                                                                                                                          ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
                                        If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                            ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                                            exp = exp.AddDays(14)                                                                                                           ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                                            Exit For
                                        End If
                                        exp = exp.AddDays(d)
                                    Next

                                    Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                    TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                                    Dim newhedge As New HarvestHedge With { _
                                                                    .symbol = symbol.ToUpper, _
                                                                    .type = "P", _
                                                                    .lots = 4, _
                                                                    .strike = Int(gap - 2), _
                                                                    .stockatopen = gap, _
                                                                    .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                    .open = True, _
                                                                    .exp = exp, _
                                                                    .harvestkey = harvestkey, _
                                                                    .userid = userid _
                                                                }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                                    db.HarvestHedges.InsertOnSubmit(newhedge)

                                    su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                                    su.strike = Int(gap - width - 2)                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.
                                End If

                                db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                            End If

                        Next

                        '***** UPDATE THE MARK POSITION *****     
                        If gapcntr > 0 Then
                            Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                     ' PULL THE OPEN MARK RECORD.
                            om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                  ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                            om.turns = om.turns + 1                                                                                                                     ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                            om.mark = gap                                                                                                                               ' SET THE MARK TO THE CURRENT PRICE.

                            db.SubmitChanges()                                                                                                                          ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                        End If

                        datastring = datastring & "  " & "C: " & (String.Format("{0:C}", closeprice)) & " " & closestatus & " M: " & (String.Format("{0:C}", gap))      ' ADD CLOSE PRICE DATA IF THERE WAS A CHANGE THAT OCCURRED TO THE DATASTRING.

                    Else
                        datastring = datastring & "  " & " C: " & (String.Format("{0:C}", closeprice))                                                                  ' ADD CLOSE PRICE DATA WITHOUT A CHANGE TO THE DATASTRING.
                    End If

                End If

            End Using

            Return datastring
        End Function

    End Class
End Namespace
