# mia_template_service_name_placeholder

[![pipeline status][pipeline]][git-link]
[![coverage report][coverage]][git-link]

## Summary

Welcome to mia_template_service_name_placeholder .NET Core 3.1 Microservice

%CUSTOM_PLUGIN_SERVICE_DESCRIPTION%

## Local Development

To develop the service locally you need:
- .NET Core 3.1

You can create your local copy of the default values for the `env` variables needed for
launching the application.
```shell
cp ./default.env ./local.env
```

From now on, if you want to change anyone of the default values for the variables you can do it inside the `local.env`
file without pushing it to the remote repository.

Before launching the service set the `env` variables:
```shell
set -a && source local.env
```

To run the service locally you can launch:
```shell
dotnet run
```

## Notes

[pipeline]: %GITLAB_BASE_URL%/%CUSTOM_PLUGIN_PROJECT_FULL_PATH%/mia_template_service_name_placeholder/badges/master/pipeline.svg
[coverage]: %GITLAB_BASE_URL%/%CUSTOM_PLUGIN_PROJECT_FULL_PATH%/mia_template_service_name_placeholder/badges/master/coverage.svg
[git-link]: %GITLAB_BASE_URL%/%CUSTOM_PLUGIN_PROJECT_FULL_PATH%/mia_template_service_name_placeholder/commits/master

[merge-request]: %GITLAB_BASE_URL%/%CUSTOM_PLUGIN_PROJECT_FULL_PATH%/mia_template_service_name_placeholder/merge_requests
