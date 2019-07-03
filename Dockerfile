FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as dotnet-build-env

COPY . /app

WORKDIR /app

RUN dotnet restore

RUN dotnet build -c Release

RUN dotnet publish -c Release

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /app

COPY --from=dotnet-build-env /app/src/api/Cf.Ksc/bin/Release/netcoreapp2.2/publish .

Expose 5000 5001

ENTRYPOINT ["dotnet", "Cf.Ksc.dll", "--launch-profile", "Docker"]