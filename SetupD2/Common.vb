Public Class Common

    Private lang As New Dictionary(Of String, String)

    Private backButtonPressed As Boolean

    Public Sub actOnLoad(ByRef current As Form, ByRef previous As Form)
        If Not IsNothing(previous) Then
            current.Location = New Point(previous.Location.X, previous.Location.Y)
            current.Size = New Size(previous.Size.Width, previous.Size.Height)
            Call SetCommonControlsSize(current, previous)
            previous.Visible = False
        End If
        current.MinimumSize = New Size(current.Size.Width, current.Size.Height)
        current.MaximumSize = New Size(current.Size.Width, current.Size.Height)
    End Sub
    Private Sub SetCommonControlsSize(ByRef current As Control, ByRef previous As Control)
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
                    Call SetCommonControlsSize(current.Controls.Item(destControlName), item)
                ElseIf item.GetType = (New RadioButton).GetType Then
                    CType(current.Controls.Item(destControlName), RadioButton).Checked = CType(item, RadioButton).Checked
                ElseIf item.GetType = (New PictureBox).GetType Then
                    current.Controls.Item(destControlName).BackgroundImage = item.BackgroundImage
                End If
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
    Public Sub Cancel()
        Dim response As Integer = MsgBox(lang.Item(My.Resources.CancelMsgKeyword), MsgBoxStyle.YesNo)
        If response = vbYes Then Call closeEventSub()
    End Sub

    Public Sub ReadLangFile(ByRef radioButtonName As String)
        Dim txt As String
        If radioButtonName = "LangRuRadioButton" Then
            txt = My.Resources.RusLang
        ElseIf radioButtonName = "LangEnRadioButton" Then
            txt = My.Resources.EngLang
        Else
            Throw New Exception("Unknown language")
            End
        End If
        lang.Clear()
        Dim splited() As String = txt.Replace(Chr(10), vbNewLine).Replace(vbLf, "").Split(vbNewLine)
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
    Public Sub SetLang(ByRef c As Control)
        For Each item As Control In c.Controls
            If item.GetType = (New Panel).GetType Then
                Call SetLang(item)
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

End Class
