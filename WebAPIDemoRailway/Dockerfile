# Stage 1: Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Không fix cứng USER $APP_UID để tránh vấn đề phân quyền trên một số môi trường cloud
EXPOSE 8080

# Stage 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copy file csproj và restore
COPY ["WebAPIDemoRailway/WebAPIDemoRailway.csproj", "WebAPIDemoRailway/"]
RUN dotnet restore "WebAPIDemoRailway/WebAPIDemoRailway.csproj"
# Copy toàn bộ code
COPY . .
WORKDIR "/src/WebAPIDemoRailway"
RUN dotnet build "WebAPIDemoRailway.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "WebAPIDemoRailway.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final Production
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# QUAN TRỌNG: Railway yêu cầu App lắng nghe theo biến môi trường $PORT
ENTRYPOINT ["sh", "-c", "dotnet WebAPIDemoRailway.dll --urls http://0.0.0.0:${PORT:-8080}"]