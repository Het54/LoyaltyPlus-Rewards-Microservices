FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV TransactionDb="Server=localhost; Database=TransactionDb; User=sa; Password=Hetpatel@123; TrustServerCertificate=True"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TransactionAPI/TransactionAPI.csproj", "TransactionAPI/"]
COPY ["TransactionAPI.Infrastructure/TransactionAPI.Infrastructure.csproj", "TransactionAPI.Infrastructure/"]
COPY ["TransactionAPI.Core/TransactionAPI.Core.csproj", "TransactionAPI.Core/"]
RUN dotnet restore "TransactionAPI/TransactionAPI.csproj"
COPY . .
WORKDIR "/src/TransactionAPI"
RUN dotnet build "TransactionAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TransactionAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionAPI.dll"]
