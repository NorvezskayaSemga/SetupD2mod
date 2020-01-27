Public Class CustomDialog

    Dim myowner As Form

    Public Sub New(ByRef lang As Dictionary(Of String, String), ByRef c As Form)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        myowner = c

        Me.Size = New Size(255, 164)
        Me.Text = ""
        Me.ShowIcon = False
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.TopMost = True

        Me.MinimumSize = New Size(Me.Size.Width, Me.Size.Height)
        Me.MaximumSize = New Size(Me.Size.Width, Me.Size.Height)

        Dim qLabel As New Label With {.Text = lang.Item(My.Resources.CancelMsgKeyword), _
                                      .AutoSize = True}
        qLabel.Font = New Font(qLabel.Font.Name, 10)

        qLabel.Location = New Point(20, CInt(0.35 * Me.Size.Height) - qLabel.Size.Height)

        Dim yButton As New Button With {.TabIndex = 2, .Size = New Size(85, 25), _
                                        .Text = lang.Item(My.Resources.CancelMsgKeywordYes)}
        yButton.Font = New Font(qLabel.Font.Name, qLabel.Font.Size)
        yButton.Location = New Point(40, CInt(0.65 * Me.Size.Height) - yButton.Size.Height)

        Dim nButton As New Button With {.TabIndex = 1, .Size = New Size(yButton.Width, yButton.Height), _
                                        .Text = lang.Item(My.Resources.CancelMsgKeywordNo), _
                                        .Location = New Point(yButton.Location.X + yButton.Size.Width + 15, _
                                                              yButton.Location.Y)}
        nButton.Font = New Font(qLabel.Font.Name, qLabel.Font.Size)

        AddHandler yButton.Click, New EventHandler(Sub()
                                                       Me.DialogResult = Windows.Forms.DialogResult.Yes
                                                       Me.Close()
                                                   End Sub)
        AddHandler nButton.Click, New EventHandler(Sub()
                                                       Me.DialogResult = Windows.Forms.DialogResult.No
                                                       Me.Close()
                                                   End Sub)
        Me.Controls.Add(qLabel)
        Me.Controls.Add(nButton)
        Me.Controls.Add(yButton)
    End Sub

    Private Sub meload() Handles Me.Load
        Me.Location = New Point(myowner.Location.X + CInt(0.5 * (myowner.Size.Width - Me.Size.Width)), _
                                myowner.Location.Y + CInt(0.5 * (myowner.Size.Height - Me.Size.Height)))
    End Sub

End Class