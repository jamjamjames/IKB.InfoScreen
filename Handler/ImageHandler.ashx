<%@ WebHandler Language="VB" Class="ImageHandler" %>

Imports System
Imports System.Web

Public Class ImageHandler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim di As New System.IO.DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings.Get("ImageRootPath"))
        Dim extensions As New List(Of String)
        extensions.Add("*.jpg")
        extensions.Add("*.png")
        extensions.Add("*.gif")

        Dim imageFiles = GetFilesByExtensions(di, extensions.ToArray())
        Dim rnd As New Random()
        Dim tempIndex = rnd.Next(0, imageFiles.Count - 1)

        Dim imageToDisplay As IO.FileInfo = imageFiles(tempIndex)
        Dim fs As New System.IO.FileStream(imageToDisplay.FullName, IO.FileMode.Open, IO.FileAccess.Read)

        Dim br As New IO.BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()
        
        'Write the file to Reponse
        context.Response.Buffer = True
        context.Response.Charset = ""
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim contenttype As String = "image/" & imageToDisplay.Extension.Replace(".", "")
        context.Response.ContentType = contenttype 
        context.Response.AddHeader("content-disposition", "attachment;filename=" & imageToDisplay.Name)
        context.Response.BinaryWrite(bytes)
        context.Response.Flush()
        context.Response.End()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Private Shared Function GetFilesByExtensions(dir As IO.DirectoryInfo, ParamArray extensions As String()) As IEnumerable(Of IO.FileInfo)
        If extensions Is Nothing Then
            Throw New ArgumentNullException("extensions")
        End If
        Dim files As New List(Of IO.FileInfo)
        For Each extension In extensions
            files.AddRange(dir.GetFiles(extension, IO.SearchOption.AllDirectories))
        Next

        Return files
    End Function

End Class