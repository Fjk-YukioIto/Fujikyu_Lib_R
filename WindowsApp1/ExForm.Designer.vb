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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FjkButton1 = New Fujikyu_Lib_R.FjkButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(426, 297)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(311, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FjkButton1
        '
        Me.FjkButton1.ChangeColorIfEnter = False
        Me.FjkButton1.ChangeColorIfFocus = True
        Me.FjkButton1.EnterBackColor = System.Drawing.Color.Gray
        Me.FjkButton1.EnterForeColor = System.Drawing.Color.White
        Me.FjkButton1.Location = New System.Drawing.Point(451, 359)
        Me.FjkButton1.Name = "FjkButton1"
        Me.FjkButton1.Size = New System.Drawing.Size(141, 56)
        Me.FjkButton1.TabIndex = 0
        Me.FjkButton1.Text = "FjkButton1"
        Me.FjkButton1.UseVisualStyleBackColor = True
        '
        'ExForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(645, 467)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FjkButton1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ExForm"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FjkButton1 As Fujikyu_Lib_R.FjkButton
    Friend WithEvents Button1 As Button
End Class
