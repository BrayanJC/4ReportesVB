Imports System.Data.SqlClient
Public Class _2RepositorioMaestro
    Inherits _1Conexion
    Protected parametros As List(Of SqlParameter)
    Protected Sub ExecuteNonQuery(ByVal transactSql As String) 'Ejecutar sentencias de texto insert, update, delete con parametros
        Using conexion = ObtenerConexion()
            conexion.Open()
            Using comando = New SqlCommand()
                comando.Connection = conexion
                comando.CommandText = transactSql
                comando.CommandType = CommandType.Text
                For Each item As SqlParameter In parametros
                    comando.Parameters.Add(item)
                Next
                comando.ExecuteNonQuery()
                parametros.Clear()
            End Using
        End Using
    End Sub
    Protected Function ExecuteReader(ByVal transactSql As String) As DataTable 'Devolver tablas ejecutando consultas de texto con parametros
        Using conexion = ObtenerConexion()
            conexion.Open()
            Using comando = New SqlCommand()
                comando.Connection = conexion
                comando.CommandText = transactSql
                comando.CommandType = CommandType.Text
                For Each item As SqlParameter In parametros
                    comando.Parameters.Add(item)
                Next
                Dim lector As SqlDataReader = comando.ExecuteReader()
                Using tabla = New DataTable()
                    tabla.Load(lector)
                    lector.Dispose()
                    Return tabla
                End Using
            End Using
        End Using
    End Function
    Protected Function ExecuteReader2(ByVal transactSql As String) As DataTable 'Devolver tablas ejecutando consultas de texto sin parametros
        Using conexion = ObtenerConexion()
            conexion.Open()
            Using comando = New SqlCommand()
                comando.Connection = conexion
                comando.CommandText = transactSql
                comando.CommandType = CommandType.Text
                Dim lector As SqlDataReader = comando.ExecuteReader()
                Using tabla = New DataTable()
                    tabla.Load(lector)
                    lector.Dispose()
                    Return tabla
                End Using
            End Using
        End Using
    End Function
End Class
