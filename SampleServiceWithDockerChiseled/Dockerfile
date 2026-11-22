#####################################
# Build image
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .

WORKDIR "/src/SampleServiceWithDockerChiseled"
RUN dotnet restore "SampleServiceWithDockerChiseled.csproj"
RUN dotnet publish "SampleServiceWithDockerChiseled.csproj" -c Release -o /app/publish /p:UseAppHost=false

#####################################
# Runtime image
## Configure OS
FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble-chiseled AS final
EXPOSE 80

## Copy application and define entrypoint
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SampleServiceWithDockerChiseled.dll"]