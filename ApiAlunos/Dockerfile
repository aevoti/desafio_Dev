#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80 443 

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApiAlunos/ApiAlunos.csproj", "ApiAlunos/"]
RUN dotnet restore "ApiAlunos/ApiAlunos.csproj"
COPY . .
WORKDIR "/src/ApiAlunos"
RUN dotnet build "ApiAlunos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiAlunos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet ApiAlunos.dll

#ENTRYPOINT ["dotnet", "ApiAlunos.dll"]