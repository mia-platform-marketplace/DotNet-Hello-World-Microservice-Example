# mia_template_service_name_placeholder

## Summary

%CUSTOM_PLUGIN_SERVICE_DESCRIPTION%

## Local Development

To develop the service locally you need:

- .NET Core 3.1+

To launch the service, run:
```shell
cd src/mia_template_service_name_placeholder
dotnet run
```

After that you will have the service exposed on your machine. In order to verify that the service is working properly you could launch in another terminal shell:

```shell
curl https://localhost:3001/-/ready
```

As a result the terminal should return you the following message:

```json
{"name":"mia_template_service_name_placeholder","version":"1.0.0.0","status":"OK"}
```

## Contributing

To contribute to the project, please be mindful for this simple rules:

1. Don’t commit directly on master
2. Start your branches with `feature/` or `fix/` based on the content of the branch
3. If possible, refer to the Jira issue id, inside the name of the branch, but not call it only `fix/BAAST3000`
4. Always commit in english
5. Once you are happy with your branch, open a [Merge Request][merge-request]

## Run the Docker Image

If you are interested in the docker image you can get one and run it locally with this commands:

```shell
docker pull %NEXUS_HOSTNAME%/mia_template_image_name_placeholder:latest
set -a
source .env
docker run --name mia_template_service_name_placeholder \
  -e USERID_HEADER_KEY=${USERID_HEADER_KEY} \
  -e USER_PROPERTIES=${USER_PROPERTIES} \
  -e GROUPS_HEADER_KEY=${GROUPS_HEADER_KEY} \
  -e CLIENTTYPE_HEADER_KEY=${CLIENTTYPE_HEADER_KEY} \
  -e BACKOFFICE_HEADER_KEY=${BACKOFFICE_HEADER_KEY} \
  -e MICROSERVICE_GATEWAY_SERVICE_NAME=${MICROSERVICE_GATEWAY_SERVICE_NAME} \
  -e LOG_LEVEL=trace \
  -p 3000:3000 \
  --detach \
  %NEXUS_HOSTNAME%/mia_template_image_name_placeholder
```

[nvm]: https://github.com/creationix/nvm
[merge-request]: %GITLAB_BASE_URL%/%CUSTOM_PLUGIN_PROJECT_FULL_PATH%/merge_requests
