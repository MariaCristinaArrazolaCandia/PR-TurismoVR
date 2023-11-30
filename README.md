# Manual Técnico: WEB Administrative

## Introducción:

Este sistema, desarrollado con ASP.NET Web MVC, proporciona una solución dinámica y escalable para la administración de atracciones turísticas en Tiquipaya. Diseñado para la eficiencia y simplicidad, este manual está destinado a administradores y personal técnico familiarizado con operaciones informáticas y conceptos básicos de ASP.NET y MVC.

## Descripción del Proyecto:

El proyecto registra usuarios y lugares turísticos en Tiquipaya mediante una aplicación web ASP.NET MVC. Utiliza una base de datos para almacenar información sobre usuarios y sitios turísticos, integrándose con la API de Bing Maps para mostrar ubicaciones geográficas en un mapa.

## Roles/Integrantes del Equipo:

- Maria Cristina Arrazola Candia - Team Líder y Desarrolladora
- Devon Anderson Sandoval Berrios – Desarrollador

## Arquitectura del Software:

### Componentes Principales:

- **Controllers:** Actúan como intermediarios entre vistas y modelos, gestionando las acciones del usuario.
- **Models:** Representan la lógica de negocios y datos del sistema, manejando operaciones en la base de datos.
- **Views:** Plantillas que generan la interfaz de usuario utilizando Razor para HTML dinámico.
- **Data:** Contiene el DbContext para la configuración de la conexión y mapeo de objetos usando Entity Framework.

### Interacciones:

- **Flujo de Trabajo Estándar:** El enrutamiento de ASP.NET MVC dirige las solicitudes al controlador adecuado, que interactúa con el modelo y presenta la vista correspondiente.

- **Interacción con la Base de Datos:** Los modelos utilizan el DbContext para operaciones CRUD, traduciendo a consultas SQL ejecutadas por Entity Framework.

- **Integración con Servicios Externos:** Se utilizan DTOs para comunicarse con servicios externos como la API de Bing Maps.

## Integración con Servicios Externos: API de Bing Maps

### Obtención de una Clave de API de Bing Maps:

1. Visita [Bing Maps Dev Center](https://www.bingmapsportal.com/).
2. Inicia sesión o regístrate.
3. Crea un nuevo proyecto y obtén la clave de API asociada.

### Utilización de Credenciales en la Aplicación:

Reemplaza la clave de API en `Create.cshtml` en la sección de scripts.

```html
credentials: 'TU_CLAVE_DE_API',
```

## Patrones de Diseño Utilizados:

- **Repositorio:** Para abstraer la lógica de acceso a datos.
- **Inyección de Dependencias (DI):** Facilita la inserción de dependencias en controladores sin acoplamiento.
- **Servicio:** Crea servicios para lógica de negocios no específica de modelos o controladores.

## Requisitos del Sistema:

### Cliente:

- **Hardware:** Intel Core i3 o superior, 4 GB RAM, 10 GB de espacio libre, resolución mínima de 1280x720.
- **Software:** Windows 10 Pro/Enterprise, macOS, o Linux con soporte para Docker, Docker Desktop, Navegador Web: Última versión de Chrome, Firefox, Edge.

### Servidor/Hosting/BD:

- **Hardware:** Intel Core i5 o superior, 8 GB RAM, 50 GB de espacio libre.
- **Software:** Sistema operativo compatible con Docker Engine, Docker Compose, Imagen de Docker ASP.NET 7 oficial, Servidor de Base de Datos compatible con Entity Framework.

## Instalación y Configuración:

**Procedimiento de Hosteado/Hosting:**

Detalles paso a paso de la puesta en marcha en hosting para el sitio web, API, base de datos, etc.

**Git:**

- Versión final entregada del proyecto.
- Entrega de compilados ejecutables.

**Personalización y Configuración:**

- Añadir modelos.
- Actualizar DbContext.
- Añadir controladores.
- Crear DTOs.
- Actualizar vistas.

## Gestión de Usuarios:

### Crear un Nuevo Usuario:

1. Navega a "Crear Usuario" en el menú de administración.
2. Completa el formulario con la información requerida.
3. Selecciona el rol y género.
4. Haz clic en "Crear".

### Editar/Eliminar Usuario:

- Accede a "Editar Usuario" o "Eliminar Usuario" según sea necesario.
- Selecciona el usuario.
- Actualiza o confirma la acción.

### Listar Usuarios:

- Explora "Lista de Usuarios" para ver detalles y acceder a opciones adicionales.

## Mensajes de Error:

- Mensajes explicativos en caso de errores.
- Asegúrate de completar campos obligatorios y seguir el formato correcto.

## Seguridad:

- Configuración de encabezados HTTP, como Content Security Policy (CSP).
- Prevención de ataques XSS e inyección SQL.
- Limitación de permisos en archivos y directorios en el servidor.

## Sesiones Login:

### Iniciar/Cerrar Sesión:

- Visita la página de inicio de sesión.
- Ingresa credenciales y haz clic en "Iniciar Sesión".
- Selecciona "Cerrar Sesión" para finalizar.

## Depuración y Solución de Problemas:

- Usa `docker logs [CONTAINER_ID]` para revisar registros.
- Utiliza `docker exec -it [CONTAINER_ID] bash` para acceder al shell del contenedor.
- Verifica actualizaciones y compatibilidad de dependencias.

## Glosario de Términos:

- ASP.NET Web MVC, API, Bing Maps, Controllers, Models, Views, DbContext, Entity Framework, DTO, CRUD, Repositorio, Inyección de Dependencias, Servicio, Docker, Contenedor, Docker Compose, Git.

## Referencias y Recursos Adicionales:

- Incluye enlaces o referencias a documentación técnica, tutoriales y foros de soporte.

## Herramientas de Implementación:

- Lenguajes: C#
- Frameworks: ASP.NET Core Web MVC
- APIs de Terceros: Bing Maps

## Bibliografía:

- [Getting a Bing Maps Key - Microsoft Learn](https://learn.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key)
## VIDEO YOUTUBE
https://youtu.be/B9f4w4N4oAA
