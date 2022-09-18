FROM mcr.microsoft.com/mssql/server:2019-CU16-GDR1-ubuntu-20.04 AS base
RUN mkdir -p /usr/work
WORKDIR /usr/work
COPY . /usr/work/
EXPOSE 1433

# Vai chamar o arquivo shell entrypoint, onde este chamará o arquivo import-data.sh
CMD /bin/bash ./entrypoint.sh