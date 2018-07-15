Imports NReco.VideoConverter
Imports System.Environment
Imports System.IO

<Assembly: CLSCompliant(True)>

Public Class FrmMain
    Private initialized As Boolean

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.Form.set_Text(System.String)")>
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set version number in title
        Text = My.Application.Info.Title + " " + My.Application.Info.Version.ToString

        ' Initialize the source and target folders
        If My.Settings.SelectedFolders Is Nothing Then
            My.Settings.SelectedFolders = New Specialized.StringCollection From {
                GetFolderPath(SpecialFolder.Desktop),
                GetFolderPath(SpecialFolder.Desktop)
            }
        End If

        ' Load "source" and "target" settings
        LblMainSource.Text = CompactString(My.Settings.SelectedFolders(0), Width - 125, LblMainSource.Font)
        LblMainTarget.Text = CompactString(My.Settings.SelectedFolders(1), Width - 125, LblMainTarget.Font)

        ' Load "frame" setting
        NudMainFrame.Value = My.Settings.Frame

        ' Load "overwrite" setting
        ChkMainOverwrite.Checked = My.Settings.Overwrite

        initialized = True
    End Sub

    Private Sub BtnMainSource_Click(sender As Object, e As EventArgs) Handles BtnMainSource.Click

        ' Select the source folder
        OpenFbd(0, My.Settings.SelectedFolders(0), LblMainSource)
        LblMainSource.Text = CompactString(My.Settings.SelectedFolders(0), Width - 125, LblMainSource.Font)
    End Sub

    Private Sub BtnMainTarget_Click(sender As Object, e As EventArgs) Handles BtnMainTarget.Click

        ' Select the target folder
        OpenFbd(1, My.Settings.SelectedFolders(1), LblMainTarget)
        LblMainTarget.Text = CompactString(My.Settings.SelectedFolders(1), Width - 125, LblMainTarget.Font)
    End Sub

    Private Sub NudMainFrame_ValueChanged(sender As Object, e As EventArgs) Handles NudMainFrame.ValueChanged

        ' Update the "frame" setting
        If initialized Then
            My.Settings.Frame = NudMainFrame.Value
        End If
    End Sub

    Private Sub NudMainFrame_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NudMainFrame.KeyPress

        ' Update the "frame" setting
        Call NudMainFrame_ValueChanged(sender, e)
    End Sub

    Private Sub ChkMainOVerwrite_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMainOverwrite.CheckedChanged

        ' Update the "overwrite" setting
        My.Settings.Overwrite = ChkMainOverwrite.Checked
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Sub BtnMainStart_Click(sender As Object, e As EventArgs) Handles BtnMainStart.Click

        ' Start extraction if source and target folder exists
        If My.Computer.FileSystem.DirectoryExists(My.Settings.SelectedFolders(0)) And My.Computer.FileSystem.DirectoryExists(My.Settings.SelectedFolders(1)) Then

            ' Lock the UI
            BtnMainSource.Enabled = False
            BtnMainTarget.Enabled = False
            NudMainFrame.Enabled = False
            ChkMainOverwrite.Enabled = False
            BtnMainStart.Enabled = False
            BtnMainCancel.Enabled = True

            BgwMain.RunWorkerAsync()
        Else
            MessageBox.Show("Source or target folder does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End If
    End Sub

    Private Sub BtnMainCancel_Click(sender As Object, e As EventArgs) Handles BtnMainCancel.Click

        ' Interrupt extraction
        BgwMain.CancelAsync()
    End Sub

    Private Shared Sub ExtractCovers(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim Files = My.Computer.FileSystem.GetFiles(My.Settings.SelectedFolders(0), FileIO.SearchOption.SearchTopLevelOnly, "*.mp4")

        ' Iterate over every .mp4 file in the source folder
        For Each sourceFile As String In Files

            ' Detect a cancel request
            If worker.CancellationPending Then
                e.Cancel = True
            Else
                Dim targetFile = Replace(My.Settings.SelectedFolders(1) & "\" & Path.GetFileName(Path.ChangeExtension(sourceFile, ".jpg")), "'", "-")
                Dim ffmpeg As New FFMpegConverter

                ' Update the progressbar
                worker.ReportProgress(Math.Round(Files.IndexOf(sourceFile) / Files.Count * 100))

                ' Extract the frame
                If My.Settings.Overwrite Or Not File.Exists(targetFile) Then
                    ffmpeg.GetVideoThumbnail(sourceFile, targetFile, My.Settings.Frame)
                End If
            End If
        Next
    End Sub

    Private Sub BgwMain_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgwMain.DoWork
        Dim Worker As ComponentModel.BackgroundWorker = CType(sender, ComponentModel.BackgroundWorker)

        ' Extract frames
        ExtractCovers(Worker, e)
    End Sub

    Private Sub BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BgwMain.ProgressChanged

        ' Update the progressbar
        PgbMain.Value = e.ProgressPercentage
    End Sub

    Private Sub BgwMain_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgwMain.RunWorkerCompleted

        ' Unlock the UI
        BtnMainSource.Enabled = True
        BtnMainTarget.Enabled = True
        NudMainFrame.Enabled = True
        ChkMainOverwrite.Enabled = True
        BtnMainStart.Enabled = True
        BtnMainCancel.Enabled = False

        ' Reset the progressbar
        PgbMain.Value = 0
    End Sub
End Class
