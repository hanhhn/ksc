@echo off
cd /d %~dp0
echo "---> Start building Client app..."

cd	../src/Navi.CH.Client

echo "---> Install packages..."
call npm install

echo "---> Build app..."
call npm run build

echo "---> Clean dist directories..."
cd /d %~dp0
cd ../
rd build/client
mkdir build/client

echo "---> Copy build content to dist directories..."
cd /d %~dp0
cd ../
xcopy "src/Navi.CH.Client/build" "build/client" /E /Y /F

echo "---> Finish build Client app!"
pause