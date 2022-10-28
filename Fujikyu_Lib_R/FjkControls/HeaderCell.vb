Imports System
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

'Public Class HeaderCellColection
'    Inherits System.Collections.Generic.List(Of HeaderCell)
'End Class

''' <summary>
''' ヘッダーセル定義
''' </summary>
''' <remarks></remarks>
Public Class HeaderCell
    Inherits System.Windows.Forms.DataGridViewHeaderCell
    Private _row As Integer = 0
    ''' <summary>
    ''' 行
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セル位置")>
    <Description("行")>
    Public Property Row As Integer
        Get
            Return _row
        End Get
        Set(ByVal value As Integer)
            _row = value
        End Set
    End Property

    Private _column As Integer = 0
    ''' <summary>
    ''' 列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セル位置")>
    <Description("列")>
    Public Property Column As Integer
        Get
            Return _column
        End Get
        Set(ByVal value As Integer)
            _column = value
        End Set
    End Property

    Private _rowSpan As Integer = 1
    ''' <summary>
    ''' 結合する行数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セル結合")>
    <Description("行数")>
    Public Property RowSpan As Integer
        Get
            Return _rowSpan
        End Get
        Set(ByVal value As Integer)
            _rowSpan = value
        End Set
    End Property

    Private _columnSpan As Integer = 1
    ''' <summary>
    ''' 結合する列数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("セル結合")>
    <Description("列数")>
    Public Property ColumnSpan As Integer
        Get
            Return _columnSpan
        End Get
        Set(ByVal value As Integer)
            _columnSpan = value
        End Set
    End Property

    Private _backgroundColor As System.Drawing.Color = Color.Empty
    ''' <summary>
    ''' セルの背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("表示")>
    <Description("セルの背景色")>
    Public Property BackgroundColor As System.Drawing.Color
        Get
            Return _backgroundColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            _backgroundColor = value
        End Set
    End Property

    Private _foreColor As System.Drawing.Color = Color.Empty
    ''' <summary>
    ''' テキストの文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("表示")>
    <Description("テキストの文字色")>
    Public Property ForeColor As System.Drawing.Color
        Get
            Return _foreColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            _foreColor = value
        End Set
    End Property


    Private _text As String
    ''' <summary>
    ''' セルに関連付けられたテキスト
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("表示")>
    <Description("セルに関連付けられたテキストです")>
    Public Property Text As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Private _textAlign As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter
    ''' <summary>
    ''' 結合されたセル内でのテキストの位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks> 
    <Category("表示")>
    <Description("結合されたセル内のテキストの位置を決定します")>
    Public Property TextAlign As DataGridViewContentAlignment
        Get
            Return _textAlign
        End Get
        Set(ByVal value As DataGridViewContentAlignment)
            _textAlign = value
        End Set
    End Property

    Private _wrapMode As DataGridViewTriState = DataGridViewTriState.NotSet
    ''' <summary>
    ''' セルに含まれるテキスト形式の内容が 1 行に収まらないほど長い場合に、次の行に折り返されるか、
    ''' 切り捨てられるかを示す値を取得または設定する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("表示")>
    <Description("セル内のテキストが一行に収まらない場合にテキストを折り返す")>
    Public Property WrapMode As DataGridViewTriState
        Get
            Return _wrapMode
        End Get
        Set(ByVal value As DataGridViewTriState)
            _wrapMode = value
        End Set
    End Property

    Private _sortVisible As Boolean
    ''' <summary>
    ''' 結合されている列に並び替えがある場合に並び替えの方向を表示する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("表示")>
    <Description("結合されている列に並び替えがある場合に並び替えの方向を表示する")>
    Public Property SortVisible As Boolean
        Get
            Return _sortVisible
        End Get
        Set(ByVal value As Boolean)
            _sortVisible = value
        End Set
    End Property

End Class
