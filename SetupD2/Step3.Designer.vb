<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstallForm
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
        Me.InstallationProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ProgressLabel = New System.Windows.Forms.Label()
        Me.LangPanel = New System.Windows.Forms.Panel()
        Me.LangRuRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangEnRadioButton = New System.Windows.Forms.RadioButton()
        Me.HintPanel = New System.Windows.Forms.Panel()
        Me.WrapperLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.HintLabel41 = New System.Windows.Forms.Label()
        Me.HintLabel32 = New System.Windows.Forms.Label()
        Me.HintLabel12 = New System.Windows.Forms.Label()
        Me.SiteLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.HintLabel31 = New System.Windows.Forms.Label()
        Me.HintLabel2 = New System.Windows.Forms.Label()
        Me.GuideLabel = New System.Windows.Forms.LinkLabel()
        Me.HintLabel11 = New System.Windows.Forms.Label()
        Me.FinishButton = New System.Windows.Forms.Button()
        Me.CancButton = New System.Windows.Forms.Button()
        Me.ActionLabel = New System.Windows.Forms.TextBox()
        Me.MapsLabel = New System.Windows.Forms.Label()
        Me.LogLabel = New System.Windows.Forms.Label()
        Me.ModMapsLabel = New System.Windows.Forms.TextBox()
        Me.HintLabel42 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.LangPanel.SuspendLayout()
        Me.HintPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.InstallationProgressBar)
        Me.Panel.Controls.Add(Me.ProgressLabel)
        Me.Panel.Controls.Add(Me.LangPanel)
        Me.Panel.Controls.Add(Me.HintPanel)
        Me.Panel.Location = New System.Drawing.Point(244, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(360, 284)
        Me.Panel.TabIndex = 14
        '
        'InstallationProgressBar
        '
        Me.InstallationProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstallationProgressBar.Location = New System.Drawing.Point(9, 256)
        Me.InstallationProgressBar.Name = "InstallationProgressBar"
        Me.InstallationProgressBar.Size = New System.Drawing.Size(348, 18)
        Me.InstallationProgressBar.TabIndex = 8
        '
        'ProgressLabel
        '
        Me.ProgressLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressLabel.AutoSize = True
        Me.ProgressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ProgressLabel.Location = New System.Drawing.Point(6, 237)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(49, 16)
        Me.ProgressLabel.TabIndex = 7
        Me.ProgressLabel.Text = "Label1"
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
        Me.HintPanel.Controls.Add(Me.HintLabel42)
        Me.HintPanel.Controls.Add(Me.WrapperLinkLabel)
        Me.HintPanel.Controls.Add(Me.HintLabel41)
        Me.HintPanel.Controls.Add(Me.HintLabel32)
        Me.HintPanel.Controls.Add(Me.HintLabel12)
        Me.HintPanel.Controls.Add(Me.SiteLinkLabel)
        Me.HintPanel.Controls.Add(Me.HintLabel31)
        Me.HintPanel.Controls.Add(Me.HintLabel2)
        Me.HintPanel.Controls.Add(Me.GuideLabel)
        Me.HintPanel.Controls.Add(Me.HintLabel11)
        Me.HintPanel.Location = New System.Drawing.Point(3, 3)
        Me.HintPanel.Name = "HintPanel"
        Me.HintPanel.Size = New System.Drawing.Size(293, 100)
        Me.HintPanel.TabIndex = 6
        '
        'WrapperLinkLabel
        '
        Me.WrapperLinkLabel.AutoSize = True
        Me.WrapperLinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.WrapperLinkLabel.Location = New System.Drawing.Point(73, 84)
        Me.WrapperLinkLabel.Name = "WrapperLinkLabel"
        Me.WrapperLinkLabel.Size = New System.Drawing.Size(73, 16)
        Me.WrapperLinkLabel.TabIndex = 11
        Me.WrapperLinkLabel.TabStop = True
        Me.WrapperLinkLabel.Text = "LinkLabel3"
        '
        'HintLabel41
        '
        Me.HintLabel41.AutoSize = True
        Me.HintLabel41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel41.Location = New System.Drawing.Point(3, 84)
        Me.HintLabel41.Name = "HintLabel41"
        Me.HintLabel41.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel41.TabIndex = 10
        Me.HintLabel41.Text = "InfoLabel"
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
        'FinishButton
        '
        Me.FinishButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FinishButton.Enabled = False
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
        Me.CancButton.Enabled = False
        Me.CancButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancButton.Location = New System.Drawing.Point(542, 300)
        Me.CancButton.Name = "CancButton"
        Me.CancButton.Size = New System.Drawing.Size(66, 24)
        Me.CancButton.TabIndex = 12
        Me.CancButton.Text = "Cancel"
        Me.CancButton.UseVisualStyleBackColor = True
        '
        'ActionLabel
        '
        Me.ActionLabel.Location = New System.Drawing.Point(6, 22)
        Me.ActionLabel.Multiline = True
        Me.ActionLabel.Name = "ActionLabel"
        Me.ActionLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ActionLabel.Size = New System.Drawing.Size(232, 154)
        Me.ActionLabel.TabIndex = 15
        '
        'MapsLabel
        '
        Me.MapsLabel.AutoSize = True
        Me.MapsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MapsLabel.Location = New System.Drawing.Point(3, 189)
        Me.MapsLabel.Name = "MapsLabel"
        Me.MapsLabel.Size = New System.Drawing.Size(49, 16)
        Me.MapsLabel.TabIndex = 17
        Me.MapsLabel.Text = "Label1"
        '
        'LogLabel
        '
        Me.LogLabel.AutoSize = True
        Me.LogLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LogLabel.Location = New System.Drawing.Point(3, 3)
        Me.LogLabel.Name = "LogLabel"
        Me.LogLabel.Size = New System.Drawing.Size(49, 16)
        Me.LogLabel.TabIndex = 18
        Me.LogLabel.Text = "Label2"
        '
        'ModMapsLabel
        '
        Me.ModMapsLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ModMapsLabel.Location = New System.Drawing.Point(6, 208)
        Me.ModMapsLabel.Multiline = True
        Me.ModMapsLabel.Name = "ModMapsLabel"
        Me.ModMapsLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ModMapsLabel.Size = New System.Drawing.Size(232, 116)
        Me.ModMapsLabel.TabIndex = 16
        '
        'HintLabel42
        '
        Me.HintLabel42.AutoSize = True
        Me.HintLabel42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HintLabel42.Location = New System.Drawing.Point(152, 84)
        Me.HintLabel42.Name = "HintLabel42"
        Me.HintLabel42.Size = New System.Drawing.Size(63, 16)
        Me.HintLabel42.TabIndex = 12
        Me.HintLabel42.Text = "InfoLabel"
        '
        'InstallForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 336)
        Me.Controls.Add(Me.LogLabel)
        Me.Controls.Add(Me.MapsLabel)
        Me.Controls.Add(Me.ModMapsLabel)
        Me.Controls.Add(Me.ActionLabel)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.FinishButton)
        Me.Controls.Add(Me.CancButton)
        Me.Name = "InstallForm"
        Me.Text = "Step3"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.LangPanel.ResumeLayout(False)
        Me.LangPanel.PerformLayout()
        Me.HintPanel.ResumeLayout(False)
        Me.HintPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents HintLabel11 As System.Windows.Forms.Label
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
    Friend WithEvents ProgressLabel As System.Windows.Forms.Label
    Friend WithEvents WrapperLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents HintLabel41 As System.Windows.Forms.Label
    Friend WithEvents ActionLabel As System.Windows.Forms.TextBox
    Friend WithEvents MapsLabel As System.Windows.Forms.Label
    Friend WithEvents LogLabel As System.Windows.Forms.Label
    Friend WithEvents InstallationProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ModMapsLabel As System.Windows.Forms.TextBox
    Friend WithEvents HintLabel42 As System.Windows.Forms.Label
End Class
