<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manageUsersForm
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
        Me.btnDeleteUser = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.userList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnDeleteUser
        '
        Me.btnDeleteUser.Location = New System.Drawing.Point(354, 172)
        Me.btnDeleteUser.Name = "btnDeleteUser"
        Me.btnDeleteUser.Size = New System.Drawing.Size(292, 40)
        Me.btnDeleteUser.TabIndex = 6
        Me.btnDeleteUser.Text = "Delete User"
        Me.btnDeleteUser.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(56, 172)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(292, 41)
        Me.btnChange.TabIndex = 5
        Me.btnChange.Text = "Change Password"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'userList
        '
        Me.userList.FormattingEnabled = True
        Me.userList.Location = New System.Drawing.Point(56, 102)
        Me.userList.Name = "userList"
        Me.userList.Size = New System.Drawing.Size(593, 32)
        Me.userList.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Select User Below"
        '
        'manageUsersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 324)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDeleteUser)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.userList)
        Me.Name = "manageUsersForm"
        Me.Text = "manageUsersForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDeleteUser As Button
    Friend WithEvents btnChange As Button
    Friend WithEvents userList As ComboBox
    Friend WithEvents Label1 As Label
End Class
