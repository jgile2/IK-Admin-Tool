<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addUser
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtConf = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbAccount = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Confirm Password"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(213, 121)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(201, 29)
        Me.txtUser.TabIndex = 3
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(213, 177)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(201, 29)
        Me.txtPass.TabIndex = 4
        '
        'txtConf
        '
        Me.txtConf.Location = New System.Drawing.Point(213, 220)
        Me.txtConf.Name = "txtConf"
        Me.txtConf.Size = New System.Drawing.Size(201, 29)
        Me.txtConf.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 284)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 55)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Add User"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 25)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Account Type"
        '
        'cmbAccount
        '
        Me.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccount.FormattingEnabled = True
        Me.cmbAccount.Items.AddRange(New Object() {"Defence", "NGO"})
        Me.cmbAccount.Location = New System.Drawing.Point(169, 66)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(270, 32)
        Me.cmbAccount.TabIndex = 10
        '
        'addUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 516)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbAccount)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtConf)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "addUser"
        Me.Text = "Add User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtConf As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbAccount As ComboBox
End Class
