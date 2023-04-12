Imports System.Data
Imports System.Data.Odbc

' Guys pag may star na dalawa meaning important code wag gagalawin (example: **Save Student)

Public Class Form2

    ' Create a connection to the database
    Dim connectionString As String = "Driver={MySQL ODBC 8.0 ANSI Driver};Server=localhost:3309;Database=m1_gradingsystem_db;Uid=root;"

    ' Create ng instance or bagong object para sa connection ng database
    Dim connection As New OdbcConnection(connectionString)

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computeBtn.Click

        'Dim response As Byte

        'response = MessageBox.Show("All Entries Correct", "Compute", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If response = DialogResult.Yes Then
        If ((tbprelim.Text.Length > 0) And (tbmidterm.Text.Length > 0) And (tbsemis.Text.Length > 0) And (tbfinal.Text.Length > 0)) Then

            tbsemgrade.Text = (tbprelim.Text / 100) * 25 + (tbmidterm.Text / 100) * 25 + (tbsemis.Text / 100) * 25 + (tbfinal.Text / 100) * 25

            tbgenave.Text = ComputeGeneralAverage(tbsemgrade.Text)
            tbremarks.Text = GetRemarks(tbsemgrade.Text)

        Else
            MessageBox.Show("Cannot Compute. Text box are Empty.", "Failed to Compute Grades", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim response As Byte
        response = MessageBox.Show("You want to exit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        Me.Close()
        Form1.Refresh()
        Form1.Show()
    End Sub
    'dev by alyssandra
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim response As Byte
        response = MessageBox.Show("Are you sure you want to create a new record?", "New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If response = DialogResult.Yes Then
            tbname.Clear()
            tbgenave.Clear()
            tbgenave.Focus()
            tbprelim.Clear()
            tbmidterm.Clear()
            tbsemis.Clear()
            tbfinal.Clear()
            tbsemgrade.Clear()
            tbgenave.Clear()
            tbremarks.Clear()
            tbsubject.Clear()
            tblevel.Clear()

        End If
    End Sub
    ' end of alyssandra

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        ' checking kung open yung database para fresh start si connection if need i-open
        ' If connection.State = System.Data.ConnectionState.Open Then connection.Close()

        ' itong code na to is para sa pag check ng textbox kung may laman. kapag si tbname, tbsubject etc. ay may laman mag sho-show ng confirmation message else mag sho-show ng error message
        If ((tbname.Text.Length > 0) And (tbsubject.Text.Length > 0) And (tblevel.Text.Length > 0) And (tbprelim.Text.Length > 0) And (tbmidterm.Text.Length > 0) And (tbsemis.Text.Length > 0) And (tbfinal.Text.Length > 0)) Then
            ' Saving student information
            Dim response As Byte

            response = MessageBox.Show("Are you sure you want to save student information?", "Save Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If response = DialogResult.Yes Then

                ' **Start SQL Command pang save ng student
                ' kapag existing na sa database yung user hindi na sya mase-save yung grade nalang.
                Dim student_details_query As String = "INSERT INTO users (name, role, password) VALUES (?, ?, ?)"


                Dim name As String = tbname.Text
                Dim role As String = "student" ' default when saving student
                Dim password As String = "password" ' default password

                ' "Using" statement to automatically dispose the OdbcConnection and OdbcCommand objects and release the resources or memory they are using
                Using connection As New OdbcConnection(connectionString)
                    ' prepare connectio before saving
                    connection.Open()
                    Using command As New OdbcCommand(student_details_query, connection)
                        command.Parameters.AddWithValue("@name", name)
                        command.Parameters.AddWithValue("@role", role)
                        command.Parameters.AddWithValue("@password", password)
                        Debug.Print("Affect row: " + command.ExecuteNonQuery().ToString)
                    End Using
                    Debug.Print("Student: " + name + " Successfully save...")
                    ' close the connection after saving
                    connection.Close()
                End Using
                ' end of saving student

                ' **Start SQL Command pang save ng student grades
                Dim student_grades_query As String = "" ' save grades

                ' end of saving student
            End If
        Else
            MessageBox.Show("Cannot be Save. Text box is empty", "Failed to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' dev by denn
        tbsemgrade.Enabled = False

        ' checking kung open yung database para fresh start si connection if need i-open
        If connection.State = System.Data.ConnectionState.Open Then connection.Close()

        ' Open the connection
        connection.Open()

        ' SQL command para makuha sa database yung kailangan na data like colums saka rows
        Dim query As String = "SELECT u.id, u.name, g.prelim, g.midterm, g.semis, g.final, s.subject, g.level FROM users u JOIN grades g ON u.id = g.studentid JOIN subjects s ON g.subjectid = s.id WHERE u.role = 'student'"
        ' end of denn

        ' execute yung query using yung OdbcCommand
        Dim command As New OdbcCommand(query, connection)

        ' gumamit ng reader para mai-loop yung laman ng database
        Dim adapter As New OdbcDataAdapter(command)

        ' Gumawa ng kamukhang object ni DataTable
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ' Add columns to the DataTable '
        dataTable.Columns.Add("Sem Grade", GetType(Integer))
        dataTable.Columns.Add("Gen Ave", GetType(String))
        dataTable.Columns.Add("Remarks", GetType(String))

        ' modify column names
        Dim columns As DataColumnCollection = dataTable.Columns
        columns("id").ColumnName = "Student ID"
        columns("name").ColumnName = "Name"
        columns("prelim").ColumnName = "Prelim"
        columns("midterm").ColumnName = "Midterm"
        columns("semis").ColumnName = "Semis"
        columns("final").ColumnName = "Finals"
        columns("subject").ColumnName = "Subject"
        columns("level").ColumnName = "Year Level"

        DataGridView1.DataSource = dataTable

        ' Para automatic na ma resize yung colums according sa size ng grid view
        ' Pag tinanggal to mag kakaroon ng scroll bar sa baba ng table.
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next

        ' ito yung nag po-populate ng data sa grid view using for loop
        For Each row As DataRow In dataTable.Rows
            Dim prelim As Integer = CInt(row("prelim"))
            Dim midterm As Integer = CInt(row("midterm"))
            Dim semis As Integer = CInt(row("semis"))
            Dim final As Integer = CInt(row("Finals"))
            Dim semGrade As Double = (prelim + midterm + semis + final) / 4
            Dim genAve As String = ComputeGeneralAverage(semGrade)
            Dim remarks As String = GetRemarks(semGrade)
            Debug.Print(CStr(semGrade) + " " + genAve + " " + remarks)
            row("Sem Grade") = semGrade
            row("Gen Ave") = genAve
            row("Remarks") = remarks
        Next

        ' close connection to database para ma avoid yung memory leak
        connection.Close()

    End Sub

    ' develop by janses 
    Private Sub tbprelim_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbprelim.KeyPress

        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field will accept numbers only")
        End If
    End Sub
    Private Sub tbmidterm_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbmidterm.KeyPress

        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field will accept numbers only")
        End If
    End Sub
    Private Sub tbsemis_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbsemis.KeyPress

        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field will accept numbers only")
        End If
    End Sub
    Private Sub tbfinal_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbfinal.KeyPress

        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field will accept numbers only")
        End If
    End Sub
    ' end of janses
End Class