<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMyCompiler
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtProgram = New TextBox()
        ProgramLabel = New Label()
        lstResults = New ListBox()
        ResultsLabel = New Label()
        btnLoadFile = New Button()
        btnParse = New Button()
        btnExit = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        SuspendLayout()
        ' 
        ' txtProgram
        ' 
        txtProgram.Location = New Point(184, 32)
        txtProgram.Multiline = True
        txtProgram.Name = "txtProgram"
        txtProgram.Size = New Size(340, 90)
        txtProgram.TabIndex = 0
        ' 
        ' ProgramLabel
        ' 
        ProgramLabel.AutoSize = True
        ProgramLabel.Location = New Point(74, 32)
        ProgramLabel.Name = "ProgramLabel"
        ProgramLabel.Size = New Size(53, 15)
        ProgramLabel.TabIndex = 1
        ProgramLabel.Text = "Program"
        ' 
        ' lstResults
        ' 
        lstResults.FormattingEnabled = True
        lstResults.ItemHeight = 15
        lstResults.Location = New Point(184, 189)
        lstResults.Name = "lstResults"
        lstResults.Size = New Size(340, 154)
        lstResults.TabIndex = 2
        ' 
        ' ResultsLabel
        ' 
        ResultsLabel.AutoSize = True
        ResultsLabel.Location = New Point(74, 189)
        ResultsLabel.Name = "ResultsLabel"
        ResultsLabel.Size = New Size(44, 15)
        ResultsLabel.TabIndex = 3
        ResultsLabel.Text = "Results"
        ' 
        ' btnLoadFile
        ' 
        btnLoadFile.Location = New Point(184, 372)
        btnLoadFile.Name = "btnLoadFile"
        btnLoadFile.Size = New Size(75, 23)
        btnLoadFile.TabIndex = 4
        btnLoadFile.Text = "Load File"
        btnLoadFile.UseVisualStyleBackColor = True
        ' 
        ' btnParse
        ' 
        btnParse.Location = New Point(324, 372)
        btnParse.Name = "btnParse"
        btnParse.Size = New Size(75, 23)
        btnParse.TabIndex = 5
        btnParse.Text = "Parse"
        btnParse.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(449, 372)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(75, 23)
        btnExit.TabIndex = 6
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' frmMyCompiler
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(578, 450)
        Controls.Add(btnExit)
        Controls.Add(btnParse)
        Controls.Add(btnLoadFile)
        Controls.Add(ResultsLabel)
        Controls.Add(lstResults)
        Controls.Add(ProgramLabel)
        Controls.Add(txtProgram)
        Name = "frmMyCompiler"
        Text = "My Compiler"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtProgram As TextBox
    Friend WithEvents ProgramLabel As Label
    Friend WithEvents lstResults As ListBox
    Friend WithEvents ResultsLabel As Label
    Friend WithEvents btnLoadFile As Button
    Friend WithEvents btnParse As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog

End Class
