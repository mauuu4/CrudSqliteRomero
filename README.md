# CrudSqliteRomero

Aplicación .NET MAUI para gestionar motos usando SQLite con operaciones CRUD (crear, leer, actualizar y borrar).

## Requisitos
- .NET 10 SDK
- Visual Studio 2026 con el workload de .NET MAUI

## Cómo ejecutar
1. Abre la solución/proyecto en Visual Studio.
2. Selecciona el destino (Windows, MacCatalyst, etc.).
3. Ejecuta el proyecto.

## Cómo funciona
- **Crear**: valida Id y año, y guarda una moto en SQLite.
- **Leer**: busca una moto por Id y carga los campos.
- **Actualizar**: actualiza la moto actual usando el Id.
- **Borrar**: elimina una moto por Id.

## Notas
- La base de datos se guarda en `FileSystem.AppDataDirectory` como `motos.db`.
- El Id es único; si intentas repetirlo, la app te avisará.
