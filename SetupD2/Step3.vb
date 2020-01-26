Public Class Step3

    Private comm As Common
    Private prevForm As Step2

    Public Sub New(ByRef previous As Step2, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, prevForm)
        GuideLabel.Links.Clear()
        GuideLabel.Links.Add(New LinkLabel.Link With {.LinkData = "https://www.youtube.com/watch?v=XEFrECQ8yH4"})
        SiteLinkLabel.Links.Clear()
        SiteLinkLabel.Links.Add(New LinkLabel.Link With {.LinkData = "https://norvezskayasemga.wixsite.com/d2bfwmod"})
    End Sub
    Private Sub goNext() Handles FinishButton.Click
        End
    End Sub
    Private Sub cancel() Handles CancButton.Click
        Call comm.Cancel()
    End Sub
    Private Sub meclose() Handles Me.FormClosing
        Call comm.closeEventSub()
    End Sub

    Private Sub ChangeLang(sender As RadioButton, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged
        If sender.Checked Then
            comm.ReadLangFile(sender.Name)
            comm.SetLang(Me)

            Call PlaceLabel(HintLabel12, HintLabel11, False)
            Call PlaceLinkLabel(GuideLabel, HintLabel12)

            Call PlaceLabel(HintLabel2, HintLabel12, True)

            Call PlaceLabel(HintLabel31, HintLabel2, True)
            Call PlaceLabel(HintLabel32, HintLabel31, False)
            Call PlaceLinkLabel(SiteLinkLabel, HintLabel32)

        End If
    End Sub
    Private Sub PlaceLabel(ByRef current As Label, ByRef prev As Label, ByRef addSpacing As Boolean)
        Dim blocksSpacing As Integer
        If addSpacing Then blocksSpacing = 15
        current.Location = New Point(prev.Location.X, prev.Location.Y + prev.Size.Height + blocksSpacing)
    End Sub
    Private Sub PlaceLinkLabel(ByRef current As LinkLabel, ByRef prev As Label)
        current.Location = New Point(prev.Location.X + prev.Size.Width, prev.Location.Y)
    End Sub

    Private Sub ShowGuide(sender As System.Windows.Forms.LinkLabel, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles GuideLabel.LinkClicked, SiteLinkLabel.LinkClicked
        Dim L As LinkLabel.Link = sender.Links.Item(0)
        System.Diagnostics.Process.Start(L.LinkData)
    End Sub

End Class