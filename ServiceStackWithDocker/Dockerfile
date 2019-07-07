FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ServiceStackWithDocker/ServiceStackWithDocker.csproj", "ServiceStackWithDocker/"]
COPY ["ServiceStackWithDocker.ServiceInterface/ServiceStackWithDocker.ServiceInterface.csproj", "ServiceStackWithDocker.ServiceInterface/"]
COPY ["ServiceStackWithDocker.ServiceModel/ServiceStackWithDocker.ServiceModel.csproj", "ServiceStackWithDocker.ServiceModel/"]
RUN dotnet restore "ServiceStackWithDocker/ServiceStackWithDocker.csproj"
COPY . .
WORKDIR "/src/ServiceStackWithDocker"
RUN dotnet build "ServiceStackWithDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ServiceStackWithDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ServiceStackWithDocker.dll"]