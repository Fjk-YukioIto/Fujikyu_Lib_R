Imports Fujikyu_Lib_R

Public Class ExForm

    Private Sub ExForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        'FjkBarCordReader1.Init_Reader()
        Dim hc As HeaderCell = New HeaderCell With {
            .Column = 0,
            .Row = 0,
            .ColumnSpan = 2,
            .RowSpan = 1,
            .Text = "結合",
            .TextAlign = DataGridViewContentAlignment.MiddleCenter
        }
        FjkDataGridView1.HeaderCells.Add(hc)
        Dim num As Integer = 0
        FjkDataGridView1.ColumnCount = 6
        For i = 0 To 30
            FjkDataGridView1.Rows.Add(num + 1, num + 2, num + 3, num + 4)
            num = num + 4
        Next
    End Sub



End Class
