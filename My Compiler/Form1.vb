Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Public Class frmMyCompiler
    Dim nextToken As cToken
    Private Sub txtProgram_TextChanged(sender As Object, e As EventArgs) Handles txtProgram.TextChanged

    End Sub

    Private Sub btnParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParse.Click
        lstResults.Items.Clear()
        lstResults.Items.Add("<results>")
        syntaxError = False
        scanner = New cScanner
        nextToken = scanner.scan
        parse_program()
        If syntaxError Then
            lstResults.Items.Add("Syntax Error!")
        Else
            lstResults.Items.Add("Syntax Correct!")
        End If
        lstResults.Items.Add("</results>")
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
        lstResults.Items.Add("<program>")
        Select Case nextToken.kind
            Case cToken.PROGRAM
                acceptToken(cToken.PROGRAM)
                acceptToken(cToken.BEGINTOKEN)
                parse_functions()
                acceptToken(cToken.ENDTOKEN)
            Case Else
                syntaxError = True
        End Select
        lstResults.Items.Add("</program>")
    End Sub

    Private Sub parse_functions()
        Select Case nextToken.kind
            Case cToken.FUNCTIONTOKEN
                parse_function()
                parse_functions()
            Case Else
                Return
        End Select
    End Sub

    Private Sub parse_function()
        lstResults.Items.Add("<function>")
        Select Case nextToken.kind
            Case cToken.FUNCTIONTOKEN
                acceptToken(cToken.FUNCTIONTOKEN)
                parse_header()
                acceptToken(cToken.BEGINTOKEN)
                parse_variables()
                parse_statements()
                acceptToken(cToken.ENDTOKEN)
                acceptToken(cToken.FUNCTIONTOKEN)
            Case Else
                syntaxError = True
        End Select
        lstResults.Items.Add("</function>")
    End Sub

    Private Sub parse_header()
        lstResults.Items.Add("<header>")
        Select Case nextToken.kind
            Case cToken.TYPE
                acceptToken(cToken.TYPE)
                acceptToken(cToken.IDENTIFIER)
                acceptToken(cToken.LEFTPAREN)
                parse_parameters()
                acceptToken(cToken.RIGHTPAREN)
            Case Else
                syntaxError = True
        End Select
        lstResults.Items.Add("</header>")
    End Sub


    Private Sub parse_parameters()
        Select Case nextToken.kind
            Case cToken.IDENTIFIER
                acceptToken(cToken.IDENTIFIER)
                parse_parameters_prime()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_parameters_prime()
        Select Case nextToken.kind
            Case cToken.COMMA
                acceptToken(cToken.COMMA)
                acceptToken(cToken.IDENTIFIER)
                parse_parameters_prime()
            Case Else
                Return
        End Select
    End Sub

    Private Sub parse_variables()
        Select Case nextToken.kind
            Case cToken.TYPE
                parse_variable()
                parse_variables()
            Case Else
                Return
        End Select
    End Sub

    Private Sub parse_variable()
        Select Case nextToken.kind
            Case cToken.TYPE
                acceptToken(cToken.TYPE)
                acceptToken(cToken.IDENTIFIER)
                acceptToken(cToken.PERIOD)
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_statements()
        Select Case nextToken.kind
            Case cToken.IDENTIFIER, cToken.STATEMENT
                parse_statement()
                parse_statements()
            Case Else
                Return
        End Select
    End Sub

    Private Sub parse_statement()
        Select Case nextToken.kind
            Case cToken.IDENTIFIER
                acceptToken(cToken.IDENTIFIER)
                acceptToken(cToken.ASSIGNMENT)
                parse_expression()
                acceptToken(cToken.PERIOD)
            Case cToken.STATEMENT
                acceptToken(cToken.STATEMENT)
                acceptToken(cToken.LEFTPAREN)
                parse_condition()
                acceptToken(cToken.RIGHTPAREN)
                acceptToken(cToken.OPENBRACE)
                parse_statements()
                acceptToken(cToken.CLOSEBRACE)
                parse_statement_prime()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_statement_prime()
        Select Case nextToken.kind
            Case cToken.OPENBRACE
                acceptToken(cToken.OPENBRACE)
                acceptToken(cToken.ENDTOKEN)
                parse_statements()
                acceptToken(cToken.CLOSEBRACE)
            Case Else
                Return
        End Select
    End Sub

    Private Sub parse_expression()
        Select Case nextToken.kind
            Case cToken.NUMBER
                acceptToken(cToken.NUMBER)
                parse_expression_double_prime()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_expression_double_prime()
        Select Case nextToken.kind
            Case cToken.ADDITION, cToken.MULTIPY
                parse_expression_prime()
                parse_expression_double_prime()
            Case Else
                Return

        End Select
    End Sub

    Private Sub parse_expression_prime()
        Select Case nextToken.kind
            Case cToken.ADDITION
                acceptToken(cToken.ADDITION)
                parse_expression()
            Case cToken.MULTIPY
                acceptToken(cToken.MULTIPY)
                parse_expression()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub parse_condition()
        Select Case nextToken.kind
            Case cToken.CONDITION
                acceptToken(cToken.CONDITION)
                parse_expression()
                parse_expression()
            Case Else
                syntaxError = True
        End Select
    End Sub


    Private Sub btnSaveResults_Click(ByVal sender As System.Object,
ByVal e As System.EventArgs) Handles btnSaveResults.Click
        SaveFileDialog1.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
        SaveFileDialog1.DefaultExt = "xml"
        SaveFileDialog1.Title = "Save as XML File"
        Dim FileName As String 'declaring filename to be selected
        Dim sr As StreamWriter 'streamreader is used to read text
        Dim i As Integer
        Try
            With SaveFileDialog1
                'With statement is used to execute statements using a particular Object, here, OpenFileDialog1
                If .ShowDialog() = DialogResult.OK Then
                    'showDialog method makes the dialog box visible at run Time
                    FileName = .FileName
                    sr = New StreamWriter(.OpenFile)
                    'using streamwriter to write the opened text file
                    For i = 0 To lstResults.Items.Count - 1
                        sr.WriteLine(lstResults.Items(i).ToString)
                        'write text from lstResults to streamwriter
                    Next
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


End Class
