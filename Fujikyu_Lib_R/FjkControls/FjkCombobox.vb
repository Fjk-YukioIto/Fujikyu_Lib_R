Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Public Class FjkCombobox

#Region "ﾒﾝﾊﾞ"

    ''' <summary>
    ''' テキストの位置
    ''' </summary>
    Enum TextAlign
        Left = 0
        Right = 1
        Center = 2
    End Enum

#Region "TextAlignment"
    ''' <summary>
    ''' コンボボックス内のテキストの位置を決定します。
    ''' </summary>
    Public _TextAlignment As TextAlign

    <Category("表示")>
    <Description("コンボボックス内のテキストの位置を決定します。")>
    Public Property TextAlignment() As TextAlign
        Get
            Return _TextAlignment
        End Get
        Set(value As TextAlign)
            _TextAlignment = value
        End Set
    End Property
#End Region

#End Region

#Region "ｲﾍﾞﾝﾄ"

    ''' <summary>
    ''' コントロール生成時の処理
    ''' </summary>
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        Me.DrawMode = DrawMode.OwnerDrawFixed
    End Sub

    ''' <summary>
    ''' ドロップダウンリスト内の文字位置を調整
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CbxDesign_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles Me.DrawItem
        Dim cbx As ComboBox = TryCast(sender, ComboBox)

        If (cbx IsNot Nothing) Then
            e.DrawBackground()
            If (e.Index >= 0) Then
                Dim sf As StringFormat = New StringFormat()
                ' --- TextAlignmentプロパティに準ずる
                Select Case _TextAlignment
                    '左詰め
                    Case TextAlign.Left
                        sf.LineAlignment = StringAlignment.Near
                        sf.Alignment = StringAlignment.Near
                    '右詰め
                    Case TextAlign.Right
                        sf.LineAlignment = StringAlignment.Far
                        sf.Alignment = StringAlignment.Far
                    '中央寄せ
                    Case TextAlign.Center
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                    Case Else
                End Select

                ' ---
                '描画の設定
                Dim brush As Brush = New SolidBrush(cbx.ForeColor)
                If ((e.State And DrawItemState.Selected) = DrawItemState.Selected) Then
                    brush = SystemBrushes.HighlightText
                End If
                '描画
                e.Graphics.DrawString(cbx.Items(e.Index).ToString(), cbx.Font, brush, e.Bounds, sf)
            End If
        End If

    End Sub

#End Region

#Region "ﾒｿｯﾄﾞ"

#End Region


End Class
