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
<img width="1426" height="746" alt="image" src="https://github.com/user-attachments/assets/a457c1c6-f28d-4474-a6bb-b2727c2feb36" />
<img width="1426" height="746" alt="image" src="https://github.com/user-attachments/assets/5ff57322-0883-4aae-b02c-e06c4149627f" />

- **Leer**: busca una moto por Id y carga los campos.
<img width="1426" height="746" alt="image" src="https://github.com/user-attachments/assets/66ead55d-6589-47fd-a921-3cd9de6f5b70" />
<img width="1426" height="746" alt="image" src="https://github.com/user-attachments/assets/f5958330-ec52-4c8f-b68a-c9c1aeda7b46" />

- **Actualizar**: actualiza la moto actual usando el Id.
<img width="1426" height="746" alt="image" src="https://github.com/user-attachments/assets/bb187dbc-c123-4679-8415-3938068a0b69" />

- **Borrar**: elimina una moto por Id.
<img width="1426" height="746" alt="image" src="https://github.com/user-attachments/assets/9113fea5-8100-4fa1-beff-2e6d747a4f3c" />

## Notas
- La base de datos se guarda en `FileSystem.AppDataDirectory` como `motos.db`.
- El Id es único; si intentas repetirlo, la app te avisará.
