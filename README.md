# mvc-app-calling-api
A demo for calling a WebAPI from a MVC-app.

## How to run
The demo is intended to be used together with the default weather forecast API which is generated when creating an ASP.NET Core WebAPI project.

You have two options:

1. Create a ASP.NET Core WebAPI project and run it
2. Download and run [this API-project](https://github.com/amikko-hv/webapi-with-scalar)

First make sure you build and run your API on localhost.

Open **HomeController.cs**. Ensure the URI for the HttpRequestMessage matches your API endpoint.

Then, run this project on localhost. The app will start and make a request to the API.

The result is displayed on the home page.
