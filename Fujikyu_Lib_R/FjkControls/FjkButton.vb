Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class FjkButton
    Inherits System.Windows.Forms.Button

#Region "ﾒﾝﾊﾞ"
    ''' <summary>
    ''' 背景色退避用
    ''' </summary>
    Dim DBcolor As Color = Color.Empty

    ''' <summary>
    ''' 文字色退避用
    ''' </summary>
    Dim DFcolor As Color = Color.Empty

    ''' <summary>
    ''' ﾏｳｽｶｰｿﾙが重なっているかの判定
    ''' </summary>
    Dim Mhover As Boolean = False
    Dim InFocus As Boolean = False

#Region "ChangeColorIfEnter"
    ''' <summary>
    ''' ﾏｳｽｶｰｿﾙが重なっている時、背景・文字色の変化するかを決定
    ''' </summary>
    Public _ChangeColorIfEnter As Boolean = False

    <Category("表示")>
    <Description("ﾏｳｽｶｰｿﾙが重なっている時、背景・文字色の変化するかを決定")>
    Public Property ChangeColorIfEnter As Boolean
        Get
            Return _ChangeColorIfEnter
        End Get
        Set(value As Boolean)
            _ChangeColorIfEnter = value
        End Set

    End Property

#End Region

#Region "ChangeColorIfFocus"
    ''' <summary>
    ''' ﾌｫｰｶｽ取得時に背景・文字色の変化するかを決定
    ''' </summary>
    Public _ChangeColorIfFocus As Boolean = False

    <Category("表示")>
    <Description("ﾌｫｰｶｽ取得時に背景・文字色の変化するかを決定")>
    Public Property ChangeColorIfFocus As Boolean
        Get
            Return _ChangeColorIfFocus
        End Get
        Set(value As Boolean)
            _ChangeColorIfFocus = value
        End Set

    End Property

#End Region

#Region "EnterBackColor"
    ''' <summary>
    ''' マウスカーソルがコントロール内に入った時の背景色を指定します
    ''' </summary>
    Public _EnterBackColor As Color

    <Category("表示")>
    <Description("マウスカーソルがコントロール内に入った時の背景色を指定します。")>
    Public Property EnterBackColor As Color
        Get
            If _EnterBackColor <> Color.Empty Then Return _EnterBackColor
            If Parent IsNot Nothing Then Return Parent.BackColor

            Return Control.DefaultBackColor
        End Get
        Set(value As Color)
            _EnterBackColor = value
            Me.Refresh()
        End Set
    End Property

#End Region

#Region "EnterForeColor"
    ''' <summary>
    ''' マウスカーソルがコントロール内に入った時の文字色を指定します
    ''' </summary>
    Public _EnterForeColor As Color

    <Category("表示")>
    <Description("マウスカーソルがコントロール内に入った時の文字色を指定します")>
    Public Property EnterForeColor As Color
        Get
            Return _EnterForeColor
        End Get
        Set(value As Color)
            _EnterForeColor = value
            Me.Refresh()
        End Set
    End Property

#End Region

#End Region

#Region "ｲﾍﾞﾝﾄ"
    ''' <summary>
    ''' ﾏｳｽｶｰｿﾙがﾎﾞﾀﾝ上にある時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseEnter
        If _ChangeColorIfEnter Then
            If Not Me.BackColor = Me._EnterBackColor Or DBcolor = Color.Empty Then
                DBcolor = Me.BackColor
                If Not _EnterBackColor = Color.Empty Then Me.BackColor = Me._EnterBackColor
            End If
            If Not Me.ForeColor = Me._EnterForeColor Then
                DFcolor = Me.ForeColor
                If Not _EnterForeColor = Color.Empty Then Me.ForeColor = Me._EnterForeColor
            End If
            Mhover = True
        End If
    End Sub

    ''' <summary>
    ''' ﾏｳｽｶｰｿﾙがﾎﾞﾀﾝ上から離れた時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        If _ChangeColorIfEnter And Not InFocus Then
            Me.BackColor = DBcolor
            Me.ForeColor = DFcolor
        End If
        Mhover = False
    End Sub

    ''' <summary>
    ''' ﾌｫｰｶｽ取得時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Me.GotFocus
        If _ChangeColorIfFocus Then
            If Not Me.BackColor = Me._EnterBackColor Or DBcolor = Color.Empty Then
                DBcolor = Me.BackColor
                If Not _EnterBackColor = Color.Empty Then Me.BackColor = Me._EnterBackColor
            End If
            If Not Me.ForeColor = Me._EnterForeColor Then
                DFcolor = Me.ForeColor
                If Not _EnterForeColor = Color.Empty Then Me.ForeColor = Me._EnterForeColor
            End If
            InFocus = True
        End If
    End Sub

    ''' <summary>
    ''' ﾌｫｰｶｽ喪失時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Leave
        If _ChangeColorIfFocus And Not Mhover Then
            Me.BackColor = DBcolor
            Me.ForeColor = DFcolor
        End If
        InFocus = False
    End Sub

    ''' <summary>
    ''' コントロール生成時の処理
    ''' </summary>
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

    End Sub

#End Region

#Region "ﾒｿｯﾄﾞ"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

#End Region

End Class
