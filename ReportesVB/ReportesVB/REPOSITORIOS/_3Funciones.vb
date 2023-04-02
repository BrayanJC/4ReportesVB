Imports System.Data.SqlClient
Public Class _3Funciones
    Inherits _2RepositorioMaestro
    Public estado As _4Valores

    ''''Paciente 
    Private Id As Integer
    Private Nombres As String
    Private Apellidos As String
    Private Fecha_Nacimiento As Date
    Private Ciudad As String
    Private Imagen As Byte()
#Region "Get y set"


    Public Property Id1 As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property Nombres1 As String
        Get
            Return Nombres
        End Get
        Set(value As String)
            Nombres = value
        End Set
    End Property

    Public Property Apellidos1 As String
        Get
            Return Apellidos
        End Get
        Set(value As String)
            Apellidos = value
        End Set
    End Property

    Public Property Fecha_Nacimiento1 As Date
        Get
            Return Fecha_Nacimiento
        End Get
        Set(value As Date)
            Fecha_Nacimiento = value
        End Set
    End Property

    Public Property Ciudad1 As String
        Get
            Return Ciudad
        End Get
        Set(value As String)
            Ciudad = value
        End Set
    End Property

    Public Property Imagen1 As Byte()
        Get
            Return Imagen
        End Get
        Set(value As Byte())
            Imagen = value
        End Set
    End Property
#End Region
    Public Sub INSERTAR()
        Dim TransactSQL As String = (" insert into DBPacientes values (@Nombres, @Apellidos, @Fecha_Nacimiento, @Ciudad, @Imagen)")
        parametros = New List(Of SqlParameter)()
        parametros.Add(New SqlParameter("@Nombres", Nombres1))
        parametros.Add(New SqlParameter("@Apellidos", Apellidos1))
        parametros.Add(New SqlParameter("@Fecha_Nacimiento", Fecha_Nacimiento1))
        parametros.Add(New SqlParameter("@Ciudad", Ciudad1))
        parametros.Add(New SqlParameter("@Imagen", Imagen1))
        ExecuteNonQuery(TransactSQL)
    End Sub
    Public Sub ELIMINAR()
        Dim TrsnsactSQL As String = (" DELETE FROM DBPacientes WHERE Id = @Id")
        parametros = New List(Of SqlParameter)()
        parametros.Add(New SqlParameter("@Id", Id1))
        ExecuteNonQuery(TrsnsactSQL)
    End Sub

    Public Function MOSTRAR() As DataTable
        Dim TransactSQL As String = ("Select * from DBPacientes")
        Return ExecuteReader2(TransactSQL)
    End Function
    Public Sub Grabar_PACIENTE()
        Try
            Select Case estado
                Case _4Valores.Agregar
                    INSERTAR()
                    MessageBox.Show("Paciente grabado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Select
                Case _4Valores.Borrar
                    ELIMINAR()
                    MessageBox.Show("Paciente borrado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Select
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Property sql As String
    Public Function Filtrar(campo As String, criterio As String) As DsEmpleados
        Dim DA As New SqlDataAdapter
        Dim ds As New DsEmpleados
        sql = "Select * from DBPacientes where " & campo & " like '%" & criterio & "%'"
        Try
            Using conexion = ObtenerConexion()
                conexion.Open()
                DA = New SqlDataAdapter(Me.sql, ObtenerConexion())
                DA.Fill(ds, "DBPacientes")
                conexion.Close()
                Return ds
            End Using
        Catch ex As Exception
        End Try
        Return ds
    End Function
    Public Function Refrescar() As DsEmpleados
        Dim DA As New SqlDataAdapter
        Dim ds As New DsEmpleados
        sql = "Select * from DBPacientes"
        Try
            Using conexion = ObtenerConexion()
                conexion.Open()
                DA = New SqlDataAdapter(Me.sql, ObtenerConexion())
                DA.Fill(ds, "DBPacientes")
                conexion.Close()
                Return ds
            End Using
        Catch ex As Exception
        End Try
        Return ds
    End Function
End Class
