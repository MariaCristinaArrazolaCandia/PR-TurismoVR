# TurismoTiquipaya API - Guía Rápida

## Introducción
Este repositorio contiene el código fuente y la documentación para la API de TurismoTiquipaya desarrollada en ASP.NET. Esta guía proporciona una visión general rápida para poner en marcha el proyecto.

## Descripción del Proyecto
La API facilita solicitudes de Selección, Inserción y Modificación en la base de datos para el sitio web de administración y el cliente de TurismoTiquipaya.

## Requisitos del Sistema
### Cliente
- **Hardware Mínimo:**
  - Procesador: Cualquier procesador moderno.
  - RAM: 4 GB o más.
  - Espacio en Disco: Suficiente para un navegador web moderno.
- **Software:**
  - Sistema Operativo: Windows, Linux.
  - Navegador Web: Chrome, Firefox, Edge.

### Servidor/Hosting/BD
- **Hardware:**
  - Procesador: Intel Xeon E5/E7, AMD EPYC, u similar.
  - RAM: Mínimo 16 GB.
  - Disco Duro: Mínimo 100 GB (preferiblemente SSD).
- **Software:**
  - Sistema Operativo: Windows Server 2016 o posterior.
  - Servidor Web: IIS (Internet Information Services).
  - Base de Datos: SQL Server.
  - .NET Runtime: Versión correspondiente a tu aplicación ASP.NET.

## Instalación y Configuración
1. Configura la conexión de la API en `appsettings.json` con el nombre de la base de datos y la dirección.
2. En `PhotoTouristSiteService.cs`, establece el URL del Bucket para el almacenamiento de imágenes en Firebase.

## Procedimiento de Hosting
Detalles paso a paso para poner en marcha el sitio web, la API, la base de datos y otros servicios como Firebase.

## Git
- La versión final y los ejecutables están disponibles en el repositorio.

## Personalización y Configuración
- Configura solicitudes GET, PUT, POST y modelos con datos pertinentes.
- Utiliza tokens JWT para seguridad y encripta contraseñas con SHA512.

## Seguridad
- Recomienda el uso de tokens JWT y la encriptación de contraseñas con SHA512.

## Depuración y Solución de Problemas
- Verifica la conexión a la base de datos y los permisos.
- Mantiene la versión de `FirebaseAuthentication.net` en 3.7.2 para el envío de imágenes.

## Glosario de Términos
- Incluye definiciones clave utilizadas en el proyecto.

## Referencias y Recursos Adicionales
- [Documentación API de Microsoft](https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)
- [Uso de paquete NuGet y referencia de Firebase](https://code-maze.com/dotnet-firebase/)

## Herramientas de Implementación
- Lenguajes: C#
- Frameworks: .NET Core, Entity Framework, APIs

## Bibliografía
- [Microsoft API Web con ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)
- [Dotnet-Firebase - Code Maze](https://code-maze.com/dotnet-firebase/)
## VIDEO YOUTUBE
https://youtu.be/B9f4w4N4oAA
