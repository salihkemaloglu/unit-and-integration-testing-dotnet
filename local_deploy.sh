
#!/bin/bash
echo "Building webapi project..."
docker build -t webapi .
echo "Building unit test project..."
docker build --target unittest -t webapiunit .

echo "Building integration test project..."
docker build --target integrationtest -t webapiintegration .

echo "Unit test is starting..."
docker-compose up