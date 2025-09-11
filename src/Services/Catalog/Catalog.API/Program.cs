var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    // Add explicit return statement to be able to set a breakpoint here
    Console.WriteLine("Hello World! (from console)");
    return "Hello World!";
});

app.Run();
