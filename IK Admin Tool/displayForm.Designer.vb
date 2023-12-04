<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class displayForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(displayForm))
        Me.PanelLogin = New System.Windows.Forms.Panel()
        Me.panelMenu = New System.Windows.Forms.Panel()
        Me.connectedServer = New System.Windows.Forms.Label()
        Me.btnAddUsr = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panelMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelLogin
        '
        Me.PanelLogin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelLogin.Location = New System.Drawing.Point(306, 0)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(1385, 937)
        Me.PanelLogin.TabIndex = 2
        '
        'panelMenu
        '
        Me.panelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.panelMenu.Controls.Add(Me.connectedServer)
        Me.panelMenu.Controls.Add(Me.btnAddUsr)
        Me.panelMenu.Controls.Add(Me.btnHome)
        Me.panelMenu.Controls.Add(Me.btnLogin)
        Me.panelMenu.Controls.Add(Me.Panel1)
        Me.panelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelMenu.Location = New System.Drawing.Point(0, 0)
        Me.panelMenu.Name = "panelMenu"
        Me.panelMenu.Size = New System.Drawing.Size(300, 949)
        Me.panelMenu.TabIndex = 5
        '
        'connectedServer
        '
        Me.connectedServer.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.connectedServer.AutoSize = True
        Me.connectedServer.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.connectedServer.Location = New System.Drawing.Point(109, 912)
        Me.connectedServer.Name = "connectedServer"
        Me.connectedServer.Size = New System.Drawing.Size(143, 25)
        Me.connectedServer.TabIndex = 0
        Me.connectedServer.Text = "Not Connected"
        '
        'btnAddUsr
        '
        Me.btnAddUsr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAddUsr.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAddUsr.Location = New System.Drawing.Point(0, 390)
        Me.btnAddUsr.Name = "btnAddUsr"
        Me.btnAddUsr.Size = New System.Drawing.Size(300, 120)
        Me.btnAddUsr.TabIndex = 3
        Me.btnAddUsr.Text = "Add User"
        Me.btnAddUsr.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnHome.Location = New System.Drawing.Point(0, 270)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(300, 120)
        Me.btnHome.TabIndex = 2
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnLogin.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnLogin.Location = New System.Drawing.Point(0, 150)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(300, 120)
        Me.btnLogin.TabIndex = 1
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 150)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(65, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 132)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'displayForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1703, 949)
        Me.Controls.Add(Me.panelMenu)
        Me.Controls.Add(Me.PanelLogin)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "displayForm"
        Me.Text = "IK Admin Tool"
        Me.panelMenu.ResumeLayout(False)
        Me.panelMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelLogin As Panel
    Friend WithEvents panelMenu As Panel
    Friend WithEvents btnLogin As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnHome As Button
    Friend WithEvents btnAddUsr As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents connectedServer As Label
End Class
