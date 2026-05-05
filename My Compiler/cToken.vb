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
            'ElseIf kind = 3 Then
            '    Return "INTEGERTYPE: " & spelling
            'Else
            '    Return "OPERATORTYPE: " & spelling
        ElseIf kind = 3 Then
            Return "ASSIGNMENT: " & spelling
        ElseIf kind = 4 Then
            Return "SEMICOLON: " & spelling
        ElseIf kind = 5 Then
            Return "Plus: " & spelling
        ElseIf kind = 6 Then
            Return "Multiply: " & spelling
        ElseIf kind = 7 Then
            Return "LeftPara: " & spelling
        ElseIf kind = 8 Then
            Return "RightPara: " & spelling
        End If
    End Function

    Public Shared UNKNOWN As Integer = 0
    Public Shared EOF As Integer = 1
    Public Shared IDENTIFIER As Integer = 2
    'Public Shared INTEGERTYPE As Integer = 3
    'Public Shared OPERATORTYPE As Integer = 4
    'Public Shared MNEMONIC As Integer = 5
    Public Shared ASSIGNMENT As Integer = 3
    Public Shared SEMICOLON As Integer = 4
    Public Shared Plus As Integer = 5
    Public Shared Multiply As Integer = 6
    Public Shared LeftPara As Integer = 7
    Public Shared RightPara As Integer = 8
End Class