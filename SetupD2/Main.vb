Public Class Main

    Private comm As Common

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = New Common()
        If System.Globalization.CultureInfo.InstalledUICulture.ThreeLetterISOLanguageName = "rus" Then
            LangRuRadioButton.Checked = True
        ElseIf System.Globalization.CultureInfo.InstalledUICulture.ThreeLetterISOLanguageName = "spa" Then
            LangEspRadioButton.Checked = True
        Else
            LangEnRadioButton.Checked = True
        End If
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, Nothing)
    End Sub

    Private Sub goNext() Handles NextButton.Click
        Call comm.goNext(New SettingsForm(Me, comm))
    End Sub
    Private Sub cancel() Handles CancButton.Click
        Call comm.Cancel(Me)
    End Sub

    Private Sub ChangeLang(sender As Object, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged, LangEspRadioButton.CheckedChanged
        Call comm.SetLang(Me, CType(sender, RadioButton))
    End Sub

    Private Sub FolderSelection() Handles SelectButton.Click
        Dim fbd As New FolderBrowserDialog
        Dim result As DialogResult = fbd.ShowDialog
        If result = Windows.Forms.DialogResult.OK And Not String.IsNullOrWhiteSpace(fbd.SelectedPath) Then
            SelectTextBox.Text = fbd.SelectedPath
        End If
    End Sub
    Private Sub SelectedFolder() Handles SelectTextBox.TextChanged
        NextButton.Enabled = False
        SelectFolderErrorLabel.Visible = False
        SteamErrorLabel.Visible = False
        NonlatinErrorLabel.Visible = False
        If Not IO.Directory.Exists(SelectTextBox.Text) Then
            SelectFolderErrorLabel.Visible = True
        ElseIf IsSteamFolder(SelectTextBox.Text) Then
            SteamErrorLabel.Visible = True
        ElseIf Not IsRightPath(SelectTextBox.Text) Then
            NonlatinErrorLabel.Visible = True
        Else
            NextButton.Enabled = True
        End If
    End Sub

    Private Function IsSteamFolder(ByRef path As String) As Boolean
        If IO.File.Exists(path & "\Discipl2.exe") Then
            Dim sizeInBytes As Long = New IO.FileInfo(path & "\Discipl2.exe").Length
            If sizeInBytes = Common.RussobitExeSize Or sizeInBytes = Common.AkellaExeSize Or sizeInBytes = Common.GOGExeSize Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Private Function IsRightPath(ByRef path As String) As Boolean
        Dim rightChars As New List(Of String)
        Dim s As String = "qwertyuiop[]asdfghjkl;:'\|zxcvbnm,./?<>1234567890- =+_*!@#$%^&*{}"
        For Each c As String In s
            rightChars.Add(c.ToLower)
        Next c
        For Each c As String In path
            If Not rightChars.Contains(c.ToLower) Then
                Return False
            End If
        Next c
        Return True
    End Function

End Class
