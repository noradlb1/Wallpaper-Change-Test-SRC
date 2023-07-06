Imports System
Imports System.Reflection
Imports System.Windows.Forms

Namespace VideoWallpaper
    Partial Public Class WallpaperForm
        Inherits Form

        Public Property VideoUrl As String
            Get
                Return mediaPlayer.URL
            End Get
            Set(ByVal value As String)
                mediaPlayer.URL = value
                mediaPlayer.stretchToFit = True
                mediaPlayer.settings.mute = True
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub WallpaperWindow_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim videoUrl As String = Nothing

            If CSharpImpl.__Assign(videoUrl, TryCast(VideoWallpaper.GetSavedVideoUrl(), String)) IsNot Nothing Then
                videoUrl = videoUrl
            Else

                If Not SelectVideo() Then
                    Application.[Exit]()
                    Return
                End If
            End If

            Top = 0
            Left = 0
            Width = Screen.PrimaryScreen.Bounds.Width
            Height = Screen.PrimaryScreen.Bounds.Height
            mediaPlayer.uiMode = "none"
            mediaPlayer.settings.setMode("loop", True)
        End Sub

        Private Function SelectVideo() As Boolean
            Dim ofd As OpenFileDialog = New OpenFileDialog With {
                .Title = "选择视频文件"
            }

            If ofd.ShowDialog() = DialogResult.OK Then
                VideoUrl = ofd.FileName
                VideoWallpaper.SaveVideoUrl(VideoUrl)
                Return True
            End If

            Return False
        End Function

        Public Sub Reload()
            Invoke(New Action(Sub()
                                  VideoUrl = VideoUrl
                                  mediaPlayer.Ctlcontrols.play()
                              End Sub))
        End Sub

        Private Sub NotifyIcon_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                Dim t = notifyIcon.[GetType]()
                t.GetMethod("ShowContextMenu", BindingFlags.NonPublic Or BindingFlags.Instance).Invoke(notifyIcon, Nothing)
            End If
        End Sub

        Private Sub NotifyIconContextMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            menuItem_AutoStartUp.Checked = VideoWallpaper.AutoStartUp
        End Sub

        Private Sub MenuItem_AutoStartUp_Click(ByVal sender As Object, ByVal e As EventArgs)
            VideoWallpaper.AutoStartUp = Not VideoWallpaper.AutoStartUp
        End Sub

        Private Sub MenuItem_ChangeVideo_Click(ByVal sender As Object, ByVal e As EventArgs)
            SelectVideo()
        End Sub

        Private Sub MenuItem_CloseWindow_Click(ByVal sender As Object, ByVal e As EventArgs)
            Application.[Exit]()
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
