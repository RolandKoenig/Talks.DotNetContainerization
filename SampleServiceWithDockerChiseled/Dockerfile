#####################################
# Build image
FROM mcr.microsoft.com/dotnet/sdk:11.0 AS build
WORKDIR /src

# Restore first for improved cache usage
COPY "SampleServiceWithDockerChiseled/SampleServiceWithDockerChiseled.csproj" "SampleServiceWithDockerChiseled/SampleServiceWithDockerChiseled.csproj"
RUN dotnet restore "SampleServiceWithDockerChiseled/SampleServiceWithDockerChiseled.csproj"

# Build the application
COPY . .
WORKDIR "/src/SampleServiceWithDockerChiseled"
RUN dotnet publish "SampleServiceWithDockerChiseled.csproj" -c Release -o /app/publish /p:UseAppHost=false

#####################################
# Runtime image
## Configure OS
FROM mcr.microsoft.com/dotnet/aspnet:11.0-resolute-chiseled AS final
EXPOSE 80

## Copy application and define entrypoint
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SampleServiceWithDockerChiseled.dll"]