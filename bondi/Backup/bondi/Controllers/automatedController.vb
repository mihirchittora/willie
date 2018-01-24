Imports bondi.wavesViewModel

Namespace bondi
    Public Class automatedController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /automated

        Function Index() As ActionResult
            Return View()
        End Function

        Function robot() As ActionResult
            Return View()
        End Function

        <HttpPost> _
        Function backdata(ByVal testdata As String, ByVal robotsymbol As String, ByVal robotwidth As Double, ByVal rowid As Integer) As ActionResult

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
            Dim userid As Guid                                                                                                                                                  ' USERID ADDED TO RECORDS FOR EACH USER
            Dim csvdata As String                                                                                                                                               ' USED TO HOUSE THE TEXT FILE 
            Dim username As String = "csquared20"                                                                                                                               ' USERNAME TO GET USER ID.  ---> WHEN READY FOR PRODUCTION SET TO USER.IDENTITY.NAME (WILL HAVE TO SET TO <AUTHORIZED> _)
            Dim path As String = "C:\Users\Prime\Desktop\stockprices\allstocks_"                                                                                                ' BASE PATH OF THE FILE TO BE READ INTO MEMORY.
            Dim filename As String = "20160104"                                                                                                                                 ' BASE FILENAME FOR TESTING.
            
            Dim direction As String = ""                                                                                                                                        ' INDICATOR OF THE INTERVAL GOING UP OR DOWN - OPEN TO CLOSE.

            Dim markettime As New DateTime
            Dim interval As Integer = 0

            Dim checktime As New DateTime
            checktime = Now().ToShortTimeString



            Dim datastring As String = ""

            ' **********  OPEN THE DATABASE **********
            Using db As New wavesDataContext                                                                                                                                    ' OPEN THE DATA CONTEXT FOR THE DATABASE.

                userid = db.GetUserIdForUserName(username)                                                                                                                      ' GET THE USERID FROM USERNAME. (THIS WILL HAVE TO BE EDITED WHEN SECURITY IS INSTALLED.)

                Using textReader As New System.IO.StreamReader(path & filename & "\table_" & "vxx.csv")                                                                         ' TEXT READER PULLS AND READS THE FILE.
                    csvdata = textReader.ReadToEnd                                                                                                                              ' LOAD THE ENTIRE FILE INTO THE STRING.
                End Using                                                                                                                                                       ' CLOSE THE TEXT READER.

                Dim backprices As List(Of backPrice) = ParseBackData(csvdata)                                                                                                   ' CALL THE FUNCTION TO PARSE THE DATA INTO ROWS AND RETURN OPEN MARKET HOURS.

                For Each price As backPrice In backprices                                                                                                                       ' LOOP THROUGH EACH ROW OF THE PRICES FOR THE DATE SELECTED.

                    ' WHEN USING TEXT FILE UNCOMMENT - LIVE COMMENT THIS IF THEN OUT.   Check interval against the rowid  ********************************************
                    If interval = rowid Then

                        markettime = price.MarketDate
                        markettime = markettime.Subtract(New TimeSpan(0, 60, 0))

                        datastring = String.Format("{0:t}", markettime)

                        direction = checkdirection(price.OpenPrice, price.HighPrice, price.LowPrice, price.ClosePrice)                                                          ' CALL FUNCTION TO CHECK DIRECTION AND RETURN THE INDICATOR.

                        datastring = datastring + " : " + direction

                        datastring = datastring + ": Open: " + (String.Format("{0:C}", price.OpenPrice)) + "  High: " + (String.Format("{0:C}", price.HighPrice)) + "  Low: " + (String.Format("{0:C}", price.LowPrice)) + "  Close: " + (String.Format("{0:C}", price.ClosePrice)) + "          "
                        If direction = "U" Then
                            If price.LowPrice < price.OpenPrice - 0.24 Then
                                datastring = datastring + "-- LOW TO OPEN "
                            End If
                            If price.HighPrice > price.OpenPrice + 0.24 Then
                                datastring = datastring + "-- HIGH TO OPEN "
                            End If
                            If price.ClosePrice < price.HighPrice - 0.24 Then
                                datastring = datastring + "-- CLOSE TO HIGH "
                            End If
                        Else
                            If price.HighPrice > price.OpenPrice + 0.24 Then
                                datastring = datastring + "-- HIGH TO OPEN "
                            End If
                            If price.LowPrice < price.OpenPrice - 0.24 Then
                                datastring = datastring + "-- LOW TO OPEN "
                            End If
                            If price.ClosePrice > price.LowPrice + 0.24 Then
                                datastring = datastring + "-- CLOSE TO LOW "
                            End If
                        End If


                    End If
                    ' Increase the interval to find the time based on interval --> Comment it out when live.
                    interval = interval + 1
                Next

            End Using                                                                                                                                                           ' CLOSE THE DATACONTEXT FOR THE DATABASE.

            'datastring = "end"

            Return Content(datastring)

        End Function

        Private Function ParseBackData(csvData As String) As List(Of backPrice)                                                                                                 ' THIS FUNCTION PARSES OUT THE CSV DATA INTO FIELDS THAT CAN BE READ, PROCESSED AND RECORDED IN THE DATABASE TABLES.
            Dim rowcntr As String = 1
            Dim backprices As New List(Of backPrice)()
            Dim marketdatetime As DateTime
            Dim marketdate As String

            Dim rows As String() = csvData.Replace(vbCr, "").Split(ControlChars.Lf)

            For Each row As String In rows

                If String.IsNullOrEmpty(row) Then
                    Continue For
                End If

                Dim cols As String() = row.Split(","c)

                If cols(0) = "Date" Then
                    Continue For
                End If

                Dim p As New backPrice()
                p.MarketDate = cols(0)
                p.MarketTime = cols(1)
                p.OpenPrice = Convert.ToDecimal(cols(2))
                p.HighPrice = Convert.ToDecimal(cols(3))
                p.LowPrice = Convert.ToDecimal(cols(4))
                p.ClosePrice = Convert.ToDecimal(cols(5))
                p.Volume = Convert.ToDecimal(cols(6))

                marketdate = DateTime.Parse(Left(Right(p.MarketDate, 4), 2) & "/" & Right(p.MarketDate, 2) & "/" & Left(p.MarketDate, 4))
                marketdatetime = getdatetime(marketdate, p.MarketTime)
                p.MarketDate = marketdatetime

                ' ONLY ADD ROWS WHERE THE MARKET IS OPEN.
                If marketdatetime.ToShortTimeString() > #9:29:00 AM# Then
                    If marketdatetime.ToShortTimeString() < #4:01:00 PM# Then
                        backprices.Add(p)
                    End If
                End If

                rowcntr = rowcntr + 1

            Next

            Return backprices
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

        Function checkdirection(ByVal openprice As Double, ByVal highprice As Double, ByVal lowprice As Double, ByVal closeprice As Double) As String
            Dim direction As String = ""                                                                                                                                        ' CLEAR THE DIRECTION VARIABLE TO START THE FUNCTION.
            If closeprice > openprice Then                                                                                                                                      ' IF CLOSE PRICE GREATER THAN OPEN PRICE THEN OVERALL DIRECTION OF INTERVAL IS UP.
                direction = "U"                                                                                                                                                 ' SET DIRECTION VARIABLE TO UP LOWER.            
            Else
                direction = "D"                                                                                                                                                 ' SET THE DIRECTION VARIABLE TO LOW HIGHER.            
            End If

            Return direction                                                                                                                                                    ' RETURN THE DIRECTION VARIABLE WITH ITS SET VALUE.
        End Function
    End Class
End Namespace
