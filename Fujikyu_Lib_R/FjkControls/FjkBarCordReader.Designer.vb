<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FjkBarCordReader
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PB_Reader = New System.Windows.Forms.PictureBox()
        Me.BackgroundRead = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PB_Reader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PB_Reader
        '
        Me.PB_Reader.Image = Global.Fujikyu_Lib_R.My.Resources.Resources.QRsample
        Me.PB_Reader.Location = New System.Drawing.Point(3, 3)
        Me.PB_Reader.Name = "PB_Reader"
        Me.PB_Reader.Size = New System.Drawing.Size(240, 240)
        Me.PB_Reader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_Reader.TabIndex = 0
        Me.PB_Reader.TabStop = False
        '
        'BackgroundRead
        '
        '
        'Timer1
        '
        '
        'FjkBarCordReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PB_Reader)
        Me.Location = New System.Drawing.Point(2, 2)
        Me.Name = "FjkBarCordReader"
        Me.Size = New System.Drawing.Size(246, 246)
        CType(Me.PB_Reader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PB_Reader As Windows.Forms.PictureBox
    Friend WithEvents BackgroundRead As ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Windows.Forms.Timer
End Class
