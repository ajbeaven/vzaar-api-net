# vzaar API

![vzaar Logo](https://raw.github.com/vzaar/vzaar-api-php/master/vzaar.png)

By [vzaar](http://vzaar.com)

vzaar's .NET client for interacting with version 2 of the [vzaar
API](https://vzaar.readme.io/docs).

## Updating nuget package

1. Start by creating a nupkg file. Go to the folder with the .sln file and run:
```
dotnet pack -c Release
```
2. This creates a .nupkg and .snupkg (symbols) that is uploaded to a nuget package repository (nuget.org, Azure Devops Artifacts, etc). Lets do that now. 

3. If this is the first time you're updating the nuget package, otherwise skip to step 4 now:
```
dotnet nuget add source https://pkgs.dev.azure.com/SimplyDating/_packaging/SimplyDatingNuget/nuget/v3/index.json --name SimplyDatingNuget --username any-name-here --password PAT
```

4. Now push the nuget package to the nuget repository:
```
dotnet nuget push --source "SimplyDatingNuget" "lib/bin/Release/SD_VzaarApi.X.X.X.nupkg`
```

## Requirements

The library code compiles on:
- .NET Core 5.0 / .NET Standard >=2.1

## Backwards compatability

Versions 1 and 2 of the vzaar API are incompatable with each other. The same applies to
the API SDKs. Some functionality available in the version 1 SDK has been deprecated in
version 2 and will not be implemented. The version 2 API also has a different
authentication mechanism so your existing API key will not work with version 2 SDKs.

To ease migration to the version 2 SDK, it is possible to use both versions without any
conflicts.

```
Vzaar       # <= this is version 1
VzaarApi    # <= this is version 2
```

## Usage

Check the `Examples` directory for usage examples. You can configure your `client_id` and
`auth_token` in `Program.cs`:

```

Client.client_id = "id";
Client.auth_token = "token";
```

Usage instructions and examples are available on [vzaar's documentation
site](https://vzaar.readme.io).


## License

Released under the [MIT License](http://www.opensource.org/licenses/MIT).
