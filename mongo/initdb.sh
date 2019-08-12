#!/usr/bin/env bash

set -ex

# seeding the database
mongo TempDb --host localhost --port 27017 -u "${MONGO_INITDB_ROOT_USERNAME}" -p "${MONGO_INITDB_ROOT_PASSWORD}" --authenticationDatabase admin --eval "db.Temps.insertMany([{'SensorName': 'sensor1','Timestamp': '2019-08-11','Temperature': 25.0,'HeaterAction': 'on'}])"

# mongo TempDb \
#     --host localhost \
#     --port 27017 \
#     -u ${MONGO_INITDB_ROOT_USERNAME} \
#     -p ${MONGO_INITDB_ROOT_PASSWORD} \
#     --authenticationDatabase admin \
#     --eval "db.createUser({user: 'appuser', pwd: 'apppassword', roles:[{role:'dbOwner', db: 'TempDb'}]});"
