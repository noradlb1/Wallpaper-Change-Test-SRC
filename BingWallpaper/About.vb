Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Namespace BingWallpaper
    Public Partial Class About
        Inherits Form
        Private Shared Sub Open(ByVal url As String)
            Process.Start(url)
        End Sub

        Public Sub New()
            InitializeComponent()
            If Not File.Exists(LogFile) Then ClearLogs.Enabled = False
        End Sub

        Private Sub Webpage_Click(ByVal sender As Object, ByVal e As EventArgs)
            Open("https://binghomepage.github.io/BingWallpaper.Windows/")
        End Sub

        Private Sub SourceCode_Click(ByVal sender As Object, ByVal e As EventArgs)
            Open("https://github.com/BingHomepage/BingWallpaper.Windows/")
        End Sub

        Private Sub ReportIssue_Click(ByVal sender As Object, ByVal e As EventArgs)
            Open("https://github.com/BingHomepage/BingWallpaper.Windows/issues")
        End Sub

        Private Sub OpenLogs_Click(ByVal sender As Object, ByVal e As EventArgs)
            If File.Exists(LogFile) Then Open(LogFile)
        End Sub

        Private Sub Website_Click(ByVal sender As Object, ByVal e As EventArgs)
            Open("https://muzzammil.xyz?ref=BW")
        End Sub

        Private Sub ClearLogs_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs)
            If Not File.Exists(LogFile) Then Return
            File.Delete(LogFile)
            MessageBox.Show("Logs cleared", "Bing Wallpaper", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearLogs.Enabled = False
        End Sub
    End Class
End Namespace
