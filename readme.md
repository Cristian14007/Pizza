# Readme

## Setup local environment (API+DB)
`docker-compose up --build --force-recreate -d`

## Setup database
Connect to database and run manually the script of init-db.sql
(PRO OPTIONs:
- https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database)
- https://www.softwaredeveloper.blog/initialize-mssql-in-docker-container

## Save database
docker commit & docker push

## Comando para realizar un plan de migración:
dotnet ef migrations add NombreDeLaMigracion -p Ruta/Al/Proyecto/Con/DbContext -s Ruta/Al/Proyecto/DeInicio
dotnet ef migrations add InitialCreate -p ./Data/PizzaExample.Data.csproj -s ./API/PizzaExample.API.csproj

## Comando para aplicar el plan de migración:
dotnet ef database update  -p ./Data/PizzaExample.Data.csproj -s ./API/PizzaExample.API.csproj

## Comando para borrar la base de datos (útil en caso de conflicto con las migraciones o si se borra la carpeta Migrations):
dotnet ef database drop  -p ./Data/PizzaExample.Data.csproj -s ./API/PizzaExample.API.csproj