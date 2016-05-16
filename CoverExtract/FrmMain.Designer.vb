<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.BtnMainSource = New System.Windows.Forms.Button()
        Me.BtnMainTarget = New System.Windows.Forms.Button()
        Me.LblMainSource = New System.Windows.Forms.Label()
        Me.LblMainTarget = New System.Windows.Forms.Label()
        Me.BtnMainStart = New System.Windows.Forms.Button()
        Me.PgbMain = New System.Windows.Forms.ProgressBar()
        Me.BtnMainCancel = New System.Windows.Forms.Button()
        Me.BgwMain = New System.ComponentModel.BackgroundWorker()
        Me.NudMainFrame = New System.Windows.Forms.NumericUpDown()
        Me.LblMainFrame = New System.Windows.Forms.Label()
        Me.TtMain = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.NudMainFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnMainSource
        '
        Me.BtnMainSource.Location = New System.Drawing.Point(14, 16)
        Me.BtnMainSource.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnMainSource.Name = "BtnMainSource"
        Me.BtnMainSource.Size = New System.Drawing.Size(87, 30)
        Me.BtnMainSource.TabIndex = 0
        Me.BtnMainSource.Text = "Source"
        Me.TtMain.SetToolTip(Me.BtnMainSource, "Select the folder containing the mp4 files.")
        Me.BtnMainSource.UseVisualStyleBackColor = True
        '
        'BtnMainTarget
        '
        Me.BtnMainTarget.Location = New System.Drawing.Point(14, 54)
        Me.BtnMainTarget.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnMainTarget.Name = "BtnMainTarget"
        Me.BtnMainTarget.Size = New System.Drawing.Size(87, 30)
        Me.BtnMainTarget.TabIndex = 1
        Me.BtnMainTarget.Text = "Target"
        Me.TtMain.SetToolTip(Me.BtnMainTarget, "Select the folder you want to export the image files to.")
        Me.BtnMainTarget.UseVisualStyleBackColor = True
        '
        'LblMainSource
        '
        Me.LblMainSource.AutoSize = True
        Me.LblMainSource.Location = New System.Drawing.Point(108, 22)
        Me.LblMainSource.Name = "LblMainSource"
        Me.LblMainSource.Size = New System.Drawing.Size(105, 19)
        Me.LblMainSource.TabIndex = 2
        Me.LblMainSource.Text = "Choose a folder"
        '
        'LblMainTarget
        '
        Me.LblMainTarget.AutoSize = True
        Me.LblMainTarget.Location = New System.Drawing.Point(108, 60)
        Me.LblMainTarget.Name = "LblMainTarget"
        Me.LblMainTarget.Size = New System.Drawing.Size(105, 19)
        Me.LblMainTarget.TabIndex = 3
        Me.LblMainTarget.Text = "Choose a folder"
        '
        'BtnMainStart
        '
        Me.BtnMainStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnMainStart.Location = New System.Drawing.Point(14, 129)
        Me.BtnMainStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnMainStart.Name = "BtnMainStart"
        Me.BtnMainStart.Size = New System.Drawing.Size(87, 30)
        Me.BtnMainStart.TabIndex = 4
        Me.BtnMainStart.Text = "Start"
        Me.BtnMainStart.UseVisualStyleBackColor = True
        '
        'PgbMain
        '
        Me.PgbMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PgbMain.Location = New System.Drawing.Point(0, 167)
        Me.PgbMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PgbMain.Name = "PgbMain"
        Me.PgbMain.Size = New System.Drawing.Size(430, 30)
        Me.PgbMain.TabIndex = 5
        '
        'BtnMainCancel
        '
        Me.BtnMainCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnMainCancel.Enabled = False
        Me.BtnMainCancel.Location = New System.Drawing.Point(115, 129)
        Me.BtnMainCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnMainCancel.Name = "BtnMainCancel"
        Me.BtnMainCancel.Size = New System.Drawing.Size(87, 30)
        Me.BtnMainCancel.TabIndex = 6
        Me.BtnMainCancel.Text = "Cancel"
        Me.BtnMainCancel.UseVisualStyleBackColor = True
        '
        'BgwMain
        '
        Me.BgwMain.WorkerReportsProgress = True
        Me.BgwMain.WorkerSupportsCancellation = True
        '
        'NudMainFrame
        '
        Me.NudMainFrame.Location = New System.Drawing.Point(115, 92)
        Me.NudMainFrame.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NudMainFrame.Maximum = New Decimal(New Integer() {5184000, 0, 0, 0})
        Me.NudMainFrame.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMainFrame.Name = "NudMainFrame"
        Me.NudMainFrame.Size = New System.Drawing.Size(87, 25)
        Me.NudMainFrame.TabIndex = 7
        Me.TtMain.SetToolTip(Me.NudMainFrame, "Select the time in seconds for which a video frame is to be exported.")
        Me.NudMainFrame.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'LblMainFrame
        '
        Me.LblMainFrame.AutoSize = True
        Me.LblMainFrame.Location = New System.Drawing.Point(29, 94)
        Me.LblMainFrame.Name = "LblMainFrame"
        Me.LblMainFrame.Size = New System.Drawing.Size(59, 19)
        Me.LblMainFrame.TabIndex = 8
        Me.LblMainFrame.Text = "Seconds"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 197)
        Me.Controls.Add(Me.LblMainFrame)
        Me.Controls.Add(Me.NudMainFrame)
        Me.Controls.Add(Me.BtnMainCancel)
        Me.Controls.Add(Me.PgbMain)
        Me.Controls.Add(Me.BtnMainStart)
        Me.Controls.Add(Me.LblMainTarget)
        Me.Controls.Add(Me.LblMainSource)
        Me.Controls.Add(Me.BtnMainTarget)
        Me.Controls.Add(Me.BtnMainSource)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(236, 236)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CoverExtract"
        CType(Me.NudMainFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnMainSource As Button
    Friend WithEvents BtnMainTarget As Button
    Friend WithEvents LblMainSource As Label
    Friend WithEvents LblMainTarget As Label
    Friend WithEvents BtnMainStart As Button
    Friend WithEvents PgbMain As ProgressBar
    Friend WithEvents BtnMainCancel As Button
    Friend WithEvents BgwMain As System.ComponentModel.BackgroundWorker
    Friend WithEvents NudMainFrame As NumericUpDown
    Friend WithEvents LblMainFrame As Label
    Friend WithEvents TtMain As ToolTip
End Class
