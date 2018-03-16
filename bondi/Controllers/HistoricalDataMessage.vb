Imports System.Collections.Generic
Imports System.Linq
Imports System.Text


Public Class HistoricalDataMessage
    Protected m_requestId As Integer
    Protected m_date As String
    Protected m_open As Double
    Protected m_high As Double
    Protected m_low As Double
    Protected m_close As Double
    Protected m_volume As Integer

    Public Property RequestId() As Integer
        Get
            Return m_requestId
        End Get
        Set
            m_requestId = Value
        End Set
    End Property

    Public Property [Date]() As String
        Get
            Return m_date
        End Get
        Set
            m_date = Value
        End Set
    End Property

    Public Property Open() As Double
        Get
            Return m_open
        End Get
        Set
            m_open = Value
        End Set
    End Property


    Public Property High() As Double
        Get
            Return m_high
        End Get
        Set
            m_high = Value
        End Set
    End Property

    Public Property Low() As Double
        Get
            Return m_low
        End Get
        Set
            m_low = Value
        End Set
    End Property

    Public Property Close() As Double
        Get
            Return m_close
        End Get
        Set
            m_close = Value
        End Set
    End Property

    Public Property Volume() As Integer
        Get
            Return m_volume
        End Get
        Set
            m_volume = Value
        End Set
    End Property



    Public Sub New(reqId As Integer, _date As String, open As Double, high As Double, low As Double, close As Double,
            volume As Integer, count As Integer)
        RequestId = reqId
        [Date] = _date
        m_open = open
        m_high = high
        m_low = low
        m_close = close
        m_volume = volume
    End Sub
    Public Sub New()

    End Sub
End Class

