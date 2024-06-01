# syntax=docker/dockerfile:1

FROM node:14-alpine
WORKDIR /app
COPY . .
RUN npm install
CMD ["npm", "start"]
EXPOSE 4200