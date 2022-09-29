Imports Fujikyu_Lib_R
Imports Fujikyu_Lib_R.SQLGeneralrProcesser


Public Class ExForm

    Private Sub ExForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(GetType(ExportFiles).GetType.Assembly.GetName.Name.ToString)
        TimeTest.Interval = 1
        TimeTest.Start()
    End Sub


    Private Sub FjkButton1_Click_1(sender As Object, e As EventArgs) Handles FjkButton1.Click
        Dim ofd As New OpenFileDialog() With {
            .FileName = "default.csv",
            .InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
           .Title = "ｃｓｖ選択",
           .RestoreDirectory = True,
           .CheckFileExists = True,
           .CheckPathExists = True}

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim t As DataTable = InportData.ReadCsv(ofd.FileName, False)
            DataGridView1.DataSource = t
        End If
    End Sub

    Private Sub TimeTest_Tick(sender As Object, e As EventArgs) Handles TimeTest.Tick
        Dim posX As Integer = Panel1.Location.X - 2

        'If posX > 661 Then posX = -100
        If posX <= 300 Then TimeTest.Stop()
        Panel1.Location = New Point(posX, Panel1.Location.Y)

    End Sub
End Class
