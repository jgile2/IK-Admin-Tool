Imports System.IO
Imports System.Xml
Imports Renci.SshNet

Public Class Startup
    Dim instLibrary As Library
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'main.Show()
        displayForm.library.username = username.Text
        displayForm.library.password = password.Text
        displayForm.library.ipaddress = ipadr.Text
        displayForm.library.connectedServer = cmbServer.Text
        If displayForm.library.connection() Then
            displayForm.loggedIn = True
            displayForm.btnHome.PerformClick()
            Me.Close()
        End If



        'Library.updateFilePath(lblTempLoc.Text)

    End Sub

    Private Sub Startup_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Specify the path to your XML configuration 
        instLibrary = displayForm.library
        cmbServer.SelectedIndex = 1
        ' instLibrary.setup()
        Dim configFilePath As String = instLibrary.configFilePath
        Dim server = cmbServer.Text
        ' Read configuration values
        Dim CFGusername As String = instLibrary.ReadConfigValue(configFilePath, server + "/username")
        Dim CFGpassword As String = instLibrary.ReadConfigValue(configFilePath, server + "/password")
        Dim CFGserverip As String = instLibrary.ReadConfigValue(configFilePath, server + "/SFTPIP")
        Dim tempLocation As String = instLibrary.ReadConfigValue(configFilePath, "templocation")
        ' Display the read values
        'Console.WriteLine($"Username: {CFGusername}")
        'Console.WriteLine($"Password: {CFGpassword}")
        'Console.WriteLine($"Server IP: {CFGserverip}")

        ' Console.ReadLine()

        ipadr.Text = CFGserverip
        username.Text = CFGusername
        password.Text = CFGpassword

    End Sub



    Private Function updateValue()
        ' Specify the path to your XML configuration 
        Dim configFilePath As String = "config.xml"
        Dim server = cmbServer.Text
        ' Read configuration values
        Dim CFGusername As String = instLibrary.ReadConfigValue(configFilePath, server + "/username")
        Dim CFGpassword As String = instLibrary.ReadConfigValue(configFilePath, server + "/password")
        Dim CFGserverip As String = instLibrary.ReadConfigValue(configFilePath, server + "/SFTPIP")
        ' Display the read values
        'Console.WriteLine($"Username: {CFGusername}")
        ' Console.WriteLine($"Password: {CFGpassword}")
        ' Console.WriteLine($"Server IP: {CFGserverip}")

        ' Console.ReadLine()

        ipadr.Text = CFGserverip
        username.Text = CFGusername
        password.Text = CFGpassword
    End Function

    Private Sub cmbServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbServer.SelectedIndexChanged
        updateValue()

    End Sub
End Class
