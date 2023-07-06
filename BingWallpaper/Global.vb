Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

Namespace BingWallpaper
    Public Module [Global]
        Public ReadOnly Property Directory As String
            Get
                Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bing Wallpaper")
            End Get
        End Property

        Public ReadOnly Property LogFile As String
            Get
                Return Path.Combine(Directory, "bw.log")
            End Get
        End Property

        Public Property Image As String

        Public ReadOnly Property WallpaperStyle As Dictionary(Of String, String)
            Get
                Return New Dictionary(Of String, String) From {
            {"Fill", "10"},
                    {"Fit", "6"},
                    {"Stretch", "2"},
                    {"Tile", "0"},
                    {"Center", "0"},
                    {"Span", "22"}
        }
            End Get
        End Property

        Public ReadOnly Property WallpaperStyleList As String()
            Get
                Return WallpaperStyle.Keys.ToArray()
            End Get
        End Property

        Public Sub Log(ByVal evt As String)
            File.AppendAllText(LogFile, $"{Date.Now:G} - {evt}
")
        End Sub
    End Module
End Namespace
