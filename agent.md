# AGENT CONTEXT

Este archivo sirve como memoria operativa del proyecto para sesiones futuras.
Siempre que se haga trabajo relevante, este archivo debe actualizarse con:
- contexto del sistema
- estructura del proyecto
- decisiones importantes
- riesgos detectados
- último trabajo realizado

## Proyecto

- Nombre: `vb.TransferenciasBancariasPDFtoExcel`
- Tipo: aplicación WinForms en VB.NET
- Framework principal: `.NET Framework 4.6.2`
- Objetivo: importar comprobantes/reportes bancarios en PDF, extraer campos con reglas definidas por formato, almacenar resultados en SQLite y exportarlos a Excel.

## Estructura General

- `Codigo Fuente/Bancos_AdministradorPDF/`
  - `AdministradorTicketsBanco/`
    - capa de presentación WinForms
    - formularios de importación, filtros, detalle, bancos y empresas
  - `Capa_Negocio/`
    - lógica de importación de formatos
    - lógica de lectura de PDF
    - extracción de campos
    - exportación a Excel
  - `Capa_Datos/`
    - acceso a SQLite
    - CRUDs de transacciones, formatos, bancos, empleados, vínculos
  - `Capa_Identidad/`
    - entidades del dominio (`I_Transaccion`, `I_Banco`, `I_Empleado`, etc.)
- `Formatos a Importar/`
  - ejemplos de formatos `.nfo`
  - PDFs de prueba
  - archivo `Formato.xlsx`
  - documentación y script de base de datos
- `Renovacion de formato/`
  - binarios, base de datos y documentación adicional

## Flujo Funcional

### 1. Importación de formatos

- Los formatos se definen en archivos `.nfo`.
- Cada `.nfo` tiene una estructura fija de 58 líneas:
  - 7 líneas de metadata del formato
  - 17 nombres de campos
  - 17 cadenas de inicio
  - 17 cadenas de fin
- La carga se hace en:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Negocio/N_ImportarFormato.vb`

### 2. Importación de PDFs

- El PDF se convierte a texto con `iTextSharp`.
- Se compara el texto contra los formatos cargados en BD.
- Si el formato coincide, se extraen campos usando delimitadores de inicio/fin.
- La lógica principal está en:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Negocio/N_ImportarPDF.vb`

### 3. Extracción de campos

- Los campos se manejan como `C0..C17` dentro de `I_Transaccion`.
- Significado principal:
  - `C0`: clave de rastreo
  - `C1`: banco origen
  - `C2`: cuenta origen
  - `C3`: RFC origen
  - `C4`: número de cuenta origen
  - `C5`: banco destino
  - `C6`: cuenta destino
  - `C7`: RFC destino
  - `C8`: número de cuenta destino
  - `C9`: número de registros transmitidos
  - `C10`: concepto de pago
  - `C11`: beneficiario
  - `C12`: referencia
  - `C13`: folio de internet
  - `C14`: importe
  - `C15`: moneda
  - `C16`: fecha
  - `C17`: nombre del archivo
- Clase clave:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Identidad/I_Transaccion.vb`

### 4. Empleados

- Algunos formatos representan dispersiones con múltiples empleados.
- En esos casos se extrae también una lista de empleados desde el texto del PDF.
- El total de registros y el importe consolidado se recalculan desde la lista de empleados.

### 5. Exportación

- La exportación actual usa `Microsoft.Office.Interop.Excel`.
- Genera un archivo `.xlsx` desde la tabla temporal de transacciones.
- Después de exportar, elimina las transacciones exportadas de la base.
- Archivo clave:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Negocio/N_Exportar.vb`

## Base de Datos

- Motor: SQLite
- Clase de conexión:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Datos/DataBase.vb`
- Script de referencia:
  - `Formatos a Importar/Documentos/DBLite.sql`
- Tablas principales:
  - `transaccion`
  - `empleados`
  - `formato`
  - `campos_nombre`
  - `campos_inicio`
  - `campos_fin`
  - `banco`
  - `empresa_externa`
  - `vinculo`
  - `tr_procesada`

## UI / Punto de Entrada

- Formulario principal:
  - `Codigo Fuente/Bancos_AdministradorPDF/AdministradorTicketsBanco/_GUI/GUI_Inicio.vb`
- Desde ahí se puede:
  - importar PDF
  - importar formatos
  - administrar bancos
  - administrar empresas
  - filtrar transacciones
  - exportar a Excel

## Dependencias Relevantes

- `iTextSharp`
- `System.Data.SQLite`
- `Microsoft.Office.Interop.Excel`
- `DocumentFormat.OpenXml` aparece referenciado, pero la exportación principal actual usa Interop

## Hallazgos Importantes

- El parser es configurable por formato, no por banco hardcodeado.
- La coincidencia de datos depende fuertemente de cadenas exactas en el texto extraído del PDF.
- Hay muchas excepciones ignoradas silenciosamente con `Catch ex As Exception` vacío.
- La capa de datos arma SQL por concatenación de strings.
- La referencia a `System.Data.SQLite` usa una ruta absoluta del sistema:
  - `C:\Program Files\System.Data.SQLite\2015\bin\System.Data.SQLite.dll`
- La exportación depende de Excel instalado localmente.
- El script `DBLite.sql` parece desalineado con el código en al menos un punto:
  - la tabla `transaccion` del script mostrado llega hasta `c16`
  - el código utiliza también `c17` para guardar nombre de archivo

## Riesgos Técnicos

- Inyecciones o fallos por comillas simples en textos importados debido a SQL concatenado.
- Portabilidad baja por dependencias del entorno local.
- Trazabilidad baja por manejo silencioso de errores.
- Fragilidad del parser ante cambios mínimos de layout del PDF.
- Posibles inconsistencias entre el modelo de BD documentado y la BD real usada por la app.

## Convenciones Operativas para Futuras Sesiones

- Antes de modificar código, revisar si este archivo sigue vigente.
- Si se analiza una nueva parte del proyecto, agregarla aquí.
- Si se corrige un bug, dejar:
  - problema
  - archivo afectado
  - impacto
- Si se agrega una nueva decisión de arquitectura, documentarla aquí.

## Último Trabajo Realizado

Fecha: `2026-03-19`

Contexto activo de trabajo:
- Actualmente se está trabajando en la función `Importar` del archivo:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Negocio/N_ImportarPDF.vb`
- Esta función es el punto central de la importación de PDFs:
  - lee el texto del archivo
  - identifica el formato
  - invoca la extracción de campos
  - importa empleados cuando aplica
  - inserta la transacción en base de datos
  - registra errores si el formato no coincide o falla la importación

Se realizó un análisis técnico general del proyecto y se concluyó:
- La app importa formatos `.nfo` y PDFs bancarios para extraer campos por delimitadores.
- El almacenamiento intermedio se hace en SQLite.
- La exportación a Excel usa Interop y borra las transacciones exportadas.
- La solución está dividida en capas y es entendible, pero tiene deuda técnica importante en manejo de errores, SQL concatenado y dependencia del entorno.

También se ajustó el control de archivos generados para Git:
- se corrigió `.gitignore` eliminando una línea basura al inicio
- se confirmó política de repositorio: ignorar solo artefactos generados
- se sacaron del índice de Git artefactos autogenerados ya trackeados:
  - `.vs/`
  - `bin/`
  - `obj/`
  - `Bancos/Debug/`
  - `packages/`
- no se tocaron archivos fuente, `.vbproj`, `.resx`, `.nfo`, documentación ni recursos del proyecto

También se agregó un nuevo formato `.nfo` para PEIBO:
- archivo:
  - `Formatos a Importar/20 - PEIBO.nfo`
- criterios de identificación:
  - `Clave de rastreo`
  - `Peibo Fintech`
- configuración:
  - `empleados = 2` para tratarlo como formato de multiples transacciones por pagina
  - `banco_origen = Peibo`
  - `banco_destino` se deja vacio porque puede variar y no es extraible de forma confiable solo con delimitadores simples
- campos extraíbles de forma confiable con este `.nfo`:
  - clave de rastreo
  - nombre del ordenante
  - cuenta del ordenante
  - beneficiario registrado en Peibo
  - nombre de la cuenta destino
  - concepto de pago
  - referencia
  - importe
  - fecha de operación
- campos omitidos intencionalmente en este formato por limitación del parser actual:
  - RFC origen
  - banco destino
  - RFC destino
  - número de cuenta destino
  - folio de internet

Posteriormente se extendió el código para PEIBO:
- archivo:
  - `Codigo Fuente/Bancos_AdministradorPDF/Capa_Negocio/N_ImportarPDF.vb`
- formato afectado:
  - `F020`
- estrategia:
  - además de los delimitadores del `.nfo`, existe un complemento específico `c_f20`
  - dicho complemento interpreta la sección `Cadena Original Información del Pago:` hasta `Sello Digital`
  - la cadena original se normaliza quitando saltos de línea y luego se divide por `|`
- datos que se intentan recuperar desde esa estructura:
  - banco origen
  - nombre del ordenante
  - cuenta ordenante
  - RFC origen
  - banco destino
  - beneficiario en institución financiera
  - cuenta destino
  - RFC destino
  - concepto de pago
  - importe
  - fecha

## Próximos Puntos Útiles a Revisar

- endurecer el parser de extracción
- parametrizar consultas SQLite
- desacoplar la exportación de Excel Interop
- agregar validación formal del archivo `.nfo`
- alinear el script de BD con el modelo real usado por la aplicación
