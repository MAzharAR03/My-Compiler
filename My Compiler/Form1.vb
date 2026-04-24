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
        End While
    End Sub

    Private Sub frmMyCompiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
