Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class OpenOrders
    Private m_symbol As String
    Private m_permId As Integer    
    Private m_lmtprice As Double
    Private m_oaction As String
    Private m_sectype As String
    Private m_status As String
    Private m_oid As Integer
    Private m_check As Boolean

    Sub New(symbol As String, permid As Integer, lmtprice As Double, oaction As String, sectype As String, status As String, oid As Integer)
        m_permId = permid
        m_symbol = symbol
        m_lmtprice = lmtprice
        m_oaction = oaction
        m_sectype = sectype
        m_status = status
        m_oid = oid
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

    Public Property Check() As Boolean
        Get
            Return m_check
        End Get
        Set(value As Boolean)
            m_check = value
        End Set
    End Property

End Class
Public Class OrderIds
    Private m_orderId As Integer

    Sub New(orderid As Integer)
        m_orderId = orderid        
    End Sub

    Public Property OrderId() As Integer
        Get
            Return m_orderId
        End Get
        Set(value As Integer)
            m_orderId = value
        End Set
    End Property


End Class