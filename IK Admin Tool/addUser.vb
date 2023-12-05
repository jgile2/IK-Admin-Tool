Public Class addUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim line As Integer = displayForm.library.FindLineWithText(displayForm.library.filePath, txtUser.Text)
        Dim userExist As Boolean = displayForm.library.doesUserExit(txtUser.Text, cmbAccount.Text)
        If txtPass.Text IsNot "" OrElse txtConf.Text IsNot "" Then
            Console.WriteLine("writing Passwords: " & txtPass.Text)

            If userExist = False Then
                Console.WriteLine("Continuing")
                If txtPass.Text = txtConf.Text Then
                    Dim EnByte() As Byte = DSInternals.Common.Cryptography.NTHash.ComputeHash(txtPass.Text)
                    Dim hashHex As String = displayForm.library.ByteArrayToHexString(EnByte)
                    Console.WriteLine("Password is: " & hashHex)
                    displayForm.library.addUser(txtUser.Text, hashHex, cmbAccount.Text)
                Else
                    MessageBox.Show("Passwords Dont Match")
                End If
            Else
                MessageBox.Show("User Already Exist")
            End If
        Else
            MessageBox.Show("Please Enter Password")
        End If
    End Sub

    Private Sub addUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbAccount.SelectedIndex = 0
    End Sub
End Class