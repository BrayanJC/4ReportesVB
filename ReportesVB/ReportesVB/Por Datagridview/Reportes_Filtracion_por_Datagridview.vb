Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Public Class Reportes_Filtracion_por_Datagridview
    Public Estado As _4Valores
    Public id As Integer = 0
    Private Sub Reportes_Filtracion_por_Datagridview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDatos()
    End Sub
    Private Sub ListarDatos()
        Dim obj As _3Funciones = New _3Funciones()
        DataGridView1.DataSource = obj.MOSTRAR
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox1.Text <> "" And TextBox2.Text <> "" And ComboBox1.Text <> "") Then
            If Me.PictureBox1.Image Is Nothing Then
                MessageBox.Show("¡Error!, Suba una imagen e referencia", "Llene Todos Los Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                If MessageBox.Show("Se realizará el proceso, ¿Está seguro?", "Mensaje",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    AGREGAR()
                End If

            End If
        Else
            MessageBox.Show("¡Error!, No pueden haber campos vacios", "Llene Todos Los Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        Me.PictureBox1.Image = Nothing
        ComboBox1.Text = ""
        Button1.Enabled = False
    End Sub
    Public Sub AGREGAR()
        Try
            Dim obj As _3Funciones = New _3Funciones()
            Estado = _4Valores.Agregar
            obj.estado = Estado
            obj.Nombres1 = TextBox1.Text
            obj.Apellidos1 = TextBox2.Text
            obj.Fecha_Nacimiento1 = DateTimePicker1.Text
            obj.Ciudad1 = ComboBox1.Text
            obj.Imagen1 = ConvertirImg()
            obj.Grabar_PACIENTE()
            limpiar()
            ListarDatos()

        Catch ex As Exception
        End Try
    End Sub
    Private Function ConvertirImg() As Byte()
        Dim ms As MemoryStream = New MemoryStream()
        PictureBox1.Image.Save(ms, Drawing.Imaging.ImageFormat.Jpeg)
        Return ms.GetBuffer()
    End Function
    Public Sub ELIMINAR()
        Try
            Dim obj As _3Funciones = New _3Funciones()
            Estado = _4Valores.Borrar
            obj.estado = Estado
            obj.Id1 = Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value.ToString())
            obj.Grabar_PACIENTE()
            limpiar()
            ListarDatos()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (DataGridView1.SelectedRows.Count > 0) Then
            If MessageBox.Show("Se realizará el proceso, ¿Está seguro?", "Mensaje",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                ELIMINAR()
            End If
        Else
            MessageBox.Show("Por favor seleccione una fila...", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim openFile As OpenFileDialog = New OpenFileDialog()
        openFile.Filter = "Images(.jpg,.png)|*.png;*.jpg"
        If openFile.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = New Bitmap(openFile.FileName)
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        FilterData(TextBox4.Text)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Using cnn As New SqlConnection("Server=(local);DataBase=CRUD_Example_Reportes; Integrated Security=true")
            cnn.Open()
            Dim ConsultaSQL As String = "Select * from DBPacientes WHERE CONCAT(id,Nombres,Apellidos) like '%" & valueToSearch & "%'"
            Dim cmd As New SqlCommand(ConsultaSQL, cnn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
            cnn.Close()
        End Using
    End Sub
    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        If (DataGridView1.SelectedRows.Count > 0) Then
            TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value
            DateTimePicker1.Text = DataGridView1.CurrentRow.Cells(3).Value
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(4).Value
            Dim img As Byte()
            img = DataGridView1.CurrentRow.Cells(5).Value
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            Button1.Enabled = True
        Else
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rep As ReporteFRM = New ReporteFRM()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim dat As Reportes_Filtracion_por_DatagridviewLASS = New Reportes_Filtracion_por_DatagridviewLASS()
            dat.Nombres = TextBox1.Text
            dat.Apellidos = TextBox2.Text
            dat.Fecha_Nacimiento = DateTimePicker1.Text
            dat.Ciudad = ComboBox1.Text
            dat.Imagen = GetBytes(PictureBox1.Image)
            rep.Datos.Add(dat)
        Next
        rep.ShowDialog()
    End Sub
    Private Function GetBytes(ByVal imageIN As Image) As Byte()
        Dim ms As MemoryStream = New MemoryStream()
        imageIN.Save(ms, ImageFormat.Png)
        Return ms.ToArray()
    End Function
End Class