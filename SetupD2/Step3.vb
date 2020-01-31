﻿Public Class InstallForm

    Private comm As Common
    Public prevForm As SettingsForm
    Public progressList, mapsList As String
    Friend inst As AsynhInstall

    Public Sub New(ByRef previous As SettingsForm, ByRef c As Common)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        comm = c
        prevForm = previous
        inst = New AsynhInstall(Me, comm)
    End Sub

    Private Sub meload() Handles Me.Load
        Call comm.actOnLoad(Me, CType(prevForm, Form))
        inst.InstallationWorker.RunWorkerAsync()
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

    Protected Friend Sub SaveSettings()
        Dim IgnoreNames As New List(Of String)
        For Each c As Control In Me.Controls
            If TypeOf c Is TextBox Then
                IgnoreNames.Add(c.Name)
            End If
        Next c
        Call comm.settings.CreateKey()
        Call comm.SaveRegistryControlSettings(CType(Me, Control), IgnoreNames)
        Call comm.SaveRegistryControlSettings(CType(Me.prevForm, Control), IgnoreNames)
        Call comm.SaveRegistryControlSettings(CType(Me.prevForm.prevForm, Control), IgnoreNames)
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

    Friend Sub InstallTask(ByRef InstallWorker As AsynhInstall)
        Dim IsError As Boolean = False
        Dim skipCopy As Boolean
        For id As Integer = 1 To 5 Step 1
            Call CopyFolder(IsError, skipCopy, id, InstallWorker)
        Next id
        Call RewriteD2Config()
    End Sub
    Private Sub CopyFolder(ByRef IsError As Boolean, ByRef skipCopy As Boolean, ByRef id As Integer, _
                           ByRef InstallWorker As AsynhInstall)
        Dim f() As List(Of String) = GetFilesList(id, InstallWorker)
        Call TestFilesList(f(0), IsError, skipCopy, id, InstallWorker)
        Call copyFiles(f(0), IsError, skipCopy, f(1), id, InstallWorker)
        If IO.Directory.Exists(tmpDir) Then IO.Directory.Delete(tmpDir, True)
    End Sub
    Private Function GetFilesList(ByRef id As Integer, ByRef InstallWorker As AsynhInstall) As List(Of String)()
        Dim IgnorFiles As New List(Of String)
        If id = 1 Then
            Dim L, t() As List(Of String)
            For i As Integer = 2 To 3 Step 1
                t = GetFilesList(i, InstallWorker)
                If Not IsNothing(t) AndAlso Not IsNothing(t(0)) Then
                    For Each item As String In t(0)
                        IgnorFiles.Add(item)
                    Next item
                End If
            Next i

            Dim s As String
            If myowner.prevForm.InstallRadioButton.Checked Then
                L = DistributiveHandler.GetFullVersionFiles()
            Else
                L = DistributiveHandler.GetModFiles()
            End If
            myowner.mapsList = ""
            For Each p As String In L
                If IO.File.GetLastWriteTime(p).Year > 2010 Then
                    s = MapNameRead.Read(p)
                    If Not s = "" Then
                        If Not myowner.mapsList = "" Then myowner.mapsList &= vbNewLine
                        myowner.mapsList &= s
                    End If
                End If
            Next p
            Call SetProgressLabel(True, InstallWorker, 2)
            Return New List(Of String)() {L, IgnorFiles}
        ElseIf id = 2 Then
            If myowner.prevForm.EnTextRadioButton.Checked Then
                Return New List(Of String)() {DistributiveHandler.GetEngFiles(True), IgnorFiles}
            Else
                Return Nothing
            End If
        ElseIf id = 3 Then
            If myowner.prevForm.EnSoundRadioButton.Checked Then
                Return New List(Of String)() {DistributiveHandler.GetEngFiles(False), IgnorFiles}
            Else
                Return Nothing
            End If
        ElseIf id = 4 Then
            If myowner.prevForm.ToolsCheckBox.Checked Then
                Return New List(Of String)() {DistributiveHandler.GetToolsAndReadmeFiles(), IgnorFiles}
            Else
                Return Nothing
            End If
        ElseIf id = 5 Then
            Call AddMsg(My.Resources.copyGLWrapper)
            Call SetProgressLabel(True, InstallWorker, 1)
            Dim dw As New DownloadGLWrapper(InstallWorker.InstallationWorker, myowner.InstallationProgressBar)
            Dim p() As String = dw.Download
            If IO.File.Exists(p(0)) Then IO.File.Delete(p(0))
            tmpDir = p(1)
            Return New List(Of String)() {DistributiveHandler.GetWrapperFiles(p(1)), IgnorFiles}
        Else
            MsgBox("Invalid id " & id)
            End
        End If
    End Function
    Private Sub TestFilesList(ByRef f As List(Of String), ByRef IsError As Boolean, ByRef skipCopy As Boolean, ByRef id As Integer, _
                              ByRef InstallWorker As AsynhInstall)
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
            Call SetProgressLabel(True, InstallWorker, 1)
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
        Call SetProgressLabel(False, InstallWorker, 1)
    End Sub
    Private Sub copyFiles(ByRef f As List(Of String), ByRef IsError As Boolean, ByRef skipCopy As Boolean, _
                          ByRef ignore As List(Of String), ByRef id As Integer, ByRef InstallWorker As AsynhInstall)
        If IsError Or skipCopy Then Exit Sub
        Dim errorRised As Boolean
        Try
            Dim rootfolder As String = GetDestinationDirectory()
            Dim dest As String
            Dim totalSize, complitedSize As Long
            InstallWorker.InstallationWorker.ReportProgress(0, New AsynhInstall.ProgressText With {.destination = -1})

            Dim destIgnore, destList As New List(Of String)
            If Not IsNothing(ignore) Then
                For Each item As String In ignore
                    destIgnore.Add(MakeDestinationPath(id, rootfolder, item).ToLower)
                Next item
                For Each item As String In f
                    dest = MakeDestinationPath(id, rootfolder, item)
                    If Not destIgnore.Contains(dest.ToLower) Then destList.Add(item)
                Next item
            End If

            For Each item As String In destList
                totalSize += New System.IO.FileInfo(item).Length
            Next item

            For Each source As String In destList
                dest = MakeDestinationPath(id, rootfolder, source)
                Call CopyFile(source, dest)
                complitedSize += New System.IO.FileInfo(source).Length

                If Math.Abs(CLng(Environment.TickCount) - CLng(InstallWorker.LastReportTime)) > 200 Then
                    InstallWorker.LastReportTime = Environment.TickCount
                    Call SendProgreeBarValue(complitedSize, totalSize, InstallWorker)
                End If
                If InstallWorker.InstallationWorker.CancellationPending Then End
                Do While InstallWorker.PauseInstallationWorker
                    Threading.Thread.Sleep(100)
                    If InstallWorker.InstallationWorker.CancellationPending Then End
                Loop
            Next source
            Call SendProgreeBarValue(complitedSize, totalSize, InstallWorker)
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
            Call SetProgressLabel(False, InstallWorker, 1)
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
            Call SetProgressLabel(False, InstallWorker, 1)
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
    Private Function MakeDestinationPath(ByRef id As Integer, ByRef rootfolder As String, _
                                         ByRef source As String) As String
        Dim dest As String
        Dim maxI As Integer
        If id = 4 Then
            maxI = 0
        Else
            maxI = 1
        End If
        If Not id = 5 Then
            dest = source
            For i As Integer = 0 To maxI Step 1
                dest = dest.Substring(dest.IndexOf("\") + 1)
            Next i
        Else
            dest = source.Substring(source.LastIndexOf("\") + 1)
        End If
        Return rootfolder & dest
    End Function

    Private Sub CopyFile(ByRef source As String, ByRef destination As String)
        Dim s() As String = destination.Split(CChar("\"))
        Dim d As String = s(0)
        For i As Integer = 1 To UBound(s) - 1 Step 1
            d &= "\" & s(i)
            If Not IO.Directory.Exists(d) Then IO.Directory.CreateDirectory(d)
        Next i
        IO.File.Copy(source, destination, True)
    End Sub
    Private Sub SetProgressLabel(ByRef riseExceptionOnError As Boolean, ByRef InstallWorker As AsynhInstall, ByRef dest As Integer)
        Dim v As Integer = Common.ProgressPersantage(myowner.InstallationProgressBar.Value, myowner.InstallationProgressBar.Maximum)
        Dim msg As New AsynhInstall.ProgressText
        msg.destination = dest
        If msg.destination = 1 Then
            msg.txt = comm.MultiStringConversion(myowner.progressList, riseExceptionOnError)
        ElseIf msg.destination = 2 Then
            msg.txt = myowner.mapsList
        Else
            msg.txt = ""
        End If
        InstallWorker.InstallationWorker.ReportProgress(v, msg)
    End Sub
    Private Sub SendProgreeBarValue(ByRef currentVal As Long, ByRef maxVal As Long, ByRef InstallWorker As AsynhInstall)
        Dim v As Integer = Common.ProgressPersantage(currentVal, maxVal)
        InstallWorker.InstallationWorker.ReportProgress(v, New AsynhInstall.ProgressText With {.destination = -1})
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
                    Dim splited() As String = s(i).Replace(" ", "").Split(CChar(delimiter))
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

Class AsynhInstall

    Private myowner As InstallForm
    Private comm As Common
    Private inst As Installer

    Public WithEvents InstallationWorker As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Public PauseInstallationWorker As Boolean

    Public LastReportTime As Long

    Public Structure ProgressText
        Dim txt As String
        ''' <summary>
        ''' -1 - никуда
        '''  1 - ActionLabel
        '''  2 - ModMapsLabet
        ''' </summary>
        Dim destination As Integer
    End Structure

    Public Sub New(ByRef s As InstallForm, ByRef c As Common)
        myowner = s
        comm = c
        inst = New Installer(myowner, comm)
    End Sub

    Sub meaninglessjob() Handles InstallationWorker.DoWork
        PauseInstallationWorker = False
        Try
            inst.InstallTask(Me)
        Catch ex As Exception
            Console.WriteLine("Ошибка при работе установщика: " & ex.Message)
        End Try
        PauseInstallationWorker = False
    End Sub

    Private Sub ReportProgressEventHandler(s As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles InstallationWorker.ProgressChanged
        Try
            Call Common.SetPercentage(e.ProgressPercentage, myowner.InstallationProgressBar)
            If TypeOf e.UserState Is ProgressText Then
                Dim p As ProgressText = CType(e.UserState, ProgressText)
                If Not p.destination = -1 Then
                    If p.destination = 1 Then
                        myowner.ActionLabel.Text = p.txt
                        myowner.ActionLabel.SelectionStart = myowner.ActionLabel.Text.Length
                        myowner.ActionLabel.ScrollToCaret()
                        myowner.ActionLabel.Refresh()
                    ElseIf p.destination = 2 Then
                        If Not myowner.ModMapsLabel.Text = "" Then myowner.ModMapsLabel.Text &= vbNewLine
                        myowner.ModMapsLabel.Text = p.txt
                        myowner.ModMapsLabel.Refresh()
                    Else
                        Throw New Exception("Неожиданный id бокса")
                    End If
                End If
            Else
                Throw New Exception("Неожиданный тип данных")
            End If
        Catch ex As Exception
            Console.WriteLine("Ошибка при отображении прогресса: " & ex.Message)
        End Try
    End Sub

    Private Sub WorkComplitedEventHandler() Handles InstallationWorker.RunWorkerCompleted
        Call myowner.SaveSettings()
        myowner.InstallationProgressBar.Visible = False
        myowner.ProgressLabel.Visible = False
        myowner.FinishButton.Enabled = True
        myowner.CancButton.Enabled = False
    End Sub

    Public Sub CancelInstallationWork()
        InstallationWorker.CancelAsync()
    End Sub

    Public Sub PauseInstallationWork()
        PauseInstallationWorker = True
    End Sub
    Public Sub ResumeInstallationWork()
        PauseInstallationWorker = False
    End Sub

End Class

Class MapNameRead

    Public Shared Function Read(ByRef path As String) As String
        Try
            Dim f As String = path.Substring(path.LastIndexOf("\") + 1)
            Dim iPos As Integer = f.LastIndexOf(".")
            If iPos = -1 Then Return ""
            If Not f.Substring(iPos).ToUpper = ".SG" Then Return ""
            If Not IO.File.Exists(path) Then Return ""
            Dim content() As Byte = IO.File.ReadAllBytes(path)
            Dim name(255) As Byte
            Dim startByte As Integer = 321
            For i As Integer = startByte To Math.Min(UBound(content), startByte + UBound(name)) Step 1
                name(i - startByte) = content(i)
            Next i
            For i As Integer = UBound(name) To 0 Step -1
                If name(i) > 0 Or i = 0 Then
                    ReDim Preserve name(i)
                    Exit For
                End If
            Next i
            Dim txt As String = System.Text.Encoding.GetEncoding(1251).GetString(name)
            Return txt
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class