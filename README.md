# 🛒 EasyShopper Backend - .NET 9

Este es un backend robusto diseñado bajo los principios de **Clean Architecture**, utilizando **.NET 9**. La aplicación implementa el patrón **CQRS** (Command Query Responsibility Segregation) con **MediatR** y gestiona la seguridad mediante **ASP.NET Core Identity**.

## 🏗️ Estructura de la Solución

La arquitectura se organiza en capas para desacoplar la lógica de negocio de la infraestructura:

```text
src/
├── Domain/                 # Reglas de negocio puras y entidades
│   ├── Entities/           # User (Identity), Product, Order
│   └── Enums/              # Tipos enumerados globales
├── Application/            # Orquestación de lógica de negocio (Casos de uso)
│   ├── Common/             # Interfaces de abstracción y DTOs
│   ├── Users/
│   │   ├── Commands/       # Acciones (Crear, Actualizar)
│   │   ├── Queries/        # Consultas (Listar, Obtener por Id)
│   │   ├── Handlers/       # Lógica de procesamiento de MediatR
│   │   └── Validators/     # Validaciones de entrada (FluentValidation)
│   ├── Products/           # Estructura CQRS para Productos
│   ├── Orders/             # Estructura CQRS para Órdenes
│   └── DependencyInjection/# Registro de MediatR y validadores
├── Infrastructure/         # Implementaciones técnicas y acceso a datos
│   ├── Persistence/        # DbContext, Migraciones y Fábricas de diseño
│   ├── Identity/           # Configuración de ApplicationUser y Roles
│   ├── Repositories/       # Implementación física de las interfaces
│   └── DependencyInjection/# Registro de DB e Identity
└── Api/                    # Punto de entrada de la aplicación (HTTP)
    ├── Controllers/        # Endpoints (Users, Products, Orders)
    └── Program.cs          # Configuración del Pipeline de ASP.NET Core