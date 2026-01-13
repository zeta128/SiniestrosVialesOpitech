# 🚦 API de Siniestros Viales

## 📖 Descripción
Esta API permite la gestión y consulta de información relacionada con **siniestros viales**, incluyendo vehículos, víctimas, tipos de siniestro y datos asociados al evento.  
Está diseñada bajo principios de **arquitectura limpia**, priorizando mantenibilidad, escalabilidad y claridad del dominio.

El proyecto fue desarrollado teniendo en cuenta buenas prácticas de ingeniería de software y estándares modernos para APIs REST.

---

## 🏗️ Arquitectura y decisiones clave

La solución implementa una combinación de:

- **Clean Architecture**
- **Domain-Driven Design (DDD)**
- **CQRS (Command Query Responsibility Segregation)**

### Principios aplicados
- SOLID
- Separación de responsabilidades
- Bajo acoplamiento y alta cohesión

### Patrones utilizados
- Repository
- Unit of Work
- Mediator
- Specification (para reglas complejas de consulta)
- Result Pattern para manejo de respuestas



## 🧱 Estructura del proyecto

```text
src/
 ├── SiniestrosViales.Domain
 │    ├── Entities
 │    ├── ValueObjects
 │    └── Specifications
 │
 ├── SiniestrosViales.Application
 │    ├── Features
 │    │    ├── Commands
 │    │    └── Queries
 │    ├── DTOs
 │    ├── Interfaces
 │    └── Common
 │
 ├── SiniestrosViales.Infrastructure
 │    ├── Persistence
 │    ├── Repositories
 
 │
 └── Program.cs
 └── .env

Pasos de ejecución

-Ejecutar los scripts de base de datos asociados
-Ejecutar git clone https://github.com/tu-usuario/siniestros-viales-api.git
cd siniestros-viales-api
dotnet restore
dotnet run --project src/SiniestrosViales.API

 
