# Ejercicio Mutantes
X-Men detector de mutantes

 
Magneto quiere reclutar la mayor cantidad de mutantes para poder luchar
contra los X-Men.
Te ha contratado a ti para que desarrolles un proyecto que detecte si un
humano es mutante basándose en su secuencia de ADN.

Para eso te ha pedido crear un programa con un método o función boolean isMutant(String[] dna); 


En donde recibirás como parámetro un array de Strings que representan cada fila de una tabla
de (NxN) con la secuencia del ADN. Las letras de los Strings solo pueden ser: (A,T,C,G), las
cuales representa cada base nitrogenada del ADN.

Sabrás si un humano es mutante, si encuentras más de una secuencia de cuatro letras
iguales, de forma oblicua, horizontal o vertical.

## Ejemplo (Caso mutante):
String[] dna = {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"};
En este caso el llamado a la función isMutant(dna) devuelve “true”.


### Implementacion y tecnologias usadas

- [Net Core c#](https://visualstudio.microsoft.com/es/)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) 

## Setup

### Instrucciones

Clonar este repositorio: https://github.com/vamv86/ApiAdnMeli

Para compilar y ejecutar proyecto es necesario instalar el visual studio 2019 , si se quiere una base de datos local hay que descargar el sql server y el sql server management.
Las conexiones a la base de datos se tienen que cambiar para que apunten a la instancia local.
El archivo donde se encuentran las conexiones está en el proyecto Core.api en el archivo appsettings.json.

Colocar como proyecto de inicio el Core.api

NOTA : Si se va a cambiar las conexiones a una instancia nueva de base de datos se debe actualizar la migración en la consola de administración de paquetes desde la capa de persistencia con el comando update-database.
  
Ahora se debe ejecutar desde el visual estudio el proyecto Core.api para que las Apis puedan ser consumidas.


### API Url

URL local: https://localhost:44317/

URL EN AWS: http://adnmutant.us-east-2.elasticbeanstalk.com/

URL Externa Hosting: http://amisauro1-001-site1.gtempurl.com/


### Servicios
#### Es mutante

Request: 
- POST → /mutant
```
{
 "dna2:["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
}
```
-Mutante  
Response:

```
  200 OK
```
```
  Body : Mutante
```

-No Mutante  
Response:

```
  403 Forbidden
```

```
  Body : No Mutante
```

 
 Request: 
- GET → /stats 
  
Response:

```
  200 OK
``` 

```
adn: {“count_mutant_dna”:40, “count_human_dna”:100: “ratio”:0.4}
```


### Test

#### Automaticos

Para la ejecución de los test automáticos usar visual studio con el fin de evitar la ejecución por comandos.
En el proyecto de Service.Test dar click derecho y ejecutar pruebas unitarias.


#### Cobertura

La cobertura tambien es ejecutada desde el visual studio, si la versión es comunity no aparece la opción por lo que se recomienda instalar la extensión Find code coverage (https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage)
