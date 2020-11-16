#!/bin/bash

/usr/config/configure-db.sh & 

# Inicia o SQL Server
/opt/mssql/bin/sqlservr
