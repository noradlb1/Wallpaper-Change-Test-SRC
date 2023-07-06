Imports System

Namespace VideoWallpaper
    Partial Class WallpaperForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New ComponentModel.Container()
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(VideoWallpaper.WallpaperForm))
            notifyIcon = New Windows.Forms.NotifyIcon(components)
            notifyIconContextMenu = New Windows.Forms.ContextMenuStrip(components)
            menuItem_ChangeVideo = New Windows.Forms.ToolStripMenuItem()
            toolStripSeparator1 = New Windows.Forms.ToolStripSeparator()
            menuItem_AutoStartUp = New Windows.Forms.ToolStripMenuItem()
            menuItem_CloseWindow = New Windows.Forms.ToolStripMenuItem()
            mediaPlayer = New AxWMPLib.AxWindowsMediaPlayer()
            notifyIconContextMenu.SuspendLayout()
            CType(mediaPlayer, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' notifyIcon
            ' 
            notifyIcon.ContextMenuStrip = notifyIconContextMenu
            notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), Drawing.Icon)
            notifyIcon.Text = "VideoWallpaper"
            notifyIcon.Visible = True
            AddHandler notifyIcon.MouseClick, New Windows.Forms.MouseEventHandler(AddressOf NotifyIcon_MouseClick)
            ' 
            ' notifyIconContextMenu
            ' 
            notifyIconContextMenu.ImageScalingSize = New Drawing.Size(20, 20)
            notifyIconContextMenu.Items.AddRange(New Windows.Forms.ToolStripItem() {menuItem_ChangeVideo, toolStripSeparator1, menuItem_AutoStartUp, menuItem_CloseWindow})
            notifyIconContextMenu.Name = "contextMenuStrip1"
            notifyIconContextMenu.Size = New Drawing.Size(139, 82)
            AddHandler notifyIconContextMenu.Opening, New ComponentModel.CancelEventHandler(AddressOf NotifyIconContextMenu_Opening)
            ' 
            ' menuItem_ChangeVideo
            ' 
            menuItem_ChangeVideo.Name = "menuItem_ChangeVideo"
            menuItem_ChangeVideo.Size = New Drawing.Size(138, 24)
            menuItem_ChangeVideo.Text = "更换视频"
            AddHandler menuItem_ChangeVideo.Click, New EventHandler(AddressOf MenuItem_ChangeVideo_Click)
            ' 
            ' toolStripSeparator1
            ' 
            toolStripSeparator1.Name = "toolStripSeparator1"
            toolStripSeparator1.Size = New Drawing.Size(135, 6)
            ' 
            ' menuItem_AutoStartUp
            ' 
            menuItem_AutoStartUp.Name = "menuItem_AutoStartUp"
            menuItem_AutoStartUp.Size = New Drawing.Size(138, 24)
            menuItem_AutoStartUp.Text = "开机自启"
            AddHandler menuItem_AutoStartUp.Click, New EventHandler(AddressOf MenuItem_AutoStartUp_Click)
            ' 
            ' menuItem_CloseWindow
            ' 
            menuItem_CloseWindow.Name = "menuItem_CloseWindow"
            menuItem_CloseWindow.Size = New Drawing.Size(138, 24)
            menuItem_CloseWindow.Text = "退出程序"
            AddHandler menuItem_CloseWindow.Click, New EventHandler(AddressOf MenuItem_CloseWindow_Click)
            ' 
            ' mediaPlayer
            ' 
            mediaPlayer.Dock = Windows.Forms.DockStyle.Fill
            mediaPlayer.Enabled = True
            mediaPlayer.Location = New Drawing.Point(0, 0)
            mediaPlayer.Name = "mediaPlayer"
            mediaPlayer.OcxState = CType(resources.GetObject("mediaPlayer.OcxState"), Windows.Forms.AxHost.State)
            mediaPlayer.Size = New Drawing.Size(500, 300)
            mediaPlayer.TabIndex = 0
            ' 
            ' WallpaperForm
            ' 
            AutoScaleDimensions = New Drawing.SizeF(8.0F, 15.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(500, 300)
            Controls.Add(mediaPlayer)
            FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Name = "WallpaperForm"
            Text = "WallpaperWindow"
            AddHandler Load, New EventHandler(AddressOf WallpaperWindow_Load)
            notifyIconContextMenu.ResumeLayout(False)
            CType(mediaPlayer, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)

        End Sub

#End Region

        Private mediaPlayer As AxWMPLib.AxWindowsMediaPlayer
        Private notifyIcon As Windows.Forms.NotifyIcon
        Private notifyIconContextMenu As Windows.Forms.ContextMenuStrip
        Private menuItem_CloseWindow As Windows.Forms.ToolStripMenuItem
        Private menuItem_ChangeVideo As Windows.Forms.ToolStripMenuItem
        Private menuItem_AutoStartUp As Windows.Forms.ToolStripMenuItem
        Private toolStripSeparator1 As Windows.Forms.ToolStripSeparator
    End Class
End Namespace
