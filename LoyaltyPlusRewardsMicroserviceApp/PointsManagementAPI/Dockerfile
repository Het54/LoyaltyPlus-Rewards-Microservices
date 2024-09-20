FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV PointsManagementDb="Server=localhost; Database=PointsManagementDb; User=sa; Password=Hetpatel@123; TrustServerCertificate=True"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PointsManagementAPI/PointsManagementAPI.csproj", "PointsManagementAPI/"]
COPY ["PointsManagementAPI.Infrastructure/PointsManagementAPI.Infrastructure.csproj", "PointsManagementAPI.Infrastructure/"]
COPY ["PointsManagementAPI.Core/PointsManagementAPI.Core.csproj", "PointsManagementAPI.Core/"]
RUN dotnet restore "PointsManagementAPI/PointsManagementAPI.csproj"
COPY . .
WORKDIR "/src/PointsManagementAPI"
RUN dotnet build "PointsManagementAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PointsManagementAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PointsManagementAPI.dll"]
