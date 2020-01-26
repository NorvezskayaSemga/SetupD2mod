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
        Me.SoundLangLabel = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.TextLangLabel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PatchRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstallRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstallModeLabel = New System.Windows.Forms.Label()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.LangPanel = New System.Windows.Forms.Panel()
        Me.LangEnRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangRuRadioButton = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.LangPanel.SuspendLayout()
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
        Me.Panel5.Controls.Add(Me.RadioButton4)
        Me.Panel5.Controls.Add(Me.RadioButton5)
        Me.Panel5.Location = New System.Drawing.Point(4, 174)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(306, 51)
        Me.Panel5.TabIndex = 6
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(3, 26)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(59, 17)
        Me.RadioButton4.TabIndex = 1
        Me.RadioButton4.Text = "English"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton5.TabIndex = 0
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Русский"
        Me.RadioButton5.UseVisualStyleBackColor = True
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
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Location = New System.Drawing.Point(4, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(306, 51)
        Me.Panel2.TabIndex = 4
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(3, 26)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(59, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "English"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Русский"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.CheckBox2)
        Me.Panel4.Controls.Add(Me.CheckBox1)
        Me.Panel4.Location = New System.Drawing.Point(4, 231)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(306, 51)
        Me.Panel4.TabIndex = 4
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(4, 27)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(251, 17)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "Copy usful Tools and readme to the game folder"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(4, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(251, 17)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Try to download and install Verok's GL Wrapper"
        Me.CheckBox1.UseVisualStyleBackColor = True
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
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.LangPanel.ResumeLayout(False)
        Me.LangPanel.PerformLayout()
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
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents TextLangLabel As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents LangPanel As System.Windows.Forms.Panel
    Friend WithEvents LangEnRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LangRuRadioButton As System.Windows.Forms.RadioButton
End Class
