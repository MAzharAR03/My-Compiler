Imports System.IO
Public Class frmMyCompiler
    Dim nextToken As cToken
    Private Sub txtProgram_TextChanged(sender As Object, e As EventArgs) Handles txtProgram.TextChanged

    End Sub

    Private Sub btnParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParse.Click
        lstResults.Items.Clear()
        syntaxError = False
        scanner = New cScanner
        nextToken = scanner.scan
        parse_program()
        If syntaxError Then
            lstResults.Items.Add("Syntax Error!")
        Else
            lstResults.Items.Add("Syntax Correct!")
        End If
    End Sub

    Private Sub frmMyCompiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub btnLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFile.Click
        Dim FileName As String 'declaring filename to be selected
        Dim sr As StreamReader 'streamreader is used to read text
        Try
            With OpenFileDialog1
                'With statement is used to execute statements using a particular Object, here, OpenFileDialog1
                If .ShowDialog() = DialogResult.OK Then
                    'showDialog method makes the dialog box visible at run time
                    FileName = .FileName
                    sr = New StreamReader(.OpenFile)
                    'using streamreader to read the opened text file
                    txtProgram.Text = sr.ReadToEnd()
                    'displaying text from streamreader in textbox
                End If
            End With
        Catch es As Exception
            MessageBox.Show(es.Message)
        Finally
            If Not (sr Is Nothing) Then
                sr.Close()
            End If
        End Try
    End Sub

    Private Sub acceptToken(ByVal k As Integer)
        If nextToken.kind = k Then
            lstResults.Items.Add(nextToken.ToString)
            nextToken = scanner.scan
        Else
            syntaxError = True
        End If
    End Sub

    Private Sub parse_program()
        Select Case nextToken.kind
            Case cToken.OPENBRACES
                acceptToken(cToken.OPENBRACES)
                parse_statement()
                acceptToken(cToken.CLOSEBRACES)
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_statement()
        Select Case nextToken.kind
            Case cToken.IFTOKEN
                parse_if()
            Case cToken.IDENTIFIER
                parse_assign()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_if()
        acceptToken(cToken.IFTOKEN)
        acceptToken(cToken.LeftPara)
        parse_expression()
        acceptToken(cToken.RightPara)
        parse_statement()
        parse_else()
    End Sub

    Private Sub parse_expression()
        Select Case nextToken.kind
            Case cToken.EXPRESSION
                acceptToken(cToken.EXPRESSION)
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_assign()
        Select Case nextToken.kind
            Case cToken.IDENTIFIER
                acceptToken(cToken.IDENTIFIER)
                acceptToken(cToken.ASSIGNMENT)
                parse_expression()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_else()
        Select Case nextToken.kind
            Case cToken.ELSETOKEN
                acceptToken(cToken.ELSETOKEN)
                parse_statement()
            Case Else
                Return
        End Select
    End Sub

End Class
