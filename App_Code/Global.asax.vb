Imports Microsoft.VisualBasic

Public Class [Global]
    Inherits System.Web.HttpApplication
    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub

    Private Sub Application_Start(sender As Object, e As EventArgs)
        ' Code that runs on application startup
    End Sub

    Private Sub Application_End(sender As Object, e As EventArgs)
        '  Code that runs on application shutdown
    End Sub

    Private Sub Application_Error(sender As Object, e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Private Sub Session_Start(sender As Object, e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Private Sub Session_End(sender As Object, e As EventArgs)
        ' Code that runs when a session ends.
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer
        ' or SQLServer, the event is not raised.        
    End Sub
End Class