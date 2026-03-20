Imports Capa_Negocio
Imports System.Reflection

Public Class GUI_Inicio
#Region "VARIABLES ------------------------------------------------------------------------------"
    Private db_Empresa As DataTable
    Private db_BancoOrigen As DataTable
    Private db_BancoDestino As DataTable
    Private ReadOnly TimerFiltros As New Timer()
    Private SuspendirFiltros As Boolean = False

#End Region
#Region "FUNCIONES COMPONENTES ------------------------------------------------------------------"
    Private Sub ImportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarToolStripMenuItem.Click
        GUI_ImportarPDF.ShowDialog()
    End Sub

    Private Sub ImportarFormatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarFormatoToolStripMenuItem.Click
        GUI_ImportarFormato.ShowDialog()
    End Sub

    Private Sub OrigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrigenToolStripMenuItem.Click
        GUI_BancoOrigen.ShowDialog()
    End Sub

    Private Sub DestinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DestinoToolStripMenuItem.Click
        GUI_BancoDestino.ShowDialog()
    End Sub

    Private Sub GUI_Inicio_Load(sender As Object, e As EventArgs) Handles Me.Load
        PrepararTabla()
        PrepararTimerFiltros()
        CargarDatos()
    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        GUI_EmpresaAgregar.ShowDialog()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        GUI_EmpresaEliminar.ShowDialog()
    End Sub

    Private Sub VincularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VincularToolStripMenuItem.Click
        GUI_EmpresaVincular.ShowDialog()
    End Sub

    Private Sub Tabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Tabla.CellDoubleClick
        Detalles()
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Detalles()
    End Sub

    Private Sub txtFechas_CheckedChanged(sender As Object, e As EventArgs) Handles txtFechas.CheckedChanged
        If SuspendirFiltros Then
            Return
        End If

        If txtFechas.Checked Then
            P_Fechas.Enabled = True
        Else
            P_Fechas.Enabled = False
        End If

        ProgramarFiltro()
    End Sub

    Private Sub txtBancoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtBancoOrigen.SelectedIndexChanged
        If SuspendirFiltros Then
            Return
        End If

        ProgramarFiltro()
    End Sub

    Private Sub txtBancoDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtBancoDestino.SelectedIndexChanged
        If SuspendirFiltros Then
            Return
        End If

        ProgramarFiltro()
    End Sub

    Private Sub txtFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicio.ValueChanged
        If SuspendirFiltros Then
            Return
        End If

        ProgramarFiltro()
    End Sub

    Private Sub txtFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFin.ValueChanged
        If SuspendirFiltros Then
            Return
        End If

        ProgramarFiltro()
    End Sub

#End Region
#Region "FUNCIONES GENERALES --------------------------------------------------------------------"
    Public Sub CargarDatos()
        Dim db_Transacciones As New N_Transacciones
        Dim dbBanco As New N_Banco
        Dim dbEmpresa As New N_EmpresaExterna

        Try
            SuspendirFiltros = True
            TimerFiltros.Stop()
            db_Empresa = dbEmpresa.Lista
            db_BancoOrigen = dbBanco.ListaBancoOrigen
            db_BancoDestino = dbBanco.ListaBancoDestino

            txtEmpresa.Items.Clear()
            txtBancoOrigen.Items.Clear()
            txtBancoDestino.Items.Clear()

            txtEmpresa.Items.Add("Ninguno")
            Try
                For Each Linea As DataRow In db_Empresa.Rows
                    txtEmpresa.Items.Add(Linea.Item(1))
                Next
            Catch ex As Exception
            End Try

            txtBancoOrigen.Items.Add("Ninguno")
            For Each Linea As DataRow In db_BancoOrigen.Rows
                txtBancoOrigen.Items.Add(Linea.Item(0) & " " & Linea.Item(2))
            Next

            txtBancoDestino.Items.Add("Ninguno")
            For Each Linea As DataRow In db_BancoDestino.Rows
                txtBancoDestino.Items.Add(Linea.Item(0) & " " & Linea.Item(2))
            Next

            txtEmpresa.SelectedIndex = 0
            txtBancoOrigen.SelectedIndex = 0
            txtBancoDestino.SelectedIndex = 0

            db_Transaccion = db_Transacciones.Lista

            AsignarTabla(db_Transaccion)
        Catch ex As Exception
            msg("Error", 2)
        Finally
            SuspendirFiltros = False
        End Try
    End Sub
    Private Sub Campos(ByVal Valor)
        txtEmpresa.Enabled = Valor
        txtBancoOrigen.Enabled = Valor
        txtBancoDestino.Enabled = Valor
        txtFechaInicio.Enabled = Valor
        txtFechaFin.Enabled = Valor
    End Sub
    Private Sub Detalles()
        Try
            V_Transaccion = Tabla.Item(0, Tabla.CurrentRow.Index).Value.ToString

            If Val(Tabla.Item(11, Tabla.CurrentRow.Index).Value) > 0 Then
                V_Empleados = True
            Else
                V_Empleados = False
            End If

            If V_Transaccion.Length > 1 Then
                GUI_DetallesGeneral.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Limpiar()
        txtClaveRastreo.Text = ""
        txtEmpresa.SelectedIndex = 0
        txtBancoOrigen.SelectedIndex = 0
        txtBancoDestino.SelectedIndex = 0

        txtFechaInicio.Value = Today.Date
        txtFechaFin.Value = Today.Date
        txtFechas.Checked = False
    End Sub

#End Region
#Region "FILTROS --------------------------------------------------------------------------------"

    Private Sub txtClaveRastreo_TextChanged(sender As Object, e As EventArgs) Handles txtClaveRastreo.TextChanged
        If SuspendirFiltros Then
            Return
        End If

        ProgramarFiltro()
    End Sub

    Private Sub AplicarFiltroClaveRastreo()
        Dim DB As New N_Filtros

        If txtClaveRastreo.Text.Length > 0 Then
            Campos(False)
            db_Transaccion = DB.Consultar(txtClaveRastreo.Text)
            AsignarTabla(db_Transaccion)
        Else
            db_Transaccion = DB.Consultar
            AsignarTabla(db_Transaccion)
            Campos(True)
        End If
    End Sub

    Private Sub txtEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtEmpresa.SelectedIndexChanged
        If SuspendirFiltros Then
            Return
        End If

        Dim DB As New N_Filtros
        Dim FI As String
        Dim FF As String
        Dim Aux As String
        Dim Empresa As String

        If txtEmpresa.SelectedIndex > 0 Then
            txtBancoOrigen.Enabled = False
            txtBancoDestino.Enabled = False
            txtClaveRastreo.Enabled = False

            Empresa = db_Empresa.Rows(txtEmpresa.SelectedIndex - 1).Item(0).ToString

            If txtFechas.Checked Then
                FI = Format(txtFechaInicio.Value, "yyyy/MM/dd")
                FF = Format(txtFechaFin.Value, "yyyy/MM/dd")

                If Convert.ToDateTime(FI) > Convert.ToDateTime(FF) Then
                    Aux = FI
                    FI = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(Aux).Date, "yyyy/MM/dd")
                Else
                    FI = Format(Convert.ToDateTime(FI).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                End If
            Else
                FI = ""
                FF = ""
            End If

            db_Transaccion = DB.Consultar(Empresa, FI, FF)
            AsignarTabla(db_Transaccion)
        Else
            Campos(True)
            txtClaveRastreo.Enabled = True

            db_Transaccion = DB.Consultar
            AsignarTabla(db_Transaccion)
        End If
    End Sub

    Private Sub FiltrarInfo()
        Dim DB As New N_Filtros
        Dim BO As String
        Dim BD As String
        Dim FI As String
        Dim FF As String
        Dim Aux As String

        If txtBancoOrigen.SelectedIndex > 0 Then
            BO = db_BancoOrigen.Rows(txtBancoOrigen.SelectedIndex - 1).Item(0).ToString

            If txtBancoDestino.SelectedIndex > 0 Then
                BD = db_BancoDestino.Rows(txtBancoDestino.SelectedIndex - 1).Item(0).ToString
            Else
                BD = ""
            End If

            If txtFechas.Checked Then
                FI = Format(txtFechaInicio.Value, "yyyy/MM/dd")
                FF = Format(txtFechaFin.Value, "yyyy/MM/dd")

                If Convert.ToDateTime(FI) > Convert.ToDateTime(FF) Then
                    Aux = FI
                    FI = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(Aux).Date, "yyyy/MM/dd")
                Else
                    FI = Format(Convert.ToDateTime(FI).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                End If
            Else
                FI = ""
                FF = ""
            End If

            txtClaveRastreo.Enabled = False
            txtEmpresa.Enabled = False

            db_Transaccion = DB.Consultar(BO, BD, FI, FF)
            AsignarTabla(db_Transaccion)
        ElseIf txtBancoDestino.SelectedIndex > 0 Then
            BD = db_BancoDestino.Rows(txtBancoDestino.SelectedIndex - 1).Item(0).ToString

            If txtBancoOrigen.SelectedIndex > 0 Then
                BO = db_BancoOrigen.Rows(txtBancoOrigen.SelectedIndex - 1).Item(0).ToString
            Else
                BO = ""
            End If

            If txtFechas.Checked Then
                FI = Format(txtFechaInicio.Value, "yyyy/MM/dd")
                FF = Format(txtFechaFin.Value, "yyyy/MM/dd")

                If Convert.ToDateTime(FI) > Convert.ToDateTime(FF) Then
                    Aux = FI
                    FI = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(Aux).Date, "yyyy/MM/dd")
                Else
                    FI = Format(Convert.ToDateTime(FI).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                End If
            Else
                FI = ""
                FF = ""
            End If

            txtClaveRastreo.Enabled = False
            txtEmpresa.Enabled = False

            db_Transaccion = DB.Consultar(BO, BD, FI, FF)
            AsignarTabla(db_Transaccion)
        Else
            Campos(True)

            If txtFechas.Checked Then
                FI = Format(txtFechaInicio.Value, "yyyy/MM/dd")
                FF = Format(txtFechaFin.Value, "yyyy/MM/dd")

                If Convert.ToDateTime(FI) > Convert.ToDateTime(FF) Then
                    Aux = FI
                    FI = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(Aux).Date, "yyyy/MM/dd")
                Else
                    FI = Format(Convert.ToDateTime(FI).Date, "yyyy/MM/dd")
                    FF = Format(Convert.ToDateTime(FF).Date, "yyyy/MM/dd")
                End If

                db_Transaccion = DB.Consultar("", "", FI, FF)
                AsignarTabla(db_Transaccion)
            Else
                db_Transaccion = DB.Consultar()
                AsignarTabla(db_Transaccion)
            End If

            txtClaveRastreo.Enabled = True
        End If
    End Sub

    Private Sub btnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles btnAplicarFiltro.Click
        TimerFiltros.Stop()
        FiltrarInfo()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim Guardar As New N_Exportar(db_Transaccion)
        CargarDatos()
    End Sub

    Private Sub Tabla_DataSourceChanged(sender As Object, e As EventArgs) Handles Tabla.DataSourceChanged
        txtTotal.Text = Tabla.Rows.Count - 1
    End Sub

    Private Sub PrepararTabla()
        Tabla.RowHeadersVisible = False
        Tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

        Try
            GetType(DataGridView).InvokeMember("DoubleBuffered",
                                               BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty,
                                               Nothing,
                                               Tabla,
                                               New Object() {True})
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrepararTimerFiltros()
        TimerFiltros.Interval = 350
        AddHandler TimerFiltros.Tick, AddressOf TimerFiltros_Tick
    End Sub

    Private Sub ProgramarFiltro()
        TimerFiltros.Stop()
        TimerFiltros.Start()
    End Sub

    Private Sub TimerFiltros_Tick(sender As Object, e As EventArgs)
        TimerFiltros.Stop()

        If txtClaveRastreo.TextLength > 0 Then
            AplicarFiltroClaveRastreo()
        ElseIf txtEmpresa.SelectedIndex > 0 Then
            txtEmpresa_SelectedIndexChanged(txtEmpresa, EventArgs.Empty)
        Else
            FiltrarInfo()
        End If
    End Sub

    Private Sub AsignarTabla(ByVal tablaDatos As DataTable)
        Tabla.SuspendLayout()
        Tabla.DataSource = Nothing
        Tabla.DataSource = tablaDatos
        Tabla.ResumeLayout()
    End Sub

    Private Sub TransaccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaccionesToolStripMenuItem.Click
        Dim DB As New N_VaciarBaseDeDatos
        DB.VaciarTransacciones()
        DB.VaciarTR_Procesadas()
        DB.VaciarEmpleados()

        CargarDatos()
        msg("Base de datos actualizada!")
    End Sub

    Private Sub EmpresasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmpresasToolStripMenuItem1.Click
        Dim DB As New N_VaciarBaseDeDatos
        DB.VaciarEmpresas()
        DB.VaciarVinculos()

        CargarDatos()
        msg("Base de datos actualizada!")
    End Sub

    Private Sub BancosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BancosToolStripMenuItem1.Click
        Dim DB As New N_VaciarBaseDeDatos
        DB.VaciarBancos()

        CargarDatos()
        msg("Base de datos actualizada!")
    End Sub

    Private Sub FormatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatosToolStripMenuItem.Click
        Dim DB As New N_VaciarBaseDeDatos
        DB.VaciarFormatos()
        DB.VaciarCamposNombre()
        DB.VaciarCamposInicio()
        DB.VaciarCamposFin()

        CargarDatos()
        msg("Base de datos actualizada!")
    End Sub

    Private Sub TodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodoToolStripMenuItem.Click
        Dim DB As New N_VaciarBaseDeDatos
        DB.VaciarTodo()

        CargarDatos()
        msg("Base de datos actualizada!")
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        GUI_Pruebas.ShowDialog()
    End Sub

#End Region
End Class
