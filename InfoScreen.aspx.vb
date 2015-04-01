Partial Class InfoScreen
    Inherits System.Web.UI.Page

    Public Property CurrentScreen() As Integer
        Get
            If Session("ikbCurrentScreenId") Is Nothing Then
                Session("ikbCurrentScreenId") = 0
                Return Session("ikbCurrentScreenId")
            Else
                Return Session("ikbCurrentScreenId")
            End If
        End Get
        Set(ByVal value As Integer)
            Session("ikbCurrentScreenId") = value
        End Set
    End Property

    Public Property LastImages() As List(Of Integer)
        Get
            If Session("ikbLastImageList") Is Nothing Then
                Session("ikbLastImageList") = New List(Of Integer)
                Return Session("ikbLastImageList")
            Else
                Return Session("ikbLastImageList")
            End If
        End Get
        Set(ByVal value As List(Of Integer))
            Session("ikbLastImageList") = value
        End Set
    End Property

    'Protected Sub aspTimer_Tick(sender As Object, e As EventArgs) Handles aspTimer.Tick        
    '    LoadScreen(CurrentScreen)
    '    CurrentScreen += 1
    'End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            'divContentContainer.Attributes.Add("style", "width: 100%; height: 100%;")
        End If
        LoadChart(Date.Now.AddDays(-1), Date.Now.AddDays(-1))
    End Sub

    'Private Sub LoadScreen(screenId As Integer)
    '    Select Case screenId

    '        Case 0
    '            ' data from every park
    '            LoadChart(Date.Now, Date.Now)

    '        Case 1
    '            ' display image   
    '            LoadImage()
    '        Case 2
    '            ' data from every park

    '        Case 3
    '            ' data from every park
    '            LoadImage()

    '        Case 4
    '            ' data from every park
    '            LoadImage()

    '        Case Else
    '            ' data from every park
    '            LoadImage()
    '            CurrentScreen = 0

    '    End Select

    'End Sub

    Private Sub LoadChart(fromDateTime As DateTime, toDateTime As DateTime)
        'divContentContainer.Controls.Clear()
        PrepareChartControl()

        Dim c As New SunlightData()
        Dim ds = c.LoadDayBased(fromDateTime, toDateTime)       

        chrtSunlight.Width = 1920
        chrtSunlight.Height = 1080

        Dim v = ds.Tables(0).Rows.Count

        chrtSunlight.Series("Series1").XValueMember = Convert.ToString(ds.Tables(0).Columns(0))
        chrtSunlight.Series("Series1").YValueMembers = Convert.ToString(ds.Tables(0).Columns(1))

        chrtSunlight.Visible = True

        chrtSunlight.DataSource = ds
        chrtSunlight.DataBind()
    End Sub

    'Private Sub LoadImage()
    '    divContentContainer.Controls.Clear()
    '    Dim img As New Image()
    '    img.ImageUrl = "~/Handler/ImageHandler.ashx"
    '    img.Attributes.Add("style", "width: 100%; height: 100%;")
    '    divContentContainer.Controls.Add(img)
    'End Sub

    Private Sub PrepareChartControl()
        chrtSunlight.Attributes.Add("style", "width: 100%; height: 100%;")


    End Sub



End Class
