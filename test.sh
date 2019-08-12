#!/bin/bash


docker system prune -f
docker volume rm mongostore
docker network remove dbnet

# using tutorial from
#docker pull mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
#docker pull mcr.microsoft.com/dotnet/core/sdk:2.2-stretch
docker pull mongo:latest

# build the image
#docker build -t tempapi:latest .

# create a network and volume for mongo communication and data store, then start the database.
docker network create dbnet
docker volume create --name mongostore

MONGO_INITDB_ROOT_USERNAME="mongoroot"
MONGO_INITDB_ROOT_PASSWORD="CHANGEME"
MONGO_USER_USERNAME="tempuser"
MONGO_USER_PASSWORD="testpassword"

docker build -t mongo:temp ./mongo/

docker run -d \
    -e MONGO_INITDB_DATABASE="TempDb" \
    -e MONGO_INITDB_ROOT_USERNAME="$MONGO_INITDB_ROOT_USERNAME" \
    -e MONGO_INITDB_ROOT_PASSWORD="$MONGO_INITDB_ROOT_PASSWORD" \
    --network=dbnet \
    --name tempmongo \
    -v mongostore:/data/db \
    mongo:temp

# start the webapi connecting it to dbnet.
#docker run -d --network=dbnet --name tempapi -p 80:80 tempapi:latest

# run mondodb cli
# #docker run -it --network dbnet --rm mongo mongo --host tempmongo TempDb