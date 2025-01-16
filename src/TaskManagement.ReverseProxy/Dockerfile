FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TaskManagement.ReverseProxy/TaskManagement.ReverseProxy.csproj", "./"]
RUN dotnet restore "TaskManagement.ReverseProxy.csproj"
COPY . .
WORKDIR "/src/src/TaskManagement.ReverseProxy"
RUN dotnet build "TaskManagement.ReverseProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagement.ReverseProxy.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagement.ReverseProxy.dll"]