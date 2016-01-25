Public Class MainForm

    Private Sub MetroTilePanel1_ItemClick(sender As Object, e As EventArgs)

    End Sub
    Private Sub MetroTileItem1_Click(sender As Object, e As EventArgs) Handles MetroTileItem1.Click
        lblSelectedForm.Text = "Reports"
        selectpage()
    End Sub
    Private Sub MetroTileItem2_Click(sender As Object, e As EventArgs) Handles MetroTileItem2.Click
        lblSelectedForm.Text = "Transactions"
        selectpage()
    End Sub
    Private Sub selectpage()
        Select Case lblSelectedForm.Text
            Case Is = "Reports"
                SlidePanel2.Visible = False
                SlidePanel2.IsOpen = False
                SlidePanel2.Controls.Clear()
                Reports.TopLevel = False
                Me.SlidePanel2.Controls.Add(Reports)
                SlidePanel2.Visible = True
                Reports.Show()
                SlidePanel2.IsOpen = True
                Reports.Left = (SlidePanel2.Width - Reports.Width) / 2
                Reports.Top = (SlidePanel2.Height - Reports.Height) / 2
            Case Is = "Transactions"
                SlidePanel2.Visible = False
                SlidePanel2.IsOpen = False
                SlidePanel2.Controls.Clear()
                Transactions.TopLevel = False
                Me.SlidePanel2.Controls.Add(Transactions)
                SlidePanel2.Visible = True
                Transactions.Show()
                SlidePanel2.IsOpen = True
                Reports.Left = (SlidePanel2.Width - Reports.Width) / 2
                Reports.Top = (SlidePanel2.Height - Reports.Height) / 2
        End Select
    End Sub

    Private Sub MetroTilePanel1_ItemClick_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroTileItem2_Click_1(sender As Object, e As EventArgs) Handles MetroTileItem2.Click

    End Sub

    Private Sub MetroTileItem1_Click_1(sender As Object, e As EventArgs) Handles MetroTileItem1.Click

    End Sub

    Private Sub MainForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Dim db As New DBHelper(My.Settings.DBconn)
        Dim parameters As New Dictionary(Of String, Object)()
        parameters.Add("username", Login.userName)
        db.ExecuteNonQuery("UPDATE Users SET loggedin='NO' WHERE username=@username", parameters)
    End Sub
End Class