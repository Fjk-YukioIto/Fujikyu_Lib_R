'コントロールの継承で読み込む
Imports System.Windows.Forms
Imports System.ComponentModel
'枠線や直線などの描画に必要なインポート
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FjkLabel

#Region "ﾒﾝﾊﾞｰ"

    Private Const WM_PAINT = &HF

#Region "BorderColor"
    ''' <summary>
    ''' 枠線の色を指定します。
    ''' </summary>
    Public _BorderColor As Color = Color.Black

    <Category("表示")>
    <Description("枠線の色を指定します。")>
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Me.Refresh()
        End Set
    End Property

#End Region

#Region "BorderSize"
    ''' <summary>
    ''' 枠線の太さを決めます。※太くなるほど内側に広がります
    ''' </summary>
    Public _BorderSize As Integer = 1

    <Category("表示")>
    <Description("枠線の太さを決めます。※太くなるほど内側に広がります")>
    Public Property BorderSize() As Integer
        Get
            Return _BorderSize
        End Get
        Set(value As Integer)
            _BorderSize = value
            Me.Refresh()
        End Set
    End Property

#End Region

#Region "BorderWrite"
    ''' <summary>
    ''' 枠線の表示を指定します。
    ''' </summary>
    ''' <returns></returns>
    Public Property Borderwrite() As New Border

    <Category("表示")>
    <Description("枠線の表示を指定します。")>
    <TypeConverter(GetType(CustomBorderConverter))>
    Public Class Border
#Region "宣言"
        Public _All As Boolean = True
        Public _Top As Boolean = True
        Public _Bottom As Boolean = True
        Public _Right As Boolean = True
        Public _Left As Boolean = True
#End Region
#Region "ｹﾞｯﾄ/ｾｯﾄ"
        ''' <summary>
        ''' True/Falseの切替えで以下4つのプロパティを切り替える事が可能です、
        ''' なお4つの内1つでもFalseになると自動的にFalseに変更
        ''' </summary>
        ''' <returns></returns>
        Public Property All() As Boolean
            Get
                Return _All
            End Get
            Set(value As Boolean)
                _All = value
                If value = False Then
                    _Top = False
                    _Bottom = False
                    _Right = False
                    _Left = False
                ElseIf value = True Then
                    _Top = True
                    _Bottom = True
                    _Right = True
                    _Left = True
                End If

            End Set
        End Property
        Public Property Top() As Boolean
            Get
                Return _Top
            End Get
            Set(value As Boolean)
                _Top = value
                If value = False Then
                    _All = False
                ElseIf value = True Then
                    If _Top And _Bottom And
                    _Right And _Left Then
                        _All = True
                    End If
                End If
            End Set
        End Property
        Public Property Bottom() As Boolean
            Get
                Return _Bottom
            End Get
            Set(value As Boolean)
                _Bottom = value
                If value = False Then
                    _All = False
                ElseIf value = True Then
                    If _Top And _Bottom And
                    _Right And _Left Then
                        _All = True
                    End If
                End If
            End Set
        End Property
        Public Property Right() As Boolean
            Get
                Return _Right
            End Get
            Set(value As Boolean)
                _Right = value
                If value = False Then
                    _All = False
                ElseIf value = True Then
                    If _Top And _Bottom And
                    _Right And _Left Then
                        _All = True
                    End If
                End If
            End Set
        End Property
        Public Property Left() As Boolean
            Get
                Return _Left
            End Get
            Set(value As Boolean)
                _Left = value
                If value = False Then
                    _All = False
                ElseIf value = True Then
                    If _Top And _Bottom And
                    _Right And _Left Then
                        _All = True
                    End If
                End If
            End Set
        End Property
#End Region
    End Class
#End Region

#Region "DashDotSize"
    ''' <summary>
    ''' カスタム破線の線の長さを指定します。
    ''' </summary>
    Public _DashDotsize As Integer = 5

    <Category("表示")>
    <Description("カスタム破線の線の長さを指定します。")>
    Public Property Dash_DotSize() As Integer
        Get
            Return _DashDotsize
        End Get
        Set(value As Integer)
            _DashDotsize = value
            Me.Refresh()
        End Set
    End Property

#End Region

#Region "DashStyle"

    ''' <summary>
    ''' 枠線の線のスタイルを指定します。
    ''' </summary>
    Public _DashStyle As DashStyle

    <Category("表示")>
    <Description("枠線の線のスタイルを指定します。")>
    Public Property DashStyle() As DashStyle
        Get
            Return _DashStyle
        End Get
        Set(value As DashStyle)
            _DashStyle = value
            Me.Refresh()
        End Set
    End Property

#End Region

#End Region

#Region "ｲﾍﾞﾝﾄ"

#End Region

#Region "ﾒｿｯﾄﾞ"

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

    ''' <summary>
    ''' 初期値の設定
    ''' </summary>
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    ''' <summary>
    ''' WndProcメソッドオーバーライド/プロパティの情報をもとに枠線を描画
    ''' </summary>
    ''' <param name="m"></param>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If (m.Msg = WM_PAINT) Then

            Using g As Graphics = CreateGraphics()
                'ペンのスタイルを初期化
                Dim dashValues As Single() = {_DashDotsize, CSng(_DashDotsize) / 2}
                Dim p As New Pen(_BorderColor, _BorderSize) With {
                    .DashPattern = dashValues,
                    .DashStyle = _DashStyle,
                    .LineJoin = LineJoin.Miter
                    }
                '標準カラーでない場合は指定色で描画する
                If _BorderColor <> Color.FromArgb(171, 173, 179) Then
                    'BorderSize に合わせて座標調整
                    Dim PosS As Single = CSng(Math.Floor(_BorderSize / 2))
                    'それぞれの辺で線を描画
                    If Borderwrite.Top Then g.DrawLine(p, 0, PosS, Width - 1, PosS)
                    If Borderwrite.Bottom Then g.DrawLine(p, 0, Height - 1 - PosS, Width - 1, Height - 1 - PosS)
                    If Borderwrite.Left Then g.DrawLine(p, PosS, 0, PosS, Height - 1)
                    If Borderwrite.Right Then g.DrawLine(p, Width - 1 - PosS, 0, Width - 1 - PosS, Height - 1)
                Else
                    ControlPaint.DrawVisualStyleBorder(g, New Rectangle(0, 0, Width - 1, Height - 1))
                End If

            End Using
        End If
    End Sub

    ''' <summary>
    ''' プロパティの文字列とBorder型のコンバート
    ''' </summary>
    Public Class CustomBorderConverter
        Inherits ExpandableObjectConverter

        ''' <summary>
        ''' コンバータがオブジェクトを指定した型に変換できるか（変換できる時はTrueを返す）
        ''' ここでは、Border型のオブジェクトには変換可能とする
        ''' </summary>
        ''' <param name="context"></param>
        ''' <param name="destinationType"></param>
        ''' <returns></returns>
        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
            If destinationType Is GetType(Border) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        ''' <summary>
        ''' 指定した値オブジェクトを、指定した型に変換する
        ''' Border型のオブジェクトをString型に変換する方法を提供する
        ''' </summary>
        ''' <param name="context"></param>
        ''' <param name="culture"></param>
        ''' <param name="value"></param>
        ''' <param name="destinationType"></param>
        ''' <returns></returns>
        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo,
                                                                              ByVal value As Object, ByVal destinationType As Type) As Object
            If destinationType Is GetType(String) And TypeOf value Is Border Then
                Dim cc As Border = CType(value, Border)
                Return cc.All.ToString() + "," +
                           cc.Bottom.ToString() + "," +
                           cc.Left.ToString() + "," +
                           cc.Right.ToString() + "," +
                           cc.Top.ToString()
            End If
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function


        ''' <summary>
        ''' コンバータが特定の型のオブジェクトをコンバータの型に変換できるか（変換できる時はTrueを返す）
        ''' ここでは、String型のオブジェクトなら変換可能とする
        ''' </summary>
        ''' <param name="context"></param>
        ''' <param name="sourceType"></param>
        ''' <returns></returns>
        Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
            If sourceType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertFrom(context, sourceType)
        End Function

        ''' <summary>
        ''' 指定した値をコンバータの型に変換するString型のオブジェクトをBorder型に変換する方法を提供する
        ''' </summary>
        ''' <param name="context"></param>
        ''' <param name="culture"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo,
                                                                                 ByVal value As Object) As Object
            If TypeOf value Is String Then
                Dim ss As String() = value.ToString().Split(New Char() {","c}, 5)
                Dim cc As New Border With {
                    .All = Boolean.Parse(ss(0)),
                    .Bottom = Boolean.Parse(ss(1)),
                    .Left = Boolean.Parse(ss(2)),
                    .Right = Boolean.Parse(ss(3)),
                    .Top = Boolean.Parse(ss(4))
                }
                Return cc
            End If
            Return MyBase.ConvertFrom(context, culture, value)
        End Function

    End Class

#End Region

End Class
