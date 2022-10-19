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
        Dim UnionCell2 As Fujikyu_Lib_R.UnionCell = New Fujikyu_Lib_R.UnionCell()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FjkDataGridView1 = New Fujikyu_Lib_R.FjkDataGridView()
        CType(Me.FjkDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FjkDataGridView1
        '
        Me.FjkDataGridView1.CellUnion = True
        Me.FjkDataGridView1.ColumnHeaderBorderStyle = Fujikyu_Lib_R.FjkDataGridView.HeaderCellBorderStyle.SingleLine
        Me.FjkDataGridView1.ColumnHeaderCustom = True
        Me.FjkDataGridView1.ColumnHeaderRowCount = 1
        Me.FjkDataGridView1.ColumnHeaderRowHeight = 17
        Me.FjkDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FjkDataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.FjkDataGridView1.Name = "FjkDataGridView1"
        Me.FjkDataGridView1.RowTemplate.Height = 21
        Me.FjkDataGridView1.Size = New System.Drawing.Size(402, 246)
        Me.FjkDataGridView1.TabIndex = 4
        UnionCell1.BackgroundColor = System.Drawing.Color.Empty
        UnionCell1.Column = 0
        UnionCell1.ColumnSpan = 1
        UnionCell1.ErrorText = ""
        UnionCell1.ForeColor = System.Drawing.Color.Empty
        UnionCell1.Row = 0
        UnionCell1.RowSpan = 3
        UnionCell1.Style = DataGridViewCellStyle1
        UnionCell1.Text = Nothing
        UnionCell1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        UnionCell1.Value = Nothing
        UnionCell1.ValueType = Nothing
        UnionCell1.WrapMode = System.Windows.Forms.DataGridViewTriState.NotSet
        UnionCell2.BackgroundColor = System.Drawing.Color.Empty
        UnionCell2.Column = 1
        UnionCell2.ColumnSpan = 3
        UnionCell2.ErrorText = ""
        UnionCell2.ForeColor = System.Drawing.Color.Empty
        UnionCell2.Row = 0
        UnionCell2.RowSpan = 1
        UnionCell2.Style = DataGridViewCellStyle2
        UnionCell2.Text = Nothing
        UnionCell2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        UnionCell2.Value = Nothing
        UnionCell2.ValueType = Nothing
        UnionCell2.WrapMode = System.Windows.Forms.DataGridViewTriState.NotSet
        Me.FjkDataGridView1.UnionCells.Add(UnionCell1)
        Me.FjkDataGridView1.UnionCells.Add(UnionCell2)
        Me.FjkDataGridView1.UseWaitCursor = True
        '
        'ExForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(706, 487)
        Me.Controls.Add(Me.FjkDataGridView1)
        Me.Name = "ExForm"
        Me.Text = "Form1"
        Me.UseWaitCursor = True
        CType(Me.FjkDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FjkDataGridView1 As Fujikyu_Lib_R.FjkDataGridView
End Class
