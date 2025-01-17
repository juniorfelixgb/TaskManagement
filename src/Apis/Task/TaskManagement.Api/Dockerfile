# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar el archivo .csproj
COPY ["src/Apis/Task/TaskManagement.Api/TaskManagement.Api.csproj", "./"]

# Restaurar dependencias
RUN dotnet restore "TaskManagement.Api.csproj"

# Copiar el resto del código fuente
COPY . .

WORKDIR "./src/TaskManagement.Api/"
CMD "dir"
RUN dotnet build "TaskManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaskManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagement.Api.dll"]
