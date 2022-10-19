Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms

Public Class ExportFiles

#Region "ﾒﾝﾊﾞ"

#End Region

#Region "ﾒｿｯﾄﾞ"

    ''' <summary>
    ''' 保存先、データ、使用するレポート名からPDFを出力します。
    ''' </summary>
    ''' <param name="Pad">保存先アドレス</param>
    ''' <param name="table">出力するデータテーブル</param>
    ''' <param name="CRnm">使用するクリスタルレポート名</param>
    Public Shared Sub ExportPDF(ByVal Pad As String, ByVal table As DataTable, ByRef CRnm As String)

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        Dim asm As System.Reflection.Assembly
        Dim t As Type
        Dim obj As Object
        Dim CR As ReportClass

        Try
            'ファイルの存在ﾁｪｯｸ　
            If System.IO.File.Exists(Pad) Then
                '既にファイルが存在していた場合
                Dim dr As DialogResult
                dr = MessageBox.Show(Pad & "は既に存在します。上書きしますか？", "確認",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2)
                Select Case dr
                '削除して再生成
                    Case DialogResult.Yes
                        System.IO.File.Delete(Pad)

                '処理を中断
                    Case DialogResult.No
                        Exit Sub
                End Select
            End If

            'ファイルの出力先を設定
            CrDiskFileDestinationOptions.DiskFileName = Pad

            'exeに関する情報を取得
            asm = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.ExecutablePath)
            '出力するレポートの型を取得
            t = asm.GetType(CRnm)
            'ｲﾝｽﾀﾝｽの生成
            obj = System.Activator.CreateInstance(t)
            'クリスタルレポートを生成
            CR = CType(obj, ReportClass)

            'セクションを設定
            Dim section As CrystalDecisions.CrystalReports.Engine.Section = CR.ReportDefinition.Sections.Item("Section1")
            '出力データをクリスタルレポートにバインド
            CR.SetDataSource(table)
            'PDF出力
            CrExportOptions = CR.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            CR.Export()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' データテーブルをCSVに変換して出力
    ''' </summary>
    ''' <param name="Pad">ファイルの出力先アドレス</param>
    ''' <param name="Table">出力するデータのDatatable</param>
    ''' <param name="IsWriteHeader">列名を記載するか否か(true省略可)</param>
    Public Shared Sub ExportCSV(ByVal Pad As String, ByVal Table As DataTable, Optional ByVal IsWriteHeader As Boolean = True)

        Try

            Dim Encoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

            'ファイルの存在ﾁｪｯｸ　
            If System.IO.File.Exists(Pad) Then
                '既にファイルが存在していた場合
                Dim dr As DialogResult
                dr = MessageBox.Show(Pad & "は既に存在します。上書きしますか？", "確認",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2)
                Select Case dr
                '削除して再生成
                    Case DialogResult.Yes
                        System.IO.File.Delete(Pad)

                '処理を中断
                    Case DialogResult.No
                        Exit Sub
                End Select
            End If

            '書き込むファイルを開く
            Dim Writer As New System.IO.StreamWriter(Pad, False, Encoding)

            Dim ColCnt As Integer = Table.Columns.Count
            Dim LastCol As Integer = ColCnt - 1
            Dim i As Integer = 0

            Dim IsNeedC As Boolean = True

            'ヘッダを書き込む
            If IsWriteHeader Then
                For Each col As DataColumn In Table.Columns
                    'カンマ付与
                    If IsNeedC Then
                        Writer.Write(","c)
                    End If
                    'ヘッダの取得
                    Dim field As String = col.Caption
                    '"で囲み書き込む
                    field = EncloseDoubleQuotes(field)
                    Writer.Write(field)

                Next
                '改行
                Writer.Write(vbCrLf)
            End If

            'レコードを書き込む
            Dim row As DataRow
            For Each row In Table.Rows
                For i = 0 To ColCnt - 1
                    'フィールドの取得
                    Dim field As String = row(i).ToString()
                    '"で囲み書き込む
                    field = EncloseDoubleQuotes(field)
                    Writer.Write(field)
                    'カンマ付与
                    If LastCol > i Then
                        Writer.Write(","c)
                    End If
                Next
                '改行
                Writer.Write(vbCrLf)
            Next

            '閉じる
            Writer.Close()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    ''' <summary>
    ''' 文字列をダブルクォーテーションで囲む
    ''' </summary>
    Private Shared Function EncloseDoubleQuotes(field As String) As String
        Return "" & field & ""
    End Function


#End Region

End Class
