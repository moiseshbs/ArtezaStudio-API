# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["ArtezaStudio.Api.sln", "."]
COPY ["src/ArtezaStudio.Api/ArtezaStudio.Api.csproj", "src/ArtezaStudio.Api/"]
COPY ["src/ArtezaStudio.Application/ArtezaStudio.Application.csproj", "src/ArtezaStudio.Application/"]
COPY ["src/ArtezaStudio.Domain/ArtezaStudio.Domain.csproj", "src/ArtezaStudio.Domain/"]
COPY ["src/ArtezaStudio.Infrastructure/ArtezaStudio.Infrastructure.csproj", "src/ArtezaStudio.Infrastructure/"]

RUN dotnet restore "src/ArtezaStudio.Api/ArtezaStudio.Api.csproj"

COPY . .
WORKDIR /src/src/ArtezaStudio.Api
RUN dotnet publish "ArtezaStudio.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ArtezaStudio.Api.dll"]