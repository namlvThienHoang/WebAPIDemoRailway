FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Trỏ đúng vào thư mục con để copy file csproj
COPY ["WebAPIDemoRailway/WebAPIDemoRailway.csproj", "WebAPIDemoRailway/"]
RUN dotnet restore "WebAPIDemoRailway/WebAPIDemoRailway.csproj"

# Copy toàn bộ nội dung
COPY . .
WORKDIR "/src/WebAPIDemoRailway"

# Build và Publish
RUN dotnet publish "WebAPIDemoRailway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Lệnh chạy quan trọng cho Railway
ENTRYPOINT ["sh", "-c", "dotnet WebAPIDemoRailway.dll --urls http://0.0.0.0:${PORT:-8080}"]