Imports System.Threading
Imports System.Collections.Generic
Imports System.Net
Imports bondi.wavesViewModel
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Text
Imports System

Namespace bondi
    Public Class gardenController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /garden

        Function Index() As ActionResult
            Return View()
        End Function

        Function addposition(ByVal tradedate As Date, ByVal tradedata As String) As ActionResult

            ' MsgBox(tradedate.ToString() & tradedata.ToString())


            Dim tradedater As List(Of TradeData) = ParseTradeData(tradedata)                                                                                                   ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.







            Return RedirectToAction("index", "garden")
        End Function

        Private Function ParseTradeData(trade As String) As List(Of TradeData)

            'SOLD -1 IRON CONDOR SPX 100 (Weeklys) 3 FEB 17 2320/2330/2150/2140 CALL/PUT @1.20

            'SOLD -1 IRON CONDOR SPX 100 (Weeklys) 2 DEC 16 2225/2245/2130/2110 CALL/PUT @1.90 CBOE
            ' BOT +1 IRON CONDOR SPX 100 (Weeklys) 2 DEC 16 2225/2245/2130/2110 CALL/PUT @1.25 CBOE
            Dim rowcntr As String = 1
            Dim tradedata As New List(Of TradeData)()
            
            Dim rows As String() = trade.Replace(vbCr, "").Split(ControlChars.Lf)

            For Each row As String In rows

                If String.IsNullOrEmpty(row) Then
                    Continue For
                End If

                Dim cols As String() = row.Split(" "c)
                ' MsgBox(cols.Count())
                If cols(0) = "Date" Then
                    Continue For
                End If

                'For x = 0 To cols.Count() - 1
                '    MsgBox(x & " : " & cols(x))
                'Next


                Dim p As New TradeData()
                p.type = cols(0)
                p.lots = cols(1)
                p.iron = cols(2)
                p.condor = cols(3)
                p.product = cols(4)

                p.shares = cols(5)
                p.category = cols(6)
                p.datefield = cols(7)
                p.monthfield = cols(8)
                p.yearfield = cols(9)
                p.strikes = cols(10)

                'If p.type = "SOLD" Then
                Dim strikeprices As String() = p.strikes.Split("/"c)
                p.shortcall = strikeprices(0)
                p.longcall = strikeprices(1)
                p.shortput = strikeprices(2)
                p.longput = strikeprices(3)

                'ElseIf p.type = "BOT" Then
                'Dim strikeprices As String = cols(10)
                'End If

                p.order = cols(11)
                Dim minusat = Mid(cols(12), 2)
                p.price = Convert.ToDecimal(minusat)
                If cols.Count = 14 Then
                    p.exchange = cols(13)
                End If

                tradedata.Add(p)

            Next

            Return tradedata
        End Function



    End Class

End Namespace
