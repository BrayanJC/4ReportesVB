Imports Microsoft.Reporting.WinForms
Public Class ReportePORFiltracionUNICA
    Private Sub ReportePORFiltracionUNICA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsEmpleados.DBPacientes' Puede moverla o quitarla según sea necesario.
        Me.DBPacientesTableAdapter.Fill(Me.DsEmpleados.DBPacientes)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Info As New DsEmpleados
        Dim campo As String = CmbCampo.Text
        Dim criterio As String = TXTcriterio.Text

        Dim op As New _3Funciones
        Info = op.Filtrar(campo, criterio)
        ReportViewer1.Visible = True

        ReportViewer1.SetDisplayMode(DisplayMode.Normal)
        ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportesVB.RepprtUNI.rdlc"
        Dim rds As New ReportDataSource("DsEmpleados", Info.Tables(0))
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Info As New DsEmpleados
        Dim campo As String = CmbCampo.Text
        Dim criterio As String = TXTcriterio.Text

        Dim op As New _3Funciones
        Info = op.Refrescar()
        ReportViewer1.Visible = True

        ReportViewer1.SetDisplayMode(DisplayMode.Normal)
        ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportesVB.RepprtUNI.rdlc"
        Dim rds As New ReportDataSource("DsEmpleados", Info.Tables(0))
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.RefreshReport()
    End Sub
End Class