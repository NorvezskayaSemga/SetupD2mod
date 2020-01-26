<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CancButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.LangPanel = New System.Windows.Forms.Panel()
        Me.LangEnRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangRuRadioButton = New System.Windows.Forms.RadioButton()
        Me.SoundLangLabel = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.EnRadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RuRadioButton2 = New System.Windows.Forms.RadioButton()
        Me.TextLangLabel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.EnRadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RuRadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolsCheckBox = New System.Windows.Forms.CheckBox()
        Me.GLWrapperCheckBox = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PatchRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstallRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstallModeLabel = New System.Windows.Forms.Label()
        Me.NextButton = New System.Windows.Forms.Button()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.LangPanel.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancButton
        '
        Me.CancButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancButton.Location = New System.Drawing.Point(456, 300)
        Me.CancButton.Name = "CancButton"
        Me.CancButton.Size = New System.Drawing.Size(66, 24)
        Me.CancButton.TabIndex = 7
        Me.CancButton.Text = "Cancel"
        Me.CancButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BackButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BackButton.Location = New System.Drawing.Point(249, 300)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(66, 24)
        Me.BackButton.TabIndex = 6
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'PictureBox
        '
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(236, 336)
        Me.PictureBox.TabIndex = 8
        Me.PictureBox.TabStop = False
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.LangPanel)
        Me.Panel.Controls.Add(Me.SoundLangLabel)
        Me.Panel.Controls.Add(Me.Panel5)
        Me.Panel.Controls.Add(Me.TextLangLabel)
        Me.Panel.Controls.Add(Me.Panel2)
        Me.Panel.Controls.Add(Me.Panel4)
        Me.Panel.Controls.Add(Me.Panel3)
        Me.Panel.Controls.Add(Me.InstallModeLabel)
        Me.Panel.Location = New System.Drawing.Point(242, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(360, 284)
        Me.Panel.TabIndex = 9
        '
        'LangPanel
        '
        Me.LangPanel.Controls.Add(Me.LangEnRadioButton)
        Me.LangPanel.Controls.Add(Me.LangRuRadioButton)
        Me.LangPanel.Location = New System.Drawing.Point(316, 207)
        Me.LangPanel.Name = "LangPanel"
        Me.LangPanel.Size = New System.Drawing.Size(55, 45)
        Me.LangPanel.TabIndex = 8
        '
        'LangEnRadioButton
        '
        Me.LangEnRadioButton.AutoSize = True
        Me.LangEnRadioButton.Location = New System.Drawing.Point(9, 22)
        Me.LangEnRadioButton.Name = "LangEnRadioButton"
        Me.LangEnRadioButton.Size = New System.Drawing.Size(44, 17)
        Me.LangEnRadioButton.TabIndex = 1
        Me.LangEnRadioButton.TabStop = True
        Me.LangEnRadioButton.Text = "Eng"
        Me.LangEnRadioButton.UseVisualStyleBackColor = True
        '
        'LangRuRadioButton
        '
        Me.LangRuRadioButton.AutoSize = True
        Me.LangRuRadioButton.Location = New System.Drawing.Point(9, 3)
        Me.LangRuRadioButton.Name = "LangRuRadioButton"
        Me.LangRuRadioButton.Size = New System.Drawing.Size(43, 17)
        Me.LangRuRadioButton.TabIndex = 0
        Me.LangRuRadioButton.TabStop = True
        Me.LangRuRadioButton.Text = "Рус"
        Me.LangRuRadioButton.UseVisualStyleBackColor = True
        '
        'SoundLangLabel
        '
        Me.SoundLangLabel.AutoSize = True
        Me.SoundLangLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SoundLangLabel.Location = New System.Drawing.Point(4, 155)
        Me.SoundLangLabel.Name = "SoundLangLabel"
        Me.SoundLangLabel.Size = New System.Drawing.Size(63, 16)
        Me.SoundLangLabel.TabIndex = 7
        Me.SoundLangLabel.Text = "InfoLabel"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.EnRadioButton2)
        Me.Panel5.Controls.Add(Me.RuRadioButton2)
        Me.Panel5.Location = New System.Drawing.Point(4, 174)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(306, 51)
        Me.Panel5.TabIndex = 5
        '
        'EnRadioButton2
        '
        Me.EnRadioButton2.AutoSize = True
        Me.EnRadioButton2.Location = New System.Drawing.Point(3, 26)
        Me.EnRadioButton2.Name = "EnRadioButton2"
        Me.EnRadioButton2.Size = New System.Drawing.Size(59, 17)
        Me.EnRadioButton2.TabIndex = 1
        Me.EnRadioButton2.Text = "English"
        Me.EnRadioButton2.UseVisualStyleBackColor = True
        '
        'RuRadioButton2
        '
        Me.RuRadioButton2.AutoSize = True
        Me.RuRadioButton2.Checked = True
        Me.RuRadioButton2.Location = New System.Drawing.Point(3, 3)
        Me.RuRadioButton2.Name = "RuRadioButton2"
        Me.RuRadioButton2.Size = New System.Drawing.Size(67, 17)
        Me.RuRadioButton2.TabIndex = 0
        Me.RuRadioButton2.TabStop = True
        Me.RuRadioButton2.Text = "Русский"
        Me.RuRadioButton2.UseVisualStyleBackColor = True
        '
        'TextLangLabel
        '
        Me.TextLangLabel.AutoSize = True
        Me.TextLangLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextLangLabel.Location = New System.Drawing.Point(4, 82)
        Me.TextLangLabel.Name = "TextLangLabel"
        Me.TextLangLabel.Size = New System.Drawing.Size(63, 16)
        Me.TextLangLabel.TabIndex = 5
        Me.TextLangLabel.Text = "InfoLabel"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.EnRadioButton1)
        Me.Panel2.Controls.Add(Me.RuRadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(4, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(306, 51)
        Me.Panel2.TabIndex = 4
        '
        'EnRadioButton1
        '
        Me.EnRadioButton1.AutoSize = True
        Me.EnRadioButton1.Location = New System.Drawing.Point(3, 26)
        Me.EnRadioButton1.Name = "EnRadioButton1"
        Me.EnRadioButton1.Size = New System.Drawing.Size(59, 17)
        Me.EnRadioButton1.TabIndex = 1
        Me.EnRadioButton1.Text = "English"
        Me.EnRadioButton1.UseVisualStyleBackColor = True
        '
        'RuRadioButton1
        '
        Me.RuRadioButton1.AutoSize = True
        Me.RuRadioButton1.Checked = True
        Me.RuRadioButton1.Location = New System.Drawing.Point(3, 3)
        Me.RuRadioButton1.Name = "RuRadioButton1"
        Me.RuRadioButton1.Size = New System.Drawing.Size(67, 17)
        Me.RuRadioButton1.TabIndex = 0
        Me.RuRadioButton1.TabStop = True
        Me.RuRadioButton1.Text = "Русский"
        Me.RuRadioButton1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ToolsCheckBox)
        Me.Panel4.Controls.Add(Me.GLWrapperCheckBox)
        Me.Panel4.Location = New System.Drawing.Point(4, 231)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(306, 51)
        Me.Panel4.TabIndex = 6
        '
        'ToolsCheckBox
        '
        Me.ToolsCheckBox.AutoSize = True
        Me.ToolsCheckBox.Checked = True
        Me.ToolsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolsCheckBox.Location = New System.Drawing.Point(4, 27)
        Me.ToolsCheckBox.Name = "ToolsCheckBox"
        Me.ToolsCheckBox.Size = New System.Drawing.Size(251, 17)
        Me.ToolsCheckBox.TabIndex = 3
        Me.ToolsCheckBox.Text = "Copy usful Tools and readme to the game folder"
        Me.ToolsCheckBox.UseVisualStyleBackColor = True
        '
        'GLWrapperCheckBox
        '
        Me.GLWrapperCheckBox.AutoSize = True
        Me.GLWrapperCheckBox.Checked = True
        Me.GLWrapperCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GLWrapperCheckBox.Location = New System.Drawing.Point(4, 4)
        Me.GLWrapperCheckBox.Name = "GLWrapperCheckBox"
        Me.GLWrapperCheckBox.Size = New System.Drawing.Size(251, 17)
        Me.GLWrapperCheckBox.TabIndex = 2
        Me.GLWrapperCheckBox.Text = "Try to download and install Verok's GL Wrapper"
        Me.GLWrapperCheckBox.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PatchRadioButton)
        Me.Panel3.Controls.Add(Me.InstallRadioButton)
        Me.Panel3.Location = New System.Drawing.Point(4, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(306, 51)
        Me.Panel3.TabIndex = 3
        '
        'PatchRadioButton
        '
        Me.PatchRadioButton.AutoSize = True
        Me.PatchRadioButton.Location = New System.Drawing.Point(3, 26)
        Me.PatchRadioButton.Name = "PatchRadioButton"
        Me.PatchRadioButton.Size = New System.Drawing.Size(234, 17)
        Me.PatchRadioButton.TabIndex = 1
        Me.PatchRadioButton.Text = "Patch my game (GOG, Russobit-M or Akella)"
        Me.PatchRadioButton.UseVisualStyleBackColor = True
        '
        'InstallRadioButton
        '
        Me.InstallRadioButton.AutoSize = True
        Me.InstallRadioButton.Checked = True
        Me.InstallRadioButton.Location = New System.Drawing.Point(3, 3)
        Me.InstallRadioButton.Name = "InstallRadioButton"
        Me.InstallRadioButton.Size = New System.Drawing.Size(139, 17)
        Me.InstallRadioButton.TabIndex = 0
        Me.InstallRadioButton.TabStop = True
        Me.InstallRadioButton.Text = "Install full patched game"
        Me.InstallRadioButton.UseVisualStyleBackColor = True
        '
        'InstallModeLabel
        '
        Me.InstallModeLabel.AutoSize = True
        Me.InstallModeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InstallModeLabel.Location = New System.Drawing.Point(4, 9)
        Me.InstallModeLabel.Name = "InstallModeLabel"
        Me.InstallModeLabel.Size = New System.Drawing.Size(63, 16)
        Me.InstallModeLabel.TabIndex = 2
        Me.InstallModeLabel.Text = "InfoLabel"
        '
        'NextButton
        '
        Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NextButton.Location = New System.Drawing.Point(348, 300)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(66, 24)
        Me.NextButton.TabIndex = 10
        Me.NextButton.Text = "Next"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'Step2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 336)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.CancButton)
        Me.Controls.Add(Me.BackButton)
        Me.Name = "Step2"
        Me.Text = "Step2"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.LangPanel.ResumeLayout(False)
        Me.LangPanel.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancButton As System.Windows.Forms.Button
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PatchRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InstallRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InstallModeLabel As System.Windows.Forms.Label
    Friend WithEvents SoundLangLabel As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents EnRadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RuRadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents TextLangLabel As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EnRadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RuRadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents ToolsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GLWrapperCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents LangPanel As System.Windows.Forms.Panel
    Friend WithEvents LangEnRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LangRuRadioButton As System.Windows.Forms.RadioButton
End Class
