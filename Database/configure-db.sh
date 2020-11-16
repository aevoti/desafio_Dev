#!/bin/bash

set -e

wait_time=90s

# wait for SQL Server to come up
echo importing data will start in $wait_time...
sleep $wait_time

# Run the setup script to create the DB and the schema in the DB
echo "Running setup script"
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i setup.sql