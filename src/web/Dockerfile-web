FROM node:8 as node-env

COPY . /app

WORKDIR /app

RUN npm install

RUN npm run build

EXPOSE 3000

CMD ["npm", "start"]