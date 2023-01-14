Public Class Common

    Public settings As New RegSettings

    Private lang As New Dictionary(Of String, String)

    Private backButtonPressed As Boolean
    Private currentLang As String

    Public Sub actOnLoad(ByRef current As Form, ByRef previous As Form)
        current.MaximizeBox = False
        Call LoadRegistryControlSettings(CType(current, Control))
        If Not IsNothing(previous) Then
            current.Text = previous.Text
            current.Icon = previous.Icon
            Call InheritControlsSettings(CType(current, Control), CType(previous, Control))
            previous.Visible = False
        Else
            current.Location = New Point(CInt(0.5 * (Screen.PrimaryScreen.WorkingArea.Width - current.Size.Width)), _
                                         CInt(0.5 * (Screen.PrimaryScreen.WorkingArea.Height - current.Size.Height)))
        End If
        current.MinimumSize = New Size(current.Size.Width, current.Size.Height)
        current.MaximumSize = New Size(current.Size.Width, current.Size.Height)

        If TypeOf current Is Main Then
            CType(current, Main).Text = My.Resources.title & DistributiveHandler.GetVersion()
        ElseIf TypeOf current Is SettingsForm Then
            'CType(current, Step2).RuTextRadioButton.Checked = CType(current, Step2).LangRuRadioButton.Checked
            'CType(current, Step2).RuSoundRadioButton.Checked = CType(current, Step2).LangRuRadioButton.Checked
            'CType(current, Step2).EnTextRadioButton.Checked = CType(current, Step2).LangEnRadioButton.Checked
            'CType(current, Step2).EnSoundRadioButton.Checked = CType(current, Step2).LangEnRadioButton.Checked
        ElseIf TypeOf current Is InstallForm Then
            CType(current, InstallForm).GuideLabel.Links.Clear()
            CType(current, InstallForm).GuideLabel.Links.Add(New LinkLabel.Link With {.LinkData = My.Resources.startGuideLink})
            CType(current, InstallForm).SiteLinkLabel.Links.Clear()
            CType(current, InstallForm).SiteLinkLabel.Links.Add(New LinkLabel.Link With {.LinkData = My.Resources.modSiteLink})
            CType(current, InstallForm).WrapperLinkLabel.Links.Clear()
            CType(current, InstallForm).WrapperLinkLabel.Links.Add(New LinkLabel.Link With {.LinkData = My.Resources.VerokBlog})
        End If
    End Sub
    Private Sub InheritControlsSettings(ByRef current As Control, ByRef previous As Control)
        current.Size = New Size(previous.Size.Width, previous.Size.Height)
        current.Location = New Point(previous.Location.X, previous.Location.Y)
        current.Dock = previous.Dock
        current.Anchor = previous.Anchor

        For Each item As Control In previous.Controls
            Dim destControlName As String = ""
            If (current.Controls.ContainsKey("InstallButton") OrElse current.Controls.ContainsKey("FinishButton")) _
             AndAlso (item.Name = "NextButton" OrElse item.Name = "InstallButton") Then
                If current.Controls.ContainsKey("InstallButton") Then
                    destControlName = "InstallButton"
                ElseIf current.Controls.ContainsKey("FinishButton") Then
                    destControlName = "FinishButton"
                End If
            Else
                destControlName = item.Name
            End If
            If current.Controls.ContainsKey(destControlName) Then
                Call InheritControlsSettings(current.Controls.Item(destControlName), item)
                If TypeOf item Is Panel Then
                    For Each c As Control In item.Controls
                        item.Size = New Size(Math.Max(item.Size.Width, c.Location.X + c.Size.Width + 2), _
                                             Math.Max(item.Size.Height, c.Location.Y + c.Size.Height + 2))
                    Next c
                ElseIf TypeOf item Is RadioButton Then
                    CType(current.Controls.Item(destControlName), RadioButton).Checked = CType(item, RadioButton).Checked
                ElseIf TypeOf item Is PictureBox Then
                    current.Controls.Item(destControlName).BackgroundImage = item.BackgroundImage
                End If
            End If
        Next item
    End Sub
    Private Sub LoadRegistryControlSettings(ByRef current As Control)
        For Each item As Control In current.Controls
            If TypeOf item Is Panel Then
                Call LoadRegistryControlSettings(item)
            ElseIf TypeOf item Is TabControl Then
                For Each page As TabPage In CType(item, TabControl).TabPages
                    Call LoadRegistryControlSettings(page.Controls(0))
                Next page
            Else
                Call settings.ReadSetting(item)
            End If
        Next item
    End Sub
    Public Sub SaveRegistryControlSettings(ByRef current As Control, ByRef IgnoreNames As List(Of String))
        For Each item As Control In current.Controls
            If TypeOf item Is Panel Then
                Call SaveRegistryControlSettings(item, IgnoreNames)
            ElseIf TypeOf item Is TabControl Then
                For Each page As TabPage In CType(item, TabControl).TabPages
                    Call SaveRegistryControlSettings(page.Controls(0), IgnoreNames)
                Next page
            Else
                Call settings.WriteSettings(item, IgnoreNames)
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
        If TypeOf current Is InstallForm Then Call CType(current, InstallForm).inst.PauseInstallationWork()
        Dim canc As New CustomDialog(lang, current)
        Dim response As DialogResult = canc.ShowDialog(current)
        If response = DialogResult.Yes Then End
        If TypeOf current Is InstallForm Then Call CType(current, InstallForm).inst.ResumeInstallationWork()
        'response = MsgBox(lang.Item(My.Resources.CancelMsgKeyword), MsgBoxStyle.YesNo)
    End Sub

    Public Sub SetLang(ByRef c As Control, ByRef LangRButton As RadioButton)
        If Not LangRButton.Checked Then Exit Sub
        Call ReadLangFile(LangRButton)
        For Each item As Control In c.Controls
            If TypeOf item Is Panel Then
                Call SetLang(item, LangRButton)
            ElseIf TypeOf item Is Button _
            OrElse TypeOf item Is RadioButton _
            OrElse TypeOf item Is Label _
            OrElse TypeOf item Is LinkLabel _
            OrElse TypeOf item Is CheckBox Then
                item.Text = MultiStringConversion(item.Name)
            ElseIf TypeOf item Is TextBox And TypeOf item.Parent Is InstallForm And item.Name = "ActionLabel" Then
                Dim msg As String = CType(item.Parent, InstallForm).progressList
                If msg = "" Then msg = item.Name
                item.Text = MultiStringConversion(msg)
            ElseIf TypeOf item Is TabControl Then
                For Each page As TabPage In CType(item, TabControl).TabPages
                    page.Text = MultiStringConversion(page.Name)
                    Call SetLang(page.Controls(0), LangRButton)
                Next page
            End If
        Next item
        If TypeOf c Is InstallForm Then
            If LangRButton.Checked Then
                Call PlaceLabel(CType(c, InstallForm).HintLabel12, CType(c, InstallForm).HintLabel11, False)
                Call PlaceLinkLabel(CType(c, InstallForm).GuideLabel, CType(c, InstallForm).HintLabel12)

                Call PlaceLabel(CType(c, InstallForm).HintLabel2, CType(c, InstallForm).HintLabel12, True)

                Call PlaceLabel(CType(c, InstallForm).HintLabel31, CType(c, InstallForm).HintLabel2, True)
                Call PlaceLabel(CType(c, InstallForm).HintLabel32, CType(c, InstallForm).HintLabel31, False)
                Call PlaceLinkLabel(CType(c, InstallForm).SiteLinkLabel, CType(c, InstallForm).HintLabel32)
                
                Call PlaceLabel(CType(c, InstallForm).HintLabel41, CType(c, InstallForm).HintLabel32, True)
                Call PlaceLabel(CType(c, InstallForm).HintLabel42, CType(c, InstallForm).HintLabel41, False)
                Call PlaceLinkLabel(CType(c, InstallForm).WrapperLinkLabel, CType(c, InstallForm).HintLabel42)

                Call PlaceLabel(CType(c, InstallForm).HintLabel51, CType(c, InstallForm).HintLabel42, True)
                Call PlaceLabel(CType(c, InstallForm).HintLabel52, CType(c, InstallForm).HintLabel51, False)

                For Each item As Control In CType(c, InstallForm).HintPanel.Controls
                    CType(c, InstallForm).HintPanel.Size = New Size(Math.Max(CType(c, InstallForm).HintPanel.Size.Width, item.Location.X + item.Size.Width + 2), _
                                                              Math.Max(CType(c, InstallForm).HintPanel.Size.Height, item.Location.Y + item.Size.Height + 2))
                Next item
            End If
        End If
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
            If splited(i).Length > 0 Then
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

    Public Function StringConversion(ByVal str As String, Optional ByRef riseExceptionOnError As Boolean = True) As String
        Dim res As String
        str = str.Replace(Chr(10), "")
        If lang.ContainsKey(str) Then
            res = lang.Item(str)
        Else
            If str.Length >= My.Resources.errorMsgTag.Length AndAlso str.StartsWith(My.Resources.errorMsgTag) Then
                res = str
            Else
                Dim errTxt As String = "В словаре не хватает записи для " & str
                If riseExceptionOnError Then
                    Throw New Exception(errTxt)
                    res = "***error"
                Else
                    res = errTxt
                End If
            End If
        End If
        Return res
    End Function
    Public Function MultiStringConversion(ByRef str As String, Optional ByRef riseExceptionOnError As Boolean = True) As String
        Dim s() As String = str.Split(CChar(vbNewLine))
        Dim res As String = ""
        For i As Integer = 0 To UBound(s) Step 1
            res &= StringConversion(s(i), riseExceptionOnError) & vbNewLine
        Next i
        Return res.Remove(res.Length - 1)
    End Function

    Private Sub PlaceLabel(ByRef current As Label, ByRef prev As Label, ByRef addSpacing As Boolean)
        Dim blocksSpacing As Integer
        If addSpacing Then blocksSpacing = 8
        current.Location = New Point(prev.Location.X, prev.Location.Y + prev.Size.Height + blocksSpacing)
    End Sub
    Private Sub PlaceLinkLabel(ByRef current As LinkLabel, ByRef prev As Label)
        current.Location = New Point(prev.Location.X + prev.Size.Width, prev.Location.Y)
    End Sub

    Public Shared Function ProgressPersantage(ByRef currentVal As Long, ByRef maxVal As Long) As Integer
        Return Math.Max(0, Math.Min(100, CInt(100 * currentVal / maxVal)))
    End Function
    Public Shared Function ProgressPersantage(ByRef currentVal As Integer, ByRef maxVal As Integer) As Integer
        Return ProgressPersantage(CLng(currentVal), CLng(maxVal))
    End Function
    Public Shared Sub SetPercentage(ByRef value As Integer, ByRef pb As ProgressBar)
        pb.Value = CInt(pb.Maximum * Math.Min(0.01 * value, 1))
    End Sub

    Public Const RussobitExeSize As Integer = 4187648
    Public Const AkellaExeSize As Integer = 4474880
    Public Const GOGExeSize As Integer = 3907200

    Public Sub ReplaceCode(ByRef f As InstallForm)
        If Not f.prevForm.DmgLimitCheckBox.Checked Then Exit Sub
        Dim path As String = Installer.GetDestinationDirectory(f) & "Discipl2.exe"
        Dim tpath As String = Installer.GetDestinationDirectory(f) & "Discipl2.t.exe"
        Dim msg As String = ""
        If Not IO.File.Exists(path) Then msg = My.Resources.limitRemoveErr
        If msg = "" Then
            Dim bias() As Integer = New Integer() {3058044, 3049244, 3055484}
            Dim len() As Integer = New Integer() {GOGExeSize, AkellaExeSize, RussobitExeSize}
            Dim bytes() As Byte = IO.File.ReadAllBytes(path)
            For i As Integer = 0 To UBound(len) Step 1
                If bytes.Length = len(i) Then
                    Dim byteform() As Byte = BitConverter.GetBytes(CInt(10000))
                    For j As Integer = 0 To UBound(byteform) Step 1
                        bytes(bias(i) + j) = byteform(j)
                    Next j
                    Try
                        IO.File.WriteAllBytes(tpath, bytes)
                        IO.File.Delete(path)
                        IO.File.Move(tpath, path)
                        msg = My.Resources.limitRemoveOk
                    Catch ex As Exception
                        msg = ex.Message
                    End Try
                    Exit For
                End If
            Next i
        End If
        If msg = "" Then msg = My.Resources.limitRemoveErr
        Call Installer.AddMsg(msg, f)
        msg = MultiStringConversion(f.progressList, False)
        f.ActionLabel.Text = msg
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

            If TypeOf c Is TextBox Then
                CType(c, TextBox).Text = value.ToString
            ElseIf TypeOf c Is CheckBox Then
                CType(c, CheckBox).Checked = CBool(value)
            ElseIf TypeOf c Is RadioButton Then
                CType(c, RadioButton).Checked = CBool(value)
            End If
        Catch ex As Exception
            errorText = ex.Message
        End Try
        If Not IsNothing(key) Then key.Close()
    End Sub

    Public Sub WriteSettings(ByRef c As Control, ByRef IgnoreNames As List(Of String))
        If Not errorText = "" Then Exit Sub
        If Not IsNothing(IgnoreNames) AndAlso IgnoreNames.Contains(c.Name) Then Exit Sub
        If Not IsRightControl(c) Then Exit Sub
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = My.Computer.Registry.CurrentUser.OpenSubKey(My.Resources.regKey, True)
            If IsNothing(key) Then Exit Sub

            If TypeOf c Is TextBox Then
                key.SetValue(c.Name, CType(c, TextBox).Text)
            ElseIf TypeOf c Is CheckBox Then
                key.SetValue(c.Name, CType(c, CheckBox).Checked)
            ElseIf TypeOf c Is RadioButton Then
                key.SetValue(c.Name, CType(c, RadioButton).Checked)
            End If
        Catch ex As Exception
            errorText = ex.Message
        End Try
        If Not IsNothing(key) Then key.Close()
    End Sub
    Private Function IsRightControl(ByRef c As Control) As Boolean
        If IsNothing(c) Then Return False
        If Not TypeOf c Is TextBox _
        And Not TypeOf c Is CheckBox _
        And Not TypeOf c Is RadioButton Then Return False
        Return True
    End Function

End Class

Public Class DistributiveHandler

    Public Shared Function GetVersion() As String
        Dim p As String
        Dim v As String = "unknown"
        If IO.Directory.Exists(My.Resources.versionPath1) Then
            p = My.Resources.versionPath1
        ElseIf IO.Directory.Exists(My.Resources.versionPath2) Then
            p = My.Resources.versionPath2
        Else
            Return v
        End If

        Dim list() As String = IO.Directory.GetFiles(p)
        If IsNothing(list) Then Return v
        Array.Sort(list)
        v = list(UBound(list))
        v = v.Substring(v.LastIndexOf("\") + 1)
        v = v.Remove(v.LastIndexOf("."))
        Return v
    End Function

    Public Shared Function GetModFiles(ByRef settings As SettingsForm) As List(Of String)
        Dim f, m As New List(Of String)
        Dim ig As List(Of String) = IgnoreList()
        Call GetFolderFiles(f, ig, True, My.Resources.gameDir)
        For Each p As String In f
            If IO.File.GetLastWriteTime(p).Year > 2010 Then m.Add(p)
        Next p
        For Each dll As String In IO.Directory.GetFiles(My.Resources.gameDir, "*.dll")
            m.Add(dll)
        Next dll
        Return SFXProjectFilesFilter(m, settings)
    End Function
    Public Shared Function GetFullVersionFiles(ByRef settings As SettingsForm) As List(Of String)
        Dim f As New List(Of String)
        Dim ig As List(Of String) = IgnoreList()
        Call GetFolderFiles(f, ig, False, My.Resources.gameDir)
        Return SFXProjectFilesFilter(f, settings)
    End Function
    Public Shared Function GetEngFiles(ByRef text As Boolean) As List(Of String)
        Dim f, r As New List(Of String)
        Call GetFolderFiles(f, New List(Of String), False, My.Resources.engFilesDir)
        For Each item As String In f
            Dim s As String = item.Substring(item.LastIndexOf(".")).ToLower
            If text = CBool(Not s = ".wdb" And Not s = ".wdt" And Not s = ".wav") Then r.Add(item)
        Next item
        Return r
    End Function
    Public Shared Function GetToolsAndReadmeFiles() As List(Of String)
        Dim t1 As List(Of String) = GetToolsFiles()
        Dim t2 As List(Of String) = GetReadmeFiles()
        For Each s As String In t2
            t1.Add(s)
        Next s
        Return t1
    End Function
    Private Shared Function GetToolsFiles() As List(Of String)
        Dim f As New List(Of String)
        Call GetFolderFiles(f, New List(Of String), False, My.Resources.toolsDir)
        Return f
    End Function
    Private Shared Function GetReadmeFiles() As List(Of String)
        Dim f As New List(Of String)
        Call GetFolderFiles(f, New List(Of String), False, My.Resources.readmeDir)
        Return f
    End Function
    Public Shared Function GetWrapperFiles(ByRef path As String) As List(Of String)
        Dim f As New List(Of String)
        Call GetFolderFiles(f, New List(Of String), False, path)
        Return f
    End Function
    Public Shared Function SFXProjectFilesFilter(ByRef list As List(Of String), ByRef settings As SettingsForm) As List(Of String)
        If settings.SFXProjectCheckBox.Checked Then Return list
        Dim sfx, filtered As New List(Of String)
        For Each t In My.Resources.SFXProjectFiles.Split({Chr(10), Chr(13)})
            If t.Length > 1 Then sfx.Add(t.ToLower)
        Next t
        Dim remove As Boolean
        For Each p As String In list
            remove = False
            For Each f As String In sfx
                If p.ToLower.EndsWith("\music\" & f) Then
                    remove = True
                    Exit For
                End If
            Next f
            If Not remove Then filtered.Add(p)
        Next p
        Return filtered
    End Function
    Public Shared Sub CompleteSFXProjectRemove(ByRef f As InstallForm)

        Dim menutrck As String = Installer.GetDestinationDirectory(f) & "Music\menutrck.wav"
        Dim imusic As String = Installer.GetDestinationDirectory(f) & "ImgData\imusic.DBF"

        Dim path() As String = {"Music\menutrck.wav", "ImgData\imusic.DBF"}
        Dim res()() As Byte = {My.Resources.menutrck, My.Resources.imusic}

        For i As Integer = 0 To UBound(path) Step 1
            IO.File.WriteAllBytes(Installer.GetDestinationDirectory(f) & path(i), res(i))
        Next i

        Dim remName() As String = {"amb", "battle", "dwrftrk", "elftrk", "heretrk", "humntrk", "undetrk", "ingame"}
        Dim remNum() As Integer = {12, 5, 4, 4, 4, 4, 4, 12}
        Dim removeList As New List(Of String)
        Dim p, s As String
        For j As Integer = 0 To UBound(remName) Step 1
            For i As Integer = remNum(j) To 99 Step 1
                For r As Integer = 0 To 1 Step 1
                    If r = 0 Then
                        s = ""
                    Else
                        If i < 10 Then
                            s = "0"
                        Else
                            Exit For
                        End If
                    End If
                    p = Installer.GetDestinationDirectory(f) & "Music\" & remName(j) & s & i & ".wav"
                    If IO.File.Exists(p) Then Kill(p)
                Next r
            Next i
        Next j
    End Sub

    Private Shared Sub GetFolderFiles(ByRef result As List(Of String), ByRef ig As List(Of String), _
                                      ByRef ignoreThisLevel As Boolean, ByRef folder As String)
        If Not IO.Directory.Exists(folder) Then Exit Sub
        If Not ignoreThisLevel Then
            For Each p As String In IO.Directory.GetFiles(folder)
                If Not IgnoreItem(p, ig) Then result.Add(p)
            Next p
        End If
        For Each p As String In IO.Directory.GetDirectories(folder)
            If Not IgnoreItem(p, ig) Then Call GetFolderFiles(result, ig, False, p)
        Next p
    End Sub

    Private Shared Function IgnoreList() As List(Of String)
        Dim res As New List(Of String)
        res.AddRange(My.Resources.IgnoreIOItem.ToUpper.Split(CChar("#")))
        Return res
    End Function
    Private Shared Function IgnoreItem(ByRef path As String, ByRef ig As List(Of String)) As Boolean
        Dim p As String = path.Substring(path.LastIndexOf("\") + 1)
        If ig.Contains(p.ToUpper) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

Public Class DownloadGLWrapper

    Private WithEvents downloader As New System.Net.WebClient With {.Proxy = Nothing}
    Private WithEvents InstallationWorker As System.ComponentModel.BackgroundWorker
    Private myProgressBar As ProgressBar
    Private downloadStep As Integer
    Private resumeWork As Boolean
    Private page As String
    Private downloadStepWeight() As Integer = New Integer() {45, 35, 20} 'sum=100

    Public Sub New(ByRef inst As System.ComponentModel.BackgroundWorker, Optional ByRef myPB As ProgressBar = Nothing)
        InstallationWorker = inst
        myProgressBar = myPB
    End Sub

    Private Structure ParseResult
        Dim fileName As String
        Dim link As System.Uri
    End Structure

    Public Function Download() As String()()
        'давать ссылку на верка, на случай, если не получится скачать
        downloadStep = 1
        Dim link() As ParseResult = GetLink(True)
        For i As Integer = 0 To UBound(link) Step 1
            If IsNothing(link(i)) Then Throw New Exception(My.Resources.noGLWrapperLinks)
        Next i
        Dim r(UBound(link))() As String
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType) Or _
                                                   CType(768, Net.SecurityProtocolType) Or _
                                                   CType(192, Net.SecurityProtocolType) Or _
                                                   CType(48, Net.SecurityProtocolType)
        For k As Integer = 0 To UBound(link) Step 1
            Dim p As String = IO.Path.GetTempPath & link(k).fileName
            downloadStep = 2 + k
            resumeWork = False
            downloader.DownloadFileAsync(link(k).link, p)
            Dim res As String
            Call WaitDownload()
            Dim destination As String = createDestinationFolder(p)
            If (New IO.FileInfo(p)).Extension.ToLower = ".exe" Then
                Dim sfx As New ProcessStartInfo
                sfx.FileName = p
                sfx.Arguments = "-o""" & destination & """ -y"
                Dim proc As Process = Process.Start(sfx)
                proc.WaitForExit()
                res = destination
            Else
                res = Extract(p, destination)
            End If
            If res = "" Then
                r = Nothing
                Exit For
            End If
            r(k) = {p, res}
            If IO.File.Exists(res & "\Imgs\IsoClouds.ff") Then IO.File.Delete(res & "\Imgs\IsoClouds.ff")
        Next k
        Return r
    End Function

    Private Function GetLink(ByRef fromGit As Boolean) As ParseResult()
        Dim link() As ParseResult
        If fromGit Then
            Dim f As String = "DisciplesGL.7z"
            link = New ParseResult() {New ParseResult With {.fileName = f, _
                                                            .link = New System.Uri(My.Resources.VerokGit & f)}, _
                                      New ParseResult With {.fileName = "Wrapper.zip", _
                                                            .link = New System.Uri(My.Resources.googleDriveCommon & My.Resources.googleDriveWrapper)}}
        Else
            page = ""
            resumeWork = False
            downloader.DownloadStringAsync(New System.Uri(My.Resources.VerokBlog))
            Call WaitDownload()
            Dim splited() As String = page.Split(CChar("<"))
            link = New ParseResult() {New ParseResult With {.fileName = "", .link = Nothing}, _
                                      New ParseResult With {.fileName = "", .link = Nothing}}
            Dim p, f As String
            For i As Integer = 0 To UBound(splited) Step 1
                If splited(i).Contains("Download") Then
                    For k As Integer = 0 To UBound(link) Step 1
                        Dim j As Integer = i + 2 * (k + 1)
                        If j <= UBound(splited) AndAlso splited(j).Contains(" href=") Then
                            p = splited(j).Substring(splited(j).IndexOf("=") + 1)
                            p = p.Replace("/open?id=", "/uc?id=")
                            f = p.Substring(p.IndexOf(">") + 1)
                            p = p.Remove(p.IndexOf(">")).Replace("""", "")
                            link(k).fileName = f
                            link(k).link = New System.Uri(p)
                            If k = 1 Then i = splited.Length
                        End If
                    Next k
                End If
            Next i
        End If
        Return link
    End Function
    Private Function createDestinationFolder(ByRef path As String) As String
        Dim destination As String = path & My.Resources.extractedTmpFolder
        If IO.Directory.Exists(destination) Then IO.Directory.Delete(destination, True)
        IO.Directory.CreateDirectory(destination)
        Return destination
    End Function
    Private Function Extract(ByRef archivePath As String, ByRef destination As String) As String
        Dim successful As Boolean = Decompressor.Extract(archivePath, destination)
        If successful Then
            Return destination
        Else
            Return ""
        End If
    End Function
    Private Sub WaitDownload()
        Do While Not resumeWork
            Threading.Thread.Sleep(100)
        Loop
    End Sub

    Private Sub ReportDownloadProgress(s As Object, e As System.Net.DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        If Not IsNothing(myProgressBar) Then
            Dim v As Integer = Common.ProgressPersantage(e.BytesReceived, e.TotalBytesToReceive)
            Dim p As Integer = 0
            For i As Integer = 0 To downloadStep - 2 Step 1
                p += downloadStepWeight(i)
            Next i
            p += CInt(0.01 * v * downloadStepWeight(downloadStep - 1))
            InstallationWorker.ReportProgress(Math.Min(p, 100), New AsynhInstall.ProgressText With {.destination = -1})
        End If
    End Sub

    Private Sub ReportDownloadFileComplited(s As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        resumeWork = True
    End Sub
    Private Sub ReportDownloadStrigComplited(s As Object, e As System.Net.DownloadStringCompletedEventArgs) Handles downloader.DownloadStringCompleted
        Try
            page = e.Result
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        resumeWork = True
    End Sub
    Private Sub ReportDownloadDataComplited(s As Object, e As System.Net.DownloadDataCompletedEventArgs) Handles downloader.DownloadDataCompleted
        resumeWork = True
    End Sub

End Class