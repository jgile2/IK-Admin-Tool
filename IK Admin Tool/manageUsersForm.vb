Public Class manageUsersForm
    Dim library As Library
    Private Sub manageUsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        library = displayForm.library
        ' library.setup()
        Dim linesArray() As String = Library.fillUserList()
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
        library.deleteUser(userList.Text)
    End Sub
End Class