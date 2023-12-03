<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Me.btnDelete = New System.Windows.Forms.RichTextBox()
        Me.userList = New System.Windows.Forms.ComboBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(276, 241)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(1228, 579)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = ""
        '
        'userList
        '
        Me.userList.FormattingEnabled = True
        Me.userList.Location = New System.Drawing.Point(693, 119)
        Me.userList.Name = "userList"
        Me.userList.Size = New System.Drawing.Size(593, 32)
        Me.userList.TabIndex = 1
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(1310, 86)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(292, 41)
        Me.btnChange.TabIndex = 2
        Me.btnChange.Text = "Change Password"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(912, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(349, 40)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Delete User"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1801, 1118)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.userList)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "main"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnDelete As RichTextBox
    Friend WithEvents userList As ComboBox
    Friend WithEvents btnChange As Button
    Friend WithEvents Button1 As Button
End Class
