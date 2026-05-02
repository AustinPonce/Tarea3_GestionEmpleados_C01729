Tarea3_GestionEmpleados_C01729

Nombre: Austin Carrillo Ponce
Carnet: C01729

Descripción

Sistema de gestión de empleados con EF Core, búsqueda por Nombre/Apellidos/Departamento (case-insensitive) y paginación.

Instrucciones de ejecución

1. Asegúrate de tener instalado .NET 10 SDK y la herramienta dotnet-ef:
   - dotnet tool install --global dotnet-ef
2. Restaurar paquetes y construir:
   - dotnet restore
   - dotnet build
3. Generar y aplicar migraciones (si no se han aplicado):
   - dotnet ef migrations add InitialCreate -p "GestorDeEmpleados.DA" -s "GestorDeEmpleados.WEB"
   - dotnet ef database update -p "GestorDeEmpleados.DA" -s "GestorDeEmpleados.WEB"
4. Ejecutar la aplicación (desde la carpeta del proyecto Web):
   - dotnet run --project GestorDeEmpleados.WEB

Paginación

- La vista Index utiliza parámetros query: `?busqueda=X&pagina=N`.
- Valores por defecto: `busqueda` vacío, `pagina=1`, `tamano=5`.
- La paginación muestra botones Anterior/Siguiente y el texto "Página X de Y" junto con el total de registros.

Ejemplo de URL con búsqueda

- Mostrar página 1 con resultados que contengan "TI":
  /Empleados?busqueda=TI&pagina=1

Notas

- Archivo de conexión SQLite: `GestorDeEmpleados.WEB/appsettings.json` (por defecto: `Data Source=GestorDeEmpleados.db`).
- El repositorio local está preparado; para subir a GitHub crea un repositorio remoto y ejecuta:
  - git remote add origin <url-del-repositorio>
  - git branch -M main
  - git push -u origin main
