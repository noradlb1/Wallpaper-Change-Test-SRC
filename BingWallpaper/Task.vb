Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Win32

Namespace BingWallpaper
    Public Module Task
        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Private Function SystemParametersInfo(ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
        End Function

        Private Function Process(ByVal cmd As String, ByVal args As String) As Integer
            Dim taskId As Integer
            Using lProcess = New Process With {
                .StartInfo = New ProcessStartInfo With {
                    .FileName = cmd,
                    .Arguments = args,
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }
            }
                lProcess.Start()
                taskId = lProcess.Id
            End Using
            Log($"Started process (PID: {taskId}) {cmd} {args}")
            Return taskId
        End Function

        Private Sub TaskSch(ByVal args As String, ByVal action As Action)
            Process("taskkill", $"/f /pid {Process("schtasks", args)}")
            action()
        End Sub

        Public Sub Create(ByVal freq As String)
            TaskSch($"/create /tn BingWallpaper /tr ""{Application.ExecutablePath} once"" /sc MINUTE /mo {freq} /st 04:00", Sub()
                                                                                                                                Call Run()
                                                                                                                                [Set]("applied", True)
                                                                                                                                Save()
                                                                                                                            End Sub)
        End Sub

        Public Sub Delete()
            TaskSch("/delete /tn BingWallpaper /f", Sub()
                                                        [Set]("applied", False)
                                                        Save()
                                                    End Sub)
        End Sub

        Public Sub Run(ByVal Optional cc As String = Nothing)
            If Equals(Image, Nothing) Then
                Dim homepage = New BingHomepage(If(cc, Fetch("cc")))
                Image = Path.Combine(Directory, $"image-{New Random().Next()}.bw")
                homepage.GetImage(Image)
            End If

            Using registryKey = If(Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True), CSharpImpl.__Throw(Of RegistryKey)(New Exception("Unable to find registry key.")))
                registryKey.SetValue("WallpaperStyle", WallpaperStyle(Fetch("style")))
                registryKey.SetValue("TileWallpaper", If(Equals(Fetch("style"), "Tile"), "1", "0"))
            End Using

            SystemParametersInfo(20, 0, Image, &H01 Or &H02)

            Enumerable.ToList(New DirectoryInfo(Directory).GetFiles("image-*.bw", SearchOption.TopDirectoryOnly)).ForEach(Sub(file)
                                                                                                                              Try
                                                                                                                                  IO.File.Delete(file.FullName)
                                                                                                                                  Log($"Deleted {file.Name}")
                                                                                                                              Catch
                                                                                                                                  ' ignored
                                                                                                                                  Log($"Unable to delete {file.Name}")
                                                                                                                              End Try
                                                                                                                          End Sub)
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal throw statements")>
            Shared Function __Throw(Of T)(ByVal e As Exception) As T
                Throw e
            End Function
        End Class
    End Module
End Namespace
