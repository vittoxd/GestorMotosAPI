# GestorMotos API

Sistema de gestión para talleres mecánicos de motos, construido con **.NET 10** y **C#**. Permite registrar motos, mecánicos y órdenes de trabajo a través de una REST API con interfaz web integrada.

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-11-239120?style=flat&logo=csharp)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=flat&logo=sqlite)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=flat&logo=dotnet)

## Características

- CRUD completo de **motos** (patente única, búsqueda por RUT dueño)
- CRUD completo de **mecánicos** (RUT único, especialidades)
- Gestión de **órdenes de trabajo** (asignación moto + mecánico, seguimiento de estado)
- Actualización parcial de estado de órdenes (`PATCH`)
- Interfaz web integrada (HTML/CSS/JS vanilla, servida como archivos estáticos)
- Documentación automática con **Swagger / OpenAPI**
- Base de datos **SQLite** con migraciones via Entity Framework Core
- Índices de búsqueda optimizados en patente y RUT

## Tecnologías

| Capa | Tecnología |
|---|---|
| Backend | C# / .NET 10, ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Base de datos | SQLite |
| Frontend | HTML, CSS, JavaScript (Vanilla) |
| Documentación | Swagger / OpenAPI |

## Estructura del proyecto

```
GestorMotosAPI/
├── Controllers/
│   └── OrdenesTrabajoController.cs   # Endpoints de órdenes de trabajo
├── Data/
│   └── AppDbContext.cs               # Contexto de base de datos
├── Models/
│   ├── Moto.cs                       # Modelo con índice único en Patente
│   ├── Mecanico.cs                   # Modelo con índice único en RUT
│   └── OrdenTrabajo.cs               # Relación Moto ↔ Mecánico
├── Migrations/                       # Historial de migraciones EF Core
├── wwwroot/
│   ├── index.html                    # Interfaz web del sistema
│   ├── app.js                        # Lógica frontend
│   └── Estilo.css                    # Estilos
├── appsettings.json
└── Program.cs
```

## Endpoints de la API

### Motos — `/api/Moto`

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/Moto` | Listar todas las motos |
| `GET` | `/api/Moto/{id}` | Obtener moto por ID |
| `POST` | `/api/Moto` | Registrar nueva moto |
| `PUT` | `/api/Moto/{id}` | Actualizar moto |
| `DELETE` | `/api/Moto/{id}` | Eliminar moto |

### Mecánicos — `/api/Mecanico`

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/Mecanico` | Listar todos los mecánicos |
| `GET` | `/api/Mecanico/{id}` | Obtener mecánico por ID |
| `POST` | `/api/Mecanico` | Registrar nuevo mecánico |
| `PUT` | `/api/Mecanico/{id}` | Actualizar mecánico |
| `DELETE` | `/api/Mecanico/{id}` | Eliminar mecánico |

### Órdenes de Trabajo — `/api/OrdenesTrabajo`

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/OrdenesTrabajo` | Listar órdenes (incluye moto y mecánico) |
| `POST` | `/api/OrdenesTrabajo` | Crear nueva orden de trabajo |
| `PATCH` | `/api/OrdenesTrabajo/{id}/estado` | Actualizar estado de una orden |
| `DELETE` | `/api/OrdenesTrabajo/{id}` | Eliminar orden |

## Cómo ejecutar localmente

### Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Pasos

```bash
# Clonar el repositorio
git clone https://github.com/vittoxd/GestorMotosAPI.git
cd GestorMotosAPI/GestorMotosAPI

# Aplicar migraciones (crea taller.db automáticamente)
dotnet ef database update

# Ejecutar
dotnet run
```

La aplicación estará disponible en `https://localhost:7258`.

- **Interfaz web:** `https://localhost:7258`
- **Swagger UI:** `https://localhost:7258/swagger`

## Ejemplo de uso

### Registrar una moto

```json
POST /api/Moto
{
  "patente": "ABCD12",
  "marca": "Honda",
  "modelo": "CB500X",
  "año": 2022,
  "kilometraje": 15000,
  "rutDueno": "12.345.678-9"
}
```

### Crear una orden de trabajo

```json
POST /api/OrdenesTrabajo
{
  "motoId": 1,
  "mecanicoId": 2,
  "descripcion": "Cambio de aceite y revisión de frenos",
  "costo": 45000
}
```

### Actualizar estado de una orden

```json
PATCH /api/OrdenesTrabajo/1/estado
"En Proceso"
```

Estados disponibles: `En Espera`, `En Proceso`, `Completado`

## Autor

**Victor Gonzalez** — [github.com/vittoxd](https://github.com/vittoxd)
