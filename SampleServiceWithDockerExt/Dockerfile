#####################################
# Build image
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Restore first for improved cache usage
COPY "SampleServiceWithDocker/SampleServiceWithDocker.csproj" "SampleServiceWithDocker/SampleServiceWithDocker.csproj"
RUN dotnet restore "SampleServiceWithDocker/SampleServiceWithDocker.csproj"

# Build the application
COPY . .
WORKDIR "/src/SampleServiceWithDocker"
RUN dotnet publish "SampleServiceWithDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

#####################################
# Runtime image
## Configure OS
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
EXPOSE 80

## Create a group, user and work directory for the application
RUN mkdir /home/app/net && \
    chown -R app:app /home/app/net
WORKDIR /home/app/net

## Copy application and define entrypoint
USER app
COPY --chown=app:app --from=build /app/publish .
ENTRYPOINT ["dotnet", "SampleServiceWithDocker.dll"]