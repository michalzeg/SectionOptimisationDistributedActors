#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
RUN dotnet restore


FROM build AS publish
ARG PROJECT_NAME
ARG BUILD_CONFIGURATION=Release
RUN dotnet build "./${PROJECT_NAME}/${PROJECT_NAME}.Silo/${PROJECT_NAME}.Silo.csproj" -c $BUILD_CONFIGURATION 
RUN dotnet publish "./${PROJECT_NAME}/${PROJECT_NAME}.Silo/${PROJECT_NAME}.Silo.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG PROJECT_NAME
ENV PROJECT_NAME=$PROJECT_NAME
WORKDIR /app
COPY --chown=$APP_UID build/wait ./wait
USER root
RUN chmod +x ./wait
USER $APP_UID
COPY --from=publish /app/publish .
ENTRYPOINT wait && dotnet ${PROJECT_NAME}.Silo.dll