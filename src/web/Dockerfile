FROM node:latest as node-env

COPY . /app

WORKDIR /app

RUN npm install

RUN npm run build

FROM nginx:latest

WORKDIR /app

COPY --from=node-env /app/web/. /var/wwww/html/

CMD ["nginx", "-g", "daemon off;"]