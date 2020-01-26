Public Class Main

    Private comm As Common

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = New Common()
        If System.Globalization.CultureInfo.InstalledUICulture.Name = "ru-RU" Then
            LangRuRadioButton.Checked = True
        Else
            LangEnRadioButton.Checked = True
        End If
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, Nothing)
    End Sub

    Private Sub goNext() Handles NextButton.Click
        Call comm.goNext(New Step2(Me, comm))
    End Sub
    Private Sub cancel() Handles CancButton.Click
        Call comm.Cancel()
    End Sub

    Private Sub ChangeLang(sender As RadioButton, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged
        If sender.Checked Then
            comm.ReadLangFile(sender.Name)
            comm.SetLang(Me)
        End If
    End Sub


End Class
