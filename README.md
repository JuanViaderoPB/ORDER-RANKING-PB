# ORDER-RANKING-PB

---

# INTEGRANTES

- Juan Camilo Viadero Muriel

---

# DESCRIPCIÓN DEL PROBLEMA

Una tienda en línea necesita un sistema que clasifique los pedidos según reglas de negocio y determine el costo de envío.

La clasificación depende de:

- Monto del pedido
- Tipo de cliente
- Cantidad de ítems
- Ciudad destino

El sistema debe:

- Determinar la categoría de despacho
- Calcular el costo final de envío
- Mostrar la información del pedido
- Permitir registrar múltiples pedidos mediante un menú interactivo

El proyecto fue refactorizado aplicando programación modular, separando:

- Entrada y salida de datos
- Validaciones
- Lógica de negocio
- Orquestación del sistema

---

# IPO

| Entradas      | Proceso | Salidas |
|---|---|---|
| monto | Evaluar si aplica envío gratis | Categoría de despacho |
| ciudad | Evaluar si aplica envío express | Costo de envío |
| tipoCliente | Aplicar recargo por exterior | Mensaje al cliente |
| items | Calcular categoría final | Resumen de pedidos |

---

# VARIABLES

| Nombre | Tipo | Propósito |
|---|---|---|
| monto | decimal | Valor total del pedido |
| ciudad | string | Destino del envío |
| tipoCliente | string | Tipo de cliente |
| items | int | Cantidad de productos |
| categoria | string | Tipo de envío asignado |
| costoEnvio | decimal | Costo final del envío |
| pedidos | List<Pedido> | Lista de pedidos registrados |

---

# ARQUITECTURA MODULAR

El sistema fue organizado en módulos con responsabilidad única.

| Función | Responsabilidad |
|---|---|
| Main() | Coordina el flujo principal |
| MostrarMenu() | Muestra el menú del sistema |
| LeerOpcionMenu() | Valida la opción seleccionada |
| IngresarPedidos() | Gestiona el ingreso de pedidos |
| LeerCantidadPedidos() | Valida cantidad de pedidos |
| CrearPedido() | Construye un pedido completo |
| LeerMonto() | Solicita y valida monto |
| LeerCiudad() | Solicita y valida ciudad |
| LeerTipoCliente() | Solicita y valida tipo de cliente |
| LeerCantidadItems() | Solicita y valida ítems |
| CalcularCategoria() | Determina categoría de envío |
| CalcularCostoEnvio() | Calcula costo final |
| MostrarResultados() | Muestra resultados registrados |

---

# JERARQUÍA MODULAR

```text
Main
 ├── MostrarMenu
 ├── LeerOpcionMenu
 ├── IngresarPedidos
 │     ├── LeerCantidadPedidos
 │     ├── CrearPedido
 │     │     ├── LeerMonto
 │     │     ├── LeerCiudad
 │     │     ├── LeerTipoCliente
 │     │     ├── LeerCantidadItems
 │     │     ├── CalcularCategoria
 │     │     └── CalcularCostoEnvio
 └── MostrarResultados
```

---

# REGLAS DE NEGOCIO

## ENVÍO GRATIS

Se aplica cuando:

- El monto es mayor o igual a 150000
- El cliente es recurrente

Costo base:

```text
$0
```

---

## ENVÍO EXPRESS

Se aplica cuando:

- La cantidad de ítems es mayor o igual a 5
- O el monto es mayor o igual a 300000

Costo base:

```text
$30000
```

---

## ENVÍO ESTÁNDAR

Se aplica cuando no cumple las condiciones anteriores.

Costo base:

```text
$15000
```

---

## RECARGO POR EXTERIOR

Si la ciudad es:

```text
exterior
```

Se agrega un recargo de:

```text
$25000
```

---

# CASOS DE PRUEBA

## CASO 1 — ENVÍO GRATIS

### Entrada

```text
Monto = 200000
Cliente = recurrente
Items = 2
Ciudad = local
```

### Resultado esperado

```text
Categoría = Envío Gratis
Costo = 0
```

---

## CASO 2 — ENVÍO EXPRESS

### Entrada

```text
Monto = 100000
Cliente = nuevo
Items = 6
Ciudad = local
```

### Resultado esperado

```text
Categoría = Envío Express
Costo = 30000
```

---

## CASO 3 — ENVÍO ESTÁNDAR

### Entrada

```text
Monto = 80000
Cliente = nuevo
Items = 2
Ciudad = local
```

### Resultado esperado

```text
Categoría = Envío Estándar
Costo = 15000
```

---

## CASO 4 — ENVÍO EXTERIOR

### Entrada

```text
Monto = 150000
Cliente = recurrente
Items = 1
Ciudad = exterior
```

### Resultado esperado

```text
Categoría = Envío Gratis
Costo = 25000
```

---

# SEPARACIÓN DE RESPONSABILIDADES

## UI (Entrada/Salida)

Funciones encargadas de interacción con consola:

- MostrarMenu()
- LeerMonto()
- LeerCiudad()
- LeerTipoCliente()
- MostrarResultados()

---

## LÓGICA

Funciones encargadas de cálculos y reglas de negocio:

- CalcularCategoria()
- CalcularCostoEnvio()

---

## ORQUESTACIÓN

Funciones encargadas de coordinar el sistema:

- Main()
- IngresarPedidos()
- CrearPedido()

---

# DOCUMENTACIÓN XML

Las funciones principales incluyen documentación XML utilizando:

- `<summary>`
- `<param>`
- `<returns>`

Esto mejora:

- Legibilidad
- Mantenimiento
- Escalabilidad
- Comprensión del código

---

# INSTRUCCIONES DE EJECUCIÓN

1. Ejecutar el programa.
2. Seleccionar una opción del menú.
3. Ingresar los datos solicitados.
4. Registrar pedidos.
5. Consultar resultados desde el menú.
6. Salir utilizando la opción 3.

---

# TECNOLOGÍAS UTILIZADAS

- Lenguaje: C#
- Consola .NET
- Programación modular
- Documentación XML

---

# RESULTADO FINAL

El sistema final cumple con:

- Refactorización modular
- Separación de responsabilidades
- Funciones reutilizables
- Validaciones independientes
- Lógica desacoplada
- Arquitectura mantenible
- Documentación XML
- Casos de prueba actualizados

---
