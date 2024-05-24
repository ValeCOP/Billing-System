# Етап 1: Създаване на билд среда
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Billing-System

# Копиране на csproj файловете и възстановяване на зависимостите
COPY *.sln .
COPY /*.csproj Billing-System
RUN dotnet restore

# Копиране на останалите файлове и компилиране на приложението
COPY . .
WORKDIR /Billing-System
RUN dotnet publish -c Release -o /app

# Етап 2: Създаване на изпълнима среда
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Дефиниране на командата за стартиране на приложението
ENTRYPOINT ["dotnet", "Billing_System.dll"]
