Imports System.Text.RegularExpressions

Public Class HostEntry
    Private m_Ipaddress As String
    Private m_Names As List(Of String)

    Public Sub New()
        m_Names = New List(Of String)
    End Sub

    Public Property IpAddress() As String
        Get
            Return m_Ipaddress

        End Get
        Set(ByVal value As String)
            m_Ipaddress = value
        End Set
    End Property

    Public ReadOnly Property Names As List(Of String)
        Get
            Return m_Names
        End Get
    End Property

    Public Shared Function GetFromLine(ByVal line As String) As HostEntry
        Dim matches As String()
        Dim regex As New Regex("\s+")
        matches = regex.Split(line)

        Dim result As New HostEntry()
        result.IpAddress = matches(0)

        For i = 1 To matches.Length - 1
            result.Names.Add(matches(i))
        Next

        Return result
    End Function

    Public Overrides Function ToString() As String
        Dim n As String = ""
        For Each name In m_Names
            n += name + " "
        Next
        Return m_Ipaddress + " " + n
    End Function

End Class
