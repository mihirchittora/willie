Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Web.Routing

Public Class AccountController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Account/LogOn

    Public Function LogOn() As ActionResult

        ' **********************************************************************************************************************************************************
        ' Function:         LogOn Page
        ' Written By:       Troy Belden
        ' Date Written:     October, 31 2016
        ' Last Updated:     October, 31 2016
        ' Details:          This function displays the logOn page. It allows a registered user to log on the system. If the user is not registered there is a register  
        '                   action as well.
        '                   
        ' **********************************************************************************************************************************************************

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

        ' Section: Get Total Wins  
        ' Get total number of winning trades and total closed trades for the current month to display in the top-bar of the landing page.

        '    Dim cmw = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) And c.winFLAG = True Select c.tradeID
        '    Dim cmt = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) Select c.tradeID

        '    Dim cmWins = cmw.Count()
        '    Dim CMtot = cmt.Count()

        '    ViewData("curMonthNum") = CMtot
        '    ViewData("curMonthWinPct") = (cmWins / CMtot.ToString())

        '    ' End Section: Get Total Wins

        'End Using

        Return View()
    End Function

    '
    ' POST: /Account/LogOn

    <HttpPost()> _
    Public Function LogOn(ByVal model As LogOnModel, ByVal returnUrl As String) As ActionResult

        If ModelState.IsValid Then
            If Membership.ValidateUser(model.UserName, model.Password) Then
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe)
                If Url.IsLocalUrl(returnUrl) AndAlso returnUrl.Length > 1 AndAlso returnUrl.StartsWith("/") _
                   AndAlso Not returnUrl.StartsWith("//") AndAlso Not returnUrl.StartsWith("/\\") Then
                    Return Redirect(returnUrl)
                Else
                    Return RedirectToAction("Index", "member")
                End If
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/LogOff

    Public Function LogOff() As ActionResult
        FormsAuthentication.SignOut()

        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/Register

    Public Function Register() As ActionResult

        ' **********************************************************************************************************************************************************
        ' Function:         Register Page
        ' Written By:       Troy Belden
        ' Date Written:     October, 31 2016
        ' Last Updated:     October, 31 2016
        ' Details:          This function displays the register page. It allows a user to register into the system.   
        '                   
        '                   
        ' **********************************************************************************************************************************************************

        ' Establish link to data tables.
        'Using db As New wavesDataContext

        '    ' Section: Get trending blog entries
        '    ' Get top three trending blog article short names and index to pass to the top bar of the landing page.  The code pulls the last three blog entries loops through
        '    ' a counter and assigns the Title to the variable datafield for display on the page.

        '    Dim model As New wavesViewModel With { _
        '                                            .AllBlogs = db.GetXPosts(3) _
        '                                          }

        '    Dim loopcntr As Integer = 1
        '    For Each item In model.AllBlogs
        '        If loopcntr = 1 Then
        '            ViewData("article1") = item.Name.ToString()
        '            Dim testme As Integer = item.id
        '        ElseIf loopcntr = 2 Then
        '            ViewData("article2") = item.Name.ToString()
        '        Else
        '            ViewData("article3") = item.Name.ToString()
        '        End If
        '        loopcntr = loopcntr + 1
        '    Next
        '    loopcntr = 0

        '    ' Section: Get Total Wins  
        '    ' Get total number of winning trades and total closed trades for the current month to display in the top-bar of the landing page.

        '    Dim cmw = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) And c.winFLAG = True Select c.tradeID
        '    Dim cmt = From c In db.TradeDetails Where c.open = False And c.closeDATE.Year = Year(Now()) And c.closeDATE.Month = Month(Now()) Select c.tradeID

        '    Dim cmWins = cmw.Count()
        '    Dim CMtot = cmt.Count()

        '    ViewData("curMonthNum") = CMtot
        '    ViewData("curMonthWinPct") = (cmWins / CMtot.ToString())

        '    ' End Section: Get Total Wins

        'End Using

        Return View()
    End Function

    '
    ' POST: /Account/Register

    <HttpPost()> _
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        'If ModelState.IsValid Then
        ' Attempt to register the user
        Dim createStatus As MembershipCreateStatus
        Membership.CreateUser(model.UserName, model.Password, Nothing, Nothing, Nothing, True, Nothing, createStatus)

        If createStatus = MembershipCreateStatus.Success Then
            FormsAuthentication.SetAuthCookie(model.UserName, False)
            Return RedirectToAction("Index", "Home")
        Else
            ModelState.AddModelError("", ErrorCodeToString(createStatus))
        End If
        ' End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/ChangePassword

    <Authorize()> _
    Public Function ChangePassword() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Account/ChangePassword

    <Authorize()> _
    <HttpPost()> _
    Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
        If ModelState.IsValid Then
            ' ChangePassword will throw an exception rather
            ' than return false in certain failure scenarios.
            Dim changePasswordSucceeded As Boolean

            Try
                Dim currentUser As MembershipUser = Membership.GetUser(User.Identity.Name, True)
                changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword)
            Catch ex As Exception
                changePasswordSucceeded = False
            End Try

            If changePasswordSucceeded Then
                Return RedirectToAction("ChangePasswordSuccess")
            Else
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/forgotpassword

    Public Function forgotpassword() As ActionResult
        Return View()
    End Function


    '
    ' GET: /Account/ChangePasswordSuccess

    Public Function ChangePasswordSuccess() As ActionResult
        Return View()
    End Function

    '
    ' GET: /Account/profile

    Public Function profile() As ActionResult
        Return View()
    End Function


    ' GET: /Account/settings

    Public Function settings() As ActionResult
        Return View()
    End Function


    ' GET: /Account/billing

    Public Function billing() As ActionResult
        Return View()
    End Function

#Region "Status Code"
    Public Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
        ' See http://go.microsoft.com/fwlink/?LinkID=177550 for
        ' a full list of status codes.
        Select Case createStatus
            Case MembershipCreateStatus.DuplicateUserName
                Return "User name already exists. Please enter a different user name."

            Case MembershipCreateStatus.DuplicateEmail
                Return "A user name for that e-mail address already exists. Please enter a different e-mail address."

            Case MembershipCreateStatus.InvalidPassword
                Return "The password provided is invalid. Please enter a valid password value."

            Case MembershipCreateStatus.InvalidEmail
                Return "The e-mail address provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidAnswer
                Return "The password retrieval answer provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidQuestion
                Return "The password retrieval question provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidUserName
                Return "The user name provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.ProviderError
                Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case MembershipCreateStatus.UserRejected
                Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case Else
                Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
        End Select
    End Function
#End Region

End Class
