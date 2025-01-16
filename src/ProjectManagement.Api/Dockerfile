FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/ProjectManagement.Api/ProjectManagement.Api.csproj", "./"]
RUN dotnet restore "ProjectManagement.Api.csproj"
COPY . .
WORKDIR "/src/src/ProjectManagement.Api"
RUN dotnet build "ProjectManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManagement.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagement.Api.dll"]
