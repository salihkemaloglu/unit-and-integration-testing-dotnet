FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY webapi/*.csproj ./dotnetapp/
COPY data/*.csproj ./data/
WORKDIR /app/dotnetapp
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY webapi/. ./dotnetapp/
COPY data/. ./data/
WORKDIR /app/dotnetapp
RUN dotnet publish -c Release -o out


# test application -- see: dotnet-docker-unit-testing.md
FROM build AS testrunner
WORKDIR /app/tests
COPY unit/. .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM  microsoft/dotnet:latest
WORKDIR /app
COPY --from=build /app/dotnetapp/out ./
ENTRYPOINT ["dotnet", "webapi.dll"]