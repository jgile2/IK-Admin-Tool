Imports System.IO
Imports System.Text
Imports System.Xml
Imports Renci.SshNet


Public Class Library
    Public client As SftpClient
    Dim sshclient As SshClient
    Dim sshcomd As SshCommand
    Dim remoteLocation As String
    Dim ngoremoteLocation As String
    Public configFilePath As String = "config.xml"
    Public filePath As String
    Public ngofilePath As String
    Dim downloaded As Boolean = False
    Public username As String
    Public password As String
    Public ipaddress As String
    Dim connected As Boolean = False
    Public connectedServer As String
    Public accountType As String


    Public Function setup()
        username = Startup.username.Text
        password = Startup.password.Text
        ipaddress = Startup.ipadr.Text
        connected = False




    End Function

    Public Function updateFilePath(path As String)
        'Console.WriteLine("updating path with: ")
        filePath = path
    End Function

    Public Function connection() As Boolean
        ' username = Startup.username.Text
        'password = Startup.password.Text
        'ipaddress = Startup.ipadr.Text
        Dim accountType = "defence"
        filePath = ReadConfigValue(configFilePath, "templocation")
        ngofilePath = ReadConfigValue(configFilePath, "ngolocation")
        remoteLocation = ReadConfigValue(configFilePath, connectedServer + "/defence-location")
        ngoremoteLocation = ReadConfigValue(configFilePath, connectedServer + "/ngo-location")
        client = New SftpClient(ipaddress, username, password)
        sshclient = New SshClient(ipaddress, username, password)
        ' Console.WriteLine("before connected: " & connected)
        Try
            sshclient.Connect()
            client.Connect()
            connected = True
        Catch ex As Exception
            ' Console.WriteLine("Error: " + ex.Message)
        Finally

        End Try
        If connected Then


            ' Console.WriteLine(downloaded)
            ' Console.WriteLine("downloading file")
            Using streamwrite As Stream = File.Create(filePath)
                client.DownloadFile(remoteLocation, streamwrite)

            End Using
            Using streamwrite As Stream = File.Create(ngofilePath)
                client.DownloadFile(ngoremoteLocation, streamwrite)

            End Using
        Else
            MessageBox.Show("Failed to connect")
        End If
        Return connected
    End Function


    Public Function fillUserList(accounttype As String) As String()
        Dim linesToKeep As New List(Of String)
        Dim typePath As String
        If accounttype = "Defence" Then
            typepath = filePath
            ' Console.WriteLine("Account type is Defence")
        ElseIf accounttype = "NGO" Then
            typepath = ngofilePath
            ' Console.WriteLine("Account type is NGO")
        Else
            MessageBox.Show("Invalid Account type")
            typePath = filePath
        End If

        'Console.WriteLine("file path: " + typePath)
        Dim lineCounter As Integer = 0
        Using reader As New StreamReader(typePath)
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


        Return linesArray
    End Function

    Public Function ReadConfigValue(configFilePath As String, key As String) As String
        ' Check if the file exists
        If Not File.Exists(configFilePath) Then
            '  Console.WriteLine("Configuration file not found.")
            Return Nothing
        End If

        Try
            ' Load the XML document
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(configFilePath)

            ' Select the value based on the key
            Dim node As XmlNode = xmlDoc.SelectSingleNode($"/configuration/settings/{key}")

            If node IsNot Nothing Then
                Return node.InnerText
            Else
                '  Console.WriteLine($"Key '{key}' not found in the configuration file.")
                Return Nothing
            End If
        Catch ex As Exception
            'Console.WriteLine($"An error occurred while reading the configuration file: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Public Sub uploadFile(accounttype As String)
        Dim typePath As String
        Dim locType As String
        If accounttype = "Defence" Then
            typePath = filePath
            locType = remoteLocation
            ' Console.WriteLine("Account type is Defence")
        ElseIf accounttype = "NGO" Then
            typePath = ngofilePath
            locType = ngoremoteLocation
            ' Console.WriteLine("Account type is NGO")
        Else
            MessageBox.Show("Invalid Account type")
            typePath = filePath
            locType = remoteLocation
        End If
        Using streamReady As Stream = New FileStream(typePath, FileMode.Open)
            'setup()
            client.UploadFile(streamReady, locType)
            sshcomd = sshclient.CreateCommand("chmod 0744 " + locType)
            sshcomd.Execute()
            ' Console.WriteLine(sshcomd.Result)
        End Using

    End Sub


    Public Function deleteUser(user As String, accounttype As String)
        ' Console.WriteLine("delete user being called with user " + user)
        Dim typePath As String
        If accounttype = "Defence" Then
            typePath = filePath
            ' Console.WriteLine("Account type is Defence")
        ElseIf accounttype = "NGO" Then
            typePath = ngofilePath
            ' Console.WriteLine("Account type is NGO")
        Else
            MessageBox.Show("Invalid Account type")
            typePath = filePath
        End If

        ' Specify the text to search for
        Dim searchText As String = user

        ' Find the line with specific text
        Dim lineNumber As Integer = FindLineWithText(typePath, searchText)
        ' Console.WriteLine("deleting 2")
        ' Display the result
        If lineNumber > 0 Then
            ' Console.WriteLine("deleting 3")
            ' Console.WriteLine($"The text '{searchText}' was found on line {lineNumber}.")
        Else
            ' Console.WriteLine($"The text '{searchText}' was not found in the file.")
        End If

        ' Console.ReadLine()
        Dim linetoDelete = ""

        Dim lines As List(Of String) = System.IO.File.ReadAllLines(typePath).ToList
        Try
            lines.RemoveAt(lineNumber - 1) ' index starts at 0 
            System.IO.File.WriteAllLines(typePath, lines)
            'MessageBox.Show("Please Wait")
            uploadFile(accounttype)
            ' fillReadout()
            MessageBox.Show(user + " Has been Deleted")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
                        Dim parts As String() = line.Split(" "c)
                        If parts(0) = searchText Then
                            Return lineNumber
                        End If

                    End If
                End While
            End Using
        Catch ex As Exception
            ' Handle exceptions, if any
            ' Console.WriteLine("An error occurred: " & ex.Message)
        End Try

        ' If the text was not found, return 0
        Return 0
    End Function
    Public Function doesUserExit(user As String, accounttype As String) As Boolean
        Dim typePath As String
        If accounttype = "Defence" Then
            typePath = filePath
            ' Console.WriteLine("Account type is Defence")
        ElseIf accounttype = "NGO" Then
            typePath = ngofilePath
            ' Console.WriteLine("Account type is NGO")
        Else
            MessageBox.Show("Invalid Account type")
            typePath = filePath
        End If
        ' The username to search for
        Dim usernameToFind As String = user

        Try
            ' Read all lines from the file
            Dim lines As String() = File.ReadAllLines(typePath)

            ' Find the line with an exact match for the username
            Dim matchingLine As String = lines.FirstOrDefault(Function(line) line.Contains(usernameToFind))

            If matchingLine IsNot Nothing Then
                'Console.WriteLine($"Found: {matchingLine}")
                Dim parts As String() = matchingLine.Split(" "c)
                'Console.WriteLine(parts(0))
                If parts(0) = user Then
                    ' Console.WriteLine("User is found")
                    Return True
                Else
                    ' Console.WriteLine("User is not found")
                    Return False
                End If
            Else
                'Console.WriteLine($"Username '{usernameToFind}' not found.")
                Return False
            End If
        Catch ex As Exception
            '  Console.WriteLine($"An error occurred: {ex.Message}")
        End Try
        Return False
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

            'Console.WriteLine($"Line {lineNumberToUpdate} updated successfully.")
        Else
            '  Console.WriteLine("Invalid line number.")
        End If
    End Sub

    Public Sub addUser(user As String, password As String, accounttype As String)
        ' Text to append
        Dim typePath As String
        If accounttype = "Defence" Then
            typePath = filePath
            ' Console.WriteLine("Account type is Defence")
        ElseIf accounttype = "NGO" Then
            typePath = ngofilePath
            ' Console.WriteLine("Account type is NGO")
        Else
            MessageBox.Show("Invalid Account type")
            typePath = filePath
        End If
        Dim textToAppend As String = user + "  NT-Password := """ + password + """"

        Try
            ' Create a StreamWriter with the Append option
            Using sw As New StreamWriter(typePath, True)
                ' Write the text to the end of the file
                sw.WriteLine(textToAppend)
            End Using

            ' Console.WriteLine("Text appended successfully.")
        Catch ex As Exception
            ' Console.WriteLine($"An error occurred: {ex.Message}")
        End Try
        fillReadout()
        uploadFile(accounttype)
        MessageBox.Show(user & " Has been added")
    End Sub

    Public Sub updatePassword(user As String, newPassword As String, accounttype As String)
        Dim typePath As String
        If accounttype = "Defence" Then
            typePath = filePath
            ' Console.WriteLine("Account type is Defence")
        ElseIf accounttype = "NGO" Then
            typePath = ngofilePath
            'Console.WriteLine("Account type is NGO")
        Else
            MessageBox.Show("Invalid Account type")
            typePath = filePath
        End If
        ' Specify the text to search for
        Dim searchText As String = user

        ' Find the line with specific text
        Dim lineNumber As Integer = FindLineWithText(typePath, searchText)


        ' Display the result
        If lineNumber > 0 Then
            'Console.WriteLine($"The text '{searchText}' was found on line {lineNumber}.")
        Else
            ' Console.WriteLine($"The text '{searchText}' was not found in the file.")
        End If

        ' Console.ReadLine()
        Dim updatedLine As String = user + "  NT-Password := """ + newPassword + """"
        UpdateLineInTextFile(typePath, lineNumber, updatedLine)
        'displayForm.library.uploadFile()
        fillReadout()
        uploadFile(accounttype)
        MessageBox.Show(user + "'s Has been updated")
    End Sub

    Private Sub fillReadout()
        ' Specify the path to the text file
        ' Dim filePath As String = "C:\temp\authorize"

        ' Check if the file exists
        If File.Exists(filePath) Then
            ' Open the file and read its contents
            Dim fileContents As String = ReadTextFile(filePath)
            'btnDelete.Text = fileContents
            ' Display the file contents
        Else
            ' Console.WriteLine("The file does not exist.")
        End If


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
            ' Console.WriteLine("An error occurred: " & ex.Message)
            Return String.Empty
        End Try


    End Function
    Public Sub closingCleanup()
        '  Console.WriteLine("Performing Closing Cleanup")
        Try
            ' Check if the file exists before attempting to delete
            If File.Exists(filePath) Then
                'Console.WriteLine("Found file to delete")
                ' Delete the file
                File.Delete(filePath)
                ' Console.WriteLine("File deleted successfully.")
            Else
                'Console.WriteLine("File does not exist.")
            End If
        Catch ex As Exception
            Console.WriteLine($"An error occurred: {ex.Message}")
        End Try
        Try
            ' Check if the file exists before attempting to delete
            If File.Exists(ngofilePath) Then
                ' Console.WriteLine("Found file to delete")
                ' Delete the file
                File.Delete(ngofilePath)
                '  Console.WriteLine("File deleted successfully.")
            Else
                ' Console.WriteLine("File does not exist.")
            End If
        Catch ex As Exception
            '  Console.WriteLine($"An error occurred: {ex.Message}")
        End Try
    End Sub

    Function ByteArrayToHexString(byteArray() As Byte) As String
        ' Convert byte array to hexadecimal string
        Dim hexString As New StringBuilder(byteArray.Length * 2)
        For Each b As Byte In byteArray
            hexString.AppendFormat("{0:X2}", b)
        Next
        Return hexString.ToString()
    End Function
    Public Function setAccountType(accountType As String)

    End Function

End Class
