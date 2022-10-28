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
        Dim UnionCell1 As Fujikyu_Lib_R.UnionCell = New Fujikyu_Lib_R.UnionCell()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FjkDataGridView1 = New Fujikyu_Lib_R.FjkDataGridView()
        Me.FjkButton2 = New Fujikyu_Lib_R.FjkButton()
        Me.FjkButton1 = New Fujikyu_Lib_R.FjkButton()
        Me.FjkBarCordReader1 = New Fujikyu_Lib_R.FjkBarCordReader()
        CType(Me.FjkDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FjkDataGridView1
        '
        Me.FjkDataGridView1.CellUnion = True
        Me.FjkDataGridView1.ColumnHeaderBorderStyle = Fujikyu_Lib_R.FjkDataGridView.HeaderCellBorderStyle.SingleLine
        Me.FjkDataGridView1.ColumnHeaderCustom = False
        Me.FjkDataGridView1.ColumnHeaderRowCount = 1
        Me.FjkDataGridView1.ColumnHeaderRowHeight = 17
        Me.FjkDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FjkDataGridView1.Location = New System.Drawing.Point(270, 35)
        Me.FjkDataGridView1.Name = "FjkDataGridView1"
        Me.FjkDataGridView1.RowTemplate.Height = 21
        Me.FjkDataGridView1.Size = New System.Drawing.Size(374, 224)
        Me.FjkDataGridView1.TabIndex = 8
        UnionCell1.BackgroundColor = System.Drawing.Color.Empty
        UnionCell1.Column = 2
        UnionCell1.ColumnSpan = 0
        UnionCell1.ErrorText = ""
        UnionCell1.ForeColor = System.Drawing.Color.Empty
        UnionCell1.Row = 0
        UnionCell1.RowSpan = 2
        UnionCell1.Style = DataGridViewCellStyle1
        UnionCell1.Text = ""
        UnionCell1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        UnionCell1.Value = Nothing
        UnionCell1.ValueType = Nothing
        UnionCell1.WrapMode = System.Windows.Forms.DataGridViewTriState.NotSet
        Me.FjkDataGridView1.UnionCells.Add(UnionCell1)
        '
        'FjkButton2
        '
        Me.FjkButton2.BackColor = System.Drawing.SystemColors.Control
        Me.FjkButton2.ChangeColorIfEnter = True
        Me.FjkButton2.ChangeColorIfFocus = False
        Me.FjkButton2.EnterBackColor = System.Drawing.SystemColors.ControlDark
        Me.FjkButton2.EnterForeColor = System.Drawing.Color.Empty
        Me.FjkButton2.Location = New System.Drawing.Point(316, 344)
        Me.FjkButton2.Name = "FjkButton2"
        Me.FjkButton2.Size = New System.Drawing.Size(168, 61)
        Me.FjkButton2.TabIndex = 7
        Me.FjkButton2.Text = "FjkButton2"
        Me.FjkButton2.UseVisualStyleBackColor = False
        Me.FjkButton2.UseWaitCursor = True
        '
        'FjkButton1
        '
        Me.FjkButton1.ChangeColorIfEnter = False
        Me.FjkButton1.ChangeColorIfFocus = False
        Me.FjkButton1.EnterBackColor = System.Drawing.SystemColors.Control
        Me.FjkButton1.EnterForeColor = System.Drawing.Color.Empty
        Me.FjkButton1.Location = New System.Drawing.Point(94, 336)
        Me.FjkButton1.Name = "FjkButton1"
        Me.FjkButton1.Size = New System.Drawing.Size(216, 76)
        Me.FjkButton1.TabIndex = 6
        Me.FjkButton1.Text = "FjkButton1"
        Me.FjkButton1.UseVisualStyleBackColor = True
        Me.FjkButton1.UseWaitCursor = True
        '
        'FjkBarCordReader1
        '
        Me.FjkBarCordReader1.BackColor = System.Drawing.SystemColors.Control
        Me.FjkBarCordReader1.Location = New System.Drawing.Point(42, 35)
        Me.FjkBarCordReader1.Name = "FjkBarCordReader1"
        Me.FjkBarCordReader1.Size = New System.Drawing.Size(177, 168)
        Me.FjkBarCordReader1.TabIndex = 5
        Me.FjkBarCordReader1.UseWaitCursor = True
        '
        'ExForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(706, 487)
        Me.Controls.Add(Me.FjkDataGridView1)
        Me.Controls.Add(Me.FjkButton2)
        Me.Controls.Add(Me.FjkButton1)
        Me.Controls.Add(Me.FjkBarCordReader1)
        Me.Name = "ExForm"
        Me.Text = "Form1"
        Me.UseWaitCursor = True
        CType(Me.FjkDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FjkBarCordReader1 As Fujikyu_Lib_R.FjkBarCordReader
    Friend WithEvents FjkButton1 As Fujikyu_Lib_R.FjkButton
    Friend WithEvents FjkButton2 As Fujikyu_Lib_R.FjkButton
    Friend WithEvents FjkDataGridView1 As Fujikyu_Lib_R.FjkDataGridView
End Class
