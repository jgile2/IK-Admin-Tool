Public Class manageUsersForm
    Dim library As Library
    Private Sub manageUsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        library = displayForm.library
        cmbAccount.SelectedIndex = 0
        ' library.setup()
        Dim linesArray() As String = library.fillUserList("Defence")
        Array.Sort(linesArray)
        ' You can access and manipulate the lines as needed
        Dim userArray As New List(Of String)()

        Dim count As Integer
        For Each line As String In linesArray
            count = count + 1
            'Console.WriteLine(line)
            If line IsNot "" Then
                ''authCont.Text = authCont.Text + Environment.NewLine + line
                userArray.Add(line)


                'userList.Items.Add(line)

                ' Console.WriteLine(userArray)
            End If
        Next
        ''fillReadout()
        Dim UserID() As String
        For Each user As String In userArray
            UserID = user.Split(" NT-Password := ")

            'Console.WriteLine(UserID(0))
            userList.Items.Add(UserID(0))
        Next

    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        chngPwd.Show()
        chngPwd.updateUserField(userList.Text)
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        library.deleteUser(userList.Text, cmbAccount.Text)
        Dim currentselected = userList.SelectedIndex
        userList.Items.Clear()


        Dim linesArray() As String = library.fillUserList(cmbAccount.Text)
        Array.Sort(linesArray)
        ' You can access and manipulate the lines as needed
        Dim userArray As New List(Of String)()

        Dim count As Integer
        For Each line As String In linesArray
            count = count + 1
            'Console.WriteLine(line)
            If line IsNot "" Then
                ''authCont.Text = authCont.Text + Environment.NewLine + line
                userArray.Add(line)


                'userList.Items.Add(line)

                ' Console.WriteLine(userArray)
            End If
        Next
        ''fillReadout()
        Dim UserID() As String
        For Each user As String In userArray
            UserID = user.Split(" NT-Password := ")

            'Console.WriteLine(UserID(0))
            userList.Items.Add(UserID(0))
        Next
        userList.SelectedIndex = currentselected

    End Sub

    Private Sub cmbAccount_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAccount.SelectedValueChanged
        Dim linesArray() As String = library.fillUserList(cmbAccount.Text)
        Console.WriteLine("Updating user list for type: " & cmbAccount.Text)
        userList.Items.Clear()
        Array.Sort(linesArray)
        ' You can access and manipulate the lines as needed
        Dim userArray As New List(Of String)()

        Dim count As Integer
        For Each line As String In linesArray
            count = count + 1
            'Console.WriteLine(line)
            If line IsNot "" Then
                ''authCont.Text = authCont.Text + Environment.NewLine + line
                userArray.Add(line)


                'userList.Items.Add(line)

                ' Console.WriteLine(userArray)
            End If
        Next
        ''fillReadout()
        Dim UserID() As String
        For Each user As String In userArray
            UserID = user.Split(" NT-Password := ")

            userList.Items.Add(UserID(0))
            'Console.WriteLine(user)
        Next
        userList.SelectedIndex = 0
        ' Console.WriteLine("updating user list")
    End Sub
End Class