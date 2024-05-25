# Етап 1: Създаване на билд среда
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копиране на csproj файл и възстановяване на зависимости
COPY /src/BillingSystem.csproj /src/BillingSystem/
RUN dotnet restore /src/BillingSystem.csproj

# Копиране на останалите файлове и компилиране на приложението
COPY . .
WORKDIR /src/BillingSystem
RUN dotnet publish -c Release -o /app

# Етап 2: Създаване на изпълнима среда
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Дефиниране на командата за стартиране на приложението
ENTRYPOINT ["dotnet", "BillingSystem.dll"]
