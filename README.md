# webBeta NSerializer ASP.NET Core module

[![Build Status](https://travis-ci.com/webbeta/NSerializer.AspNetCore.svg?branch=master)](https://travis-ci.com/webbeta/NSerializer.AspNetCore)
[![GitHub license](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet](https://buildstats.info/nuget/webBeta.NSerializer.AspNetCore)](http://www.nuget.org/packages/webBeta.NSerializer.AspNetCore)

## Installation

```csharp
public class Startup
{
    // ...
    
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddNSerializer();
        // ...
    }

    // ...
}
```

## Usage

```csharp
[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly NSerializer _serializer;

    public DemoController(NSerializer serializer)
    {
        _serializer = serializer;
    }

    [HttpGet("ascreated")]
    public ActionResult AsCreated()
    {
        return _serializer.SerializeAndCreated(new Demo(), "created_group");
    }

    [HttpGet("asok")]
    public ActionResult AsOk()
    {
        return _serializer.SerializeAndOk(new Demo(), "ok_group");
    }
}
```

## Documentation

More documentation and resources at [webBeta NSerializer](https://github.com/webbeta/NSerializer) repository.

## License

[MIT](LICENSE)
