Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

Namespace BingWallpaper
    Public Module Settings
        Private ReadOnly SettingsFile As String = Path.Combine(Directory, "settings.bw")
        Private _settings As Dictionary(Of String, String) = New Dictionary(Of String, String)()

        Private ReadOnly DefaultSettings As Dictionary(Of String, String) = New Dictionary(Of String, String) From {
            {"style", "Stretch"},
            {"cc", New RegionInfo(CultureInfo.CurrentCulture.LCID).Name},
            {"freq", "10"},
            {"applied", "false"}
        }

        Public Function Fetch(ByVal key As String) As String
            If _settings.Count = 0 Then Call Create()
            Return If(Not _settings.ContainsKey(key), Nothing, _settings(key))
        End Function

        <Obsolete>
        Public Sub [Set](ByVal key As String, ByVal value As String)
            CSharpImpl.__Assign(_settings(key), value)
        End Sub
        Public Sub [Set](ByVal key As String, ByVal value As Integer)
            [Set](key, value.ToString())
        End Sub
        Public Sub [Set](ByVal key As String, ByVal state As Boolean)
            [Set](key, state.ToString())
        End Sub
        Public Sub [Set](ByVal key As String, ByVal c As Control)
            [Set](key, c.Text)
        End Sub

        Private Sub Load(ByVal Optional forceRead As Boolean = False)
            Enumerable.ToList(File.ReadAllLines(SettingsFile)).ForEach(Sub(x)
                                                                           If x.Length = 0 Then Return
                                                                           Dim data As String() = x.Split("="c).Where(Function(y) Not Equals(y.Trim(), "")).ToArray()
                                                                           If data.Length < 2 Then
                                                                               If Not forceRead Then
                                                                                   Throw New Exception("Invalid settings")
                                                                               End If

                                                                               data = {data(0), Nothing}
                                                                           End If

                                                                           _settings(data(0)) = data(1)
                                                                       End Sub)
            If _settings.Count >= DefaultSettings.Count OrElse forceRead Then Return
            Throw New Exception("Insufficient settings")
        End Sub

        Public Sub Create(ByVal Optional force As Boolean = False, ByVal Optional dSettings As Dictionary(Of String, String) = Nothing)
            If force Xor dSettings IsNot Nothing Then
                Load(force)
                File.Delete(SettingsFile)
            End If

            If Not IO.Directory.Exists(Directory) Then
                IO.Directory.CreateDirectory(Directory)
            End If

            If Not File.Exists(SettingsFile) Then
                Enumerable.ToList(Of KeyValuePair(Of Global.System.[String], Global.System.[String]))(If(dSettings, DefaultSettings)).ForEach(Sub(x)
                                                                                                                                                  If _settings.ContainsKey(x.Key) Then
                                                                                                                                                      File.AppendAllText(SettingsFile, $"{x.Key}={If(_settings(x.Key), x.Value)}
")
                                                                                                                                                      Return
                                                                                                                                                  End If

                                                                                                                                                  File.AppendAllText(SettingsFile, $"{x.Key}={x.Value}
")
                                                                                                                                              End Sub)
            End If

            Call Load()
        End Sub

        Public Sub Save()
            File.Delete(SettingsFile)
            Create(True, _settings)
            Call Load()
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Module
End Namespace
