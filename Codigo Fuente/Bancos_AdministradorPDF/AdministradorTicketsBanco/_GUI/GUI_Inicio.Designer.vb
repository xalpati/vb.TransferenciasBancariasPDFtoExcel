<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI_Inicio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI_Inicio))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VincularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BancosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DestinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarNuevoFormatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarFormatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VaciarBaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VaciarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BancosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.P_Left = New System.Windows.Forms.Panel()
        Me.P_Fechas = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechas = New System.Windows.Forms.CheckBox()
        Me.btnAplicarFiltro = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBancoDestino = New System.Windows.Forms.ComboBox()
        Me.txtClaveRastreo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBancoOrigen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.P_Body = New System.Windows.Forms.Panel()
        Me.P_Body_Body = New System.Windows.Forms.Panel()
        Me.Tabla = New System.Windows.Forms.DataGridView()
        Me.P_Body_Header = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.L_Titulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDetalles = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.P_Header = New System.Windows.Forms.Panel()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtTitulo = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.P_Left.SuspendLayout()
        Me.P_Fechas.SuspendLayout()
        Me.P_Body.SuspendLayout()
        Me.P_Body_Body.SuspendLayout()
        CType(Me.Tabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P_Body_Header.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.P_Header.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EmpresasToolStripMenuItem, Me.ImportarToolStripMenuItem, Me.BancosToolStripMenuItem, Me.ImportarNuevoFormatoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1147, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'EmpresasToolStripMenuItem
        '
        Me.EmpresasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarToolStripMenuItem, Me.VincularToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.EmpresasToolStripMenuItem.Name = "EmpresasToolStripMenuItem"
        Me.EmpresasToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.EmpresasToolStripMenuItem.Text = "Empresas"
        '
        'AgregarToolStripMenuItem
        '
        Me.AgregarToolStripMenuItem.Name = "AgregarToolStripMenuItem"
        Me.AgregarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.AgregarToolStripMenuItem.Text = "Agregar"
        '
        'VincularToolStripMenuItem
        '
        Me.VincularToolStripMenuItem.Name = "VincularToolStripMenuItem"
        Me.VincularToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.VincularToolStripMenuItem.Text = "Vincular"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ImportarToolStripMenuItem
        '
        Me.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem"
        Me.ImportarToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.ImportarToolStripMenuItem.Text = "Importar PDF"
        '
        'BancosToolStripMenuItem
        '
        Me.BancosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrigenToolStripMenuItem, Me.DestinoToolStripMenuItem})
        Me.BancosToolStripMenuItem.Name = "BancosToolStripMenuItem"
        Me.BancosToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.BancosToolStripMenuItem.Text = "Bancos"
        '
        'OrigenToolStripMenuItem
        '
        Me.OrigenToolStripMenuItem.Name = "OrigenToolStripMenuItem"
        Me.OrigenToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.OrigenToolStripMenuItem.Text = "Ver Bancos Origen"
        '
        'DestinoToolStripMenuItem
        '
        Me.DestinoToolStripMenuItem.Name = "DestinoToolStripMenuItem"
        Me.DestinoToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DestinoToolStripMenuItem.Text = "Ver Bancos Destino"
        '
        'ImportarNuevoFormatoToolStripMenuItem
        '
        Me.ImportarNuevoFormatoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarFormatoToolStripMenuItem, Me.VaciarBaseDeDatosToolStripMenuItem})
        Me.ImportarNuevoFormatoToolStripMenuItem.Name = "ImportarNuevoFormatoToolStripMenuItem"
        Me.ImportarNuevoFormatoToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ImportarNuevoFormatoToolStripMenuItem.Text = "Configuración"
        '
        'ImportarFormatoToolStripMenuItem
        '
        Me.ImportarFormatoToolStripMenuItem.Name = "ImportarFormatoToolStripMenuItem"
        Me.ImportarFormatoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ImportarFormatoToolStripMenuItem.Text = "Importar Formato"
        '
        'VaciarBaseDeDatosToolStripMenuItem
        '
        Me.VaciarBaseDeDatosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VaciarToolStripMenuItem})
        Me.VaciarBaseDeDatosToolStripMenuItem.Name = "VaciarBaseDeDatosToolStripMenuItem"
        Me.VaciarBaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.VaciarBaseDeDatosToolStripMenuItem.Text = "Base de datos"
        '
        'VaciarToolStripMenuItem
        '
        Me.VaciarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransaccionesToolStripMenuItem, Me.EmpresasToolStripMenuItem1, Me.BancosToolStripMenuItem1, Me.FormatosToolStripMenuItem, Me.TodoToolStripMenuItem})
        Me.VaciarToolStripMenuItem.Name = "VaciarToolStripMenuItem"
        Me.VaciarToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.VaciarToolStripMenuItem.Text = "Vaciar"
        '
        'TransaccionesToolStripMenuItem
        '
        Me.TransaccionesToolStripMenuItem.Name = "TransaccionesToolStripMenuItem"
        Me.TransaccionesToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.TransaccionesToolStripMenuItem.Text = "Transacciones"
        '
        'EmpresasToolStripMenuItem1
        '
        Me.EmpresasToolStripMenuItem1.Name = "EmpresasToolStripMenuItem1"
        Me.EmpresasToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.EmpresasToolStripMenuItem1.Text = "Empresas"
        '
        'BancosToolStripMenuItem1
        '
        Me.BancosToolStripMenuItem1.Name = "BancosToolStripMenuItem1"
        Me.BancosToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.BancosToolStripMenuItem1.Text = "Bancos"
        '
        'FormatosToolStripMenuItem
        '
        Me.FormatosToolStripMenuItem.Name = "FormatosToolStripMenuItem"
        Me.FormatosToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.FormatosToolStripMenuItem.Text = "Formatos"
        '
        'TodoToolStripMenuItem
        '
        Me.TodoToolStripMenuItem.Name = "TodoToolStripMenuItem"
        Me.TodoToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.TodoToolStripMenuItem.Text = "Todo"
        '
        'P_Left
        '
        Me.P_Left.AutoScroll = True
        Me.P_Left.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.P_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.P_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_Left.Controls.Add(Me.P_Fechas)
        Me.P_Left.Controls.Add(Me.txtFechas)
        Me.P_Left.Controls.Add(Me.btnAplicarFiltro)
        Me.P_Left.Controls.Add(Me.Label5)
        Me.P_Left.Controls.Add(Me.txtBancoDestino)
        Me.P_Left.Controls.Add(Me.txtClaveRastreo)
        Me.P_Left.Controls.Add(Me.Label4)
        Me.P_Left.Controls.Add(Me.Label3)
        Me.P_Left.Controls.Add(Me.txtBancoOrigen)
        Me.P_Left.Controls.Add(Me.Label2)
        Me.P_Left.Controls.Add(Me.txtEmpresa)
        Me.P_Left.Controls.Add(Me.Label1)
        Me.P_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.P_Left.Location = New System.Drawing.Point(0, 119)
        Me.P_Left.Name = "P_Left"
        Me.P_Left.Size = New System.Drawing.Size(235, 631)
        Me.P_Left.TabIndex = 2
        '
        'P_Fechas
        '
        Me.P_Fechas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.P_Fechas.Controls.Add(Me.Label6)
        Me.P_Fechas.Controls.Add(Me.txtFechaFin)
        Me.P_Fechas.Controls.Add(Me.txtFechaInicio)
        Me.P_Fechas.Controls.Add(Me.Label7)
        Me.P_Fechas.Enabled = False
        Me.P_Fechas.Location = New System.Drawing.Point(6, 395)
        Me.P_Fechas.Name = "P_Fechas"
        Me.P_Fechas.Size = New System.Drawing.Size(204, 147)
        Me.P_Fechas.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label6.Location = New System.Drawing.Point(1, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 31)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Fecha Inicio"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(2, 114)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(201, 29)
        Me.txtFechaFin.TabIndex = 13
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicio.Location = New System.Drawing.Point(2, 39)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(201, 29)
        Me.txtFechaInicio.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Location = New System.Drawing.Point(1, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 31)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Fecha Fin"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechas
        '
        Me.txtFechas.BackColor = System.Drawing.Color.Lavender
        Me.txtFechas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.txtFechas.Location = New System.Drawing.Point(6, 366)
        Me.txtFechas.Name = "txtFechas"
        Me.txtFechas.Size = New System.Drawing.Size(203, 23)
        Me.txtFechas.TabIndex = 17
        Me.txtFechas.Text = "Filtro por Fecha"
        Me.txtFechas.UseVisualStyleBackColor = False
        '
        'btnAplicarFiltro
        '
        Me.btnAplicarFiltro.BackColor = System.Drawing.Color.SeaGreen
        Me.btnAplicarFiltro.ForeColor = System.Drawing.Color.White
        Me.btnAplicarFiltro.Location = New System.Drawing.Point(9, 584)
        Me.btnAplicarFiltro.Name = "btnAplicarFiltro"
        Me.btnAplicarFiltro.Size = New System.Drawing.Size(198, 38)
        Me.btnAplicarFiltro.TabIndex = 14
        Me.btnAplicarFiltro.Text = "Aplicar filtro"
        Me.btnAplicarFiltro.UseVisualStyleBackColor = False
        Me.btnAplicarFiltro.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label5.Location = New System.Drawing.Point(5, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(202, 31)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cuenta Destino"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBancoDestino
        '
        Me.txtBancoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBancoDestino.DropDownWidth = 700
        Me.txtBancoDestino.FormattingEnabled = True
        Me.txtBancoDestino.Location = New System.Drawing.Point(5, 321)
        Me.txtBancoDestino.Name = "txtBancoDestino"
        Me.txtBancoDestino.Size = New System.Drawing.Size(202, 30)
        Me.txtBancoDestino.TabIndex = 7
        '
        'txtClaveRastreo
        '
        Me.txtClaveRastreo.Location = New System.Drawing.Point(5, 93)
        Me.txtClaveRastreo.Name = "txtClaveRastreo"
        Me.txtClaveRastreo.Size = New System.Drawing.Size(202, 29)
        Me.txtClaveRastreo.TabIndex = 6
        Me.txtClaveRastreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label4.Location = New System.Drawing.Point(5, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 31)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Clave rastreo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label3.Location = New System.Drawing.Point(5, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 31)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cuenta Origen"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBancoOrigen
        '
        Me.txtBancoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBancoOrigen.DropDownWidth = 700
        Me.txtBancoOrigen.FormattingEnabled = True
        Me.txtBancoOrigen.Location = New System.Drawing.Point(5, 244)
        Me.txtBancoOrigen.Name = "txtBancoOrigen"
        Me.txtBancoOrigen.Size = New System.Drawing.Size(202, 30)
        Me.txtBancoOrigen.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Location = New System.Drawing.Point(5, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Empresa"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmpresa
        '
        Me.txtEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtEmpresa.DropDownWidth = 700
        Me.txtEmpresa.FormattingEnabled = True
        Me.txtEmpresa.IntegralHeight = False
        Me.txtEmpresa.Location = New System.Drawing.Point(5, 167)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(202, 30)
        Me.txtEmpresa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Image = Global.AdministradorTicketsBanco.My.Resources.Resources.Filtro
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_Body
        '
        Me.P_Body.Controls.Add(Me.P_Body_Body)
        Me.P_Body.Controls.Add(Me.P_Body_Header)
        Me.P_Body.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P_Body.Location = New System.Drawing.Point(235, 119)
        Me.P_Body.Name = "P_Body"
        Me.P_Body.Size = New System.Drawing.Size(912, 631)
        Me.P_Body.TabIndex = 3
        '
        'P_Body_Body
        '
        Me.P_Body_Body.Controls.Add(Me.Tabla)
        Me.P_Body_Body.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P_Body_Body.Location = New System.Drawing.Point(0, 51)
        Me.P_Body_Body.Name = "P_Body_Body"
        Me.P_Body_Body.Size = New System.Drawing.Size(912, 580)
        Me.P_Body_Body.TabIndex = 2
        '
        'Tabla
        '
        Me.Tabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.Tabla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Tabla.BackgroundColor = System.Drawing.Color.White
        Me.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Tabla.Location = New System.Drawing.Point(0, 0)
        Me.Tabla.MultiSelect = False
        Me.Tabla.Name = "Tabla"
        Me.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Tabla.Size = New System.Drawing.Size(912, 580)
        Me.Tabla.TabIndex = 6
        '
        'P_Body_Header
        '
        Me.P_Body_Header.AutoScroll = True
        Me.P_Body_Header.BackColor = System.Drawing.Color.CornflowerBlue
        Me.P_Body_Header.BackgroundImage = Global.AdministradorTicketsBanco.My.Resources.Resources.Textura
        Me.P_Body_Header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_Body_Header.Controls.Add(Me.Panel2)
        Me.P_Body_Header.Controls.Add(Me.L_Titulo)
        Me.P_Body_Header.Controls.Add(Me.Panel1)
        Me.P_Body_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_Body_Header.Location = New System.Drawing.Point(0, 0)
        Me.P_Body_Header.Name = "P_Body_Header"
        Me.P_Body_Header.Size = New System.Drawing.Size(912, 51)
        Me.P_Body_Header.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(181, 49)
        Me.Panel2.TabIndex = 4
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Linen
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Blue
        Me.txtTotal.Location = New System.Drawing.Point(106, 13)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(72, 29)
        Me.txtTotal.TabIndex = 1
        Me.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-3, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 22)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Resultados:"
        '
        'L_Titulo
        '
        Me.L_Titulo.BackColor = System.Drawing.Color.Transparent
        Me.L_Titulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L_Titulo.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Titulo.ForeColor = System.Drawing.Color.White
        Me.L_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.L_Titulo.Name = "L_Titulo"
        Me.L_Titulo.Size = New System.Drawing.Size(582, 49)
        Me.L_Titulo.TabIndex = 3
        Me.L_Titulo.Text = "Reportes bancarios"
        Me.L_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnDetalles)
        Me.Panel1.Controls.Add(Me.btnExportarExcel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(582, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 49)
        Me.Panel1.TabIndex = 2
        '
        'btnDetalles
        '
        Me.btnDetalles.BackColor = System.Drawing.Color.Orange
        Me.btnDetalles.BackgroundImage = Global.AdministradorTicketsBanco.My.Resources.Resources.Detalles1
        Me.btnDetalles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDetalles.ForeColor = System.Drawing.Color.Black
        Me.btnDetalles.Location = New System.Drawing.Point(7, 6)
        Me.btnDetalles.Name = "btnDetalles"
        Me.btnDetalles.Size = New System.Drawing.Size(112, 38)
        Me.btnDetalles.TabIndex = 2
        Me.btnDetalles.Text = "Detalles"
        Me.btnDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDetalles.UseVisualStyleBackColor = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = Global.AdministradorTicketsBanco.My.Resources.Resources.Excel1
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExportarExcel.Location = New System.Drawing.Point(125, 6)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(189, 38)
        Me.btnExportarExcel.TabIndex = 0
        Me.btnExportarExcel.Text = "Exportar a Excel"
        Me.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'P_Header
        '
        Me.P_Header.BackgroundImage = Global.AdministradorTicketsBanco.My.Resources.Resources.Textura
        Me.P_Header.Controls.Add(Me.btnTest)
        Me.P_Header.Controls.Add(Me.PictureBox1)
        Me.P_Header.Controls.Add(Me.txtTitulo)
        Me.P_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_Header.Location = New System.Drawing.Point(0, 24)
        Me.P_Header.Name = "P_Header"
        Me.P_Header.Size = New System.Drawing.Size(1147, 95)
        Me.P_Header.TabIndex = 1
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.Color.Transparent
        Me.btnTest.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnTest.FlatAppearance.BorderSize = 0
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.Location = New System.Drawing.Point(0, 0)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(18, 95)
        Me.btnTest.TabIndex = 2
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.AdministradorTicketsBanco.My.Resources.Resources.Logo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(20, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(175, 95)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'txtTitulo
        '
        Me.txtTitulo.BackColor = System.Drawing.Color.Transparent
        Me.txtTitulo.Font = New System.Drawing.Font("Arial", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitulo.ForeColor = System.Drawing.Color.White
        Me.txtTitulo.Location = New System.Drawing.Point(346, 0)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(801, 95)
        Me.txtTitulo.TabIndex = 0
        Me.txtTitulo.Text = "Administrador de Transacciones bancarias"
        Me.txtTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GUI_Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 750)
        Me.Controls.Add(Me.P_Body)
        Me.Controls.Add(Me.P_Left)
        Me.Controls.Add(Me.P_Header)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MinimumSize = New System.Drawing.Size(889, 658)
        Me.Name = "GUI_Inicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrador de reportes bancarios V2.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.P_Left.ResumeLayout(False)
        Me.P_Left.PerformLayout()
        Me.P_Fechas.ResumeLayout(False)
        Me.P_Body.ResumeLayout(False)
        Me.P_Body_Body.ResumeLayout(False)
        CType(Me.Tabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P_Body_Header.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.P_Header.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpresasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BancosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DestinoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents P_Header As Panel
    Friend WithEvents txtTitulo As Label
    Friend WithEvents P_Left As Panel
    Friend WithEvents P_Body As Panel
    Friend WithEvents P_Body_Header As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents P_Body_Body As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmpresa As ComboBox
    Friend WithEvents txtClaveRastreo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBancoOrigen As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBancoDestino As ComboBox
    Friend WithEvents txtFechaFin As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFechaInicio As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents ImportarNuevoFormatoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarFormatoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents L_Titulo As Label
    Friend WithEvents Tabla As DataGridView
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VincularToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnDetalles As Button
    Friend WithEvents btnAplicarFiltro As Button
    Friend WithEvents P_Fechas As Panel
    Friend WithEvents txtFechas As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtTotal As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents VaciarBaseDeDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VaciarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpresasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BancosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FormatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTest As Button
End Class
