Imports System.IO
Imports Capa_Negocio

Public Class GUI_Load_Importar
    Private _ImportacionFinalizada As Boolean = False

    Public Sub Iniciar(ByVal TotalArchivos As Integer)
        If InvokeRequired Then
            Invoke(New Action(Of Integer)(AddressOf Iniciar), TotalArchivos)
            Return
        End If

        Dim Total As Integer = Math.Max(TotalArchivos, 1)

        txtTotal.Text = TotalArchivos.ToString()
        txtImportados.Text = "0"
        txtRestantes.Text = TotalArchivos.ToString()
        txtArchivoActual.Text = "Preparando importacion..."
        txtProgreso.Minimum = 0
        txtProgreso.Maximum = Total
        txtProgreso.Value = 0
        btnCerrar.Enabled = False
        _ImportacionFinalizada = False
    End Sub

    Public Sub ActualizarProgreso(ByVal sender As Object, ByVal e As ImportarPDFProgresoEventArgs)
        If InvokeRequired Then
            Invoke(New Action(Of Object, ImportarPDFProgresoEventArgs)(AddressOf ActualizarProgreso), sender, e)
            Return
        End If

        Dim Restantes As Integer = e.TotalArchivos - e.ArchivosProcesados

        txtTotal.Text = e.TotalArchivos.ToString()
        txtImportados.Text = e.ArchivosImportados.ToString()
        txtRestantes.Text = Math.Max(Restantes, 0).ToString()

        If e.ArchivoActual <> "" Then
            txtArchivoActual.Text = Path.GetFileName(e.ArchivoActual)
        ElseIf e.TotalArchivos > 0 AndAlso e.ArchivosProcesados = 0 Then
            txtArchivoActual.Text = "Preparando importacion..."
        Else
            txtArchivoActual.Text = "Esperando..."
        End If

        If txtProgreso.Maximum <> Math.Max(e.TotalArchivos, 1) Then
            txtProgreso.Maximum = Math.Max(e.TotalArchivos, 1)
        End If

        txtProgreso.Value = Math.Min(e.ArchivosProcesados, txtProgreso.Maximum)
    End Sub

    Public Sub Finalizar()
        If InvokeRequired Then
            Invoke(New Action(AddressOf Finalizar))
            Return
        End If

        txtArchivoActual.Text = "Importacion finalizada."
        txtProgreso.Value = txtProgreso.Maximum
        btnCerrar.Enabled = True
        _ImportacionFinalizada = True
        Activate()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub GUI_Load_Importar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not _ImportacionFinalizada AndAlso e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If
    End Sub
End Class
