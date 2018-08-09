Imports Microsoft.VisualBasic.FileIO
Imports System.Environment

Public Module Tools
    Public Function CompactString(ByVal input As String, ByVal width As Integer, ByVal font As Font) As String
        Dim Result As String = String.Copy(input)

        ' Shorten the "input" string
        TextRenderer.MeasureText(Result, font, New Size(width, 0), TextFormatFlags.PathEllipsis Or TextFormatFlags.ModifyString)

        ' Set the tooltip to full folder path
        FrmMain.TtMain.SetToolTip(FrmMain.LblMainSource, My.Settings.SelectedFolders(0))
        FrmMain.TtMain.SetToolTip(FrmMain.LblMainTarget, My.Settings.SelectedFolders(1))

        Return Result
    End Function

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.FolderBrowserDialog.set_Description(System.String)")>
    Public Sub OpenFbd(ByVal index As Short, ByVal folder As String, ByVal label As Label)

        ' Ensure the "index" is in range
        If index < 0 Or index > 1 Then
            Throw New ArgumentOutOfRangeException("index")
        End If

        ' Ensure the "folder" is valid
        If Not FileSystem.DirectoryExists(folder) Then
            ' Fallback to desktop
            folder = SpecialFolder.Desktop
        End If

        ' Ensure a "label" is given
        If label Is Nothing Then
            Throw New ArgumentNullException("label")
        End If

        Dim Fbd As New FolderBrowserDialog

        Try
            ' Start from desktop
            Fbd.RootFolder = SpecialFolder.Desktop

            ' Navigate to last used folder
            Fbd.SelectedPath = folder

            ' Make only the target folder creatable
            If index = 0 Then
                Fbd.ShowNewFolderButton = False
            Else
                Fbd.ShowNewFolderButton = True
            End If

            ' Show the "folder browser" dialog
            Fbd.Description = "Select directory:"
            Fbd.ShowDialog()

            ' Ensure there is a path selected
            If Fbd.SelectedPath = Nothing Then
                If My.Settings.SelectedFolders(index) <> folder Then
                    Fbd.SelectedPath = My.Settings.SelectedFolders(index)
                Else
                    Fbd.SelectedPath = folder
                End If
            End If

            ' Save the folder in settings
            My.Settings.SelectedFolders(index) = Fbd.SelectedPath

            ' Update UI
            label.Text = Fbd.SelectedPath
        Finally

            ' Free resources
            Fbd.Dispose()
        End Try
    End Sub
End Module
