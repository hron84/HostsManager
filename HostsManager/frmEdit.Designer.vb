<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEdit))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.lstAlias = New System.Windows.Forms.ListBox()
        Me.btOK = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btRm = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP Address"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(15, 25)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(167, 20)
        Me.txtIP.TabIndex = 1
        '
        'lstAlias
        '
        Me.lstAlias.FormattingEnabled = True
        Me.lstAlias.Location = New System.Drawing.Point(15, 64)
        Me.lstAlias.Name = "lstAlias"
        Me.lstAlias.Size = New System.Drawing.Size(167, 186)
        Me.lstAlias.TabIndex = 2
        '
        'btOK
        '
        Me.btOK.Location = New System.Drawing.Point(15, 256)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 23)
        Me.btOK.TabIndex = 3
        Me.btOK.Text = "OK"
        Me.btOK.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(107, 256)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 4
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Aliases"
        '
        'btRm
        '
        Me.btRm.Image = Global.HostsManager.My.Resources.Resources.monitor_delete
        Me.btRm.Location = New System.Drawing.Point(188, 104)
        Me.btRm.Name = "btRm"
        Me.btRm.Size = New System.Drawing.Size(29, 26)
        Me.btRm.TabIndex = 7
        Me.btRm.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Image = Global.HostsManager.My.Resources.Resources.monitor_add
        Me.btAdd.Location = New System.Drawing.Point(188, 73)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(31, 25)
        Me.btAdd.TabIndex = 6
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'frmEdit
        '
        Me.AcceptButton = Me.btOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(231, 292)
        Me.Controls.Add(Me.btRm)
        Me.Controls.Add(Me.btAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btOK)
        Me.Controls.Add(Me.lstAlias)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEdit"
        Me.Text = "frmEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents lstAlias As System.Windows.Forms.ListBox
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btRm As System.Windows.Forms.Button
End Class
