FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY ../Models/*.csproj Models/
COPY ../Data/*.csproj Data/
COPY ../API/*.csproj API/
RUN dotnet restore PizzaExample.sln

COPY . .
RUN dotnet publish PizzaExample.sln -c Release -o API/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/API/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "PizzaExample.API.dll"]
