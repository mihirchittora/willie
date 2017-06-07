Imports System.Threading
Imports System.Collections.Generic
Imports System.Net
Imports bondi.wavesViewModel
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Text
Imports System

' DEFINITIONS:
' SYMBOL:   THE ABBREVIATION OF THE PRODUCT BEING USED IN THE SYSTEM.  EX: AAPL = THE APPLE STOCK SYMBOL
' WIDTH:    THE PRICE DISTANCE TO TRIGGER A BUYING OR SELLING EVENT AS DEFINED BY THE USER.  DEFAULT IS $ 0.25.
' MARK:     THE CURRENT PRICE ROUNDED TO THE NEAREST WIDTH.  
' TRIGGER:  THE DISTANCE OF THE WIDTH ABOVE AND BELOW THE MARK.
' GAP:      THE DISTANCE OF A OPENING PRICE ABOVE OR BELOW THE MARK TYPICALLY GREATER THAN 1 WIDTH.

Namespace bondi
    Public Class testController
        Inherits System.Web.Mvc.Controller
        '
        ' GET: /test

        Function Index() As ActionResult

            ' Need to determine whether to place read code in an event like this or to have it cycle only when a button is clicked.

            Return View()

        End Function

        Function backdata(ByVal symbol As String, ByVal filename As String, ByVal harvestkey As String) As ActionResult

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
            Dim userid As Guid                                                                                                                                                  ' USERID ADDED TO RECORDS FOR EACH USER
            Dim csvdata As String                                                                                                                                               ' USED TO HOUSE THE TEXT FILE 
            Dim username As String = "csquared20"                                                                                                                               ' USERNAME TO GET USER ID.  ---> WHEN READY FOR PRODUCTION SET TO USER.IDENTITY.NAME (WILL HAVE TO SET TO <AUTHORIZED> _)
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                ' BASE PATH OF THE FILE TO BE READ INTO MEMORY.
            Dim loopcounter As Integer = 0                                                                                                                                      ' COUNTER FOR THE ROWS TO BE PROCESSED.
            Dim mark As Double = 0                                                                                                                                              ' HOLDS THE CURRENT PRICE OF THE MARK.
            Dim width As Double = 0.25                                                                                                                                          ' THE WIDTH OF THE TRIGGERS - THIS WILL BE PULLED FROM THE CONTROL CARD OF THE USER
            Dim trigger As Double = 0                                                                                                                                           ' HOLDS THE TRIGGER WHICH IS BASED ON THE WIDTH MINUS .01 
            Dim gap As Double = 0                                                                                                                                               ' HOLDS THE DIFFERENCE BETWEEN THE PRICE AND THE MARK.
            Dim gappositions As Double = 0                                                                                                                                      ' DETERMINES THE NUMBER OF LEVELS THAT A PRICE HAS GAPPED.
            Dim gapcntr As Double = 0                                                                                                                                           ' LOOP COUNTER WHEN A GAP EXISTS.
            Dim hedgestatus As String = ""                                                                                                                                      ' INDICATOR FOR THE VIEW IF THE CLOSED POSITION TRIGGERS A HEDGE.
            ' Dim hedgeupdate As Boolean                                                                                                                                          ' HEDGE TRIGGER FOR THE TABLE BASED ON THE CLOSED POSITION TRIGGERING A NEED FOR A HEDGE.
            Dim strike As Double = 0                                                                                                                                            ' INDICATOR OF THE STRIKE TO SELECT FOR THE HEDGE.
            Dim direction As String = ""                                                                                                                                        ' INDICATOR OF THE INTERVAL GOING UP OR DOWN - OPEN TO CLOSE.

            Dim openpricegreater As String = ""
            Dim highpricegreater As String = ""
            Dim closepricegreater As String = ""
            Dim openpricelower As String = ""
            Dim lowpricelower As String = ""
            Dim closepricelower As String = ""

            ' **********  OPEN THE DATABASE **********
            Using db As New wavesDataContext                                                                                                                                    ' OPEN THE DATA CONTEXT FOR THE DATABASE.

                userid = db.GetUserIdForUserName(username)                                                                                                                      ' GET THE USERID FROM USERNAME. (THIS WILL HAVE TO BE EDITED WHEN SECURITY IS INSTALLED.)

                Using textReader As New System.IO.StreamReader(path & filename & "\table_" & "vxx.csv")                                                                         ' TEXT READER PULLS AND READS THE FILE.
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

                    ' ********** STEP 2: DETERMINE WHETHER THERE IS A MARK ESTABLISHED FOR THIS SYMBOL AND THIS USER **********

                    If db.markExists(symbol, userid) = True Then                                                                                                                ' CALL FUNCTION TO DETERMINE IF A RECORD CONTAINING A MARK EXISTS FOR THIS PRODUCT & USER.
                        Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                                 ' PULL THE OPEN MARK RECORD.
                        mark = om.mark                                                                                                                                          ' SET THE VARIABLE MARK FOR COMPARISONS WITH THE PRICES.
                    Else
                        mark = Math.Round((price.OpenPrice - width) * 4, MidpointRounding.ToEven) / 4                                                                           ' ROUND THE OPENING PRICE TO THE NEAREST QUARTER DOLLAR.
                        Dim newMark As New HarvestMark                                                                                                                          ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                        TryUpdateModel(newMark)
                        Dim new_mrk As New HarvestMark With { _
                                                        .timestamp = DateTime.Parse(price.MarketDate).ToUniversalTime(), _
                                                        .userid = userid, _
                                                        .symbol = symbol.ToUpper(), _
                                                        .mark = mark, _
                                                        .turns = 1 _
                                                        }                                                                                                                       ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                        db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                                        ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                        db.SubmitChanges()                                                                                                                                      ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.
                    End If

                    trigger = width - 0.01                                                                                                                                      ' SETS THE TRIGGER FOR PRICE COMPARISONS FOR EACH PRICE.

                    ' ********** STEP 3: CHECK OPENING PRICE AGAINST THE MARK AND PROCESS RECORD IF PRICE TRIGGERS MOVE IN MARK **********

                    If price.OpenPrice > mark + trigger Then                                                                                                                    ' CHECK TO SEE IF THE OPENING PRICE IS GREATER THAN THE TRIGGER.

                        openpricegreater = PriceGreaterThanMark(symbol, userid, price.OpenPrice, trigger, width, price.MarketDate, width)                                              ' CALL FUNCTION TO CHECK IF OPEN PRICE IS GREATER THAN THE MARK AND RECORD APPROPRIATELY.

                    ElseIf price.OpenPrice < mark - trigger Then                                                                                                                ' CHECK TO SEE IF THE OPENING PRICE IS LESS THAN THE TRIGGER.

                        ' ***** OPEN UP A NEW POSITION BASED ON THE LOWER OPENING PRICE *****
                        gap = Math.Round((price.OpenPrice) * 4, MidpointRounding.AwayFromZero) / 4                                                                              ' ROUND THE OPENING PRICE TO THE NEAREST QUARTER DOLLAR.

                        '***** OPEN A NEW HARVEST POSITION *****
                        Dim newHarvestPosition As New HarvestPosition                                                                                                                   ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                        TryUpdateModel(newHarvestPosition)                                                                                                                      ' TEST CONNECTION TO DATABASE TABLES.
                        Dim newpos As New HarvestPosition With { _
                                                        .open = True, _
                                                        .opendate = DateTime.Parse(price.MarketDate), _
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .symbol = symbol, _
                                                        .userid = userid, _
                                                        .openprice = gap _
                                                    }                                                                                                                           ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.HarvestPositions.InsertOnSubmit(newpos)                                                                                                                      ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SubmitChanges()                                                                                                                                      ' SUBMIT THE CHANGES TO THE TABLE.

                        '***** UPDATE THE MARK POSITION *****     
                        Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                                 ' PULL THE OPEN MARK RECORD.
                        om.ctimestamp = DateTime.Parse(price.MarketDate).ToUniversalTime                                                                                        ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                        'om.trigger = gap                                                                                                                                        ' SET THE NEW MARK BASED ON THE PRICE MOVEMENT.
                        om.turns = om.turns                                                                                                                                     ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                        om.open = False                                                                                                                                         ' SET THE OPEN FLAG TO FALSE = CLOSED RECORD.

                        Dim newMark As New HarvestMark                                                                                                                                 ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                        TryUpdateModel(newMark)
                        Dim new_mrk As New HarvestMark With { _
                                                        .timestamp = DateTime.Parse(price.MarketDate).ToUniversalTime(), _
                                                        .userid = userid, _
                                                        .symbol = symbol.ToUpper(), _
                                                        .mark = gap, _
                                                        .open = True, _
                                                        .turns = om.turns + 1 _
                                                        }                                                                                                                       ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                        db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                                        ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                        db.SubmitChanges()                                                                                                                                      ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.

                    End If

                    ' ********** STEP 4: DETERMINE THE INTERVAL DIRECTION AFTER THE OPEN AND PROCESS HLC **********
                    direction = checkdirection(price.OpenPrice, price.HighPrice, price.LowPrice, price.ClosePrice)                                                              ' CALL FUNCTION TO CHECK DIRECTION AND RETURN THE INDICATOR.
                    If direction = "U" Then                                                                                                                                     ' SET IF FOR UPWARD DIRECTION HERE.

                        ' ***** IF DIRECTION IS UP FIRST ORDER OF PROCESSING: LOW, HIGH, CLOSE  **********
                        Dim cm = db.getopenmark(symbol, userid, harvestkey)                                                                                                                 ' PULL THE OPEN MARK RECORD.  cm = check mark.
                        mark = cm.mark                                                                                                                                          ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.

                        ' ***** PROCESS MARK AND TRIGGERS IF LOW PRICE IS LESS THAN THE TRIGGER  **********
                        If price.LowPrice < mark - trigger Then                                                                                                                 ' CHECK TO SEE IF LOW PRICE IS LESS THAN THE CURRENT TRIGGER.

                            lowpricelower = PriceLessThanMark(symbol, userid, price.LowPrice, trigger, width, price.MarketDate, width)                                                 ' CALL FUNCTION TO CHECK IF LOW PRICE IS LESS THAN THE MARK AND RECORD APPROPRIATELY.

                        End If

                        cm = db.getopenmark(symbol, userid, harvestkey)                                                                                                                     ' PULL THE OPEN MARK RECORD.  cm = check mark.
                        mark = cm.mark                                                                                                                                          ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.
                        ' ***** PROCESS MARK AND TRIGGERS IF HIGH PRICE IS GREATER THAN THE TRIGGER  **********
                        If price.HighPrice > mark + trigger Then

                            highpricegreater = PriceGreaterThanMark(symbol, userid, price.HighPrice, trigger, width, price.MarketDate, width)                                          ' CALL FUNCTION TO CHECK IF HIGH PRICE IS GREATER THAN THE MARK AND RECORD APPROPRIATELY.

                        End If

                        ' ***** PROCESS MARK AND TRIGGERS IF CLOSE PRICE IS GREATER THAN THE TRIGGER  **********

                        cm = db.getopenmark(symbol, userid, harvestkey)                                                                                                                     ' PULL THE OPEN MARK RECORD.  cm = check mark.
                        mark = cm.mark                                                                                                                                          ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.

                        If price.ClosePrice < mark - trigger Then

                            closepricegreater = PriceGreaterThanMark(symbol, userid, price.ClosePrice, trigger, width, price.MarketDate, width)                                        ' CALL FUNCTION TO CHECK IF HIGH PRICE IS GREATER THAN THE MARK AND RECORD APPROPRIATELY.

                        End If

                    ElseIf direction = "L" Then                                                                                                                                 ' SET THE THEN FOR A LOWER DIRECTIONAL POSITION HERE.

                        ' ***** IF DIRECTION IS DOWN  FIRST ORDER OF PROCESSING: HIGH, LOW, CLOSE  **********

                        Dim cm = db.getopenmark(symbol, userid, harvestkey)                                                                                                                 ' PULL THE OPEN MARK RECORD.  cm = check mark.
                        mark = cm.mark                                                                                                                                          ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.

                        ' ***** PROCESS MARK AND TRIGGERS IF HIGH PRICE IS GREATER THAN THE TRIGGER  **********
                        If price.HighPrice > mark + trigger Then

                            highpricegreater = PriceGreaterThanMark(symbol, userid, price.HighPrice, trigger, width, price.MarketDate, width)                                          ' CALL FUNCTION TO CHECK IF HIGH PRICE IS GREATER THAN THE MARK AND RECORD APPROPRIATELY.

                        End If

                        cm = db.getopenmark(symbol, userid, harvestkey)                                                                                                                     ' PULL THE OPEN MARK RECORD.  cm = check mark.
                        mark = cm.mark                                                                                                                                          ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.

                        ' ***** PROCESS MARK AND TRIGGERS IF LOW PRICE IS LESS THAN THE TRIGGER  **********
                        If price.LowPrice < mark - trigger Then                                                                                                                 ' CHECK TO SEE IF LOW PRICE IS LESS THAN THE CURRENT TRIGGER.

                            lowpricelower = PriceLessThanMark(symbol, userid, price.LowPrice, trigger, width, price.MarketDate, width)                                                 ' CALL FUNCTION TO CHECK IF LOW PRICE IS LESS THAN THE MARK AND RECORD APPROPRIATELY.

                        End If

                        If price.ClosePrice > mark + trigger Then

                            closepricegreater = PriceGreaterThanMark(symbol, userid, price.ClosePrice, trigger, width, price.MarketDate, width)                                        ' CALL FUNCTION TO CHECK IF HIGH PRICE IS GREATER THAN THE MARK AND RECORD APPROPRIATELY.

                        End If

                    End If
                    loopcounter = loopcounter + 1                                                                                                                               ' INCREMENT LOOPCOUNTER WHICH POPULATES THE INTERVAL FIELD AND TRACKS THE ROWS.

                Next                                                                                                                                                            ' LOOP

            End Using                                                                                                                                                           ' CLOSE THE DATA CONTEXT FOR THE DATABASE

            Return RedirectToAction("index", "test")
        End Function

        Function PriceGreaterThanMark(ByVal symbol As String, ByVal userid As Guid, ByVal price As Double, ByVal trigger As Double, ByVal width As Double, ByVal marketdate As DateTime, ByVal harvestkey As String) As String

            ' DEFINE VARIABLES USED IN THE PROCESS THAT ARE NOT PASSED
            Dim results As String = ""                                                                                                                                  ' VARIABLE RETURNED TO CALLED FUNCTION.
            Dim loopcounter As Integer = 0                                                                                                                              ' COUNTER FOR THE ROWS TO BE PROCESSED.
            Dim mark As Double = 0                                                                                                                                      ' HOLDS THE CURRENT PRICE OF THE MARK.            
            Dim gap As Double = 0                                                                                                                                       ' HOLDS THE DIFFERENCE BETWEEN THE PRICE AND THE MARK.
            Dim gappositions As Double = 0                                                                                                                              ' DETERMINES THE NUMBER OF LEVELS THAT A PRICE HAS GAPPED.
            Dim gapcounter As Double = 0                                                                                                                                ' LOOP COUNTER WHEN A GAP EXISTS.
            Dim hedgestatus As String = ""                                                                                                                              ' INDICATOR FOR THE VIEW IF THE CLOSED POSITION TRIGGERS A HEDGE.
            Dim hedgeupdate As Boolean                                                                                                                                  ' HEDGE TRIGGER FOR THE TABLE BASED ON THE CLOSED POSITION TRIGGERING A NEED FOR A HEDGE.
            Dim strike As Double = 0                                                                                                                                    ' INDICATOR OF THE STRIKE TO SELECT FOR THE HEDGE.
            Dim direction As String = ""                                                                                                                                ' INDICATOR OF THE INTERVAL GOING UP OR DOWN - OPEN TO CLOSE.
            Dim turns As Integer = 0                                                                                                                                    ' THE NUMBER OF LEVELS FOR THIS PRODUCT AND USER.

            Using db As New wavesDataContext                                                                                                                            ' OPEN THE DATA CONTEXT FOR THE DATABASE.

                ' ***** DETERMINE IF THERE IS A GAP UP AND WHAT POSITIONS SHOULD BE CLOSED AS WELL AS THE CURRENT MARK *****

                Dim currentmark = db.getopenmark(symbol, userid, harvestkey)                                                                                                        ' PULL THE OPEN MARK RECORD.
                mark = currentmark.mark                                                                                                                                 ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.
                gap = Math.Round((price - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                                                       ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                gappositions = (gap - mark) / width                                                                                                                     ' DETERMINE THE NUMBER OF OPEN POSITIONS TO SEARCH FOR AND CLOSE BASED ON THE GAP UP.

                ' ***** LOOP THROUGH EACH LEVEL AND DETERMINE IF THERE IS AN OPEN POSITION TO CLOSE FOR PROFIT *****
                For i = 1 To gappositions                                                                                                                               ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                    ' ********** Step 1: DETERMINE THE HEDGE ON THE UP POSITION **********
                    If gap - Int(gap) = 0.5 Or gap - Int(gap) = 0.0 Then                                                                                                ' DETERMINE WHETHER A HEDGE NEEDS TO BE ESTABLISHED OR NOT. 
                        hedgestatus = "HEDGE"                                                                                                                           ' SET THE STATUS FOR THE LIST THAT THIS POSITION IS HEDGED. 
                        hedgeupdate = True                                                                                                                              ' SET THE FIELD IN THE TABLE FOR THE HEDGE EQUALS TRUE.
                        strike = Int(gap) - 2.0                                                                                                                         ' SET THE STRIKE PRICE FOR THE HEDGE
                        ' ADD THE HEDGE POSITION TO THE HEDGE TABLE. NEED TO WORK THROUGH THE STRUCTURE AND LOGIC OF THE HEDGE POSITIONING.
                    Else
                        hedgestatus = ""                                                                                                                                ' CLEAR THE STATUS FOR THE LIST ON THE HEDGE.
                        hedgeupdate = False                                                                                                                             ' SET THE FIELD IN THE TABLE FOR THE HEDGE EQUALS FALSE.
                        strike = 0                                                                                                                                      ' CLEAR THE STRIKE PRICE FOR THE HEDGE.
                    End If

                    ' ********** STEP 2: RECORD THE CLOSED POSITION FROM THE PLATFORM FOR PROFIT & SEND ANOTHER OPEN TO BUY ORDER *****
                    If db.posExists(symbol, gap - (width * i), userid, True) = True Then                                                                                 ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP
                        Dim su = db.positionexists(harvestkey, gap - (width * i), userid, True)                                                                              ' GET THE POSITION TO UPDATE THE RECORD.

                        su.closedate = DateTime.Parse(marketdate)                                                                                                       ' SET THE CLOSE DATE FOR THIS RECORD                        
                        su.closeprice = gap                                                                                                                             ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                        su.open = False                                                                                                                                 ' SET THE OPEN FLAG TO FALSE
                        su.hedge = hedgeupdate                                                                                                                          ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                        su.strike = strike                                                                                                                              ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.
                        su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                              ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.

                        db.SubmitChanges()                                                                                                                              ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.
                    End If

                    gapcounter = gapcounter + width                                                                                                                     ' INCREMENT THE GAP COUNTER FOR EACH LEVEL WITHIN THE GAP.

                Next

                '***** UPDATE THE MARK POSITION *****     
                Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                                 ' PULL THE OPEN MARK RECORD.
                If om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime Then                                                                                      ' DETERMINE IF THIS MARK HAS ALREADY BEEN PROCESSED. (IN THE EVENT THE DATA IS RUN TWICE.)
                Else
                    om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                          ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                    'om.trigger = gap                                                                                                                                    ' SET THE NEW MARK BASED ON THE PRICE MOVEMENT.
                    turns = om.turns                                                                                                                                    ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                    om.open = False                                                                                                                                     ' SET THE OPEN FLAG TO FALSE = CLOSED RECORD.

                    Dim newMark As New HarvestMark                                                                                                                             ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                    TryUpdateModel(newMark)
                    Dim new_mrk As New HarvestMark With { _
                                                    .timestamp = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                    .userid = userid, _
                                                    .symbol = symbol.ToUpper(), _
                                                    .mark = gap, _
                                                    .open = True, _
                                                    .turns = turns + 1 _
                                                    }                                                                                                                   ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                    db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                                    ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                    db.SubmitChanges()                                                                                                                                  ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.
                End If
            End Using

            Return results

        End Function

        Function PriceLessThanMark(ByVal symbol As String, ByVal userid As Guid, ByVal price As Double, ByVal trigger As Double, ByVal width As Double, ByVal marketdate As DateTime, ByVal harvestkey As String) As String
            ' DEFINE VARIABLES USED IN THE PROCESS THAT ARE NOT PASSED
            Dim results As String = ""                                                                                                                                  ' VARIABLE RETURNED TO CALLED FUNCTION.
            Dim loopcounter As Integer = 0                                                                                                                              ' COUNTER FOR THE ROWS TO BE PROCESSED.
            Dim mark As Double = 0                                                                                                                                      ' HOLDS THE CURRENT PRICE OF THE MARK.            
            Dim gap As Double = 0                                                                                                                                       ' HOLDS THE DIFFERENCE BETWEEN THE PRICE AND THE MARK.
            Dim gappositions As Double = 0                                                                                                                              ' DETERMINES THE NUMBER OF LEVELS THAT A PRICE HAS GAPPED.
            Dim gapcounter As Double = 0                                                                                                                                ' LOOP COUNTER WHEN A GAP EXISTS.                       
            Dim strike As Double = 0                                                                                                                                    ' INDICATOR OF THE STRIKE TO SELECT FOR THE HEDGE.
            Dim direction As String = ""                                                                                                                                ' INDICATOR OF THE INTERVAL GOING UP OR DOWN - OPEN TO CLOSE.
            Dim turns As Integer = 0                                                                                                                                    ' THE NUMBER OF LEVELS FOR THIS PRODUCT AND USER.

            Using db As New wavesDataContext                                                                                                                            ' OPEN THE DATA CONTEXT FOR THE DATABASE.

                Dim currentmark = db.getopenmark(symbol, userid, harvestkey)                                                                                                        ' PULL THE OPEN MARK RECORD.
                mark = currentmark.mark                                                                                                                                 ' SETS THE MARK TO CHECK THE LOW PRICE AGAINST.

                ' ***** DETERMINE IF THERE IS A GAP UP AND WHAT POSITIONS SHOULD BE CLOSED AS WELL AS THE CURRENT MARK *****
                gap = Math.Round((price + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                                                              ' CALCULATE THE WIDTH OF THE GAP UP.  ********** WILL NEED TO USE THIS FOR HIGHS AS WELL. 
                gappositions = ((gap - mark) / width) * -1                                                                                                              ' DETERMINE THE NUMBER OF OPEN POSITIONS TO SEARCH FOR AND CLOSE BASED ON THE GAP UP. MAKE IT A POSITIVE NUMBER FOR THE LOOP COUNTER.

                ' ***** LOOP THROUGH EACH LEVEL AND DETERMINE IF THERE IS AN OPEN POSITION TO CLOSE FOR PROFIT *****
                For i = 1 To gappositions                                                                                                                               ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   
                    ' ***** OPEN A NEW HARVEST POSITION *****
                    Dim newHarvestPosition As New HarvestPosition                                                                                                               ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                    TryUpdateModel(newHarvestPosition)                                                                                                                  ' TEST CONNECTION TO DATABASE TABLES.
                    Dim newpos As New HarvestPosition With { _
                                                    .open = True, _
                                                    .opendate = DateTime.Parse(marketdate), _
                                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                    .symbol = symbol.ToUpper, _
                                                    .userid = userid, _
                                                    .openprice = mark - (i * width) _
                                                }                                                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                    db.HarvestPositions.InsertOnSubmit(newpos)                                                                                                                  ' INSERT THE NEW RECORD TO BE ADDED.
                    db.SubmitChanges()                                                                                                                                  ' SUBMIT THE CHANGES TO THE TABLE.

                    '***** UPDATE THE MARK POSITION *****     
                    Dim om = db.getopenmark(symbol, userid, harvestkey)                                                                                                             ' PULL THE OPEN MARK RECORD.
                    om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                          ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                    'om.trigger = mark - (i * width)                                                                                                                     ' SET THE NEW MARK BASED ON THE PRICE MOVEMENT.
                    turns = om.turns                                                                                                                                    ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                    om.open = False                                                                                                                                     ' SET THE OPEN FLAG TO FALSE = CLOSED RECORD.


                    Dim newMark As New HarvestMark                                                                                                                             ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                    TryUpdateModel(newMark)
                    Dim new_mrk As New HarvestMark With { _
                                                    .timestamp = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                    .userid = userid, _
                                                    .symbol = symbol.ToUpper(), _
                                                    .mark = mark - (i * width), _
                                                    .open = True, _
                                                    .turns = turns + 1 _
                                                    }                                                                                                                   ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                    db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                                    ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                    db.SubmitChanges()                                                                                                                                 ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.

                    gapcounter = gapcounter - width                                                                                                                     ' INCREMENT THE GAP COUNTER FOR EACH LEVEL WITHIN THE GAP.

                Next

            End Using

            Return results
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
                direction = "L"                                                                                                                                                 ' SET THE DIRECTION VARIABLE TO LOW HIGHER.            
            End If

            Return direction                                                                                                                                                    ' RETURN THE DIRECTION VARIABLE WITH ITS SET VALUE.
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

        Private Function ParseBackData(csvData As String) As List(Of backPrice)
            Dim rowcntr As String = 1
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
                p.Volume = Convert.ToDecimal(cols(6))

                marketdate = DateTime.Parse(Left(Right(p.MarketDate, 4), 2) & "/" & Right(p.MarketDate, 2) & "/" & Left(p.MarketDate, 4))
                marketdatetime = getdatetime(marketdate, p.MarketTime)
                p.MarketDate = marketdatetime

                ' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
                If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then
                    If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then
                        backprices.Add(p)
                    End If
                End If

                rowcntr = rowcntr + 1

            Next

            Return backprices
        End Function

    End Class



End Namespace
