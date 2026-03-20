Imports System.Data.Common
Imports System.IO
Imports Capa_Datos
Imports Capa_Identidad
Imports iTextSharp.text.pdf

Public Class N_ImportarPDF
#Region "Variables"
    Private Formatos As DataTable
    Private CamposNombre As DataTable
    Private CamposInicio As DataTable
    Private CamposFin As New DataTable
    Private _ListaTransacciones As New List(Of I_Transaccion)
    Public Errores As Hashtable
    Public No_Errores As Integer = 0
    Public Event ProgresoActualizado(ByVal sender As Object, ByVal e As ImportarPDFProgresoEventArgs)

#End Region
#Region "Constructor"
    Public Sub New()
        Errores = New Hashtable
        CargarDatos()
    End Sub

#End Region
#Region "Propiedades"
    ''' <summary>
    ''' Obtiene / establece lista de transacciones
    ''' </summary>
    ''' <returns></returns>
    Public Property ListaTransacciones As List(Of I_Transaccion)
        Get
            Return _ListaTransacciones
        End Get
        Set(value As List(Of I_Transaccion))
            _ListaTransacciones = value
        End Set
    End Property

#End Region
#Region "Funciones"
#Region "Públicas"
    ''' <summary>
    ''' Importar archivo de reporte bancario
    ''' </summary>
    ''' <param name="_Path">Archivo</param>
    ''' <returns>True - Si exitoso</returns>
    Public Function ImportarArchivo(ByVal _Path As String) As Boolean
        Dim Archivos As New List(Of String) From {"\\?\" & _Path}
        Return ImportarArchivos(Archivos)
    End Function
    ''' <summary>
    ''' Importa todos los archivos de una carpeta
    ''' </summary>
    ''' <param name="_Path">Carpeta</param>
    Public Sub ImportarCarpeta(ByVal _Path As String)
        Dim Archivos As List(Of String) = ObtenerArchivosPDF("\\?\" & _Path)
        ImportarArchivos(Archivos)
    End Sub

#End Region
#Region "Privadas"
    Private Function ImportarArchivos(ByVal Archivos As List(Of String)) As Boolean
        Dim TotalArchivos As Integer
        Dim ArchivosProcesados As Integer = 0
        Dim ArchivosImportados As Integer = 0
        Dim ImportacionExitosa As Boolean = False

        Try
            TotalArchivos = Archivos.Count
            NotificarProgreso(TotalArchivos, ArchivosProcesados, ArchivosImportados, "")

            For Each Archivo As String In Archivos
                NotificarProgreso(TotalArchivos, ArchivosProcesados, ArchivosImportados, Path.GetFileName(Archivo))

                Try
                    If Importar(Archivo) Then
                        ArchivosImportados += 1
                        ImportacionExitosa = True
                    End If
                Catch ex As Exception
                Finally
                    ArchivosProcesados += 1
                    NotificarProgreso(TotalArchivos, ArchivosProcesados, ArchivosImportados, Path.GetFileName(Archivo))
                End Try
            Next
        Catch ex As Exception
        End Try

        Return ImportacionExitosa
    End Function

    Private Function ObtenerArchivosPDF(ByVal Ruta As String) As List(Of String)
        Dim Archivos As New List(Of String)

        Try
            Archivos.AddRange(Directory.GetFiles(Ruta, "*.pdf", SearchOption.AllDirectories))
            Archivos.AddRange(Directory.GetFiles(Ruta, "*.PDF", SearchOption.AllDirectories))
        Catch ex As Exception
        End Try

        Return Archivos.Distinct(StringComparer.OrdinalIgnoreCase).ToList()
    End Function

    Private Sub NotificarProgreso(ByVal TotalArchivos As Integer,
                                  ByVal ArchivosProcesados As Integer,
                                  ByVal ArchivosImportados As Integer,
                                  ByVal ArchivoActual As String)
        RaiseEvent ProgresoActualizado(Me, New ImportarPDFProgresoEventArgs(TotalArchivos,
                                                                            ArchivosProcesados,
                                                                            ArchivosImportados,
                                                                            ArchivoActual))
    End Sub

    ''' <summary>
    ''' Importa un archivo de reporte bancario
    ''' </summary>
    ''' <param name="_Ruta_archivo">Path del archivo</param>
    Private Function Importar(ByVal _Ruta_archivo As String) As Boolean
        Dim Archivo_pdf As String
        Dim Lista_campos_encontrados As New I_Transaccion
        Dim db_Transaccion As New D_Transaccion

        Dim Formato_indice As Integer
        Dim NumeroPagina As Integer
        Dim TotalPaginas As Integer
        Dim ImportacionExitosa As Boolean

        Try
            Archivo_pdf = Leer(_Ruta_archivo)
            If Archivo_pdf.Length > 100 Then
                Formato_indice = 0
                For Each Formato As DataRow In Formatos.Rows
                    If InStr(Archivo_pdf, Formato.Item(1)) > 0 Then
                        If InStr(Archivo_pdf, Formato.Item(2)) > 0 Then

                            'Valida si es un formato multiple(contiene mas de una transaccion)
                            If Val(Formato.Item(4)) = 2 Then
                                'Obtiene el total de paginas para procesar cada pagina como una transaccion potencial.
                                TotalPaginas = ObtenerNumeroPaginas(_Ruta_archivo)
                                ImportacionExitosa = False

                                For NumeroPagina = 1 To TotalPaginas
                                    'Carga en Archivo_pdf solo el texto de la pagina actual.
                                    Archivo_pdf = Leer(_Ruta_archivo, NumeroPagina)

                                    If Archivo_pdf.Length < 1 Then
                                        Continue For
                                    End If

                                    'Busca los campos del formato usando exclusivamente el contenido de la pagina actual.
                                    Lista_campos_encontrados = Buscar(Formato_indice, Archivo_pdf, _Ruta_archivo)

                                    If Lista_campos_encontrados Is Nothing Then
                                        Continue For
                                    End If

                                    'Marca exito si al menos una pagina del PDF se inserta correctamente.
                                    If InsertarTransaccion(Lista_campos_encontrados) Then
                                        ImportacionExitosa = True
                                    End If
                                Next

                                Return ImportacionExitosa
                            End If

                            'Se encarga de buscar todos los campos del formato especifico
                            Lista_campos_encontrados = Buscar(Formato_indice, Archivo_pdf, _Ruta_archivo)

                            'En caso de que el formato sea de empleados, se encarga de obtener la lista de empleados
                            If Val(Formato.Item(4)) = 1 Then '------------------------------------------EMPLEADOS -------EMPLEADOS ------EMPLEADOS --
                                Lista_campos_encontrados = ImportarEmpleados(Archivo_pdf, Lista_campos_encontrados)
                            End If

                            'Inserta los datos encontrados en la base de datos, si es exitoso se agrega
                            Return InsertarTransaccion(Lista_campos_encontrados)

                        End If
                    End If
                    Formato_indice += 1
                Next
            End If
            VerificarError(_Ruta_archivo, Archivo_pdf)
            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Agrega la transaccion a la base de datos, si es exitosa se agrega a la lista de transacciones
    ''' </summary>
    ''' <param name="Lista_campos_encontrados"></param>
    ''' <returns></returns>
    Private Function InsertarTransaccion(ByVal Lista_campos_encontrados As I_Transaccion) As Boolean
        Dim db_Transaccion As New D_Transaccion

        Try
            'Se encarga de insertar la transaccion a la base de datos, si es exitosa se agrega a la lista de transacciones
            If db_Transaccion.Insertar(Lista_campos_encontrados) Then
                _ListaTransacciones.Add(Lista_campos_encontrados)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Sub VerificarError(ByVal Ubicacion As String, ByVal Cadena As String)
        Dim v1 As Boolean = False
        Dim v2 As Boolean = False
        Dim v3 As Boolean = False

        No_Errores += 1

        If InStr(Cadena.ToLower, "importe") > 0 OrElse InStr(Cadena.ToLower, "monto") > 0 Then
            v1 = True
        End If

        If InStr(Cadena.ToLower, "cuenta") > 0 Then
            v2 = True
        End If

        If InStr(Cadena.ToLower, "fecha") > 0 Then
            v3 = True
        End If

        If v1 And v2 And v3 Then
            Errores.Add(Ubicacion, "Formato no registrado!.")
        Else
            Errores.Add(Ubicacion, "No es reporte bancario!.")
        End If

    End Sub

#Region "EMPLEADOS ---"
    ''' <summary>
    ''' Devuelve transaccion con lista de empleados
    ''' </summary>
    ''' <param name="Cadena">PDF convertido a texto</param>
    ''' <param name="TR">Identidad de la transacción</param>
    ''' <returns></returns>
    Private Function ImportarEmpleados(ByVal Cadena As String, ByVal TR As I_Transaccion) As I_Transaccion
        Dim sCadena As String
        Dim Inicio As Integer
        Dim Fin As Integer

        Inicio = InStr(Cadena, "Código Descripción" & Chr(10)) + 18
        Fin = InStr(Cadena, " Fecha de  Impresión")

        sCadena = Cadena.Substring(Inicio, (Fin - Inicio) - 2)
        TR.Empleados = getAllEmpleados(sCadena)
        TR = getInfoTransaccion(TR)

        Return TR
    End Function
    Private Function getInfoTransaccion(ByVal Transaccion As I_Transaccion) As I_Transaccion
        Dim RT As Integer = 0
        Dim Importe As Decimal = 0.0
        Dim ImporteAux As Decimal

        For Each Empleado As I_Empleado In Transaccion.Empleados
            ImporteAux = Convert.ToDecimal(Empleado.Importe)
            Empleado.Idtransaccion = Transaccion.Idtransaccion
            If ImporteAux > 0 Then
                Importe += ImporteAux
                RT += 1
            End If
        Next

        Transaccion.C14 = Importe
        Transaccion.C9 = RT

        Return Transaccion
    End Function

    ''' <summary>
    ''' Devuelve lista de empleados
    ''' </summary>
    ''' <param name="Cadena">Cadena filtrada con solo lista de empleados a procesar</param>
    ''' <returns></returns>
    Private Function getAllEmpleados(ByVal Cadena As String) As List(Of I_Empleado)
        Dim Empleados As New List(Of I_Empleado)
        Dim Empleado As New I_Empleado
        Dim Fin As Integer
        Dim sCadena As String

        'Fin = InStr(Cadena, Chr(10))

        Do
            Fin = InStr(Cadena, Chr(10))
            If Fin = 0 Then
                Fin = Cadena.Length + 1
            End If

            sCadena = Cadena.Substring(0, Fin - 1)

            If Fin < Cadena.Length Then
                Cadena = Cadena.Substring(Fin, Cadena.Length - Fin)
            Else
                Cadena = ""
            End If

            Empleado = getEmpleado(sCadena)

            If Not Empleado Is Nothing Then
                Empleados.Add(Empleado)
            End If

        Loop While Cadena.Length > 50

        Return Empleados
    End Function

    ''' <summary>
    ''' Devuelve un empleado
    ''' </summary>
    ''' <param name="Cadena">Linea de empleado</param>
    ''' <returns></returns>
    Private Function getEmpleado(ByVal Cadena As String) As I_Empleado
        Dim Empleado As New I_Empleado
        Dim Inicio As Integer
        Dim Fin As Integer
        Dim Aux As Integer
        Dim Aux2 As Decimal
        Dim sCadena As String

        '-> NUMERO DE EMPLEADO -----------------------------------
        Empleado.No_empleado = Cadena.Substring(0, 10)
        '---------------------------------------------------------

        '-> NOMBRE --------------------------------------------------
        Inicio = 11
        Aux = Inicio
        While True
            Fin = InStr(Aux, Cadena, " ")
            sCadena = Cadena.Substring(Fin, 1)

            If Char.IsNumber(sCadena) Then
                Exit While
            End If
            Aux = Fin + 1
        End While

        Empleado.Nombre = Cadena.Substring(Inicio, Fin - Inicio - 1)
        '---------------------------------------------------------

        '-> TIPO CUENTA ------------------------------------------
        Inicio = Fin
        Fin = InStr(Inicio + 1, Cadena, " ")

        Empleado.Tipo_cuenta = Cadena.Substring(Inicio, Fin - Inicio - 1)
        '---------------------------------------------------------

        '-> NUMERO DE CUENTA -------------------------------------
        Inicio = Fin
        Empleado.No_cuenta = Cadena.Substring(Inicio, 18)
        '---------------------------------------------------------

        '-> IMPORTE ----------------------------------------------
        Inicio = InStr(Inicio, Cadena, "$")

        Fin = InStr(Inicio, Cadena, "APLICADO")
        If Fin = 0 Then
            Fin = InStr(Inicio, Cadena, "RECHAZADO")
        End If
        Fin -= 1

        Aux2 = Cadena.Substring(Inicio, Fin - Inicio)
        Empleado.Importe = Convert.ToDecimal(Aux2)
        '---------------------------------------------------------

        '-> DESCRIPCION ------------------------------------------
        Inicio = Fin + 1

        For I As Integer = 1 To 2
            Inicio += 1
            Inicio = InStr(Inicio, Cadena, " ")
        Next

        Fin = Cadena.Length

        Empleado.Descripcion = Cadena.Substring(Inicio, Fin - Inicio)
        '---------------------------------------------------------

        Return Empleado
    End Function

#End Region
    ''' <summary>
    ''' Lee archivo de reporte bancario
    ''' </summary>
    ''' <param name="Ubicacion">Path del archivo</param>
    ''' <returns></returns>
    Private Function Leer(ByVal Ubicacion As String) As String
        Dim ArchivoPDF As New PdfReader(Ubicacion)
        Dim Texto = ""

        For i = 1 To ArchivoPDF.NumberOfPages
            Dim its As New parser.SimpleTextExtractionStrategy
            Texto &= parser.PdfTextExtractor.GetTextFromPage(ArchivoPDF, i, its)
        Next
        ArchivoPDF.Close()
        Return Texto
    End Function

    ''' <summary>
    ''' Lee una pagina especifica del archivo de reporte bancario
    ''' </summary>
    ''' <param name="Ubicacion">Path del archivo</param>
    ''' <param name="NumeroPagina">Numero de pagina a leer, base 1</param>
    ''' <returns></returns>
    Private Function Leer(ByVal Ubicacion As String, ByVal NumeroPagina As Integer) As String
        Dim ArchivoPDF As New PdfReader(Ubicacion)
        Dim Texto As String = ""

        Try
            If NumeroPagina < 1 OrElse NumeroPagina > ArchivoPDF.NumberOfPages Then
                Return ""
            End If

            Dim its As New parser.SimpleTextExtractionStrategy
            Texto = parser.PdfTextExtractor.GetTextFromPage(ArchivoPDF, NumeroPagina, its)
        Finally
            ArchivoPDF.Close()
        End Try

        Return Texto
    End Function

    ''' <summary>
    ''' Obtiene el total de paginas del archivo PDF
    ''' </summary>
    ''' <param name="Ubicacion">Path del archivo</param>
    ''' <returns></returns>
    Private Function ObtenerNumeroPaginas(ByVal Ubicacion As String) As Integer
        Dim ArchivoPDF As New PdfReader(Ubicacion)

        Try
            Return ArchivoPDF.NumberOfPages
        Finally
            ArchivoPDF.Close()
        End Try
    End Function

    Public Function Buscar(ByVal Formato_indice As Integer, ByVal Archivo_pdf_texto_completo As String, ByVal Ubicacion As String) As I_Transaccion
        Dim CampoInicio As String
        Dim CampoFin As String
        Dim Inicio As Integer
        Dim Fin As Integer
        Dim Auxiliar As String
        Dim Respuesta As New I_Transaccion
        Dim DB As New N_TR_Procesada

        Respuesta.Idformato = Formatos.Rows(Formato_indice).Item(0).ToString
        Respuesta.Banco_origen.Moneda = Formatos.Rows(Formato_indice).Item(3).ToString
        Respuesta.Banco_destino.Moneda = Formatos.Rows(Formato_indice).Item(3).ToString
        Respuesta.C15 = Formatos.Rows(Formato_indice).Item(3).ToString

        Try
            For i = 1 To 17
                Inicio = 0
                Fin = 0
                CampoInicio = CamposInicio.Rows(Formato_indice).Item(i).ToString
                CampoFin = CamposFin.Rows(Formato_indice).Item(i).ToString

                'Se reemplaza caracteres especiales para coincidencia con documento
                CampoInicio = CampoInicio.Replace("\n", Chr(10))
                CampoInicio = CampoInicio.Replace("\0", "")
                CampoFin = CampoFin.Replace("\n", Chr(10))
                CampoFin = CampoFin.Replace("\0", "")

                If CampoInicio.Contains("COMPLEMENTO") Then
                    Continue For
                End If

                If CampoInicio.Length > 0 Then
                    If CampoFin = "" Then
                        CampoFin = Chr(10)
                    End If

                    Inicio = InStr(Archivo_pdf_texto_completo, CampoInicio)
                    Inicio = Inicio + CampoInicio.Length - 1

                    'Si se especifica fin de archivo
                    If CampoFin = "\f" Then
                        Fin = Archivo_pdf_texto_completo.Length
                    Else
                        Fin = InStr(Inicio, Archivo_pdf_texto_completo, CampoFin)
                    End If


                    If (Fin - Inicio) < 1 Then
                        Dim y As Integer = 1
                        While Fin - Inicio < 1 And y < Archivo_pdf_texto_completo.Length
                            Try
                                Fin = InStr(Inicio + y, Archivo_pdf_texto_completo, CampoFin)
                            Catch ex As Exception
                                Exit While
                            End Try
                            y += 1
                        End While
                        Fin += 1
                    End If

                    Try
                        If CampoFin = "\f" Then
                            Auxiliar = Archivo_pdf_texto_completo.Substring(Inicio, Fin - Inicio)
                        Else
                            Auxiliar = Archivo_pdf_texto_completo.Substring(Inicio, Fin - (Inicio + 1))
                        End If
                    Catch ex As Exception
                        If Inicio > 1 Then
                            Auxiliar = Archivo_pdf_texto_completo.Substring(Inicio)
                        End If
                        Auxiliar = ""
                        Console.WriteLine(ex.Message + vbCrLf + vbCrLf + ex.StackTrace)
                    End Try
                    Auxiliar = Auxiliar.Replace(Chr(10), " ")
                    Auxiliar = Auxiliar.Trim

                    Respuesta.setValor(i - 1, Auxiliar)
                End If
            Next

            'AQUI SE INSERTAN LOS COMPLEMENTOS DE LOS FORMATOS --------------------

            Respuesta = Complementos(Archivo_pdf_texto_completo, Respuesta)

            '-----FIN COMPLEMENTOS FORMATO **************************************

            'Validación de la clave de rastreo que sea diferente a 0 o null
            If Respuesta.C0 = "" Then
                If Respuesta.C13.Length > 2 Then
                    Respuesta.C0 = Respuesta.C13
                Else
                    If Respuesta.C12.Length > 2 Then
                        Respuesta.C0 = Respuesta.C12
                    End If
                End If
            End If
            ' FIN VALIDACION CLAVE RASTREO

            'Verifica Si existe clave de rastreo

            If DB.Consultar(Respuesta.C0) Then
                No_Errores += 1
                Errores.Add(Ubicacion, "Formato duplicado!.")
                Return Nothing
            End If

            ' Continua ejecución normal ---------------------------------------------------------

            If Len(Formatos.Rows(Formato_indice).Item(5).ToString) > 0 Then
                Respuesta.C1 = Formatos.Rows(Formato_indice).Item(5).ToString
            End If

            If Len(Formatos.Rows(Formato_indice).Item(6).ToString) > 0 Then
                Respuesta.C5 = Formatos.Rows(Formato_indice).Item(6).ToString
            End If

            If Respuesta.C8.Length < 2 Then
                With Respuesta
                    .C5 = ""
                    .C6 = ""
                    .C7 = ""
                    .C8 = ""
                End With
            End If

            'ESTABLECIENDO UBICACION DE ARCHIVO
            Try
                Respuesta.C17 = Path.GetFileName(Ubicacion)
                If Respuesta.C17.Length = 0 Then
                    Respuesta.C17 = ""
                End If
            Catch ex As Exception
                Respuesta.C17 = ""
            End Try
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Return Respuesta
    End Function



    Private Sub CargarDatos()
        Dim _Formato As New D_Formato
        Dim _CN As New D_CamposNombre
        Dim _CI As New D_CamposInicio
        Dim _CF As New D_CamposFin

        Formatos = _Formato.Lista
        CamposNombre = _CN.Lista
        CamposInicio = _CI.Lista
        CamposFin = _CF.Lista

    End Sub
#End Region
#End Region
#Region "Complementos de formatos"
    ''' <summary>
    ''' Complemento Formatos
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function Complementos(ByVal cadena As String, ByVal obj As I_Transaccion) As I_Transaccion
        Try
            Select Case obj.Idformato
                Case "F15"
                    Return c_f15(cadena, obj)
                Case "F020"
                    Return c_f20(cadena, obj)
                Case Else
                    Return obj
            End Select
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    ''' <summary>
    ''' Complemento del formato 15
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function c_f15(ByVal cadena As String, ByVal obj As I_Transaccion) As I_Transaccion
        Dim _cadena As String
        Dim _ind1, _ind2 As Integer
        Dim _NoCuentaOrdenante, _NombreCuentaOrdenante, _NoCuentaDestino, _NombreCuentaDestino As String

        _NoCuentaOrdenante = ""
        _NombreCuentaOrdenante = ""
        _NoCuentaDestino = ""
        _NombreCuentaDestino = ""

        Try
            _cadena = cadena.Replace(Chr(10), " ")
            _cadena = _cadena.Replace(vbCr, " ")
            _cadena = _cadena.Replace(vbCrLf, " ")

            _ind1 = _cadena.IndexOf("Descripción")
            _cadena = _cadena.Substring(_ind1 + 12)

            _ind1 = _cadena.IndexOf("-")

            _ind2 = getIndiceInverso(" ", _cadena.Substring(0, _ind1))

            If _ind1 > 0 AndAlso _ind2 < _ind1 Then
                'Numero de cuenta ordenante
                _NoCuentaOrdenante = _cadena.Substring(_ind2 + 1, _ind1 - _ind2 - 1).Trim
                _cadena = _cadena.Substring(_ind1 + 1)

                _ind1 = _cadena.IndexOf("-")
                If _ind1 > 0 AndAlso _ind2 < _ind1 Then
                    _ind2 = getIndiceInverso(" ", _cadena.Substring(0, _ind1))
                    'Numero de cuenta destino
                    _NoCuentaDestino = _cadena.Substring(_ind2 + 1, _ind1 - _ind2 - 1).Trim

                    _NombreCuentaOrdenante = _cadena.Substring(0, _ind2).Trim
                    _ind1 += 1
                    _cadena = _cadena.Substring(_ind1)
                    _ind1 = _cadena.IndexOf("$")

                    If _ind1 > 0 Then
                        _NombreCuentaDestino = _cadena.Substring(0, _ind1).Trim
                    End If
                End If
            End If


            'Asignacion de valores en objeto
            obj.C2 = _NombreCuentaOrdenante
            obj.C4 = _NoCuentaOrdenante
            obj.C6 = _NombreCuentaDestino
            obj.C8 = _NoCuentaDestino

        Catch ex As Exception
        End Try

        Return obj
    End Function

    ''' <summary>
    ''' Complemento del formato 20 - PEIBO
    ''' Interpreta la "Cadena Original Información del Pago" para recuperar
    ''' campos que no se extraen bien con delimitadores simples.
    ''' </summary>
    ''' <param name="cadena"></param>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function c_f20(ByVal cadena As String, ByVal obj As I_Transaccion) As I_Transaccion
        Dim CadenaOriginal As String
        Dim Partes As String()

        Try
            CadenaOriginal = ExtraerCadenaOriginalPago(cadena)

            If CadenaOriginal.Length < 1 Then
                Return obj
            End If

            Partes = CadenaOriginal.Split("|"c)

            'Indices relevantes del ejemplo PEIBO:
            ' 7  = Banco origen
            ' 8  = Nombre ordenante
            ' 10 = Cuenta ordenante
            ' 11 = RFC origen
            ' 12 = Banco destino
            ' 13 = Beneficiario en institución financiera
            ' 15 = Cuenta destino
            ' 16 = RFC destino
            ' 17 = Concepto de pago
            ' 19 = Importe
            If GetParteCadenaOriginal(Partes, 7).Length > 0 Then obj.C1 = GetParteCadenaOriginal(Partes, 7)
            If GetParteCadenaOriginal(Partes, 8).Length > 0 Then obj.C2 = GetParteCadenaOriginal(Partes, 8)
            If GetParteCadenaOriginal(Partes, 10).Length > 0 Then obj.C4 = GetParteCadenaOriginal(Partes, 10)
            If GetParteCadenaOriginal(Partes, 11).Length > 0 Then obj.C3 = GetParteCadenaOriginal(Partes, 11)
            If GetParteCadenaOriginal(Partes, 12).Length > 0 Then obj.C5 = GetParteCadenaOriginal(Partes, 12)
            If GetParteCadenaOriginal(Partes, 13).Length > 0 Then
                obj.C6 = GetParteCadenaOriginal(Partes, 13)
                obj.C11 = GetParteCadenaOriginal(Partes, 13)
            End If
            If GetParteCadenaOriginal(Partes, 15).Length > 0 Then obj.C8 = GetParteCadenaOriginal(Partes, 15)
            If GetParteCadenaOriginal(Partes, 16).Length > 0 Then obj.C7 = GetParteCadenaOriginal(Partes, 16)
            If GetParteCadenaOriginal(Partes, 17).Length > 0 Then obj.C10 = GetParteCadenaOriginal(Partes, 17)
            If GetParteCadenaOriginal(Partes, 19).Length > 0 Then obj.C14 = Convert.ToDecimal(GetParteCadenaOriginal(Partes, 19))

            If obj.C16.Length < 1 Then
                obj.C16 = FormatearFechaCadenaOriginal(GetParteCadenaOriginal(Partes, 4))
            End If

        Catch ex As Exception
        End Try

        Return obj
    End Function

    Private Function ExtraerCadenaOriginalPago(ByVal cadena As String) As String
        Dim Inicio As Integer
        Dim Fin As Integer
        Dim Resultado As String
        Dim MarcaInicio As String = "Cadena Original Información del Pago:"
        Dim MarcaFin As String = "Sello Digital (firma provista por el banco receptor del pago):"

        Try
            Inicio = cadena.IndexOf(MarcaInicio)

            If Inicio < 0 Then
                MarcaInicio = "Cadena Original Informacion del Pago:"
                Inicio = cadena.IndexOf(MarcaInicio)
            End If

            If Inicio < 0 Then
                Return ""
            End If

            Inicio += MarcaInicio.Length
            Fin = cadena.IndexOf(MarcaFin, Inicio)

            If Fin < 0 Then
                Fin = cadena.Length
            End If

            Resultado = cadena.Substring(Inicio, Fin - Inicio)
            Resultado = Resultado.Replace(vbCrLf, " ")
            Resultado = Resultado.Replace(vbCr, " ")
            Resultado = Resultado.Replace(Chr(10), " ")

            While Resultado.Contains("  ")
                Resultado = Resultado.Replace("  ", " ")
            End While

            Resultado = Resultado.Trim()

            Return Resultado
        Catch ex As Exception
        End Try

        Return ""
    End Function

    Private Function GetParteCadenaOriginal(ByVal Partes As String(), ByVal Indice As Integer) As String
        Try
            If Indice < 0 OrElse Indice > Partes.Length - 1 Then
                Return ""
            End If

            Return Partes(Indice).Trim()
        Catch ex As Exception
        End Try

        Return ""
    End Function

    Private Function FormatearFechaCadenaOriginal(ByVal Fecha As String) As String
        Try
            If Fecha.Length <> 8 Then
                Return ""
            End If

            Return Fecha.Substring(0, 2) & "/" & Fecha.Substring(2, 2) & "/" & Fecha.Substring(4, 4)
        Catch ex As Exception
        End Try

        Return ""
    End Function

    Private Function getIndiceInverso(ByVal _caracter As String, cadena As String) As Integer
        Dim indice As Integer
        Try
            If cadena.Length <= 1 Then
                Return -1
            End If

            indice = cadena.Length - 2

            While indice >= 0
                If cadena(indice) = _caracter Then
                    Return indice
                End If
                indice -= 1
            End While

        Catch ex As Exception
        End Try

        Return -1
    End Function
#End Region

End Class

Public Class ImportarPDFProgresoEventArgs
    Inherits EventArgs

    Public Sub New(ByVal TotalArchivos As Integer,
                   ByVal ArchivosProcesados As Integer,
                   ByVal ArchivosImportados As Integer,
                   ByVal ArchivoActual As String)
        Me.TotalArchivos = TotalArchivos
        Me.ArchivosProcesados = ArchivosProcesados
        Me.ArchivosImportados = ArchivosImportados
        Me.ArchivoActual = ArchivoActual
    End Sub

    Public ReadOnly Property TotalArchivos As Integer
    Public ReadOnly Property ArchivosProcesados As Integer
    Public ReadOnly Property ArchivosImportados As Integer
    Public ReadOnly Property ArchivoActual As String
End Class
