# Используем SDK образ для сборки и выполнения миграций
FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /src

# Копируем файлы проекта и восстанавливаем зависимости
COPY ["BotGarden.Infrastructure/BotGardens.Infrastructure.csproj", "BotGarden.Infrastructure/"]
COPY ["BotGarden.Domain/BotGardens.Domain.csproj", "BotGarden.Domain/"]

RUN dotnet restore "BotGarden.Infrastructure/BotGardens.Infrastructure.csproj"

# Копируем остальную часть кода
COPY . .

# Сборка проекта
WORKDIR "/src/BotGarden.Infrastructure"
RUN dotnet build "BotGardens.Infrastructure.csproj" -c Release -o /app/build

# Публикация
RUN dotnet publish "BotGardens.Infrastructure.csproj" -c Release -o /app/publish

# Установка инструмента dotnet-ef
RUN dotnet tool install --global dotnet-ef

# Обновление переменной PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Установка рабочей директории
WORKDIR "/src/BotGarden.Infrastructure"

# Выполнение миграций
ENTRYPOINT ["dotnet", "ef", "database", "update"]
