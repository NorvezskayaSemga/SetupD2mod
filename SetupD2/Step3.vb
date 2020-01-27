Public Class Step3

    Private comm As Common
    Public prevForm As Step2

    Public Sub New(ByRef previous As Step2, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, CType(prevForm, Form))
        GuideLabel.Links.Clear()
        GuideLabel.Links.Add(New LinkLabel.Link With {.LinkData = My.Resources.startGuideLink})
        SiteLinkLabel.Links.Clear()
        SiteLinkLabel.Links.Add(New LinkLabel.Link With {.LinkData = My.Resources.modSiteLink})
    End Sub
    Private Sub goNext() Handles FinishButton.Click
        End
    End Sub
    Private Sub cancel() Handles CancButton.Click
        Call comm.Cancel(Me)
    End Sub
    Private Sub meclose() Handles Me.FormClosing
        Call comm.closeEventSub()
    End Sub

    Private Sub ChangeLang(sender As Object, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged
        Call comm.SetLang(Me, CType(sender, RadioButton))

        If CType(sender, RadioButton).Checked Then
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

    Private Sub OpenWebPage(sender As Object, e As System.EventArgs) Handles GuideLabel.LinkClicked, SiteLinkLabel.LinkClicked
        Dim L As LinkLabel.Link = CType(sender, LinkLabel).Links.Item(0)
        System.Diagnostics.Process.Start(L.LinkData.ToString)
    End Sub

    Private Sub SaveSettings()
        Call comm.settings.CreateKey()
        Call comm.SaveRegistryControlSettings(CType(Me, Control))
        Call comm.SaveRegistryControlSettings(CType(Me.prevForm, Control))
        Call comm.SaveRegistryControlSettings(CType(Me.prevForm.prevForm, Control))
    End Sub
End Class