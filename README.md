# Product API - .NET

Implementación de una REST API desarrollada en .NET como solución para la prueba técnica.
La API permite crear, actualizar y consultar productos, integrándose con un servicio externo para obtener descuentos y aplicando buenas prácticas de arquitectura, validación y pruebas.

---

# Arquitectura

El proyecto está estructurado utilizando arquitectura en capas (N-Layer Architecture):

## Responsabilidad de cada capa

### ProductApi.API
Capa de presentación.
Contiene los Controllers, Swagger y Middlewares.

### ProductApi.BLL
Capa de lógica de negocio.
Contiene servicios, DTOs, interfaces y validaciones.

### ProductApi.DAL
Capa de acceso a datos.
Implementa la persistencia utilizando Repository Pattern.

### ProductApi.Entities
Contiene la entidad Product.

---

# Patrones y buenas prácticas aplicadas

- Repository Pattern
- Dependency Injection
- Middleware Pattern
- FluentValidation
- TDD
- SOLID

---

# Funcionalidades implementadas

- Crear producto (POST)
- Actualizar producto (PUT)
- Obtener producto por ID (GET)
- Persistencia en SQL Server
- Obtención de descuentos mediante servicio externo
- Cálculo de precio final
- Cache de estados del producto
- Logging del tiempo de respuesta de cada request

---

# Tecnologías utilizadas

- .NET
- C#
- ASP.NET Core Web API
- SQL Server
- Dapper
- Swagger / OpenAPI
- FluentValidation
- xUnit
- Moq

---

# Paquetes NuGet principales

## ProductApi.API

- FluentValidation.AspNetCore
- Microsoft.Extensions.Caching.Memory

## ProductApi.DAL

- Microsoft.Data.SqlClient

## ProductApi.Tests

- xUnit
- Moq
- FluentAssertions

---

# Base de datos

La aplicación utiliza SQL Server.

Crear la base de datos ejecutando el script correspondiente y configurar la cadena de conexión en: ProductApi.API/appsettings.json
