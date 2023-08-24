internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/request", (HttpContext context) => 
        {
            context.Response.StatusCode = 201;
            context.Response.WriteAsync("ABOBA");
        });

        app.MapGet("/request/{filePath}", (string filePath) =>
        {
            File.ReadAllText(Path.Combine("resources", filePath));
        });

        app.Run();
    }
}