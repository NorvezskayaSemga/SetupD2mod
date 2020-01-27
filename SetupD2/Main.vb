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
        Call comm.Cancel(Me)
    End Sub

    Private Sub ChangeLang(sender As Object, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged
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
        NextButton.Enabled = IO.Directory.Exists(SelectTextBox.Text)
    End Sub

End Class
