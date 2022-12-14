Imports System
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

Public Class FjkDataGridView
    Inherits System.Windows.Forms.DataGridView

#Region "ﾒﾝﾊﾞ"

#Region "列ﾍｯﾀﾞ"
    Private _item As New MyCollection(Me)
    ''' <summary>
    ''' 列ヘッダに表示するCellを設定します
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("セルのカスタマイズ")>
    <Description("列ヘッダに表示するCellを設定します")>
    Public ReadOnly Property HeaderCells() As MyCollection
        Get
            Return _item
        End Get
    End Property

    Friend Sub OnCollectionChanged()
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' 列ヘッダ：コレクションの設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MyCollection
        Inherits System.Collections.ObjectModel.Collection(Of HeaderCell)

        Private _parent As FjkDataGridView

        Friend Sub New(ByVal parent As FjkDataGridView)
            _parent = parent
        End Sub

        Protected Overrides Sub ClearItems()
            MyBase.ClearItems()
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As HeaderCell)
            MyBase.InsertItem(index, item)
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            MyBase.RemoveItem(index)
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As HeaderCell)
            MyBase.SetItem(index, item)
            _parent.OnCollectionChanged()
        End Sub

    End Class

    Private _ColumnHeaderCustom As Boolean = False
    ''' <summary>
    ''' セルのカスタマイズを適用するか判定する
    ''' </summary>
    ''' <returns></returns>
    <Category("セルのカスタマイズ")>
    <Description("セルのカスタマイズの適用を決定します")>
    Public Property ColumnHeaderCustom As Boolean
        Get
            Return _ColumnHeaderCustom
        End Get
        Set(value As Boolean)
            _ColumnHeaderCustom = value
        End Set
    End Property

    Private _columnHeaderRowCount As Integer = 1
    ''' <summary>
    ''' 列ヘッダーの行数を設定します
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セルのカスタマイズ")>
    <Description("列ヘッダに表示する行を設定します")>
    Public Property ColumnHeaderRowCount As Integer
        Get
            Return _columnHeaderRowCount
        End Get
        Set(ByVal value As Integer)



            _columnHeaderRowCount = value

            If value = 0 Then
                _columnHeaderRowCount = 1
            End If

            MyBase.ColumnHeadersHeight = value * ColumnHeaderRowHeight + 2
            MyBase.Refresh()
        End Set
    End Property

    Private _columnHeaderRowHeight As Integer = 17
    ''' <summary>
    ''' 列ヘッダに表示する行の高さ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セルのカスタマイズ")>
    <Description("列ヘッダに表示する行の高さを設定します")>
    Public Property ColumnHeaderRowHeight As Integer
        Get
            Return _columnHeaderRowHeight
        End Get
        Set(ByVal value As Integer)
            _columnHeaderRowHeight = value

            MyBase.ColumnHeadersHeight = value * ColumnHeaderRowCount + 2
            MyBase.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' 列ヘッダーの境界線の種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum HeaderCellBorderStyle
        SingleLine = 0
        DoubleLine = 1
    End Enum

    Private _columnHeaderBorderStyle As HeaderCellBorderStyle = HeaderCellBorderStyle.SingleLine
    ''' <summary>
    ''' 列ヘッダーの線種
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セルのカスタマイズ")>
    <Description("列ヘッダに線種を設定します")>
    Public Property ColumnHeaderBorderStyle As HeaderCellBorderStyle
        Get
            Return _columnHeaderBorderStyle
        End Get
        Set(ByVal value As HeaderCellBorderStyle)
            _columnHeaderBorderStyle = value
            MyBase.Refresh()
        End Set
    End Property

#End Region

#Region "ｾﾙ結合"

    Private _Cells As New CellsCollection(Me)
    ''' <summary>
    ''' セルを指定して結合表示します
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("セルのカスタマイズ")>
    <Description("セルを指定して結合表示します")>
    Public ReadOnly Property UnionCells() As CellsCollection
        Get
            Return _Cells
        End Get
    End Property

    ''' <summary>
    ''' セル結合：コレクションの設定
    ''' </summary>
    Public Class CellsCollection
        Inherits System.Collections.ObjectModel.Collection(Of UnionCell)

        Private _parent As FjkDataGridView
        Friend Sub New(ByVal parent As FjkDataGridView)
            _parent = parent
        End Sub

        Protected Overrides Sub ClearItems()
            MyBase.ClearItems()
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As UnionCell)
            MyBase.InsertItem(index, item)
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            MyBase.RemoveItem(index)
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As UnionCell)
            MyBase.SetItem(index, item)
            _parent.OnCollectionChanged()
        End Sub

    End Class

    Private _cellUnion As Boolean = False
    ''' <summary>
    ''' セル結合の適用を決定します
    ''' </summary>
    ''' <returns></returns>
    <Category("セルのカスタマイズ")>
    <Description("セル結合の適用を決定します")>
    Public Property CellUnion As Boolean
        Get
            Return _cellUnion
        End Get
        Set(value As Boolean)
            _cellUnion = value
        End Set
    End Property

#End Region

#End Region

#Region "ｲﾍﾞﾝﾄ"

    ''' <summary>
    ''' ｼｮｰﾄｶｯﾄｷｰの操作を実装
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CopyPaste_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
            'Controlキーが押されているか確認
            If e.Control = True Then
                Try
                    Select Case e.KeyCode
                   '貼付け
                        Case Keys.V
                            SetClipDataToDGV()

                   '切取り
                        Case Keys.X
                            CutDataFromDGV()

                    End Select
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If


        End Sub

    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙが追加された時
    ''' </summary>
    Protected Overrides Sub InitLayout()
            MyBase.InitLayout()

            'ｺﾝﾃｷｽﾄﾒﾆｭｰを設定
            Dim con As New ContextMenuStrip
            con.Items.Add("コピー(&C)", Nothing, New System.EventHandler(AddressOf ContextMenuCopy_Click))
            con.Items.Add("切り取り(&X)", Nothing, New System.EventHandler(AddressOf CutDataFromDGV))
            con.Items.Add("貼り付け(&V)", Nothing, New System.EventHandler(AddressOf SetClipDataToDGV))
        Me.ContextMenuStrip = con

    End Sub

    ''' <summary>
    ''' ｾﾙ描画
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        Dim dv As DataGridView = CType(sender, DataGridView)

        'データグリッドビューのデータが存在していない場合処理しない
        If AllowUserToAddRows Then
            If Rows.Count <= 1 Then Exit Sub
        Else
            If Rows.Count <= 0 Then Exit Sub
        End If

        Dim rect As Rectangle
        Dim cell As DataGridViewCell
        Dim draw As Boolean = True
        Dim bkColor As Color = Color.Empty
        Dim frColor As Color = Color.Empty
        Dim Union As UnionCell
        Dim TFflag As TextFormatFlags

        'ｾﾙ結合を行うか判断
        If _cellUnion Then

            'セル結合を行う：UnionCellsから該当する場所で結合セルを描画
            For i = 0 To UnionCells.Count - 1

                Union = UnionCells(i)
                '列幅・行高のいずれかが0以下の場合または
                '列・行の位置がDataGridViewの範囲外の場合処理を飛ばす
                If Union.RowSpan <= 0 OrElse Union.ColumnSpan <= 0 OrElse
                    Union.Row >= dv.Rows.Count - 1 OrElse Union.Column >= dv.Columns.Count - 1 Then
                    Continue For
                End If

                '描画するセルが結合範囲内の四つ角のどれかであるかを判断
                If CheckUnionArea(e.RowIndex, e.ColumnIndex, Union.Row, Union.Column, Union.RowSpan, Union.ColumnSpan) Then

                    rect = e.CellBounds
                    '縦方向の結合
                    If Union.RowSpan > 1 Then
                        '高さが2以上の場合高さを加算していく
                        For Heightcn = 1 To Union.RowSpan - 1

                            If e.RowIndex = Union.Row Then
                                '描画するセルが上端の場合：下にスライドして高さを加算
                                If Me.Rows.Count - 1 < e.RowIndex + Heightcn Then Exit For
                                cell = Me(e.ColumnIndex, e.RowIndex + Heightcn)
                                rect.Height += cell.Size.Height

                            ElseIf e.RowIndex = Union.Row + Union.RowSpan - 1 Then
                                '描画するセルが下端の場合：上にスライドして高さを加算
                                If e.RowIndex - Heightcn < 0 Then Exit For
                                cell = Me(e.ColumnIndex, e.RowIndex - Heightcn)
                                rect.Height += cell.Size.Height

                                '座標を左上になるよう調整
                                rect.Y -= cell.Size.Height
                            End If
                        Next
                    End If
                    '横方向の結合
                    If UnionCells(i).ColumnSpan > 1 Then
                        '横幅が2以上の場合幅を加算していく
                        For Widthcn = 1 To Union.ColumnSpan - 1

                            If e.ColumnIndex = Union.Column Then
                                '描画するセルが左端の場合：右にスライドして幅を加算
                                If Me.Columns.Count - 1 < e.ColumnIndex + Widthcn Then Exit For
                                cell = Me(e.ColumnIndex + Widthcn, e.RowIndex)
                                rect.Width += cell.Size.Width

                            ElseIf e.ColumnIndex = Union.Column + Union.ColumnSpan - 1 Then
                                '描画するセルが右端の場合：左にスライドして幅を加算
                                If e.ColumnIndex - Widthcn < 0 Then Exit For
                                cell = Me(e.ColumnIndex - Widthcn, e.RowIndex)
                                rect.Width += cell.Size.Width

                                '座標を左上になるよう調整
                                rect.X -= cell.Size.Width
                            End If
                        Next
                    End If

                    '表示位置の補正
                    rect.X -= 1
                    rect.Y -= 1
                    '画面外にはみ出るとサイズ縮小
                    'If rect.X < 0 Then
                    '    rect.Width -= Math.Abs(rect.X)
                    '    rect.X += Math.Abs(rect.X)
                    'End If

                    '基準となる結合セルにデータがある場合表示する
                    Dim text As String = ""
                    If Me(Union.Column, Union.Row).Value IsNot Nothing Then
                        text = Me(Union.Column, Union.Row).Value.ToString
                    ElseIf Not Union.Text = String.Empty Then
                        text = Union.Text
                    End If

                    'UnionCellに背景色が設定されている場合反映、されていない場合セルの書式を反映
                    bkColor = e.CellStyle.BackColor
                    If Not Union.BackgroundColor = Color.Empty Then
                        bkColor = Union.BackgroundColor
                    End If

                    'UnionCellに文字色が設定されている場合反映、されていない場合セルの書式を反映
                    frColor = e.CellStyle.ForeColor
                    If Not Union.ForeColor = Color.Empty Then
                        frColor = Union.ForeColor
                    End If

                    'UnionCellで文字位置の設定がされている場合反映、されていない場合ﾃﾞﾌｫﾙﾄを反映
                    Dim align As DataGridViewContentAlignment = MyBase.ColumnHeadersDefaultCellStyle.Alignment
                    Dim wrap As DataGridViewTriState = MyBase.ColumnHeadersDefaultCellStyle.WrapMode

                    If Not Union.TextAlign = DataGridViewContentAlignment.NotSet Then align = Union.TextAlign
                    If Not Union.WrapMode = DataGridViewTriState.NotSet Then wrap = Union.WrapMode
                    TFflag = GetTextFormatFlags(align, wrap)

                    '結合セルの描画
                    e.Graphics.FillRectangle(New SolidBrush(bkColor), rect)
                    e.Graphics.DrawRectangle(New Pen(dv.GridColor), rect)
                    TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, rect, frColor, TFflag)
                    e.Handled = True

                    draw = False

                ElseIf CheckIndex(e.RowIndex, e.ColumnIndex, UnionCells(i).Row, UnionCells(i).Column, UnionCells(i).RowSpan, UnionCells(i).ColumnSpan) Then
                    'セル結合の範囲内に存在する場合:背景色のみのセルを描画、本来存在していたデータは表示されない
                    'ここがなくなるとスクロール時再描画で処理されないセルが発生し黒塗りの虫食い状態になる
                    rect = e.CellBounds
                    Dim width As Integer = rect.Width

                    'UnionCellに背景色が設定されている場合反映、されていない場合セルの書式を反映
                    bkColor = e.CellStyle.BackColor
                    If Not Union.BackgroundColor = Color.Empty Then
                        bkColor = Union.BackgroundColor
                    End If

                    '被結合セルの描画
                    e.Graphics.FillRectangle(New SolidBrush(bkColor), rect)

                    rect.X -= 1
                    rect.Y -= 1
                    '結合セルの左辺を描画
                    If e.ColumnIndex = Union.Column Then
                        e.Graphics.DrawLine(New Pen(dv.GridColor), rect.X, rect.Y, rect.X, rect.Y + rect.Height)
                    End If
                    '結合セルの右辺を描画
                    If e.ColumnIndex = Union.Column + Union.ColumnSpan - 1 Then
                        rect.X += width
                        e.Graphics.DrawLine(New Pen(dv.GridColor), rect.X, rect.Y, rect.X, rect.Y + rect.Height)
                    End If
                    e.Handled = True
                    draw = False

                End If

            Next
            'セル結合の範囲外にある場合：通常の描画
            If draw Then e.Paint(e.ClipBounds, e.PaintParts)
            e.Handled = True

        Else
            'セル結合を行わない：そのままセルを描画
            e.Paint(e.ClipBounds, e.PaintParts)
            e.Handled = True
        End If

    End Sub

#End Region

#Region "ﾒｿｯﾄﾞ"

#Region "ｺﾝﾃｷｽﾄﾒﾆｭｰ"

    ''' <summary>
    ''' ｺﾝﾃｷｽﾄﾒﾆｭｰのｺﾋﾟｰ選択時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ContextMenuCopy_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.DataSource Is Nothing Or Me.GetClipboardContent Is Nothing Then Exit Sub
            '選択されたセルをクリップボードにコピーする
            Clipboard.SetDataObject(Me.GetClipboardContent())

        End Sub

    ''' <summary>
    ''' ClipBoardのﾃﾞｰﾀをDataGridViewに貼付け
    ''' </summary>
    Private Sub SetClipDataToDGV()

            Dim Data As IDataObject = Clipboard.GetDataObject()
            If Not Data.GetDataPresent(DataFormats.Text) Or
            Me.DataSource Is Nothing Then Exit Sub
            If Me.AllowUserToAddRows Then
                If Me.Rows.Count < 2 Then Exit Sub
            Else
                If Me.Rows.Count < 1 Then Exit Sub
            End If
            Dim DataList As List(Of List(Of String)) = SeparateTexttoData(Clipboard.GetText)
            Dim col As Integer = SelectedCells.Item(0).ColumnIndex
            Dim row As Integer = SelectedCells.Item(0).RowIndex

            For y = 0 To DataList.Count - 1
                For x = 0 To DataList(y).Count - 1
                    If Me(col + x, row + y).Value.GetType <> DataList(y)(x).GetType Then
                        Continue For
                    End If
                    Me(col + x, row + y).Value = DataList(y)(x)
                Next
            Next
        End Sub

    ''' <summary>
    ''' DataGridViewからﾃﾞｰﾀをｺﾋﾟｰしｺﾋﾟｰ元は削除する
    ''' </summary>
    Private Sub CutDataFromDGV()
            If Me.DataSource Is Nothing Or Me.GetClipboardContent Is Nothing Then Exit Sub

            '選択されたセルをクリップボードにコピーする
            Clipboard.SetDataObject(Me.GetClipboardContent())
            For Each cell As DataGridViewCell In Me.SelectedCells
                cell.Value = ""
            Next
        End Sub

    ''' <summary>
    ''' 貼付け用にｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを分解
    ''' </summary>
    ''' <param name="Pdata"></param>
    ''' <returns></returns>
    Private Function SeparateTexttoData(ByVal Pdata As String) As List(Of List(Of String))
            Dim LineArray As String() = Pdata.Split(vbCrLf)
            Dim ReturnArray As New List(Of List(Of String))

            For i = 0 To LineArray.Count - 1
                Dim ColArray As New List(Of String)
                If LineArray(i) = vbLf Then Continue For
                ColArray.AddRange(LineArray(i).Split(vbTab))
                ReturnArray.Add(ColArray)
            Next

            Return ReturnArray
        End Function

#End Region

#Region "ｶﾗﾑﾍｯﾀﾞｰ"

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'この呼び出しは、コンポーネント デザイナーで必要です。
        InitializeComponent()

        MyBase.DoubleBuffered = True

    End Sub

    ''' <summary>
    ''' 再描画をするとき
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            If ColumnHeaderCustom Then
                Try


                    '---------------------------------------------------------------------------------------------------------
                    'ヘッダーセルの描画
                    '---------------------------------------------------------------------------------------------------------

                    'ヘッダーの行の高さの取得
                    Dim rowHeight As Integer = MyBase.ColumnHeadersHeight

                If Me.ColumnHeaderRowCount > 0 Then
                    rowHeight = Me.ColumnHeaderRowHeight
                    MyBase.ColumnHeadersHeight = Me.ColumnHeaderRowCount * Me.ColumnHeaderRowHeight + 2
                End If

                '線の太さ
                Dim lineWidth As Integer = 1

                    For i = 0 To ColumnCount - 1

                        For j = 0 To Me.ColumnHeaderRowCount - 1

                            'グッリドの線
                            Dim gridPen As New Pen(MyBase.GridColor)
                            '背景色
                            Dim backBrash As New SolidBrush(MyBase.ColumnHeadersDefaultCellStyle.BackColor)
                            'くぼみ線
                            Dim whiteBrash As New SolidBrush(Color.White)

                            Try
                                '列ヘッダーの描画領域
                                Dim rect As Rectangle = MyBase.GetCellDisplayRectangle(i, -1, True)
                                '列ヘッダーの描画領域の底部の座標を保存
                                Dim btm As Integer = rect.Bottom
                                'セルの描画領域のY座標
                                Select Case MyBase.BorderStyle
                                    Case Windows.Forms.BorderStyle.None
                                        rect.Y = rowHeight * j
                                    Case Windows.Forms.BorderStyle.FixedSingle
                                        rect.Y = rowHeight * j + lineWidth
                                    Case Windows.Forms.BorderStyle.Fixed3D
                                        rect.Y = rowHeight * j + (lineWidth * 2)
                                End Select

                                'セルの描画領域のX座標
                                rect.X -= lineWidth
                                'セルの描画領域の高さ
                                rect.Height = rowHeight

                                '最下行の場合高さを調整
                                If j = Me.ColumnHeaderRowCount - 1 Then
                                    rect.Height = btm - rect.Y - lineWidth
                                End If

                                'セルを囲む線の描画
                                e.Graphics.DrawRectangle(gridPen, rect)


                                'セルの背景色の領域
                                rect.Y += lineWidth
                                rect.X += lineWidth
                                rect.Height -= lineWidth
                                rect.Width -= lineWidth
                                '背景色の描画
                                If ColumnHeaderBorderStyle <> HeaderCellBorderStyle.DoubleLine Then
                                    'Single線の場合
                                    e.Graphics.FillRectangle(backBrash, rect)
                                Else
                                    'くぼみ線の場合
                                    'rect.Width -= lineWidth
                                    e.Graphics.FillRectangle(whiteBrash, rect)
                                    rect.Y += lineWidth
                                    rect.X += lineWidth
                                    rect.Height -= lineWidth
                                    rect.Width -= lineWidth

                                    e.Graphics.FillRectangle(backBrash, rect)
                                End If

                                '見出しを最下列に表示
                                If j = Me.ColumnHeaderRowCount - 1 Then
                                    Dim text As String = MyBase.Columns(i).HeaderText

                                    If MyBase.SortedColumn IsNot Nothing AndAlso MyBase.SortedColumn Is Me.Columns(i) Then
                                        If MyBase.SortOrder = Windows.Forms.SortOrder.Ascending Then
                                            text = text & "  ▼"
                                        ElseIf MyBase.SortOrder = Windows.Forms.SortOrder.Descending Then
                                            text = text & "  ▲"
                                        End If
                                    End If

                                    Dim formatFlg As TextFormatFlags = GetTextFormatFlags(MyBase.ColumnHeadersDefaultCellStyle.Alignment,
                                                                                                                    MyBase.ColumnHeadersDefaultCellStyle.WrapMode)

                                    TextRenderer.DrawText(e.Graphics, text,
                                                                   MyBase.ColumnHeadersDefaultCellStyle.Font, rect,
                                                                   MyBase.ColumnHeadersDefaultCellStyle.ForeColor,
                                                                   formatFlg)
                                End If

                            Finally
                                'リソースの解放
                                gridPen.Dispose()
                                backBrash.Dispose()
                                whiteBrash.Dispose()
                            End Try
                        Next
                    Next


                    '---------------------------------------------------------------------------------------------------------
                    'ヘッダーのセル結合
                    '---------------------------------------------------------------------------------------------------------
                    'ヘッダーセル定義の処理
                    For i = 0 To Me.HeaderCells.Count - 1

                        'セルの結合の開始行がヘッダーの行数より大きい場合は除外
                        If HeaderCells(i).Row > Me.ColumnHeaderRowCount - 1 Then
                            Continue For
                        End If

                        'セルの結合の開始列の列インデックスが列数より大きい場合は除外
                        If HeaderCells(i).Column > MyBase.ColumnCount - 1 Then
                            Continue For
                        End If

                        '描画領域の設定
                        Dim rect As Rectangle = Nothing

                        '結合する列中のソート状態
                        Dim sortText As String = String.Empty

                        '結合するセルの各列の幅を取得し描画領域の幅を決める、ソートされている列の場合Textに表示するソート方向の設定
                        For j = Me.HeaderCells(i).Column To Me.HeaderCells(i).Column + Me.HeaderCells(i).ColumnSpan - 1

                            '列が画面に表示されていない場合は処理しない
                            If MyBase.Columns(j).Displayed = False Then
                                Continue For
                            End If

                            '列ヘッダーの領域の幅
                            If rect = Nothing Then
                                '結合するセルの開始列の場合
                                rect = MyBase.GetCellDisplayRectangle(j, -1, True)
                            Else
                                '結合するセルの2列目以降の場合
                                rect.Width += MyBase.GetCellDisplayRectangle(j, -1, True).Width
                            End If


                            'ソート列の場合
                            If HeaderCells(i).SortVisible = True AndAlso MyBase.SortedColumn IsNot Nothing AndAlso MyBase.SortedColumn Is MyBase.Columns(j) Then
                                If MyBase.SortOrder = Windows.Forms.SortOrder.Ascending Then
                                    sortText = "  ▼"
                                ElseIf MyBase.SortOrder = Windows.Forms.SortOrder.Descending Then
                                    sortText = "  ▲"
                                End If
                            End If

                        Next

                        '結合するセルが画面中に無い場合
                        If rect = Nothing Then
                            Continue For
                        End If

                        '結合する行がヘッダー行数より大きい場合
                        Dim rowSapn As Integer = Me.HeaderCells(i).RowSpan
                        If rowSapn > ColumnHeaderRowCount Then
                            rowSapn = ColumnHeaderRowCount
                        End If

                        '列ヘッダーの描画領域の底部の座標を保存
                        Dim btm As Integer = rect.Bottom

                        '結合するセルの描画領域のY座標
                        Select Case MyBase.BorderStyle
                            Case Windows.Forms.BorderStyle.None
                                rect.Y = rowHeight * (Me.HeaderCells(i).Row)
                            Case Windows.Forms.BorderStyle.FixedSingle
                                rect.Y = rowHeight * (Me.HeaderCells(i).Row) + lineWidth
                            Case Windows.Forms.BorderStyle.Fixed3D
                                rect.Y = rowHeight * (Me.HeaderCells(i).Row) + (lineWidth * 2)
                        End Select

                        '結合するセルの描画領域のX座標
                        rect.X -= lineWidth

                        '結合するセルの描画領域の高さ
                        rect.Height = rowHeight * rowSapn

                        '最下行の場合は描画領域の高さを調整する
                        If Me.HeaderCells(i).Row + rowSapn = Me.ColumnHeaderRowCount Then
                            rect.Height = btm - rect.Y - lineWidth
                        End If

                        'グッリドの線
                        Dim gridPen As New Pen(MyBase.GridColor)

                        '背景色の取得
                        Dim backgroundColor As System.Drawing.Color = MyBase.ColumnHeadersDefaultCellStyle.BackColor
                        'セルの背景色が設定されている場合
                        If Not Me.HeaderCells(i).BackgroundColor = Color.Empty Then
                            backgroundColor = Me.HeaderCells(i).BackgroundColor
                        End If

                        '背景色
                        Dim backBrash As New SolidBrush(backgroundColor)

                        'くぼみ線
                        Dim whiteBrash As New SolidBrush(Color.White)

                        Try

                            '枠線の描画
                            e.Graphics.DrawRectangle(gridPen, rect)


                            '結合セルの背景色の描画領域の設定
                            rect.Y += lineWidth
                            rect.X += lineWidth
                            rect.Height -= lineWidth
                            rect.Width -= lineWidth


                            '背景色の描画
                            If ColumnHeaderBorderStyle = HeaderCellBorderStyle.SingleLine Then
                                'Singleの場合
                                e.Graphics.FillRectangle(backBrash, rect)
                            Else
                                'くぼみ線の場合
                                e.Graphics.FillRectangle(whiteBrash, rect)
                                rect.Y += lineWidth
                                rect.X += lineWidth
                                rect.Height -= lineWidth
                                rect.Width -= lineWidth

                                e.Graphics.FillRectangle(backBrash, rect)
                            End If


                            'テキストの描画
                            Dim foreColor As System.Drawing.Color = MyBase.ColumnHeadersDefaultCellStyle.ForeColor
                            If Not Me.HeaderCells(i).ForeColor = Color.Empty Then
                                foreColor = Me.HeaderCells(i).ForeColor
                            End If

                            Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.HeaderCells(i).TextAlign, Me.HeaderCells(i).WrapMode)

                            TextRenderer.DrawText(e.Graphics,
                                                           Me.HeaderCells(i).Text & sortText,
                                                           MyBase.ColumnHeadersDefaultCellStyle.Font,
                                                           rect, foreColor, formatFlg)

                        Finally
                            'リソースの解放
                            gridPen.Dispose()
                            backBrash.Dispose()
                            whiteBrash.Dispose()
                        End Try
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            End If

        End Sub

    ''' <summary>
    ''' 指定のスタイルから描写するテキストのスタイルを取得する
    ''' </summary>
    ''' <param name="alignment">テキストのスタイル</param>
    ''' <param name="wrapMode">折り返</param>
    ''' <remarks>描写するテキストのスタイル</remarks>
    Private Function GetTextFormatFlags(ByVal alignment As DataGridViewContentAlignment,
                                                                ByVal wrapMode As DataGridViewTriState) As TextFormatFlags
        Try
            ''文字の描画
            Dim formatFlg As TextFormatFlags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis

            '表示位置
            Select Case alignment
                Case DataGridViewContentAlignment.BottomCenter
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.BottomLeft
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.BottomRight
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleCenter
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleLeft
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleRight
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopCenter
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopLeft
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopRight
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
            End Select


            '折り返し
            Select Case wrapMode
                Case DataGridViewTriState.False
                Case DataGridViewTriState.NotSet
                Case DataGridViewTriState.True
                    formatFlg = formatFlg Or TextFormatFlags.WordBreak
            End Select

            Return formatFlg

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' セルを結合する対象の列の描画領域の無効化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InvalidateUnitColumns()
            Try

            Dim hRect As Rectangle = MyBase.DisplayRectangle
            hRect.Height = MyBase.ColumnHeadersHeight + 1
            MyBase.Invalidate()

            'For y = 0 To Me.Rows.Count - 1
            '    For x = 0 To Me.Columns.Count - 1
            '        MyBase.InvalidateColumn(x)
            '    Next

            '    MyBase.InvalidateRow(y)
            'Next

        Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

    ''' <summary>
    ''' スクロールが実行されたとき
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnScroll(ByVal e As System.Windows.Forms.ScrollEventArgs)
            MyBase.OnScroll(e)

            Try
            InvalidateUnitColumns()
            'Me.Refresh()
        Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

    ''' <summary>
    ''' サイズが変更されたとき
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
            MyBase.OnSizeChanged(e)

            Try
                InvalidateUnitColumns()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        End Sub

    ''' <summary>
    ''' 列の幅が変更されたとき
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnColumnWidthChanged(ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
            MyBase.OnColumnWidthChanged(e)

            Try
                InvalidateUnitColumns()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

    ''' <summary>
    ''' 行の境界線がダブルクリックされた時
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnRowDividerDoubleClick(ByVal e As System.Windows.Forms.DataGridViewRowDividerDoubleClickEventArgs)
            MyBase.OnRowDividerDoubleClick(e)

            Try
                '行ヘッダーの境界線がダブルクリックされたへっだーの高さを整える
                If e.RowIndex = -1 Then
                    MyBase.ColumnHeadersHeight = Me.ColumnHeaderRowCount * Me.ColumnHeaderRowHeight + 2
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

    ''' <summary>
    ''' マウスのボタンが押された時
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)

            Try
                '列幅、行高を調整するドラグ線を見えるようにするためにダブルバッファを解除する
                MyBase.DoubleBuffered = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

    ''' <summary>
    ''' マウスのボタンが離された時
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnMouseUp(e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)

            Try
                'OnMouseDownイベントで解除されたダブルバッファを適用する
                MyBase.DoubleBuffered = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

#End Region

#Region "ｾﾙ結合：条件判定"

    ''' <summary>
    ''' セル結合の四隅のセルであるか判断
    ''' </summary>
    ''' <param name="CellRow"></param>
    ''' <param name="CellColumn"></param>
    ''' <param name="UnionRow"></param>
    ''' <param name="UnionColumn"></param>
    ''' <param name="RowSpan"></param>
    ''' <param name="ColumnSpan"></param>
    ''' <returns></returns>
    Private Function CheckUnionArea(ByVal CellRow As Integer, ByVal CellColumn As Integer,
                                                     ByVal UnionRow As Integer, ByVal UnionColumn As Integer,
                                                     ByVal RowSpan As Integer, ByVal ColumnSpan As Integer) As Boolean
        Dim chk As Boolean = False

        If (CellRow = UnionRow OrElse CellRow = UnionRow + RowSpan - 1) AndAlso
            (CellColumn = UnionColumn OrElse CellColumn = UnionColumn + ColumnSpan - 1) Then
            chk = True
        End If

        Return chk


    End Function

    ''' <summary>
    ''' 結合領域内に存在するかﾁｪｯｸ
    ''' </summary>
    ''' <param name="CellRow"></param>
    ''' <param name="CellColumn"></param>
    ''' <param name="UnionRow"></param>
    ''' <param name="UnionColumn"></param>
    ''' <param name="RowSpan"></param>
    ''' <param name="ColumnSpan"></param>
    ''' <returns></returns>
    Private Function CheckIndex(ByVal CellRow As Integer, ByVal CellColumn As Integer,
                                               ByVal UnionRow As Integer, ByVal UnionColumn As Integer,
                                               ByVal RowSpan As Integer, ByVal ColumnSpan As Integer) As Boolean
        Dim rtn As Boolean = False

        For checkR = UnionRow To UnionRow + RowSpan - 1
            For checkC = UnionColumn To UnionColumn + ColumnSpan - 1
                If checkC = CellColumn And checkR = CellRow Then rtn = True
            Next
        Next
        Return rtn
    End Function

#End Region

#End Region

End Class
