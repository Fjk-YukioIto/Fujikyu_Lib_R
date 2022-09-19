Imports Fujikyu_Lib_R
Public Class ExForm

    Private Sub ExForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show(GetType(ExportFiles).GetType.Assembly.GetName.Name.ToString)
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
            Dim t As DataTable = Fujikyu_Lib_R.InportData.ReadCsv(ofd.FileName, False)
            DataGridView1.DataSource = t
        End If
    End Sub
End Class
