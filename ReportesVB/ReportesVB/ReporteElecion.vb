Public Class ReporteElecion
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New ReportePORFiltracionUNICA
        frm.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As New Reportes_Filtracion_por_Datagridview
        frm.ShowDialog()
    End Sub
End Class