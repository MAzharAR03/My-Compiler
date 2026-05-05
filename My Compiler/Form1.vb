Imports System.IO
Public Class frmMyCompiler
    Private Sub txtProgram_TextChanged(sender As Object, e As EventArgs) Handles txtProgram.TextChanged

    End Sub

    Private Sub btnParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParse.Click
        Dim scanner As cScanner = New cScanner
        Dim currentToken As cToken
        lstResults.Items.Clear()
        currentToken = scanner.scan
        While currentToken.kind <> cToken.EOF
            lstResults.Items.Add(currentToken.ToString)
            currentToken = scanner.scan
            If currentToken.kind = cToken.UNKNOWN Then
                MessageBox.Show("An unrecognized character or token was encountered: " & currentToken.ToString(),
                    "Lexical Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End If
        End While
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
End Class
