Imports System.Data.Odbc

Module ModPublicVariable
    Public con As New OdbcConnection
    Public constring As String

    ' Function para ma compute ang general average
    Public Function ComputeGeneralAverage(ByVal semGrade As Integer) As String
        Dim generalAverage As String

        If semGrade = 100 Then
            generalAverage = "1.00"
        ElseIf semGrade >= 98 Then
            generalAverage = "1.25"
        ElseIf semGrade >= 95 Then
            generalAverage = "1.50"
        ElseIf semGrade >= 93 Then
            generalAverage = "1.75"
        ElseIf semGrade >= 90 Then
            generalAverage = "2.00"
        ElseIf semGrade >= 88 Then
            generalAverage = "2.25"
        ElseIf semGrade >= 85 Then
            generalAverage = "2.50"
        ElseIf semGrade >= 83 Then
            generalAverage = "2.75"
        ElseIf semGrade >= 80 Then
            generalAverage = "3.00"
        ElseIf semGrade >= 78 Then
            generalAverage = "3.25"
        ElseIf semGrade >= 75 Then
            generalAverage = "3.50"
        Else
            generalAverage = "5.00"
        End If
        Return generalAverage
    End Function

    ' Funtion para ma get yung remarks
    Public Function GetRemarks(ByVal semGrade As Integer) As String
        Dim remarks As String

        If semGrade >= 75 Then
            remarks = "Passed"
        Else
            remarks = "Failed"
        End If
        Return remarks
    End Function



End Module
