﻿Public Class SettingsForm

    Public Const EnableGLWrapper As Boolean = False

    Private comm As Common
    Public prevForm As Main

    Public Sub New(ByRef previous As Main, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
        Call SetInterfacePos()
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, CType(prevForm, Form))
        GLWrapperCheckBox.Checked = EnableGLWrapper
        GLWrapperCheckBox.Enabled = EnableGLWrapper
    End Sub
    Private Sub goNext() Handles InstallButton.Click
        If Not checkSettings() Then Exit Sub
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

    Private Sub SetInterfacePos()
        Call SetInterfacePos({InstallModeLabel, PanelInstallation, TextLangLabel, PanelTextLang, SoundLangLabel, PanelSoundLang, GAILabel, PanelDifficulty})
        Call SetInterfacePos({PanelLuaSettings, PanelOther})
    End Sub
    Private Sub SetInterfacePos(controls() As Control)
        Dim d As Integer
        For i As Integer = 1 To UBound(controls) Step 1
            If TypeOf (controls(i - 1)) Is Label Then
                d = 1
            Else
                d = 4
            End If
            controls(i).Location = New Point(controls(i - 1).Location.X, controls(i - 1).Location.Y + controls(i - 1).Height + d)
        Next i
    End Sub

    Private Function checkSettings() As Boolean
        Dim boxes() As TextBox = {carryOverItemsMaxTextBox, unitMaxDamageTextBox, criticalHitDamageTextBox, criticalHitChanceTextBox}
        Dim labels() As Label = {carryOverItemsMaxLabel, unitMaxDamageLabel, criticalHitDamageLabel, criticalHitChanceLabel}
        Dim minVal() As Integer = {0, 300, 0, 0}
        Dim maxVal() As Integer = {Integer.MaxValue, Integer.MaxValue, 255, 100}
        Dim errors As String = ""
        Dim e As String
        Dim v As Long
        For i As Integer = 0 To UBound(boxes) Step 1
            e = ""
            If Long.TryParse(boxes(i).Text, v) Then
                If v < minVal(i) Then
                    e = comm.StringConversion("mustbegreaterorequalerror", False) & " " & minVal(i)
                ElseIf v > maxVal(i) Then
                    e = comm.StringConversion("mustbelowerorequalerror", False) & " " & maxVal(i)
                End If
            Else
                e = comm.StringConversion("mustbeintegererror", False)
            End If
            If Not e = "" Then
                errors &= labels(i).Text & ":" & vbNewLine & e & vbNewLine & vbNewLine
            End If
        Next i
        If Not errors = "" Then
            MsgBox(errors)
            Return False
        Else
            Return True
        End If
    End Function

End Class