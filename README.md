# Computer-Box (e-commerce)
### (Proyecto final del curso .NET, organizado por Adecco & Sage y realizado por el grupo 3)

Somos uno de los grupos resultantes del presente curso de programación .NET 22 y este es nuestro proyecto: concretamente, una Ecommerce.

Con este proyecto hemos puesto en práctica todos los conocimientos técnicos, que hemos aprendido y practicado a lo largo del curso, y los hemos utilizado para construir una tienda 'online', la cuál vende ordenadores.

## Tecnologías utilizadas (Requisitos técnicos)

- Angular 14

- Node 16

- C# 10

- .NET 6

- Entity Framework Core 6

- MySQL 8 (vía MySQL Workbench 8)

- npm

- HTML and CSS

- JavaScript

- TypeScript

## IDE utilizado
Visual Studio Community

## Para instalar MySql Server y MySql Workbench en tu sistema
Accede a la dirección de [descarga del instalador de mysql](https://dev.mysql.com/downloads/mysql/), haz clic sobre la imagen principal, descarga el instalador, ejecútalo y sigue los pasos de este hasta finalizar la instalación.  
**NOTA:** Usar el usuario `root` y la contraseña `admin` en el apartado donde nos solicita definir unas claves.
  
## Para instalar C# y .NET en tu sistema
Al instalar `Visual Studio Community`, la ultima versión, y seleccionando todos los paquetes referentes a `C#` y `.NET`, exceptuando las versiones especificas para soportar versiones anteriores de .NET (4.?), ya podras clonar y ejecturar el proyecto.  
[Visual Studio Community](https://visualstudio.microsoft.com/es/vs/community/)
  
  
## Para instalar Angular en tu sistema
Paso 1: Necesitas que "Node.js" (versión 16) y "npm package manager" estén instalados.

Paso 2: Instalar Angular CLI (versión 14)

Run `npm install -g @angular/cli` en tu terminal. 

Paso 3: `npm install ngx-cookie-service --force`  
  
Paso 4: Forzar dependencias `npm install --legacy-peer-deps`  
  
  
## Instruciones Back End  
  
Paso 1: Abrir el proyecto en Visual Studio Community  
  
Paso 2: Ejectuar migraciones (MySQL deve estar activo en el ordenador)
  
```
cd net_grupo_3

dotnet ef migrations add Initial -o Db/Migrations -c net_grupo_3.Db.AppDbContext -v

dotnet ef database update Initial -c net_grupo_3.Db.AppDbContext
```
  
Paso 3: Llenar la Base de Datos  

1. Abrir MySQL Workbench  
2. Abrir la Base de Datos (ecommerce) que ha generado la migración
3. Abrir la vista de cualquier tabla y en la pestaña de instrucciones copiar y ejectuar el siguiente código SQL.
```
use ecommerce;
INSERT INTO categories VALUES (1,'PC','pc','../assets/img/category/pc.jpg'),(2,'Portátil','portatil','../assets/img/category/portatil.jpg');
INSERT INTO manufacturer VALUES (1,'HP','hp','0001-01-01 00:00:00.000000','../assets/img/manufacturers/hp.png'),(2,'Dell','dell','0002-02-02 00:00:00.000000','../assets/img/manufacturers/dell.png'),(4,'MSI','msi','2022-01-01 00:00:00.000000','../assets/img/manufacturers/msi.png'),(5,'Acer','acer','0001-01-01 00:00:00.000000','../assets/img/manufacturers/acer.png');
INSERT INTO product VALUES (1,'Dell optiplex 790','dell_optiplex_790',85.00,118.00,2,21.00,'/pc/dell/d1.jpg','Intel I5-2400 Quad Core I5','ddr3 8 GB',NULL,'0002-02-02 00:00:00.000000',2,1,NULL,NULL),(2,'Dell VOSTRO 3888','dell_vostro_3888',450.00,544.00,3,21.00,'/pc/dell/d2.jpg','Intel Core i5-12400 ',NULL,'Intel UHD Graphics 730 con memoria gráfica compartida ','2022-09-09 00:00:00.000000',2,1,NULL,NULL),(3,'DELL Vostro 3681','dell_vostro_3681',850.00,913.00,4,21.00,'/pc/dell/d3.jpg','i7-10700 SFF Intel','DDR4-SDRAM ',NULL,'2022-11-23 00:00:00.000000',2,1,NULL,NULL),(4,'Dell Inspiron 7700','dell_inspiron_7700',1350.00,1149.00,3,21.00,'/pc/dell/d4.jpg','Intel Core i7-1165G7','8 GB','Intel Iris Xe Graphics','2022-11-05 00:00:00.000000',2,1,NULL,NULL),(5,'HP Elite 8300','hp_elite_8300',250.00,337.00,2,21.00,'/pc/hp/h1.jpg','Intel Core i7-3770 caché de 8M, hasta 3,90 GHz ','DDR3 32 GB ',NULL,'2022-11-26 00:00:00.000000',1,1,NULL,NULL),(6,'HP 27-ca0008ns','hp_27-ca0008ns',750.00,899.00,3,0.00,'/pc/hp/h2.jpg','AMD Ryzen 7 5700U','DDR4-3200 MHz 16 GB','Gráficos Integrada AMD Radeon ','2022-11-23 00:00:00.000000',1,1,NULL,NULL),(7,'HP ENVY TE01-1040ns','hp_enviy_teo1-1040ns',1150.00,1355.85,3,21.00,'/pc/hp/h3.jpg','i7-10700F frecuencia base de 2,9 GHz, hasta 4,8 GHz','DDR4-2933 MHz de 32 GB ','NVIDIA GeForce RTX 3060 (GDDR6 de 12 GB dedicada) ','2022-11-22 00:00:00.000000',1,1,NULL,NULL),(8,'MAG Infinite 11TG-1413EU','mag_infinite_11tg-1413EU',850.00,1199.00,2,21.00,'/pc/msi/m1.jpg','Intel Core i5-11400F','16GB','RTX 3060 Ti VENTUS 2X LHR','2022-11-05 00:00:00.000000',4,1,NULL,NULL),(9,'MSI MPG Trident AS 12TC-201IT','msi_mpg_trident_as_12tc-201IT',1250.00,1699.92,3,21.00,'/pc/msi/m2.jpg','Intel Core i5-12400F','16GB','NVIDIA GeForce RTX 3060 Ventus 2X 12G','2022-11-25 00:00:00.000000',4,1,NULL,NULL),(31,'Acer Nitro 5 AN515-58','acer_nitro-aN515-58',475.00,779.00,2,21.00,'/laptop/acer/a1.jpg','Intel Core i7-12700H','16 GB','NVIDIA GeForce RTX3050','2022-11-17 00:00:00.000000',5,2,NULL,NULL),(32,'Acer Predator Helios 300 PH315-54','acer_predator_ph315_54',950.00,1299.00,3,21.00,'/laptop/acer/a2.jpg','Intel Core i7-11800H','16GB','NVIDIA GeForce RTX 3070','2022-11-23 00:00:00.000000',5,2,NULL,NULL),(33,'MSI GP66 Leopard 11UG-691XES','msi_gp66_leopard_11ug-691xes',945.00,1299.00,2,21.00,'/laptop/msi/m1.jpg','Intel Core i7-11800H','16GB','NVIDIA RTX3070-8GB','2022-11-24 00:00:00.000000',4,2,NULL,NULL),(34,'MSI Raider GE66 12UH-005ES','msi_raider_ge66_12uh',1953.55,2399.00,4,21.00,'/laptop/msi/m2.jpg','Intel Core i7-12700H','32GB ','RTX 3080-8GB','2022-11-25 00:00:00.000000',4,2,NULL,NULL);
```
  
## Instrucciones de aplicación  
  
1. Abrir una consola en el proyecto abierto de Visual Studio
```
cd frontend
ng serve
```
  
2. En el mismo Visual Studio, pulsar el botón de Iniciar
  
3. En el navegador, ir a la url: `http://localhost:4200`

# Presentación del proyecto
https://docs.google.com/presentation/d/1Xxn2LFgyD44Wd1C4VNXBSvVRae465oHaUtzojXc8QF4/  
  
  
## Otros documentos de interés  
[Documentación](Documentacion)  
  
  
## En proceso  
  
**Hecho desde la ultima presentación**:  
- Seeder de User (para usar en compra, hardcoded) [Enlace](net_grupo_3/Program.cs)
- Business Logic de Back End para compra [Enlace](net_grupo_3/Controllers/OrderController.cs)
- Maquetación vista Back Office [Enlace](frontend/src/app/back-office)
  
**En proceso**:  
- UI y lógica de compra en Angular [Enlace](frontend/src/app/services/shopping.service.ts)
- Vistas Login y Signup [Enlace](frontend/src/app/login)  
- Comunicación entre 2 componentes no relacionados para desarrollar el `shopping cart` [Enlace](frontend/src/app/product-detail)  
  
___  
### Restringir acceso al backoffice 

Hemos restringido el acceso al backoffice mediante el uso de `guards` y `cookies`.

Para poder probarlo hay que ir a la pantalla de login:

-Si le das click a entrar generara una **cookie** con valor `"User"`
-Si le das click a salir generara una **cookie con** valor `"NoUser"`

En el `guard` según el valor de esta `cookie` nos dejara entrar o no a la ruta del backoffice.

Si no estamos autorizados a entrar en backoffice nos devolverá a la pagina del login.

Si estamos autorizados, nos llevara a la pagina del backoffice.

Actualmente el proceso de login no esta implementado completamente, por eso solamente simulamos el login con los botones "Entrar" y "Salir" respectivamente.

Esperamos para la presentación del día 12 tener el login implementado.
