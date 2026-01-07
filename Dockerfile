# =========================
# Stage 1: Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files and restore
COPY ["NgCrm.BasicInfoService.Api/NgCrm.BasicInfoService.Api.csproj", "NgCrm.BasicInfoService.Api/"]
COPY ["NgCrm.BasicInfoService.Application/NgCrm.BasicInfoService.Application.csproj", "NgCrm.BasicInfoService.Application/"]
COPY ["NgCrm.BasicInfoService.Domain/NgCrm.BasicInfoService.Domain.csproj", "NgCrm.BasicInfoService.Domain/"]
COPY ["NgCrm.BasicInfoService.DataAccess.Command/NgCrm.BasicInfoService.DataAccess.Command.csproj", "NgCrm.BasicInfoService.DataAccess.Command/"]
COPY ["NgCrm.BasicInfoService.DataAccess.Query/NgCrm.BasicInfoService.DataAccess.Query.csproj", "NgCrm.BasicInfoService.DataAccess.Query/"]
COPY ["NgCrm.BasicInfoService.Integration/NgCrm.BasicInfoService.Integration.csproj", "NgCrm.BasicInfoService.Integration/"]
COPY ["NgCrm.BasicInfoService.Mapping/NgCrm.BasicInfoService.Mapping.csproj", "NgCrm.BasicInfoService.Mapping/"]
COPY ["NgCrm.BasicInfoService.Proxy/NgCrm.BasicInfoService.Proxy.csproj", "NgCrm.BasicInfoService.Proxy/"]

RUN dotnet restore "./NgCrm.BasicInfoService.Api/NgCrm.BasicInfoService.Api.csproj"

# Copy all source files
COPY . .

WORKDIR "/src/NgCrm.BasicInfoService.Api"

# Build the project
RUN dotnet build "./NgCrm.BasicInfoService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# =========================
# Stage 2: Publish
# =========================
FROM build AS publish
RUN dotnet publish "./NgCrm.BasicInfoService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# =========================
# Stage 3: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# -------------------------
# Install LDAP native dependencies with retry logic
# -------------------------
RUN set -eux; \
    for i in 1 2 3; do \
        apt-get update --fix-missing && apt-get install -y --no-install-recommends \
            libldap-2.5-0 \
            libsasl2-2 \
            ca-certificates \
            tzdata && break || sleep 5; \
    done; \
    rm -rf /var/lib/apt/lists/*

# -------------------------
# Create non-root user
# -------------------------
ARG APP_UID=1000
RUN useradd -u $APP_UID -m appuser
USER appuser

# Copy published app
COPY --from=publish /app/publish .

# Set timezone to Asia/Tehran
ENV TZ="Asia/Tehran"

# Set environment
ENV ASPNETCORE_ENVIRONMENT=Development

# Expose ports if needed
EXPOSE 8080
EXPOSE 8081

# Start the application
ENTRYPOINT ["dotnet", "NgCrm.BasicInfoService.Api.dll"]
