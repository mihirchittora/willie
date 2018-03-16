Imports System.Threading
Imports bondi.Tws
Module Willie
    Public nextOrderId As Integer
    Dim Tws1 As Tws = New Tws()
    Dim connected As String



    ' CALLED PROCESSES TO INTERACT WITH THE TWS API
    Public Function TWSconnect() As String

        Call Tws1.connect("", 7497, 0, False)                                                                                                           ' CALL THE CONNECT FUNCTION FOR THE API PASSING THE CONNECTION STRING 
        Tws1.msgProcessing()                                                                                                                            ' CALL THE TWS PROCESSING FUNCTION TO WORK THROUGH THE API INTERACTION TO CONNECT
        If (Tws1.serverVersion() > 0) Then                                                                                                              ' CHECK TO DETERMINE IF CONNECTED
            connected = "Online"                                                                                                                        ' RETURN ONLINE IF CONNECTED TO TWS 
        Else
            connected = "Off-line"                                                                                                                      ' RETURN OFFLINE IF NOT CONNECTED TO TWS
        End If

        Return connected                                                                                                                                ' RETURN THE VALUE OF CONNECTED                 
    End Function

End Module
