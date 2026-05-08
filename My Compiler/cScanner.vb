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
        'If Char.IsLetter(currentChar) Then
        '    takeIt()
        '    state = 2
        '    While Char.IsLetterOrDigit(currentChar)
        '        takeIt()
        '    End While
        'ElseIf Char.IsDigit(currentChar) Then
        '    takeIt()
        '    state = 3
        '    While Char.IsDigit(currentChar)
        '        takeIt()
        '    End While
        'ElseIf "+-*/=".Contains(currentChar) Then
        '    takeIt()
        '    state = 4
        'End If
        If currentChar = "i" Then
            takeIt()
            If currentChar = "d" Then
                takeIt()
                state = 2
            ElseIf currentChar = "f" Then
                takeIt()
                state = 11
            End If
        ElseIf currentChar = "=" Then
            takeIt()
            state = 3
        ElseIf currentChar = ";" Then
            takeIt()
            state = 4
        ElseIf currentChar = "+" Then
            takeIt()
            state = 5
        ElseIf currentChar = "*" Then
            takeIt()
            state = 6
        ElseIf currentChar = "(" Then
            takeIt()
            state = 7
        ElseIf currentChar = ")" Then
            takeIt()
            state = 8
        ElseIf currentChar = "{" Then
            takeIt()
            state = 9
        ElseIf currentChar = "}" Then
            takeIt()
            state = 10
        ElseIf currentChar = "e" Then
            takeIt()
            takeIt()
            takeIt()
            takeIt()
            state = 12
        ElseIf currentChar = "0" Or currentChar = "1" Then
            takeIt()
            state = 13
        End If
        Select Case state
            Case 2
                Return cToken.IDENTIFIER
                'Case 3
                '    Return cToken.INTEGERTYPE
                'Case 4
                '    Return cToken.OPERATORTYPE
            Case 3
                Return cToken.ASSIGNMENT
            Case 4
                Return cToken.SEMICOLON
            Case 5
                Return cToken.Plus
            Case 6
                Return cToken.Multiply
            Case 7
                Return cToken.LeftPara
            Case 8
                Return cToken.RightPara
            Case 9
                Return cToken.OPENBRACES
            Case 10
                Return cToken.CLOSEBRACES
            Case 11
                Return cToken.IFTOKEN
            Case 12
                Return cToken.ELSETOKEN
            Case 13
                Return cToken.EXPRESSION
            Case Else
                Return cToken.UNKNOWN
        End Select
    End Function

End Class