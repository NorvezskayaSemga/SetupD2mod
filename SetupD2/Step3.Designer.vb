﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step3
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
        Me.Panel = New System.Windows.Forms.Panel()
        Me.LangPanel = New System.Windows.Forms.Panel()
        Me.LangRuRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangEnRadioButton = New System.Windows.Forms.RadioButton()
        Me.HintPanel = New System.Windows.Forms.Panel()
        Me.HintLabel32 = New System.Windows.Forms.Label()
        Me.HintLabel12 = New System.Windows.Forms.Label()
        Me.SiteLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.HintLabel31 = New System.Windows.Forms.Label()
        Me.HintLabel2 = New System.Windows.Forms.Label()
        Me.GuideLabel = New System.Windows.Forms.LinkLabel()
        Me.HintLabel11 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.FinishButton = New System.Windows.Forms.Button()
        Me.CancButton = New System.Windows.Forms.Button()
        Me.Panel.SuspendLayout()
        Me.LangPanel.SuspendLayout()
        Me.HintPanel.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.LangPanel)
        Me.Panel.Controls.Add(Me.HintPanel)
        Me.Panel.Controls.Add(Me.ProgressBar)
        Me.Panel.Location = New System.Drawing.Point(244, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(360, 284)
        Me.Panel.TabIndex = 14
        '
        'LangPanel
        '
        Me.LangPanel.Controls.Add(Me.LangRuRadioButton)
        Me.LangPanel.Controls.Add(Me.LangEnRadioButton)
        Me.LangPanel.Location = New System.Drawing.Point(302, 11)
        Me.LangPanel.Name = "LangPanel"
        Me.LangPanel.Size = New System.Drawing.Size(55, 45)
        Me.LangPanel.TabIndex = 5
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
        'HintPanel
        '
        Me.HintPanel.Controls.Add(Me.HintLabel32)
        Me.HintPanel.Controls.Add(Me.HintLabel12)
        Me.HintPanel.Controls.Add(Me.SiteLinkLabel)
        Me.HintPanel.Controls.Add(Me.HintLabel31)
        Me.HintPanel.Controls.Add(Me.HintLabel2)
        Me.HintPanel.Controls.Add(Me.GuideLabel)
        Me.HintPanel.Controls.Add(Me.HintLabel11)
        Me.HintPanel.Location = New System.Drawing.Point(3, 3)
        Me.HintPanel.Name = "HintPanel"
        Me.HintPanel.Size = New System.Drawing.Size(293, 212)
        Me.HintPanel.TabIndex = 6
        '
        'HintLabel32
        '
        Me.HintLabel32.AutoSize = True
        Me.HintLabel32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel32.Location = New System.Drawing.Point(152, 60)
        Me.HintLabel32.Name = "HintLabel32"
        Me.HintLabel32.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel32.TabIndex = 9
        Me.HintLabel32.Text = "InfoLabel"
        '
        'HintLabel12
        '
        Me.HintLabel12.AutoSize = True
        Me.HintLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel12.Location = New System.Drawing.Point(152, 6)
        Me.HintLabel12.Name = "HintLabel12"
        Me.HintLabel12.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel12.TabIndex = 8
        Me.HintLabel12.Text = "InfoLabel"
        '
        'SiteLinkLabel
        '
        Me.SiteLinkLabel.AutoSize = True
        Me.SiteLinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SiteLinkLabel.Location = New System.Drawing.Point(73, 60)
        Me.SiteLinkLabel.Name = "SiteLinkLabel"
        Me.SiteLinkLabel.Size = New System.Drawing.Size(73, 16)
        Me.SiteLinkLabel.TabIndex = 7
        Me.SiteLinkLabel.TabStop = True
        Me.SiteLinkLabel.Text = "LinkLabel2"
        '
        'HintLabel31
        '
        Me.HintLabel31.AutoSize = True
        Me.HintLabel31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel31.Location = New System.Drawing.Point(3, 60)
        Me.HintLabel31.Name = "HintLabel31"
        Me.HintLabel31.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel31.TabIndex = 6
        Me.HintLabel31.Text = "InfoLabel"
        '
        'HintLabel2
        '
        Me.HintLabel2.AutoSize = True
        Me.HintLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel2.Location = New System.Drawing.Point(3, 30)
        Me.HintLabel2.Name = "HintLabel2"
        Me.HintLabel2.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel2.TabIndex = 5
        Me.HintLabel2.Text = "InfoLabel"
        '
        'GuideLabel
        '
        Me.GuideLabel.AutoSize = True
        Me.GuideLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GuideLabel.Location = New System.Drawing.Point(73, 6)
        Me.GuideLabel.Name = "GuideLabel"
        Me.GuideLabel.Size = New System.Drawing.Size(73, 16)
        Me.GuideLabel.TabIndex = 4
        Me.GuideLabel.TabStop = True
        Me.GuideLabel.Text = "LinkLabel1"
        '
        'HintLabel11
        '
        Me.HintLabel11.AutoSize = True
        Me.HintLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel11.Location = New System.Drawing.Point(3, 6)
        Me.HintLabel11.Name = "HintLabel11"
        Me.HintLabel11.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel11.TabIndex = 2
        Me.HintLabel11.Text = "InfoLabel"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(3, 255)
        Me.ProgressBar.Maximum = 1000
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(354, 25)
        Me.ProgressBar.TabIndex = 3
        '
        'PictureBox
        '
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(236, 336)
        Me.PictureBox.TabIndex = 13
        Me.PictureBox.TabStop = False
        '
        'FinishButton
        '
        Me.FinishButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FinishButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FinishButton.Location = New System.Drawing.Point(323, 300)
        Me.FinishButton.Name = "FinishButton"
        Me.FinishButton.Size = New System.Drawing.Size(66, 24)
        Me.FinishButton.TabIndex = 10
        Me.FinishButton.Text = "Finish"
        Me.FinishButton.UseVisualStyleBackColor = True
        '
        'CancButton
        '
        Me.CancButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancButton.Location = New System.Drawing.Point(542, 300)
        Me.CancButton.Name = "CancButton"
        Me.CancButton.Size = New System.Drawing.Size(66, 24)
        Me.CancButton.TabIndex = 12
        Me.CancButton.Text = "Cancel"
        Me.CancButton.UseVisualStyleBackColor = True
        '
        'Step3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 336)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.FinishButton)
        Me.Controls.Add(Me.CancButton)
        Me.Name = "Step3"
        Me.Text = "Step3"
        Me.Panel.ResumeLayout(False)
        Me.LangPanel.ResumeLayout(False)
        Me.LangPanel.PerformLayout()
        Me.HintPanel.ResumeLayout(False)
        Me.HintPanel.PerformLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents HintLabel11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents FinishButton As System.Windows.Forms.Button
    Friend WithEvents CancButton As System.Windows.Forms.Button
    Friend WithEvents GuideLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents LangPanel As System.Windows.Forms.Panel
    Friend WithEvents LangEnRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LangRuRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents HintPanel As System.Windows.Forms.Panel
    Friend WithEvents HintLabel2 As System.Windows.Forms.Label
    Friend WithEvents SiteLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents HintLabel31 As System.Windows.Forms.Label
    Friend WithEvents HintLabel12 As System.Windows.Forms.Label
    Friend WithEvents HintLabel32 As System.Windows.Forms.Label
End Class
