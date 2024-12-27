<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.NextButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.CancButton = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.SelectTextBox = New System.Windows.Forms.TextBox()
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.NonlatinErrorLabel = New System.Windows.Forms.Label()
        Me.SteamErrorLabel = New System.Windows.Forms.Label()
        Me.SelectFolderErrorLabel = New System.Windows.Forms.Label()
        Me.LangPanel = New System.Windows.Forms.Panel()
        Me.LangEspRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangEnRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangRuRadioButton = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ModWikiLinkLabel = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.LangPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NextButton
        '
        Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NextButton.Enabled = False
        Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NextButton.Location = New System.Drawing.Point(365, 389)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(100, 28)
        Me.NextButton.TabIndex = 0
        Me.NextButton.Text = "Next"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BackButton.Enabled = False
        Me.BackButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BackButton.Location = New System.Drawing.Point(259, 389)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(100, 28)
        Me.BackButton.TabIndex = 11
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'CancButton
        '
        Me.CancButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancButton.Location = New System.Drawing.Point(531, 389)
        Me.CancButton.Name = "CancButton"
        Me.CancButton.Size = New System.Drawing.Size(82, 28)
        Me.CancButton.TabIndex = 2
        Me.CancButton.Text = "Cancel"
        Me.CancButton.UseVisualStyleBackColor = True
        '
        'PictureBox
        '
        Me.PictureBox.BackgroundImage = Global.SetupD2mod.My.Resources.Resources.logo
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(236, 422)
        Me.PictureBox.TabIndex = 3
        Me.PictureBox.TabStop = False
        '
        'SelectTextBox
        '
        Me.SelectTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SelectTextBox.Location = New System.Drawing.Point(117, 327)
        Me.SelectTextBox.Name = "SelectTextBox"
        Me.SelectTextBox.Size = New System.Drawing.Size(237, 22)
        Me.SelectTextBox.TabIndex = 3
        '
        'SelectButton
        '
        Me.SelectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SelectButton.Location = New System.Drawing.Point(3, 324)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(109, 29)
        Me.SelectButton.TabIndex = 2
        Me.SelectButton.Text = "SelectFolder"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InfoLabel.Location = New System.Drawing.Point(7, 135)
        Me.InfoLabel.MaximumSize = New System.Drawing.Size(300, 0)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(63, 16)
        Me.InfoLabel.TabIndex = 2
        Me.InfoLabel.Text = "InfoLabel"
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Panel1)
        Me.Panel.Controls.Add(Me.NonlatinErrorLabel)
        Me.Panel.Controls.Add(Me.SteamErrorLabel)
        Me.Panel.Controls.Add(Me.SelectFolderErrorLabel)
        Me.Panel.Controls.Add(Me.LangPanel)
        Me.Panel.Controls.Add(Me.InfoLabel)
        Me.Panel.Controls.Add(Me.SelectButton)
        Me.Panel.Controls.Add(Me.SelectTextBox)
        Me.Panel.Location = New System.Drawing.Point(242, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(380, 383)
        Me.Panel.TabIndex = 4
        '
        'NonlatinErrorLabel
        '
        Me.NonlatinErrorLabel.AutoSize = True
        Me.NonlatinErrorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NonlatinErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.NonlatinErrorLabel.Location = New System.Drawing.Point(7, 275)
        Me.NonlatinErrorLabel.MaximumSize = New System.Drawing.Size(320, 0)
        Me.NonlatinErrorLabel.Name = "NonlatinErrorLabel"
        Me.NonlatinErrorLabel.Size = New System.Drawing.Size(49, 16)
        Me.NonlatinErrorLabel.TabIndex = 13
        Me.NonlatinErrorLabel.Text = "Label1"
        '
        'SteamErrorLabel
        '
        Me.SteamErrorLabel.AutoSize = True
        Me.SteamErrorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SteamErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.SteamErrorLabel.Location = New System.Drawing.Point(7, 275)
        Me.SteamErrorLabel.MaximumSize = New System.Drawing.Size(320, 0)
        Me.SteamErrorLabel.Name = "SteamErrorLabel"
        Me.SteamErrorLabel.Size = New System.Drawing.Size(49, 16)
        Me.SteamErrorLabel.TabIndex = 12
        Me.SteamErrorLabel.Text = "Label1"
        '
        'SelectFolderErrorLabel
        '
        Me.SelectFolderErrorLabel.AutoSize = True
        Me.SelectFolderErrorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SelectFolderErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.SelectFolderErrorLabel.Location = New System.Drawing.Point(7, 275)
        Me.SelectFolderErrorLabel.MaximumSize = New System.Drawing.Size(320, 0)
        Me.SelectFolderErrorLabel.Name = "SelectFolderErrorLabel"
        Me.SelectFolderErrorLabel.Size = New System.Drawing.Size(49, 16)
        Me.SelectFolderErrorLabel.TabIndex = 11
        Me.SelectFolderErrorLabel.Text = "Label1"
        '
        'LangPanel
        '
        Me.LangPanel.Controls.Add(Me.LangEspRadioButton)
        Me.LangPanel.Controls.Add(Me.LangEnRadioButton)
        Me.LangPanel.Controls.Add(Me.LangRuRadioButton)
        Me.LangPanel.Location = New System.Drawing.Point(322, 0)
        Me.LangPanel.Name = "LangPanel"
        Me.LangPanel.Size = New System.Drawing.Size(55, 63)
        Me.LangPanel.TabIndex = 10
        '
        'LangEspRadioButton
        '
        Me.LangEspRadioButton.AutoSize = True
        Me.LangEspRadioButton.Location = New System.Drawing.Point(9, 41)
        Me.LangEspRadioButton.Name = "LangEspRadioButton"
        Me.LangEspRadioButton.Size = New System.Drawing.Size(43, 17)
        Me.LangEspRadioButton.TabIndex = 2
        Me.LangEspRadioButton.TabStop = True
        Me.LangEspRadioButton.Text = "Esp"
        Me.LangEspRadioButton.UseVisualStyleBackColor = True
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ModWikiLinkLabel)
        Me.Panel1.Location = New System.Drawing.Point(3, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 32)
        Me.Panel1.TabIndex = 15
        '
        'ModWikiLinkLabel
        '
        Me.ModWikiLinkLabel.AutoSize = True
        Me.ModWikiLinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ModWikiLinkLabel.Location = New System.Drawing.Point(4, 0)
        Me.ModWikiLinkLabel.Name = "ModWikiLinkLabel"
        Me.ModWikiLinkLabel.Size = New System.Drawing.Size(85, 16)
        Me.ModWikiLinkLabel.TabIndex = 15
        Me.ModWikiLinkLabel.TabStop = True
        Me.ModWikiLinkLabel.Text = "ModWikiLink"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 422)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.CancButton)
        Me.Controls.Add(Me.BackButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Form1"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.LangPanel.ResumeLayout(False)
        Me.LangPanel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents CancButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents SelectTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents LangPanel As System.Windows.Forms.Panel
    Friend WithEvents LangEnRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LangRuRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents SteamErrorLabel As System.Windows.Forms.Label
    Friend WithEvents SelectFolderErrorLabel As System.Windows.Forms.Label
    Friend WithEvents NonlatinErrorLabel As System.Windows.Forms.Label
    Friend WithEvents LangEspRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ModWikiLinkLabel As System.Windows.Forms.LinkLabel

End Class
