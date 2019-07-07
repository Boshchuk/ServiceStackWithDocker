#!/bin/bash

# set environment variables used in deploy.sh and AWS task-definition.json:
export IMAGE_NAME=servicestack-with-docker-azure
export IMAGE_VERSION=latest

export AZURE_REGISTRY=serivcestack.azurecr.io

# set any sensitive information in travis-ci encrypted project settings:
# required: AZURE_REGISTRY_LOGIN, AZURE_REGISTRY_PASSWORD
# optional: SERVICESTACK_LICENSE


export AZURE_REGISTRY_USER=nakedsnake.boschuk@gmail.com
export AZURE_REGISTRY_PASSWORD="snake_559754!"