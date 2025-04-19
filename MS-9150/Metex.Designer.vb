<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Metex
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBoxPorts = New System.Windows.Forms.ComboBox()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.SpinEditInterval = New System.Windows.Forms.NumericUpDown()
        Me.Ontvangen = New System.Windows.Forms.Label()
        Me.ms = New System.Windows.Forms.Label()
        Me.Puls = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SpinEditInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxPorts
        '
        Me.ComboBoxPorts.FormattingEnabled = True
        Me.ComboBoxPorts.Location = New System.Drawing.Point(12, 132)
        Me.ComboBoxPorts.Name = "ComboBoxPorts"
        Me.ComboBoxPorts.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxPorts.TabIndex = 0
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(456, 129)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(120, 23)
        Me.ButtonConnect.TabIndex = 4
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'SpinEditInterval
        '
        Me.SpinEditInterval.Location = New System.Drawing.Point(139, 132)
        Me.SpinEditInterval.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.SpinEditInterval.Minimum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.SpinEditInterval.Name = "SpinEditInterval"
        Me.SpinEditInterval.Size = New System.Drawing.Size(50, 20)
        Me.SpinEditInterval.TabIndex = 7
        Me.SpinEditInterval.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'Ontvangen
        '
        Me.Ontvangen.AutoSize = True
        Me.Ontvangen.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ontvangen.Location = New System.Drawing.Point(12, 18)
        Me.Ontvangen.Name = "Ontvangen"
        Me.Ontvangen.Size = New System.Drawing.Size(485, 73)
        Me.Ontvangen.TabIndex = 8
        Me.Ontvangen.Text = "Metex MS-9150"
        '
        'ms
        '
        Me.ms.AutoSize = True
        Me.ms.Location = New System.Drawing.Point(191, 134)
        Me.ms.Name = "ms"
        Me.ms.Size = New System.Drawing.Size(20, 13)
        Me.ms.TabIndex = 9
        Me.ms.Text = "ms"
        '
        'Puls
        '
        Me.Puls.BackColor = System.Drawing.SystemColors.Control
        Me.Puls.Location = New System.Drawing.Point(220, 136)
        Me.Puls.Name = "Puls"
        Me.Puls.Size = New System.Drawing.Size(10, 10)
        Me.Puls.TabIndex = 10
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 170)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(588, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel1.Text = "No Connection"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(445, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "ON7LDS"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(29, 17)
        Me.ToolStripStatusLabel3.Text = "Vx.x"
        '
        'Metex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 192)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Puls)
        Me.Controls.Add(Me.ms)
        Me.Controls.Add(Me.Ontvangen)
        Me.Controls.Add(Me.SpinEditInterval)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.ComboBoxPorts)
        Me.Name = "Metex"
        Me.Text = "MS-9150"
        CType(Me.SpinEditInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxPorts As ComboBox
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents SpinEditInterval As NumericUpDown
    Friend WithEvents Ontvangen As Label
    Friend WithEvents ms As Label
    Friend WithEvents Puls As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
End Class
