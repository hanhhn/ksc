@echo off
cd /d %~dp0
echo "---> Start building API..."

cd	../src/Navi.CH.Api

echo "---> Restore packages..."
call dotnet restore

echo "---> Build app..."
call dotnet build
call dotnet publish -c Release

echo "---> Clean dist directories..."
cd /d %~dp0
cd ../
rd build/api
mkdir build/api

echo "---> Copy build content to dist directories..."
cd /d %~dp0
cd ../
xcopy "src/Navi.CH.Api/bin/Release/netcoreapp2.2/publish" "build/api" /E /Y /F

echo "---> Finish build API!"
pause