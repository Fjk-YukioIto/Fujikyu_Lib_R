Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports OpenCvSharp

Public Class FjkBarCordReader

#Region "ﾒﾝﾊﾞ"
    ''' <summary>
    ''' 二重取込ﾁｪｯｸ用ﾘｽﾄ
    ''' </summary>
    Dim DobCheck As New List(Of String)
    ''' <summary>
    ''' ｶﾒﾗｻｲｽﾞ幅
    ''' </summary>
    Dim CamWidth As Integer = 640
    ''' <summary>
    ''' ｶﾒﾗｻｲｽﾞ高さ
    ''' </summary>
    Dim CamHeight As Integer = 480
    ''' <summary>
    ''' ﾌﾚｰﾑ情報
    ''' </summary>
    Dim Frame As Mat
    ''' <summary>
    ''' 画像情報
    ''' </summary>
    Dim Bmp As Bitmap
    ''' <summary>
    ''' 描画用
    ''' </summary>
    Dim Graph As Graphics
    ''' <summary>
    '''ｶﾒﾗの検出
    ''' </summary>
    Dim Captures As VideoCapture
    ''' <summary>
    ''' ﾃﾞﾌｫﾙﾄｶﾗｰ退避用
    ''' </summary>
    Dim Dcolor As Color
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞ/QR分解能
    ''' </summary>
    Dim reader As New ZXing.BarcodeReader() With {
                    .AutoRotate = True,
                    .Options = New ZXing.Common.DecodingOptions With {.TryHarder = True}
                    }

#End Region

#Region "ｲﾍﾞﾝﾄ"

    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙのｻｲｽﾞが変更された時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FjkBarCordReader_Sizechanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        PB_Reader.Width = Me.Width - 6
        PB_Reader.Height = Me.Height - 6
        PB_Reader.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    ''' <summary>
    ''' ﾊﾞｯｸｸﾞﾗｳﾝﾄﾞ処理が更新された場合
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BackgroundRead_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundRead.ProgressChanged
        '描画
        Try
            Graph.DrawImage(Bmp, 0, 0, PB_Reader.Width, PB_Reader.Height)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DrawingError", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' ﾊﾞｯｸｸﾞﾗｳﾝﾄﾞ処理の実行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BackgroundRead_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundRead.DoWork
        Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)

        While Not BackgroundRead.CancellationPending
            '画像取得
            Captures.Grab()
            Internal.NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(Captures.CvPtr, Frame.CvPtr)
            bw.ReportProgress(0)


        End While

    End Sub

    ''' <summary>
    ''' ﾀｲﾏｰ経過時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.BackColor = Dcolor
        Timer1.Stop()
    End Sub


#End Region

#Region "ﾒｿｯﾄﾞ"

    ''' <summary>
    ''' 読込機能の初期化・起動
    ''' </summary>
    Public Sub Start_Reader()
        If Not BackgroundRead.IsBusy Then
            'カメラの認識：一通り確認して起動できなかった場合エラー
            For i = 0 To 30
                Captures = New VideoCapture(i)
                If Captures.IsOpened Then
                    Exit For
                End If
            Next
            If Not Captures.IsOpened Then
                MessageBox.Show("カメラを起動出来ませんでした")
                Exit Sub
            Else
                Captures.FrameWidth = CamWidth
                Captures.FrameHeight = CamHeight
            End If

            '取得先のMat作成
            Frame = New Mat(CamHeight, CamWidth, MatType.CV_8UC3)
            '表示用のBitmat作成
            Bmp = New Bitmap(Frame.Cols, Frame.Rows, CInt(Frame.Step()), Imaging.PixelFormat.Format24bppRgb, Frame.Data)
            '描画用のGraphics作成
            Graph = PB_Reader.CreateGraphics()

            'チラつき防止で初期画像を非表示
            PB_Reader.Image = Nothing

            'カメラ描画開始
            BackgroundRead.WorkerReportsProgress = True
            BackgroundRead.WorkerSupportsCancellation = True
            BackgroundRead.RunWorkerAsync()
        End If
    End Sub

    ''' <summary>
    ''' 読込機能の停止
    ''' </summary>
    Public Sub Stop_Reader()
        'ﾊﾞｯｸｸﾞﾗｳﾝﾄﾞ処理の中止：処理中の場合完了まで待機
        If BackgroundRead.IsBusy Then
            BackgroundRead.CancelAsync()
            While BackgroundRead.IsBusy
                Application.DoEvents()
            End While
            '初期画像を表示
            PB_Reader.Image = My.Resources.QRsample
            'カメラ停止
            Captures.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' 単体読込処理
    ''' </summary>
    ''' <returns></returns>
    Public Function BarCordReadSingle() As String
        Dim StrResult As String = "Error"

        '読込機能が起動していない場合エラーを返答
        If BackgroundRead.IsBusy Then
            Try
                Dim im As Image = Bmp
                ' コードの解析
                Dim result As ZXing.Result = reader.Decode(TryCast(im, Bitmap))
                Dcolor = Me.BackColor
                '読込結果の判別
                If (result IsNot Nothing) Then
                    '二重取込ﾁｪｯｸ
                    If DobCheck.Contains(result.Text) Then
                        Me.BackColor = Color.Red
                        StrResult = "Double Capture"
                        MessageBox.Show("すでに取込まれたデータです", "二重取込み", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Else '二重取込がない場合
                        DobCheck.Add(result.Text)
                        Me.BackColor = Color.Lime
                        StrResult = result.Text

                    End If

                Else '読込結果が存在しない場合
                    Me.BackColor = Color.Red
                    StrResult = "Not Found"

                End If
                '0.2秒取込成否の背景色描画
                Timer1.Interval = 200
                Timer1.Start()

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        End If

        Return StrResult

    End Function

    ''' <summary>
    ''' 複数同時読込処理
    ''' </summary>
    ''' <returns></returns>
    Public Function BarCordReadMultiple() As List(Of String)
        Dim StockResult As New List(Of String) From {"Error"}

        '読込機能が起動していない場合エラーを返答
        If BackgroundRead.IsBusy Then
            StockResult.Clear()

            Try
                Dim im As Image = Bmp
                Dim NowDob As New HashSet(Of String)
                ' コードの解析
                Dim result() As ZXing.Result = reader.DecodeMultiple(TryCast(im, Bitmap))
                Dcolor = Me.BackColor
                If (result IsNot Nothing) Then
                    Dim dob As Boolean = False
                    '二重取込ﾁｪｯｸ
                    For i = 0 To result.Count - 1
                        If DobCheck.Contains(result(i).Text) Or (NowDob.Add(result(i).Text) = False) Then
                            dob = True
                            Exit For
                        End If
                    Next

                    '二重取込が存在した場合
                    If dob Then
                        Me.BackColor = Color.Red
                        StockResult.Add("Double Capture")
                        MessageBox.Show("すでに取込まれたデータが含まれています", "二重取込み", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Else '二重取込が存在しない場合
                        Me.BackColor = Color.Lime
                        For i = 0 To result.Count - 1
                            StockResult.Add(result(i).Text)
                            DobCheck.Add(result(i).Text)
                        Next

                    End If
                Else
                    Me.BackColor = Color.Red
                End If

                '0.2秒読込成否を背景色描画
                Timer1.Interval = 200
                Timer1.Start()

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                '読込結果が存在しない場合
                If StockResult.Count = 0 Then StockResult.Add("Not Found")
            End Try
        End If
        Return StockResult

    End Function

#End Region

End Class