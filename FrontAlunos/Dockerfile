# stage 1
FROM node:12.18.1-alpine3.12 as node
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# stage 2
FROM nginx:1.19.0-alpine
COPY --from=node /usr/src/app/dist/FrontAlunos /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
