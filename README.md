# TechnicalTestRedArbor
 
 Proyecto realizado para prueba técnica con RedArbor. 

 

El proyecto se encuentra configurado para funcionar con una base de datos que se encuentra online y al descargar el código puede ser ejecutado desde el visual estudio. 

Si se desea se puede crear una base de datos en SQL server y ejecutar el script inicial el cual se encuentra en la siguiente ruta 

https://github.com/DiegoAGalindo/TechnicalTestRedArbor/blob/main/SQL/ScriptInicial.sql 

Luego de haber creado la base de datos y ejecutar el script es necesario configurar  “ConnectionStrings”. Esto se realiza en el archivo “appsettings.json” y se cambia el valor que se tiene en “DefaultConnection”. 

Es necesario que se cambien tanto en el proyecto “TechnicalTestRedArbor” como en el de pruebas “TechnicalTestRedArbor.Tests”, con el fin de que las pruebas unitarias funcionen de forma correcta. 

 

Si desea realizar pruebas por medio de postman en el siguiente link se encuentra la collection para ser importada. 

https://github.com/DiegoAGalindo/TechnicalTestRedArbor/blob/main/PostMan/TechnicalTestRedArbor.postman_collection.json 
