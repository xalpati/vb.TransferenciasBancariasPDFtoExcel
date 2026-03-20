Imports Capa_Negocio
Imports System.ComponentModel
Imports System.Threading.Tasks

Public Class GUI_ImportarPDF
    Private Async Sub btnImportarPDF_Click(sender As Object, e As EventArgs) Handles btnImportarPDF.Click
        Dim Ubicacion As String
        Dim Importar As New N_ImportarPDF
        Dim Carga As New GUI_Load_Importar
        Dim ImportacionExitosa As Boolean = False

        _Errores.Clear()
        DialogoArchivo.ShowDialog()
        Ubicacion = DialogoArchivo.FileName

        If Ubicacion = "" Then
            Exit Sub
        End If

        ToggleImportacion(False)
        AddHandler Importar.ProgresoActualizado, AddressOf Carga.ActualizarProgreso

        Try
            Carga.Iniciar(1)
            Carga.Show(Me)

            ImportacionExitosa = Await Task.Run(Function() Importar.ImportarArchivo(Ubicacion))
        Catch ex As Exception
            msg("Ocurrio un error durante la importacion." & vbCrLf & ex.Message, 2)
            Return
        Finally
            RemoveHandler Importar.ProgresoActualizado, AddressOf Carga.ActualizarProgreso
            Carga.Finalizar()
            ToggleImportacion(True)
        End Try

        If ImportacionExitosa AndAlso Importar.ListaTransacciones.Count > 0 Then
            msg("Archivos importados: " & Importar.ListaTransacciones.Count.ToString)
        Else
            msg("Error al importar archivo!", 2)
        End If

        _Errores = Importar.Errores
        _No_Errores = Importar.No_Errores

        VerificaErrores()
    End Sub

    Private Async Sub btnImportarCarpeta_Click(sender As Object, e As EventArgs) Handles btnImportarCarpeta.Click
        Dim Ubicacion As String
        Dim Importar As New N_ImportarPDF
        Dim Carga As New GUI_Load_Importar

        _Errores.Clear()
        DialogoCarpeta.ShowDialog()
        Ubicacion = DialogoCarpeta.SelectedPath

        If Ubicacion = "" Then
            Exit Sub
        End If

        ToggleImportacion(False)
        AddHandler Importar.ProgresoActualizado, AddressOf Carga.ActualizarProgreso

        Try
            Carga.Iniciar(0)
            Carga.Show(Me)

            Await Task.Run(Sub() Importar.ImportarCarpeta(Ubicacion))
        Catch ex As Exception
            msg("Ocurrio un error durante la importacion." & vbCrLf & ex.Message, 2)
            Return
        Finally
            RemoveHandler Importar.ProgresoActualizado, AddressOf Carga.ActualizarProgreso
            Carga.Finalizar()
            ToggleImportacion(True)
        End Try

        If Importar.ListaTransacciones.Count > 0 Then
            msg("Archivos importados: " & Importar.ListaTransacciones.Count.ToString)
        Else
            msg("Error al importar archivo!", 2)
        End If

        _Errores = Importar.Errores
        _No_Errores = Importar.No_Errores

        VerificaErrores()
    End Sub

    Private Sub GUI_ImportarPDF_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        GUI_Inicio.CargarDatos()
    End Sub

    Private Sub VerificaErrores()
        If _No_Errores > 0 Then
            GUI_MostrarErrores.ShowDialog()
        End If
    End Sub

    Private Sub ToggleImportacion(ByVal Habilitar As Boolean)
        btnImportarPDF.Enabled = Habilitar
        btnImportarCarpeta.Enabled = Habilitar
        Cursor = If(Habilitar, Cursors.Default, Cursors.WaitCursor)
    End Sub
End Class
