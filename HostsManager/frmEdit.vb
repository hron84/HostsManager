Public Class frmEdit

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        Dim a As String = InputBox("Alias")
        If a.Length > 0 Then lstAlias.Items.Add(a)
    End Sub

    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Me.Hide()
    End Sub

    Private Sub btRm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRm.Click
        lstAlias.Items.Remove(lstAlias.SelectedItem)
    End Sub
End Class