Imports Microsoft.VisualBasic

Public Class cScanner
    Private currentChar As Char = frmMyCompiler.txtProgram.Text(0)
    Private currentSpelling As String
    Private currentIndex As Integer = 0
    Private currentKind As Integer
    Private Sub takeIt()
        currentSpelling &= currentChar
        currentIndex += 1
        If currentIndex < frmMyCompiler.txtProgram.Text.Length Then
            currentChar = frmMyCompiler.txtProgram.Text(currentIndex)
        Else
            currentChar = ""
        End If
    End Sub
    Public Function scan() As cToken
        While Char.IsWhiteSpace(currentChar)
            takeIt()
        End While
        currentSpelling = ""
        currentKind = scanToken()
        Return New cToken(currentKind, currentSpelling)
    End Function
    Private Function scanToken() As Integer
        Dim state As Integer = 1
        If currentIndex = frmMyCompiler.txtProgram.Text.Length Then
            Return cToken.EOF
        End If
        If Char.IsLetter(currentChar) Then
            takeIt()
            state = 2
            While Char.IsLetterOrDigit(currentChar)
                takeIt()
            End While
        ElseIf Char.IsDigit(currentChar) Then
            takeIt()
            state = 3
            While Char.IsDigit(currentChar)
                takeIt()
            End While
        ElseIf "+-*/=".Contains(currentChar) Then
            takeIt()
            state = 4
        End If
        Select Case state
            Case 2
                Return cToken.IDENTIFIER
            Case 3
                Return cToken.INTEGERTYPE
            Case 4
                Return cToken.OPERATORTYPE
            Case Else
                Return cToken.UNKNOWN
        End Select
    End Function

    Private Function isMnemonic(String s ByVal) As Boolean

    End Function
End Class