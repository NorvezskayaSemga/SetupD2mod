Public Class Step2

    Private comm As Common
    Private prevForm As Main

    Public Sub New(ByRef previous As Main, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, prevForm)
        RuRadioButton1.Checked = LangRuRadioButton.Checked
        RuRadioButton2.Checked = LangRuRadioButton.Checked
        EnRadioButton1.Checked = LangEnRadioButton.Checked
        EnRadioButton2.Checked = LangEnRadioButton.Checked
    End Sub
    Private Sub goNext() Handles NextButton.Click
        Call comm.goNext(New Step3(Me, comm))
    End Sub
    Private Sub goBack() Handles BackButton.Click
        Call comm.goBack(Me, prevForm)
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
        End If
    End Sub

End Class