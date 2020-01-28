﻿Public Class SettingsForm

    Private comm As Common
    Public prevForm As Main

    Public Sub New(ByRef previous As Main, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, CType(prevForm, Form))
    End Sub
    Private Sub goNext() Handles InstallButton.Click
        Call comm.goNext(New InstallForm(Me, comm))
    End Sub
    Private Sub goBack() Handles BackButton.Click
        Call comm.goBack(Me, CType(prevForm, Form))
    End Sub
    Private Sub cancel() Handles CancButton.Click
        Call comm.Cancel(Me)
    End Sub
    Private Sub meclose() Handles Me.FormClosing
        Call comm.closeEventSub()
    End Sub

    Private Sub ChangeLang(sender As Object, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged
        Call comm.SetLang(Me, CType(sender, RadioButton))
    End Sub

End Class