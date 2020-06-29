Imports SharpCompress.Archives

Public Class Decompressor

    Public Shared Function Extract(ByRef source As String, ByRef destination As String) As Boolean
        Dim eo As New SharpCompress.Common.ExtractionOptions With {.ExtractFullPath = True, .Overwrite = True}
        If SharpCompress.Archives.SevenZip.SevenZipArchive.IsSevenZipFile(source) Then
            Using archive As SharpCompress.Archives.SevenZip.SevenZipArchive = SharpCompress.Archives.SevenZip.SevenZipArchive.Open(source)
                For Each entry As SharpCompress.Archives.SevenZip.SevenZipArchiveEntry In archive.Entries
                    If Not entry.IsDirectory Then entry.WriteToDirectory(destination, eo)
                Next entry
            End Using
        ElseIf SharpCompress.Archives.Zip.ZipArchive.IsZipFile(source) Then
            Using archive As SharpCompress.Archives.Zip.ZipArchive = SharpCompress.Archives.Zip.ZipArchive.Open(source)
                For Each entry As SharpCompress.Archives.Zip.ZipArchiveEntry In archive.Entries
                    If Not entry.IsDirectory Then entry.WriteToDirectory(destination, eo)
                Next entry
            End Using
        ElseIf SharpCompress.Archives.Rar.RarArchive.IsRarFile(source) Then
            Using archive As SharpCompress.Archives.Rar.RarArchive = SharpCompress.Archives.Rar.RarArchive.Open(source)
                For Each entry As SharpCompress.Archives.Rar.RarArchiveEntry In archive.Entries
                    If Not entry.IsDirectory Then entry.WriteToDirectory(destination, eo)
                Next entry
            End Using
        ElseIf SharpCompress.Archives.GZip.GZipArchive.IsGZipFile(source) Then
            Using archive As SharpCompress.Archives.GZip.GZipArchive = SharpCompress.Archives.GZip.GZipArchive.Open(source)
                For Each entry As SharpCompress.Archives.GZip.GZipArchiveEntry In archive.Entries
                    If Not entry.IsDirectory Then entry.WriteToDirectory(destination, eo)
                Next entry
            End Using
        Else
            Return False
        End If
        Return True
    End Function

End Class
