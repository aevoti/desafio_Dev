FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /app
COPY *.sln .
COPY ApiAlunos/*.csproj ./ApiAlunos/
COPY ApiAlunos.Test/*.csproj ./ApiAlunos.Test/
COPY Contracts/*.csproj ./Contracts/
COPY Entities/*.csproj ./Entities/
COPY Repository/*.csproj ./Repository/
RUN dotnet restore

# copy full solution over
COPY . .
RUN dotnet build

FROM build AS testrunner
WORKDIR /app/ApiAlunos.Test
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
WORKDIR /app/ApiAlunos.Test
RUN dotnet test --logger:trx

# publish the API
FROM build AS publish
WORKDIR /app/ApiAlunos
RUN dotnet publish -c Release -o out

# run the api
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=publish /app/ApiAlunos/out ./
ENTRYPOINT ["dotnet", "ApiAlunos.dll"]