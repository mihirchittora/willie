Imports System.Threading
Imports System.Collections.Generic
Imports System.Net
Imports bondi.wavesViewModel
Imports bondi.robot
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Math
Imports MathNet.Numerics
Imports System.Text
Imports System
Imports System.Globalization
Imports System.Data.Linq
Imports Microsoft.Office.Interop
Imports bondi.Tws
Imports bondi.Utils
Imports IBApi
Imports System.Security.Cryptography

Namespace bondi
    Public Class memberController
        Inherits System.Web.Mvc.Controller

        Public ordernumber As Integer

        Dim Tws1 As Tws = New Tws()

        Dim hedgecntr As Integer
        Dim hedgeopencntr As Integer
        Dim hedgeclosecntr As Integer
        Dim stockopencntr As Integer
        Dim stockclosecntr As Integer
        Dim maxcapital As Double
        Dim currentcapital As Double
        Dim hedgeprofit As Double
        Dim stockprofit As Double

        Function Index() As ActionResult                                                                                                                                                    ' LOADS THE INITIAL DASHBOARD FOR THE LOGGED IN USER

            'Using db As New wavesDataContext                                                                                                                                                ' INSTANCIATES CONNECTION TO THE DATA CONTEXT TO ACCESS THE DATA TABLES

            'Dim indexlist = (From m In db.HarvestIndexes Select m).ToList()                                                                                                             ' PULLS OFF OF THE INDEXES TO POPULATE THE DROPDOWN LIST IN THE VIEW
            ''Dim loglist = (From m In db.HarvestLogs Where m.harvestkey = "H1QESGH2BPCX" And m.marketdate >= "1/01/2017" Order By m.harvestkey, m.marketdate Select m).ToList()                                          ' NEED TO MAKE THIS PULL THE DROPDOWN HARVESTKEY - ANY CHANGE NEEDS TO AJAX A REPULL OF THE DATA.

            ''Dim loglist = (From m In db.HarvestLogs Where m.harvestkey = "H1QESGH2BPCX" Group By LogYear = m.marketdate.Value.Year Into Grouped = Group Select).ToList()

            'Dim loglist = From t In db.HarvestLogs Where t.harvestkey = "H1QESGH2BPCX" Group t By keys = New With {Key t.marketdate.Value.Year, t.marketdate.Value.Month} Into Group
            '    Order By keys.Year, keys.Month Ascending _
            '    Select New With {.year = keys.Year, .month = keys.Month, .bought = Group.Sum(Function(x) x.sharesbought), .sold = Group.Sum(Function(x) x.sharessold)}






            ' Dim summary5 = team.GroupBy(Function(x) New With {Key x.Office, Key x.Department}) _
            '.Select(Function(y) New With {.office = y.Key.Office, _
            '                              .dept = y.Key.Department, _
            '                              .sum = y.Sum(Function(x) x.Salary), _
            '                              .max = y.Max(Function(x) x.Salary)}) _
            '                              .OrderBy(Function(x) x.office) _
            '                              .ThenBy(Function(x) x.dept)



            'For Each item In loglist
            '    MsgBox(item.month & "/" & item.year & " " & item.bought & " " & item.sold)
            'Next

            'Stop



            'Dim model As New wavesViewModel()                                                                                                                                           ' INSTANCIATES A NEW MODEL TO PASS DATA FROM CONTROLLER TO VIEW
            'model.AllIndexes = indexlist                                                                                                                                                ' ADDS THE INDEX DATA TO THE MODEL
            ''model.AllLogs = loglist                                                                                                                                                     ' ADDS THE LOG DATA TO THE MODEL
            ''model.Allhedges = hedgelist

            ''For Each Item In model.AllLogs
            ''    ' MsgBox(Item.marketdate)
            ''Next

            'ViewData("msg") = "Select back test and enter file date to run back test."                                                                                                  ' VIEWDATA MESSAGE TO SUPPLY USER INFORMATION BACK TO THE VIEW

            'ViewData("asdf") = "test."                                                                                                  ' VIEWDATA MESSAGE TO SUPPLY USER INFORMATION BACK TO THE VIEW

            'Return View(model)                                                                                                                                                          ' INITIATES ROUTING TO THE VIEW PASSING THE MODEL WITH ALL THE ADDED DATA

            'End Using

            Dim connected As String = ""
            Dim msg As String = ""
            Call Tws1.connect("", 7497, 0, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                connected = "Online"
                'msg = "Connected to Tws server version " & Tws1.serverVersion() &
                ' " at " & Tws1.TwsConnectionTime()
            Else
                connected = "Off-line"
            End If

            'MsgBox("NextValidId - OrderId [" & nextOrderId & "]")

            'Dim contract As IBApi.Contract = New IBApi.Contract()
            'contract.Symbol = "AAPL"
            'contract.SecType = "STK"
            'contract.Currency = "USD"
            'contract.Exchange = "SMART"
            'Tws1.Symbol = contract.Symbol
            'Tws1.reqMarketDataType(3)
            ''Tws1.reqRealTimeBarsEx(10001, contract, 5, "", False, Nothing)
            'Dim queryTime As String = DateTime.Now.AddMonths(-3).ToString("yyyyMMdd HH:mm:ss")

            ''Tws1.reqHistoricalDataEx(1, contract, queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, Nothing)
            'Tws1.reqMktDataEx(1, contract, "", False, Nothing)

            'Thread.Sleep(10000)
            'msg += " Stock Price:" & Tws1.StockTickPrice
            'ViewData("Message") = msg
            'Tws1.cancelMktData(1)
            'Tws1.cancelOrder(1)
            'Tws1.OrderID = 1
            'Dim Contract As IBApi.Contract = New IBApi.Contract
            'Contract.Symbol = "GOOG"
            'Contract.SecType = "OPT"
            'Contract.Exchange = "BOX"
            'Contract.Currency = "USD"
            'Contract.LastTradeDateOrContractMonth = "20171215"
            'Contract.Strike = 1020
            'Contract.Right = "P"

            'Dim order As IBApi.Order = New IBApi.Order()

            'order.OrderId = (Tws1.OrderID + 1)

            'order.Action = "BUY"
            'order.OrderType = "LMT"
            'order.TotalQuantity = 1
            'order.LmtPrice = 0.8
            'order.Tif = "DAY"

            'Tws1.placeOrderEx(order.OrderId, Contract, order)

            'Tws1.nextValidId(0)

            'Tws1.reqIds(2)

            'Stop




            Tws1.reqPositions()                                                                                                                                                         ' CALL TO PULL ALL POSITIONS IN PORTFOLIO

            Tws1.reqAllOpenOrders()                                                                                                                                                    ' CALL TO PULL ALL OPEN POSITIONS

            'Call Tws1.reqHistoricalDataEx(1, contract, "20171120 00:00:00", "1 D", "1 min", "MIDPOINT", 0, 1, Nothing)

            Thread.Sleep(1000)



            Tws1.listPositionsMessage = Tws1.listPositionsMessage.Select(Function(x) x).Distinct().ToList()

            Tws1.listOrderStatus = Tws1.listOrderStatus.Select(Function(x) x).Distinct().ToList()                                                                                       ' REMOVE ANY DUPLICATES FROM THE OPEN ORDERS LIST
            msg = (Tws1.listOrderStatus.Count())                                                                                                                                        ' OBTAIN THE TOTAL NUMBER OF OPEN ORDERS TO DISPLAY ON THE PAGE

            Dim model As New wavesViewModel()                                                                                                                                           ' INSTANCIATES A NEW MODEL TO PASS DATA FROM CONTROLLER TO VIEW
            model.OrderList = Tws1.OpenOrderList
            'model.PositionList = Tws1.listPositionsMessage

            'For Each item In model.PositionList
            '    MsgBox(item.Contract.Symbol)
            'Next

            ViewData("Message") = msg
            ViewData("connected") = connected

            Tws1.disconnect()
            'Dim historicalPrice As HistoricalDataMessage = New HistoricalDataMessage()
            'historicalPrice = Tws1.listHistoricalPrice.Item(0)
            'Return View()

            Return View(model)
        End Function

        'Function Index() As ActionResult

        'Dim datastring As String = ""
        'Dim Tws1 As Tws = New Tws()

        'Call Tws1.connect("", 7497, 1, False)
        'If (Tws1.serverVersion() > 0) Then
        '    datastring = "Connected to Tws server version " & Tws1.serverVersion() & " at " & Tws1.TwsConnectionTime()
        'End If

        'Tws1.msgProcessing()


        '' Dim datastring As String = "getDataAPI"
        'Dim contract As IBApi.Contract = New Contract()
        'contract.Symbol = "EUR"
        'contract.SecType = "CASH"
        'contract.Currency = "USD"
        'contract.Exchange = "IDEALPRO"
        'Tws1.Symbol = contract.Symbol

        ''Dim Tws1 As Tws = New Tws()

        ''Tws1.reqRealTimeBarsEx(10001, contract, 5, "", False, Nothing)
        'Dim queryTime As String = DateTime.Now.AddMonths(-3).ToString("yyyyMMdd HH:mm:ss")

        ''Tws1.reqHistoricalDataEx(1, contract, queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, Nothing)
        'Tws1.reqMktDataEx(1, contract, "", False, Nothing)

        'Thread.Sleep(5000)

        'MsgBox(Tws1.StockTickPrice.ToString())

        '    Return View()
        'End Function


        <HttpPost()> _
        Function apiStarting(ByVal testdata As String) As ActionResult
            Dim datastring As String = "Starting"
            Return Content(datastring)
        End Function

        <HttpPost()> _
        Function apiPortfolio(ByVal testdata As String) As ActionResult
            Dim datastring As String = "Starting"
            Dim msg As String = ""

            Call Tws1.connect("", 7497, 9, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                msg = "Connected to Tws server version " & Tws1.serverVersion() &
                              " at " & Tws1.TwsConnectionTime()
            End If
            ' Tws1.reqPositions()
            ' Thread.Sleep(10000)
            Stop
            Tws1.disconnect()

            Return Content(datastring)
        End Function

        Function IBTest() As ActionResult

            Return View()
        End Function

        <HttpPost()> _
        Function connectAPI(ByVal testdata As Date) As ActionResult

            'TWS Paper trading userid: tpaper182
            'TWS paper trading pw: Roswell182

            Dim datastring As String = ""
            Dim Tws1 As Tws = New Tws()

            Call Tws1.connect("", 7497, 1, False)
            If (Tws1.serverVersion() > 0) Then
                datastring = "Connected to Tws server version " & Tws1.serverVersion() & " at " & Tws1.TwsConnectionTime()
            End If

            Tws1.msgProcessing()


            ' Dim datastring As String = "getDataAPI"
            '            Dim contract As IBApi.Contract = New Contract()
            '            contract.Symbol = "EUR"
            '            contract.SecType = "CASH"
            '            contract.Currency = "USD"
            '            contract.Exchange = "IDEALPRO"
            '            Tws1.Symbol = contract.Symbol

            'Dim Tws1 As Tws = New Tws()

            'Tws1.reqRealTimeBarsEx(10001, contract, 5, "", False, Nothing)
            '            Dim queryTime As String = DateTime.Now.AddMonths(-3).ToString("yyyyMMdd HH:mm:ss")

            'Tws1.reqHistoricalDataEx(1, contract, queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, Nothing)
            '            Tws1.reqMktDataEx(1, contract, "", False, Nothing)

            '            Thread.Sleep(5000)

            '            MsgBox(Tws1.Symbol & ": " & Tws1.StockTickPrice.ToString())

            Return Content(datastring)
        End Function

        <HttpPost()> _
        Function disconnectAPI(ByVal testdata As Date) As ActionResult

            Dim datastring As String = ""
            Dim Tws1 As Tws = New Tws()

            Call Tws1.disconnect()
            If (Tws1.serverVersion() = 0) Then
                datastring = "Successfully disconnected from TWS at " & DateTime.Parse(Now()).ToShortTimeString()
            End If

            Return Content(datastring)
        End Function

        <HttpPost()> _
        Function apiOrder(ByVal symbol As String, ByVal rowid As Integer, ByVal testdata As Date) As ActionResult

            'Dim lower As Integer = 11
            'Dim upper As Integer = 75

            Dim rnd As Integer = RandomGenerator() * 0.0001
            If rnd < 0 Then
                rnd = rnd * -1
            End If

            If symbol = "" Then
                symbol = "AAPL"
            End If
            symbol = symbol.ToUpper()
            Dim datastring As String = ""                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

            Call Tws1.connect("", 7497, 9, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                datastring = "Connected to Tws server version " & Tws1.serverVersion() &
                              " at " & Tws1.TwsConnectionTime()
            Else
                datastring = "Unable to connect to TWS."
                'Return Content(datastring)
            End If

            'Tws1.OrderID = rnd
            Dim contract As IBApi.Contract = New IBApi.Contract()
            contract.Symbol = symbol
            contract.SecType = "STK"
            contract.Currency = "USD"
            contract.Exchange = "SMART"
            Dim order As IBApi.Order = New IBApi.Order()

            order.OrderId = rnd

            order.Action = "BUY"
            order.OrderType = "LMT"
            order.LmtPrice = 28.0
            order.TotalQuantity = 100

            Call Tws1.placeOrderEx(order.OrderId, contract, order)
            Thread.Sleep(5000)

            datastring = rowid & ": " & DateTime.Parse(Now()).ToShortTimeString() & " Order Id:" & order.OrderId & " Symbol: " & symbol & " Total Shares: " & order.TotalQuantity & " Price: " & order.LmtPrice & " Order Status:" & Tws1.Status

            Tws1.disconnect()
            rnd = 0
            'MsgBox(datastring)

            Return Content(datastring)
        End Function

        <HttpPost()> _
        Function apiOrderStatus(ByVal testdata As Date) As ActionResult

            Dim datastring As String = "getDataAPI"                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

            Tws1.listOrderStatus.Clear()

            Call Tws1.connect("", 7497, 9, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                'datastring = "Connected to Tws server version " & Tws1.serverVersion() &
                '              " at " & Tws1.TwsConnectionTime()
                datastring = ""
            Else
                'datastring = "Unable to connect to TWS."
                datastring = ""
                'Return Content(datastring)
            End If

            Call Tws1.reqAllOpenOrders()
            'Call Tws1.reqOpenOrders()

            Thread.Sleep(5000)

            For Each OpenOrders In Tws1.OpenOrderList

                'MsgBox(OpenOrders.PermId & " : " & OpenOrders.Symbol)
                datastring += " Order Id: " & OpenOrders.PermId & " Symbol: " & OpenOrders.Symbol & "<br/>"
            Next
            Tws1.disconnect()

            'MsgBox(datastring)

            Return Content(datastring)

        End Function

        <HttpPost()> _
        Function apiOption(ByVal testdata As Date) As ActionResult

            Dim datastring As String = "getDataAPI"                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES


            Call Tws1.connect("", 7497, 9, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                datastring = "Connected to Tws server version " & Tws1.serverVersion() &
                              " at " & Tws1.TwsConnectionTime()
            Else
                datastring = "Unable to connect to TWS."
                'Return Content(datastring)
            End If

            Tws1.OrderID = 10
            Dim Contract As IBApi.Contract = New IBApi.Contract
            Contract.Symbol = "GOOG"
            Contract.SecType = "OPT"
            Contract.Exchange = "BOX"
            Contract.Currency = "USD"
            Contract.LastTradeDateOrContractMonth = "20171215"
            Contract.Strike = 1020
            Contract.Right = "P"

            Dim order As IBApi.Order = New IBApi.Order()

            order.OrderId = (Tws1.OrderID + 1)

            order.Action = "BUY"
            order.OrderType = "LMT"
            order.TotalQuantity = 1
            order.LmtPrice = 0.8
            order.Tif = "DAY"

            Call Tws1.placeOrderEx(order.OrderId, contract, order)
            Thread.Sleep(10000)

            datastring += " Order Id:" & Tws1.OrderID & " Order Status:" & Tws1.Status

            Tws1.disconnect()

            'MsgBox(datastring)

            Return Content(datastring)
        End Function

        <HttpPost()> _
        Function apiHistorical(ByVal testdata As Date) As ActionResult

            Dim datastring As String = "getDataAPI"                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES

            Call Tws1.connect("", 7497, 9, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                datastring = "Connected to Tws server version " & Tws1.serverVersion() &
                              " at " & Tws1.TwsConnectionTime()
            Else
                datastring = "Unable to connect to TWS."
                'Return Content(datastring)
            End If

            Dim contract As IBApi.Contract = New IBApi.Contract()
            contract.Symbol = "EUR"
            contract.SecType = "CASH"
            contract.Currency = "USD"
            contract.Exchange = "idealpro"

            'Tws1.reqMarketDataType(3)                                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 

            Call Tws1.reqHistoricalDataEx(1, contract, "20171110 00:00:00", "1 D", "1 min", "MIDPOINT", 0, 1, Nothing)  'MIDPOINT

            Thread.Sleep(10000)

            Tws1.disconnect()

            Dim historicalPrice As HistoricalDataMessage = New HistoricalDataMessage()
            'historicalPrice = Tws1.listHistoricalPrice.FirstOrDefault(Function(x) x.Date = "20171119  16:20:00")                                        ' WILL PULL THE INTERVAL DATA FOR THE SPECIFIC DATE AND TIME BASED ON THAT DATE/TIME REQUESTED USING LINQ

            historicalPrice = Tws1.listHistoricalPrice.Item(5)


            Return Content(datastring)
        End Function

        <HttpPost()> _
        Function getDataAPI(ByVal testdata As Date, ByVal symbol As String, ByVal rowid As Integer) As ActionResult

            If symbol = "" Then
                symbol = "AAPL"
            End If

            Dim datastring As String = "getDataAPI"                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES
            'Dim msg As String = ""
            Call Tws1.connect("", 7497, 9, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                datastring = "Connected to Tws server version " & Tws1.serverVersion() &
                              " at " & Tws1.TwsConnectionTime()
            Else
                datastring = "Unable to connect to TWS."
                'Return Content(datastring)
            End If

            Dim contract As IBApi.Contract = New IBApi.Contract()
            contract.Symbol = symbol.ToUpper()
            contract.SecType = "STK"
            contract.Currency = "USD"
            contract.Exchange = "SMART"
            Tws1.Symbol = contract.Symbol

            'Tws1.reqRealTimeBarsEx(10001, contract, 5, "", False, Nothing)
            'Dim queryTime As String = DateTime.Now.AddMonths(-3).ToString("yyyyMMdd HH:mm:ss")

            'Tws1.reqHistoricalDataEx(1, contract, queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, Nothing)

            Tws1.reqMarketDataType(3)                                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 

            Tws1.reqMktDataEx(1, contract, "", False, Nothing)

            Thread.Sleep(10000)

            datastring = contract.Symbol & " Price at " & DateTime.Parse(Now()).ToShortTimeString() & " : " & Tws1.OrderID

            Tws1.cancelMktData(1)

            Call Tws1.disconnect()

            Return Content(datastring)

        End Function

        <HttpPost()> _
        Function runRobot(ByVal testdata As Date, ByVal symbol As String, ByVal rowid As Integer) As ActionResult

            ' VARIABLES USED IN THIS FUNCTION
            Dim csvdata As String = ""                                                                                                                                                  ' USED TO HOUSE THE TEXT FILE             
            Dim path As String = "~\\content\assets\excel\intervals.csv"                                                                                                                ' BASE PATH OF THE FILE TO BE READ INTO MEMORY.
            Dim fullpath As String = Request.MapPath("~\\content\assets\excel\intervals.csv")                                                                                           ' PROVIDES INTERVAL INFORMATION TO CALC THE ORDERID FOR EACH INTERVAL PER DAY.
            Dim datastring As String = ""                                                                                                                                               ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS.
            Dim width As Integer = 0.25                                                                                                                                                 ' WIDTH VARIABLE CONTAINING THE AMOUNT BETWEEN PRICES EACH TIME YOU BUY OR SELL.
            Dim connected As String = ""                                                                                                                                                ' STRING INITIALIZED WHEN CONNECTED TO TWS - DISPLAYS THE STATUS ONLINE OR OFFLINE.
            Dim rnd As String = ""

            datastring = rowid & ": " & String.Format("{0:hh:mm:ss}", testdata.ToLocalTime) & " "                                                                                       'INITIALIZE DATASTRING WITH ROWID, AND TIME

            Using textReader As New System.IO.StreamReader(fullpath)                                                                                                                    ' TEXT READER PULLS AND READS THE FILE.
                csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
            End Using                                                                                                                                                                   ' CLOSE THE TEXT READER.

            Dim intervals As List(Of interval) = ParseIntervalData(csvdata)                                                                                                             ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.

            Dim timetemp As String = (String.Format("{0:h:mm}", Now()))

            For Each interval In intervals
                If timetemp = interval.iTime Then
                    'MsgBox(Month(Now()) & Day(Now()) & interval.Interval + 1 & " " & interval.iTime)
                    rnd = Mid(Year(Now()), 3, 2) & Month(Now()) & Day(Now()) & (interval.Interval + 1)
                End If
            Next

            Call Tws1.connect("", 7497, 0, False)
            Tws1.msgProcessing()
            If (Tws1.serverVersion() > 0) Then
                connected = "Online"
            Else
                connected = "Off-line"
            End If

            Dim contract As IBApi.Contract = New IBApi.Contract()
            'MsgBox(ordernumber)
            contract.Symbol = symbol.ToUpper()
            contract.SecType = "STK"
            contract.Currency = "USD"
            contract.Exchange = "SMART"
            Tws1.Symbol = contract.Symbol

            Tws1.reqMarketDataType(3)                                                                                                                       ' SETS DATA FEED TO (1) LIVE STREAMING  (2) FROZEN  (3) DELAYED 15 - 20 MINUTES 
            Tws1.reqMktDataEx(1, contract, "", False, Nothing)                       '""
            Thread.Sleep(5000)

            'Call Tws1.reqAllOpenOrders()
            'For Each OpenOrders In Tws1.OpenOrderList

            '    'MsgBox(OpenOrders.PermId & " : " & OpenOrders.Symbol)
            '    datastring += " Order Id: " & OpenOrders.PermId & " Symbol: " & OpenOrders.Status & "<br/>"
            'Next

            'If Tws1.StockTickPrice <> 0 Then

            'If Tws1.StockTickPrice <= 28 Then

            'Dim rnd As Integer = RandomGenerator() * 0.0001
            'If rnd < 0 Then
            '    rnd = rnd * -1
            'End If

            'Dim contract As IBApi.Contract = New IBApi.Contract()
            'contract.Symbol = symbol.ToUpper()
            'contract.SecType = "STK"
            'contract.Currency = "USD"
            'contract.Exchange = "SMART"
            Dim order As IBApi.Order = New IBApi.Order()

            rnd = Mid(Year(Now()), 3, 2) & Month(Now()) & Day(Now()) & (rowid + 1)             ' TEST to see is this works - may want to comment it out once verified adding year works

            order.OrderId = CInt(rnd)
            order.Action = "BUY"
            order.OrderType = "LMT"
            order.Tif = "GTC"
            order.LmtPrice = 1.5 '- (rowid * width)
            order.TotalQuantity = 100



            'Call Tws1.reqAllOpenOrders()
            'For Each OpenOrders In Tws1.OpenOrderList

            'MsgBox(OpenOrders.Symbol & " " & OpenOrders.LmtPrice & " " & OpenOrders.Status & " : " & Tws1.Status)

            'Next

            Call Tws1.placeOrderEx(rnd, contract, order)
            Thread.Sleep(10000)

            datastring = datastring & contract.Symbol & " : " & (String.Format("{0:C}", Tws1.StockTickPrice)) & " Order Id:" & order.OrderId &
                " Total Shares: " & order.TotalQuantity & " Price: " & (String.Format("{0:C}", order.LmtPrice)) & " Order Status: " & Tws1.Status & " - "

            'Else
            '   datastring = datastring & contract.Symbol & " : " & Tws1.StockTickPrice
            'End If

            ' Else
            'datastring = datastring & contract.Symbol & " : Error"
            'End If

            Call Tws1.reqAllOpenOrders()
            For Each OpenOrders In Tws1.OpenOrderList

                If OpenOrders.OId = order.OrderId Then
                    datastring = datastring & "C"

                End If

            Next


            Tws1.cancelMktData(1)

            Call Tws1.disconnect()

            Return Content(datastring)
        End Function                                                                                                                                                                                                                    ' ROBOT MAIN FUNCTION




        '<HttpPost()> _
        'Function getDataAPI(ByVal testdata As Date) As ActionResult

        '    Dim datastring As String = "getDataAPI"                                                                                                         ' SETS THE INITIAL DATASTRING VALUE - REWRITTEN WHEN THE CODE EXECUTES





        '    Dim contract As IBApi.Contract = New Contract()                                                                                                 ' ESTABLISHES A NEW OBJECT CONTRACT USED TO REQUEST ASSOCIATED DATA
        '    contract.Symbol = "TSLA"                                                                                                                        ' CONTRACT SYMBOL - THIS WILL BE PASSED FROM THE VIEW WHEN FUNCTION IS CALLED
        '    contract.SecType = "STK"                                                                                                                        ' SECURITY TYPE REQUESTED CAN BE STK, CASH, OPT, & FUT : WILL USE STK MOST OFTEN TESTING WITH CASH
        '    contract.Currency = "USD"                                                                                                                       ' CURRENCY - TYPICALLY USD
        '    contract.Exchange = "SMART"                                                                                                                     ' EXCHANGE TO LEVERAGE FOR THE CONTRACT CAN BE : IDEALPRO, ISLAND, SMART AND OTHERS
        '    contract.PrimaryExch = "SMART"                                                                                                                 ' PRIMARY EXCHANGE THAT CAN BE LEVERAGED ALSO
        '    'Tws1.Symbol = contract.Symbol                                                                                                                   ' SETS THE OBJECT SYMBOL FOR THE TWS ELEMENT THE SAME AS THE CONTRACT OBJECT SYMBOL

        '    Dim order As IBApi.Order = New Order()
        '    order.Action = "action"
        '    order.OrderType = "LMT"
        '    order.TotalQuantity = 1
        '    order.LmtPrice = 5.0




        '    Tws1.placeOrderEx(1, contract, order)

        '    '            Tws1.reqMktDataEx(1, contract, "", False, Nothing)

        '    Thread.Sleep(5000)

        '    datastring = DateTime.Parse(Now()).ToShortTimeString() & " " & contract.Symbol & ": " & Tws1.StockTickPrice.ToString()

        '    Return Content(datastring)
        'End Function

        <HttpGet()> _
        Function blackscholes() As ActionResult

            ViewData("callprice") = ""
            ViewData("putprice") = ""

            Return View()

        End Function

        <HttpPost()> _
        Function blackscholes(ByVal price As Double, ByVal strike As Double, ByVal vol As Double, ByVal interest As Double, ByVal dividend As Double, ByVal pricedate As Date, ByVal expdate As Date) As ActionResult

            Dim excel As New Excel.Application

            Dim fullpath As String = Request.MapPath("~\\content\assets\excel\bondi.xlsx")

            Dim wb As Excel.Workbook = excel.Workbooks.Open(fullpath)
            Dim ws As Excel.Worksheet = wb.Sheets(1)

            Dim stockprice As Double = price
            'Dim strike As Double = 12
            Dim startdate As Date = pricedate '#7/5/2017# 'Date.Now
            Dim enddate As Date = expdate '#8/18/2017#

            Dim timetoexpiration As TimeSpan = enddate.Subtract(startdate)
            Dim dte As Integer = timetoexpiration.Days
            Dim prctofyear As Double = dte / 365

            Dim iv As Double = vol
            Dim interestrate As Double = interest
            'Dim dividend As Double = 0

            Dim a1 As Double = Log(stockprice / strike)                                         ' Column H
            Dim a2 As Double = (interestrate - dividend + Pow(iv, 2) / 2) * prctofyear          ' Column I
            Dim a3 As Double = Max(0.000000000001, iv * Sqrt(prctofyear))                       ' Column J
            Dim d1 As Double = (a1 + a2) / a3                                                   ' Column K
            Dim d2 As Double = d1 - a3                                                          ' Column L

            ' Dim d1 As Double = (Log(stockprice / strike) + (interestrate + iv ^ 2 / 2) * prctofyear) / (iv * Sqrt(prctofyear))                                                                                                                    ' d1 = (Log(S / X) + (r + v ^ 2 / 2) * T) / (v * Sqr(T))
            ' Dim d2 As Double = d1 - Max(0.000000000001, iv * Sqrt(prctofyear))

            ws.Range("B2").Value = "=NORM.DIST(" & d1 & ",0,1,TRUE)"
            ws.Range("B3").Value = "=NORM.DIST(" & -d1 & ",0,1,TRUE)"
            ws.Range("B4").Value = "=NORM.DIST(" & d2 & ",0,1,TRUE)"
            ws.Range("B5").Value = "=NORM.DIST(" & -d2 & ",0,1,TRUE)"

            Dim Nd1 As Double = ws.Range("b2").Value
            Dim Nd1n As Double = ws.Range("b3").Value
            Dim Nd2 As Double = ws.Range("b4").Value
            Dim Nd2n As Double = ws.Range("b5").Value

            Dim ert As Double = Exp(-interestrate * prctofyear)
            Dim Xert As Double = strike * ert
            Dim Eqtn As Double = Exp(-dividend * prctofyear)
            Dim Soe As Double = stockprice * Eqtn
            Dim callprice As Double = Soe * Nd1 - Xert * Nd2
            Dim putprice As Double = Xert * Nd2n - Soe * Nd1n

            ViewData("callprice") = callprice
            ViewData("putprice") = putprice
            'ViewData("stockprice") = stockprice
            'ViewData("strikeprice") = strike
            'ViewData("expdate") = enddate


            ws = Nothing
            wb.Close(False)
            wb = Nothing

            excel.Quit()
            excel = Nothing
            'Dim sheetName = wb.Sheets(1).Name

            'Stop

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
                Dim loglist = (From m In db.HarvestLogs Where m.harvestkey = "W3G02T43L4K3" Order By m.harvestkey, m.marketdate Select m).ToList()                              ' NEED TO MAKE THIS PULL THE DROPDOWN HARVESTKEY - ANY CHANGE NEEDS TO AJAX A REPULL OF THE DATA.

                Dim model As New wavesViewModel()
                model.AllIndexes = indexlist
                model.AllLogs = loglist
                'model.Allhedges = hedgelist

                ViewData("msg") = "Select back test and enter file date to run back test."

                Return View(model)

            End Using

            'Return View(model)
        End Function

        Function yahoodata(ByVal robotsymbol As String, ByVal robotdate As String, ByVal rowid As Integer) As ActionResult
            Dim datastring As String = "yahoo"
            Return Content(datastring)
        End Function

        <HttpPost> _
        Function backtest(ByVal robotdate As String, ByVal robotindex As String) As ActionResult
            ' **********   BACK TESTING FUNCTIONS    **********
            Dim datastring As String = "Successfully completed daily run for " & robotdate
            ' Pull Harvestindex information to begin the processing
            Using db As New wavesDataContext                                                                                ' ESTABLISH CONNECTION TO THE DATABASE
                Dim hi = db.GetHarvestIndex(robotindex, True)






                ViewData("msg") = datastring
            End Using
            Return RedirectToAction("backtest", "member")

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
            'Dim userid As Guid                                                                                                                                                                 ' USERID ADDED TO RECORDS FOR EACH USER
            Dim csvdata As String                                                                                                                                                               ' USED TO HOUSE THE TEXT FILE             
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                                ' BASE PATH OF THE FILE TO BE READ INTO MEMORY.
            Dim datastring As String = ""                                                                                                                                                       ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS.
            Dim loopcounter As Integer = 0                                                                                                                                                      ' COUNTER FOR THE ROWS TO BE PROCESSED.
            Dim mark As Double = 0                                                                                                                                                              ' HOLDS THE CURRENT PRICE OF THE MARK.            
            Dim direction As String = ""                                                                                                                                                        ' INDICATOR OF THE INTERVAL GOING UP OR DOWN - OPEN TO CLOSE.
            Dim symbol As String                                                                                                                                                                ' SYMBOL OF THE PRODUCT SELECTED FOR THE AUTOMATED SYSTEM.   { = robotsymbol.ToUpper()  }
            Dim markettime As New DateTime                                                                                                                                                      ' TIME INTERVAL FOR THE DATASET ROW FOR THE DAY BEING PROCESSED.
            Dim marketdate As New DateTime                                                                                                                                                      ' DATE INTERVAL FOR THE DATASET BEING PROCESSED.
            Dim OpenMark As Double = 0                                                                                                                                                          ' HOLDS THE NEW MARK BASED ON THE MOVEMENT OF PRICE IN THE INTERVAL AND TRIGGER POINTS HIT.

            ' **********  OPEN THE DATABASE **********
            Using db As New wavesDataContext

                Dim hi = db.GetHarvestIndex(robotindex, True)                                                                                                                                   ' PULLS RELEVANT DATA BASED ON THE EXPERIMENT SELECTED.
                symbol = hi.product.ToUpper()                                                                                                                                                   ' SETS THE SYMBOL FOR THE BACKTEST BASED ON THE EXPERIMENT SELECTED.

                ' ********** STEP 1: READ DATA INTO PRICE OBJECT **********
                path = path & robotdate & "\table_" & symbol & ".csv"                                                                                                                           ' SET THE PATH AND FILENAME FOR THE CSV FILE TO BE READ INTO MEMORY.

                If My.Computer.FileSystem.FileExists(path) Then                                                                                                                                 ' CHECKS TO SEE WHETHER THE FILE FOR THIS DATE EXISTS BEFORE ATTEMPTING TO PROCESS IT.
                    Using textReader As New System.IO.StreamReader(path)                                                                                                                        ' TEXT READER PULLS AND READS THE FILE.
                        csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING.
                    End Using                                                                                                                                                                   ' CLOSE THE TEXT READER.
                Else
                    MsgBox("File Does not Exist. Please review and correct.")                                                                                                                   ' MESSAGE TO THE USER THAT THIS DATE DOES NOT EXIST.  < SHOULD BUILD OUT A TABLE WITH ALL TRADING DATES IN 2016 & 2017 AND READ AND LOOP THORUGH THEM >            
                    Return RedirectToAction("backtest", "member")                                                                                                                               ' BECAUSE OF THE ERROR RETURN BACK TO THE BACKTEST PAGE FOR USER TO CORRECT THE ERROR.
                End If

                Dim backprices As List(Of backPrice) = ParseBackData(csvdata)                                                                                                                   ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.

                ' ********** STEP 2: PROCESS EACH RECORD IN PRICE OBJECT **********

                For Each price As backPrice In backprices                                                                                                                                       ' LOOP THROUGH EACH ROW OF THE PRICES FOR THE DATE SELECTED.

                    direction = checkdirection(price.OpenPrice, price.HighPrice, price.LowPrice, price.ClosePrice)                                                                              ' CALL FUNCTION TO CHECK INTERVAL DIRECTION AND RETURN AN INDICATOR.
                    markettime = String.Format("{0:t}", price.MarketDate)                                                                                                                       ' FORMAT MARKETTIME FOR PRESENTATION.

                    If rowid = 0 Then

                        Dim newHarvestLog As New HarvestLog
                        TryUpdateModel(newHarvestLog)                                                                                                                                           ' TEST CONNECTION TO DATABASE TABLES.
                        Dim newlog As New HarvestLog With { _
                                                        .opens = 0, _
                                                        .closes = 0, _
                                                        .harvestkey = robotindex.ToUpper, _
                                                        .marketdate = Date.Parse(price.MarketDate).ToUniversalTime().ToShortDateString, _
                                                        .stockprofit = 0, _
                                                        .hedgeprofit = 0, _
                                                        .currentcapital = 0, _
                                                        .maxcapital = 0, _
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .hedgebought = 0, _
                                                        .hedgesold = 0, _
                                                        .sharesbought = 0, _
                                                        .sharessold = 0, _
                                                        .otimestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .trans = 0 _
                                                        }                                                                                                                                            ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.HarvestLogs.InsertOnSubmit(newlog)                                                                                                                                   ' INSERT THE NEW RECORD TO BE ADDED.
                        db.SubmitChanges()

                    End If

                    If loopcounter = rowid Then

                        ' CHECK TO SEE IF THIS INTERVAL HAS BEEN ADDED TO THE HARVESTINTERVALS TABLE.  IF NOT ADD IT, IF SO DO NOT ADD IT.
                        ' ADD THIS CODE ONCE THE TESTING OF THE OPEN, HIGH, LOW, AND CLOSE HAS BEEN COMPLETED.

                        datastring = String.Format("{0: hh:mm tt}", markettime)                                                                                                                 ' SETS THE TIME FOR THE ROW INTERVAL.
                        datastring = datastring & " " & symbol.ToUpper() & " " & direction                                                                                                      ' SETS THE SYMBOL, AND DIRECTION FOR THE ROW INTERVAL.

                        OpenMark = getOpenMark(symbol, price.OpenPrice, price.MarketDate, hi.harvestKey)                                                                                        ' CALLED FUNCTION TO GO GET THE OPENING MARK PRICE VALUE.

                        datastring = datastring & " M: " & (String.Format("{0:C}", OpenMark))                                                                                                   ' SETS THE OPENING MARK FOR THE ROW INTERVAL.

                        If loopcounter = 0 Then
                            datastring = datastring & CheckOpenPrice(symbol, price.OpenPrice, price.MarketDate, OpenMark, 0, hi.width, hi.harvestKey)
                        Else
                            datastring = datastring & CheckOpenPrice(symbol, price.OpenPrice, price.MarketDate, OpenMark, 1, hi.width, hi.harvestKey)
                        End If

                        If direction = "U" Then

                            ' CHECK THE LOW PRICE
                            OpenMark = getOpenMark(symbol, price.LowPrice, price.MarketDate, hi.harvestKey)                                                                                     ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckLowPrice(symbol, price.LowPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey, rowid)                                                ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE HIGH PRICE
                            OpenMark = getOpenMark(symbol, price.HighPrice, price.MarketDate, hi.harvestKey)                                                                                    ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckHighPrice(symbol, price.HighPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey, rowid)                                              ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE CLOSING PRICE
                            OpenMark = getOpenMark(symbol, price.ClosePrice, price.MarketDate, hi.harvestKey)                                                                                   ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckClosePrice(symbol, price.ClosePrice, price.MarketDate, OpenMark, direction, hi.width, hi.harvestKey, rowid)                          ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                        Else

                            ' CHECK THE HIGH PRICE
                            OpenMark = getOpenMark(symbol, price.HighPrice, price.MarketDate, hi.harvestKey)                                                                                    ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckHighPrice(symbol, price.HighPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey, rowid)                                              ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE LOW PRICE
                            OpenMark = getOpenMark(symbol, price.LowPrice, price.MarketDate, hi.harvestKey)                                                                                     ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckLowPrice(symbol, price.LowPrice, price.MarketDate, OpenMark, hi.width, hi.harvestKey, rowid)                                                ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                            ' CHECK THE CLOSING PRICE
                            OpenMark = getOpenMark(symbol, price.ClosePrice, price.MarketDate, hi.harvestKey)                                                                                   ' GET THE CURRENT OPEN MARK PRICE TO EVALUATE THE LOW PRICE AGAINST TO DETERMINE IF THE TRIGGER WAS MET.
                            datastring = datastring & CheckClosePrice(symbol, price.ClosePrice, price.MarketDate, OpenMark, direction, hi.width, hi.harvestKey, rowid)                          ' CHECK THE LOW PRICE AGAINST THE OPEN MARK PRICE.

                        End If

                    End If

                    marketdate = Date.Parse(price.MarketDate).ToUniversalTime().ToShortDateString

                    loopcounter = loopcounter + 1
                    rowid = rowid + 1

                    If loopcounter = 390 Then

                        Dim hedgesleft = (From m In db.HarvestHedges Where m.open = True And m.stockatopen >= (OpenMark + 2 + hi.width) And m.harvestkey = hi.harvestKey Select m)
                        Dim hedgecount = hedgesleft.Count
                        'Stop

                        '    Dim hedgelist = (From m In db.HarvestHedges Where m.open = True And m.stockatopen > (OpenMark + 2 + hi.width) And m.harvestkey = hi.harvestKey Select m).ToList()
                        '    If hedgelist.Count() > 0 Then

                        '        For Each item In hedgelist

                        '            item.open = False
                        '            item.closedate = marketdate
                        '            item.stockatclose = OpenMark
                        '            item.timestamp = DateTime.Parse(Now).ToUniversalTime()
                        '            item.positionID = 1

                        '            db.SubmitChanges()

                        '        Next
                        '    End If

                    End If

                Next



            End Using
            MsgBox("Processing Complete for " & (String.Format("{0:d}", marketdate)))
            Return RedirectToAction("backtest", "member")
            'Return Content(datastring)
        End Function

        Function getOpenMark(ByVal symbol As String, ByVal openprice As Double, ByVal marketdate As Date, ByVal harvestkey As String) As Double
            Dim OpenMark As Double = 0

            Using db As New wavesDataContext

                If db.markExists(symbol, harvestkey) = True Then                                                                                                            ' CALL FUNCTION TO DETERMINE IF A RECORD CONTAINING A MARK EXISTS FOR THIS PRODUCT & USER.
                    Dim om = db.getopenmark(symbol, harvestkey)                                                                                                             ' PULL THE OPEN MARK RECORD.
                    OpenMark = om.mark                                                                                                                                      ' SET THE VARIABLE MARK FOR COMPARISONS WITH THE PRICES.
                Else
                    OpenMark = Math.Round((openprice) * 4, MidpointRounding.ToEven) / 4                                                                                     ' ROUND THE OPENING PRICE TO THE NEAREST QUARTER DOLLAR.
                    Dim newMark As New HarvestMark                                                                                                                          ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                    TryUpdateModel(newMark)
                    Dim new_mrk As New HarvestMark With { _
                                                    .timestamp = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                    .symbol = symbol.ToUpper(), _
                                                    .mark = OpenMark, _
                                                    .turns = 1, _
                                                    .harvestkey = harvestkey, _
                                                    .open = True _
                                                    }                                                                                                                       ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                    db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                                 ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                    db.SubmitChanges()                                                                                                                                      ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.
                End If

            End Using

            Return OpenMark
        End Function

        Function CheckOpenPrice(ByVal symbol As String, ByVal openprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal indicator As Integer, ByVal width As Double, ByVal harvestkey As String) As String

            Dim datastring As String = ""
            Dim gap As Double = 0
            'Dim width As Double = 0.25
            Dim gapcntr As Integer = 0
            Dim openstatus As String = "S"
            Dim testprice As Double = 0
            Dim putprice As Double = 0

            Using db As New wavesDataContext

                If openprice - openMark > (width - 0.01) Then                                                                                                               ' DETERMINES IF THE OPEN PRICE IS GREATER THAN THE CURRENT MARK.

                    ' IF THIS CONDITION IS MET THE SELL TO CLOSE ORDER(S) WILL BE FILLED. WILL NEED TO WRITE THE CODE TO DETECT THAT AS WELL AS SET A NEW
                    ' BUY TO OPEN ORDER ONE WIDTH LEVEL BELOW THE NEW MARK.

                    gap = Math.Round((openprice + 0.01 - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                                     ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width                                                                                                                      ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED DOWN                    
                    openstatus = " S "                                                                                                                                      ' SETS THE OPEN STATUS TO STOCK OPEN THIS IS IN THE DATASTRING DISPLAY ONLY.

                    ' BECAUSE THE PRICE IS GREATER THAN THE MARK PLUS THE WIDTH THERE NEEDS TO BE A NEW MARK ESTABLISHED.

                    '***** PROCESS HARVEST POSITIONS HERE *****
                    For i = gapcntr To 1 Step -1                                                                                                                            ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                        testprice = gap + (width * i)

                        '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                        If db.posExists(harvestkey, gap - (width * i), True) = True Then                                                                                    ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP
                            Dim su = db.getposition(harvestkey, gap - (width * i), True)                                                                                 ' GET THE POSITION TO UPDATE THE RECORD.
                            su.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                     ' SET THE CLOSE DATE FOR THIS RECORD                                                                    
                            su.closeprice = su.openprice + width
                            su.open = False                                                                                                                             ' SET THE OPEN FLAG TO FALSE                            
                            su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                          ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        
                            su.closeflag = "O"

                            'db.SubmitChanges()                                                                                                                         ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                            Dim ul = db.getlog(harvestkey, marketdate)
                            ul.closes = ul.closes + 1
                            'ul.trans = ul.trans + 1
                            ul.closingmark = gap
                            ul.stockprofit = ul.stockprofit + ((su.closeprice - su.openprice) * 100)
                            ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                            ul.currentcapital = ul.currentcapital - (100 * su.closeprice)

                            db.SubmitChanges()

                            ' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                            'If db.hedgeexists(harvestkey, gap, True) = False Then                                                                                       ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                            '    Dim expyear As Integer = marketdate.Year
                            '    Dim expmonth As Integer = marketdate.Month                                                                                              ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.
                            '    expmonth = expmonth + 2                                                                                                                 ' ADD 2 MONTHS TO THE HEDGE EXPIRATION                              ****  NEED TO MAKE THIS DYNAMIC FOR USER TO SET  ****
                            '    Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                    ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****

                            '    For d = 0 To 6                                                                                                                          ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
                            '        If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                            ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                            '            exp = exp.AddDays(14)                                                                                                           ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                            '            Exit For
                            '        End If
                            '        exp = exp.AddDays(d)
                            '    Next


                            '    putprice = getPutPrice(gap, Int(gap - width - 2), marketdate, exp)

                            '    Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                            '    TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                            '    Dim newhedge As New HarvestHedge With { _
                            '                                    .symbol = symbol.ToUpper, _
                            '                                    .type = "P", _
                            '                                    .lots = 4, _
                            '                                    .strike = Int(gap - width - 2), _
                            '                                    .stockatopen = gap, _
                            '                                    .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                            '                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                            '                                    .open = True, _
                            '                                    .exp = exp, _
                            '                                    .openprice = putprice, _
                            '                                    .harvestkey = harvestkey _
                            '                                }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                            '    db.HarvestHedges.InsertOnSubmit(newhedge)

                            '    su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                            '    su.strike = Int(gap - width - 2)                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.

                            '    db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                            'End If

                        End If

                    Next

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
                        om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                      ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                        om.turns = om.turns + 1                                                                                                                         ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                        om.mark = gap                                                                                                                                   ' SET THE MARK TO THE CURRENT PRICE.

                        db.SubmitChanges()                                                                                                                              ' SUBMIT THE RECORD TO THE TABLE TO BE UPDATED.
                    End If

                    datastring = datastring & " O: " & (String.Format("{0:C}", openprice)) & openstatus & " M: " & (String.Format("{0:C}", gap))


                ElseIf openprice - openMark < (-width + 0.01) Then

                    gap = Math.Round((openprice - 0.01 + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                             ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width * -1                                                                                                                 ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED UP
                    'triggercounter = triggercounter + 1
                    'buys = buys + 1
                    openstatus = "B"

                    ' CHECK TO SEE IF POSITION EXISTS AT GAP DOWN PRICE. IF NOT THEN ADD A POSITION AT THE GAP PRICE - GAP COULD EQUAL 1 WIDTH LEVEL.
                    If db.posExists(symbol, gap, True) = False Then                                                                                             ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP

                        Dim newHarvestPosition As New HarvestPosition                                                                                                               ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                        TryUpdateModel(newHarvestPosition)                                                                                                                  ' TEST CONNECTION TO DATABASE TABLES.
                        Dim newpos As New HarvestPosition With { _
                                                        .open = True, _
                                                        .symbol = symbol.ToUpper, _
                                                        .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                        .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                        .openflag = "O", _
                                                        .harvestkey = harvestkey, _
                                                        .openprice = gap _
                                                    }                                                                                                                       ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                        db.HarvestPositions.InsertOnSubmit(newpos)                                                                                                                  ' INSERT THE NEW RECORD TO BE ADDED.                        

                        Dim ul = db.getlog(harvestkey, marketdate)
                        ul.opens = ul.opens + 1
                        'ul.trans = ul.trans + 1
                        ul.closingmark = gap
                        ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                        ul.currentcapital = ul.currentcapital + (100 * gap)

                        db.SubmitChanges()

                        ' ******************                                                  Because of a GAP DOWN need to loop this by the gap counter.

                        For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED. 
                            Dim pricetest As Double = openMark - (width * i)





                            'If db.posExists(harvestkey, pricetest + 2 + width, True) = True Then                                                                                  ' CHECK IF THERE IS A POSITION TO CLOSE BASED ON THE DROP IN PRODUCT PRICE.

                            '    If db.hedgeexists(harvestkey, pricetest + 2 + width, True) = True Then                                                                            ' CHECK TO SEE IF THERE IS A HEDGE TO MATCH THE GAP PLUS SPREAD.







                            '        Dim su = db.positionexists(harvestkey, pricetest + 2 + width, True)                                                                           ' GET THE POSITION TO UPDATE THE RECORD.
                            '        su.closeprice = pricetest
                            '        su.closeflag = "Z"                                                                                                                      ' SET CLOSEFLAG TO Z INDICATING THAT THIS POSITION WAS CLOSED VIA THE HEDGE CLOSE.
                            '        su.open = 0
                            '        su.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                            '        su.timestamp = DateTime.Parse(Now).ToUniversalTime()
                            '        ul.closes = ul.closes + 1

                            '        Dim hu = db.gethedge(harvestkey, pricetest + 2 + width, True)

                            '        putprice = getPutPrice(gap, hu.strike, marketdate, hu.exp)

                            '        hu.open = False
                            '        hu.closeprice = putprice
                            '        hu.stockatclose = pricetest
                            '        hu.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                            '        hu.timestamp = DateTime.Parse(Now).ToUniversalTime()
                            '        hu.positionID = su.id
                            '        hu.marketdate = marketdate

                            '        ul.hedgeprofit = ul.hedgeprofit + ((hu.stockatclose - hu.stockatopen) * 100) + ((putprice - hu.openprice) * hu.lots * 100)
                            '        su.hedgeid = hu.id


                            '        'Stop

                            '    End If

                            'End If

                            db.SubmitChanges()

                        Next


                    End If

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
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

        Function CheckLowPrice(ByVal symbol As String, ByVal lowprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal width As Double, ByVal harvestkey As String, ByVal rowid As Integer) As String

            ' Process will check to determine whether the current price is less than the mark.
            ' If it is then add a new position for each step down that the price is below the mark.            

            Dim datastring As String = ""
            Dim shares As Integer = 100
            Dim gap As Double = 0
            Dim gapcntr As Integer = 0
            Dim lowstatus As String = "B"
            Dim putprice As Double = 0
            Dim openpos As Integer = 0

            'If marketdate = #1/4/2016 10:17:00 AM# Then
            '    Dim stopme As String = ""
            'End If

            Using db As New wavesDataContext

                Dim ul = db.getlog(harvestkey, marketdate)                                                                                                          ' OPEN THE LOG TABLE TO RECORD ANY CHANGES BASED ON LOW PRICE.
                Dim hi = db.GetHarvestIndex(harvestkey, True)

                If lowprice - openMark < (-width + 1) Then
                    gap = Math.Round((lowprice - 0.01 + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                                ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (openMark - gap) / width                                                                                                                      ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED UP                    
                    lowstatus = "B"

                    ' STEP 1: ITERATE THE NUMBER OF LEVELS THE LOWPRICE MAY HAVE DROPPED.

                    For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                        Dim pricetest As Double = openMark - (width * i)                                                                                            ' SET THE OPENPRICE TO EACH LEVEL BELOW THE MARK. ACCOUNTS FOR OPEN TO BUY GTC ORDERS IN THE PLATFORM.

                        ' STEP 2: DETERMINE WHETHER THERE IS AN OPEN POSITION AT THIS PRICE LEVEL.  IF NOT ADD IT TO THE TABLE.

                        If db.posExists(harvestkey, gap - (width * i), True) = False Then                                                                       ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP

                            Dim newHarvestPosition As New HarvestPosition                                                                                           ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                            TryUpdateModel(newHarvestPosition)                                                                                                      ' TEST CONNECTION TO DATABASE TABLES.
                            Dim newpos As New HarvestPosition With { _
                                                            .open = True, _
                                                            .symbol = symbol.ToUpper, _
                                                            .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                            .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                            .openflag = "L", _
                                                            .openrowid = rowid, _
                                                            .harvestkey = harvestkey, _
                                                            .openprice = pricetest _
                                                        }                                                                                                           ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                            db.HarvestPositions.InsertOnSubmit(newpos)
                            db.SubmitChanges()

                            ul.sharesbought = ul.sharesbought + hi.shares
                            ul.opens = ul.opens + 1                                                                                                                     ' BECAUSE A NEW OPEN POSITION WAS ADDED INCREMENT THE OPEN COUNTER IN THE LOG.
                            ul.currentcapital = ul.currentcapital + (hi.shares * pricetest)

                            ' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                            If db.hedgeexists(harvestkey, gap, True) = False Then                                                                               ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                                Dim Exp As Date = expdate(harvestkey, marketdate)
                                Dim targetprice As Double = Int(gap - width - hi.hedgewidth)

                                putprice = getPutPrice(gap, targetprice, marketdate, Exp)

                                Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                                Dim newhedge As New HarvestHedge With { _
                                                                .symbol = symbol.ToUpper, _
                                                                .type = "P", _
                                                                .lots = 4, _
                                                                .strike = targetprice, _
                                                                .stockatopen = gap, _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .open = True, _
                                                                .exp = Exp, _
                                                                .targetexit = gap - hi.hedgewidth, _
                                                                .openprice = putprice, _
                                                                .harvestkey = harvestkey, _
                                                                .openrowid = rowid _
                                                            }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                                db.HarvestHedges.InsertOnSubmit(newhedge)

                                ul.hedgebought = ul.hedgebought + (hi.hedgelots * hi.shares)

                                Dim su = db.getposition(harvestkey, pricetest, True)

                                su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                                su.strike = targetprice                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.

                                db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                            End If


                        End If

                        ' STEP 3: CHECK TO SEE IF THERE IS A HEDGE TO CLOSE BASED ON THIS NEW LOWER PRICE LEVEL.

                        If db.chedgeexists(harvestkey, pricetest, True) = True Then                                                                            ' CHECK TO SEE IF THERE IS A HEDGE TO MATCH THE GAP PLUS SPREAD.

                            If db.posExists(harvestkey, pricetest + hi.hedgewidth, True) = True Then                                                                                  ' CHECK IF THERE IS A POSITION TO CLOSE BASED ON THE DROP IN PRODUCT PRICE.

                                Dim su = db.getposition(harvestkey, pricetest + hi.hedgewidth, True)                                                                           ' GET THE POSITION TO UPDATE THE RECORD.
                                su.closeprice = gap
                                su.closeflag = "Z"                                                                                                                      ' SET CLOSEFLAG TO Z INDICATING THAT THIS POSITION WAS CLOSED VIA THE HEDGE CLOSE.
                                su.closerowid = rowid
                                su.open = 0
                                su.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                su.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                ul.closes = ul.closes + 1

                                Dim hu = db.gethedge(harvestkey, pricetest, True)

                                putprice = getPutPrice(gap, hu.strike, marketdate, hu.exp)

                                hu.open = False
                                hu.closerowid = rowid
                                hu.closeprice = putprice
                                hu.stockatclose = pricetest
                                hu.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                hu.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                hu.positionID = su.id
                                hu.marketdate = marketdate

                                ul.hedgesold = ul.hedgesold + (hi.hedgelots * hi.shares)
                                ul.hedgeprofit = ul.hedgeprofit + ((hu.stockatclose - hu.stockatopen) * 100) + ((putprice - hu.openprice) * hu.lots * 100)
                                su.hedgeid = hu.id

                            End If

                            ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                            ul.closingmark = gap

                            db.SubmitChanges()

                        End If



                    Next

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
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

        Function CheckHighPrice(ByVal symbol As String, ByVal highprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal width As Double, ByVal harvestkey As String, ByVal rowid As Integer) As String

            Dim datastring As String = ""                                                                                                                           ' VARIABLE PASSED WITH DATA BETWEEN FUNCTIONS.
            Dim gap As Double = 0                                                                                                                                   ' VARIABLE USED TO CALCULATE THE ROUNDED PRICE ACTION AGAINST THE MARK.
            Dim gapcntr As Integer = 0                                                                                                                              ' VARIABLE USED TO CALCULATE THE NUMBER OF LEVELS THAT THE GAP MAY BE FROM THE MARK.
            Dim highstatus As String = "S"                                                                                                                          ' VARIABLE USED TO INDICATE THAT THERE WAS A SALE THAT HAS OCCURRED IN THE FUNCTION.                                                  
            Dim pos As Double = 0                                                                                                                                   ' is this variable used?
            Dim expiration As Date = Now()                                                                                                                          '************** DO I NEED THIS NOW THAT I AM CALLING THE EXPIRATION CALCS AND HEDGE FUNCTION?
            Dim putprice As Double = 0                                                                                                                              ' VARIABLE USED TO INDICATE THE PRICE OF THE PUT USED IN THE HEDGE. 

            Using db As New wavesDataContext

                Dim hi = db.GetHarvestIndex(harvestkey, True)

                If highprice - openMark > (width - 0.01) Then
                    gap = Math.Round((highprice + 0.01 - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                                 ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                    gapcntr = (gap - openMark) / width
                    highstatus = "S"

                    '***** PROCESS HARVEST POSITIONS HERE *****
                    For i = gapcntr To 1 Step -1                                                                                                                        ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                        'Dim pricetest As Double = openMark + (width * i)

                        '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                        If db.posExists(harvestkey, gap - (width * i), True) = True Then                                                                        ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP.
                            Dim su = db.getposition(harvestkey, gap - (width * i), True)                                                                     ' GET THE POSITION TO UPDATE THE RECORD.
                            su.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                 ' SET THE CLOSE DATE FOR THIS RECORD                                        
                            su.closeprice = su.openprice + width                                                                                                        ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                            su.open = False                                                                                                                             ' SET THE OPEN FLAG TO FALSE
                            su.closerowid = rowid
                            su.closeflag = "H"
                            su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                          ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                            Dim ul = db.getlog(harvestkey, marketdate)
                            ul.closes = ul.closes + 1

                            ul.sharessold = ul.sharessold + hi.shares

                            ul.closingmark = gap
                            ul.stockprofit = ul.stockprofit + ((su.closeprice - su.openprice) * 100)
                            ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                            ul.currentcapital = ul.currentcapital - (hi.shares * su.closeprice)

                            db.SubmitChanges()

                            'ADD OPEN HEDGE CALL HERE

                            'Call openHedge(harvestkey, gap)

                            '' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                            'If db.hedgeexists(harvestkey, gap, True) = False Then                                                                               ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                            '    Dim Exp As Date = expdate(harvestkey, marketdate)
                            '    Dim targetprice As Double = Int(gap - width - hi.hedgewidth)

                            '    putprice = getPutPrice(gap, targetprice, marketdate, Exp)

                            '    Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                            '    TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                            '    Dim newhedge As New HarvestHedge With { _
                            '                                    .symbol = symbol.ToUpper, _
                            '                                    .type = "P", _
                            '                                    .lots = 4, _
                            '                                    .strike = targetprice, _
                            '                                    .stockatopen = gap, _
                            '                                    .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                            '                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                            '                                    .open = True, _
                            '                                    .exp = Exp, _
                            '                                    .targetexit = gap - hi.hedgewidth, _
                            '                                    .openprice = putprice, _
                            '                                    .harvestkey = harvestkey, _
                            '                                    .openrowid = rowid _
                            '                                }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                            '    db.HarvestHedges.InsertOnSubmit(newhedge)

                            '    su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                            '    su.strike = Int(gap - width - 2)                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.

                            '    db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                            'End If

                        End If

                    Next

                    '***** UPDATE THE MARK POSITION *****     
                    If gapcntr > 0 Then
                        Dim om = db.getopenmark(symbol, harvestkey)                                                                                                         ' PULL THE OPEN MARK RECORD.
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

        Function CheckClosePrice(ByVal symbol As String, ByVal closeprice As Double, ByVal marketdate As Date, ByVal openMark As Double, ByVal dir As String, ByVal width As Double, ByVal harvestkey As String, ByVal rowid As Integer) As String

            Dim datastring As String = ""                                                                                                                               ' HOLDS THE RESULT OF EXECUTED CODE PASSED BETWEEN FUNCTIONS AND PRESENTED IN THE VIEW.
            Dim gap As Double = 0                                                                                                                                       ' HOLDS THE DIFFERENCE BETWEEN THE PRICE AND THE MARK.
            'Dim width As Double = 0.25
            Dim gapcntr As Integer = 0
            Dim closestatus As String = "S"
            Dim putprice As Double = 0
            Dim opened As Integer = 0
            Dim closed As Integer = 0

            Using db As New wavesDataContext

                If dir = "U" Then

                    If closeprice - openMark < (-width + 0.01) Then
                        gap = Math.Round((closeprice - 0.01 + (width / 2)) * 4, MidpointRounding.AwayFromZero) / 4                                                      ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                        gapcntr = (gap - openMark) / width * -1                                                                                                         ' DETERMINE THE NUMBER OF WIDTH LEVES THAT THE PRICE HAS GAPPED UP                        
                        closestatus = "B"

                        For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   
                            Dim pricetest As Double = openMark - (width * i)                                                                                            ' SET THE OPENPRICE TO EACH LEVEL BELOW THE MARK. ACCOUNTS FOR OPEN TO BUY GTC ORDERS IN THE PLATFORM.
                            '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                            If db.posExists(harvestkey, gap - (width * i), True) = False Then                                                                       ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP

                                Dim newHarvestPosition As New HarvestPosition                                                                                           ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                TryUpdateModel(newHarvestPosition)                                                                                                      ' TEST CONNECTION TO DATABASE TABLES.
                                Dim newpos As New HarvestPosition With { _
                                                                .open = True, _
                                                                .symbol = symbol.ToUpper, _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .openflag = "C", _
                                                                .harvestkey = harvestkey, _
                                                                .openprice = pricetest _
                                                            }                                                                                                           ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE.

                                db.HarvestPositions.InsertOnSubmit(newpos)

                                opened = opened + 1

                                'Dim ul = db.getlog(harvestkey, marketdate)
                                'ul.opens = ul.opens + 1
                                'ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                                'ul.closingmark = gap


                                'If db.posExists(harvestkey, pricetest + 2 + width, True) = True Then                                                                                  ' CHECK IF THERE IS A POSITION TO CLOSE BASED ON THE DROP IN PRODUCT PRICE.

                                'If db.hedgeexists(harvestkey, pricetest + 2 + width, True) = True Then                                                                            ' CHECK TO SEE IF THERE IS A HEDGE TO MATCH THE GAP PLUS SPREAD.

                                'Dim su = db.positionexists(harvestkey, gap + 2 + width, True)                                                                           ' GET THE POSITION TO UPDATE THE RECORD.
                                'su.closeprice = gap
                                'su.closeflag = "Z"                                                                                                                      ' SET CLOSEFLAG TO Z INDICATING THAT THIS POSITION WAS CLOSED VIA THE HEDGE CLOSE.
                                'su.open = 0
                                'su.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                'su.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                'ul.closes = ul.closes + 1

                                'Dim hu = db.gethedge(harvestkey, pricetest + 2 + width, True)

                                'putprice = getPutPrice(gap, hu.strike, marketdate, hu.exp)

                                'hu.open = False
                                'hu.closeprice = putprice
                                'hu.stockatclose = pricetest
                                'hu.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                                'hu.timestamp = DateTime.Parse(Now).ToUniversalTime()
                                'hu.positionID = su.id
                                'hu.marketdate = marketdate

                                'ul.hedgeprofit = ul.hedgeprofit + ((hu.stockatclose - hu.stockatopen) * 100) + ((putprice - hu.openprice) * hu.lots * 100)
                                'su.hedgeid = hu.id

                                'Stop

                                'End If

                                'End If

                                db.SubmitChanges()

                            End If

                            'Dim ul = db.getlog(harvestkey, marketdate)
                            'ul.opens = ul.opens + 1
                            'ul.trans = rowid
                            'ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                            'ul.closingmark = gap
                            'db.SubmitChanges()


                        Next

                        '***** UPDATE THE MARK POSITION *****     
                        If gapcntr > 0 Then
                            Dim om = db.getopenmark(symbol, harvestkey)                                                                                                     ' PULL THE OPEN MARK RECORD.
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

                    If closeprice - openMark > (width - 0.01) Then
                        gap = Math.Round((closeprice + 0.01 - (width / 2)) * 4, MidpointRounding.ToEven) / 4                                                            ' CALCULATE THE WIDTH OF THE GAP UP. ADJUST 0.12 TO ACCOUNT FOR ROUND UP FUNCTIONALITY.
                        gapcntr = (gap - openMark) / width
                        closestatus = "S"

                        '***** PROCESS HARVEST POSITIONS HERE *****
                        For i = gapcntr To 1 Step -1                                                                                                                    ' LOOP THROUGH THE NUMBER OF POSSIBLE POSITIONS THE GAP CREATED.   

                            '***** DETERMINE IF THERE IS A POSITION TO CLOSE *****
                            If db.posExists(harvestkey, gap - (width * i), True) = True Then                                                                        ' CHECK IF THERE IS A POSITION TO CLOSE FOR EACH LEVEL IN THE GAP UP
                                Dim su = db.getposition(harvestkey, gap - (width * i), True)                                                                     ' GET THE POSITION TO UPDATE THE RECORD.
                                su.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                             ' SET THE CLOSE DATE FOR THIS RECORD                                        
                                su.closeprice = su.openprice + width                                                                                                    ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                                su.open = False                                                                                                                         ' SET THE OPEN FLAG TO FALSE
                                ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.
                                su.closeflag = "C"
                                su.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                      ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                                'db.SubmitChanges()                                                                                                                      ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                                'Dim ul = db.getlog(harvestkey, marketdate)
                                'ul.closes = ul.closes + 1
                                'ul.stockprofit = ul.stockprofit + ((su.closeprice - su.openprice) * 100)
                                'ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                                'ul.closingmark = gap


                                db.SubmitChanges()
                                closed = closed + 1
                                ' NOTE: THE CURRENT HEDGE PROCESS ACCOUNTS FOR LONG POSITIONS ONLY - NO SHORT(S) WITH CALL HEDGES ARE IN PLACE AT THIS TIME.
                                'If db.hedgeexists(harvestkey, gap, True) = False Then                                                                               ' DETERMINE WHETHER A HEDGE FOR THE CURRENT PRICE EXISTS. IF NOT ADD IT IF IT DOES THEN IGNORE AND LOOP.

                                '    Dim expyear As Integer = marketdate.Year
                                '    Dim expmonth As Integer = marketdate.Month                                                                                              ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.
                                '    expmonth = expmonth + 2                                                                                                                 ' ADD 2 MONTHS TO THE HEDGE EXPIRATION                              ****  NEED TO MAKE THIS DYNAMIC FOR USER TO SET  ****
                                '    Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                    ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****

                                '    For d = 0 To 6                                                                                                                          ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
                                '        If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                            ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                                '            exp = exp.AddDays(14)                                                                                                           ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                                '            Exit For
                                '        End If
                                '        exp = exp.AddDays(d)
                                '    Next

                                '    putprice = getPutPrice(gap, Int(gap - width - 2), marketdate, exp)

                                '    Dim newHarvestHEDGE As New HarvestHedge                                                                                                 ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                                '    TryUpdateModel(newHarvestHEDGE)                                                                                                         ' TEST CONNECTION TO DATABASE TABLES.
                                '    Dim newhedge As New HarvestHedge With { _
                                '                                    .symbol = symbol.ToUpper, _
                                '                                    .type = "P", _
                                '                                    .lots = 4, _
                                '                                    .strike = Int(gap - width - 2), _
                                '                                    .stockatopen = gap, _
                                '                                    .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                '                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                '                                    .open = True, _
                                '                                    .exp = exp, _
                                '                                    .openprice = putprice, _
                                '                                    .harvestkey = harvestkey _
                                '                                }                                                                                                           ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.

                                '    db.HarvestHedges.InsertOnSubmit(newhedge)

                                '    su.hedge = True                                                                                                                         ' SET THE DISPOSITION TO HEDGE IF TRIGGERED.
                                '    su.strike = Int(gap - width - 2)                                                                                                        ' SET THE STRIKE PRICE RECOMMENDATION IF NEEDED.

                                '    db.SubmitChanges()                                                                                                                          ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                                'End If

                            End If






                        Next

                        '***** UPDATE THE MARK POSITION *****     
                        If gapcntr > 0 Then
                            Dim om = db.getopenmark(symbol, harvestkey)                                                                                                     ' PULL THE OPEN MARK RECORD.
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

                Dim ul = db.getlog(harvestkey, marketdate)
                ul.opens = ul.opens + opened
                ul.closes = ul.closes + closed
                ul.trans = rowid
                ul.timestamp = DateTime.Parse(Now).ToUniversalTime
                ul.closingmark = gap
                db.SubmitChanges()

            End Using

            Return datastring
        End Function

        Function openHedge(ByVal harvestkey As String, marketdate As Date, pricetest As Double) As String                                                               ' CALLED FUNCTION TO HANDLE THE OPEN HEDGE PROCESS.

            Using db As New wavesDataContext
                Dim exp As Date = expdate(harvestkey, marketdate)
                Dim hi = db.GetHarvestIndex(harvestkey, True)                                                                                                           ' PULLS RELEVANT DATA BASED ON THE EXPERIMENT SELECTED.

                If db.hedgeexists(harvestkey, pricetest, True) = True Then                                                                                              ' DETERMINE IF A HEDGE POSITION FOR THIS PRICE LEVEL ALREADY EXISTS IF IT DOES THEN RETURN TO THE CALLING FUNCTION. 

                Else
                    Dim putprice As Double = getPutPrice(pricetest, Int(pricetest - hi.hedgewidth), marketdate, exp)



                End If

            End Using

            Dim datastring As String = ""
            Return datastring
        End Function

        Function EODHedgeSweep() As String
            Dim datastring As String = ""
            Return datastring
        End Function

        ' **********  CALLED FUNCTIONS ***********

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

        Function getdatetime(ByVal marketdate As String, ByVal markettime As String) As String
            Dim dateandtime As String = ""
            If markettime.Length < 4 Then
                dateandtime = DateTime.Parse(marketdate & " " & Left(markettime, 1) & ":" & Right(markettime, 2))
            Else
                dateandtime = DateTime.Parse(marketdate & " " & Left(markettime, 2) & ":" & Right(markettime, 2))
            End If
            Return dateandtime
        End Function

        Function expdate(ByVal harvestkey As String, ByVal marketdate As Date) As Date                                                                                                      ' CALLED FUNCTION TO CALCULATE THE EXPIRATION DATE FOR THE HEDGE OPTIONS.

            Dim expDateWidth As Integer = 0                                                                                                                                                 ' VARIABLE CONTAINING THE WIDTH IN MONTHS FOR THE OPTION CONTRACT FOR THE HEDGE RETRIEVED FROM THE HEDGEINDEX TABLE.  

            Using db As New wavesDataContext
                Dim hi = db.GetHarvestIndex(harvestkey, True)


                Dim expyear As Integer = marketdate.Year
                Dim expmonth As Integer = marketdate.Month                                                                                                                                  ' SET THE MONTH FOR THE EXPIRATION OF THE HEDGE.

                expmonth = expmonth + hi.hedgewidth                                                                                                                                         ' ADD 2 MONTHS TO THE HEDGE EXPIRATION                              ****  NEED TO MAKE THIS DYNAMIC FOR USER TO SET  ****


                If expmonth = 13 Then
                    expmonth = 1
                    expyear = expyear + 1
                ElseIf expmonth = 14 Then
                    expmonth = 2
                    expyear = expyear + 1
                End If

                Dim exp As Date = New DateTime(expyear, expmonth, 1)                                                                                                                        ' SET THE FIRST DATE TO CHECK AS THE 1ST OF THE MONTH.              ****  THIS ONLY ALLOWS MONTHLY EXPIRATIONS AT THIS POINT NEED TO ADD WEEKLYS  ****

                For d = 0 To 6                                                                                                                                                              ' LOOP THROUGH 7 DAYS TO FIND FRIDAY.
                    If exp.DayOfWeek = DayOfWeek.Friday Then                                                                                                                                ' CHECK TO SEE IF THE DAY OF THE WEEK FOR EXP IS FRIDAY.
                        exp = exp.AddDays(14)                                                                                                                                               ' ADD 2 WEEKS TO THE FRIDAY TO GET THE THIRD FRIDAY OF THE MONTH FOR EXPIRATION.
                        Exit For
                    End If
                    exp = exp.AddDays(d)
                Next
                expdate = exp
            End Using

            Return expdate
        End Function

        Function test() As ActionResult                                                                                                                                                     ' FUNCTION TO USED TO BUILD OUT THE BACK TEST CAPABILITIES.  WILL TRANSPORT THIS TO A SUITABLE BACKTEST FUNCTION ONCE PROVEN.
            Using db As New wavesDataContext                                                                                                                                                ' INSTANCIATES CONNECTION TO THE DATA CONTEXT TO ACCESS THE DATA TABLES

                Dim indexlist = (From m In db.HarvestIndexes Select m).ToList()                                                                                                             ' PULLS OFF OF THE INDEXES TO POPULATE THE DROPDOWN LIST IN THE VIEW
                Dim loglist = (From m In db.HarvestLogs Where m.harvestkey = "H1QESGH2BPCX" And m.marketdate >= "09/01/2017" Order By m.harvestkey, m.marketdate Select m).ToList()                                          ' NEED TO MAKE THIS PULL THE DROPDOWN HARVESTKEY - ANY CHANGE NEEDS TO AJAX A REPULL OF THE DATA.

                'Dim loglist = (From m In db.HarvestLogs Group By m.harvestkey Into logGroup = Group, totalbought = Sum(m.sharesbought)).ToList()

                'SELECT YEAR([marketdate]) as Y, Month([marketdate]) as M, SUM([stockprofit] + [hedgeprofit]) as p
                'from dbo.HarvestLogs
                'Group by YEAR([marketdate]), MONTH([marketdate])

                ' Stop

                'For Each drp In q
                '    MsgBox(drp.YearMonth.year & " : " & drp.YearMonth.month & " : " & drp.DateGroup.Count)
                'Next

                Dim model As New wavesViewModel()                                                                                                                                           ' INSTANCIATES A NEW MODEL TO PASS DATA FROM CONTROLLER TO VIEW
                model.AllIndexes = indexlist                                                                                                                                                ' ADDS THE INDEX DATA TO THE MODEL
                model.AllLogs = loglist                                                                                                                                                     ' ADDS THE LOG DATA TO THE MODEL
                'model.Allhedges = hedgelist

                ViewData("msg") = "Select back test and enter file date to run back test."                                                                                                  ' VIEWDATA MESSAGE TO SUPPLY USER INFORMATION BACK TO THE VIEW

                Return View(model)                                                                                                                                                          ' INITIATES ROUTING TO THE VIEW PASSING THE MODEL WITH ALL THE ADDED DATA

            End Using                                                                                                                                                                       ' CLOSES THE DATA CONTEXT WITH THE ASSOCIATED DATA TABLES
        End Function

        <HttpPost()> _
        Function testme(ByVal fieldone As String, ByVal fieldtwo As String, ByVal robotindex As String) As ActionResult                                                                     ' FUNCTION USED TO PROCESS THE SELECTED BACKTEST THIS PROCESS WILL RUN ONE LOOP THROUGH 390 RECORDS OF A TYPICAL TRADING DAY

            'MsgBox(fieldone & " " & fieldtwo)
            Dim harvestkey As String = robotindex
            Dim csvdata As String = ""                                                                                                                                                      ' USED TO HOUSE THE TEXT FILE             
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                            ' BASE PATH OF THE FILE TO BE READ INTO MEMORY
            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            Dim loopcounter As Integer = 0                                                                                                                                                  ' COUNTER FOR THE ROWS TO BE PROCESSED
            Dim mark As Double = 0                                                                                                                                                          ' SET THE POINTER FOR WHERE THE PRICE IS IN RELATION TO THE TRIGGERS
            Dim marketdate As String = ""                                                                                                                                                   ' SET MARKETDATE TO STRING TO FORMAT AND USE TO PULL RECORDS FROM TABLE
            Dim direction As String = ""                                                                                                                                                    ' SET THE DIRECTION OF THE PRICE MOVEMENT IN THE INTERVAL
            Dim rowid As Integer = 0                                                                                                                                                        ' INITIALIZE ROW COUNTER FOR LOOPING FUNCTION

            path = path & fieldone & "\table_" & fieldtwo & ".csv"                                                                                                                          ' SET THE PATH AND FILENAME FOR THE CSV FILE TO BE READ INTO MEMORY

            If My.Computer.FileSystem.FileExists(path) Then                                                                                                                                 ' CHECKS TO SEE WHETHER THE FILE FOR THIS DATE EXISTS BEFORE ATTEMPTING TO PROCESS IT
                Using textReader As New System.IO.StreamReader(path)                                                                                                                        ' TEXT READER PULLS AND READS THE FILE
                    csvdata = textReader.ReadToEnd                                                                                                                                          ' LOAD THE ENTIRE FILE INTO THE STRING
                End Using                                                                                                                                                                   ' CLOSE THE TEXT READER
            Else
                MsgBox("File Does not Exist. Please review and correct.")                                                                                                                   ' MESSAGE TO THE USER THAT THIS DATE DOES NOT EXIST  < SHOULD BUILD OUT A TABLE WITH ALL TRADING DATES IN 2016 & 2017 AND READ AND LOOP THORUGH THEM >            
                Return RedirectToAction("backtest", "member")                                                                                                                               ' BECAUSE OF THE ERROR RETURN BACK TO THE BACKTEST PAGE FOR USER TO CORRECT THE ERROR
            End If

            Dim backprices As List(Of backPrice) = ParseBackData(csvdata)                                                                                                                   ' LOADS THE PRICES INTO THE BACKPRICES DATA MODEL



            For Each Price As backPrice In backprices

                'If rowid = 0 Then                                                                                                                                                          ' THIS IS RUN AT THE FIRST INTERVAL TO DETERMINE IF THERE IS A MARK THAT EXISTS FOR THIS HARVEST KEY IT IS ONLY RUN ONCE BASED ON ROW EQUALING ZERO
                mark = processMark(harvestkey, Price.MarketDate, Price.OpenPrice)                                                                                                           ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                'End If

                direction = checkdirection(Price.OpenPrice, Price.HighPrice, Price.LowPrice, Price.ClosePrice)                                                                              ' CALL FUNCTION TO CHECK INTERVAL DIRECTION AND RETURN AN INDICATOR
                datastring = processLog(harvestkey, Price.MarketDate, rowid, mark)                                                                                                          ' DETERMINE IF A LOG FOR THIS HARVEST KEY AND MARKET DATE EXISTS. IF NOT CREATE IT AND ADD IT TO THE DATABASE TABLES

                If direction = "U" Then

                    ' CHECK THE OPEN PRICE - WHETHER THIS PRICE IS LESS THAN MARK MINUS WIDTH OR GREATER THAN MARK PLUS WIDTH
                    datastring = priceAbove(harvestkey, Price.MarketDate, Price.OpenPrice, rowid)
                    datastring = priceBelow(harvestkey, Price.MarketDate, Price.OpenPrice, rowid)
                    ' CHECK THE LOW PRICE - WHETHER THIS PRICE IS LESS THAN MARK MINUS WIDTH 
                    datastring = priceBelow(harvestkey, Price.MarketDate, Price.LowPrice, rowid)
                    ' CHECK THE HIGH PRICE - WHETHER THIS PRICE IS GREATER THAN THE MARK PLUS WIDTH
                    datastring = priceAbove(harvestkey, Price.MarketDate, Price.HighPrice, rowid)
                    ' CHECK THE CLOSING PRICE - WHETHER THIS PRICE IS LESS THAN MARK MINUS WIDTH OR GREATER THAN MARK PLUS WIDTH
                    datastring = priceBelow(harvestkey, Price.MarketDate, Price.ClosePrice, rowid)
                    datastring = priceAbove(harvestkey, Price.MarketDate, Price.ClosePrice, rowid)
                Else
                    ' CHECK THE OPEN PRICE - WHETHER THIS PRICE IS LESS THAN MARK MINUS WIDTH OR GREATER THAN MARK PLUS WIDTH
                    datastring = priceAbove(harvestkey, Price.MarketDate, Price.OpenPrice, rowid)
                    datastring = priceBelow(harvestkey, Price.MarketDate, Price.OpenPrice, rowid)
                    ' CHECK THE HIGH PRICE - WHETHER THIS PRICE IS GREATER THAN THE MARK PLUS WIDTH
                    datastring = priceAbove(harvestkey, Price.MarketDate, Price.HighPrice, rowid)
                    ' CHECK THE LOW PRICE - WHETHER THIS PRICE IS LESS THAN MARK MINUS WIDTH 
                    datastring = priceBelow(harvestkey, Price.MarketDate, Price.LowPrice, rowid)
                    ' CHECK THE CLOSING PRICE - WHETHER THIS PRICE IS LESS THAN MARK MINUS WIDTH OR GREATER THAN MARK PLUS WIDTH
                    datastring = priceBelow(harvestkey, Price.MarketDate, Price.ClosePrice, rowid)
                    datastring = priceAbove(harvestkey, Price.MarketDate, Price.ClosePrice, rowid)
                End If

                rowid = rowid + 1                                                                                                                                                           ' INCREMENT THE ROW COUNTER MOVING DOWN THROUGHT THE FILE
            Next Price                                                                                                                                                                      ' LOOP TO THE NEXT PRICE IN THE FILE AND PROCESS THAT RECORD

            MsgBox("Complete")

            Return View()
        End Function

        Function processMark(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double) As Double                                                                         ' IF MARK EXISTS RETURN IT TO THE CALLING FUNCTION IF IT DOES NOT EXIST CALCULATE IT BASED ON THE PARAMETERS AND RETURN IT TO THE CALLING FUNCTION.  DOES NOT UPDATE THE MARK!

            Dim openmark As Double                                                                                                                                                          ' VARIABLE USED TO SUPPLY THE CURRENT MARK IN THE DATABASE TO THE FUNCTION TO CHECK THE PRICE AGAINST

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 
                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                Dim CheckMark = db.CheckMark(harvestkey)                                                                                                                                    ' FUNCTION THAT DETERMINES WHETHER A MARK EXISTS FOR THIS HARVEST KEY 
                Dim buytarget As Double = h.opentrigger                                                                                                                                     ' EXTRACT THE BUYING TRIGGER FROM THE HARVEST INDEX RECORD FOR THIS HARVEST KEY
                If CheckMark = True Then                                                                                                                                                    ' IF THE MARK EXISTS THEN RETURN IT FOR PROCESSING
                    Dim om = db.pullmark(harvestkey)                                                                                                                                        ' PULL THE HARVEST MARK RECORD BASED ON THE HARVEST KEY
                    openmark = om.mark                                                                                                                                                      ' ASSIGN THE OPENMARK VARIABLE THE OPEN MARK VALUE FROM THE TABLE
                Else                                                                                                                                                                        ' MARK DOES NOT EXIST - ADD NEW MARK RECORD AND SET THE VALUES 

                    Dim cents As Double = price - Int(price)                                                                                                                                ' CALCULATE THE CENTS PORTION OF THE PRICE
                    Dim dividecents As Double = Math.Truncate(cents / buytarget)                                                                                                            ' CALCULATE THE FACTOR TO USE WHEN SETTING THE OPENING FIRST MARK

                    openmark = Int(price) + (dividecents * buytarget)

                    Dim newMark As New HarvestMark                                                                                                                                          ' SET THE NEW MARK STRUCTURE TO ADD THE RECORD TO THE TABLE.
                    TryUpdateModel(newMark)
                    Dim new_mrk As New HarvestMark With { _
                                                    .timestamp = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                    .symbol = h.product.ToUpper(), _
                                                    .mark = openmark, _
                                                    .turns = 1, _
                                                    .harvestkey = harvestkey, _
                                                    .open = True _
                                                    }                                                                                                                                       ' SET THE PARAMETERS OF THE NEW RECORD TO BE ADDED.

                    db.HarvestMarks.InsertOnSubmit(new_mrk)                                                                                                                                 ' INSERT THE NEW RECORD WHEN SUBMIT CHANGES IS EXECUTED.
                    db.SubmitChanges()                                                                                                                                                      ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.

                End If

            End Using

            Return openmark
        End Function

        ' TEST CODE HERE

        Function priceBelow(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double, ByVal rowid As Integer) As String                                                                          ' FUNCTION TO DETERMINE IF THE PRICE IS LESS THAN MARK MINUS THE WIDTH PARAMETER AND PROCESS RECORDS IN THE DATABASE TIED TO THAT OUTCOME

            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            Dim mark As Double = 0                                                                                                                                                          ' SET THE POINTER FOR WHERE THE PRICE IS IN RELATION TO THE TRIGGERS
            'price = 86
            Dim loops As Integer = 0                                                                                                                                                        ' LOOP COUNTER USED TO LOOP THROUGH THE NUMBER OF INTERVALS THAT A PRICE MAY BE BELOW THE MARK
            Dim resultingPrice As Double = 0                                                                                                                                                ' USED TO CALCULATE THE RESULTING PRICE WHEN THE WIDTH BY INTERVAL IS APPLIED TO THE MARK BASED ON THE ACTUAL PRICE MOVEMENT

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 

                Dim ul = db.getlog(harvestkey, marketdate)                                                                                                                                  ' PULL LOG RECORD TO BE UPDATED AS PRICE IS PROCESSED IN THIS FUNCTION
                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                Dim m = db.pullmark(harvestkey)                                                                                                                                             ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                mark = m.mark                                                                                                                                                               ' SET THE MARK POINTER

                If price - mark < ((-1 * h.width) + 0.01) Then                                                                                                                              ' PRICE BELOW CHECKS THE PRICE LESS THE MARK AGAINST THE WIDTH IF IT IS EQUAL TO OR LESS THAN THAT VALUE THEN TRIGGER ACTION
                    loops = (mark - price) / h.width                                                                                                                                        ' CALCULATES THE NUMBER OF TIMES TO LOOP THROUGH THE PROCESS BASED ON THE NUMBER OF INTERVALS THE PRICE IS BELOW THE MARK
                    For i = 1 To loops                                                                                                                                                      ' LOOP FUNCTION FOR PRICE BELOW 

                        If price < mark - h.width * i Then

                            resultingPrice = mark - h.width * i                                                                                                                                 ' RESULTING PRICE WHEN THE WIDTH MULTIPLIED BY THE LOOP COUNTER IS SUBTRACTED FROM THE MARK THIS GIVES THE CHANGE IN INTERVAL LEVELS BASED ON THE PRICE MOVEMENT

                            If db.posExists(harvestkey, resultingPrice, True) = False Then                                                                                                      ' CHECK IF THERE IS A POSITION TO CLOSE FOR THIS RESULTING PRICE IF NOT THEN ADD THE POSITION

                                Dim newHarvestPosition As New HarvestPosition                                                                                                                   ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE
                                TryUpdateModel(newHarvestPosition)                                                                                                                              ' TEST CONNECTION TO DATABASE TABLES
                                Dim newpos As New HarvestPosition With { _
                                                                .open = True, _
                                                                .symbol = h.product.ToUpper, _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .openflag = "L", _
                                                                .openrowid = rowid, _
                                                                .shares = h.shares, _
                                                                .harvestkey = harvestkey, _
                                                                .openprice = resultingPrice _
                                                            }                                                                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE

                                db.HarvestPositions.InsertOnSubmit(newpos)
                                db.SubmitChanges()                                                                                                                                              ' COMMIT THE NEW POSITION TO THE DATABASE



                                'datastring = "Added position for price: " & (String.Format("{0:C}", resultingPrice))

                                'datastring = processHedge(harvestkey, marketdate, resultingPrice, "o")                                                                                          ' CHECK IF A HEDGE EXISTS FOR THE POSITION ADDED 
                                'datastring = processHedge(harvestkey, marketdate, resultingPrice, "c")                                                                                          ' CHECK IF A HEDGE EXISTS FOR THE POSITION TO BE CLOSED
                                ' ** complete ** IF A POSITION DOES NOT EXIST AT THIS RESULTING PRICE LEVEL ADD A POSITION
                                ' IF A HEDGE DOES NOT EXIST FOR THIS RESULTING PRICE LEVEL ADD A HEDGE POSITION
                                ' INCREMENT THE LOG COUNTERS APPROPRIATELY

                                'MsgBox("Added position for price: " & (String.Format("{0:C}", resultingPrice)))

                            End If
                            'Else
                            'resultingPrice = mark + h.width * i
                        End If
                    Next
                    ' UPDATE THE MARK & LOGS 
                    mark = updateMark(harvestkey, marketdate, resultingPrice)

                End If

            End Using                                                                                                                                                                       ' CLOSES THE DATA CONTEXT TO THE DATA TABLES

            Return datastring
        End Function

        Function priceAbove(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double, ByVal rowid As Integer) As String                                                  ' FUNCTION TO DETERMINE IF THE PRICE IS GREATER THAN THE MARK PLUS THE WIDTH PARAMETER AND PROCESS RECORDS IN THE DATABASE TIED TO THAT OUTCOME

            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            Dim mark As Double = 0                                                                                                                                                          ' SET THE POINTER FOR WHERE THE PRICE IS IN RELATION TO THE TRIGGERS
            'price = 87
            Dim loops As Double = 0                                                                                                                                                        ' LOOP COUNTER USED TO LOOP THROUGH THE NUMBER OF INTERVALS THAT A PRICE MAY BE BELOW THE MARK
            Dim resultingPrice As Double = 0                                                                                                                                                ' USED TO CALCULATE THE RESULTING PRICE WHEN THE WIDTH BY INTERVAL IS APPLIED TO THE MARK BASED ON THE ACTUAL PRICE MOVEMENT

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 

                Dim ul = db.getlog(harvestkey, marketdate)                                                                                                                                  ' PULL LOG RECORD TO BE UPDATED AS PRICE IS PROCESSED IN THIS FUNCTION
                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                Dim m = db.pullmark(harvestkey)                                                                                                                                             ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                mark = m.mark                                                                                                                                                               ' SET THE MARK POINTER

                If price - mark > (h.width - 0.01) Then                                                                                                                                     ' PRICE BELOW CHECKS THE PRICE LESS THE MARK AGAINST THE WIDTH IF IT IS EQUAL TO OR LESS THAN THAT VALUE THEN TRIGGER ACTION
                    loops = (price - mark) / h.width                                                                                                                                      ' CALCULATES THE NUMBER OF TIMES TO LOOP THROUGH THE PROCESS BASED ON THE NUMBER OF INTERVALS THE PRICE IS BELOW THE MARK
                    loops = Math.Floor(loops)

                    For i = 1 To loops                                                                                                                                                     ' LOOP FUNCTION FOR PRICE BELOW 

                        'If price > mark + (h.width * i) Then

                        resultingPrice = mark + (h.width * i)                                                                                                                               ' RESULTING PRICE WHEN THE WIDTH MULTIPLIED BY THE LOOP COUNTER IS SUBTRACTED FROM THE MARK THIS GIVES THE CHANGE IN INTERVAL LEVELS BASED ON THE PRICE MOVEMENT

                        If db.posExists(harvestkey, resultingPrice - h.width, True) = True Then                                                                                                                 ' CHECK IF THERE IS A POSITION TO CLOSE FOR THIS RESULTING PRICE CLOSE THE RESULTING POSITION

                            Dim us = db.getposition(harvestkey, resultingPrice - h.width, True)                                                                                                                 ' GET THE POSITION TO UPDATE THE RECORD.

                            us.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                                     ' SET THE CLOSE DATE FOR THIS RECORD                                        
                            us.closeprice = resultingPrice                                                                                                                                  ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                            us.open = False                                                                                                                                                 ' SET THE OPEN FLAG TO FALSE
                            us.closerowid = rowid                                                                                                                                           ' SET THE ROWID OF THE CLOSED POSITION TO MAP WHICH MINUTE THE POSIITON WAS CLOSED FOR DEBUG PURPOSES
                            us.closeflag = "H"                                                                                                                                              ' INDICATES THAT THE CLOSED METHOD WAS HIGH  ***** NEED TO DETERMINE IF THIS HAS VALUE ANYMORE OR NOT
                            us.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                                              ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                            db.SubmitChanges()



                            'End If
                        End If

                    Next
                    mark = updateMark(harvestkey, marketdate, resultingPrice)

                End If

            End Using
            Return datastring
        End Function

        Function npriceAbove(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double, ByVal rowid As Integer, ByVal width As Double, ByVal mark As Double) As Double    ' FUNCTION TO DETERMINE IF THE PRICE IS GREATER THAN THE MARK PLUS THE WIDTH PARAMETER AND PROCESS RECORDS IN THE DATABASE TIED TO THAT OUTCOME

            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            'Dim mark As Double = 0                                                                                                                                                          ' SET THE POINTER FOR WHERE THE PRICE IS IN RELATION TO THE TRIGGERS
            'price = 87
            Dim loops As Double = 0                                                                                                                                                        ' LOOP COUNTER USED TO LOOP THROUGH THE NUMBER OF INTERVALS THAT A PRICE MAY BE BELOW THE MARK
            Dim resultingPrice As Double = 0                                                                                                                                                ' USED TO CALCULATE THE RESULTING PRICE WHEN THE WIDTH BY INTERVAL IS APPLIED TO THE MARK BASED ON THE ACTUAL PRICE MOVEMENT

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 

                'Dim ul = db.getlog(harvestkey, marketdate)                                                                                                                                  ' PULL LOG RECORD TO BE UPDATED AS PRICE IS PROCESSED IN THIS FUNCTION
                'Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                'Dim m = db.pullmark(harvestkey)                                                                                                                                             ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                'mark = m.mark                                                                                                                                                               ' SET THE MARK POINTER

                Stop

                If price - mark > (width - 0.01) Then                                                                                                                                     ' PRICE BELOW CHECKS THE PRICE LESS THE MARK AGAINST THE WIDTH IF IT IS EQUAL TO OR LESS THAN THAT VALUE THEN TRIGGER ACTION
                    loops = (price - mark) / width                                                                                                                                      ' CALCULATES THE NUMBER OF TIMES TO LOOP THROUGH THE PROCESS BASED ON THE NUMBER OF INTERVALS THE PRICE IS BELOW THE MARK
                    loops = Math.Floor(loops)

                    For i = 1 To loops                                                                                                                                                     ' LOOP FUNCTION FOR PRICE BELOW 

                        'If price > mark + (h.width * i) Then

                        resultingPrice = mark + (width * i)                                                                                                                               ' RESULTING PRICE WHEN THE WIDTH MULTIPLIED BY THE LOOP COUNTER IS SUBTRACTED FROM THE MARK THIS GIVES THE CHANGE IN INTERVAL LEVELS BASED ON THE PRICE MOVEMENT

                        If db.posExists(harvestkey, resultingPrice - width, True) = True Then                                                                                                                 ' CHECK IF THERE IS A POSITION TO CLOSE FOR THIS RESULTING PRICE CLOSE THE RESULTING POSITION

                            Dim us = db.getposition(harvestkey, resultingPrice - width, True)                                                                                                                 ' GET THE POSITION TO UPDATE THE RECORD.

                            us.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                                     ' SET THE CLOSE DATE FOR THIS RECORD                                        
                            us.closeprice = resultingPrice                                                                                                                                  ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                            us.open = False                                                                                                                                                 ' SET THE OPEN FLAG TO FALSE
                            us.closerowid = rowid                                                                                                                                           ' SET THE ROWID OF THE CLOSED POSITION TO MAP WHICH MINUTE THE POSIITON WAS CLOSED FOR DEBUG PURPOSES
                            us.closeflag = "H"                                                                                                                                              ' INDICATES THAT THE CLOSED METHOD WAS HIGH  ***** NEED TO DETERMINE IF THIS HAS VALUE ANYMORE OR NOT
                            us.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                                              ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                            db.SubmitChanges()



                            'End If
                        End If

                    Next
                    mark = resultingPrice

                End If

            End Using
            Return mark
        End Function

        Function NpriceBelow(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double, ByVal rowid As Integer, ByVal width As Double, ByVal mark As Double) As Double    ' FUNCTION TO DETERMINE IF THE PRICE IS LESS THAN MARK MINUS THE WIDTH PARAMETER AND PROCESS RECORDS IN THE DATABASE TIED TO THAT OUTCOME

            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            'Dim mark As Double = 0                                                                                                                                                          ' SET THE POINTER FOR WHERE THE PRICE IS IN RELATION TO THE TRIGGERS
            'price = 86
            Dim loops As Integer = 0                                                                                                                                                        ' LOOP COUNTER USED TO LOOP THROUGH THE NUMBER OF INTERVALS THAT A PRICE MAY BE BELOW THE MARK
            Dim resultingPrice As Double = 0                                                                                                                                                ' USED TO CALCULATE THE RESULTING PRICE WHEN THE WIDTH BY INTERVAL IS APPLIED TO THE MARK BASED ON THE ACTUAL PRICE MOVEMENT

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 

                'Dim ul = db.getlog(harvestkey, marketdate)                                                                                                                                  ' PULL LOG RECORD TO BE UPDATED AS PRICE IS PROCESSED IN THIS FUNCTION
                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                'Dim m = db.pullmark(harvestkey)                                                                                                                                             ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                'mark = m.mark                                                                                                                                                               ' SET THE MARK POINTER

                If price - mark < ((-1 * width) + 0.01) Then                                                                                                                              ' PRICE BELOW CHECKS THE PRICE LESS THE MARK AGAINST THE WIDTH IF IT IS EQUAL TO OR LESS THAN THAT VALUE THEN TRIGGER ACTION
                    loops = (mark - price) / width                                                                                                                                        ' CALCULATES THE NUMBER OF TIMES TO LOOP THROUGH THE PROCESS BASED ON THE NUMBER OF INTERVALS THE PRICE IS BELOW THE MARK
                    For i = 1 To loops                                                                                                                                                      ' LOOP FUNCTION FOR PRICE BELOW 

                        If price < mark - width * i Then

                            resultingPrice = mark - width * i                                                                                                                                 ' RESULTING PRICE WHEN THE WIDTH MULTIPLIED BY THE LOOP COUNTER IS SUBTRACTED FROM THE MARK THIS GIVES THE CHANGE IN INTERVAL LEVELS BASED ON THE PRICE MOVEMENT

                            If db.posExists(harvestkey, resultingPrice, True) = False Then                                                                                                      ' CHECK IF THERE IS A POSITION TO CLOSE FOR THIS RESULTING PRICE IF NOT THEN ADD THE POSITION

                                Dim newHarvestPosition As New HarvestPosition                                                                                                                   ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE
                                TryUpdateModel(newHarvestPosition)                                                                                                                              ' TEST CONNECTION TO DATABASE TABLES
                                Dim newpos As New HarvestPosition With { _
                                                                .open = True, _
                                                                .symbol = h.product.ToUpper, _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .openflag = "L", _
                                                                .openrowid = rowid, _
                                                                .shares = h.shares, _
                                                                .harvestkey = harvestkey, _
                                                                .openprice = resultingPrice _
                                                            }                                                                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE

                                db.HarvestPositions.InsertOnSubmit(newpos)
                                'db.SubmitChanges()                                                                                                                                              ' COMMIT THE NEW POSITION TO THE DATABASE



                                'datastring = "Added position for price: " & (String.Format("{0:C}", resultingPrice))

                                'datastring = processHedge(harvestkey, marketdate, resultingPrice, "o")                                                                                          ' CHECK IF A HEDGE EXISTS FOR THE POSITION ADDED 
                                'datastring = processHedge(harvestkey, marketdate, resultingPrice, "c")                                                                                          ' CHECK IF A HEDGE EXISTS FOR THE POSITION TO BE CLOSED
                                ' ** complete ** IF A POSITION DOES NOT EXIST AT THIS RESULTING PRICE LEVEL ADD A POSITION
                                ' IF A HEDGE DOES NOT EXIST FOR THIS RESULTING PRICE LEVEL ADD A HEDGE POSITION
                                ' INCREMENT THE LOG COUNTERS APPROPRIATELY

                                'MsgBox("Added position for price: " & (String.Format("{0:C}", resultingPrice)))

                            End If
                            'Else
                            'resultingPrice = mark + h.width * i
                        End If
                    Next
                    ' UPDATE THE MARK & LOGS 
                    mark = resultingPrice

                End If

            End Using                                                                                                                                                                       ' CLOSES THE DATA CONTEXT TO THE DATA TABLES

            Return mark
        End Function

        Function updateMark(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double) As Double

            Dim mark As Double = 0                                                                                                                                                          ' VARIABLE USED TO SUPPLY THE CURRENT MARK IN THE DATABASE TO THE FUNCTION TO CHECK THE PRICE AGAINST

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 
                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                Dim CheckMark = db.CheckMark(harvestkey)                                                                                                                                    ' FUNCTION THAT DETERMINES WHETHER A MARK EXISTS FOR THIS HARVEST KEY 

                If CheckMark = True Then                                                                                                                                                    ' IF THE MARK EXISTS THEN RETURN IT FOR PROCESSING
                    Dim om = db.pullmark(harvestkey)                                                                                                                                        ' PULL THE HARVEST MARK RECORD BASED ON THE HARVEST KEY
                    om.ctimestamp = DateTime.Parse(marketdate).ToUniversalTime                                                                                                              ' SET THE EXIT TIME STAMP TO THE MARKET DATE THAT TRIGGERED THE CHANGE IN THE MARK.
                    om.turns = om.turns + 1                                                                                                                                                 ' INCREMENT THE TURNS FLAG TO SEE HOW MANY TIMES THE MARK HAS BEEN TRIGGERED.
                    om.mark = price                                                                                                                                                         ' SET THE MARK TO THE CURRENT PRICE.
                    db.SubmitChanges()                                                                                                                                                      ' SUBMIT THE RECORD TO THE TABLE TO BE ADDED.
                    mark = price
                End If

            End Using

            Return mark
        End Function

        ' ***** NEW CODE *****

        Function viewdetail(ByVal id As Date) As ActionResult

            MsgBox(id)
            Return RedirectToAction("test", "member")
            'Return View()
        End Function

        Function processTest(ByVal fieldone As String, ByVal fieldtwo As String, ByVal robotindex As String) As ActionResult                                                                ' FUNCTION USED TO PROCESS THE SELECTED BACKTEST THIS PROCESS WILL RUN ONE LOOP THROUGH 390 RECORDS OF A TYPICAL TRADING DAY

            ' THIS FUNCTIONS GOAL IS TO ACCURATELY PROCESS THE MARKETDATA IN AS EFFICIENT AND EFFECTIVE MANNER AS POSSIBLE.  WITH A GOAL OF MINIMIZING THE NUMEBR OF READS AND WRITES TO THE DATABASES BY LEVERAGING COUNTERS ETC.

            Dim harvestkey As String = robotindex
            Dim csvdata As String = ""                                                                                                                                                      ' USED TO HOUSE THE TEXT FILE             
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                            ' BASE PATH OF THE FILE TO BE READ INTO MEMORY
            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            Dim loopcounter As Integer = 0                                                                                                                                                  ' COUNTER FOR THE ROWS TO BE PROCESSED
            Dim mark As Double = 0                                                                                                                                                          ' SET THE POINTER FOR WHERE THE PRICE IS IN RELATION TO THE TRIGGERS
            Dim marketdate As String = ""                                                                                                                                                   ' SET MARKETDATE TO STRING TO FORMAT AND USE TO PULL RECORDS FROM TABLE
            Dim direction As String = ""                                                                                                                                                    ' SET THE DIRECTION OF THE PRICE MOVEMENT IN THE INTERVAL
            Dim rowid As Integer = 0                                                                                                                                                        ' INITIALIZE ROW COUNTER FOR LOOPING FUNCTION
            Dim u As Integer = 0
            Dim d As Integer = 0

            'Dim dateloop() As String = {"20160105", "20160106", "20160107", "20160108", "20160111", "20160112", "20160113" _
            '                           , "20160114", "20160115", "20160119", "20160120", "20160121", "20160122", "20160125", "20160126", _
            '                          "20160127", "20160128", "20160129"}                                                                                                                 '"20160104", 

            'For l = 0 To 18
            'marketdate = Mid(dateloop(l), 5, 2) & "/" & Mid(dateloop(l), 7, 2) & "/" & Mid(dateloop(l), 1, 4)                                                                                        ' SETS THE MARKETDATE BASED ON THE FILENAME PASSED FROM THE VIEW
            'MsgBox(marketdate)

            marketdate = Mid(fieldone, 5, 2) & "/" & Mid(fieldone, 7, 2) & "/" & Mid(fieldone, 1, 4)                                                                                        ' SETS THE MARKETDATE BASED ON THE FILENAME PASSED FROM THE VIEW

            Using db As New wavesDataContext                                                                                                                                                ' OPEN AND CONNECT TO THE DATACONTEXT PROVIDING ACCESS TO THE DATABASE TABLES

                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY - ***** CONTROL CARD RECORD *****
                mark = db.CheckMark(harvestkey)                                                                                                                                             ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES

                path = path & fieldone & "\table_" & h.product & ".csv"                                                                                                                     ' SET THE PATH AND FILENAME FOR THE CSV FILE TO BE READ INTO MEMORY

                If My.Computer.FileSystem.FileExists(path) Then                                                                                                                             ' CHECKS TO SEE WHETHER THE FILE FOR THIS DATE EXISTS BEFORE ATTEMPTING TO PROCESS IT
                    Using textReader As New System.IO.StreamReader(path)                                                                                                                    ' TEXT READER PULLS AND READS THE FILE
                        csvdata = textReader.ReadToEnd                                                                                                                                      ' LOAD THE ENTIRE FILE INTO THE STRING
                    End Using                                                                                                                                                               ' CLOSE THE TEXT READER
                Else
                    MsgBox("File Does not Exist. Please review and correct.")                                                                                                               ' MESSAGE TO THE USER THAT THIS DATE DOES NOT EXIST  < SHOULD BUILD OUT A TABLE WITH ALL TRADING DATES IN 2016 & 2017 AND READ AND LOOP THORUGH THEM >            
                    Return RedirectToAction("backtest", "member")                                                                                                                           ' BECAUSE OF THE ERROR RETURN BACK TO THE BACKTEST PAGE FOR USER TO CORRECT THE ERROR
                End If

                Dim backprices As List(Of backPrice) = ParseBackData(csvdata)                                                                                                               ' LOADS THE PRICES INTO THE BACKPRICES DATA MODEL

                For Each Price As backPrice In backprices                                                                                                                                   ' LOOP THROUGH ALL OF THE PRICES 

                    If rowid = 0 Then
                        If db.CheckMark(harvestkey) = False Then                                                                                                                            ' FOR THE FIRST INTERVAL IN THE MARKETDATA CHECK TO SEE IF THERE IS A MARK ESTABLISHED IF NOT GENERATE THE INITIAL MARK 
                            mark = processMark(harvestkey, Price.MarketDate, Price.OpenPrice)                                                                                               ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                            datastring = processLog(harvestkey, Price.MarketDate, rowid, mark)                                                                                              ' DETERMINE IF A LOG FOR THIS HARVEST KEY AND MARKET DATE EXISTS. IF NOT CREATE IT AND ADD IT TO THE DATABASE TABLES
                        Else                                                                                                                                                                ' IF THE MARK EXISTS PULL IT  
                            Dim m As HarvestMark = db.getmark(harvestkey)                                                                                                                   ' RETRIEVE HARVESTMARK RECORD FROM TABLE AS IT EXISTS
                            mark = m.mark                                                                                                                                                   ' SET MARK TO CURRENT MARK PRICE FROM TABLE FROM PREVIOUS DAY
                            datastring = processLog(harvestkey, Price.MarketDate, rowid, mark)                                                                                              ' DETERMINE IF A LOG FOR THIS HARVEST KEY AND MARKET DATE EXISTS. IF NOT CREATE IT AND ADD IT TO THE DATABASE TABLES

                            ' ADD CODE TO CHECK IF THIS MARKET DATE HAS BEEN PROCESSED ALREADY - IF SO EXIT FOR AND CHECK THE NEXT ONE.

                        End If
                    End If

                    direction = checkdirection(Price.OpenPrice, Price.HighPrice, Price.LowPrice, Price.ClosePrice)                                                                          ' CALL FUNCTION TO CHECK INTERVAL DIRECTION AND RETURN AN INDICATOR

                    If direction = "U" Then                                                                                                                                                 ' INITIATE SPECIFIC PROCESSING IF THE INTERVAL DIRECTION IS UP - ALL PROCESSING FOR THIS INTERVAL (MINUTE) IS DONE HERE
                        u = u + 1                                                                                                                                                           ' INCREMENT UP COUNTER TO BE LOGGED
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.OpenPrice, rowid, h.width, mark, "O")                                                                              ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.LowPrice, rowid, h.width, mark, "L")                                                                               ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.HighPrice, rowid, h.width, mark, "H")                                                                              ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.ClosePrice, rowid, h.width, mark, "C")                                                                             ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                    Else                                                                                                                                                                    ' INITIATE SPECIFIC PROCESSING IF THE INTERVAL DIRECTION IS DOWN (ONLY OPTION OTHER THAN UP IS DOWN) - ALL PROCESSING FOR THIS INTERVAL (MINUTE) IS DONE HERE
                        d = d + 1                                                                                                                                                           ' INCREMENT DOWN COUNTER TO BE LOGGED
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.OpenPrice, rowid, h.width, mark, "O")                                                                              ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.HighPrice, rowid, h.width, mark, "H")                                                                              ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.LowPrice, rowid, h.width, mark, "L")                                                                               ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL
                        mark = checkPrice(harvestkey, Price.MarketDate, Price.ClosePrice, rowid, h.width, mark, "C")                                                                             ' CALL FUNCTION TO PROCESS THE OPEN PRICE - RETURN THE PRICE MARK TO PROCESS THE NEXT PRICE IN THE INTERVAL

                    End If

                    ' ********** DETERMINE IF BEST TO WRITE TO LOG AND MARK TABLE AFTER EACH INTERVAL OR WAIT UNTIL COMPLETE WITH THE DAY **********
                    rowid = rowid + 1                                                                                                                                                       ' INCREMENT THE ROW COUNTER MOVING DOWN THROUGHT THE FILE
                Next

                datastring = processLog(harvestkey, marketdate, rowid, mark)                                                                                                                ' DETERMINE IF A LOG FOR THIS HARVEST KEY AND MARKET DATE EXISTS. IF NOT CREATE IT AND ADD IT TO THE DATABASE TABLES

            End Using                                                                                                                                                                       ' CLOSE THE DATA CONTEXT CONNECTION

            path = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                                          ' RESET THE PATH FOR THE NEXT DAYS RECORDS IN THE MONTHLY PULL

            'Next
            MsgBox("Processing complete for " & marketdate & " " & rowid & " rows processed.")

            Return RedirectToAction("test", "member")
        End Function

        Function processLog(ByVal harvestkey As String, ByVal marketdate As Date, ByVal rowid As Integer, ByVal mark As Double) As String                                                   ' THE LOG IS A TABLE CONRAINING RECORDS CAPTURING EVENTS PERTAINING TO THE TEST & DATE THESE LOG RECORDS ARE A SUMMARY OF THE TRADING ACTIVITY

            Dim datastring As String = ""                                                                                                                                                   ' INITIALIZE THE DATASTRING USED TO PASS DATA BETWEEN FUNCTIONS
            Dim logExists As Boolean                                                                                                                                                        ' INITIALIZE THE TRUE/FALSE FIELD INDICATING A LOG FOR THIS TEST & DATE EXISTS

            Using db As New wavesDataContext                                                                                                                                                ' ATTACH TO THE DATACONTEXT & DATABASE

                logExists = db.logExists(harvestkey, marketdate)                                                                                                                            ' CALLED FUNCTION TO QUERY DATABASE FOR A LOG RECORD FOR THIS TEST & DATE

                If logExists = False Then                                                                                                                                                   ' IF THE LOG DOES NOT EXISTS CREATE A NEW LOG FOR THIS TEST & DATE

                    Dim newHarvestLog As New HarvestLog                                                                                                                                     ' INITIALIZE THE HARVESTLOG TABLE FOR WRITING DATA TO THE DATABASE
                    TryUpdateModel(newHarvestLog)                                                                                                                                           ' TEST CONNECTION TO DATABASE TABLES
                    Dim newlog As New HarvestLog With { _
                                                    .opens = 0, _
                                                    .closes = 0, _
                                                    .harvestkey = harvestkey.ToUpper, _
                                                    .marketdate = Date.Parse(marketdate).ToUniversalTime().ToShortDateString, _
                                                    .stockprofit = 0, _
                                                    .hedgeprofit = 0, _
                                                    .currentcapital = 0, _
                                                    .maxcapital = 0, _
                                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                    .hedgebought = 0, _
                                                    .hedgesold = 0, _
                                                    .sharesbought = 0, _
                                                    .sharessold = 0, _
                                                    .openingmark = mark, _
                                                    .closingmark = mark, _
                                                    .otimestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                    .trans = rowid _
                                                    }                                                                                                                                       ' OPEN THE NEW RECORD (HARVESTKEY & DATE RECORD) IN THE TABLE.

                    db.HarvestLogs.InsertOnSubmit(newlog)                                                                                                                                   ' INSERT THE NEW RECORD TO BE ADDED.
                    db.SubmitChanges()                                                                                                                                                      ' COMMIT THE NEW ROCORD TO THE DATABASE TABLE

                    datastring = "Added new log."                                                                                                                                           ' ADD A MESSAGE TO THE DATASTRING INDICATING PROGRESS.  ***** MAY NOT NEED THIS IN FINAL PRODUCT.

                Else                                                                                                                                                                        ' IF THE LOG EXISTS UPDATE THE LOG RECORD FOR THIS TEST & DATE

                    Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                            ' GET INDEX DATA BASED ON HARVEST KEY

                    Dim lu = db.getlog(harvestkey, marketdate)                                                                                                                              ' PULL THE LOG RECORD FOR THE HARVESTKEY AND MARKEETDATE TO BE UPDATED AS PROCESSING HAS COMPLETED FOR THE CURRENT MARKETDATE
                    lu.trans = rowid
                    lu.closingmark = mark
                    lu.timestamp = DateTime.Parse(Now).ToUniversalTime()
                    lu.closes = stockclosecntr
                    lu.opens = stockopencntr
                    lu.sharesbought = stockopencntr * h.shares
                    lu.sharessold = stockclosecntr * h.shares
                    lu.stockprofit = stockprofit
                    If currentcapital < 0 Then
                        lu.currentcapital = 0
                    Else
                        lu.currentcapital = currentcapital
                    End If

                    lu.hedgeprofit = hedgeprofit
                    lu.maxcapital = maxcapital
                    lu.hedgesold = hedgeclosecntr
                    lu.hedgebought = hedgeopencntr

                    Dim dm = db.getmark(harvestkey)                                                                                                                                         ' GET THE MARK TO UPDATE FOR THE NEXT MARKETDATES PROCESSING
                    dm.mark = mark                                                                                                                                                          ' UPDATE THE MARK TO THE CURRENT MARK VALUE

                    db.SubmitChanges()                                                                                                                                                      ' SUBMIT THE CHANGES TO THE TABLES IN THE DATABASE

                    datastring = "Updated existing log and mark."
                End If

            End Using

            Return datastring
        End Function

        Function checkPrice(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double, ByVal rowid As Integer, ByVal width As Double, ByVal mark As Double, ptype As String) As Double         ' FUNCTION TO DETERMINE IF THE PRICE IS LESS THAN MARK MINUS THE WIDTH PARAMETER AND PROCESS RECORDS IN THE DATABASE TIED TO THAT OUTCOME

            Dim loops As Double = 0                                                                                                                                                             ' LOOP COUNTER USED TO LOOP THROUGH THE NUMBER OF INTERVALS THAT A PRICE MAY BE BELOW THE MARK
            Dim resultingPrice As Double = 0                                                                                                                                                    ' USED TO CALCULATE THE RESULTING PRICE WHEN THE WIDTH BY INTERVAL IS APPLIED TO THE MARK BASED ON THE ACTUAL PRICE MOVEMENT
            Dim datastring As String = ""

            Using db As New wavesDataContext                                                                                                                                                    ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 

                'Dim ul = db.getlog(harvestkey, marketdate)                                                                                                                                     ' PULL LOG RECORD TO BE UPDATED AS PRICE IS PROCESSED IN THIS FUNCTION
                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                    ' GET INDEX DATA BASED ON HARVEST KEY
                'Dim m = db.pullmark(harvestkey)                                                                                                                                                ' DETERMINE IF A MARK FOR THIS HARVESTKEY EXISTS, IF NOT CALCULATE AND ADD IT TO THE DATABASE TABLES
                'mark = m.mark                                                                                                                                                                  ' SET THE MARK POINTER

                If price > mark Then                                                                                                                                                            ' DETERMINE IF THE PRICE IS GREATER THAN THE CURRENT MARK IF SO CHECK TO SEE IF IT EXCEEDS THE WIDTH


                    If price - mark > (width - 0.01) Then                                                                                                                                       ' PRICE BELOW CHECKS THE PRICE LESS THE MARK AGAINST THE WIDTH IF IT IS EQUAL TO OR LESS THAN THAT VALUE THEN TRIGGER ACTION
                        loops = (price - mark) / width                                                                                                                                          ' CALCULATES THE NUMBER OF TIMES TO LOOP THROUGH THE PROCESS BASED ON THE NUMBER OF INTERVALS THE PRICE IS BELOW THE MARK
                        loops = Math.Floor(loops)                                                                                                                                               ' ROUND LOOPS TO INTEGER TO AVOID EXTRA LOOPS THROUGH THE PROCESS

                        For i = 1 To loops                                                                                                                                                      ' LOOP FUNCTION FOR PRICE BELOW 

                            resultingPrice = mark + (width * i)                                                                                                                                 ' RESULTING PRICE WHEN THE WIDTH MULTIPLIED BY THE LOOP COUNTER IS SUBTRACTED FROM THE MARK THIS GIVES THE CHANGE IN INTERVAL LEVELS BASED ON THE PRICE MOVEMENT

                            If db.posExists(harvestkey, resultingPrice - width, True) = True Then                                                                                               ' CHECK IF THERE IS A POSITION TO CLOSE FOR THIS RESULTING PRICE CLOSE THE RESULTING POSITION

                                Dim us = db.getposition(harvestkey, resultingPrice - width, True)                                                                                               ' GET THE POSITION TO UPDATE THE RECORD.

                                us.closedate = DateTime.Parse(marketdate).ToUniversalTime()                                                                                                     ' SET THE CLOSE DATE FOR THIS RECORD                                        
                                If rowid = 0 Then
                                    us.closeprice = price                                                                                                                                       ' IF THE ROW IS 0 AND WE GAP UP SET THE CLOSINGPRICE EQUAL TO THE PRICE
                                Else
                                    us.closeprice = resultingPrice                                                                                                                              ' SET THE CLOSE PRICE WHICH WILL BE THE GAP PRICE.
                                End If

                                us.open = False                                                                                                                                                 ' SET THE OPEN FLAG TO FALSE
                                us.closerowid = rowid                                                                                                                                           ' SET THE ROWID OF THE CLOSED POSITION TO MAP WHICH MINUTE THE POSIITON WAS CLOSED FOR DEBUG PURPOSES
                                us.closeflag = ptype                                                                                                                                              ' INDICATES THAT THE CLOSED METHOD WAS HIGH  ***** NEED TO DETERMINE IF THIS HAS VALUE ANYMORE OR NOT
                                us.timestamp = DateTime.Parse(Now).ToUniversalTime                                                                                                              ' SET THE TIMESTAMP FOR THE LATEST UPDATE TO THE HARVEST TABLE.                                        

                                db.SubmitChanges()

                                stockclosecntr = stockclosecntr + 1                                                                                                                             ' INCREMENT THE CLOSED POSIITON COUNTER TO BE WRITTEN TO THE LOG AT THE END OF THE MARKETDATE PROCESSING
                                stockprofit = stockprofit + (h.shares * (us.closeprice - us.openprice))

                                If currentcapital > 0 Then
                                    currentcapital = currentcapital - (resultingPrice * h.shares)
                                End If

                            End If

                        Next
                        mark = resultingPrice

                    End If

                Else                                                                                                                                                                        ' PROCESS IF PRICE IS LESS THAN MARK

                    If price - mark < ((-1 * width) + 0.01) Then                                                                                                                              ' PRICE BELOW CHECKS THE PRICE LESS THE MARK AGAINST THE WIDTH IF IT IS EQUAL TO OR LESS THAN THAT VALUE THEN TRIGGER ACTION
                        loops = (mark - price) / width                                                                                                                                        ' CALCULATES THE NUMBER OF TIMES TO LOOP THROUGH THE PROCESS BASED ON THE NUMBER OF INTERVALS THE PRICE IS BELOW THE MARK
                        loops = Math.Floor(loops)

                        For i = 1 To loops                                                                                                                                                      ' LOOP FUNCTION FOR PRICE BELOW 

                            'If price < mark - width * i Then

                            resultingPrice = mark - width * i                                                                                                                                 ' RESULTING PRICE WHEN THE WIDTH MULTIPLIED BY THE LOOP COUNTER IS SUBTRACTED FROM THE MARK THIS GIVES THE CHANGE IN INTERVAL LEVELS BASED ON THE PRICE MOVEMENT

                            If db.posExists(harvestkey, resultingPrice, True) = False Then                                                                                                      ' CHECK IF THERE IS A POSITION TO CLOSE FOR THIS RESULTING PRICE IF NOT THEN ADD THE POSITION

                                Dim newHarvestPosition As New HarvestPosition                                                                                                                   ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE
                                TryUpdateModel(newHarvestPosition)                                                                                                                              ' TEST CONNECTION TO DATABASE TABLES
                                Dim newpos As New HarvestPosition With { _
                                                                .open = True, _
                                                                .symbol = h.product.ToUpper, _
                                                                .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                                .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                                .openflag = ptype, _
                                                                .openrowid = rowid, _
                                                                .shares = h.shares, _
                                                                .harvestkey = harvestkey, _
                                                                .openprice = resultingPrice _
                                                            }                                                                                                                                   ' OPEN THE NEW RECORD (BOUGHT POSITION) IN THE TABLE

                                db.HarvestPositions.InsertOnSubmit(newpos)
                                db.SubmitChanges()                                                                                                                                              ' COMMIT THE NEW POSITION TO THE DATABASE

                                stockopencntr = stockopencntr + 1                                                                                                                               ' INCREMENT THE OPEN POSITION COUNTER TO BE WRITTEN TO THE LOG RECORD AT THE END OF THE DAYS PROCESSING
                                currentcapital = currentcapital + (resultingPrice * h.shares)
                                If currentcapital > maxcapital Then
                                    maxcapital = currentcapital
                                End If


                                'datastring = "Added position for price: " & (String.Format("{0:C}", resultingPrice))

                                datastring = processHedge(harvestkey, marketdate, resultingPrice, rowid)                                                                                          ' CHECK IF A HEDGE EXISTS FOR THE POSITION ADDED 
                                'datastring = processHedge(harvestkey, marketdate, resultingPrice, "c")                                                                                          ' CHECK IF A HEDGE EXISTS FOR THE POSITION TO BE CLOSED

                            End If
                        Next
                        ' UPDATE THE MARK & LOGS 
                        mark = resultingPrice

                    End If



                End If
            End Using


            Return mark
        End Function

        Private Function ParseBackData(csvData As String) As List(Of backPrice)                                                                                                             ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
            Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.
            Dim backprices As New List(Of backPrice)()                                                                                                                                      ' INITIALIZE THE BACKPRICES LIST
            Dim marketdatetime As DateTime                                                                                                                                                  ' INITIALIZE THE MARKET DATE BEING PROCESSED    
            Dim marketdate As String                                                                                                                                                        ' USED TO REDUCE MARKETDATETIME TO DATE ONLY

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)                                                                                                         ' LOADS EACH LINE INTO ROWS TO BE PARSED

            For Each row As String In rows                                                                                                                                                  ' ROW LOOPS

                If String.IsNullOrEmpty(row) Then                                                                                                                                           ' IF THE LINE IS NULL OR EMPTY MOVE TO NEXT ROW
                    Continue For                                                                                                                                                            ' MOVE FORWARD IN THE LOOP
                End If

                Dim cols As String() = row.Split(","c)                                                                                                                                      ' SPLIT ROWS INTO FIELDS BASED ON , 

                If cols(0) = "Date" Then                                                                                                                                                    ' CHECK FOR THE DATE ROW. USED IN YAHOO FINANCE
                    Continue For
                End If

                Dim p As New backPrice()                                                                                                                                                    ' INITIALIZE A NEW BACKPRICE 
                p.MarketDate = cols(0)                                                                                                                                                      ' SET COLUMN 0 TO MARKET DATE
                p.MarketTime = cols(1)                                                                                                                                                      ' SET COLUMN 1 TO MARKET TIME
                p.OpenPrice = Convert.ToDecimal(cols(2))                                                                                                                                    ' SET COLUMN 2 TO OPEN PRICE    
                p.HighPrice = Convert.ToDecimal(cols(3))                                                                                                                                    ' SET COLUMN 3 TO HIGH PRICE
                p.LowPrice = Convert.ToDecimal(cols(4))                                                                                                                                     ' SET COLUMN 4 TO LOW PRICE
                p.ClosePrice = Convert.ToDecimal(cols(5))                                                                                                                                   ' SET COLUMN 5 TO CLOSE PRICE
                'p.Volume = Convert.ToDecimal(cols(6))

                marketdate = DateTime.Parse(Left(Right(p.MarketDate, 4), 2) & "/" _
                                            & Right(p.MarketDate, 2) & "/" & Left(p.MarketDate, 4))                                                                                         ' FORMAT MARKET DATE TO MM/DD/YYYY
                marketdatetime = getdatetime(marketdate, p.MarketTime)                                                                                                                      ' FORMAT MARKET TIME FROM MARKETDATE
                p.MarketDate = marketdate                                                                                                                                                   ' SET MARKETDATE TO MARKETDATETIME

                ' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
                If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then                                                                                                                   ' CHECK IF MARKET TIME IS AFTER MARKET OPENS
                    If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then                                                                                                               ' CHECK IF MARKET TIME IS BEFORE MARKET CLOSES CHANGE BACK TO 4:01:00 PM
                        p.interval = rowcntr                                                                                                                                                ' SET INTERVAL FIELD IN PRICE TO CURRENT ROW
                        backprices.Add(p)                                                                                                                                                   ' ADD P TO BACKPRICES
                        rowcntr = rowcntr + 1                                                                                                                                               ' INCREMENT THE ROW COUNTER
                    End If
                End If

            Next

            Return backprices                                                                                                                                                               ' RETURN TO CALLING FUNCTION WITH BACKPRICES MODEL POPULATED
        End Function

        Private Function ParseIntervalData(csvData As String) As List(Of interval)                                                                                                          ' THIS FUNCTION WILL PARSE THE INTERVAL PRICES FROM THE CSV FILE.
            Dim intervals As New List(Of interval)()                                                                                                                                        ' INITIALIZE THE BACKPRICES LIST
            Dim rowcntr As Integer = 0                                                                                                                                                      ' INITALIZE THE ROW COUNTER.

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)                                                                                                         ' LOADS EACH LINE INTO ROWS TO BE PARSED

            For Each row As String In rows                                                                                                                                                  ' ROW LOOPS

                If String.IsNullOrEmpty(row) Then                                                                                                                                           ' IF THE LINE IS NULL OR EMPTY MOVE TO NEXT ROW
                    Continue For                                                                                                                                                            ' MOVE FORWARD IN THE LOOP
                End If

                Dim cols As String() = row.Split(","c)                                                                                                                                      ' SPLIT ROWS INTO FIELDS BASED ON ,

                Dim i As New interval()                                                                                                                                                     ' INITIALIZE A NEW INTERVAL 
                i.iTime = cols(0)                                                                                                                                                           ' SET COLUMN 0 TO MARKET DATE
                i.Interval = cols(1)                                                                                                                                                        ' SET COLUMN 1 TO MARKET TIME
                intervals.Add(i)
                'i.iTime = (String.Format("{0:hh:mm}", i.iTime))                                                                                                                                 ' FORMAT TIME TO SHORTTIMESTRING HH:MM:SS
            Next

            Return intervals
        End Function

        Function processHedge(ByVal harvestkey As String, ByVal marketdate As Date, ByVal price As Double, ByVal rowid As Integer) As String                                                  ' RECEIVES PARAMETERS FROM CALLING FUNCTION AND WILL OPEN OR CLOSE A HEDGE IF IT EXISTS OR NOT

            Dim datastring As String = ""                                                                                                                                                   ' DATASTRING THAT RETURNS RESULTS TO THE VIEW AND CALLS REQUIRED FUNCTIONS
            Dim putprice As Double = 0

            Using db As New wavesDataContext                                                                                                                                                ' ESTABLISH DATA CONTEXT TO THE DATA TABLES 

                Dim h As HarvestIndex = db.GetHarvestIndex(harvestkey, True)                                                                                                                ' GET INDEX DATA BASED ON HARVEST KEY
                Dim Exp As Date = expdate(harvestkey, marketdate)                                                                                                                   ' CALL FUNCTION TO DETERMINE EXPIRATION DATE BASED ON THE HARVEST KEY AND MARKET DATE TIMING WIDTH SET IN HARVEST INDEX
                Dim targetprice As Double = Int(price - h.hedgewidth)                                                                                                               ' SETS THE STRIKE AND TARGETED EXIT STOCK PRICE FOR THE HEDGE
                putprice = getPutPrice(price, targetprice, marketdate, Exp)                                                                                                         ' CALLS THE FUNCTION TO CALCULATE THE PUT PRICE BASED ON THE BLACK SCHOLES PRICING ESTIMATOR
                Dim hedgeExit As Double = ((((targetprice - price) / h.hedgelots) - putprice) - (h.width / h.hedgelots)) * -1                                                       ' CALCULATE THE PUT OPTION (HEDGE) EXIT PRICE TO SET TO EXIT ANYTHING ABOVE THIS EXCEEDS THE PROFIT TARGET

                'If type = "o" Then                                                                                                                                                          ' TYPE IS PASSED FROM THE CALLING FUNCTION o HANDLES OPENING A HEDGE 

                If db.hedgeexists(harvestkey, price, True) = False Then                                                                                                                 ' CHECK TO SEE IF HEDGE ALREADY EXISTS FOR THIS PRICE LEVEL, IF NOT ADD IT

                    Dim newHarvestHEDGE As New HarvestHedge                                                                                                                             ' OPEN NEW STRUCTURE FOR RECORD IN HARVEST TABLE.
                    TryUpdateModel(newHarvestHEDGE)                                                                                                                                     ' TEST CONNECTION TO DATABASE TABLES.
                    Dim newhedge As New HarvestHedge With { _
                                                    .symbol = h.product.ToUpper, _
                                                    .type = "P", _
                                                    .lots = h.hedgelots, _
                                                    .strike = targetprice, _
                                                    .stockatopen = price, _
                                                    .opendate = DateTime.Parse(marketdate).ToUniversalTime(), _
                                                    .timestamp = DateTime.Parse(Now).ToUniversalTime(), _
                                                    .open = True, _
                                                    .openrowid = rowid, _
                                                    .exp = Exp, _
                                                    .targetexit = hedgeExit, _
                                                    .openprice = putprice, _
                                                    .harvestkey = harvestkey _
                                                }                                                                                                                                       ' OPEN THE NEW RECORD (HEDGE) IN THE TABLE.   .openrowid = rowid _

                    db.HarvestHedges.InsertOnSubmit(newhedge)
                    db.SubmitChanges()                                                                                                                                                  ' SUBMIT THE CHANGES FOR EACH OPEN POSITION IN THE HARVEST TABLE.

                    hedgecntr = hedgecntr + 1
                    hedgeopencntr = hedgeopencntr + 1


                End If

                If db.hedgeexists(harvestkey, price + h.hedgewidth, True) = True Then

                    If db.posExists(harvestkey, price + h.hedgewidth, True) = True Then
                        putprice = getPutPrice(price, targetprice + h.hedgewidth, marketdate, Exp)

                        Dim uh = db.gethedge(harvestkey, price + h.hedgewidth, True)
                        uh.closerowid = rowid
                        uh.stockatclose = price
                        uh.closedate = marketdate
                        uh.closeprice = putprice
                        uh.open = False

                        Dim us = db.getposition(harvestkey, price + h.hedgewidth, True)
                        us.closeflag = "Z"
                        us.closedate = marketdate
                        us.open = False
                        us.closeprice = price
                        us.closerowid = rowid
                        us.closedate = DateTime.Parse(marketdate).ToUniversalTime()
                        us.timestamp = DateTime.Parse(Now).ToUniversalTime()
                        us.hedgeid = uh.id
                        uh.open = False
                        uh.positionID = us.id

                        hedgeprofit = hedgeprofit + ((us.shares * (price - uh.stockatopen)) + ((h.hedgelots * 100) * (uh.closeprice - uh.openprice)))
                        hedgeclosecntr = hedgeclosecntr + 1
                        stockclosecntr = stockclosecntr + 1
                        currentcapital = currentcapital - (price * h.shares)

                    End If

                    db.SubmitChanges()

                End If

            End Using
            Return datastring
        End Function

        Function getPutPrice(ByVal price As Double, ByVal strike As Double, ByVal marketdate As Date, ByVal expdate As Date) As Double

            ' THIS FUNCTION CALCULATES THE PUT OPTION PRICE AND RETURNS IT TO THE CALLING FUNCTION. IT USES THE BLACK SCHOLES OPTIONS CALCULATOR AS A PRICE ESTIMATOR.  FOR A SYSTEM TO USE THIS IT REQUIRES THAT THE USER HAS MICROSOFT EXCEL INSTALLED ON THEIR SYSTEM AS IT LEVERAGES
            ' THE EXCEL OBJECT TO CALCULATE NORMAL DISTRIBUTIONS FOR THE CALCULATOR.  THIS IS CALLED WHEN OPENING AND CLOSING A HEDGE POSITION.  NOTE: ASSUMES VOL AT 25%, DIVIDEND AT 0.00 AND INTEREST AT 3% STATIC TO AVOID SWINGS IN PRICE BASED ON ENVIRONMENTAL CONDITIONS.
            ' ***** THIS IS AN ESTIMATOR ONLY *****

            Dim putprice As Double                                                                                                                                          ' DEFINE THE VARIABLE TO BE CALCULATED AND PASSED BACK TO THE CALLING FUNCTION.

            Dim excel As New Excel.Application                                                                                                                              ' ESTABLISHES THE EXCEL OBJECT IN THE FUNCTION.

            Dim fullpath As String = Request.MapPath("~\\content\assets\excel\bondi.xlsx")                                                                                  ' SETS THE VIRTUAL PATH AS THE PHYSICAL PATH TO LOCATE THE EXCEL FILE USED IN THE CALCULATIONS.

            Dim wb As Excel.Workbook = excel.Workbooks.Open(fullpath)                                                                                                       ' INITIALIZES THE EXCEL WORKBOOK TO BE USED.
            Dim ws As Excel.Worksheet = wb.Sheets(1)                                                                                                                        ' INITIALIZES THE SHEET TO BE USED AS THE FIRST SHEEK IN THE WORKBOOK.

            Dim iv As Double = 0.25                                                                                                                                         ' SETS VOLATILITY AT A FIXED RATE OF 25% **************************************** WILL WANT TO CONVERT THIS TO A VARIABLE IN SETTINGS.
            Dim rate As Double = 0.03                                                                                                                                       ' SETS INTEREST RATE AT A FIXED RATE OF 3% ************************************** WILL WANT TO CONVERT THIS TO A VARIABLE IN SETTINGS.
            Dim dividend As Double = 0.0                                                                                                                                    ' SETS DIVIDEND RATE AT A FEXID RATE OF 0% ************************************** WILL WANT TO CONVERT THIS TO A VARIABLE IN SETTINGS.

            Dim timetoexpiration As TimeSpan = expdate.Subtract(marketdate)
            Dim dte As Integer = timetoexpiration.Days
            Dim prctofyear As Double = dte / 365

            Dim a1 As Double = Log(price / strike)                                                                                                                          ' Column H
            Dim a2 As Double = (rate - dividend + Pow(iv, 2) / 2) * prctofyear          ' Column I
            Dim a3 As Double = Max(0.000000000001, iv * Sqrt(prctofyear))                       ' Column J
            Dim d1 As Double = (a1 + a2) / a3                                                   ' Column K
            Dim d2 As Double = d1 - a3                                                          ' Column L

            ws.Range("B2").Value = "=NORM.DIST(" & d1 & ",0,1,TRUE)"
            ws.Range("B3").Value = "=NORM.DIST(" & -d1 & ",0,1,TRUE)"
            ws.Range("B4").Value = "=NORM.DIST(" & d2 & ",0,1,TRUE)"
            ws.Range("B5").Value = "=NORM.DIST(" & -d2 & ",0,1,TRUE)"

            Dim Nd1 As Double = ws.Range("b2").Value
            Dim Nd1n As Double = ws.Range("b3").Value
            Dim Nd2 As Double = ws.Range("b4").Value
            Dim Nd2n As Double = ws.Range("b5").Value

            Dim ert As Double = Exp(-rate * prctofyear)
            Dim Xert As Double = strike * ert
            Dim Eqtn As Double = Exp(-dividend * prctofyear)
            Dim Soe As Double = price * Eqtn
            Dim callprice As Double = Soe * Nd1 - Xert * Nd2
            putprice = Xert * Nd2n - Soe * Nd1n

            ws = Nothing
            wb.Close(False)
            wb = Nothing

            excel.Quit()
            excel = Nothing

            Return putprice
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

        Public Function RandomGenerator() As Integer
            Dim byteCount As Byte() = New Byte(6) {}
            Dim randomNumber As New RNGCryptoServiceProvider()

            randomNumber.GetBytes(byteCount)
            Return BitConverter.ToInt32(byteCount, 0)
        End Function

    End Class
End Namespace
