Imports System.Data.SqlClient

Public MustInherit Class _1Conexion
    Private CadenaConexion As String
    Public Sub New()
        CadenaConexion = "Server=(local);DataBase=CRUD_Example_Reportes; Integrated Security=true"
    End Sub
    Protected Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(CadenaConexion)
    End Function
End Class
