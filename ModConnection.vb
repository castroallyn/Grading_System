Imports System.Data.Odbc

Module ModConnection
    Public Sub connect_me()
        If con.State = System.Data.ConnectionState.Open Then con.Close()
        constring = "driver=MySQL ODBC 8.0 ANSI Driver;localhost;port=3309;uid='root';pwd=password=m1_gradingsystem_db"
        con.ConnectionString = constring
        con.Open()
    End Sub
End Module
