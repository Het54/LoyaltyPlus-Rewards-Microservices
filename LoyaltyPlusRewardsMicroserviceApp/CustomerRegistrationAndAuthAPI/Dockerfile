FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV CustomerDb="Server=localhost; Database=CustomerRegistrationAndAuthDb; User=sa; Password=Hetpatel@123; TrustServerCertificate=True"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerRegistrationAndAuthAPI/CustomerRegistrationAndAuthAPI.csproj", "CustomerRegistrationAndAuthAPI/"]
COPY ["CustomerRegistrationAndAuthAPI.Infrastructure/CustomerRegistrationAndAuthAPI.Infrastructure.csproj", "CustomerRegistrationAndAuthAPI.Infrastructure/"]
COPY ["CustomerRegistrationAndAuthAPI.Core/CustomerRegistrationAndAuthAPI.Core.csproj", "CustomerRegistrationAndAuthAPI.Core/"]
RUN dotnet restore "CustomerRegistrationAndAuthAPI/CustomerRegistrationAndAuthAPI.csproj"
COPY . .
WORKDIR "/src/CustomerRegistrationAndAuthAPI"
RUN dotnet build "CustomerRegistrationAndAuthAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CustomerRegistrationAndAuthAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerRegistrationAndAuthAPI.dll"]
