FROM node:8.16 as node-env

COPY . /app

WORKDIR /app

RUN npm install

RUN npm run build

EXPOSE 3000

ENTRYPOINT ["npm", "start"]