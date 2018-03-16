' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Linq
Imports System.Collections.Generic
Imports IBApi
Imports System.Threading

Friend Class Tws
    Implements IBApi.EWrapper

    Dim cntr As Integer = 0


    Dim eReaderSignal As EReaderSignal = New EReaderMonitorSignal
    Dim socket As IBApi.EClientSocket = New IBApi.EClientSocket(Me, eReaderSignal)
    Public ordernumber As Integer
    Private id As Integer
    Private _tickType As Utils.TickType
    Private price As Double
    Private _canAutoExecute As Integer
    Private _symbol As String
    Private _orderID As Integer
    Private _status As String
    Public listHistoricalPrice As List(Of HistoricalDataMessage) = New List(Of HistoricalDataMessage)
    Public listOrderStatus As List(Of OrderStatusMessage) = New List(Of OrderStatusMessage)
    Public OpenOrderList As List(Of OpenOrders) = New List(Of OpenOrders)
    Public listPositionsMessage As List(Of PositionMessage) = New List(Of PositionMessage)
    Public OrderIdList As List(Of OrderIds) = New List(Of OrderIds)
    Public OrderNum As Integer = New Integer

    Public Property OrderID() As Integer
        Get
            Return _orderID
        End Get
        Set(ByVal value As Integer)
            _orderID = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
    Public Property Symbol() As String
        Get
            Return _symbol
        End Get
        Set(ByVal value As String)
            _symbol = value
        End Set
    End Property
    Public Property TickId() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property
    Public Property StockTickPrice() As Double
        Get
            Return price
        End Get
        Set(ByVal value As Double)
            price = value
        End Set
    End Property
    Public Property TickType() As Utils.TickType
        Get
            Return _tickType
        End Get
        Set(ByVal value As Utils.TickType)
            _tickType = value
        End Set
    End Property
    Public Property CanAutoExecute() As Integer
        Get
            Return _canAutoExecute
        End Get
        Set(ByVal value As Integer)
            _canAutoExecute = value
        End Set
    End Property

    'Sub InvokeIfRequired(del As [Delegate])
    '    If Me.InvokeRequired Then
    '        form.Invoke(del)
    '    Else
    '        del.DynamicInvoke()
    '    End If
    'End Sub

#Region "IBApi.EWrapper"

    Sub softDollarTiers(reqId As Integer, tiers() As SoftDollarTier) Implements EWrapper.softDollarTiers

    End Sub
    Public Sub accountDownloadEnd(account As String) Implements IBApi.EWrapper.accountDownloadEnd

    End Sub
    Public Sub accountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements IBApi.EWrapper.accountSummary

    End Sub
    Public Sub accountSummaryEnd(reqId As Integer) Implements IBApi.EWrapper.accountSummaryEnd

    End Sub
    Public Sub commissionReport(commissionReport As IBApi.CommissionReport) Implements IBApi.EWrapper.commissionReport

    End Sub
    Public Sub connectionClosed() Implements IBApi.EWrapper.connectionClosed

    End Sub
    Public Sub contractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.contractDetails

    End Sub
    Public Sub contractDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.contractDetailsEnd

    End Sub
    Public Sub currentTime(time As Long) Implements IBApi.EWrapper.currentTime

    End Sub
    Public Sub deltaNeutralValidation(reqId As Integer, underComp As IBApi.UnderComp) Implements IBApi.EWrapper.deltaNeutralValidation

    End Sub
    Public Sub displayGroupList(reqId As Integer, groups As String) Implements IBApi.EWrapper.displayGroupList

    End Sub
    Public Sub displayGroupUpdated(reqId As Integer, contractInfo As String) Implements IBApi.EWrapper.displayGroupUpdated

    End Sub
    Public Sub [error](id As Integer, errorCode As Integer, errorMsg As String) Implements IBApi.EWrapper.error

    End Sub
    Public Sub [error](str As String) Implements IBApi.EWrapper.error

    End Sub
    Public Sub [error](e As Exception) Implements IBApi.EWrapper.error

    End Sub
    Public Sub execDetails(reqId As Integer, contract As IBApi.Contract, execution As IBApi.Execution) Implements IBApi.EWrapper.execDetails

    End Sub
    Public Sub execDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.execDetailsEnd

    End Sub
    Public Sub fundamentalData(reqId As Integer, data As String) Implements IBApi.EWrapper.fundamentalData

    End Sub
    Public Sub historicalData(reqId As Integer, [date] As String, open As Double, high As Double, low As Double, close As Double, volume As Integer, count As Integer, WAP As Double, hasGaps As Boolean) Implements IBApi.EWrapper.historicalData
        Dim histData As HistoricalDataMessage = New HistoricalDataMessage(reqId, [date], open, high, low, close, volume, count)
        listHistoricalPrice.Add(histData)
    End Sub
    Public Sub historicalDataEnd(reqId As Integer, start As String, [end] As String) Implements IBApi.EWrapper.historicalDataEnd

    End Sub
    Public Sub managedAccounts(accountsList As String) Implements IBApi.EWrapper.managedAccounts

    End Sub
    Public Sub marketDataType(reqId As Integer, marketDataType As Integer) Implements IBApi.EWrapper.marketDataType

    End Sub
    Public Sub nextValidId(orderId As Integer) Implements IBApi.EWrapper.nextValidId

        'Dim orderIDList As OrderIds = New OrderIds(orderId)                                                                                                                                                            ' SET THE CURRENT ORDER ID TO INCREMENT BEFORE SENDING THE NEXT ORDER.
        'MsgBox("NextValidId - OrderId [" & orderId & "]")
        nextOrderId = orderId
        'Stop
    End Sub
    Public Sub openOrder(orderId As Integer, contract As IBApi.Contract, order As IBApi.Order, orderState As IBApi.OrderState) Implements IBApi.EWrapper.openOrder                                                      ' HANDLES ALL OF THE PROCESSING FOR OPEN ORDERS USING THE API.

        Dim openorderslist As OpenOrders = New OpenOrders(contract.Symbol, order.PermId, order.LmtPrice, order.Action, contract.SecType, orderState.Status, order.OrderId)                                              ' SETS THE OPEN ORDER LIST TO ALL OPEN ORDERS PULLED VIA THE API FOR THE FIELDS LISTED.

        Dim itemExist As Boolean = OpenOrderList.Any(Function(x) x.PermId = order.PermId)                                                                                                                               ' LINQ SQL TO CHECK THE OPEN ORDERS LIST FOR DUPLICATES BASED ON THE UNIQUE ID OF PERMID
        If (Not itemExist) Then                                                                                                                                                                                         ' IF THE PERM ID IS FOUND AND NOT A DUPLICATE             
            OpenOrderList.Add(openorderslist)                                                                                                                                                                           ' ADD THE FIELDS TO THE OPEN ORDERS LIST.
        End If

    End Sub
    Public Sub openOrderEnd() Implements IBApi.EWrapper.openOrderEnd

    End Sub
    'Public Sub orderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double,
    '                       permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus

    '    Dim ordersStatus As OrderStatusMessage = New OrderStatusMessage(orderId, status, filled, remaining,
    '                                                                    avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld)
    '    listOrderStatus.Add(ordersStatus)
    '    Me.OrderID = orderId
    '    Me.Status = status
    '    cntr = cntr + 1
    '    Stop
    'End Sub

    Public Sub orderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double,
                           permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus

        Dim ordersStatus As OrderStatusMessage = New OrderStatusMessage(orderId, status, filled, remaining, price,
                                                                        avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld)

        Dim itemIndex As Integer = listOrderStatus.FindIndex(Function(x) x.PermId = permId)

        If (itemIndex > 0) Then
            listOrderStatus.RemoveAt(itemIndex)
        End If

        listOrderStatus.Add(ordersStatus)

        'Dim itemExist As Boolean = listOrderStatus.Any(Function(x) x.PermId = permId)
        'If (Not itemExist) Then
        '    listOrderStatus.Add(ordersStatus)
        'End If

        Me.OrderID = orderId
        Me.Status = status

    End Sub


    'Public Sub orderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double,
    '                       permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus

    '    Dim ordersStatus As OrderStatusMessage = New OrderStatusMessage(orderId, status, filled, remaining,
    '                                                                    avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld)
    '    Dim itemIndex As Integer = listOrderStatus.FindIndex(Function(x) x.PermId = permId)

    '    If (itemIndex > 0) Then
    '        listOrderStatus.RemoveAt(itemIndex)
    '    End If

    '    listOrderStatus.Add(ordersStatus)

    '    Me.OrderID = orderId
    '    Me.Status = status

    'End Sub


    Public Sub position(account As String, contract As IBApi.Contract, pos As Double, avgCost As Double) Implements IBApi.EWrapper.position

        Dim positionsMessage As PositionMessage = New PositionMessage(account, contract, pos, avgCost)

        listPositionsMessage.Add(positionsMessage)

    End Sub

    Public Sub positionEnd() Implements IBApi.EWrapper.positionEnd

    End Sub
    Public Sub realtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements IBApi.EWrapper.realtimeBar
        If True Then
            Console.Write("Done")
        End If
    End Sub
    Public Sub receiveFA(faDataType As Integer, faXmlData As String) Implements IBApi.EWrapper.receiveFA

    End Sub
    Public Sub scannerData(reqId As Integer, rank As Integer, contractDetails As IBApi.ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements IBApi.EWrapper.scannerData

    End Sub
    Public Sub scannerDataEnd(reqId As Integer) Implements IBApi.EWrapper.scannerDataEnd

    End Sub
    Public Sub scannerParameters(xml As String) Implements IBApi.EWrapper.scannerParameters

    End Sub
    Public Sub tickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureLastTradeDate As String, dividendImpact As Double, dividendsToLastTradeDate As Double) Implements IBApi.EWrapper.tickEFP

    End Sub
    Public Sub tickGeneric(tickerId As Integer, field As Integer, value As Double) Implements IBApi.EWrapper.tickGeneric

    End Sub
    Public Sub tickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements IBApi.EWrapper.tickOptionComputation

    End Sub
    'New Code
    Public Sub tickPrice(tickerId As Integer, field As Integer, price As Double, canAutoExecute As Integer) Implements IBApi.EWrapper.tickPrice
        'MsgBox("Ticker Id:" + tickerId.ToString() + ", Field:" + field.ToString() + ", Price:" + price.ToString())
        Me.TickId = tickerId
        'Me.StockTickPrice = price
        Me.TickType = field
        Me.CanAutoExecute = canAutoExecute
        'cancelMktData(tickerId)

        ' WILL NEED TO CHANGE THIS ONCE THE REAL TIME STREAM IS SET UP

        If Me.TickType = 68 Then
            Me.StockTickPrice = price
        End If
    End Sub
    Function LogMessage() As String
        Return "Symbol : " & Me.Symbol & " Price : " & Me.StockTickPrice
    End Function

    Public Sub tickSize(tickerId As Integer, field As Integer, size As Integer) Implements IBApi.EWrapper.tickSize

    End Sub
    Public Sub tickSnapshotEnd(tickerId As Integer) Implements IBApi.EWrapper.tickSnapshotEnd

    End Sub
    Public Sub tickString(tickerId As Integer, field As Integer, value As String) Implements IBApi.EWrapper.tickString

    End Sub
    Public Sub updateAccountTime(timestamp As String) Implements IBApi.EWrapper.updateAccountTime

    End Sub
    Public Sub updateAccountValue(key As String, value As String, currency As String, accountName As String) Implements IBApi.EWrapper.updateAccountValue

    End Sub
    Public Sub updateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepth

    End Sub
    Public Sub updateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepthL2

    End Sub
    Public Sub updateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements IBApi.EWrapper.updateNewsBulletin

    End Sub
    Public Sub updatePortfolio(contract As IBApi.Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements IBApi.EWrapper.updatePortfolio

    End Sub
    Public Sub verifyCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyCompleted

    End Sub
    Public Sub verifyMessageAPI(apiData As String) Implements IBApi.EWrapper.verifyMessageAPI

    End Sub
    Public Sub verifyAndAuthCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyAndAuthCompleted

    End Sub
    Public Sub verifyAndAuthMessageAPI(apiData As String, xyzChallenge As String) Implements IBApi.EWrapper.verifyAndAuthMessageAPI

    End Sub
    Public Sub connectAck() Implements EWrapper.connectAck
        If socket.AsyncEConnect Then
            socket.startApi()
        End If
    End Sub
    Public Sub positionMulti(reqId As Integer, account As String, modelCode As String, contract As IBApi.Contract, pos As Double, avgCost As Double) Implements IBApi.EWrapper.positionMulti

    End Sub
    Public Sub positionMultiEnd(reqId As Integer) Implements IBApi.EWrapper.positionMultiEnd

    End Sub
    Public Sub accountUpdateMulti(reqId As Integer, account As String, modelCode As String, key As String, value As String, currency As String) Implements IBApi.EWrapper.accountUpdateMulti

    End Sub
    Public Sub accountUpdateMultiEnd(reqId As Integer) Implements IBApi.EWrapper.accountUpdateMultiEnd

    End Sub
    Public Sub bondContractDetails(reqId As Integer, contract As IBApi.ContractDetails) Implements IBApi.EWrapper.bondContractDetails

    End Sub
    Public Sub securityDefinitionOptionParameter(reqId As Integer, exchange As String, underlyingConId As Integer, tradingClass As String, multiplier As String, expirations As HashSet(Of String), strikes As HashSet(Of Double)) Implements EWrapper.securityDefinitionOptionParameter

    End Sub
    Public Sub securityDefinitionOptionParameterEnd(reqId As Integer) Implements EWrapper.securityDefinitionOptionParameterEnd

    End Sub
#End Region

    Sub reqScannerParameters()
        socket.reqScannerParameters()
    End Sub

    Sub cancelScannerSubscription(id As Short)
        socket.cancelScannerSubscription(id)
    End Sub

    Sub reqScannerSubscriptionEx(id As Integer, subscription As IBApi.ScannerSubscription, scannerSubscriptionOptions As Generic.List(Of IBApi.TagValue))
        socket.reqScannerSubscription(id, subscription, scannerSubscriptionOptions)
    End Sub

    Sub connect(p1 As String, p2 As Integer, p3 As Integer, p4 As Boolean)

        socket.eConnect(p1, p2, p3)

    End Sub

    Public Sub StartAPI()
        socket.startApi()
    End Sub
    'New Code
    Public Sub msgProcessing()
        Dim reader As EReader = New EReader(socket, eReaderSignal)

        reader.Start()

        Dim thread As New Thread(
        Sub()
            While socket.IsConnected
                eReaderSignal.waitForSignal()
                reader.processMsgs()
            End While
        End Sub
        )
        thread.IsBackground = True
        thread.Sleep(3000)
        thread.Start()

    End Sub


    Function serverVersion() As Integer
        serverVersion = socket.ServerVersion
    End Function

    Function TwsConnectionTime() As String
        TwsConnectionTime = socket.ServerTime
    End Function

    Sub disconnect()
        socket.eDisconnect()
    End Sub

    Sub reqMktDataEx(tickerId As Integer, m_contractInfo As IBApi.Contract, genericTicks As String, snapshot As Boolean, m_mktDataOptions As Generic.List(Of IBApi.TagValue))
        socket.reqMktData(tickerId, m_contractInfo, genericTicks, snapshot, m_mktDataOptions)
    End Sub

    Sub cancelMktData(p1 As Integer)
        socket.cancelMktData(p1)
    End Sub

    Sub reqMktDepthEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Integer, m_mktDepthOptions As Generic.List(Of IBApi.TagValue))
        socket.reqMarketDepth(p1, m_contractInfo, p3, m_mktDepthOptions)
    End Sub

    Sub cancelMktDepth(p1 As Integer)
        socket.cancelMktDepth(p1)
    End Sub

    Sub reqHistoricalDataEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As String, p4 As String, p5 As String, p6 As String, p7 As Integer, p8 As Integer, m_chartOptions As Generic.List(Of IBApi.TagValue))
        socket.reqHistoricalData(p1, m_contractInfo, p3, p4, p5, p6, p7, p8, m_chartOptions)
    End Sub

    Sub cancelHistoricalData(p1 As Integer)
        socket.cancelHistoricalData(p1)
    End Sub

    Sub reqFundamentalData(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As String)
        socket.reqFundamentalData(p1, m_contractInfo, p3, Nothing)
    End Sub

    Sub cancelFundamentalData(p1 As Integer)
        socket.cancelFundamentalData(p1)
    End Sub

    Sub reqRealTimeBarsEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Integer, p4 As String, p5 As Integer, m_realTimeBarsOptions As Generic.List(Of IBApi.TagValue))
        socket.reqRealTimeBars(p1, m_contractInfo, p3, p4, p5, m_realTimeBarsOptions)
    End Sub

    Sub cancelRealTimeBars(p1 As Integer)
        socket.cancelRealTimeBars(p1)
    End Sub

    Sub reqCurrentTime()
        socket.reqCurrentTime()
    End Sub

    Sub placeOrderEx(p1 As Integer, m_contractInfo As IBApi.Contract, m_orderInfo As IBApi.Order)
        socket.placeOrder(p1, m_contractInfo, m_orderInfo)
    End Sub

    Sub cancelOrder(p1 As Integer)
        socket.cancelOrder(p1)
    End Sub

    Sub exerciseOptionsEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Integer, p4 As Integer, p5 As String, p6 As Integer)
        socket.exerciseOptions(p1, m_contractInfo, p3, p4, p5, p6)
    End Sub

    Sub reqContractDetailsEx(p1 As Integer, m_contractInfo As IBApi.Contract)
        socket.reqContractDetails(p1, m_contractInfo)
    End Sub



    Sub reqOpenOrders()
        socket.reqOpenOrders()
    End Sub

    Sub reqAllOpenOrders()
        socket.reqAllOpenOrders()
    End Sub

    Sub reqAutoOpenOrders(p1 As Boolean)
        socket.reqAutoOpenOrders(p1)
    End Sub

    Sub reqAccountUpdates(p1 As Boolean, p2 As String)
        socket.reqAccountUpdates(p1, p2)
    End Sub

    Sub reqExecutionsEx(p1 As Integer, m_execFilter As IBApi.ExecutionFilter)
        socket.reqExecutions(p1, m_execFilter)
    End Sub

    Sub reqIds(p1 As Integer)
        socket.reqIds(p1)
    End Sub

    Sub reqNewsBulletins(p1 As Boolean)
        socket.reqNewsBulletins(p1)
    End Sub

    Sub cancelNewsBulletins()
        socket.cancelNewsBulletin()
    End Sub

    Sub setServerLogLevel(p1 As Short)
        socket.setServerLogLevel(p1)
    End Sub

    Sub reqManagedAccts()
        socket.reqManagedAccts()
    End Sub

    Sub requestFA(fA_Message_Type As Utils.FA_Message_Type)
        socket.requestFA(fA_Message_Type)
    End Sub

    Sub calculateImpliedVolatility(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Double, p4 As Double)
        socket.calculateImpliedVolatility(p1, m_contractInfo, p3, p4, Nothing)
    End Sub

    Sub calculateOptionPrice(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Double, p4 As Double)
        socket.calculateOptionPrice(p1, m_contractInfo, p3, p4, Nothing)
    End Sub

    Sub cancelCalculateImpliedVolatility(p1 As Integer)
        socket.cancelCalculateImpliedVolatility(p1)
    End Sub

    Sub cancelCalculateOptionPrice(p1 As Integer)
        socket.cancelCalculateOptionPrice(p1)
    End Sub

    Sub reqGlobalCancel()
        socket.reqGlobalCancel()
    End Sub

    Sub reqMarketDataType(p1 As Integer)
        socket.reqMarketDataType(p1)
    End Sub

    Sub reqPositions()
        socket.reqPositions()
    End Sub

    Sub cancelPositions()
        socket.cancelPositions()
    End Sub

    Sub reqAccountSummary(p1 As Integer, p2 As String, p3 As String)
        socket.reqAccountSummary(p1, p2, p3)
    End Sub

    Sub cancelAccountSummary(p1 As Integer)
        socket.cancelAccountSummary(p1)
    End Sub

    Sub updateDisplayGroup(reqId As Integer, contractInfo As String)
        socket.updateDisplayGroup(reqId, contractInfo)
    End Sub

    Sub unsubscribeFromGroupEvents(reqId As Integer)
        socket.unsubscribeFromGroupEvents(reqId)
    End Sub

    Sub subscribeToGroupEvents(reqId As Integer, groupId As Integer)
        socket.subscribeToGroupEvents(reqId, groupId)
    End Sub

    Sub queryDisplayGroups(reqId As Integer)
        socket.queryDisplayGroups(reqId)
    End Sub

    Sub replaceFA(fA_Message_Type As Utils.FA_Message_Type, aliasesXML As Object)
        socket.replaceFA(fA_Message_Type, aliasesXML)
    End Sub

    Sub reqPositionsMulti(reqId As Integer, account As String, modelCode As String)
        socket.reqPositionsMulti(reqId, account, modelCode)
    End Sub

    Sub cancelPositionsMulti(reqId As Integer)
        socket.cancelPositionsMulti(reqId)
    End Sub

    Sub reqAccountUpdatesMulti(reqId As Integer, account As String, modelCode As String, ledgerAndNLV As Boolean)
        socket.reqAccountUpdatesMulti(reqId, account, modelCode, ledgerAndNLV)
    End Sub

    Sub cancelAccountUpdatesMulti(reqId As Integer)
        socket.cancelAccountUpdatesMulti(reqId)
    End Sub

    Sub reqSecDefOptParams(reqId As Integer, underlyingSymbol As String, futFopExchange As String, underlyingSecType As String, underlyingConId As Integer)
        socket.reqSecDefOptParams(reqId, underlyingSymbol, futFopExchange, underlyingSecType, underlyingConId)
    End Sub



End Class
