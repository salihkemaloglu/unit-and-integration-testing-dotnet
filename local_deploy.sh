
#!/bin/bash
echo "Building webapi project"
docker build -t webapi .
echo "Building test project"
docker build --target testrunner -t webapitest .


echo "Unit test is starting"
docker-compose up