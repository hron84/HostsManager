Imports System.IO
Public Class frmMain
    Private hostentries As New List(Of HostEntry)
    Private saved As Boolean = True
    Private hideNotified As Boolean = False
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            If Not hideNotified Then
                NotifyIcon1.ShowBalloonTip(10, Me.Text, "The application is now running in background. Double click to this icon, or use popup menu to show it", ToolTipIcon.Info)
                hideNotified = True
            End If
        End If
    End Sub

   



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sr As StreamReader
        Dim line As String
        Try
            sr = New StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\drivers\etc\hosts")
            While Not sr.EndOfStream
                line = sr.ReadLine
                If line.Length = 0 Or line.StartsWith("#") Then Continue While
                hostentries.Add(HostEntry.GetFromLine(line))
            End While
            sr.Close()
        Catch ex As Exception
            MessageBox.Show(Me, "Error happened while reading hosts file: " + vbCrLf + ex.Message, "Error - Hosts Manager", MessageBoxButtons.OK)
            Return
        End Try

        For Each ent In hostentries
            'Debug.WriteLine(ent)
            Dim item As ListViewItem = lvMain.Items.Add(ent.IpAddress)
            Dim n = ""
            For Each hname In ent.Names
                n += hname + " "
            Next
            item.SubItems.Add(n)
            item.Tag = ent
        Next
        'Debug.WriteLine("---------------------------------------------------------------------------------------------")
        stMessage.Text = "Created by Gabor Garami. Licensed under terms of CreativeCommons BY-SA"


    End Sub


    Private Sub btHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHide.Click
        Me.Hide()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        Save()
        FlushDNS()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If lvMain.SelectedItems.Count = 0 Then Return
        Dim item As ListViewItem = lvMain.SelectedItems.Item(0)
        Dim ent As HostEntry = item.Tag
        Dim edform As New frmEdit()
        edform.txtIP.Text = ent.IpAddress
        For Each hname In ent.Names
            edform.lstAlias.Items.Add(hname)
        Next
        Dim res As DialogResult = edform.ShowDialog()
        'Debug.WriteLine(res)
        If res = Windows.Forms.DialogResult.Cancel Then Return
        ent.IpAddress = edform.txtIP.Text
        ent.Names.Clear()
        Dim n As String = ""
        For i = 0 To edform.lstAlias.Items.Count - 1
            ent.Names.Add(edform.lstAlias.Items(i))
            n += edform.lstAlias.Items(i) + " "
        Next
        lvMain.SelectedItems.Item(0).SubItems.Item(1).Text = n
        saved = False
    End Sub

    Private Sub InsertItem()
        Dim edform As New frmEdit()
        Dim ent As New HostEntry
        Dim res As DialogResult = edform.ShowDialog()
        'Debug.WriteLine(res)
        If res = Windows.Forms.DialogResult.Cancel Then Return
        ent.IpAddress = edform.txtIP.Text
        ent.Names.Clear()
        Dim n As String = ""
        For i = 0 To edform.lstAlias.Items.Count - 1
            ent.Names.Add(edform.lstAlias.Items(i))
            n += edform.lstAlias.Items(i) + " "
        Next
        Dim item As ListViewItem = lvMain.Items.Add(ent.IpAddress)
        hostentries.Add(ent)

        item.SubItems.Add(n)
        item.Tag = ent

        saved = False
    End Sub

    Private Sub DeleteItem()
        If lvMain.SelectedItems.Count = 0 Then Return
        If MessageBox.Show(Me, _
                           "Are you sure to delete this item?", _
                           "Delete host entry", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            hostentries.Remove(lvMain.SelectedItems.Item(0).Tag)
            lvMain.Items.Remove(lvMain.SelectedItems.Item(0))
            saved = False
        End If
    End Sub

    Private Sub CopyItem()
        If lvMain.SelectedItems.Count = 0 Then Return

        Dim ent As HostEntry = lvMain.SelectedItems.Item(0).Tag
        Dim line As String = ent.ToString
        My.Computer.Clipboard.SetText(line)
    End Sub

    Private Sub frmMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvMain.KeyUp
        If e.KeyCode = Keys.Insert Then
            InsertItem()
        ElseIf e.KeyCode = Keys.Delete Then
            DeleteItem()
        ElseIf e.KeyCode = Keys.S And e.Control Then
            CopyItem()
        End If

    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If Not saved Then
            Dim res As DialogResult = MessageBox.Show(Me, "Changes are not saved. Are you sure to exit?", "Hosts Manager", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If res <> DialogResult.OK Then Return
        End If
        End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteItem()
    End Sub

 
    Private Sub InsertToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem1.Click
        InsertItem()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        CopyItem()

    End Sub

    Private Sub Save()
        Try
            Dim sw As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\drivers\etc\hosts")

            For Each ent In hostentries
                '    Debug.WriteLine(ent)
                sw.WriteLine(ent)
            Next
            sw.Flush()
            sw.Close()
            saved = True
            stMessage.Text = "Saved"
        Catch ex As Exception
            MessageBox.Show(Me, "Error happened while reading hosts file: " + vbCrLf + ex.Message, "Error - Hosts Handler", MessageBoxButtons.OK)
            Return
        End Try
    End Sub

    Private Sub FlushDNS()
        ' Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\ipconfig.exe", "/flushdns")
        Dim si As New ProcessStartInfo()

        si.CreateNoWindow = True
        si.UseShellExecute = True
        si.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\ipconfig.exe"
        si.WindowStyle = ProcessWindowStyle.Hidden
        si.Arguments = "/flushdns"

        Process.Start(si)

    End Sub

End Class
