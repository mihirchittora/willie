Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class OrderStatusMessage
    Private m_orderId As String
    Private m_status As String
    Private m_filled As Double
    Private m_price As Double
    Private m_remaining As Double
    Private m_avgFillPrice As Double
    Private m_permId As Integer
    Private m_parentId As Integer
    Private m_lastFillPrice As Double
    Private m_clientId As Integer
    Private m_whyHeld As String

    Public Sub New(orderId As Integer, status As String, filled As Double, price As Double, remaining As Double, avgFillPrice As Double, permId As Integer,
            parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String)
        m_orderId = orderId
        m_status = status
        m_filled = filled
        m_price = price
        m_remaining = remaining
        m_avgFillPrice = avgFillPrice
        m_permId = permId
        m_parentId = parentId
        m_lastFillPrice = lastFillPrice
        m_clientId = clientId
        m_whyHeld = whyHeld
    End Sub

    Public Property Status() As String
        Get
            Return m_status
        End Get
        Set(value As String)
            m_status = value
        End Set
    End Property
    Public Property OrderID() As String
        Get
            Return m_orderId
        End Get
        Set(value As String)
            m_orderId = Value
        End Set
    End Property

    Public Property Filled() As Double
        Get
            Return m_filled
        End Get
        Set(value As Double)
            m_filled = value
        End Set
    End Property

    Public Property Price() As Double
        Get
            Return m_price
        End Get
        Set(value As Double)
            m_price = value
        End Set
    End Property

    Public Property Remaining() As Double
        Get
            Return m_remaining
        End Get
        Set(value As Double)
            m_remaining = value
        End Set
    End Property

    Public Property AvgFillPrice() As Double
        Get
            Return m_avgFillPrice
        End Get
        Set(value As Double)
            m_avgFillPrice = value
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

    Public Property ParentId() As Integer
        Get
            Return m_parentId
        End Get
        Set(value As Integer)
            m_parentId = value
        End Set
    End Property

    Public Property LastFillPrice() As Double
        Get
            Return m_lastFillPrice
        End Get
        Set(value As Double)
            m_lastFillPrice = value
        End Set
    End Property

    Public Property ClientId() As Integer
        Get
            Return m_clientId
        End Get
        Set(value As Integer)
            m_clientId = Value
        End Set
    End Property

    Public Property WhyHeld() As String
        Get
            Return m_whyHeld
        End Get
        Set(value As String)
            m_whyHeld = value
        End Set
    End Property

End Class
