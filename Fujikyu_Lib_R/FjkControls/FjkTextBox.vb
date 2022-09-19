Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FjkTextBox
    Inherits System.Windows.Forms.TextBox

#Region "ﾒﾝﾊﾞｰ"

#Region "描画系"
    Private Const WM_PAINT = &HF
    ''' <summary>
    ''' 背景色退避用
    ''' </summary>
    Dim DBcolor As Color = Color.Empty

    ''' <summary>
    ''' 文字色退避用
    ''' </summary>
    Dim DFcolor As Color = Color.Empty
#End Region

#Region "DataType"
    Enum Dtype
        ''' <summary>
        ''' 区別なし
        ''' </summary>
        _None = 100
        ''' <summary>
        ''' 全角文字列
        ''' </summary>
        _String = 110
        ''' <summary>
        ''' 半角文字列
        ''' </summary>
        _String_Half = 111
        ''' <summary>
        ''' 数値区別なし
        ''' </summary>
        _Number = 120
        ''' <summary>
        ''' 小数点付き数値
        ''' </summary>
        _Number_Delimited = 121
        ''' <summary>
        ''' 日付
        ''' </summary>
        _Date = 130
    End Enum

    ''' <summary>
    ''' テキストに入力される型を指定します。
    ''' </summary>
    Public _DataType As Dtype = Dtype._None

    <Category("動作")>
    <Description("テキストに入力される型を指定します。")>
    Public Property DataType() As Dtype
        Get
            Return _DataType
        End Get
        Set(value As Dtype)
            _DataType = value
        End Set

    End Property
#End Region

#Region "EnterBackColor"

    ''' <summary>
    ''' フォーカスを取得中の背景色
    ''' </summary>
    Public _EnterBackColor As Color = Me.BackColor

    <Category("表示")>
    <Description("フォーカスを取得中の背景色")>
    Public Property EnterBackColor() As Color
        Get
            Return _EnterBackColor
        End Get
        Set(value As Color)
            _EnterBackColor = value
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

#Region "FocusNextOnEnter"
    ''' <summary>
    ''' Enterでタブ切替え
    ''' </summary>
    Public _FocusNextOnEnter As Boolean = True

    <Category("動作")>
    <Description("Enterでタブ切替え")>
    Public Property FocusNextOnEnter As Boolean
        Get
            Return _FocusNextOnEnter
        End Get
        Set(value As Boolean)
            _FocusNextOnEnter = value
        End Set
    End Property
#End Region

#Region "MaxDecimal"
    Public _MaxDecimal As Integer

    <Category("動作")>
    <Description("小数の桁数")>
    Public Property MaxDecimal As Integer
        Get
            Return _MaxDecimal
        End Get
        Set(value As Integer)
            _MaxDecimal = value
        End Set
    End Property

#End Region

#End Region

#Region "ｲﾍﾞﾝﾄ"

    ''' <summary>
    ''' ﾌｫｰｶｽ取得時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub EnterFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Enter
        '背景色と文字色を退避
        DBcolor = Me.BackColor
        DFcolor = Me.ForeColor
        '背景色と文字色変更(設定がない場合変化なし)
        Me.BackColor = EnterBackColor
        Me.ForeColor = EnterForeColor
        Me.SelectAll()
    End Sub

    ''' <summary>
    ''' ﾌｫｰｶｽ喪失時・背景色文字色を戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FcTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        '退避から元の色を取得
        Me.BackColor = DBcolor
        Me.ForeColor = DFcolor
    End Sub

    ''' <summary>
    ''' ｷｰ押下時、対応した入浴制御を設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FcTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'Enter押下時のﾌｫｰｶｽ移動を許可している場合
        If _FocusNextOnEnter Then
            If e.KeyChar = Chr(Keys.Enter) Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If

        Select Case Me.DataType
            Case Dtype._None
            Case Dtype._String
            Case Dtype._String_Half
            Case Dtype._Date

            Case Dtype._Number
                '数字のみ入力受付け
                If (e.KeyChar < "0" OrElse "9" < e.KeyChar) AndAlso
                    e.KeyChar <> ControlChars.Back Then
                    e.Handled = True
                End If
            Case Dtype._Number_Delimited
                '数字・小数点のみ入力受付け
                If (e.KeyChar < "0" OrElse "9" < e.KeyChar) AndAlso
                    e.KeyChar <> "." AndAlso
                    e.KeyChar <> ControlChars.Back Then
                    e.Handled = True
                End If
            Case Else
        End Select

    End Sub

    ''' <summary>
    ''' ﾃｷｽﾄ変更時
    ''' </summary>
    ''' <param name="sener"></param>
    ''' <param name="e"></param>
    Private Sub FjkTextBox_TextChanged(sener As Object, e As EventArgs) Handles Me.TextChanged

        If System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(Text) > MaxLength Then
            Text = Text.Remove(Text.Length - 1)
            SelectionStart = TextLength
        End If

        If DataType = Dtype._Number_Delimited Then
            If Me.Text.Length > 0 Then

                If CountChar(Me.Text, ".") > 1 Then
                    Text = Text.Remove(Text.Length - 1)
                    SelectionStart = TextLength
                End If

                If (CountChar(Me.Text, ".") = 0 AndAlso Me.Text.Length > MaxLength - MaxDecimal - 1) OrElse
                    (CountChar(Me.Text, ".") = 1 AndAlso Me.Text.Length - Text.IndexOf(".") - 1 > MaxDecimal) Then

                    Text = Text.Remove(Text.Length - 1)
                    SelectionStart = TextLength
                End If

                If Text.Substring(Text.Length - 1) = "." Then
                        If Text.Length = 1 Then
                            Text = "0."
                            Me.SelectionStart = Me.Text.Length
                        End If
                    End If

                End If
            End If

    End Sub


#End Region

#Region "ﾒｿｯﾄﾞ"

    ''' <summary>
    ''' 初期値の設定
    ''' </summary>
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

    ''' <summary>
    ''' DataTypeプロパティを元にテキストの正常性を返します
    ''' </summary>
    ''' <returns>True:異常なし｜False：異常あり</returns>
    Public Function CheckTextType() As Boolean
        Dim Bcheck As Boolean = True
        Select Case _DataType
            Case Dtype._None

                If Len(Me.Text.Trim) = 0 Then Bcheck = False

            Case Dtype._String, Dtype._String_Half

                Bcheck = CheckTextByte(Me.Text.TrimEnd)

            Case Dtype._Number
                Try
                    If CInt(Me.Text.Trim).GetType = GetType(Integer) Then
                    End If
                Catch ex As Exception
                    Bcheck = False
                End Try

            Case Dtype._Number_Delimited

                Try
                    If CDbl(Me.Text.Trim).GetType = GetType(Double) Then
                    End If
                Catch ex As Exception
                    Bcheck = False
                End Try

            Case Dtype._Date
                Bcheck = IsDate(Me.Text.Trim)

            Case Else
                MessageBox.Show("該当する型が見つかりません、" & vbCrLf &
                                            "ライブラリ担当者に問い合わせてください。", "ｴﾗｰ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
        End Select
        Return Bcheck
    End Function

    ''' <summary>
    ''' 文字列内に全角なら半角が、半角なら全角が混ざっていないか確認
    ''' </summary>
    ''' <param name="Check_String"></param>
    ''' <returns></returns>
    Private Function CheckTextByte(ByVal Check_String As String) As Boolean

        Dim Check_Result As Boolean = True
        Dim Ctext As String = String.Empty
        Dim Check_Byte As Integer = 1

        If Me.DataType = Dtype._String Then Check_Byte = 2

        If Len(Check_String) = 0 Then
            Check_Result = False
        Else
            For tpos = 0 To Check_String.Length - 1
                Ctext = Check_String.Substring(tpos, 1)
                If System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(Ctext) <> Check_Byte Then
                    Check_Result = False
                End If
            Next
        End If

        Return Check_Result

    End Function

    ''' <summary>
    ''' 小数の入力正常性ﾁｪｯｸ
    ''' </summary>
    ''' <param name="Number"></param>
    ''' <returns></returns>
    Private Function CheckNumberDecimal(ByVal Number As String) As Boolean
        '小数の設定はあるが入力がない場合
        If Me._MaxDecimal > 0 And Number.IndexOf(".") <= 0 Then
            Return False
        End If

        Dim Num_Decimal As Integer = Number.Length - Number.IndexOf(".") - 1
        If Num_Decimal > MaxDecimal Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 特定の文字が何文字含まれているかを検出
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Public Shared Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString(), "").Length
    End Function

#End Region

End Class

