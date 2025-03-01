FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["BotGarden.Backend.csproj", "./"]
COPY ["../BotGarden.Application/BotGarden.Application.csproj", "../BotGarden.Application/"]
COPY ["../BotGarden.Domain/BotGarden.Domain.csproj", "../BotGarden.Domain/"]
COPY ["../BotGarden.Infrastructure/BotGarden.Infrastructure.csproj", "../BotGarden.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "BotGarden.Backend.csproj"

# Copy the rest of the source code
COPY . .
COPY ../BotGarden.Application/. ../BotGarden.Application/
COPY ../BotGarden.Domain/. ../BotGarden.Domain/
COPY ../BotGarden.Infrastructure/. ../BotGarden.Infrastructure/

# Build the application
RUN dotnet build "BotGarden.Backend.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "BotGarden.Backend.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BotGarden.Backend.dll"]
