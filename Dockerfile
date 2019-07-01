FROM mcr.microsoft.com/dotnet/core/sdk:2.2

COPY . /app

WORKDIR /app

RUN dotnet restore

RUN dotnet build -c Release

RUN dotnet publish -c Release

RUN dotnet ksc/src/api/Cf.Ksc/bin/Release/netcoreapp2.2/publish/Cf.Ksc.dll

FROM node:latest as node-env

COPY /ksc/src/web/ /app

WORKDIR /app/web/

RUN npm install

RUN npm run build

FROM nginx:latest

WORKDIR /app

RUN rm -r /var/wwww/html/

COPY --from:node-env /app/web/. /var/wwww/html/

CMD ["nginx", "-g", "daemon off;"]

