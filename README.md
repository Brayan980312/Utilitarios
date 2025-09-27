# 🛠️ Utilitarios

**Utilitarios** es una librería desarrollada en **ASP.NET Core 8** que centraliza componentes y funcionalidades comunes, con el fin de estandarizar, simplificar y mejorar la mantenibilidad de otros proyectos dentro de la organización.

Su propósito es **evitar duplicación de código** y promover **buenas prácticas de desarrollo**, garantizando consistencia en la lógica transversal de las aplicaciones.

---

## Tabla de contenidos

1. [Características principales](#-características-principales)
2. [Arquitectura y diseño](#-arquitectura-y-diseño)
3. [Requisitos previos](#-requisitos-previos)
4. [Instalación](#️-instalación)
5. [Uso básico](#-uso-básico)
6. [Ejemplos detallados](#-ejemplos-detallados)
7. [Buenas prácticas y seguridad](#-buenas-prácticas-y-seguridad)
8. [Contribución](#-contribución)
9. [Futuras mejoras](#-futuras-mejoras)
10. [Licencia](#-licencia)

---

## Características principales

El proyecto incluye los siguientes módulos:

- **Mensajes por defecto**  
  Catálogo centralizado de mensajes estándar (errores, validaciones, confirmaciones).

- **`ICrudSqlRepositorio` (con implementación genérica)**  
  Contrato y clase base que implementa operaciones CRUD sobre SQL, facilitando la reutilización.

- **`EntidadBase`**  
  Clase padre con propiedades comunes como `Id`, `FechaCreacion`, `FechaModificacion`, `UsuarioCreacion`, etc.

- **Extensiones**  
  Contiene `DynamicFilterExtensions`, que permite transformar un objeto con propiedades en una expresión de filtrado (`Expression<Func<T,bool>>`).  
  Útil para construir consultas dinámicas en LINQ o Entity Framework de forma automática y flexible.

- **Helpers**  
  Utilidades auxiliares para tareas frecuentes (conversión de datos, manejo de excepciones, etc.).

- **Encriptación**  
  Funciones para encriptar y desencriptar información sensible.

- **Input Sanitizer**  
  Limpieza y normalización de entradas de usuario para mitigar ataques de inyección.

- **Contraseñas con AspNet Identity**  
  Políticas y helpers para manejar contraseñas seguras, integradas con **ASP.NET Identity**.

---

## Arquitectura y diseño

El proyecto sigue una arquitectura modular y desacoplada, permitiendo:

- **Reutilización**: Cada módulo puede ser consumido independientemente.
- **Extensibilidad**: Nuevos componentes se pueden agregar sin afectar lo existente.
- **Seguridad**: Incluye sanitización y cifrado de datos sensibles.
- **Mantenibilidad**: Código organizado y probado para uso transversal.

---

## Requisitos previos

- **.NET 8 SDK**
- Acceso a los proyectos donde se referenciará esta librería

---

## Instalación

Puedes referenciarlo directamente al proyecto que lo requieres
