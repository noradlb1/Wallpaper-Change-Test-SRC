Imports System

Namespace BingWallpaper
    Partial Class About
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
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(About))
            label1 = New Windows.Forms.Label()
            label2 = New Windows.Forms.Label()
            label3 = New Windows.Forms.Label()
            Webpage = New Windows.Forms.Button()
            Website = New Windows.Forms.Button()
            SourceCode = New Windows.Forms.Button()
            ClearLogs = New Windows.Forms.LinkLabel()
            OpenLogs = New Windows.Forms.Button()
            ReportIssue = New Windows.Forms.Button()
            label4 = New Windows.Forms.Label()
            pictureBox1 = New Windows.Forms.PictureBox()
            label5 = New Windows.Forms.Label()
            label6 = New Windows.Forms.Label()
            CType(pictureBox1, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Font = New Drawing.Font("Segoe UI", 15.75F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, 0)
            label1.Location = New Drawing.Point(268, 52)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(163, 30)
            label1.TabIndex = 1
            label1.Text = "Bing Wallpaper"
            ' 
            ' label2
            ' 
            label2.AutoSize = True
            label2.Font = New Drawing.Font("Segoe UI", 10.0F)
            label2.Location = New Drawing.Point(429, 62)
            label2.Name = "label2"
            label2.Size = New Drawing.Size(35, 19)
            label2.TabIndex = 2
            label2.Text = "v2.0"
            ' 
            ' label3
            ' 
            label3.AutoSize = True
            label3.Location = New Drawing.Point(280, 82)
            label3.Name = "label3"
            label3.Size = New Drawing.Size(228, 13)
            label3.TabIndex = 3
            label3.Text = "Applies Bing hompage image as wallpaper."
            ' 
            ' Webpage
            ' 
            Webpage.Location = New Drawing.Point(272, 155)
            Webpage.Name = "Webpage"
            Webpage.Size = New Drawing.Size(118, 23)
            Webpage.TabIndex = 4
            Webpage.Text = "Webpage"
            Webpage.UseVisualStyleBackColor = True
            AddHandler Webpage.Click, New EventHandler(AddressOf Webpage_Click)
            ' 
            ' Website
            ' 
            Website.Location = New Drawing.Point(272, 214)
            Website.Name = "Website"
            Website.Size = New Drawing.Size(242, 23)
            Website.TabIndex = 6
            Website.Text = "Developer's website"
            Website.UseVisualStyleBackColor = True
            AddHandler Website.Click, New EventHandler(AddressOf Website_Click)
            ' 
            ' SourceCode
            ' 
            SourceCode.Location = New Drawing.Point(396, 155)
            SourceCode.Name = "SourceCode"
            SourceCode.Size = New Drawing.Size(118, 23)
            SourceCode.TabIndex = 7
            SourceCode.Text = "Source code"
            SourceCode.UseVisualStyleBackColor = True
            AddHandler SourceCode.Click, New EventHandler(AddressOf SourceCode_Click)
            ' 
            ' ClearLogs
            ' 
            ClearLogs.AutoSize = True
            ClearLogs.Location = New Drawing.Point(454, 249)
            ClearLogs.Name = "ClearLogs"
            ClearLogs.Size = New Drawing.Size(58, 13)
            ClearLogs.TabIndex = 8
            ClearLogs.TabStop = True
            ClearLogs.Text = "Clear logs"
            AddHandler ClearLogs.LinkClicked, New Windows.Forms.LinkLabelLinkClickedEventHandler(AddressOf ClearLogs_LinkClicked)
            ' 
            ' OpenLogs
            ' 
            OpenLogs.Location = New Drawing.Point(396, 185)
            OpenLogs.Name = "OpenLogs"
            OpenLogs.Size = New Drawing.Size(118, 23)
            OpenLogs.TabIndex = 10
            OpenLogs.Text = "Open logs"
            OpenLogs.UseVisualStyleBackColor = True
            AddHandler OpenLogs.Click, New EventHandler(AddressOf OpenLogs_Click)
            ' 
            ' ReportIssue
            ' 
            ReportIssue.Location = New Drawing.Point(272, 185)
            ReportIssue.Name = "ReportIssue"
            ReportIssue.Size = New Drawing.Size(118, 23)
            ReportIssue.TabIndex = 9
            ReportIssue.Text = "Report an issue"
            ReportIssue.UseVisualStyleBackColor = True
            AddHandler ReportIssue.Click, New EventHandler(AddressOf ReportIssue_Click)
            ' 
            ' label4
            ' 
            label4.AutoSize = True
            label4.Font = New Drawing.Font("Segoe UI Emoji", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            label4.Location = New Drawing.Point(404, 98)
            label4.Name = "label4"
            label4.Size = New Drawing.Size(104, 15)
            label4.TabIndex = 11
            label4.Text = "{ } with ♥ by MMK"
            ' 
            ' pictureBox1
            ' 
            pictureBox1.Image = Global.BingWallpaper.Properties.Resources.Bing_Wallpaper
            pictureBox1.Location = New Drawing.Point(12, 12)
            pictureBox1.Name = "pictureBox1"
            pictureBox1.Size = New Drawing.Size(250, 250)
            pictureBox1.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom
            pictureBox1.TabIndex = 0
            pictureBox1.TabStop = False
            ' 
            ' label5
            ' 
            label5.AutoSize = True
            label5.Font = New Drawing.Font("Segoe UI Emoji", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            label5.Location = New Drawing.Point(270, 247)
            label5.Name = "label5"
            label5.Size = New Drawing.Size(170, 15)
            label5.TabIndex = 12
            label5.Text = "© Mohammad Muzammil Khan"
            ' 
            ' label6
            ' 
            label6.AutoSize = True
            label6.Font = New Drawing.Font("Segoe UI", 7.5F)
            label6.Location = New Drawing.Point(462, 66)
            label6.Name = "label6"
            label6.Size = New Drawing.Size(52, 12)
            label6.TabIndex = 13
            label6.Text = "Build: 2109"
            ' 
            ' About
            ' 
            AutoScaleDimensions = New Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            BackColor = Drawing.Color.FromArgb(241, 243, 247)
            ClientSize = New Drawing.Size(526, 276)
            Controls.Add(label6)
            Controls.Add(label5)
            Controls.Add(label4)
            Controls.Add(OpenLogs)
            Controls.Add(ReportIssue)
            Controls.Add(ClearLogs)
            Controls.Add(SourceCode)
            Controls.Add(Website)
            Controls.Add(Webpage)
            Controls.Add(label3)
            Controls.Add(label1)
            Controls.Add(label2)
            Controls.Add(pictureBox1)
            Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Icon = CType(resources.GetObject("$this.Icon"), Drawing.Icon)
            MaximizeBox = False
            MinimizeBox = False
            Name = "About"
            StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Text = "About"
            CType(pictureBox1, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private pictureBox1 As Windows.Forms.PictureBox
        Private label1 As Windows.Forms.Label
        Private label2 As Windows.Forms.Label
        Private label3 As Windows.Forms.Label
        Private Webpage As Windows.Forms.Button
        Private Website As Windows.Forms.Button
        Private SourceCode As Windows.Forms.Button
        Private ClearLogs As Windows.Forms.LinkLabel
        Private OpenLogs As Windows.Forms.Button
        Private ReportIssue As Windows.Forms.Button
        Private label4 As Windows.Forms.Label
        Private label5 As Windows.Forms.Label
        Private label6 As Windows.Forms.Label
    End Class
End Namespace
