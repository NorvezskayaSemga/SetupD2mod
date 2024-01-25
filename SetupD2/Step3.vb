Public Class InstallForm

    Private comm As Common
    Public prevForm As SettingsForm
    Public progressList, mapsList As String
    Friend inst As AsynhInstall
    Friend GLWrapperInstalled As Boolean

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
        HintLabel41.Visible = SettingsForm.EnableGLWrapper
        HintLabel42.Visible = SettingsForm.EnableGLWrapper
        WrapperLinkLabel.Visible = SettingsForm.EnableGLWrapper
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

    Private Sub ChangeLang(sender As Object, e As System.EventArgs) Handles LangRuRadioButton.CheckedChanged, LangEnRadioButton.CheckedChanged, LangEspRadioButton.CheckedChanged
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
    Private tmpDirs() As String
    Private modSettings As New Dictionary(Of String, String)
    Private state As New Dictionary(Of String, Boolean)

    Public Sub New(ByRef s As InstallForm, ByRef c As Common)
        myowner = s
        comm = c
        Call loadModSettings(CType(s.prevForm, Control))
    End Sub

    Private Sub loadModSettings(ByRef current As Control)
        For Each item As Control In current.Controls
            If TypeOf item Is Panel Then
                Call loadModSettings(item)
            ElseIf TypeOf item Is TabControl Then
                For Each page As TabPage In CType(item, TabControl).TabPages
                    Call loadModSettings(page.Controls(0))
                Next page
            Else
                Dim addEnabled As Boolean = True
                If TypeOf item Is TextBox Then
                    modSettings.Add(item.Name & ".Text", CType(item, TextBox).Text)
                ElseIf TypeOf item Is ComboBox Then
                    modSettings.Add(item.Name & ".Text", CType(item, ComboBox).Text)
                ElseIf TypeOf item Is CheckBox Then
                    state.Add(item.Name & ".Checked", CType(item, CheckBox).Checked)
                ElseIf TypeOf item Is RadioButton Then
                    state.Add(item.Name & ".Checked", CType(item, RadioButton).Checked)
                Else
                    addEnabled = False
                End If
                If addEnabled Then
                    state.Add(item.Name & ".Enabled", item.Enabled)
                End If
            End If
        Next item
    End Sub

    Friend Sub InstallTask(ByRef InstallWorker As AsynhInstall)
        Dim IsError As Boolean = False
        Dim skipCopy As Boolean
        For id As Integer = 1 To 5 Step 1
            Call CopyFolder(IsError, skipCopy, id, InstallWorker)
        Next id
        Call MakeAbsentFolders()
        Call SetDifficulty()
        If Not myowner.prevForm.SFXProjectCheckBox.Checked Then Call DistributiveHandler.CompleteSFXProjectRemove(myowner)
        Call (New RewriteSettings(comm, myowner, GetDestinationDirectory)).Rewrite(modSettings, state)
        Call AddMsg(My.Resources.completed)
        Call AddMsg(My.Resources.LinesDelimiter)
        Call AddMsg(My.Resources.IfYouHaveProblemsMsg)
        Call SetProgressLabel(True, InstallWorker, 1)
    End Sub
    Private Sub CopyFolder(ByRef IsError As Boolean, ByRef skipCopy As Boolean, ByRef id As Integer, _
                           ByRef InstallWorker As AsynhInstall)
        Dim f() As List(Of String) = GetFilesList(id, InstallWorker)
        If Not IsNothing(f) Then
            Call TestFilesList(f(0), IsError, skipCopy, id, InstallWorker)
            Call copyFiles(f(0), IsError, skipCopy, f(1), id, InstallWorker)
            If Not IsNothing(tmpDirs) Then
                For Each p As String In tmpDirs
                    If IO.Directory.Exists(p) Then IO.Directory.Delete(p, True)
                Next p
            End If
            If id = 5 Then myowner.GLWrapperInstalled = True
        End If
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
                L = DistributiveHandler.GetFullVersionFiles(myowner.prevForm)
            Else
                L = DistributiveHandler.GetModFiles(myowner.prevForm)
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
            ElseIf myowner.prevForm.EspTextRadioButton.Checked Then
                Return New List(Of String)() {DistributiveHandler.GetEspFiles(True), IgnorFiles}
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
            If Not myowner.prevForm.GLWrapperCheckBox.Checked Then Return Nothing
            Call AddMsg(My.Resources.copyGLWrapper)
            Call SetProgressLabel(True, InstallWorker, 1)
            Dim dw As New DownloadGLWrapper(InstallWorker.InstallationWorker, myowner.InstallationProgressBar)
            Dim p()() As String = Nothing
            Try
                p = dw.Download
            Catch ex As Exception
                Call AddMsg(My.Resources.copyGLWrapperErr)
                Call AddMsg(My.Resources.errorMsgTag & ex.Message)
            End Try

            If Not IsNothing(p) Then
                Dim L(UBound(p)), res As List(Of String)
                res = New List(Of String)
                ReDim tmpDirs(UBound(p))
                For k As Integer = 0 To UBound(p) Step 1
                    If IO.File.Exists(p(k)(0)) Then
                        Try
                            IO.File.Delete(p(k)(0))
                        Catch ex As UnauthorizedAccessException
                            Console.WriteLine(ex.Message)
                        Catch ex As Exception
                            Throw ex
                        End Try
                    End If
                    tmpDirs(k) = p(k)(1)
                    L(k) = DistributiveHandler.GetWrapperFiles(p(k)(1))
                    For Each s As String In L(k)
                        res.Add(s)
                    Next s
                Next k
                Return New List(Of String)() {res, IgnorFiles}
            Else
                Return Nothing
            End If
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
                If myowner.prevForm.EnTextRadioButton.Checked Then
                    Call AddMsg(My.Resources.noTextLangFound_eng)
                ElseIf myowner.prevForm.EspTextRadioButton.Checked Then
                    Call AddMsg(My.Resources.noTextLangFound_esp)
                End If
            ElseIf id = 3 Then
                If myowner.prevForm.EnSoundRadioButton.Checked Then
                    Call AddMsg(My.Resources.noSoundLangFound_eng)
                End If
                'ElseIf myowner.prevForm.EspSoundRadioButton.Checked Then
                '    Call AddMsg(My.Resources.noSoundLangFound_esp)
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
            If myowner.prevForm.EnTextRadioButton.Checked Then
                Call AddMsg(My.Resources.copyTextLang_eng)
            ElseIf myowner.prevForm.EspTextRadioButton.Checked Then
                Call AddMsg(My.Resources.copyTextLang_esp)
            End If
        ElseIf id = 3 Then
            If myowner.prevForm.EnSoundRadioButton.Checked Then
                Call AddMsg(My.Resources.copySoundLang_eng)
            End If
            'ElseIf myowner.prevForm.EspSoundRadioButton.Checked Then
            '    Call AddMsg(My.Resources.copySoundLang_esp)
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
                Call AddMsg(My.Resources.copyFilesErr)
            ElseIf id = 2 Then
                If myowner.prevForm.EnTextRadioButton.Checked Then
                    Call AddMsg(My.Resources.copyTextLangErr_eng)
                ElseIf myowner.prevForm.EspTextRadioButton.Checked Then
                    Call AddMsg(My.Resources.copyTextLangErr_esp)
                End If
            ElseIf id = 3 Then
                If myowner.prevForm.EnSoundRadioButton.Checked Then
                    Call AddMsg(My.Resources.copySoundLangErr_eng)
                End If
                'ElseIf myowner.prevForm.EspSoundRadioButton.Checked Then
                '    Call AddMsg(My.Resources.copySoundLangErr_esp)
            ElseIf id = 4 Then
                Call AddMsg(My.Resources.copyToolsErr)
            ElseIf id = 5 Then
                Call AddMsg(My.Resources.copyGLWrapperErr)
            Else
                MsgBox("Invalid id " & id)
                End
            End If
            Call AddMsg(My.Resources.errorMsgTag & ex.Message)
            Call SetProgressLabel(False, InstallWorker, 1)
        End Try
        If Not errorRised Then
            If id = 1 Then
                Call AddMsg(My.Resources.copyFilesOk)
            ElseIf id = 2 Then
                If myowner.prevForm.EnTextRadioButton.Checked Then
                    Call AddMsg(My.Resources.copyTextLangOk_eng)
                ElseIf myowner.prevForm.EspTextRadioButton.Checked Then
                    Call AddMsg(My.Resources.copyTextLangOk_esp)
                End If
            ElseIf id = 3 Then
                If myowner.prevForm.EnSoundRadioButton.Checked Then
                    Call AddMsg(My.Resources.copySoundLangOk_eng)
                End If
                'ElseIf myowner.prevForm.EspSoundRadioButton.Checked Then
                '    Call AddMsg(My.Resources.copySoundLangOk_esp)
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
    Friend Shared Function GetDestinationDirectory(ByRef f As InstallForm) As String
        Dim d As String = f.prevForm.prevForm.SelectTextBox.Text
        If Not d.Substring(d.Length - 1) = "\" Then d &= "\"
        Return d
    End Function
    Friend Function GetDestinationDirectory() As String
        Return Installer.GetDestinationDirectory(myowner)
    End Function
    Friend Shared Sub AddMsg(ByRef msg As String, ByRef f As InstallForm)
        If Not f.progressList = "" Then f.progressList &= vbNewLine
        f.progressList &= msg
    End Sub
    Friend Sub AddMsg(ByRef msg As String)
        Call Installer.AddMsg(msg, myowner)
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
            dest = source.Substring(source.LastIndexOf(My.Resources.extractedTmpFolder & "\") + My.Resources.extractedTmpFolder.Length + 1)
        End If
        Return rootfolder & dest
    End Function

    Private Sub SetDifficulty()
        Try
            Dim source, destination, wdir As String
            wdir = GetDestinationDirectory() & "Globals\"
            destination = "GAI.dbf"
            If myowner.prevForm.VanillaGAIRadioButton.Checked Then
                source = "GAI_vanilla.dbf"
            ElseIf myowner.prevForm.NormalGAIRadioButton.Checked Then
                source = "GAI_normal.dbf"
            ElseIf myowner.prevForm.ExpPlusGAIRadioButton.Checked Then
                source = "GAI_exp+.dbf"
            Else
                Throw New Exception(My.Resources.DifficultyUnexpected)
            End If
            IO.File.Copy(wdir & source, wdir & destination, True)
            If myowner.prevForm.VanillaGAIRadioButton.Checked Then
                Call AddMsg(My.Resources.DifficultyVanilla)
            ElseIf myowner.prevForm.NormalGAIRadioButton.Checked Then
                Call AddMsg(My.Resources.DifficultyNormal)
            ElseIf myowner.prevForm.ExpPlusGAIRadioButton.Checked Then
                Call AddMsg(My.Resources.DifficultyExpPlus)
            Else
                Throw New Exception(My.Resources.DifficultyUnexpected)
            End If
        Catch ex As Exception
            Call AddMsg(My.Resources.DifficultyError)
            Call AddMsg(My.Resources.errorMsgTag & ex.Message)
        End Try

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
    Private Sub MakeAbsentFolders()
        Dim rootfolder As String = GetDestinationDirectory()
        For Each folder As String In My.Resources.foldersList.Split(CChar(":"))
            If Not IO.Directory.Exists(rootfolder & folder) Then IO.Directory.CreateDirectory(rootfolder & folder)
        Next folder
    End Sub

End Class

Class RewriteSettings

    Private comm As Common
    Private myowner As InstallForm
    Private destinationDirectory As String

    Public Sub New(ByRef c As Common, ByRef o As InstallForm, ByRef destDir As String)
        comm = c
        myowner = o
        destinationDirectory = destDir
    End Sub

    Public Sub Rewrite(modSettings As Dictionary(Of String, String), state As Dictionary(Of String, Boolean))
        Call SettingsLua(modSettings, state)
        'Call DiscipleIni() -- old method
    End Sub

    Private Class OverwriteInfo
        Public value As String
        Public parameter As String
        Public containerUpper As String
        Public container As String
        Public added As Boolean = False

        Public Sub New(v As String, c As String, p As String)
            value = v
            containerUpper = c.ToUpper
            container = c
            parameter = p
        End Sub

        Public Shared Sub Add(ByRef overwrite As Dictionary(Of String, OverwriteInfo), key As String, val As String, cont As String)
            Dim info As New OverwriteInfo(val, cont.Replace(" ", ""), key)
            overwrite.Add(key.ToUpper, info)
        End Sub

        Public Shared Function HandleString(s As String) As Boolean
            Return (s.Length > 0 AndAlso s.Trim(CChar(" "), CChar(vbTab)).StartsWith("--") = False)
        End Function
        Public Shared Function GetKey(splited() As String) As String
            Return splited(0).Trim(CChar(" "), CChar(vbTab)).ToUpper
        End Function
        Public Shared Function GetValue(splited() As String) As String
            If splited.Length > 1 Then
                Return splited(1).Trim(CChar(" "), CChar(vbTab))
            Else
                Return ""
            End If
        End Function
        Public Shared Sub ResizeContainer(ByRef currentContainer() As String, k As String, enlarge As Boolean)
            If enlarge Then
                ReDim Preserve currentContainer(currentContainer.Length)
                currentContainer(UBound(currentContainer)) = k.Replace(",", "")
            Else
                ReDim Preserve currentContainer(UBound(currentContainer) - 1)
            End If
        End Sub
    End Class

    Private Sub SettingsLua(modSettings As Dictionary(Of String, String), state As Dictionary(Of String, Boolean))

        Try
            Dim f As String = destinationDirectory & "Disciple.ini"
            If Not IO.File.Exists(f) Then Exit Sub

            Dim overwrite As New Dictionary(Of String, OverwriteInfo)

            If Not state("GLWrapperCheckBox.Enabled") Or (state("GLWrapperCheckBox.Checked") And myowner.GLWrapperInstalled) Then
                OverwriteInfo.Add(overwrite, "UseD3D", "0", "")
                OverwriteInfo.Add(overwrite, "DisplayMode", "1", "")
            End If
            If state("EspTextRadioButton.Checked") Then
                OverwriteInfo.Add(overwrite, "Locale", "1034", "")
            Else
                OverwriteInfo.Add(overwrite, "Locale", "1049", "")
            End If

            Dim s() As String = IO.File.ReadAllLines(f)
            Dim delimiter As String = "="
            Dim k, v As String
            For i As Integer = 0 To UBound(s) Step 1
                If s(i).Length > 0 AndAlso s(i).Contains(delimiter) Then
                    Dim splited() As String = s(i).Split(CChar(delimiter))
                    k = splited(0).Trim(CChar(" "), CChar(vbTab)).ToUpper
                    If overwrite.ContainsKey(k) Then
                        s(i) = splited(0) & delimiter & overwrite.Item(k).value
                        overwrite.Item(k).added = True
                    End If
                End If
            Next i
            IO.File.WriteAllLines(f, s)

            f = destinationDirectory & "Scripts\settings.lua"
            If Not IO.File.Exists(f) Then Exit Sub
            s = IO.File.ReadAllLines(f)
            overwrite.Clear()

            OverwriteInfo.Add(overwrite, "carryOverItemsMax", modSettings("carryOverItemsMaxTextBox.Text"), "settings")
            OverwriteInfo.Add(overwrite, "unitMaxDamage", modSettings("unitMaxDamageTextBox.Text"), "settings")

            'overwrite.Add(("criticalHitDamage").ToUpper, myowner.prevForm.criticalHitDamageTextBox.Text)
            'overwrite.Add(("criticalHitChance").ToUpper, myowner.prevForm.criticalHitChanceTextBox.Text)
            If state("MissUseSingleRollRadioButton.Checked") Then
                OverwriteInfo.Add(overwrite, "missChanceSingleRoll", "true", "settings")
            Else
                OverwriteInfo.Add(overwrite, "missChanceSingleRoll", "false", "settings")
            End If
            If state("AIAccuracyBonusCheckBox.Checked") Then
                OverwriteInfo.Add(overwrite, "easy", "0", "settings,aiAccuracyBonus")
                OverwriteInfo.Add(overwrite, "average", "0", "settings,aiAccuracyBonus")
                OverwriteInfo.Add(overwrite, "hard", "0", "settings,aiAccuracyBonus")
                OverwriteInfo.Add(overwrite, "veryHard", "0", "settings,aiAccuracyBonus")
            Else
                OverwriteInfo.Add(overwrite, "easy", "-15", "settings,aiAccuracyBonus")
                OverwriteInfo.Add(overwrite, "average", "0", "settings,aiAccuracyBonus")
                OverwriteInfo.Add(overwrite, "hard", "5", "settings,aiAccuracyBonus")
                OverwriteInfo.Add(overwrite, "veryHard", "10", "settings,aiAccuracyBonus")
            End If

            OverwriteInfo.Add(overwrite, "defaultStatsShowMode", "'unitEncyclopedia_" & modSettings("defaultStatsShowModeComboBox.Text") & "'", "mnsSettings")
            OverwriteInfo.Add(overwrite, "alternativeStatsShowMode", "'unitEncyclopedia_" & modSettings("alternativeStatsShowModeComboBox.Text") & "'", "mnsSettings")
            OverwriteInfo.Add(overwrite, "statsShowModeSwitchKey", "KeyboardKey." & modSettings("statsShowModeSwitchKeyComboBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "LuckEffectMode", "'LuckEffectMode." & modSettings("LuckEffectModeComboBox.Text") & "'", "mnsSettings")
            OverwriteInfo.Add(overwrite, "damageSpreadMode", "SpreadMode." & modSettings("damageSpreadModeComboBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "damageSpreadApplyPower", modSettings("damageSpreadApplyPowerComboBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "damageSpreadUpperMulti", modSettings("damageSpreadMultiTextBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "damageSpreadLowerMulti", modSettings("damageSpreadMultiTextBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "healSpreadMode", modSettings("healSpreadModeComboBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "healSpreadUpperMulti", modSettings("healSpreadMultiTextBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "healSpreadLowerMulti", modSettings("healSpreadMultiTextBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "healLuckChance", modSettings("healLuckChanceTextBox.Text"), "mnsSettings")
            OverwriteInfo.Add(overwrite, "healUnluckMulti", modSettings("healUnluckMultiTextBox.Text"), "mnsSettings")

            Dim currentContainer(-1) As String

            ' замена параметров
            For i As Integer = 0 To UBound(s) Step 1
                If OverwriteInfo.HandleString(s(i)) Then
                    Dim splited() As String = s(i).Split(CChar(delimiter))
                    k = OverwriteInfo.GetKey(splited)
                    v = OverwriteInfo.GetValue(splited)
                    If s(i).Contains(delimiter) Then
                        If v.StartsWith("{") Then
                            Call OverwriteInfo.ResizeContainer(currentContainer, k, True)
                        End If
                        If overwrite.ContainsKey(k) Then
                            If overwrite.Item(k).containerUpper = String.Join(",", currentContainer).ToUpper Then
                                s(i) = splited(0) & delimiter & " " & overwrite.Item(k).value & ","
                                overwrite.Item(k).added = True
                            End If
                        End If
                    End If
                    If k.StartsWith("}") Then
                        Call OverwriteInfo.ResizeContainer(currentContainer, k, False)
                    End If
                End If
            Next i

            ' добавление контейнеров
            Dim maxContainerLen, maxContainerI, addAfterI, q, d As Integer
            Dim maxContainer As String
            For Each key As String In overwrite.Keys
                If Not overwrite.Item(key).added Then
                    maxContainer = ""
                    maxContainerLen = 0
                    maxContainerI = -1
                    For i As Integer = 0 To UBound(s) Step 1
                        If OverwriteInfo.HandleString(s(i)) Then
                            Dim splited() As String = s(i).Split(CChar(delimiter))
                            k = OverwriteInfo.GetKey(splited)
                            v = OverwriteInfo.GetValue(splited)
                            If s(i).Contains(delimiter) Then
                                If v.StartsWith("{") Then
                                    Call OverwriteInfo.ResizeContainer(currentContainer, k, True)
                                    If overwrite.Item(key).containerUpper.StartsWith(String.Join(",", currentContainer).ToUpper) Then
                                        If maxContainerLen < currentContainer.Length Then
                                            maxContainerLen = currentContainer.Length
                                            maxContainerI = i
                                            maxContainer = String.Join(",", currentContainer).ToUpper
                                        End If
                                    End If
                                End If
                            End If
                            If k.StartsWith("}") Then
                                Call OverwriteInfo.ResizeContainer(currentContainer, k, False)
                            End If
                        End If
                    Next i
                    If Not maxContainer = overwrite.Item(key).containerUpper Then
                        If maxContainerI > -1 Then
                            addAfterI = maxContainerI
                        Else
                            addAfterI = UBound(s)
                        End If
                        Dim sContainer() As String = overwrite.Item(key).container.Split(CChar(","))
                        d = 2 * (sContainer.Length - maxContainerLen)
                        ReDim Preserve s(UBound(s) + d)
                        For j As Integer = UBound(s) To addAfterI + d Step -1
                            s(j) = s(j - d)
                        Next j
                        For n As Integer = maxContainerLen To UBound(sContainer) Step 1
                            q = addAfterI + n + 1 - maxContainerLen
                            s(q) = sContainer(n) & " " & delimiter & " {"
                            For j = 1 To n Step 1
                                s(q) = vbTab & s(q)
                            Next j
                            q = addAfterI + d - n + maxContainerLen
                            s(q) = "}"
                            If n = 0 Then
                                s(q) &= vbNewLine
                            Else
                                s(q) &= ","
                            End If
                            For j = 1 To n Step 1
                                s(q) = vbTab & s(q)
                            Next j
                        Next n
                    End If
                End If
            Next key

            ' добавление параметров в контейнеры
            For Each key As String In overwrite.Keys
                If Not overwrite.Item(key).added Then
                    For i As Integer = 0 To UBound(s) Step 1
                        If OverwriteInfo.HandleString(s(i)) Then
                            Dim splited() As String = s(i).Split(CChar(delimiter))
                            k = OverwriteInfo.GetKey(splited)
                            v = OverwriteInfo.GetValue(splited)
                           If s(i).Contains(delimiter) Then
                                If v.StartsWith("{") Then
                                    Call OverwriteInfo.ResizeContainer(currentContainer, k, True)
                                    If overwrite.Item(key).containerUpper = String.Join(",", currentContainer).ToUpper Then
                                        ReDim Preserve s(s.Length)
                                        For j As Integer = UBound(s) To i + 2 Step -1
                                            s(j) = s(j - 1)
                                        Next j
                                        i = i + 1
                                        s(i) = ""
                                        For n As Integer = 0 To UBound(currentContainer) Step 1
                                            s(i) &= vbTab
                                        Next n
                                        s(i) &= overwrite.Item(key).parameter & " " & delimiter & " " & overwrite.Item(key).value & ","
                                        overwrite.Item(key).added = True
                                        ReDim currentContainer(-1)
                                        Exit For
                                    End If
                                End If
                            End If
                            If k.StartsWith("}") Then
                                Call OverwriteInfo.ResizeContainer(currentContainer, k, False)
                            End If
                        End If
                    Next i
                End If
            Next key
            IO.File.WriteAllLines(f, s)
        Catch
        End Try
    End Sub

    Private Sub DiscipleIni()
        Try
            Dim f As String = destinationDirectory & "Disciple.ini"
            If Not IO.File.Exists(f) Then Exit Sub

            Dim overwrite As New Dictionary(Of String, String)
            If myowner.prevForm.GLWrapperCheckBox.Checked And myowner.GLWrapperInstalled Then
                overwrite.Add(("UseD3D").ToUpper, "0")
                overwrite.Add(("DisplayMode").ToUpper, "1")
            End If

            Dim addIfAbsent As New Dictionary(Of String, Integer)
            Dim maxDmg As Integer
            If myowner.prevForm.DmgLimitCheckBox.Checked Then
                maxDmg = 100000
            Else
                maxDmg = 300
            End If
            addIfAbsent.Add("ShatterDamageMax", 15)
            addIfAbsent.Add("ShatteredArmorMax", 100)
            addIfAbsent.Add("UnitMaxDamage", maxDmg)
            addIfAbsent.Add("UnitMaxArmor", 90)
            addIfAbsent.Add("StackMaxScoutRange", 99)
            addIfAbsent.Add("CriticalHitDamage", 5)
            addIfAbsent.Add("DisplayErrors", 1)

            Dim dSection As String = "[Disciple]".ToUpper
            Dim dSectionRow As Integer = -1

            Dim s() As String = IO.File.ReadAllLines(f)
            Dim delimiter As String = "="
            For i As Integer = 0 To UBound(s) Step 1
                If s(i).Length > 0 AndAlso s(i).Contains(delimiter) Then
                    Dim splited() As String = s(i).Split(CChar(delimiter))
                    If overwrite.ContainsKey(splited(0).Trim(CChar(" "), CChar(vbTab)).ToUpper) Then
                        s(i) = splited(0) & delimiter & overwrite.Item(splited(0).ToUpper)
                    End If
                End If
                If dSectionRow < 0 AndAlso s(i).Length >= dSection.Length Then
                    If s(i).Trim(CChar(" ")).ToUpper.StartsWith(dSection) Then dSectionRow = i
                End If
            Next i

            Dim stringExists As Boolean
            For Each item As String In addIfAbsent.Keys
                stringExists = False
                For i As Integer = 0 To UBound(s) Step 1
                    If s(i).Length > 0 AndAlso s(i).Contains(delimiter) Then
                        Dim splited() As String = s(i).Split(CChar(delimiter))
                        If item.ToUpper = splited(0).Trim(CChar(" "), CChar(vbTab)).ToUpper Then
                            stringExists = True
                            Exit For
                        End If
                    End If
                Next i
                If Not stringExists Then
                    s(dSectionRow) &= vbNewLine & "; " & comm.StringConversion("comment_" & item.ToLower, False) & _
                                      vbNewLine & item & " " & delimiter & " " & addIfAbsent.Item(item) & _
                                      vbNewLine
                End If
            Next item

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
            Call inst.InstallTask(Me)
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
        'Call comm.ReplaceCode(myowner)
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
