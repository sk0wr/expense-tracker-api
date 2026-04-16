# Expense Tracker API

Pequeña API desarrollada en ASP.NET Core para la gestión de gastos.
Permite registrar, consultar y actualizar gastos.

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Swagger (OpenAPI)
- Persistencia en memoria

## Cómo ejecutar el proyecto

1. Ejecutar el proyecto



## Endpoints disponibles

/swagger/index.html

POST /api/expenses → Crear un gasto
GET /api/expenses → Listar gastos
GET /api/expenses/{id} → Obtener detalle de un gasto
PUT /api/expenses/{id} → Actualizar un gasto


## Ejemplo de uso

json
{
  "title": "Almuerzo",
  "amount": 15,
  "category": "Comida",
  "expenseDate": "2026-04-16T12:00:00",
  "description": "Almuerzo del día"
}

## Notas

Se organizó el proyecto en capas (Controller, Service y Repository) para mantener el código ordenado.

Se utilizó persistencia en memoria ya que el ejercicio no requería base de datos.

Las validaciones básicas se manejan en la capa de servicio para mantener los controladores simples.