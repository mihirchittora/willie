Public Class robot
    Public Class interval
        Private m_time As String
        Public Property iTime As String
            Get
                Return m_time
            End Get
            Set(value As String)
                m_time = value
            End Set
        End Property
        Private m_interval As Integer
        Public Property Interval As Integer
            Get
                Return m_interval
            End Get
            Set(value As Integer)
                m_interval = value
            End Set
        End Property
    End Class
End Class
