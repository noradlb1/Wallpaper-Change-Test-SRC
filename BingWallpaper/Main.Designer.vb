Imports System

Namespace BingWallpaper
    Partial Class Main
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
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Main))
            imagePreview = New Windows.Forms.PictureBox()
            ApplyButton = New Windows.Forms.Button()
            label1 = New Windows.Forms.Label()
            FitBox = New Windows.Forms.ComboBox()
            groupBox1 = New Windows.Forms.GroupBox()
            CCBox = New Windows.Forms.ComboBox()
            label2 = New Windows.Forms.Label()
            groupBox2 = New Windows.Forms.GroupBox()
            FreqText = New Windows.Forms.TextBox()
            FreqTrack = New Windows.Forms.TrackBar()
            label3 = New Windows.Forms.Label()
            RefreshButton = New Windows.Forms.Button()
            ResetTaskButton = New Windows.Forms.Button()
            AboutButton = New Windows.Forms.Button()
            InfoLabel = New Windows.Forms.TextBox()
            ApplyOnce = New Windows.Forms.Button()
            Loading = New Windows.Forms.Label()
            MMK = New Windows.Forms.Label()
            CType(imagePreview, ComponentModel.ISupportInitialize).BeginInit()
            groupBox1.SuspendLayout()
            groupBox2.SuspendLayout()
            CType(FreqTrack, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' imagePreview
            ' 
            imagePreview.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Bottom Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right

            imagePreview.Location = New Drawing.Point(0, 0)
            imagePreview.Name = "imagePreview"
            imagePreview.Size = New Drawing.Size(719, 406)
            imagePreview.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
            imagePreview.TabIndex = 0
            imagePreview.TabStop = False
            ' 
            ' ApplyButton
            ' 
            ApplyButton.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            ApplyButton.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            ApplyButton.Location = New Drawing.Point(725, 219)
            ApplyButton.Name = "ApplyButton"
            ApplyButton.Size = New Drawing.Size(97, 23)
            ApplyButton.TabIndex = 1
            ApplyButton.Text = "Apply"
            ApplyButton.UseVisualStyleBackColor = True
            AddHandler ApplyButton.Click, New EventHandler(AddressOf ApplyButton_Click)
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            label1.Location = New Drawing.Point(9, 16)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(69, 13)
            label1.TabIndex = 0
            label1.Text = "Choose a fit"
            ' 
            ' FitBox
            ' 
            FitBox.AutoCompleteCustomSource.AddRange(New String() {"Fill", "Fit", "Stretch", "Tile", "Center", "Span"})
            FitBox.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
            FitBox.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
            FitBox.BackColor = Drawing.Color.White
            FitBox.FlatStyle = Windows.Forms.FlatStyle.Popup
            FitBox.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            FitBox.FormattingEnabled = True
            FitBox.Items.AddRange(New Object() {"Fill", "Fit", "Stretch", "Tile", "Center", "Span"})
            FitBox.Location = New Drawing.Point(12, 32)
            FitBox.Name = "FitBox"
            FitBox.Size = New Drawing.Size(182, 21)
            FitBox.TabIndex = 1
            FitBox.Text = "Stretch"
            AddHandler FitBox.TextChanged, New EventHandler(AddressOf FitBox_TextChanged)
            ' 
            ' groupBox1
            ' 
            groupBox1.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            groupBox1.Controls.Add(CCBox)
            groupBox1.Controls.Add(label2)
            groupBox1.Controls.Add(FitBox)
            groupBox1.Controls.Add(label1)
            groupBox1.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            groupBox1.Location = New Drawing.Point(725, 12)
            groupBox1.Name = "groupBox1"
            groupBox1.Size = New Drawing.Size(200, 108)
            groupBox1.TabIndex = 2
            groupBox1.TabStop = False
            groupBox1.Text = "Style"
            ' 
            ' CCBox
            ' 
            CCBox.BackColor = Drawing.Color.White
            CCBox.FlatStyle = Windows.Forms.FlatStyle.Popup
            CCBox.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            CCBox.FormattingEnabled = True
            CCBox.Items.AddRange(New Object() {"Default"})
            CCBox.Location = New Drawing.Point(12, 75)
            CCBox.Name = "CCBox"
            CCBox.Size = New Drawing.Size(182, 21)
            CCBox.TabIndex = 3
            CCBox.Text = "Default"
            AddHandler CCBox.TextUpdate, New EventHandler(AddressOf CCBox_TextUpdate)
            AddHandler CCBox.KeyUp, New Windows.Forms.KeyEventHandler(AddressOf CCBox_KeyUp)
            ' 
            ' label2
            ' 
            label2.AutoSize = True
            label2.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            label2.Location = New Drawing.Point(9, 59)
            label2.Name = "label2"
            label2.Size = New Drawing.Size(78, 13)
            label2.TabIndex = 2
            label2.Text = "Country Code"
            ' 
            ' groupBox2
            ' 
            groupBox2.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            groupBox2.Controls.Add(FreqText)
            groupBox2.Controls.Add(FreqTrack)
            groupBox2.Controls.Add(label3)
            groupBox2.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            groupBox2.Location = New Drawing.Point(725, 126)
            groupBox2.Name = "groupBox2"
            groupBox2.Size = New Drawing.Size(200, 87)
            groupBox2.TabIndex = 3
            groupBox2.TabStop = False
            groupBox2.Text = "Task settings"
            ' 
            ' FreqText
            ' 
            FreqText.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            FreqText.Location = New Drawing.Point(130, 13)
            FreqText.Name = "FreqText"
            FreqText.Size = New Drawing.Size(64, 22)
            FreqText.TabIndex = 4
            AddHandler FreqText.TextChanged, New EventHandler(AddressOf FreqText_TextChanged)
            ' 
            ' FreqTrack
            ' 
            FreqTrack.Cursor = Windows.Forms.Cursors.SizeWE
            FreqTrack.Location = New Drawing.Point(9, 38)
            FreqTrack.Maximum = 30
            FreqTrack.Minimum = 1
            FreqTrack.Name = "FreqTrack"
            FreqTrack.Size = New Drawing.Size(185, 45)
            FreqTrack.TabIndex = 3
            FreqTrack.TickStyle = Windows.Forms.TickStyle.Both
            FreqTrack.Value = 1
            AddHandler FreqTrack.Scroll, New EventHandler(AddressOf FreqTrack_Scroll)
            ' 
            ' label3
            ' 
            label3.AutoSize = True
            label3.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            label3.Location = New Drawing.Point(6, 16)
            label3.Name = "label3"
            label3.Size = New Drawing.Size(126, 13)
            label3.TabIndex = 2
            label3.Text = "Frequency (in minutes):"
            ' 
            ' RefreshButton
            ' 
            RefreshButton.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            RefreshButton.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            RefreshButton.Location = New Drawing.Point(828, 248)
            RefreshButton.Name = "RefreshButton"
            RefreshButton.Size = New Drawing.Size(97, 23)
            RefreshButton.TabIndex = 4
            RefreshButton.Text = "Refresh"
            RefreshButton.UseVisualStyleBackColor = True
            AddHandler RefreshButton.Click, New EventHandler(AddressOf RefreshButton_Click)
            ' 
            ' ResetTaskButton
            ' 
            ResetTaskButton.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            ResetTaskButton.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            ResetTaskButton.Location = New Drawing.Point(725, 248)
            ResetTaskButton.Name = "ResetTaskButton"
            ResetTaskButton.Size = New Drawing.Size(97, 23)
            ResetTaskButton.TabIndex = 5
            ResetTaskButton.Text = "Reset task"
            ResetTaskButton.UseVisualStyleBackColor = True
            AddHandler ResetTaskButton.Click, New EventHandler(AddressOf ResetTaskButton_Click)
            ' 
            ' AboutButton
            ' 
            AboutButton.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            AboutButton.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            AboutButton.Location = New Drawing.Point(725, 277)
            AboutButton.Name = "AboutButton"
            AboutButton.Size = New Drawing.Size(200, 23)
            AboutButton.TabIndex = 6
            AboutButton.Text = "About Bing Wallpaper"
            AboutButton.UseVisualStyleBackColor = True
            AddHandler AboutButton.Click, New EventHandler(AddressOf AboutButton_Click)
            ' 
            ' InfoLabel
            ' 
            InfoLabel.Anchor = Windows.Forms.AnchorStyles.Bottom Or Windows.Forms.AnchorStyles.Right
            InfoLabel.BackColor = Drawing.Color.FromArgb(241, 243, 247)
            InfoLabel.BorderStyle = Windows.Forms.BorderStyle.None
            InfoLabel.Cursor = Windows.Forms.Cursors.Help
            InfoLabel.Enabled = False
            InfoLabel.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            InfoLabel.ForeColor = Drawing.SystemColors.WindowText
            InfoLabel.Location = New Drawing.Point(725, 306)
            InfoLabel.Multiline = True
            InfoLabel.Name = "InfoLabel"
            InfoLabel.Size = New Drawing.Size(200, 81)
            InfoLabel.TabIndex = 7
            ' 
            ' ApplyOnce
            ' 
            ApplyOnce.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
            ApplyOnce.Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            ApplyOnce.Location = New Drawing.Point(828, 219)
            ApplyOnce.Name = "ApplyOnce"
            ApplyOnce.Size = New Drawing.Size(97, 23)
            ApplyOnce.TabIndex = 8
            ApplyOnce.Text = "Apply once"
            ApplyOnce.UseVisualStyleBackColor = True
            AddHandler ApplyOnce.Click, New EventHandler(AddressOf ApplyOnce_Click)
            ' 
            ' Loading
            ' 
            Loading.AutoSize = True
            Loading.Font = New Drawing.Font("Segoe UI", 15.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            Loading.Location = New Drawing.Point(722, 373)
            Loading.Name = "Loading"
            Loading.Size = New Drawing.Size(102, 30)
            Loading.TabIndex = 9
            Loading.Text = "Loading..."
            ' 
            ' MMK
            ' 
            MMK.Anchor = Windows.Forms.AnchorStyles.Bottom Or Windows.Forms.AnchorStyles.Right
            MMK.AutoSize = True
            MMK.Cursor = Windows.Forms.Cursors.Hand
            MMK.Font = New Drawing.Font("Segoe UI Emoji", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            MMK.ForeColor = Drawing.Color.FromArgb(148, 160, 179)
            MMK.Location = New Drawing.Point(828, 389)
            MMK.Name = "MMK"
            MMK.Size = New Drawing.Size(104, 15)
            MMK.TabIndex = 12
            MMK.Text = "{ } with ♥ by MMK"
            AddHandler MMK.Click, New EventHandler(AddressOf MMK_Click)
            ' 
            ' Main
            ' 
            AutoScaleDimensions = New Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            BackColor = Drawing.Color.FromArgb(241, 243, 247)
            ClientSize = New Drawing.Size(934, 406)
            Controls.Add(MMK)
            Controls.Add(Loading)
            Controls.Add(ApplyOnce)
            Controls.Add(InfoLabel)
            Controls.Add(AboutButton)
            Controls.Add(ResetTaskButton)
            Controls.Add(RefreshButton)
            Controls.Add(groupBox2)
            Controls.Add(groupBox1)
            Controls.Add(ApplyButton)
            Controls.Add(imagePreview)
            Font = New Drawing.Font("Segoe UI", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            Icon = CType(resources.GetObject("$this.Icon"), Drawing.Icon)
            MinimumSize = New Drawing.Size(950, 445)
            Name = "Main"
            StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Text = "Bing Wallpaper"
            AddHandler Load, New EventHandler(AddressOf Main_Load)
            CType(imagePreview, ComponentModel.ISupportInitialize).EndInit()
            groupBox1.ResumeLayout(False)
            groupBox1.PerformLayout()
            groupBox2.ResumeLayout(False)
            groupBox2.PerformLayout()
            CType(FreqTrack, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private imagePreview As Windows.Forms.PictureBox
        Private ApplyButton As Windows.Forms.Button
        Private label1 As Windows.Forms.Label
        Private FitBox As Windows.Forms.ComboBox
        Private groupBox1 As Windows.Forms.GroupBox
        Private CCBox As Windows.Forms.ComboBox
        Private label2 As Windows.Forms.Label
        Private groupBox2 As Windows.Forms.GroupBox
        Private FreqText As Windows.Forms.TextBox
        Private FreqTrack As Windows.Forms.TrackBar
        Private label3 As Windows.Forms.Label
        Private RefreshButton As Windows.Forms.Button
        Private ResetTaskButton As Windows.Forms.Button
        Private AboutButton As Windows.Forms.Button
        Private InfoLabel As Windows.Forms.TextBox
        Private ApplyOnce As Windows.Forms.Button
        Private Loading As Windows.Forms.Label
        Private MMK As Windows.Forms.Label
    End Class
End Namespace
