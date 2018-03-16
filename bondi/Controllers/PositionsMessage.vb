Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports IBApi

Public Class PositionMessage

    Private _account As String

    Private _contract As Contract

    Private _position As Double

    Private _averageCost As Double

    Public Sub New(ByVal account As String, ByVal contract As Contract, ByVal pos As Double, ByVal avgCost As Double)
        _account = account
        _contract = contract
        _position = pos
        _averageCost = avgCost
    End Sub

    Public Property Account As String
        Get
            Return _account
        End Get

        Set(ByVal value As String)
            _account = value
        End Set
    End Property

    Public Property Contract As Contract
        Get
            Return _contract
        End Get

        Set(ByVal value As Contract)
            _contract = value
        End Set
    End Property

    Public Property Position As Double
        Get
            Return _position
        End Get

        Set(ByVal value As Double)
            _position = value
        End Set
    End Property

    Public Property AverageCost As Double
        Get
            Return _averageCost
        End Get

        Set(ByVal value As Double)
            _averageCost = value
        End Set
    End Property
End Class