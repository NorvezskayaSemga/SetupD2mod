Public Class InstallForm

    Private comm As Common
    Public prevForm As SettingsForm
    Public progressList As String
    Private inst As Installer

    Public Sub New(ByRef previous As SettingsForm, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
        inst = New Installer(Me, comm)
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, CType(prevForm, Form))
        Call inst.RunInstall()
        Call SaveSettings()
        FinishButton.Enabled = True
        CancButton.Enabled = False
    End Sub
    Private Sub finishInstall() Handles FinishButton.Click
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
    End Sub
    Private Sub OpenWebPage(sender As Object, e As System.EventArgs) Handles GuideLabel.LinkClicked, SiteLinkLabel.LinkClicked, WrapperLinkLabel.LinkClicked
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

Class Installer

    Private myowner As InstallForm
    Private comm As Common
    Private tmpDir As String

    Public Sub New(ByRef s As InstallForm, ByRef c As Common)
        myowner = s
        comm = c
    End Sub

    Public Sub RunInstall()
        Dim IsError As Boolean = False
        Dim skipCopy As Boolean
        For id As Integer = 1 To 5 Step 1
            Call CopyFolder(IsError, skipCopy, id)
        Next id
        Call RewriteD2Config()
    End Sub
    Private Sub CopyFolder(ByRef IsError As Boolean, ByRef skipCopy As Boolean, ByRef id As Integer)
        Dim f As List(Of String) = GetFilesList(id)
        Call TestFilesList(f, IsError, skipCopy, id)
        Call CopyFiles(f, IsError, skipCopy, id)
        If IO.Directory.Exists(tmpDir) Then IO.Directory.Delete(tmpDir, True)
    End Sub
    Private Function GetFilesList(ByRef id As Integer) As List(Of String)
        If id = 1 Then
            If myowner.prevForm.InstallRadioButton.Checked Then
                Return DistributiveHandler.GetFullVersionFiles()
            Else
                Return DistributiveHandler.GetModFiles()
            End If
        ElseIf id = 2 Then
            If myowner.prevForm.EnTextRadioButton.Checked Then
                Return DistributiveHandler.GetEngFiles(True)
            Else
                Return Nothing
            End If
        ElseIf id = 3 Then
            If myowner.prevForm.EnSoundRadioButton.Checked Then
                Return DistributiveHandler.GetEngFiles(False)
            Else
                Return Nothing
            End If
        ElseIf id = 4 Then
            If myowner.prevForm.ToolsCheckBox.Checked Then
                Return DistributiveHandler.GetToolsAndReadmeFiles()
            Else
                Return Nothing
            End If
        ElseIf id = 5 Then
            Call AddMsg(My.Resources.copyGLWrapper)
            Dim p() As String = DownloadGLWrapper.Download()
            If IO.File.Exists(p(0)) Then IO.File.Delete(p(0))
            tmpDir = p(1)
            Return DistributiveHandler.GetWrapperFiles(p(1))
        Else
            MsgBox("Invalid id " & id)
            End
        End If
    End Function
    Private Sub TestFilesList(ByRef f As List(Of String), ByRef IsError As Boolean, ByRef skipCopy As Boolean, ByRef id As Integer)
        If IsError Then Exit Sub
        skipCopy = False
        If Not IsNothing(f) AndAlso f.Count = 0 Then
            skipCopy = True
            If id = 1 Then
                IsError = True
                Call AddMsg(My.Resources.noFilesFound)
            ElseIf id = 2 Then
                Call AddMsg(My.Resources.noTextLangFound)
            ElseIf id = 3 Then
                Call AddMsg(My.Resources.noSoundLangFound)
            ElseIf id = 4 Then
                Call AddMsg(My.Resources.noToolsFound)
            ElseIf id = 5 Then
                Call AddMsg(My.Resources.noWrapperFound)
            Else
                MsgBox("Invalid id " & id)
                End
            End If
            Call SetProgressLabel(True)
        ElseIf IsNothing(f) Then
            skipCopy = True
        End If
        If IsError Or skipCopy Then Exit Sub
        If id = 1 Then
            Call AddMsg(My.Resources.copyFiles)
        ElseIf id = 2 Then
            Call AddMsg(My.Resources.copyTextLang)
        ElseIf id = 3 Then
            Call AddMsg(My.Resources.copySoundLang)
        ElseIf id = 4 Then
            Call AddMsg(My.Resources.copyTools)
        ElseIf id = 5 Then
        Else
            MsgBox("Invalid id " & id)
            End
        End If
        Call SetProgressLabel(False)
    End Sub
    Private Sub copyFiles(ByRef f As List(Of String), ByRef IsError As Boolean, ByRef skipCopy As Boolean, ByRef id As Integer)
        If IsError Or skipCopy Then Exit Sub
        Dim errorRised As Boolean
        Try
            Dim d As String = GetDestinationDirectory()
            Dim dest As String
            Dim totalSize, complitedSize As Long
            myowner.ProgressBar.Value = 0
            For Each item As String In f
                totalSize += New System.IO.FileInfo(item).Length
            Next item

            Dim maxI As Integer = 1
            If id = 4 Then maxI = 0

            For Each item As String In f
                If Not id = 5 Then
                    dest = item
                    For i As Integer = 0 To maxI Step 1
                        dest = dest.Substring(dest.IndexOf("\") + 1)
                    Next i
                Else
                    dest = item.Substring(item.LastIndexOf("\") + 1)
                End If
                dest = d & dest
                Call CopyFile(item, dest)
                complitedSize += New System.IO.FileInfo(item).Length
                myowner.ProgressBar.Value = CInt(myowner.ProgressBar.Maximum * Math.Min(complitedSize / totalSize, 1))
            Next item
        Catch ex As Exception
            errorRised = True
            If id = 1 Then
                IsError = True
                Call AddMsg(My.Resources.copyFilesErr & ex.Message)
            ElseIf id = 2 Then
                Call AddMsg(My.Resources.copyTextLangErr & ex.Message)
            ElseIf id = 3 Then
                Call AddMsg(My.Resources.copySoundLangErr & ex.Message)
            ElseIf id = 4 Then
                Call AddMsg(My.Resources.copyToolsErr & ex.Message)
            ElseIf id = 5 Then
                Call AddMsg(My.Resources.copyGLWrapperErr & ex.Message)
            Else
                MsgBox("Invalid id " & id)
                End
            End If
            Call SetProgressLabel(False)
        End Try
        If Not errorRised Then
            If id = 1 Then
                Call AddMsg(My.Resources.copyFilesOk)
            ElseIf id = 2 Then
                Call AddMsg(My.Resources.copyTextLangOk)
            ElseIf id = 3 Then
                Call AddMsg(My.Resources.copySoundLangOk)
            ElseIf id = 4 Then
                Call AddMsg(My.Resources.copyToolsOk)
            ElseIf id = 5 Then
                Call AddMsg(My.Resources.copyGLWrapperOk)
            Else
                MsgBox("Invalid id " & id)
                End
            End If
            Call SetProgressLabel(False)
        End If
    End Sub
    Private Function GetDestinationDirectory() As String
        Dim d As String = myowner.prevForm.prevForm.SelectTextBox.Text
        If Not d.Substring(d.Length - 1) = "\" Then d &= "\"
        Return d
    End Function
    Private Sub AddMsg(ByRef msg As String)
        If Not myowner.progressList = "" Then myowner.progressList &= vbNewLine
        myowner.progressList &= msg
    End Sub

    Private Sub CopyFile(ByRef source As String, ByRef destination As String)
        Dim s() As String = destination.Split(CChar("\"))
        Dim d As String = s(0)
        For i As Integer = 1 To UBound(s) - 1 Step 1
            d &= "\" & s(i)
            If Not IO.Directory.Exists(d) Then IO.Directory.CreateDirectory(d)
        Next i
        IO.File.Copy(source, destination, True)
    End Sub
    Private Sub SetProgressLabel(ByRef riseExceptionOnError As Boolean)
        myowner.ActionLabel.Text = comm.MultiStringConversion(myowner.progressList, riseExceptionOnError)
    End Sub

    Private Sub RewriteD2Config()
        Try
            If Not myowner.prevForm.GLWrapperCheckBox.Checked Then Exit Sub
            Dim f As String = GetDestinationDirectory() & "Disciple.ini"
            If Not IO.File.Exists(f) Then Exit Sub

            Dim overwrite As New Dictionary(Of String, String)
            overwrite.Add(("UseD3D").ToUpper, "0")
            overwrite.Add(("DisplayMode").ToUpper, "1")
            Dim s() As String = IO.File.ReadAllLines(f)
            Dim delimiter As String = "="
            For i As Integer = 0 To UBound(s) Step 1
                If s(i).Length > 0 AndAlso s(i).Contains(delimiter) Then
                    Dim splited() As String = s(i).Replace(" ", "").Split(delimiter)
                    If overwrite.ContainsKey(splited(0).ToUpper) Then
                        s(i) = splited(0) & delimiter & overwrite.Item(splited(0).ToUpper)
                    End If
                End If
            Next i
            IO.File.WriteAllLines(f, s)
        Catch
        End Try
    End Sub

End Class