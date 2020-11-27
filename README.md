# dotnetcore-webapi
[![Build Status](https://beckshome.visualstudio.com/dotnetcore-webapi/_apis/build/status/thbst16.dotnetcore-webapi?branchName=main)](https://beckshome.visualstudio.com/dotnetcore-webapi/_build/latest?definitionId=6&branchName=main)

dotnetcore-webapi is a simple REST API built on .NET Core. To browse to the online documentation for the API, use the link below:
* [dotnetcore-webapi REST API](https://beckshome-webapi.azurewebsites.net/swagger/index.html) - A REST API for CRUD with non-read API calls. The API is open and unauthenticated.

dotnetcore-webapi uses the following DevOps environment and tools to support a CI / CD process:
* [GitHub Source Code Repository](https://github.com/thbst16/dotnetcore-webapi) - All source code is stored in the GitHub repository, which is where you currently find yourself.
* [Azure DevOps for CI/CD](https://beckshome.visualstudio.com/dotnetcore-webapi/_build) - Azure DevOps is used for continunous integration and continuous delivery (CI/CD). Builds and deployments are initiated with every cheackin to the main brach of the solution in GitHub.

# Features

* REST interfaces with Swagger documentation
* Auto-generated data to pre-populate database
* CI/CD Using Azure DevOps

# Open Source Used

* [Bogus](https://github.com/bchavez/Bogus) for data generation.
* [LightQuery](https://github.com/GeorgDangl/LightQuery) for nifty lightweight WebAPI paging and sorting.
* [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) for Swagger document generation.
* [VSCode REST Client](https://github.com/Huachao/vscode-restclient/blob/master/README.md) for REST API tests from VS Code. 