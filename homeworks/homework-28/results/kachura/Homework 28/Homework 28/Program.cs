using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDirectoryBrowser();
var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory())),
}) ;

app.MapGet("/", (HttpContext context) =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync(@"
    <html>
      <head>
      </head>
      <body>
        <script src = './wwwroot/resume.js'></script>
      </body>
    </html>
    ");
});

app.Run();