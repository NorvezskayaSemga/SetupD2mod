Public Class Common

    Public settings As New RegSettings

    Private lang As New Dictionary(Of String, String)

    Private backButtonPressed As Boolean
    Private currentLang As String

    Public Sub actOnLoad(ByRef current As Form, ByRef previous As Form)
        current.MaximizeBox = False
        Call LoadRegistryControlSettings(CType(current, Control))
        If Not IsNothing(previous) Then
            current.Location = New Point(previous.Location.X, previous.Location.Y)
            current.Size = New Size(previous.Size.Width, previous.Size.Height)
            Call InheritControlsSettings(CType(current, Control), CType(previous, Control))
            previous.Visible = False
        Else
            current.Location = New Point(CInt(0.5 * (Screen.PrimaryScreen.WorkingArea.Width - current.Size.Width)), _
                                         CInt(0.5 * (Screen.PrimaryScreen.WorkingArea.Height - current.Size.Height)))
        End If
        current.MinimumSize = New Size(current.Size.Width, current.Size.Height)
        current.MaximumSize = New Size(current.Size.Width, current.Size.Height)
    End Sub
    Private Sub InheritControlsSettings(ByRef current As Control, ByRef previous As Control)
        For Each item As Control In previous.Controls
            Dim destControlName As String
            If current.Controls.ContainsKey("FinishButton") AndAlso item.Name = "NextButton" Then
                destControlName = "FinishButton"
            Else
                destControlName = item.Name
            End If
            If current.Controls.ContainsKey(destControlName) Then
                current.Controls.Item(destControlName).Size = New Size(item.Size.Width, item.Size.Height)
                current.Controls.Item(destControlName).Location = New Point(item.Location.X, item.Location.Y)
                current.Controls.Item(destControlName).Dock = item.Dock
                current.Controls.Item(destControlName).Anchor = item.Anchor
                If item.GetType = (New Panel).GetType Then
                    Call InheritControlsSettings(current.Controls.Item(destControlName), item)
                ElseIf item.GetType = (New RadioButton).GetType Then
                    CType(current.Controls.Item(destControlName), RadioButton).Checked = CType(item, RadioButton).Checked
                ElseIf item.GetType = (New PictureBox).GetType Then
                    current.Controls.Item(destControlName).BackgroundImage = item.BackgroundImage
                End If
            End If
        Next item
    End Sub
    Private Sub LoadRegistryControlSettings(ByRef current As Control)
        For Each item As Control In current.Controls
            If item.GetType = (New Panel).GetType Then
                Call LoadRegistryControlSettings(item)
            Else
                Call settings.ReadSetting(item)
            End If
        Next item
    End Sub
    Public Sub SaveRegistryControlSettings(ByRef current As Control)
        For Each item As Control In current.Controls
            If item.GetType = (New Panel).GetType Then
                Call SaveRegistryControlSettings(item)
            Else
                Call settings.WriteSettings(item)
            End If
        Next item
    End Sub

    Public Sub goNext(ByRef nextform As Form)
        nextform.Show()
    End Sub
    Public Sub goBack(ByRef current As Form, ByRef previous As Form)
        backButtonPressed = True
        current.Close()
        previous.Visible = True
    End Sub
    Public Sub closeEventSub()
        If Not backButtonPressed Then End
        backButtonPressed = False
    End Sub
    Public Sub Cancel(ByRef current As Form)
        Dim canc As New CustomDialog(lang, current)
        Dim response As DialogResult = canc.ShowDialog(current)
        If response = DialogResult.Yes Then End
        'response = MsgBox(lang.Item(My.Resources.CancelMsgKeyword), MsgBoxStyle.YesNo)
    End Sub

    Public Sub SetLang(ByRef c As Control, ByRef LangRButton As RadioButton)
        If Not LangRButton.Checked Then Exit Sub
        Call ReadLangFile(LangRButton)
        For Each item As Control In c.Controls
            If item.GetType = (New Panel).GetType Then
                Call SetLang(item, LangRButton)
            ElseIf item.GetType = (New Button).GetType _
            OrElse item.GetType = (New RadioButton).GetType _
            OrElse item.GetType = (New Label).GetType _
            OrElse item.GetType = (New LinkLabel).GetType _
            OrElse item.GetType = (New CheckBox).GetType Then
                If lang.ContainsKey(item.Name) Then
                    item.Text = lang.Item(item.Name)
                Else
                    Throw New Exception("В словаре нехватает записи для " & item.Name)
                End If
            End If
        Next item
    End Sub
    Private Sub ReadLangFile(ByRef LangRButton As RadioButton)
        If LangRButton.Name = currentLang Then Exit Sub
        currentLang = LangRButton.Name
        Dim txt As String
        If LangRButton.Name = "LangRuRadioButton" Then
            txt = My.Resources.RusLang
        ElseIf LangRButton.Name = "LangEnRadioButton" Then
            txt = My.Resources.EngLang
        Else
            Throw New Exception("Unknown language")
            End
        End If
        lang.Clear()
        Dim splited() As String = txt.Replace(Chr(10), vbNewLine).Replace(vbLf, "").Split(CChar(vbNewLine))
        Dim name, content As String
        name = ""
        content = ""
        For i As Integer = 0 To UBound(splited) Step 1
            If splited(i).Length > 1 Then
                Dim s As String = splited(i).Substring(0, 1)
                If s = "#" Then
                    If Not content = "" Then lang.Add(name, content)
                    name = splited(i).Substring(1)
                    content = ""
                Else
                    If Not content = "" Then content &= vbNewLine
                    content &= splited(i)
                End If
            End If
        Next i
        If Not content = "" Then lang.Add(name, content)
    End Sub

End Class

Public Class RegSettings

    Public errorText As String = ""

    Public Sub CreateKey()
        If Not errorText = "" Then Exit Sub
        If Not IsNothing(My.Computer.Registry.CurrentUser.GetValue(My.Resources.regKey)) Then Exit Sub
        Try
            My.Computer.Registry.CurrentUser.CreateSubKey(My.Resources.regKey)
        Catch ex As Exception
            errorText = ex.Message
        End Try
    End Sub

    Public Sub ReadSetting(ByRef c As Control)
        If Not errorText = "" Then Exit Sub
        If Not IsRightControl(c) Then Exit Sub
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = My.Computer.Registry.CurrentUser.OpenSubKey(My.Resources.regKey, False)
            If IsNothing(key) Then Exit Sub

            Dim value As Object = key.GetValue(c.Name, Nothing)
            If IsNothing(value) Then Exit Try

            If c.GetType = (New TextBox).GetType Then
                CType(c, TextBox).Text = value.ToString
            ElseIf c.GetType = (New CheckBox).GetType Then
                CType(c, CheckBox).Checked = CBool(value)
            ElseIf c.GetType = (New RadioButton).GetType Then
                CType(c, RadioButton).Checked = CBool(value)
            End If
        Catch ex As Exception
            errorText = ex.Message
        End Try
        If Not IsNothing(key) Then key.Close()
    End Sub

    Public Sub WriteSettings(ByRef c As Control)
        If Not errorText = "" Then Exit Sub
        If Not IsRightControl(c) Then Exit Sub
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = My.Computer.Registry.CurrentUser.OpenSubKey(My.Resources.regKey, True)
            If IsNothing(key) Then Exit Sub

            If c.GetType = (New TextBox).GetType Then
                key.SetValue(c.Name, CType(c, TextBox).Text)
            ElseIf c.GetType = (New CheckBox).GetType Then
                key.SetValue(c.Name, CType(c, CheckBox).Checked)
            ElseIf c.GetType = (New RadioButton).GetType Then
                key.SetValue(c.Name, CType(c, RadioButton).Checked)
            End If
        Catch ex As Exception
            errorText = ex.Message
        End Try
        If Not IsNothing(key) Then key.Close()
    End Sub
    Private Function IsRightControl(ByRef c As Control) As Boolean
        If IsNothing(c) Then Return False
        If Not c.GetType = (New TextBox).GetType _
        And Not c.GetType = (New CheckBox).GetType _
        And Not c.GetType = (New RadioButton).GetType Then Return False
        Return True
    End Function

End Class


