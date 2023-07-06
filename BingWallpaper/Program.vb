Imports System
Imports System.Windows.Forms

Namespace BingWallpaper
    Friend Module Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Private Sub Main(ByVal args As String())
            If args.Length > 0 AndAlso Equals(args(0), "once") Then
                Log("Started headless instance")
                Run(If(args.Length > 1, args(1), Fetch("cc")))
                Return
            End If

            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Main())
        End Sub
    End Module
End Namespace
