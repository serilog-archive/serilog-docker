#!/bin/bash 

# clean images and containers

docker ps -a | sed 1d | awk '{print $1}' | xargs docker rm
docker volume ls | sed 1d | awk '{print $2}' | xargs docker volume rm  
docker images | sed 1d | egrep -v 'serilog' | awk '{print $3}' | xargs docker rmi