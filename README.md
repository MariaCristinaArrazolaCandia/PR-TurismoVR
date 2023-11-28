    Manual Técnico

1.	Introducción:

Me complace presentar un proyecto que busca resaltar la belleza de Tiquipaya a través de la creación de un entorno web accesible y práctico. Este espacio virtual permitirá ingresar datos turísticos de manera sencilla, con la posibilidad de enriquecer la experiencia mediante la inserción de imágenes representativas para cada lugar.

Además, hemos desarrollado una versión móvil del sitio, garantizando así que la información sobre los lugares turísticos de Tiquipaya esté al alcance de todos. Desde un carrusel de imágenes hasta detalles específicos sobre la ubicación en un mapa interactivo, nuestro objetivo es proporcionar una herramienta fácil de usar para que residentes y visitantes descubran todo lo que este encantador pueblo tiene para ofrecer. Estamos emocionados de contribuir al impulso turístico de Tiquipaya con esta plataforma digital simple y efectiva.


2.	Descripción del proyecto:

El proyecto que presento se centra en la creación de un entorno web destinado a destacar y gestionar la riqueza turística de Tiquipaya de manera intuitiva y completa. La plataforma se divide en dos componentes esenciales: la parte web y la versión móvil web responsiva.
Parte Web: En la interfaz web, los usuarios tendrán la capacidad de ingresar datos turísticos fácilmente. Esto incluye la opción de seleccionar la categoría del lugar (como hoteles, iglesias, museos, centros recreativos) o ingresar una nueva categoría. Cada sitio turístico puede ser detalladamente descrito, y la ubicación se puede ingresar directamente desde un mapa interactivo. Los usuarios tendrán la capacidad de editar la información de un lugar turístico, a excepción de las imágenes y la categoría. También podrán eliminar registros según sea necesario, proporcionando flexibilidad en la gestión de la base de datos.
Parte Móvil Web Responsiva: La versión móvil web responsiva ofrece una experiencia visual atractiva. Un carrusel de imágenes, compuesto por las fotos asociadas a los lugares turísticos en la base de datos, permite a los usuarios explorar visualmente la diversidad de Tiquipaya. La pantalla de visualización de lugares turísticos en la móvil muestra todas las ubicaciones en un mapa, permitiendo una visión general y la opción de filtrar lugares por categoría.
Al acceder a los detalles de un lugar turístico, los usuarios encontrarán una presentación completa: la ubicación precisa en el mapa, detalles descriptivos y una galería de imágenes asociadas a ese sitio específico. Esta funcionalidad garantiza que la experiencia de descubrimiento sea completa y atractiva, facilitando a los usuarios la exploración y apreciación de la riqueza turística de Tiquipaya.


3.	Roles / integrantes

1.	Servidor (Web):
•	Responsabilidades:
•	Desarrollo y mantenimiento de la interfaz web.
•	Implementación de todas las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para la gestión de datos turísticos.
•	Garantizar la seguridad y la integridad de la base de datos.
•	Facilitar la capacidad de edición y eliminación de datos turísticos.
2.	Cliente (Móvil):
•	Responsabilidades:
•	Desarrollo y optimización de la versión móvil web responsiva.
•	Implementación de funciones para la visualización de datos turísticos.
•	Creación y gestión del carrusel de imágenes para una experiencia visual atractiva.
•	Garantizar la accesibilidad y la usabilidad en dispositivos móviles.
3.	Notas Adicionales:
•	El cliente (parte móvil) se enfoca principalmente en la visualización de datos y proporciona una interfaz amigable para los usuarios móviles.
•	El servidor (parte web) se encarga de la gestión completa de los datos, incluyendo la capacidad de editar y eliminar registros.
•	Se implementarán medidas de seguridad en la comunicación entre el cliente y el servidor para proteger la integridad de los datos.
•	La separación de roles garantiza una distribución eficiente de tareas, optimizando el rendimiento y la especialización de cada componente del proyecto.
Este enfoque permite una colaboración efectiva entre los dos roles, asegurando que tanto la parte web como la móvil trabajen armoniosamente para ofrecer una experiencia completa y satisfactoria a los usuarios que exploran los tesoros turísticos de Tiquipaya.

4.	Arquitectura del software: 
La arquitectura del software se ha diseñado de manera sólida y eficiente para lograr una implementación robusta y escalable del proyecto, enfocado en la gestión de datos turísticos de Tiquipaya. La estructura general se compone de dos componentes principales: el Servidor (Web) y el Cliente (Móvil).

•	Servidor (Web):

Componentes Principales:

Interfaz de Usuario (UI) Web: Proporciona la interfaz para la gestión de datos turísticos, permitiendo a los usuarios realizar operaciones CRUD.

Lógica de Negocio: Gestiona la lógica detrás de las operaciones CRUD, la validación de datos y la comunicación con la base de datos.
Base de Datos: Almacena y recupera datos turísticos, con medidas de seguridad para garantizar la integridad de la información.

Interacciones:

La UI Web se comunica con la Lógica de Negocio para realizar operaciones CRUD.

La Lógica de Negocio interactúa con la Base de Datos para almacenar y recuperar datos.

Patrones de Diseño:

Modelo-Vista-ViewModel (MVVM): Utilizado para separar la lógica de negocio, la presentación y la gestión de datos, facilitando la escalabilidad y mantenimiento.

•	Cliente (Móvil):

Componentes Principales:

Interfaz de Usuario (UI) Móvil Web Responsiva: Ofrece una experiencia visual atractiva para la visualización de datos turísticos en dispositivos móviles.

Módulo de Visualización de Datos: Gestiona la presentación de información, incluyendo el carrusel de imágenes y la visualización de lugares turísticos en el mapa.

Interacciones:

La UI Móvil se comunica con el Servidor para recuperar datos turísticos.

El Módulo de Visualización de Datos se encarga de presentar la información de manera efectiva.

Patrones de Diseño:

Diseño Responsivo: Garantiza una experiencia de usuario óptima en una variedad de dispositivos móviles.

Arquitectura de Cliente-Servidor: Facilita la comunicación eficiente entre el cliente móvil y el servidor web.


5.	Requisitos del sistema:
•	Requerimientos de Hardware (mínimo): (cliente)

Dispositivo Móvil o Tableta.
Conexión a Internet para acceder al entorno web responsivo.
Pantalla táctil recomendada para una experiencia de usuario óptima.

•	Requerimientos de Software: (cliente)

Navegador web actualizado compatible con estándares HTML5 y CSS3 (Chrome, Edge, Opera, Brave, Safari).
Conexión a Internet estable para la visualización de datos en tiempo real.
Sistema operativo compatible: iOS, Android u otros sistemas móviles comunes.
•	Requerimientos de Hardware (server/ hosting/BD)

Servidor:

Memoria RAM mayor igual a 4gb para soportar la carga de trabajo del servidor y las operaciones de la base de datos.
Almacenamiento en disco con suficiente espacio para el sistema operativo, la aplicación, y los datos de la base de datos.


Hosting:

Conexión a Internet para garantizar la accesibilidad del servidor desde cualquier ubicación y poder visualizar los mapas de manera eficiente.
Base de Datos SQL Server (LocalDB):

Espacio de almacenamiento suficiente para la base de datos, los registros y las imágenes asociadas a los lugares turísticos.
Instalación de Microsoft SQL Server (LocalDB) en el servidor.

•	Requerimientos de Software (server/ hosting/BD)

Servidor:

Sistema operativo compatible con el servidor web y la base de datos, preferiblemente Windows Server.
Entorno de ejecución con soporte para navegadores web modernos como Chrome, Edge, Opera, Brave, Safari.

Base de Datos (LocalDB):

Microsoft SQL Server (LocalDB) instalado y configurado en el servidor.


6.	Instalación y configuración: 

1.	Descarga y Preparación:
•	Descarga los archivos "WEB.zip" y "ParteMovilFinal.zip" desde el repositorio en GitHub.
•	Descomprime ambas carpetas en la ubicación deseada en tu sistema.
2.	Requisitos Previos:
•	Asegúrate de tener instalado Visual Studio con los componentes de Razor Pages y ASP.NET.
3.	Configuración de la Parte Web:
•	Abre el archivo de solución "CRUD3.sln" ubicado en la carpeta "WEB" con Visual Studio.
•	Recompila la solución en Visual Studio.
•	Abre la consola de paquetes NuGet y ejecuta el comando: Update-Database.
•	Si tienes Visual Studio y SQL Server instalados, este comando actualizará la base de datos.
4.	Configuración de la Parte Móvil:
•	Abre el archivo de solución "CRUD3.sln" ubicado en la carpeta "ParteMovilFinal" con Visual Studio.
•	Recompila la solución en Visual Studio.
•	Abre la consola de paquetes NuGet y ejecuta el comando: Update-Database.
•	Al igual que en la parte web, este comando actualizará la base de datos.
5.	Verificación y Ejecución:
•	Asegúrate de que todos los pasos anteriores se hayan completado correctamente.
•	Ejecuta la aplicación desde Visual Studio.
•	Accede a la interfaz web desde un navegador compatible (Chrome, Edge, Opera, Brave, Safari).
•	Verifica que la versión móvil responda correctamente en dispositivos móviles.

7.	PROCEDIMIENTO DE HOSTEADO / HOSTING (configuración)
•	Sitio Web.
•	B.D.
•	API / servicios Web
•	Otros (firebase, etc.)

Dado que el proyecto se ejecuta localmente y no se ha contemplado un entorno de hosting externo, el enfoque principal recae en asegurarse de que SQL Server esté correctamente instalado y configurado, junto con Visual Studio para ejecutar la aplicación localmente. A continuación, se detallan los pasos:
1.	Configuración de SQL Server:
•	Asegúrate de tener SQL Server instalado en tu sistema.
•	Accede al SQL Server Management Studio (SSMS).
•	Verifica que el servicio de SQL Server esté en ejecución.
•	Si es necesario, crea una instancia de LocalDB y configura las credenciales de acceso.
2.	Configuración de Visual Studio:
•	Abre el proyecto con Visual Studio.
•	Asegúrate de que las configuraciones de conexión a la base de datos en el archivo appsettings.json (o cualquier otro archivo de configuración relevante) estén correctamente establecidas para tu entorno local.
•	Verifica que la cadena de conexión coincida con la configuración de SQL Server.
3.	Ejecución de la Aplicación Localmente:
•	Recompila la solución en Visual Studio para asegurarte de que todos los cambios se reflejen.
•	Ejecuta la aplicación desde Visual Studio para iniciar el servidor web local.

8.	GIT : 
•	Versión final entregada del proyecto.
•	Entrega compilados ejecutables

9.	Seguridad: 

Almacenamiento Seguro de Imágenes:

Cada imagen almacenada debería ser cifrada con su propia llave única.
Utiliza algoritmos de cifrado robustos para garantizar la seguridad de las imágenes almacenadas.
Protege las claves de cifrado con medidas de seguridad adicionales,


10.	Depuración y solución de problemas:

Problema Común: Detención del Proyecto al no Ingresar una Imagen:

Identificación del Problema:

La aplicación puede detenerse si no se proporciona una imagen al realizar la operación de inserción.

Solución:
No olvidar el insertar imagen en esa sección.

11.	Glosario de términos: 
Entorno Web Responsivo:

Un diseño web que se adapta automáticamente al tamaño de la pantalla del dispositivo, proporcionando una experiencia de usuario óptima tanto en computadoras de escritorio como en dispositivos móviles.

CRUD:

Acrónimo de "Crear, Leer, Actualizar, Eliminar", se refiere a las operaciones básicas de gestión de datos en sistemas de información.

Razor Pages:

Un marco de trabajo de ASP.NET que facilita la construcción de páginas web en el lado del servidor con una sintaxis sencilla y concisa.

API:

Acrónimo de "Interfaz de Programación de Aplicaciones", proporciona un conjunto de reglas y herramientas para la creación de software y aplicaciones.

ORM (Mapeo Objeto-Relacional):

Un enfoque de programación que permite el acceso a bases de datos relacionales utilizando objetos de programación en lugar de consultas SQL directas.

SQL Server (LocalDB):

Una versión ligera y de fácil instalación de Microsoft SQL Server diseñada para el desarrollo y pruebas locales.

Hosting:

El proceso de proporcionar un entorno para que una aplicación web, base de datos u otro servicio esté disponible y accesible en la red.

HTTPS:

Protocolo seguro de transferencia de hipertexto, proporciona una capa adicional de seguridad al cifrar la comunicación entre el navegador del usuario y el servidor web.

OAuth 2.0:

Un protocolo de autorización ampliamente utilizado que permite que las aplicaciones obtengan acceso a recursos en nombre de un usuario.

Cross-Site Scripting (XSS):

Un tipo de ataque de seguridad en el que un atacante inyecta código malicioso en una página web visitada por otros usuarios.

Cross-Site Request Forgery (CSRF):

Un tipo de ataque en el que un atacante engaña al navegador de un usuario para que realice acciones no deseadas en una aplicación web en la que el usuario está autenticado.

Git:

Un sistema de control de versiones distribuido que permite el seguimiento de cambios en el código fuente durante el desarrollo de software.

Depuración:

Proceso de identificación y corrección de errores o problemas en el código de un programa o aplicación.

Consola de Paquetes NuGet:

Herramienta en Visual Studio que permite la instalación, actualización y gestión de paquetes NuGet en un proyecto.

12.	Referencias y recursos adicionales: 

1. **ASP.NET Core Documentation:**
   - [ASP.NET Core Documentation]( https://docs.microsoft.com/en-us/aspnet/core/): Documentación oficial de ASP.NET Core proporcionada por Microsoft.

2. **Entity Framework Core Documentation:**
   - [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/): Documentación oficial de Entity Framework Core.

3. **Bootstrap Documentation:**
   - [Bootstrap Documentation](https://getbootstrap.com/docs/4.6/getting-started/introduction/): Documentación oficial de Bootstrap para la creación de interfaces web responsivas.

4. **SQL Server Documentation:**
   - [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/): Documentación oficial de Microsoft SQL Server.

5. **Visual Studio Documentation:**
   - [Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio/): Recursos y documentación oficial de Visual Studio.

6. **Git Documentation:**
   - [Git Documentation](https://git-scm.com/doc): Documentación oficial de Git para la gestión de control de versiones.

7. **GitHub Guides:**
   - [GitHub Guides](https://guides.github.com/): Recursos y guías proporcionadas por GitHub para comprender y utilizar la plataforma.

8. **Stack Overflow:**
   - [Stack Overflow](https://stackoverflow.com/): Comunidad en línea donde los desarrolladores pueden hacer preguntas y encontrar respuestas sobre problemas específicos de programación.

9. **NuGet Documentation:**
   - [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/): Documentación oficial de NuGet para la gestión de paquetes en proyectos.

10. **Mozilla Developer Network (MDN):**
    - [MDN Web Docs](https://developer.mozilla.org/en-US/docs/Web): Recursos completos para el desarrollo web, incluyendo referencias de HTML, CSS, y JavaScript.

Estos enlaces proporcionan acceso a documentación técnica, tutoriales y recursos comunitarios que pueden ser valiosos durante el desarrollo, implementación y mantenimiento del proyecto turístico de Tiquipaya.

13.	Herramientas de Implementación:


1.	Lenguajes de Programación:
•	C#: Utilizado en el desarrollo de la aplicación web mediante ASP.NET y Razor Pages.
•	HTML y CSS: Para la estructura y estilo de las páginas web.
•	JavaScript: Para la lógica del lado del cliente y la interactividad en la parte web móvil.
2.	Frameworks:
•	ASP.NET Core: Utilizado para desarrollar la aplicación web, proporciona una arquitectura modular y de alto rendimiento.
•	Entity Framework Core: Framework ORM que simplifica el acceso y manipulación de datos en la base de datos SQL Server.
•	Bootstrap: Framework de diseño web para la creación de interfaces responsivas y atractivas.
3.	Base de Datos:
•	SQL Server (LocalDB): Versión ligera de SQL Server utilizada para el desarrollo local y pruebas.
4.	Herramientas de Desarrollo:
•	Visual Studio: Entorno de desarrollo integrado (IDE) utilizado para la creación y gestión del proyecto.
•	SQL Server Management Studio (SSMS): Herramienta para la administración y desarrollo de bases de datos SQL Server.
•	Git: Sistema de control de versiones para el seguimiento de cambios en el código fuente.
5.	Herramientas de Control de Versiones y Colaboración:
•	GitHub: Plataforma de desarrollo colaborativo que permite el alojamiento de proyectos, control de versiones y colaboración entre desarrolladores.
6.	Herramientas de Seguridad:
•	HTTPS: Protocolo de transferencia seguro utilizado para cifrar la comunicación entre el navegador y el servidor.
•	OAuth 2.0: Protocolo de autorización utilizado para autenticar y autorizar a usuarios y aplicaciones.
7.	Herramientas Adicionales:
•	NuGet: Plataforma que facilita la gestión y distribución de paquetes de software, utilizado para la instalación de bibliotecas y dependencias.
•	Consola de Paquetes NuGet: Herramienta en Visual Studio para la gestión de paquetes NuGet en un proyecto.
•	Google maps APIs:  Herramienta para control de los mapas 


14.	Bibliografía
https://dotnet.microsoft.com/es-es/apps/aspnet
https://learn.microsoft.com/es-es/aspnet/overview
https://dotnet.microsoft.com/es-es/learn/aspnet/what-is-aspnet
https://www.ionos.es/digitalguide/paginas-web/desarrollo-web/que-es-aspnet/

