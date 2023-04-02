Imports Microsoft.Reporting.WinForms
Public Class ReporteFRM
    Public Datos As List(Of Reportes_Filtracion_por_DatagridviewLASS) = New List(Of Reportes_Filtracion_por_DatagridviewLASS)()
    Private Sub ReporteFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("Reporte_Filtracion_Data", Datos))
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class