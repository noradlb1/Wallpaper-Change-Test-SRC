Imports Microsoft.Win32
Imports System
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Text
Imports Gremlin.Net.Process.Traversal

Namespace VideoWallpaper
    Public Class VideoWallpaper
        Private Const VIDEO_TXT As String = "./video.txt"
        Private Shared restart As Boolean = False
        Private Shared mutex As Mutex
		Private Shared underscore As StringBuilder

		''' <summary>
		''' 开机自启快捷方式路径
		''' </summary>
		Private Shared ReadOnly AutoStartUpLnkPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "VideoWallpaperAutoStartUp.lnk")

		''' <summary>
		''' 开机自启
		''' </summary>
		Public Shared Property AutoStartUp() As Boolean
			Get
				Return File.Exists(AutoStartUpLnkPath)
			End Get
			Set(ByVal value As Boolean)
				If value Then
					Dim shell = New IWshRuntimeLibrary.WshShell()
					Dim shortcut = CType(shell.CreateShortcut(AutoStartUpLnkPath), IWshRuntimeLibrary.WshShortcut)
					shortcut.TargetPath = Application.ExecutablePath
					shortcut.Description = "VideoWallpaper开机启动"
					shortcut.WorkingDirectory = Environment.CurrentDirectory
					shortcut.Save()
				Else
					If File.Exists(AutoStartUpLnkPath) Then
						File.Delete(AutoStartUpLnkPath)
					End If
				End If
			End Set
		End Property

		<STAThread>
		Public Shared Sub Main()
			Dim hProgman As IntPtr = IntPtr.Zero
			Dim hWorkerW As IntPtr = IntPtr.Zero
			Try
				Dim flag As Boolean
				mutex = New Mutex(True, Application.ProductName, flag)
				If Not flag Then
					Throw New Exception("程序已启动")
				End If

				hProgman = DllImports.FindWindow("Progman", Nothing)
				'INSTANT VB TASK: Underscore 'discards' are not converted by Instant VB:
				'ORIGINAL LINE: DllImports.SendMessageTimeout(hProgman, &H52c, 0, 0, 0, 100, out _);
				DllImports.SendMessageTimeout(hProgman, &H52C, 0, 0, 0, 100, underscore)

				hWorkerW = IntPtr.Zero
				DllImports.EnumWindows(Function(hwnd, lParam)
										   Dim hDefView As IntPtr = DllImports.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", Nothing)
										   If hDefView = IntPtr.Zero Then
											   Return True
										   Else
											   hWorkerW = DllImports.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", Nothing)
											   DllImports.ShowWindow(hWorkerW, 5)
											   Return False
										   End If
									   End Function, 0)

				Dim wf As New WallpaperForm()
				DllImports.SetParent(wf.Handle, hWorkerW)

				AddHandler SystemEvents.SessionSwitch, Sub(s, e)
														   '防止屏幕解锁后花屏
														   If e.Reason = SessionSwitchReason.SessionUnlock Then
															   wf.Reload()
														   End If
													   End Sub

				Dim psm As New PowerStatusMonitor(Function(context, type, setting)
													  '防止系统睡眠到唤醒时黑屏
													  If type = PowerStatusMonitor.PBT_APMRESUMESUSPEND Then
														  wf.Reload()
													  End If
													  Return 0
												  End Function)
				psm.Register()

				Dim cts As New CancellationTokenSource()
				Dim keepWallpaperTask As Task = KeepWallpaper(hProgman, cts)

				Application.Run(wf)

				DllImports.ShowWindow(hWorkerW, 0)
				psm.UnRegister()
				cts.Cancel()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				mutex.Dispose()
				If restart Then
					Application.Restart()
				End If
			End Try
		End Sub
		Public Shared Sub SaveVideoUrl(ByVal videoUrl As String)
            File.WriteAllText(VIDEO_TXT, videoUrl)
        End Sub

        Public Shared Function GetSavedVideoUrl() As String
            Return If(File.Exists(VIDEO_TXT), File.ReadAllText(VIDEO_TXT), Nothing)
        End Function

        Private Shared Async Function KeepWallpaper(ByVal hProgman As IntPtr, ByVal cts As CancellationTokenSource) As Task
            Await Task.Run(Async Function()

                               While Not cts.IsCancellationRequested
                                   Dim hProgmanCurrent As IntPtr = DllImports.FindWindow("Progman", Nothing)

                                   If hProgmanCurrent <> IntPtr.Zero AndAlso hProgmanCurrent <> hProgman Then
                                       restart = True
                                       Application.[Exit]()
                                       Exit While
                                   Else
                                       Await Task.Delay(200)
                                   End If
                               End While
                           End Function, cts.Token)
        End Function
    End Class
End Namespace
