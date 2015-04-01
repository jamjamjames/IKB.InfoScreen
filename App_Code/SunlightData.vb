Imports Microsoft.VisualBasic
Imports System.Data

Public Class SunlightData

    Public Enum ChartTypeEnum
        Today
        Yesterday
        CurrentMonth
        LastMonth
        CurrentYear
        LastYear
        SinceBuild
    End Enum

    Private _con As SqlClient.SqlConnection = Nothing

    Private _from As DateTime
    Public Property FromDateTime() As DateTime
        Get
            Return _from
        End Get
        Set(ByVal value As DateTime)
            _from = value
        End Set
    End Property

    Private _to As DateTime
    Public Property ToDateTime() As DateTime
        Get
            Return _to
        End Get
        Set(ByVal value As DateTime)
            _to = value
        End Set
    End Property

    Private _park As Integer
    Public Property ParkID() As Integer
        Get
            Return _park
        End Get
        Set(ByVal value As Integer)
            _park = value
        End Set
    End Property

    Private _charttype As ChartTypeEnum
    Public Property ChartType() As ChartTypeEnum
        Get
            Return _charttype
        End Get
        Set(ByVal value As ChartTypeEnum)
            _charttype = value
        End Set
    End Property

    Public Sub New()
        _con = New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString"))
        _con.Open()
    End Sub

    Public Function LoadDayBased(fromDateTime As DateTime, toDateTime As DateTime) As DataSet

        Dim sb As New StringBuilder()
        sb.AppendLine(" SELECT pv_date, sum(pv_ertrag) as pv_ertrag ")
        sb.AppendLine(" FROM tagessummen ")
        sb.AppendLine(" WHERE pv_date>= @from  and pv_date<=@to ")
        sb.AppendLine(" GROUP BY pv_date ORDER BY pv_date ")

        Dim com As New SqlClient.SqlCommand(sb.ToString, _con)
        com.Parameters.Add("@from", SqlDbType.DateTime)
        com.Parameters("@from").Value = fromDateTime
        com.Parameters.Add("@to", SqlDbType.DateTime)
        com.Parameters("@to").Value = toDateTime

        Dim adapter As New SqlClient.SqlDataAdapter(com)
        Dim ds As New DataSet()
        adapter.Fill(ds)

        Return ds
    End Function
End Class