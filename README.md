
## SampleServiceWithDocker
```powershell
docker build -f ./SampleServiceWithDocker/Dockerfile -t sample-service-with-docker .
```

## SampleServiceWithDockerExt
```powershell
docker build -f ./SampleServiceWithDockerExt/Dockerfile -t sample-service-with-docker-ext .
```

## SampleServiceWithDockerChiseled
```powershell
docker build -f ./SampleServiceWithDockerChiseled/Dockerfile -t sample-service-with-docker-chiseled .
```

## SampleServiceWithDockerBySdk
```powershell
dotnet publish ./SampleServiceWithDockerBySdk/SampleServiceWithDockerBySdk.csproj /t:PublishContainer
```