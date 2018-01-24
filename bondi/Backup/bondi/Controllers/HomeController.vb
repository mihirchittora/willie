Imports System.Globalization
Imports System.Data.Linq

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ' **********************************************************************************************************************************************************
        ' Function:         Front End Landing Page
        ' Written By:       Troy Belden
        ' Date Written:     October, 26 2016
        ' Last Updated:     October, 26 2016
        ' Details:          This function displays the landing page. It pulls blog entries to be displayed, a call to action, and details the general premise of  
        '                   the site.  
        '                   
        ' **********************************************************************************************************************************************************


        'Return RedirectToAction("automate", "member")
        Return RedirectToAction("index", "member")


        ' Establish link to data tables.
        'Using db As New wavesDataContext

        ' Section: Get trending blog entries
        ' Get top three trending blog article short names and index to pass to the top bar of the landing page.  The code pulls the last three blog entries loops through
        ' a counter and assigns the Title to the variable datafield for display on the page.

        'Dim model As New wavesViewModel With { _
        '                                        .AllBlogs = db.GetXPosts(3) _
        '                                      }


        'Dim loopcntr As Integer = 1
        'For Each item In model.AllBlogs
        '    If loopcntr = 1 Then
        '        ViewData("article1") = item.Name.ToString()
        '        Dim testme As Integer = item.id
        '    ElseIf loopcntr = 2 Then
        '        ViewData("article2") = item.Name.ToString()
        '    Else
        '        ViewData("article3") = item.Name.ToString()
        '    End If
        '    loopcntr = loopcntr + 1
        'Next
        'loopcntr = 0

        ' '' Section: Get Total Wins  
        ' '' Get total number of winning trades and total closed trades for the current month to display in the top-bar of the landing page.

        'Dim cmw = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) And c.winFLAG = True Select c.tradeID
        'Dim cmt = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) Select c.tradeID

        'Dim cmWins = cmw.Count()
        'Dim CMtot = cmt.Count()

        'ViewData("curMonthNum") = CMtot
        'ViewData("curMonthWinPct") = (cmWins / CMtot.ToString())



        'End Using


        Return View()
    End Function

    Function blog(ByVal article As Integer) As ActionResult

        ' **********************************************************************************************************************************************************
        ' Function:         Single Blog Page
        ' Written By:       Troy Belden
        ' Date Written:     October, 27 2016
        ' Last Updated:     October, 27 2016
        ' Details:          This function displays the selected single blog page. 
        '                   
        '                   
        ' **********************************************************************************************************************************************************

        ' Define variables used in the function.
        Dim alookup As Integer = 0

        ' MsgBox(article.ToString())


        ' Establish link to data tables.
        Using db As New wavesDataContext

            ' Section: Get trending blog entries
            ' Get top three trending blog article short names and index to pass to the top bar of the landing page.  The code pulls the last three blog entries loops through
            ' a counter and assigns the Title to the variable datafield for display on the page.

            Dim artID As Integer
            Dim cntr As Integer = 1
            Dim lastXblogs = db.GetXPosts(3)

            For Each item In lastXblogs

                If cntr = article Then
                    artID = item.id
                End If
                cntr = cntr + 1
            Next

            Dim model As New wavesViewModel With { _
                                                    .AllBlogs = db.GetXPosts(3), _
                                                    .postSelected = db.GetPost(artID) _
                                                  }

            Dim loopcntr As Integer = 1
            For Each item In model.AllBlogs
                If loopcntr = 1 Then                    
                    ViewData("article1") = item.Name.ToString()
                ElseIf loopcntr = 2 Then
                    If loopcntr = article Then                        
                        End If
                    ViewData("article2") = item.Name.ToString()
                Else
                    If loopcntr = article Then                        
                        End If
                    ViewData("article3") = item.Name.ToString()
                    End If
                loopcntr = loopcntr + 1
            Next
            loopcntr = 0

                ' Section: Get Total Wins  
                ' Get total number of winning trades and total closed trades for the current month to display in the top-bar of the landing page.

            Dim cmw = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) And c.winFLAG = True Select c.tradeID
            Dim cmt = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) Select c.tradeID

            Dim cmWins = cmw.Count()
            Dim CMtot = cmt.Count()

            ViewData("curMonthNum") = CMtot
            ViewData("curMonthWinPct") = (cmWins / CMtot.ToString())

                ' End Section: Get Total Wins
            Return View(model)
        End Using



        ' Return View()
    End Function

    Function About() As ActionResult
        Return View()
    End Function
End Class
