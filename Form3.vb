Imports System.Data
Imports System.Data.Odbc

Public Class Form3

    ' Create a connection to the database
    Dim connectionString As String = "Driver={MySQL ODBC 8.0 ANSI Driver};Server=localhost:3309;Database=m1_gradingsystem_db;Uid=root;"

    ' Create ng instance or bagong object para sa connection ng database
    Dim connection As New OdbcConnection(connectionString)

    Dim s_username As String
    Dim s_password As String
    Dim s_id As Integer

    Public Sub SetUsernamePasswordToForm3(ByVal username As String, ByVal password As String, ByVal studentId As Integer)
        Me.s_username = username
        Me.s_password = password
        Me.s_id = studentId
    End Sub

    'dev by alliana
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Refresh()
        Form1.Show()
    End Sub

    ' end of alliana

    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        ' Call the Refresh method on the main form
        Me.Refresh()
    End Sub
    ' dev by allyn
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tbname_s.Text = s_username.ToUpper

        ' ** SQL command para ma select ang grades from grades table with subjects details
        Dim student_grades_query As String = "SELECT s.subject, g.prelim, g.midterm, g.semis, g.final, g.level, g.year FROM grades g JOIN subjects s ON g.subjectid = s.id WHERE g.studentid = ? ORDER BY s.subject"

        ' execute yung query using yung OdbcCommand
        Dim command As New OdbcCommand(student_grades_query, connection)
        command.Parameters.AddWithValue("@g.studentid", s_id)

        ' gumamit ng reader para mai-loop yung laman ng database
        Dim adapter As New OdbcDataAdapter(command)

        ' Gumawa ng kamukhang object ni DataTable
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ' Add columns to the DataTable '
        dataTable.Columns.Add("Sem Grade", GetType(Integer))
        dataTable.Columns.Add("Gen Ave", GetType(String))
        dataTable.Columns.Add("Remarks", GetType(String))


        Dim columns As DataColumnCollection = dataTable.Columns

        ' arrange columns
        columns("year").SetOrdinal(0)
        columns("level").SetOrdinal(1)
        columns("subject").SetOrdinal(2)
        columns("prelim").SetOrdinal(3)
        columns("midterm").SetOrdinal(4)
        columns("semis").SetOrdinal(5)
        columns("final").SetOrdinal(6)

        ' rename column names
        columns("subject").ColumnName = "Subject"
        columns("level").ColumnName = "Year Level"
        columns("year").ColumnName = "School Year"
        columns("prelim").ColumnName = "Prelim"
        columns("midterm").ColumnName = "Midterm"
        columns("semis").ColumnName = "Semis"
        columns("final").ColumnName = "Finals"
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
    'end of allyn

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
