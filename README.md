# %CUSTOM_PLUGIN_SERVICE_NAME%

[![pipeline status][pipeline]][git-link]
[![coverage report][coverage]][git-link]

## Summary

Welcome to %CUSTOM_PLUGIN_SERVICE_NAME% .NET Core 3.1 Microservice

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

[pipeline]: https://git.tools.mia-platform.eu/clients/mia-platform/demo/services/hellovodafone/badges/master/pipeline.svg
[coverage]: https://git.tools.mia-platform.eu/clients/mia-platform/demo/services/hellovodafone/badges/master/coverage.svg
[git-link]: https://git.tools.mia-platform.eu/clients/mia-platform/demo/services/hellovodafone/commits/master

[merge-request]: https://git.tools.mia-platform.eu/clients/mia-platform/demo/services/hellovodafone/merge_requests
