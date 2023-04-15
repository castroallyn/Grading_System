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
            tblevel.Clear()
        End If
    End Sub
    ' end of alyssandra

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        ' checking kung open yung database para fresh start si connection if need i-open
        ' If connection.State = System.Data.ConnectionState.Open Then connection.Close()

        ' itong code na to is para sa pag check ng textbox kung may laman. kapag si tbname, subject etc. ay may laman mag sho-show ng confirmation message else mag sho-show ng error message
        If ((tbname.Text.Length > 0) And (ComboBox1.SelectedItem.ToString.Length > 0) And (tblevel.Text.Length > 0) And (tbprelim.Text.Length > 0) And (tbmidterm.Text.Length > 0) And (tbsemis.Text.Length > 0) And (tbfinal.Text.Length > 0)) Then
            ' Saving student information
            Dim response As Byte

            response = MessageBox.Show("Are you sure you want to save student information?", "Save Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If response = DialogResult.Yes Then


                Dim studId As Integer = findStudentIdByName(tbname.Text)

                ' checking if meron ng data si student sa database
                ' if meron, grades nalang ang ise-save
                ' if wala pa, ise-save ang student info and grades
                If studId > 0 Then
                    Debug.Print("is saving grades only? should have grades not equal to 0: " + studId.ToString)
                    saveStudentGrades()
                Else
                    Debug.Print("is saving student and grades? should have no existing student: " + studId.ToString)
                    saveStudent()
                End If

            End If
            ' end of saving student
        Else
            MessageBox.Show("Cannot be Save. Text box is empty", "Failed to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadStudentListTable()

        ' dev by allyn
        ' nag ddisplay ng list of subjects from database
        Dim get_subject_list_query As String = "SELECT id, subject FROM subjects"
        connection.Open()
        Dim command As New OdbcCommand(get_subject_list_query, connection)

        Dim reader = command.ExecuteReader()
        While reader.Read()
            ComboBox1.Items.Add(reader("subject").ToString)

        End While
        reader.Close()
        connection.Close()
        ' end ng nag di-display ng subject

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

    ' dev by alexander
    Private Sub reloadTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reloadTable.Click

        Debug.Print("Trying to reload DataGridView")
        ' reload function for student table
        loadStudentListTable()
        Debug.Print("DataGridView Reloaded Successfully")
    End Sub
    ' end of alexander

    ' function na kumukuha ng student id na base sa name
    Private Function findStudentIdByName(ByVal name As String)

        Dim selectStudentQuery As String = "SELECT u.id from users u WHERE u.name = ?"

        Dim studId As Integer

        Using command As New OdbcCommand(selectStudentQuery, connection)

            connection.Open()
            command.Parameters.AddWithValue("@u.name", name)
            Dim reader = command.ExecuteReader()

            While reader.Read()
                Debug.Print("Response : " + reader("id").ToString)
                studId = reader("id")
            End While
            ' close the connection after saving
            reader.Close()
            connection.Close()
        End Using

        Return studId
    End Function

    ' function na nag se-save ng users or student
    Private Sub saveStudent()
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
                Dim rows As Integer = command.ExecuteNonQuery()
                Debug.Print("Affect row: " + rows.ToString)
            End Using
            Debug.Print("Student: " + name + " Successfully save...")
            ' close the connection after saving
            connection.Close()
        End Using
        ' save grades after saving student info
        saveStudentGrades()
        ' end of saving student
    End Sub

    ' function na nag se-save ng grades ni student
    Private Sub saveStudentGrades()
        ' **Start SQL Command pang save ng student grades
        Dim student_grades_query As String = "INSERT INTO grades (subjectid, studentid, prelim, midterm, semis, final, level, year) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" 'save grades

        Dim studId As Integer = findStudentIdByName(tbname.Text)
        ' variables na humahawak sa data ng student info before saving grades
        Dim studentId As Integer = studId
        Dim subjectid As Integer = getSubjectId(ComboBox1.SelectedItem.ToString)
        Dim prelim As String = tbprelim.Text
        Dim midterm As String = tbmidterm.Text
        Dim semis As String = tbsemis.Text
        Dim final As String = tbfinal.Text
        Dim level As String = tblevel.Text
        Dim year As String = "2022-2023"

        'initiator of connection to database
        Using connection As New OdbcConnection(connectionString)
            ' prepare connection before saving
            connection.Open()
            ' preparation of command for query and parameter
            Using command As New OdbcCommand(student_grades_query, connection)
                command.Parameters.AddWithValue("@subjectid", subjectid)
                command.Parameters.AddWithValue("@studentid", studentId)
                command.Parameters.AddWithValue("@prelim", prelim)
                command.Parameters.AddWithValue("@midterm", midterm)
                command.Parameters.AddWithValue("@semis", semis)
                command.Parameters.AddWithValue("@final", final)
                command.Parameters.AddWithValue("@level", level)
                command.Parameters.AddWithValue("@year", year)
                Debug.Print("Student Info ID: " + studentId.ToString)
                ' execute query command
                Debug.Print("Affect row: " + command.ExecuteNonQuery().ToString)
            End Using
            Debug.Print("Student: " + Name + " Grade Successfully save...")
            ' close the connection after saving
            connection.Close()
        End Using

    End Sub

    ' dev by allyn
    ' function na nag babalik ng selected item sa combo box ni subject
    Private Function getSubjectId(ByVal subject_name As String)

        Dim subId As Integer

        ' SQL query na kumukuha ng id ng selected subject
        Dim get_subject_id_query As String = "SELECT id FROM subjects WHERE subject = ?"
        ' execute yung query using yung OdbcCommand

        Using command As New OdbcCommand(get_subject_id_query, connection)
            connection.Open()
            command.Parameters.AddWithValue("@subject", subject_name)
            Dim reader = command.ExecuteReader()

            While reader.Read()
                Debug.Print("Subject ID : " + reader("id").ToString)
                subId = reader("id")
            End While
            ' close the connection after getting subject id
            reader.Close()
            connection.Close()
        End Using

        Return subId
        ' end of allyn
    End Function


    ' function na naglo-load ng table
    Private Sub loadStudentListTable()
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
            row("Sem Grade") = semGrade
            row("Gen Ave") = genAve
            row("Remarks") = remarks
        Next

        ' close connection to database para ma avoid yung memory leak
        connection.Close()

    End Sub

End Class