<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtServerAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStopClient = New System.Windows.Forms.Button()
        Me.btnStartClient = New System.Windows.Forms.Button()
        Me.txtServerPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblWinner = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.btnBottom5 = New System.Windows.Forms.Button()
        Me.btnBottom4 = New System.Windows.Forms.Button()
        Me.btnBottom3 = New System.Windows.Forms.Button()
        Me.btnBottom2 = New System.Windows.Forms.Button()
        Me.btnBottom1 = New System.Windows.Forms.Button()
        Me.btnTop5 = New System.Windows.Forms.Button()
        Me.btnTop4 = New System.Windows.Forms.Button()
        Me.btnTop3 = New System.Windows.Forms.Button()
        Me.btnTop2 = New System.Windows.Forms.Button()
        Me.btnTop1 = New System.Windows.Forms.Button()
        Me.btnRightBig = New System.Windows.Forms.Button()
        Me.btnLeftBig = New System.Windows.Forms.Button()
        Me.pnlGameBoard = New System.Windows.Forms.Panel()
        Me.GroupBox2.SuspendLayout()
        Me.pnlGameBoard.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtServerAddress)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnStopClient)
        Me.GroupBox2.Controls.Add(Me.btnStartClient)
        Me.GroupBox2.Controls.Add(Me.txtServerPort)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(632, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(219, 142)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Network Settings - Client"
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Location = New System.Drawing.Point(87, 27)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(104, 20)
        Me.txtServerAddress.TabIndex = 5
        Me.txtServerAddress.Text = "127.0.0.1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Server Address:"
        '
        'btnStopClient
        '
        Me.btnStopClient.Enabled = False
        Me.btnStopClient.Location = New System.Drawing.Point(9, 110)
        Me.btnStopClient.Name = "btnStopClient"
        Me.btnStopClient.Size = New System.Drawing.Size(182, 23)
        Me.btnStopClient.TabIndex = 3
        Me.btnStopClient.Text = "DisconnectClient"
        Me.btnStopClient.UseVisualStyleBackColor = True
        '
        'btnStartClient
        '
        Me.btnStartClient.Location = New System.Drawing.Point(9, 81)
        Me.btnStartClient.Name = "btnStartClient"
        Me.btnStartClient.Size = New System.Drawing.Size(182, 23)
        Me.btnStartClient.TabIndex = 2
        Me.btnStartClient.Text = "Start Client"
        Me.btnStartClient.UseVisualStyleBackColor = True
        '
        'txtServerPort
        '
        Me.txtServerPort.Location = New System.Drawing.Point(87, 52)
        Me.txtServerPort.Name = "txtServerPort"
        Me.txtServerPort.Size = New System.Drawing.Size(104, 20)
        Me.txtServerPort.TabIndex = 1
        Me.txtServerPort.Text = "1000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Listen on Port:"
        '
        'lblWinner
        '
        Me.lblWinner.AutoSize = True
        Me.lblWinner.Location = New System.Drawing.Point(78, 193)
        Me.lblWinner.Name = "lblWinner"
        Me.lblWinner.Size = New System.Drawing.Size(51, 13)
        Me.lblWinner.TabIndex = 32
        Me.lblWinner.Text = "lblWinner"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Game Log:"
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(12, 213)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(561, 229)
        Me.txtLog.TabIndex = 30
        '
        'btnBottom5
        '
        Me.btnBottom5.Enabled = False
        Me.btnBottom5.Location = New System.Drawing.Point(412, 92)
        Me.btnBottom5.Name = "btnBottom5"
        Me.btnBottom5.Size = New System.Drawing.Size(75, 72)
        Me.btnBottom5.TabIndex = 29
        Me.btnBottom5.Tag = "7"
        Me.btnBottom5.UseVisualStyleBackColor = True
        '
        'btnBottom4
        '
        Me.btnBottom4.Enabled = False
        Me.btnBottom4.Location = New System.Drawing.Point(331, 92)
        Me.btnBottom4.Name = "btnBottom4"
        Me.btnBottom4.Size = New System.Drawing.Size(75, 72)
        Me.btnBottom4.TabIndex = 28
        Me.btnBottom4.Tag = "8"
        Me.btnBottom4.UseVisualStyleBackColor = True
        '
        'btnBottom3
        '
        Me.btnBottom3.Enabled = False
        Me.btnBottom3.Location = New System.Drawing.Point(250, 92)
        Me.btnBottom3.Name = "btnBottom3"
        Me.btnBottom3.Size = New System.Drawing.Size(75, 72)
        Me.btnBottom3.TabIndex = 27
        Me.btnBottom3.Tag = "9"
        Me.btnBottom3.UseVisualStyleBackColor = True
        '
        'btnBottom2
        '
        Me.btnBottom2.Enabled = False
        Me.btnBottom2.Location = New System.Drawing.Point(169, 92)
        Me.btnBottom2.Name = "btnBottom2"
        Me.btnBottom2.Size = New System.Drawing.Size(75, 72)
        Me.btnBottom2.TabIndex = 26
        Me.btnBottom2.Tag = "10"
        Me.btnBottom2.UseVisualStyleBackColor = True
        '
        'btnBottom1
        '
        Me.btnBottom1.Enabled = False
        Me.btnBottom1.Location = New System.Drawing.Point(88, 92)
        Me.btnBottom1.Name = "btnBottom1"
        Me.btnBottom1.Size = New System.Drawing.Size(75, 72)
        Me.btnBottom1.TabIndex = 25
        Me.btnBottom1.Tag = "11"
        Me.btnBottom1.UseVisualStyleBackColor = True
        '
        'btnTop5
        '
        Me.btnTop5.Enabled = False
        Me.btnTop5.Location = New System.Drawing.Point(412, 14)
        Me.btnTop5.Name = "btnTop5"
        Me.btnTop5.Size = New System.Drawing.Size(75, 72)
        Me.btnTop5.TabIndex = 24
        Me.btnTop5.Tag = "5"
        Me.btnTop5.UseVisualStyleBackColor = True
        '
        'btnTop4
        '
        Me.btnTop4.Enabled = False
        Me.btnTop4.Location = New System.Drawing.Point(331, 14)
        Me.btnTop4.Name = "btnTop4"
        Me.btnTop4.Size = New System.Drawing.Size(75, 72)
        Me.btnTop4.TabIndex = 23
        Me.btnTop4.Tag = "4"
        Me.btnTop4.UseVisualStyleBackColor = True
        '
        'btnTop3
        '
        Me.btnTop3.Enabled = False
        Me.btnTop3.Location = New System.Drawing.Point(250, 14)
        Me.btnTop3.Name = "btnTop3"
        Me.btnTop3.Size = New System.Drawing.Size(75, 72)
        Me.btnTop3.TabIndex = 22
        Me.btnTop3.Tag = "3"
        Me.btnTop3.UseVisualStyleBackColor = True
        '
        'btnTop2
        '
        Me.btnTop2.Enabled = False
        Me.btnTop2.Location = New System.Drawing.Point(169, 14)
        Me.btnTop2.Name = "btnTop2"
        Me.btnTop2.Size = New System.Drawing.Size(75, 72)
        Me.btnTop2.TabIndex = 21
        Me.btnTop2.Tag = "2"
        Me.btnTop2.UseVisualStyleBackColor = True
        '
        'btnTop1
        '
        Me.btnTop1.Enabled = False
        Me.btnTop1.Location = New System.Drawing.Point(88, 14)
        Me.btnTop1.Name = "btnTop1"
        Me.btnTop1.Size = New System.Drawing.Size(75, 72)
        Me.btnTop1.TabIndex = 20
        Me.btnTop1.Tag = "1"
        Me.btnTop1.UseVisualStyleBackColor = True
        '
        'btnRightBig
        '
        Me.btnRightBig.Enabled = False
        Me.btnRightBig.Location = New System.Drawing.Point(493, 14)
        Me.btnRightBig.Name = "btnRightBig"
        Me.btnRightBig.Size = New System.Drawing.Size(75, 150)
        Me.btnRightBig.TabIndex = 19
        Me.btnRightBig.Tag = "6"
        Me.btnRightBig.UseVisualStyleBackColor = True
        '
        'btnLeftBig
        '
        Me.btnLeftBig.Enabled = False
        Me.btnLeftBig.Location = New System.Drawing.Point(7, 14)
        Me.btnLeftBig.Name = "btnLeftBig"
        Me.btnLeftBig.Size = New System.Drawing.Size(75, 150)
        Me.btnLeftBig.TabIndex = 18
        Me.btnLeftBig.Tag = "0"
        Me.btnLeftBig.UseVisualStyleBackColor = True
        '
        'pnlGameBoard
        '
        Me.pnlGameBoard.Controls.Add(Me.btnBottom5)
        Me.pnlGameBoard.Controls.Add(Me.btnBottom4)
        Me.pnlGameBoard.Controls.Add(Me.btnBottom3)
        Me.pnlGameBoard.Controls.Add(Me.btnBottom2)
        Me.pnlGameBoard.Controls.Add(Me.btnBottom1)
        Me.pnlGameBoard.Controls.Add(Me.btnTop5)
        Me.pnlGameBoard.Controls.Add(Me.btnTop4)
        Me.pnlGameBoard.Controls.Add(Me.btnTop3)
        Me.pnlGameBoard.Controls.Add(Me.btnTop2)
        Me.pnlGameBoard.Controls.Add(Me.btnTop1)
        Me.pnlGameBoard.Controls.Add(Me.btnRightBig)
        Me.pnlGameBoard.Controls.Add(Me.btnLeftBig)
        Me.pnlGameBoard.Location = New System.Drawing.Point(12, 12)
        Me.pnlGameBoard.Name = "pnlGameBoard"
        Me.pnlGameBoard.Size = New System.Drawing.Size(575, 178)
        Me.pnlGameBoard.TabIndex = 34
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 462)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlGameBoard)
        Me.Controls.Add(Me.lblWinner)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLog)
        Me.Name = "Form1"
        Me.Text = " "
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlGameBoard.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnStopClient As Button
    Friend WithEvents btnStartClient As Button
    Friend WithEvents txtServerPort As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblWinner As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLog As TextBox
    Friend WithEvents btnBottom5 As Button
    Friend WithEvents btnBottom4 As Button
    Friend WithEvents btnBottom3 As Button
    Friend WithEvents btnBottom2 As Button
    Friend WithEvents btnBottom1 As Button
    Friend WithEvents btnTop5 As Button
    Friend WithEvents btnTop4 As Button
    Friend WithEvents btnTop3 As Button
    Friend WithEvents btnTop2 As Button
    Friend WithEvents btnTop1 As Button
    Friend WithEvents btnRightBig As Button
    Friend WithEvents btnLeftBig As Button
    Friend WithEvents txtServerAddress As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlGameBoard As Panel
End Class
