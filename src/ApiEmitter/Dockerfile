#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM  --platform=$BUILDPLATFORM  mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview AS build
ARG TARGETARCH
WORKDIR /src/ApiEmitter
COPY ["src/ApiEmitter/ApiEmitter.csproj", "."]
RUN dotnet restore "ApiEmitter.csproj"
COPY ./src/ApiEmitter/ .
RUN dotnet build "ApiEmitter.csproj" -c Release -o /app/build  -a $TARGETARCH

FROM build AS publish
RUN dotnet publish "ApiEmitter.csproj" -c Release -o /app/publish /p:UseAppHost=false  -a $TARGETARCH

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiEmitter.dll"]
