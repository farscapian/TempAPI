FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TempApi/TempApi.csproj", "TempApi/"]
RUN dotnet restore "TempApi/TempApi.csproj"
COPY . .
WORKDIR "/src/TempApi"
RUN dotnet build "TempApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TempApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TempApi.dll"]