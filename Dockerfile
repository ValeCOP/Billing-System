# Етап 1: Създаване на билд среда
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копиране на csproj и възстановяване на зависимости
COPY ["Billing_System/Billing_System.csproj", "Billing_System/"]    
RUN dotnet restore "Billing_System/Billing_System.csproj"

# Копиране на останалите файлове и билд
COPY . .
WORKDIR "/src/Billing_System"
RUN dotnet build "Billing_System.csproj" -c Release -o /app/build

# Етап 2: Публикуване на приложението
FROM build AS publish
RUN dotnet publish "Billing_System.csproj" -c Release -o /app/publish

# Етап 3: Създаване на образ
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Billing_System.dll"]


