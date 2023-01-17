FROM node:16-alpine as angular
WORKDIR /app
COPY ./front/package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=angular app/dist/front /usr/share/nginx/html

