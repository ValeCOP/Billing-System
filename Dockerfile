# Етап 1: Създаване на билд среда
# Използваме официалния образ за .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копиране на csproj и възстановяване на зависимостите
COPY *.csproj ./
RUN dotnet restore

# Копиране на останалите файлове и компилиране на приложението
COPY . ./
RUN dotnet publish -c Release -o /app

# Етап 2: Създаване на изпълнима среда
# Използваме официалния образ за .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Копиране на публикуваните файлове от билд етапа
COPY --from=build /app ./

# Дефиниране на командата за стартиране на приложението
ENTRYPOINT ["dotnet", "Billing_System.dll"]
