# Етап 1: Създаване на билд среда
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копиране на csproj файловете и възстановяване на зависимостите
COPY *.sln .
COPY Billing_System/*.csproj Billing_System/
RUN dotnet restore

# Копиране на останалите файлове и компилиране на приложението
COPY . .
WORKDIR /src/Billing_System
RUN dotnet publish -c Release -o /app

# Етап 2: Създаване на изпълнима среда
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Дефиниране на командата за стартиране на приложението
ENTRYPOINT ["dotnet", "Billing_System.dll"]
