Imports System.IO
Imports Renci.SshNet

Public Class main
    'Public library = New Library
    ''Dim client As SftpClient
    Dim remoteLocation As String
    Dim filePath As String
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'library.setup()
        ' filePath = library.filepath
        'Dim username As String = Startup.username.Text
        'Dim password As String = Startup.password.Text
        'Dim ipaddress As String = Startup.ipadr.Text
        'remoteLocation = "/home/jgile2/Documents/authorize"

        'client = New SftpClient(ipaddress, username, password)

        'client.Connect()

        'Using stream As Stream = File.OpenRead("C:\temp\authorize")
        '    client.UploadFile(stream, "/home/jgile2/Documents/authorize2")
        '    Using streamwrite As Stream = File.Create("C:\temp\authorize")
        '        client.DownloadFile(remoteLocation, streamwrite)

        '    End Using

        '    Dim fileReader As String
        '    fileReader = My.Computer.FileSystem.ReadAllText("C:\temp\authorize")
        '    authCont.Text = fileReader

        '    Dim filePath As String = "C:\temp\authorize"

        Dim linesToKeep As New List(Of String)

        ' Read the file line by line and skip the first 220 lines
        Dim lineCounter As Integer = 0
        Using reader As New StreamReader(filePath)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                If lineCounter >= 220 Then
                    ' Add the line to the list after skipping the first 220 lines
                    linesToKeep.Add(line)
                End If
                lineCounter += 1
            End While
        End Using

        ' Convert the list to an array
        Dim linesArray() As String = linesToKeep.ToArray()
        'authCont.Text = linesArray(10)
        ' Now, linesArray contains the lines from the file after skipping the first 220 lines
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
        fillReadout()
        Dim UserID() As String
        For Each user As String In userArray
            UserID = user.Split(" NT-Password := ")

            'Console.WriteLine(UserID(0))
            userList.Items.Add(UserID(0))
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        chngPwd.Show()

        ' chngPwd.LoadChange(userList.Text)

    End Sub






    Private Sub fillReadout()
        ' Specify the path to the text file
        ' Dim filePath As String = "C:\temp\authorize"

        ' Check if the file exists
        If File.Exists(filePath) Then
            ' Open the file and read its contents
            Dim fileContents As String = ReadTextFile(filePath)
            btnDelete.Text = fileContents
            ' Display the file contents
        Else
            Console.WriteLine("The file does not exist.")
        End If


    End Sub
    Public Sub updatePassword(user As String, newPassword As String)
        ' Specify the path to the text file
        'Dim filePath As String = "C:\temp\authorize"

        ' Specify the text to search for
        Dim searchText As String = user

        ' Find the line with specific text
        Dim lineNumber As Integer = FindLineWithText(filePath, searchText)


        ' Display the result
        If lineNumber > 0 Then
            Console.WriteLine($"The text '{searchText}' was found on line {lineNumber}.")
        Else
            Console.WriteLine($"The text '{searchText}' was not found in the file.")
        End If

        Console.ReadLine()
        Dim updatedLine As String = user + "  NT-Password := """ + newPassword + """"
        UpdateLineInTextFile(filePath, lineNumber, updatedLine)
        displayForm.library.uploadFile()
        fillReadout()
        MessageBox.Show(user + "'s Has been updated")
    End Sub

    Public Sub deleteUser(user As String)
        Console.WriteLine("delete user being called with user " + user)
        'Dim filePath As String = "C:\temp\authorize"

        ' Specify the text to search for
        Dim searchText As String = user

        ' Find the line with specific text
        Dim lineNumber As Integer = FindLineWithText(filePath, searchText)
        Console.WriteLine("deleting 2")
        ' Display the result
        If lineNumber > 0 Then
            Console.WriteLine("deleting 3")
            Console.WriteLine($"The text '{searchText}' was found on line {lineNumber}.")
        Else
            Console.WriteLine($"The text '{searchText}' was not found in the file.")
        End If

        Console.ReadLine()
        Dim linetoDelete = ""

        Dim lines As List(Of String) = System.IO.File.ReadAllLines(filePath).ToList
        lines.RemoveAt(lineNumber - 1) ' index starts at 0 
        System.IO.File.WriteAllLines(filePath, lines)
        'MessageBox.Show("Please Wait")
        displayForm.library.uploadFile()
        fillReadout()
        MessageBox.Show(user + " Has been Deleted")
    End Sub

    Function ReadTextFile(filePath As String) As String
        ' Read the contents of the text file
        Try
            Using reader As New StreamReader(filePath)
                Dim contents As String = reader.ReadToEnd()
                Return contents
            End Using
        Catch ex As Exception
            ' Handle exceptions, if any
            Console.WriteLine("An error occurred: " & ex.Message)
            Return String.Empty
        End Try


    End Function

    Function FindLineWithText(filePath As String, searchText As String) As Integer
        ' Read the file line by line
        Try
            Using reader As New StreamReader(filePath)
                Dim line As String
                Dim lineNumber As Integer = 0

                ' Iterate through each line
                While Not reader.EndOfStream
                    lineNumber += 1
                    line = reader.ReadLine()

                    ' Check if the line contains the desired text
                    If line.Contains(searchText) Then
                        Return lineNumber
                    End If
                End While
            End Using
        Catch ex As Exception
            ' Handle exceptions, if any
            Console.WriteLine("An error occurred: " & ex.Message)
        End Try

        ' If the text was not found, return 0
        Return 0
    End Function
    Sub UpdateLineInTextFile(filePath As String, lineNumberToUpdate As Integer, newText As String)
        ' Read all lines from the file
        Dim lines As List(Of String) = File.ReadAllLines(filePath).ToList()

        ' Check if the specified line number is valid
        If lineNumberToUpdate > 0 AndAlso lineNumberToUpdate <= lines.Count Then
            ' Update the specified line
            lines(lineNumberToUpdate - 1) = newText

            ' Write the modified lines back to the file
            File.WriteAllLines(filePath, lines)

            Console.WriteLine($"Line {lineNumberToUpdate} updated successfully.")
        Else
            Console.WriteLine("Invalid line number.")
        End If
    End Sub



    Private Sub main_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        displayForm.library.client.Disconnect()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Console.WriteLine("deleting 1")
        Dim user As String = userList.Text

        deleteUser(user)
    End Sub

    Private Sub userList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles userList.SelectedIndexChanged

    End Sub
End Class