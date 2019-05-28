@echo off
cd /d %~dp0
echo "---> Start building GATEWAY..."

cd	../src/Navi.CH.Gateway

echo "---> Restore packages..."
call dotnet restore

echo "---> Build app..."
call dotnet build
call dotnet publish -c Release

echo "---> Clean dist directories..."
cd /d %~dp0
cd ../
rd build/gateway
mkdir build/gateway

echo "---> Copy build content to dist directories..."
cd /d %~dp0
cd ../
xcopy "src/Navi.CH.Gateway/bin/Release/netcoreapp2.2/publish" "build/gateway" /E /Y /F

echo "---> Finish build GATEWAY!"
pause