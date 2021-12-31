Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Public Class Form1

    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal _
    uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Const SPI_SETDESKWALLPAPER = 20
    Private Const SPIF_UPDATEINIFILE = &H1
    Dim filename As String
    Dim imageCollection As New SortedList

    Dim locall As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Wg2.txt"

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myFile As String = locall
        Dim myWriter As New IO.StreamWriter(myFile)
        For Each myItem As ListViewItem In ListView2.Items


            myWriter.WriteLine(myItem.Text)
        Next

        myWriter.Close()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Text = "10 Segundos"
        If IO.File.Exists(locall) Then

        Else
            Dim sw As StreamWriter = File.CreateText(locall)

        End If


        On Error Resume Next
        Using sr As IO.StreamReader = File.OpenText(locall)
            While (-1 < sr.Peek())
                Dim line As String = sr.ReadLine()
                Dim item As New ListViewItem(line.Split("|"))
                ListView2.Items.Add(item)
            End While
            sr.Close()
        End Using
    End Sub

    Private Sub RemoverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoverToolStripMenuItem.Click
        Dim lst As New List(Of Object)
        For Each a As Object In ListView2.SelectedItems
            lst.Add(a)
        Next
        For Each a As Object In lst
            ListView2.Items.Remove(a)
        Next
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim myFile As String = locall
        Dim myWriter As New IO.StreamWriter(myFile)
        For Each myItem As ListViewItem In ListView2.Items


            myWriter.WriteLine(myItem.Text)
        Next

        myWriter.Close()
    End Sub


   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim openDlg As New OpenFileDialog
        openDlg.Multiselect = True

        Dim path As String

        openDlg.Filter = "Image Files (*.jpg, *.jpeg, *.png, *bmp, *.gif|*.jpg; *.jpeg; *.png; *bmp; *.gif"

        If openDlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            For Each path In openDlg.FileNames

                ListView2.Items.Add(path)
            Next
            ' ButtonX1.Enabled = True
            'onoff.Enabled = False
            ' عرض الصور()
            Timer1.Start()
        Else
            ' onoff.Value = False
        End If
    End Sub
    Dim somar As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '10:     ثواني()
        '30:     ثواني()
        '1:      دقيقة()
        '3:      دقيقة()
        '5:      دقيقة()
        '10:     دقيقة()
        '20:     دقيقة()
        '30:     دقيقة()
        If ComboBox1.Text = "5 Segundos" Then
            Timer1.Interval = 5000
        End If
        If ComboBox1.Text = "10 Segundos" Then
            Timer1.Interval = 10000
        End If

        If ComboBox1.Text = "30 Segundos" Then
            Timer1.Interval = 30000
        End If
        If ComboBox1.Text = "1 Minuto" Then
            Timer1.Interval = 600000
        End If
        If ComboBox1.Text = "3 Minutos" Then
            Timer1.Interval = 1800000
        End If
        If ComboBox1.Text = "5 Minutos" Then
            Timer1.Interval = 3000000
        End If
        If ComboBox1.Text = "10 Minutos" Then
            Timer1.Interval = 6000000
        End If
        If ComboBox1.Text = "20 Minutos" Then
            Timer1.Interval = 12000000
        End If
        If ComboBox1.Text = "30 Minutos" Then
            Timer1.Interval = 18000000
        End If
        Dim countt As Integer = ListView2.Items.Count

        On Error Resume Next
        somar += 1
        Label1.Text = somar
        'If ListView2.Items(somar).Selected Then
        On Error Resume Next
        PictureBox1.ImageLocation = ListView2.Items(somar).Text
        Dim caminhoImagem As String = Application.StartupPath & "\novo.bmp"

        PictureBox1.Image.Save(caminhoImagem, ImageFormat.Bmp)

        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, caminhoImagem, SPIF_UPDATEINIFILE)
        'Exit For
        If somar = countt Then
            somar = 0
        End If
        'End If
    End Sub
    

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        For i As Integer = 0 To ListView2.Items.Count - 1
            If ListView2.Items(i).Selected Then
                PictureBox1.ImageLocation = ListView2.Items(i).Text
                'PictureBox1.ImageLocation = ListView2.Items(somar).Text
                Dim caminhoImagem As String = Application.StartupPath & "\novo.bmp"
                On Error Resume Next
                PictureBox1.Image.Save(caminhoImagem, ImageFormat.Bmp)

                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, caminhoImagem, SPIF_UPDATEINIFILE)
            End If
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListView2.Items.Clear()
    End Sub
End Class
