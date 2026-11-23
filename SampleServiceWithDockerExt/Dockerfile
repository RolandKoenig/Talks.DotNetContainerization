#####################################
# Build image
FROM mcr.microsoft.com/dotnet/sdk:11.0 AS build
WORKDIR /src

# Restore first for improved cache usage
COPY "SampleServiceWithDockerExt/SampleServiceWithDockerExt.csproj" "SampleServiceWithDockerExt/SampleServiceWithDockerExt.csproj"
RUN dotnet restore "SampleServiceWithDockerExt/SampleServiceWithDockerExt.csproj"

# Build the application
COPY . .
WORKDIR "/src/SampleServiceWithDockerExt"
RUN dotnet publish "SampleServiceWithDockerExt.csproj" -c Release -o /app/publish /p:UseAppHost=false

#####################################
# Runtime image
## Configure OS
FROM mcr.microsoft.com/dotnet/aspnet:11.0-alpine AS final
EXPOSE 80

## Copy application and define entrypoint
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SampleServiceWithDockerExt.dll"]