Imports Microsoft.VisualBasic
Imports Microsoft.Win32

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
        If currentChar = "a" Then
            takeIt()
            If currentChar = "a" Then
                takeIt()
                If currentChar >= "0" AndAlso currentChar <= "9" Then
                    takeIt()
                    Return cToken.IDENTIFIER
                ElseIf currentChar = "<" Or currentChar = ">" Or currentChar = "=" Or currentChar = "!" Then
                    takeIt()
                    Return cToken.CONDITION
                End If
            End If
        ElseIf currentChar >= "0" AndAlso currentChar <= "3" Then
            takeIt()
            While currentChar >= "0" AndAlso currentChar <= "3"
                takeIt()
                If currentIndex >= frmMyCompiler.txtProgram.Text.Length Then Exit While
            End While
            Return cToken.NUMBER
        ElseIf currentChar = "@" Then
            takeIt()
            If currentChar = "i" Then
                takeIt()
                Return cToken.STATEMENT
            ElseIf currentChar = "b" Then
                takeIt()
                Return cToken.BEGINTOKEN
            ElseIf currentChar = "f" Then
                takeIt()
                Return cToken.FUNCTIONTOKEN
            ElseIf currentChar = "e" Then
                takeIt()
                Return cToken.ENDTOKEN
            ElseIf currentChar = "8" Then
                takeIt()
                If currentChar = "0" Then
                    takeIt()
                    If currentChar = "0" Then
                        takeIt()
                        If currentChar = "@" Then
                            takeIt()
                            Return cToken.PROGRAM
                        End If
                    End If
                End If
            End If
        ElseIf currentChar = "n" Then
            takeIt()
            If currentChar = "u" Then
                takeIt()
                If currentChar = "m" Then
                    takeIt()
                    Return cToken.TYPE
                End If
            End If
        ElseIf currentChar = "c" Then
            takeIt()
            If currentChar = "h" Then
                takeIt()
                If currentChar = "a" Then
                    takeIt()
                    If currentChar = "r" Then
                        takeIt()
                        Return cToken.TYPE
                    End If
                End If
            End If
        ElseIf currentChar = "(" Then
            takeIt()
            Return cToken.LEFTPAREN
        ElseIf currentChar = ")" Then
            takeIt()
            Return cToken.RIGHTPAREN
        ElseIf currentChar = "{" Then
            takeIt()
            Return cToken.OPENBRACE
        ElseIf currentChar = "}" Then
            takeIt()
            Return cToken.CLOSEBRACE
        ElseIf currentChar = "*" Then
            takeIt()
            Return cToken.MULTIPY
        ElseIf currentChar = "+" Then
            takeIt()
            Return cToken.ADDITION
        ElseIf currentChar = "=" Then
            takeIt()
            Return cToken.ASSIGNMENT
        ElseIf currentChar = "." Then
            takeIt()
            Return cToken.PERIOD
        ElseIf currentChar = "," Then
            takeIt()
            Return cToken.COMMA
        Else
            Return cToken.UNKNOWN
        End If
    End Function

End Class