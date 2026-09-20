FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Remy.Api/Remy.Api.csproj", "Remy.Api/"]
COPY ["Remy.Core/Remy.Core.csproj", "Remy.Core/"]
COPY ["Remy.Data/Remy.Data.csproj", "Remy.Data/"]
RUN dotnet restore "Remy.Api/Remy.Api.csproj"
COPY . .
WORKDIR "/src/Remy.Api"
RUN dotnet build "./Remy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Remy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Remy.Api.dll"]
