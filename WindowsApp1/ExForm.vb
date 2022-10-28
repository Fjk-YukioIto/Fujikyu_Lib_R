Imports Fujikyu_Lib_R

Public Class ExForm
    Dim job As Boolean = False
    Private Sub ExForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim num As Integer = 0
        FjkDataGridView1.ColumnCount = 6
        For i = 0 To 31
            FjkDataGridView1.Rows.Add(num + 1, num + 2, num + 3, num + 4, num + 5, num + 6)
            If i Mod 3 = 0 Then
                Dim union As New UnionCell With {
                .Row = i,
                .Column = 0,
                .RowSpan = 2,
                .ColumnSpan = 1,
                .BackgroundColor = Color.LightCyan,
                .ForeColor = Color.BlueViolet}

                FjkDataGridView1.UnionCells.Add(union)

            End If
            '    If i Mod 2 = 0 Then
            '        Dim union As New UnionCell With {
            '     .Row = i,
            '     .Column = 2,
            '     .RowSpan = 1,
            '     .ColumnSpan = 3,
            '     .BackgroundColor = Color.LightGreen}

            '        FjkDataGridView1.UnionCells.Add(union)
            '    End If
            num = num + 6
        Next
    End Sub

    Private Sub FjkButton1_Click(sender As Object, e As EventArgs) Handles FjkButton1.Click
        If job Then
            FjkBarCordReader1.Stop_Reader()
        Else

            FjkBarCordReader1.Start_Reader()

        End If
        job = Not job
    End Sub

    Private Sub FjkButton2_Click(sender As Object, e As EventArgs) Handles FjkButton2.Click

        Dim result As String = FjkBarCordReader1.BarCordReadSingle
        'Dim text As String = String.Empty
        'For Each a As String In FjkBarCordReader1.BarCordReadMultiple
        '    text &= a & vbCrLf
        'Next
        MessageBox.Show(result)
    End Sub

End Class
