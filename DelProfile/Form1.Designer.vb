<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DelProfiles
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DelProfiles))
        Me.BtDelete = New System.Windows.Forms.Button()
        Me.CbShutdown = New System.Windows.Forms.CheckBox()
        Me.CbRestart = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbSetTime = New System.Windows.Forms.ComboBox()
        Me.LbShow = New System.Windows.Forms.Label()
        Me.LbTimeCount = New System.Windows.Forms.Label()
        Me.TimerCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.BtPause = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtDelete
        '
        Me.BtDelete.Location = New System.Drawing.Point(67, 136)
        Me.BtDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtDelete.Name = "BtDelete"
        Me.BtDelete.Size = New System.Drawing.Size(148, 55)
        Me.BtDelete.TabIndex = 4
        Me.BtDelete.Text = "DeleteProfiles"
        Me.BtDelete.UseVisualStyleBackColor = True
        '
        'CbShutdown
        '
        Me.CbShutdown.AutoSize = True
        Me.CbShutdown.Checked = True
        Me.CbShutdown.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbShutdown.Location = New System.Drawing.Point(16, 34)
        Me.CbShutdown.Margin = New System.Windows.Forms.Padding(4)
        Me.CbShutdown.Name = "CbShutdown"
        Me.CbShutdown.Size = New System.Drawing.Size(90, 20)
        Me.CbShutdown.TabIndex = 1
        Me.CbShutdown.Text = "Shut Down"
        Me.CbShutdown.UseVisualStyleBackColor = True
        '
        'CbRestart
        '
        Me.CbRestart.AutoSize = True
        Me.CbRestart.Location = New System.Drawing.Point(187, 34)
        Me.CbRestart.Margin = New System.Windows.Forms.Padding(4)
        Me.CbRestart.Name = "CbRestart"
        Me.CbRestart.Size = New System.Drawing.Size(70, 20)
        Me.CbRestart.TabIndex = 2
        Me.CbRestart.Text = "Restart"
        Me.CbRestart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 80)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Set Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 80)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "/ s"
        '
        'CbSetTime
        '
        Me.CbSetTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbSetTime.FormattingEnabled = True
        Me.CbSetTime.Items.AddRange(New Object() {"0", "1800", "3600"})
        Me.CbSetTime.Location = New System.Drawing.Point(90, 77)
        Me.CbSetTime.Name = "CbSetTime"
        Me.CbSetTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CbSetTime.Size = New System.Drawing.Size(69, 24)
        Me.CbSetTime.Sorted = True
        Me.CbSetTime.TabIndex = 3
        '
        'LbShow
        '
        Me.LbShow.AutoSize = True
        Me.LbShow.Enabled = False
        Me.LbShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbShow.Location = New System.Drawing.Point(1, 111)
        Me.LbShow.Name = "LbShow"
        Me.LbShow.Size = New System.Drawing.Size(0, 16)
        Me.LbShow.TabIndex = 7
        '
        'LbTimeCount
        '
        Me.LbTimeCount.AutoSize = True
        Me.LbTimeCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTimeCount.ForeColor = System.Drawing.Color.Red
        Me.LbTimeCount.Location = New System.Drawing.Point(205, 111)
        Me.LbTimeCount.Name = "LbTimeCount"
        Me.LbTimeCount.Size = New System.Drawing.Size(0, 16)
        Me.LbTimeCount.TabIndex = 9
        '
        'TimerCountdown
        '
        '
        'BtPause
        '
        Me.BtPause.Enabled = False
        Me.BtPause.Location = New System.Drawing.Point(193, 77)
        Me.BtPause.Name = "BtPause"
        Me.BtPause.Size = New System.Drawing.Size(64, 26)
        Me.BtPause.TabIndex = 10
        Me.BtPause.Text = "Pause"
        Me.BtPause.UseVisualStyleBackColor = True
        '
        'DelProfiles
        '
        Me.AcceptButton = Me.BtDelete
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 206)
        Me.Controls.Add(Me.BtPause)
        Me.Controls.Add(Me.LbTimeCount)
        Me.Controls.Add(Me.LbShow)
        Me.Controls.Add(Me.CbSetTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbRestart)
        Me.Controls.Add(Me.CbShutdown)
        Me.Controls.Add(Me.BtDelete)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DelProfiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DelProfiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtDelete As Button
    Friend WithEvents CbShutdown As CheckBox
    Friend WithEvents CbRestart As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CbSetTime As ComboBox
    Friend WithEvents LbShow As Label
    Friend WithEvents LbTimeCount As Label
    Public WithEvents TimerCountdown As Timer
    Friend WithEvents BtPause As Button
End Class
