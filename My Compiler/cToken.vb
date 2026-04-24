Public Class cToken
    Public kind As Integer
    Public spelling As String = ""
    Public Sub New(ByVal kind As Integer, ByVal spelling As String)
        Me.kind = kind
        Me.spelling = spelling
    End Sub

    Public Function ToString() As String
        If kind = 0 Then
            Return "UNKNOWN: " & spelling
        ElseIf kind = 1 Then
            Return "EOF: " & spelling
        ElseIf kind = 2 Then
            Return "IDENTIFIER: " & spelling
        ElseIf kind = 3 Then
            Return "INTEGERTYPE: " & spelling
        Else
            Return "OPERATORTYPE: " & spelling
        End If
    End Function

    Public Shared UNKNOWN As Integer = 0
    Public Shared EOF As Integer = 1
    Public Shared IDENTIFIER As Integer = 2
    Public Shared INTEGERTYPE As Integer = 3
    Public Shared OPERATORTYPE As Integer = 4
    Public Shared MNEMONIC As Integer = 5
End Class