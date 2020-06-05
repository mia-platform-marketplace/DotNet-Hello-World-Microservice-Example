##########################################################################
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 3000
ENV ASPNETCORE_URLS=http://*:3000

##########################################################################
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src/HelloWorld

COPY src/HelloWorld/HelloWorld.csproj .
RUN dotnet restore HelloWorld.csproj
COPY src/HelloWorld/. .
WORKDIR /src/HelloWorld/.
RUN dotnet build "HelloWorld.csproj" -c Release -o /app/build

##########################################################################
FROM build AS publish
RUN dotnet publish "HelloWorld.csproj" -c Release -o /app/publish

##########################################################################
LABEL maintainer="%CUSTOM_PLUGIN_CREATOR_USERNAME%" \
      name="mia_template_service_name_placeholder" \
      description="mia_template_service_name_placeholder" \
      eu.mia-platform.url="https://www.mia-platform.eu" \
      eu.mia-platform.version="0.1.0" \
      eu.mia-platform.language="c#" \
      eu.mia-platform.framework=".net core 3.1"

##########################################################################
FROM base AS final
WORKDIR /app

ARG COMMIT_SHA=<not-specified>
RUN echo "mia_template_service_name_placeholder: $COMMIT_SHA" >> ./commit.sha

COPY --from=publish /app/publish .

CMD ["dotnet", "HelloWorld.dll"]