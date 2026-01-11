FROM postgres:16

COPY Database/init.sql /docker-entrypoint-initdb.d/

# Expone el puerto por defecto de Postgres
EXPOSE 5432
