Public Class displayForm

    Dim originalColor As Color
    Public loggedIn As Boolean = False
    Public library As Library
    Dim filePath As String


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.library = New Library()
        library.setup()
        filePath = library.filePath
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub displayForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        connectedServer.Left = (connectedServer.Parent.Width \ 2) - (connectedServer.Width \ 2)
        originalColor = btnLogin.BackColor
        btnLogin.PerformClick()

    End Sub
    Private Sub Login_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        closeOtherForms()
        ' Create an instance of the login form
        Dim loginForm As New Startup()

        ' Set the TopLevel property to False to allow embedding in the panel
        loginForm.TopLevel = False

        ' Set the FormBorderStyle property to None to remove the border
        loginForm.FormBorderStyle = FormBorderStyle.None

        ' Set the Dock property to Fill to make the form fill the panel
        loginForm.Dock = DockStyle.Fill
        PanelLogin.Controls.Clear()
        ' Add the login form to the panel
        PanelLogin.Controls.Add(loginForm)

        ' Show the login form
        loginForm.Show()

    End Sub

    Private Sub Login_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.DarkGray

    End Sub

    Private Sub Login_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = originalColor
    End Sub


    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        closeOtherForms()
        If loggedIn Then
            ' Create an instance of the login form
            Dim mainform As New manageUsersForm()

            ' Set the TopLevel property to False to allow embedding in the panel
            mainform.TopLevel = False

            ' Set the FormBorderStyle property to None to remove the border
            mainform.FormBorderStyle = FormBorderStyle.None

            ' Set the Dock property to Fill to make the form fill the panel
            mainform.Dock = DockStyle.Fill
            PanelLogin.Controls.Clear()

            ' Add the login form to the panel
            PanelLogin.Controls.Add(mainform)

            ' Show the login form
            mainform.Show()
            mainform.userList.SelectedIndex = 0
            connectedServer.Text = "Connected to: " & library.connectedServer
        Else
            MessageBox.Show("Please Log in First")
        End If
    End Sub

    Private Sub btnAddUsr_Click(sender As Object, e As EventArgs) Handles btnAddUsr.Click
        closeOtherForms()
        If loggedIn Then
            ' Create an instance of the login form
            Dim addUserform As New addUser()

            ' Set the TopLevel property to False to allow embedding in the panel
            addUserform.TopLevel = False

            ' Set the FormBorderStyle property to None to remove the border
            addUserform.FormBorderStyle = FormBorderStyle.None

            ' Set the Dock property to Fill to make the form fill the panel
            addUserform.Dock = DockStyle.Fill
            PanelLogin.Controls.Clear()
            ' Add the login form to the panel
            PanelLogin.Controls.Add(addUserform)
            Console.WriteLine("Attemping")
            ' Show the login form
            addUserform.Show()
        Else
            MessageBox.Show("Please Log in First")
        End If
    End Sub

    Private Sub displayForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        library.closingCleanup()

        Application.ExitThread()

    End Sub

    Private Function closeOtherForms()
        Startup.Close()
        main.Close()
        Console.WriteLine("closing forms")
    End Function

    Private Sub connectedServer_SizeChanged(sender As Object, e As EventArgs) Handles connectedServer.SizeChanged
        connectedServer.Left = (connectedServer.Parent.Width \ 2) - (connectedServer.Width \ 2)
    End Sub
End Class