Imports System.Security.Cryptography
Imports System.Text
Imports DSInternals



Public Class chngPwd
    Public changeUser As String
    Dim byteOptionalEntropy As Byte() = {0, 1, 2, 3, 4}
    Dim library As Library
    Private Sub chngPwd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'changeUser = manageUsersForm.userList.Text1
        '' passedUser.Text = changeUser
        library = displayForm.library
        Console.WriteLine("""test""")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Your plain password
        Dim plainPassword As String = txtPass.Text
        Dim EnByte() As Byte = DSInternals.Common.Cryptography.NTHash.ComputeHash(plainPassword)
        Dim hashHex As String = displayForm.library.ByteArrayToHexString(EnByte)
        Dim accounttype As String = manageUsersForm.cmbAccount.Text
        ' Calculate the NTLM hash

        Dim ntlmHash As String = UnicodeBytesToString(EnByte)
        If txtPass.Text = txtConf.Text Then
            Console.WriteLine(hashHex)

            ' Display the result
            Console.WriteLine("Input String: " & plainPassword)
            ' Console.WriteLine("NTLM Hash: " & ntlmHash)
            'For Each b As Byte In EnByte
            'Console.WriteLine(b)
            ' Next


            Console.ReadLine()
            library.updatePassword(changeUser, hashHex, accounttype)
            Me.Close()
        Else
            MessageBox.Show("Passwords do not match")

        End If

    End Sub

    Private Function UnicodeBytesToString(
    ByVal bytes() As Byte) As String

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function



    Public Function updateUserField(user As String)
        changeUser = user
        passedUser.Text = changeUser
    End Function
End Class
