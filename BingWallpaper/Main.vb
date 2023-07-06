Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

Namespace BingWallpaper
    Public Partial Class Main
        Inherits Form
        Private Shared _freqUpdate As Boolean

        <Obsolete>
        Private Sub ToggleApply()
            CSharpImpl.__Assign(ApplyButton.Text, If(Equals(Fetch("applied"), "true"), "Re-apply", "Apply"))
        End Sub

        Private Sub LoadImage(ByVal cc As String)
            Loading.Visible = True
            Dim homepage As BingHomepage = New BingHomepage(cc)
            Image = Path.Combine(Directory, $"image-{New Random().Next()}.bw")
            imagePreview.Image = homepage.GetImage(Image)
            InfoLabel.Text = homepage.GetCopyright
            Loading.Visible = False
            Log($"Load image for {cc}")
        End Sub

        Public Sub New()
            InitializeComponent()
            Try
                Settings.Create()
            Catch exp As Exception
                Dim result = MessageBox.Show("Some settings might be corrupt. Attempt fixing them?", "Bing Wallpaper", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                If result <> DialogResult.Yes Then Throw New Exception($"Unable to fix corrupt settings.
{exp.Message}")
                Settings.Create(True)
            End Try
        End Sub

        Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs)
            Log("Started GUI instance")
            Dim freq = Integer.Parse(Fetch("freq")) Mod 1440
            If Not WallpaperStyleList.Contains(Fetch("style")) Then
                [Set]("style", "Stretch")
            End If

            FitBox.SelectedItem = Fetch("style")
            CCBox.Text = Fetch("cc")
            FreqText.Text = freq.ToString()
            FreqTrack.Value = freq
            ToggleApply()

            LoadImage(Fetch("cc"))
        End Sub

        Private Sub CCBox_TextUpdate(ByVal sender As Object, ByVal e As EventArgs)
            CCBox_KeyUp(sender, New KeyEventArgs(Keys.None))
        End Sub

        Private Sub CCBox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
            Dim cc As String = CCBox.Text.ToLower()
            If Equals(cc, "default") Then
                cc = New RegionInfo(CultureInfo.CurrentCulture.LCID).Name
            Else
                Dim len = cc.Length
                If len < 2 OrElse len > 2 OrElse e.KeyCode = Keys.Back Then Return
            End If

            LoadImage(cc)
            [Set]("cc", cc.ToUpper())
        End Sub

        <Obsolete>
        Private Sub FreqText_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If _freqUpdate Then Return
            Dim value As Integer = Nothing
            If Not Integer.TryParse(FreqText.Text, value) Then Return
            If CSharpImpl.__Assign(value, 1440) < 1 Then
                value = 1
                FreqText.Text = value.ToString()
            End If

            FreqTrack.Maximum = 30
            FreqTrack.TickFrequency = 1
            If value > 30 Then
                FreqTrack.Maximum = value
                FreqTrack.TickFrequency = Integer.Parse(Math.Round(value * 0.1).ToString())
            End If

            FreqTrack.Value = value
            [Set]("freq", value)
        End Sub

        Private Sub FreqTrack_Scroll(ByVal sender As Object, ByVal e As EventArgs)
            _freqUpdate = True
            FreqText.Text = FreqTrack.Value.ToString()
            [Set]("freq", FreqText)
            _freqUpdate = False
        End Sub

        Private Sub FitBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Not WallpaperStyleList.Contains(FitBox.Text) Then Return
            [Set]("style", FitBox)
        End Sub

        Private Sub ApplyButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Task.Create(Fetch("freq"))
            Run()
            [Set]("applied", True)
            Save()
            ToggleApply()
            MessageBox.Show("Wallpaper applied and task successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            LoadImage(Fetch("cc"))
        End Sub

        Private Sub ResetTaskButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Delete()
            [Set]("applied", False)
            Save()
            ToggleApply()
            MessageBox.Show("Task successfully removed.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub ApplyOnce_Click(ByVal sender As Object, ByVal e As EventArgs)
            Run()
        End Sub

        Private Sub AboutButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Call New About().Show()
        End Sub

        Private Sub MMK_Click(ByVal sender As Object, ByVal e As EventArgs)
            Process.Start("https://muzzammil.xyz?ref=BW")
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
