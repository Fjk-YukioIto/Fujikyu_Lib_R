<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FjkBarCordReader1 = New Fujikyu_Lib_R.FjkBarCordReader()
        Me.FjkDataGridView1 = New Fujikyu_Lib_R.FjkDataGridView()
        Me.FjkButton1 = New Fujikyu_Lib_R.FjkButton()
        CType(Me.FjkDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(373, 416)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FjkBarCordReader1
        '
        Me.FjkBarCordReader1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FjkBarCordReader1.Location = New System.Drawing.Point(461, 12)
        Me.FjkBarCordReader1.Name = "FjkBarCordReader1"
        Me.FjkBarCordReader1.Size = New System.Drawing.Size(221, 211)
        Me.FjkBarCordReader1.TabIndex = 5
        '
        'FjkDataGridView1
        '
        Me.FjkDataGridView1.CellUnionMode = Fujikyu_Lib_R.FjkDataGridView.UnionMode.[Auto]
        Me.FjkDataGridView1.ColumnHeaderBorderStyle = Fujikyu_Lib_R.FjkDataGridView.HeaderCellBorderStyle.SingleLine
        Me.FjkDataGridView1.ColumnHeaderCustom = False
        Me.FjkDataGridView1.ColumnHeaderRowCount = 1
        Me.FjkDataGridView1.ColumnHeaderRowHeight = 17
        Me.FjkDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FjkDataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.FjkDataGridView1.Name = "FjkDataGridView1"
        Me.FjkDataGridView1.RowTemplate.Height = 21
        Me.FjkDataGridView1.Size = New System.Drawing.Size(428, 303)
        Me.FjkDataGridView1.TabIndex = 4
        '
        'FjkButton1
        '
        Me.FjkButton1.ChangeColorIfEnter = False
        Me.FjkButton1.ChangeColorIfFocus = False
        Me.FjkButton1.EnterBackColor = System.Drawing.SystemColors.Control
        Me.FjkButton1.EnterForeColor = System.Drawing.Color.Empty
        Me.FjkButton1.Location = New System.Drawing.Point(506, 416)
        Me.FjkButton1.Name = "FjkButton1"
        Me.FjkButton1.Size = New System.Drawing.Size(127, 39)
        Me.FjkButton1.TabIndex = 3
        Me.FjkButton1.Text = "FjkButton1"
        Me.FjkButton1.UseVisualStyleBackColor = True
        '
        'ExForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(706, 487)
        Me.Controls.Add(Me.FjkBarCordReader1)
        Me.Controls.Add(Me.FjkDataGridView1)
        Me.Controls.Add(Me.FjkButton1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ExForm"
        Me.Text = "Form1"
        CType(Me.FjkDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents FjkButton1 As Fujikyu_Lib_R.FjkButton
    Friend WithEvents FjkDataGridView1 As Fujikyu_Lib_R.FjkDataGridView
    Friend WithEvents FjkBarCordReader1 As Fujikyu_Lib_R.FjkBarCordReader
End Class
