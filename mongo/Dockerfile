FROM mongo:latest

COPY ./initdb.sh /docker-entrypoint-initdb.d/initdb.sh

RUN chmod 0755 /docker-entrypoint-initdb.d/initdb.sh
