# Sandy

Sandy is a logger for .NET Core that will help you to log your request information in a json format into files. 

##Installation

```Nuget
Install-Package Sandy -Pre
```

## How to use

Inside the Startup class of your project, in the ConfigureServices method. inject the IJsonLogger as a Singleton

```C#
public void ConfigureServices(IServiceCollection services)
{
   // Add framework services.
   services.AddApplicationInsightsTelemetry(Configuration);
   services.AddSingleton<IJsonLogger, JsonLogger>();
   services.AddMvc();
}
```
Sandy comes with default options, however you can override these options

```C#
 public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, IJsonLogger jsonLogger)
{
    ConfigureJsonLogger(jsonLogger);
}


public void ConfigureJsonLogger(IJsonLogger jsonLogger)
{
    jsonLogger.SetOptions(new JsonLoggerOptions()
    {
        AppName = "MyGreatApp", 
    });
}
```

You have to options in order for you to log

1- Injecting the IJsonLogger in the constructor and using the instance.

```C#
private IJsonLogger logger { get; set; }

public HomeController(IJsonLogger logger)
{
    this.logger = logger;
}

public IActionResult()
{
    logger.LogFatal(Request, "my message");
    return View();
}
```

2- Using the HttpRequest extension methods. 
```C#
public IActionResult()
{
    Request.LogInfo();
    Request.LogError("something went wrong");
}
```
## IMPORANT NOTE
Because .NET Core still at its early stage, granting permissions for the files inside the code still not supported.
so you might want to do it manually for now.

## Contact
Feel free to drop me an email at ibraheem.al-saady@outlook.com
