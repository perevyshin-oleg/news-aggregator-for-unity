FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["News.WebAPI/News.WebAPI.csproj", "News.WebAPI/"]
COPY ["News.Application/News.Application.csproj", "News.Application/"]
COPY ["News.Domain/News.Domain.csproj", "News.Domain/"]
COPY ["News.Persistance/News.Persistance.csproj", "News.Persistance/"]
RUN dotnet restore "News.WebAPI/News.WebAPI.csproj"
COPY . .
WORKDIR "/src/News.WebAPI"
RUN dotnet build "News.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "News.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "News.WebAPI.dll"]
