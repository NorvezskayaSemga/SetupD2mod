﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Me.GAILabel = New System.Windows.Forms.Label()
        Me.PanelDifficulty = New System.Windows.Forms.Panel()
        Me.ExpPlusGAIRadioButton = New System.Windows.Forms.RadioButton()
        Me.NormalGAIRadioButton = New System.Windows.Forms.RadioButton()
        Me.VanillaGAIRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangPanel = New System.Windows.Forms.Panel()
        Me.LangEnRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangRuRadioButton = New System.Windows.Forms.RadioButton()
        Me.SoundLangLabel = New System.Windows.Forms.Label()
        Me.PanelSoundLang = New System.Windows.Forms.Panel()
        Me.EnSoundRadioButton = New System.Windows.Forms.RadioButton()
        Me.RuSoundRadioButton = New System.Windows.Forms.RadioButton()
        Me.TextLangLabel = New System.Windows.Forms.Label()
        Me.PanelTextLang = New System.Windows.Forms.Panel()
        Me.EnTextRadioButton = New System.Windows.Forms.RadioButton()
        Me.RuTextRadioButton = New System.Windows.Forms.RadioButton()
        Me.PanelOther = New System.Windows.Forms.Panel()
        Me.DmgLimitCheckBox = New System.Windows.Forms.CheckBox()
        Me.ToolsCheckBox = New System.Windows.Forms.CheckBox()
        Me.GLWrapperCheckBox = New System.Windows.Forms.CheckBox()
        Me.PanelInstallation = New System.Windows.Forms.Panel()
        Me.PatchRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstallRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstallModeLabel = New System.Windows.Forms.Label()
        Me.InstallButton = New System.Windows.Forms.Button()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.PanelDifficulty.SuspendLayout()
        Me.LangPanel.SuspendLayout()
        Me.PanelSoundLang.SuspendLayout()
        Me.PanelTextLang.SuspendLayout()
        Me.PanelOther.SuspendLayout()
        Me.PanelInstallation.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancButton
        '
        Me.CancButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancButton.Location = New System.Drawing.Point(456, 411)
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
        Me.BackButton.Location = New System.Drawing.Point(249, 411)
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
        Me.PictureBox.Size = New System.Drawing.Size(236, 447)
        Me.PictureBox.TabIndex = 8
        Me.PictureBox.TabStop = False
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.GAILabel)
        Me.Panel.Controls.Add(Me.PanelDifficulty)
        Me.Panel.Controls.Add(Me.LangPanel)
        Me.Panel.Controls.Add(Me.SoundLangLabel)
        Me.Panel.Controls.Add(Me.PanelSoundLang)
        Me.Panel.Controls.Add(Me.TextLangLabel)
        Me.Panel.Controls.Add(Me.PanelTextLang)
        Me.Panel.Controls.Add(Me.PanelOther)
        Me.Panel.Controls.Add(Me.PanelInstallation)
        Me.Panel.Controls.Add(Me.InstallModeLabel)
        Me.Panel.Location = New System.Drawing.Point(242, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(360, 405)
        Me.Panel.TabIndex = 9
        '
        'GAILabel
        '
        Me.GAILabel.AutoSize = True
        Me.GAILabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GAILabel.Location = New System.Drawing.Point(5, 230)
        Me.GAILabel.Name = "GAILabel"
        Me.GAILabel.Size = New System.Drawing.Size(63, 16)
        Me.GAILabel.TabIndex = 9
        Me.GAILabel.Text = "InfoLabel"
        '
        'PanelDifficulty
        '
        Me.PanelDifficulty.Controls.Add(Me.ExpPlusGAIRadioButton)
        Me.PanelDifficulty.Controls.Add(Me.NormalGAIRadioButton)
        Me.PanelDifficulty.Controls.Add(Me.VanillaGAIRadioButton)
        Me.PanelDifficulty.Location = New System.Drawing.Point(4, 256)
        Me.PanelDifficulty.Name = "PanelDifficulty"
        Me.PanelDifficulty.Size = New System.Drawing.Size(306, 70)
        Me.PanelDifficulty.TabIndex = 7
        '
        'ExpPlusGAIRadioButton
        '
        Me.ExpPlusGAIRadioButton.AutoSize = True
        Me.ExpPlusGAIRadioButton.Location = New System.Drawing.Point(3, 49)
        Me.ExpPlusGAIRadioButton.Name = "ExpPlusGAIRadioButton"
        Me.ExpPlusGAIRadioButton.Size = New System.Drawing.Size(282, 17)
        Me.ExpPlusGAIRadioButton.TabIndex = 7
        Me.ExpPlusGAIRadioButton.Text = "Use exp+ mod AI (more experience for AI and neutrals)"
        Me.ExpPlusGAIRadioButton.UseVisualStyleBackColor = True
        '
        'NormalGAIRadioButton
        '
        Me.NormalGAIRadioButton.AutoSize = True
        Me.NormalGAIRadioButton.Checked = True
        Me.NormalGAIRadioButton.Location = New System.Drawing.Point(4, 26)
        Me.NormalGAIRadioButton.Name = "NormalGAIRadioButton"
        Me.NormalGAIRadioButton.Size = New System.Drawing.Size(243, 17)
        Me.NormalGAIRadioButton.TabIndex = 6
        Me.NormalGAIRadioButton.TabStop = True
        Me.NormalGAIRadioButton.Text = "Use normal mod AI (as intended by the author)"
        Me.NormalGAIRadioButton.UseVisualStyleBackColor = True
        '
        'VanillaGAIRadioButton
        '
        Me.VanillaGAIRadioButton.AutoSize = True
        Me.VanillaGAIRadioButton.Location = New System.Drawing.Point(4, 3)
        Me.VanillaGAIRadioButton.Name = "VanillaGAIRadioButton"
        Me.VanillaGAIRadioButton.Size = New System.Drawing.Size(144, 17)
        Me.VanillaGAIRadioButton.TabIndex = 5
        Me.VanillaGAIRadioButton.Text = "Use vanilla AI (very easy)"
        Me.VanillaGAIRadioButton.UseVisualStyleBackColor = True
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
        Me.SoundLangLabel.Location = New System.Drawing.Point(4, 149)
        Me.SoundLangLabel.Name = "SoundLangLabel"
        Me.SoundLangLabel.Size = New System.Drawing.Size(63, 16)
        Me.SoundLangLabel.TabIndex = 7
        Me.SoundLangLabel.Text = "InfoLabel"
        '
        'PanelSoundLang
        '
        Me.PanelSoundLang.Controls.Add(Me.EnSoundRadioButton)
        Me.PanelSoundLang.Controls.Add(Me.RuSoundRadioButton)
        Me.PanelSoundLang.Location = New System.Drawing.Point(4, 168)
        Me.PanelSoundLang.Name = "PanelSoundLang"
        Me.PanelSoundLang.Size = New System.Drawing.Size(306, 51)
        Me.PanelSoundLang.TabIndex = 5
        '
        'EnSoundRadioButton
        '
        Me.EnSoundRadioButton.AutoSize = True
        Me.EnSoundRadioButton.Location = New System.Drawing.Point(3, 26)
        Me.EnSoundRadioButton.Name = "EnSoundRadioButton"
        Me.EnSoundRadioButton.Size = New System.Drawing.Size(59, 17)
        Me.EnSoundRadioButton.TabIndex = 1
        Me.EnSoundRadioButton.Text = "English"
        Me.EnSoundRadioButton.UseVisualStyleBackColor = True
        '
        'RuSoundRadioButton
        '
        Me.RuSoundRadioButton.AutoSize = True
        Me.RuSoundRadioButton.Checked = True
        Me.RuSoundRadioButton.Location = New System.Drawing.Point(3, 3)
        Me.RuSoundRadioButton.Name = "RuSoundRadioButton"
        Me.RuSoundRadioButton.Size = New System.Drawing.Size(67, 17)
        Me.RuSoundRadioButton.TabIndex = 0
        Me.RuSoundRadioButton.TabStop = True
        Me.RuSoundRadioButton.Text = "Русский"
        Me.RuSoundRadioButton.UseVisualStyleBackColor = True
        '
        'TextLangLabel
        '
        Me.TextLangLabel.AutoSize = True
        Me.TextLangLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextLangLabel.Location = New System.Drawing.Point(4, 76)
        Me.TextLangLabel.Name = "TextLangLabel"
        Me.TextLangLabel.Size = New System.Drawing.Size(63, 16)
        Me.TextLangLabel.TabIndex = 5
        Me.TextLangLabel.Text = "InfoLabel"
        '
        'PanelTextLang
        '
        Me.PanelTextLang.Controls.Add(Me.EnTextRadioButton)
        Me.PanelTextLang.Controls.Add(Me.RuTextRadioButton)
        Me.PanelTextLang.Location = New System.Drawing.Point(4, 95)
        Me.PanelTextLang.Name = "PanelTextLang"
        Me.PanelTextLang.Size = New System.Drawing.Size(306, 51)
        Me.PanelTextLang.TabIndex = 4
        '
        'EnTextRadioButton
        '
        Me.EnTextRadioButton.AutoSize = True
        Me.EnTextRadioButton.Location = New System.Drawing.Point(3, 26)
        Me.EnTextRadioButton.Name = "EnTextRadioButton"
        Me.EnTextRadioButton.Size = New System.Drawing.Size(59, 17)
        Me.EnTextRadioButton.TabIndex = 1
        Me.EnTextRadioButton.Text = "English"
        Me.EnTextRadioButton.UseVisualStyleBackColor = True
        '
        'RuTextRadioButton
        '
        Me.RuTextRadioButton.AutoSize = True
        Me.RuTextRadioButton.Checked = True
        Me.RuTextRadioButton.Location = New System.Drawing.Point(3, 3)
        Me.RuTextRadioButton.Name = "RuTextRadioButton"
        Me.RuTextRadioButton.Size = New System.Drawing.Size(67, 17)
        Me.RuTextRadioButton.TabIndex = 0
        Me.RuTextRadioButton.TabStop = True
        Me.RuTextRadioButton.Text = "Русский"
        Me.RuTextRadioButton.UseVisualStyleBackColor = True
        '
        'PanelOther
        '
        Me.PanelOther.Controls.Add(Me.DmgLimitCheckBox)
        Me.PanelOther.Controls.Add(Me.ToolsCheckBox)
        Me.PanelOther.Controls.Add(Me.GLWrapperCheckBox)
        Me.PanelOther.Location = New System.Drawing.Point(4, 332)
        Me.PanelOther.Name = "PanelOther"
        Me.PanelOther.Size = New System.Drawing.Size(306, 70)
        Me.PanelOther.TabIndex = 6
        '
        'DmgLimitCheckBox
        '
        Me.DmgLimitCheckBox.AutoSize = True
        Me.DmgLimitCheckBox.Checked = True
        Me.DmgLimitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DmgLimitCheckBox.Location = New System.Drawing.Point(3, 50)
        Me.DmgLimitCheckBox.Name = "DmgLimitCheckBox"
        Me.DmgLimitCheckBox.Size = New System.Drawing.Size(149, 17)
        Me.DmgLimitCheckBox.TabIndex = 4
        Me.DmgLimitCheckBox.Text = "Remove max damage limit"
        Me.DmgLimitCheckBox.UseVisualStyleBackColor = True
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
        'PanelInstallation
        '
        Me.PanelInstallation.Controls.Add(Me.PatchRadioButton)
        Me.PanelInstallation.Controls.Add(Me.InstallRadioButton)
        Me.PanelInstallation.Location = New System.Drawing.Point(4, 22)
        Me.PanelInstallation.Name = "PanelInstallation"
        Me.PanelInstallation.Size = New System.Drawing.Size(306, 51)
        Me.PanelInstallation.TabIndex = 3
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
        Me.InstallModeLabel.Location = New System.Drawing.Point(4, 3)
        Me.InstallModeLabel.Name = "InstallModeLabel"
        Me.InstallModeLabel.Size = New System.Drawing.Size(63, 16)
        Me.InstallModeLabel.TabIndex = 2
        Me.InstallModeLabel.Text = "InfoLabel"
        '
        'InstallButton
        '
        Me.InstallButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstallButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InstallButton.Location = New System.Drawing.Point(348, 411)
        Me.InstallButton.Name = "InstallButton"
        Me.InstallButton.Size = New System.Drawing.Size(66, 24)
        Me.InstallButton.TabIndex = 0
        Me.InstallButton.Text = "Next"
        Me.InstallButton.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 447)
        Me.Controls.Add(Me.InstallButton)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.CancButton)
        Me.Controls.Add(Me.BackButton)
        Me.Name = "SettingsForm"
        Me.Text = "Step2"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.PanelDifficulty.ResumeLayout(False)
        Me.PanelDifficulty.PerformLayout()
        Me.LangPanel.ResumeLayout(False)
        Me.LangPanel.PerformLayout()
        Me.PanelSoundLang.ResumeLayout(False)
        Me.PanelSoundLang.PerformLayout()
        Me.PanelTextLang.ResumeLayout(False)
        Me.PanelTextLang.PerformLayout()
        Me.PanelOther.ResumeLayout(False)
        Me.PanelOther.PerformLayout()
        Me.PanelInstallation.ResumeLayout(False)
        Me.PanelInstallation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancButton As System.Windows.Forms.Button
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents PanelOther As System.Windows.Forms.Panel
    Friend WithEvents PanelInstallation As System.Windows.Forms.Panel
    Friend WithEvents PatchRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InstallRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents SoundLangLabel As System.Windows.Forms.Label
    Friend WithEvents PanelSoundLang As System.Windows.Forms.Panel
    Friend WithEvents EnSoundRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RuSoundRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TextLangLabel As System.Windows.Forms.Label
    Friend WithEvents PanelTextLang As System.Windows.Forms.Panel
    Friend WithEvents EnTextRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RuTextRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ToolsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GLWrapperCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents InstallButton As System.Windows.Forms.Button
    Friend WithEvents LangPanel As System.Windows.Forms.Panel
    Friend WithEvents LangEnRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LangRuRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DmgLimitCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents InstallModeLabel As System.Windows.Forms.Label
    Friend WithEvents PanelDifficulty As System.Windows.Forms.Panel
    Friend WithEvents ExpPlusGAIRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents NormalGAIRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents VanillaGAIRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents GAILabel As System.Windows.Forms.Label
End Class
