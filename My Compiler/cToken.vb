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
            Return "CONDITION: " & spelling
        ElseIf kind = 4 Then
            Return "NUMBER: " & spelling
        ElseIf kind = 5 Then
            Return "STATEMENT: " & spelling
        ElseIf kind = 6 Then
            Return "TYPE: " & spelling
        ElseIf kind = 7 Then
            Return "LEFTPAREN: " & spelling
        ElseIf kind = 8 Then
            Return "RIGHTPAREN: " & spelling
        ElseIf kind = 9 Then
            Return "BEGINTOKEN: " & spelling
        ElseIf kind = 10 Then
            Return "FUNCTIONTOKEN: " & spelling
        ElseIf kind = 11 Then
            Return "PROGRAM: " & spelling
        ElseIf kind = 12 Then
            Return "ENDTOKEN: " & spelling
        ElseIf kind = 13 Then
            Return "OPENBRACE: " & spelling
        ElseIf kind = 14 Then
            Return "CLOSEBRACE: " & spelling
        ElseIf kind = 15 Then
            Return "MULTIPY: " & spelling
        ElseIf kind = 16 Then
            Return "ADDITION: " & spelling
        ElseIf kind = 17 Then
            Return "ASSIGNMENT: " & spelling
        ElseIf kind = 18 Then
            Return "PERIOD: " & spelling
        ElseIf kind = 19 Then
            Return "COMMA: " & spelling
        End If

    End Function
    Public Shared UNKNOWN As Integer = 0
    Public Shared EOF As Integer = 1
    Public Shared IDENTIFIER As Integer = 2
    Public Shared CONDITION As Integer = 3
    Public Shared NUMBER As Integer = 4
    Public Shared STATEMENT As Integer = 5
    Public Shared TYPE As Integer = 6
    Public Shared LEFTPAREN As Integer = 7
    Public Shared RIGHTPAREN As Integer = 8
    Public Shared BEGINTOKEN As Integer = 9
    Public Shared FUNCTIONTOKEN As Integer = 10
    Public Shared PROGRAM As Integer = 11
    Public Shared ENDTOKEN As Integer = 12
    Public Shared OPENBRACE As Integer = 13
    Public Shared CLOSEBRACE As Integer = 14
    Public Shared MULTIPY As Integer = 15
    Public Shared ADDITION As Integer = 16
    Public Shared ASSIGNMENT As Integer = 17
    Public Shared PERIOD As Integer = 18
    Public Shared COMMA As Integer = 19

End Class