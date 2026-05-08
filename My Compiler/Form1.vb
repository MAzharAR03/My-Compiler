Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
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
            'lstResults.Items.Add("Syntax Error!")
        Else
            'lstResults.Items.Add("Syntax Correct!")
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
        lstResults.Items.Add("<program>")
        Select Case nextToken.kind
            Case cToken.OPENBRACES
                acceptToken(cToken.OPENBRACES)
                parse_statement()
                acceptToken(cToken.CLOSEBRACES)
            Case Else
                syntaxError = True
        End Select
        lstResults.Items.Add("</program>")
    End Sub

    Private Sub parse_statement()
        lstResults.Items.Add("<statement>")
        Select Case nextToken.kind
            Case cToken.IFTOKEN
                parse_if()
            Case cToken.IDENTIFIER
                parse_assign()
            Case Else
                syntaxError = True
        End Select
        lstResults.Items.Add("</statement>")
    End Sub

    Private Sub parse_if()
        lstResults.Items.Add("<If>")
        acceptToken(cToken.IFTOKEN)
        acceptToken(cToken.LeftPara)
        parse_expression()
        acceptToken(cToken.RightPara)
        parse_statement()
        parse_else()
        lstResults.Items.Add("</If>")
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
        lstResults.Items.Add("<else>")
        Select Case nextToken.kind
            Case cToken.ELSETOKEN
                acceptToken(cToken.ELSETOKEN)
                parse_statement()
            Case Else
                Return
        End Select
        lstResults.Items.Add("</else>")
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
