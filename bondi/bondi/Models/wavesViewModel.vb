Public Class wavesViewModel

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _orderlist As IEnumerable(Of OpenOrders)

    Public Property OrderList() As IEnumerable(Of OpenOrders)
        Get
            Return _orderlist
        End Get
        Set(ByVal value As IEnumerable(Of OpenOrders))
            _orderlist = value
        End Set
    End Property

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _positionlist As IEnumerable(Of OpenOrders)

    Public Property PositionList() As IEnumerable(Of PositionMessage)
        Get
            Return _positionlist
        End Get
        Set(ByVal value As IEnumerable(Of PositionMessage))
            _positionlist = value
        End Set
    End Property

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _allindexes As IEnumerable(Of HarvestIndex)

    Public Property AllIndexes() As IEnumerable(Of HarvestIndex)
        Get
            Return _allindexes
        End Get
        Set(ByVal value As IEnumerable(Of HarvestIndex))
            _allindexes = value
        End Set
    End Property

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _alllogs As IEnumerable(Of HarvestLog)

    Public Property AllLogs() As IEnumerable(Of HarvestLog)
        Get
            Return _alllogs
        End Get
        Set(ByVal value As IEnumerable(Of HarvestLog))
            _alllogs = value
        End Set
    End Property

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    'Private _alllogsTest As List(Of 

    'Public Property AllLogsTest() As IEnumerable(Of Lo)
    '    Get
    '        Return _alllogsTest
    '    End Get
    '    Set(ByVal value As IEnumerable(Of Lo))
    '        _alllogsTest = value
    '    End Set
    'End Property


    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _selectedindex As String

    Public Property SelectedIndex() As String
        Get
            Return _selectedindex
        End Get
        Set(ByVal value As String)
            _selectedindex = value
        End Set
    End Property

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _allprices As List(Of HarvestInterval)

    Public Property AllPrices() As List(Of HarvestInterval)
        Get
            Return _allprices
        End Get
        Set(ByVal value As List(Of HarvestInterval))
            _allprices = value
        End Set
    End Property

    ' This View Model is the list for all blog entries viewing in the associated pages.
    Private _allharvestprices As List(Of HarvestInterval)

    Public Property AllHarvestPrices() As List(Of HarvestInterval)
        Get
            Return _allharvestprices
        End Get
        Set(ByVal value As List(Of HarvestInterval))
            _allharvestprices = value
        End Set
    End Property

    ' This View Model is the list for all blog entries viewing in the associated pages.
    Private _allblogs As List(Of BlogEntry)

    Public Property AllBlogs() As List(Of BlogEntry)
        Get
            Return _allblogs
        End Get
        Set(ByVal value As List(Of BlogEntry))
            _allblogs = value
        End Set
    End Property

    ' This entry pulls the specific blog entry selected by the user.
    Private _postselected As BlogEntry

    Public Property postSelected() As BlogEntry
        Get
            Return _postselected
        End Get
        Set(ByVal value As BlogEntry)
            _postselected = value
        End Set
    End Property

    ' This entry pulls the specific blog entry selected by the user.
    Private _getmark As HarvestMark

    Public Property getMark() As HarvestMark
        Get
            Return _getmark
        End Get
        Set(ByVal value As HarvestMark)
            _getmark = value
        End Set
    End Property

    Private _allexperiments As List(Of HarvestIndex)

    Public Property AllExperiments() As List(Of HarvestIndex)
        Get
            Return _allexperiments
        End Get
        Set(ByVal value As List(Of HarvestIndex))
            _allexperiments = value
        End Set
    End Property

    ' This View Model is the list for all intervals entries viewing in the associated pages.
    Private _allhedges As IEnumerable(Of HarvestHedge)

    Public Property Allhedges() As IEnumerable(Of HarvestHedge)
        Get
            Return _allhedges
        End Get
        Set(ByVal value As IEnumerable(Of HarvestHedge))
            _allhedges = value
        End Set
    End Property






    Public Class confirmedOrders
        Private m_symbol As String
        Private m_permId As Integer
        Private m_lmtprice As Double
        Private m_oaction As String
        Private m_sectype As String
        Private m_status As String
        Private m_oid As Integer
        Private m_conf As Boolean

        Sub New(symbol As String, permid As Integer, lmtprice As Double, oaction As String, sectype As String, status As String, oid As Integer, conf As Boolean)
            m_permId = permid
            m_symbol = symbol
            m_lmtprice = lmtprice
            m_oaction = oaction
            m_sectype = sectype
            m_status = status
            m_oid = oid
            m_conf = conf
        End Sub

        Public Property Symbol() As String
            Get
                Return m_symbol
            End Get
            Set(value As String)
                m_symbol = value
            End Set
        End Property

        Public Property PermId() As Integer
            Get
                Return m_permId
            End Get
            Set(value As Integer)
                m_permId = value
            End Set
        End Property

        Public Property OAction() As String
            Get
                Return m_oaction
            End Get
            Set(value As String)
                m_oaction = value
            End Set
        End Property

        Public Property LmtPrice() As Double
            Get
                Return m_lmtprice
            End Get
            Set(value As Double)
                m_lmtprice = value
            End Set
        End Property

        Public Property secType() As String
            Get
                Return m_sectype
            End Get
            Set(value As String)
                m_sectype = value
            End Set
        End Property

        Public Property Status() As String
            Get
                Return m_status
            End Get
            Set(value As String)
                m_status = value
            End Set
        End Property

        Public Property OId() As Integer
            Get
                Return m_oid
            End Get
            Set(value As Integer)
                m_oid = value
            End Set
        End Property

        Public Property conf() As Boolean
            Get
                Return m_conf
            End Get
            Set(value As Boolean)
                m_conf = value
            End Set
        End Property



















    End Class

    Public Class myobj
        Private m_id As String
        Public Property ID As String
            Get
                Return m_id
            End Get
            Set(value As String)
                m_id = value
            End Set
        End Property

        Private m_name As String
        Public Property Name As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = value
            End Set
        End Property

    End Class

    Public Class Price

        Private m_Date As String
        Public Property MarketDate As String
            Get
                Return m_Date
            End Get
            Set(value As String)
                m_Date = value
            End Set
        End Property

        Public Property OpenPrice() As Decimal
            Get
                Return m_OpenPrice
            End Get
            Set(value As Decimal)
                m_OpenPrice = value
            End Set
        End Property
        Private m_OpenPrice As Decimal

        Public Property HighPrice() As Decimal
            Get
                Return m_HighPrice
            End Get
            Set(value As Decimal)
                m_HighPrice = value
            End Set
        End Property
        Private m_HighPrice As Decimal
        Public Property LowPrice() As Decimal
            Get
                Return m_LowPrice
            End Get
            Set(value As Decimal)
                m_LowPrice = value
            End Set
        End Property
        Private m_LowPrice As Decimal

        Private m_PreviousClose As Decimal
        Public Property AdjClosePrice() As Decimal
            Get
                Return m_AdjClosePrice
            End Get
            Set(value As Decimal)
                m_AdjClosePrice = value
            End Set
        End Property

        Private m_AdjClosePrice As Decimal
        Public Property ClosePrice() As Decimal
            Get
                Return m_ClosePrice
            End Get
            Set(value As Decimal)
                m_ClosePrice = value
            End Set
        End Property
        Private m_ClosePrice As Decimal

        Public Property Volume() As Integer
            Get
                Return m_Volume
            End Get
            Set(value As Integer)
                m_Volume = value
            End Set
        End Property
        Private m_Volume As Integer



    End Class

    Public Class backPrice

        Private m_Date As String
        Public Property MarketDate As String
            Get
                Return m_Date
            End Get
            Set(value As String)
                m_Date = value
            End Set
        End Property

        Private m_Time As String
        Public Property MarketTime As String
            Get
                Return m_Time
            End Get
            Set(value As String)
                m_Time = value
            End Set
        End Property

        Private m_OpenPrice As Decimal
        Public Property OpenPrice() As Decimal
            Get
                Return m_OpenPrice
            End Get
            Set(value As Decimal)
                m_OpenPrice = value
            End Set
        End Property

        Private m_HighPrice As Decimal
        Public Property HighPrice() As Decimal
            Get
                Return m_HighPrice
            End Get
            Set(value As Decimal)
                m_HighPrice = value
            End Set
        End Property

        Private m_LowPrice As Decimal
        Public Property LowPrice() As Decimal
            Get
                Return m_LowPrice
            End Get
            Set(value As Decimal)
                m_LowPrice = value
            End Set
        End Property

        Private m_AdjClosePrice As Decimal
        Public Property AdjClosePrice() As Decimal
            Get
                Return m_AdjClosePrice
            End Get
            Set(value As Decimal)
                m_AdjClosePrice = value
            End Set
        End Property

        Private m_ClosePrice As Decimal
        Public Property ClosePrice() As Decimal
            Get
                Return m_ClosePrice
            End Get
            Set(value As Decimal)
                m_ClosePrice = value
            End Set
        End Property

        Private m_Volume As Integer
        Public Property Volume() As Integer
            Get
                Return m_Volume
            End Get
            Set(value As Integer)
                m_Volume = value
            End Set
        End Property

        Private m_Interval As Integer
        Public Property interval() As Integer
            Get
                Return m_Interval
            End Get
            Set(value As Integer)
                m_Interval = value
            End Set
        End Property



    End Class

    Public Class TradeData                                                                                                      ' CLASS USED TO PARSE TD AMERITRADE DATA SUBMITTED BY THE USER.

        Private m_Type As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property type As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Type
            End Get
            Set(value As String)
                m_Type = value
            End Set
        End Property

        Private m_Lots As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property lots As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Lots
            End Get
            Set(value As String)
                m_Lots = value
            End Set
        End Property

        Private m_Iron As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property iron As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Iron
            End Get
            Set(value As String)
                m_Iron = value
            End Set
        End Property

        Private m_Condor As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property condor As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Condor
            End Get
            Set(value As String)
                m_Condor = value
            End Set
        End Property

        Private m_Product As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property product As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Product
            End Get
            Set(value As String)
                m_Product = value
            End Set
        End Property

        Private m_Shares As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property shares As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Shares
            End Get
            Set(value As String)
                m_Shares = value
            End Set
        End Property

        Private m_Category As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property category As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Category
            End Get
            Set(value As String)
                m_Category = value
            End Set
        End Property

        Private m_DateField As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property datefield As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_DateField
            End Get
            Set(value As String)
                m_DateField = value
            End Set
        End Property

        Private m_MonthField As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property monthfield As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_MonthField
            End Get
            Set(value As String)
                m_MonthField = value
            End Set
        End Property

        Private m_YearField As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property yearfield As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_YearField
            End Get
            Set(value As String)
                m_YearField = value
            End Set
        End Property

        Private m_Strikes As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property strikes As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Strikes
            End Get
            Set(value As String)
                m_Strikes = value
            End Set
        End Property

        Private m_Order As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property order As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Order
            End Get
            Set(value As String)
                m_Order = value
            End Set
        End Property

        Private m_Price As String                                                                                                ' SET THE TYPE OF TRANSACTION BASED ON THE INPUT SOLD TO OPEN BOT TO CLOSE.
        Public Property price As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Price
            End Get
            Set(value As String)
                m_Price = value
            End Set
        End Property

        Private m_Exchange As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property exchange As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_Exchange
            End Get
            Set(value As String)
                m_Exchange = value
            End Set
        End Property
        Private m_shortput As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property shortput As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_shortput
            End Get
            Set(value As String)
                m_shortput = value
            End Set
        End Property
        Private m_longput As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property longput As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_longput
            End Get
            Set(value As String)
                m_longput = value
            End Set
        End Property
        Private m_shortcall As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property shortcall As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_shortcall
            End Get
            Set(value As String)
                m_shortcall = value
            End Set
        End Property
        Private m_longcall As String                                                                                                ' SET THE QUANTITY OF CONTRACTS OF TRANSACTION BASED ON THE INPUT.
        Public Property longcall As String                                                                                          ' SETS THE DATASTRUCTURE OF THE FIELD.
            Get
                Return m_longcall
            End Get
            Set(value As String)
                m_longcall = value
            End Set
        End Property
    End Class

    Public NotInheritable Class YahooFinance
        Private Sub New()
        End Sub

        Public Shared Function Parse(csvData As String) As List(Of Price)
            MsgBox("parse")

            Dim prices As New List(Of Price)()

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)

            For Each row As String In rows
                If String.IsNullOrEmpty(row) Then
                    Continue For
                End If

                Dim cols As String() = row.Split(","c)

                If cols(0) = "Date" Then
                    Continue For
                End If


                Dim p As New Price()
                p.MarketDate = cols(0)
                p.OpenPrice = Convert.ToDecimal(cols(1))
                p.HighPrice = Convert.ToDecimal(cols(2))
                p.LowPrice = Convert.ToDecimal(cols(3))
                p.ClosePrice = Convert.ToDecimal(cols(4))
                p.Volume = Convert.ToDecimal(cols(5))
                p.AdjClosePrice = Convert.ToDecimal(cols(6))

                prices.Add(p)
            Next

            Return prices
        End Function

    End Class



End Class
