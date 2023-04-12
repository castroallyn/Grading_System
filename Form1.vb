Imports System.Data
Imports System.Data.Odbc


Public Class Form1

    ' Create a connection to the database
    Dim connectionString As String = "Driver={MySQL ODBC 8.0 ANSI Driver};Server=localhost:3309;Database=m1_gradingsystem_db;Uid=root;"

    ' Create ng instance or bagong object para sa connection ng database
    Dim connection As New OdbcConnection(connectionString)

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            tbpassword.PasswordChar = "*"
        Else
            tbpassword.PasswordChar = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim find_username_password As String = "SELECT * FROM users WHERE name = ? AND password = ?"
        Dim rowCount As Integer = 0
        Dim name As String = tbusername.Text
        Dim password As String = tbpassword.Text


        Using connection As New OdbcConnection(connectionString)
            ' prepare connectio before saving
            connection.Open()
            Using command As New OdbcCommand(find_username_password, connection)
                command.Parameters.AddWithValue("@name", Name)
                command.Parameters.AddWithValue("@password", password)
                Dim reader = command.ExecuteReader()

                While reader.Read()
                    rowCount += 1
                    Dim username_from_db As String = reader("name").ToString
                    Dim userpass_from_db As String = reader("password").ToString
                    Dim role As String = reader("role").ToString
                    Dim studentId As Integer = reader("id")

                    If (username_from_db.Length > 0) And (userpass_from_db.Length > 0) Then
                        If role = "prof" Then ' kapag ang role or user type ay prof mag redirect sya sa Form2, if student pupunta sya sa Form3
                            Form2.Show()
                            tbusername.Clear() ' clear username after login
                            tbpassword.Clear() ' clear password after login
                            CheckBox1.Checked = False ' reset check box after login
                            Me.Hide()
                        Else
                            Form3.SetUsernamePasswordToForm3(username_from_db, userpass_from_db, studentId)
                            Form3.Show()
                            tbusername.Clear() ' clear username after login
                            tbpassword.Clear() ' clear password after login
                            CheckBox1.Checked = False ' reset check box after login
                            Me.Hide()
                        End If
                    End If

                End While

            End Using
            ' close the connection after fetching
            connection.Close()
        End Using

        If rowCount = 0 Then
            MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub
End Class
