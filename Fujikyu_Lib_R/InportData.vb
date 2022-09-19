Public Class InportData

    ''' <summary>
    ''' CSVファイルの読込:Datatableで渡す
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <param name="HasHeader"></param>
    ''' <returns></returns>
    Public Shared Function ReadCsv(ByVal FilePath As String, ByVal HasHeader As Boolean) As DataTable
        Dim Dt As DataTable = New DataTable
        Using parser As New FileIO.TextFieldParser(FilePath, System.Text.Encoding.GetEncoding("shift_jis"))
            'カンマ区切り
            parser.TextFieldType = FileIO.FieldType.Delimited
            parser.SetDelimiters(",")
            'ダブルクォーテーション囲い
            parser.HasFieldsEnclosedInQuotes = True
            'フィールドの空白を削除（トリム）
            parser.TrimWhiteSpace = True

            Dim i As Integer
            Dim Dr As DataRow
            Dim currentRow As String()
            Dim cols As Integer '項目数(column)

            '1行目を読み込む（文字列の配列として返して、カーソルを次の行に進める）
            currentRow = parser.ReadFields()

            '----- 1行目がヘッダーの場合 -----
            'データテーブルのcolumnとする
            If HasHeader = True Then
                For Each currentField As String In currentRow
                    Dt.Columns.Add(New DataColumn(currentField, GetType(String)))
                Next
            Else
                '------ 1行目がヘッダーではない場合 -----
                'カラム数を取得 
                cols = currentRow.Length
                'データテーブルのダミーのcolumn
                For i = 1 To cols
                    Dt.Columns.Add(New DataColumn("Column" + i.ToString, GetType(String)))
                Next

                'データテーブルに、CSV1行目を追加 i = 0
                i = 0
                Dr = Dt.NewRow
                For Each currentField As String In currentRow
                    Dr(i) = currentField
                    i += 1
                Next
                Dt.Rows.Add(Dr)
            End If

            '2行目以降ファイルの終端までループ
            While Not parser.EndOfData

                '1行を読み込み、それを文字列の配列として返して、カーソルを次の行に進める。
                currentRow = parser.ReadFields()
                i = 0
                Dr = Dt.NewRow
                For Each currentField As String In currentRow
                    Dr(i) = currentField
                    i += 1
                Next
                Dt.Rows.Add(Dr)
            End While

        End Using
        Return Dt
    End Function

End Class
