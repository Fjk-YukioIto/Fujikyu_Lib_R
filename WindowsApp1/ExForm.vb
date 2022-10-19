Imports Fujikyu_Lib_R
Imports Fujikyu_Lib_R.SQLGeneralProcesser


Public Class ExForm

    Private Sub ExForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        'FjkBarCordReader1.Init_Reader()
        Dim num As Integer = 0
        FjkDataGridView1.ColumnCount = 4
        For i = 0 To 30
            FjkDataGridView1.Rows.Add(num + 1, num + 2, num + 3, num + 4)
            num = num + 4
        Next
        Dim hc As HeaderCell = New HeaderCell
        FjkDataGridView1.HeaderCells.Add(hc)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As List(Of String) = FjkBarCordReader1.BarCordReadMultiple
        Dim st As String = String.Empty

        For Each s As String In result
            st &= s & vbCrLf
        Next
        MessageBox.Show(st)
    End Sub

    Private Sub FjkButton1_Click(sender As Object, e As EventArgs) Handles FjkButton1.Click
        FjkBarCordReader1.Init_Reader()
    End Sub
End Class
