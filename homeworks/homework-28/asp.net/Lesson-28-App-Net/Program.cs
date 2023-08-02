// Method Main

using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// 1 - a). IoC/DI Container

// builder.Services.Add<IInterface, Implemetation>();

// builder.Services.AddTransient
// Transient -> новый для нового компонента

// builder.Services.AddScoped - Per Request
// CreateScope 1
// 
// EndScope 1

// CreateScope 2
// 
// EndScope 2

// builder.Services.AddSingleton
// Singleton - один на приложение

builder.Services.AddExceptionHandler(options =>
{
    options.AllowStatusCode404Response = false;
});

builder.Services.AddLogging(logging => { 
    logging.SetMinimumLevel(LogLevel.Debug);
    // logging.Configure()
});

// Builder pattern

WebApplication app = builder.Build();

// 3) Configuration

// app.Configuration;

// IConfigurationProvider

//1 - b).
// var implementation = app.Services.GetService<IInterface>();

using (var scope = app.Services.CreateScope()) // CreateScope 1
{
    //scope.ServiceProvider.GetService<IInterface>();
}// EndScope 1

// URL -> (http://host:port/PATH)

app.MapGet("/", () => { return "Hello World!"; }); // path -> request body

app.MapGet("/request", (HttpContext context) =>
{
    context.Response.StatusCode = 201;
    context.Response.WriteAsync("Hello World!");
});

// 1. удобство/тестирование
// 2. повторение кода DRY (Do Not Repeat Yourself)
//   /(*).js, /(*).css, /(FILE_PATH).(EXT) - вернуть содержимое файла
// 3. Эффективность веб приложения
//    - .js ~ .cs
//    - скомбинировать ресурсы для конкретной страницы -> специальный/уникальный URL для набора скриптов
//

//app.MapGet("/generatedJS.js", () => "comined content");
//app.MapGet("/resources/{filePath}", async (HttpContext context) =>
//{
//    context.Response.StatusCode = 200;
//    context.Response.ContentType = "text/html";

//    context.Response.WriteAsync(await File.ReadAllTextAsync(filePath));
//});

// request -> async/await ->
//          thread 1 -> process request -> response
//          thread 2 -> process file -> ...

app.MapGet("/resources/{filePath}", (string filePath) =>
{
    File.ReadAllText(Path.Combine("resources", filePath));
});

// HTTP Request -> HTTP Response

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    AllowStatusCode404Response = true
});

app.MapGet("/resume", (HttpContext context) =>
{
    context.Response.StatusCode = 200;
    context.Response.WriteAsync(@"<!DOCTYPE html>
<html>
<head>
    <title>Профиль Глеба Радывонюка</title>
    <link rel=""stylesheet"" type=""text/css"" href=""styles1.css"">
    
    <script src=""./resources/resume.js""></script>

    <script>

        window.onload = function () {          
            // $""onload: {document.body}"" - C#
            console.log(`onload: ${document.body}`);
        }

        console.log('start');
        NameSpace = {};

        NameSpace.MyClass = function(a)
        {
            this.a = a;
            this.b = ""b value"";
        }

        var myClass = new NameSpace.MyClass();

        // ООП
        // 1. Абстракция (out of the box) - OBJECTS

        // 2. Наследование - OBJECTS

        // MySubClass : MyClass 
        // {
        //     public int NewField
        // }

        NameSpace.MySubClass = function ()
        {
            this.newField = null;
        };
        NameSpace.MySubClass.prototype = myClass;
        
        var mySubClass = new NameSpace.MySubClass();

        // extension method
        // public static T Last<T>(this T[] arr)
        // {
        //   return  arr[arr.length - 1];
        // }

        Array.prototype.last = function() {
            return this[this.length - 1];
        }

        // 3. Полиморфизм - OBJECTS
        NameSpace.MySubClass2 = function ()
        {
            this.b = ""new b"";
        };
        NameSpace.MySubClass2.prototype = myClass;
        
        var mySubClass2 = new NameSpace.MySubClass2();

        // нет аналога base. как в C#
        // нет цепочки вызовов конструкторов
        // ECMAScript 6 Classes

       /*  class MySubClass3 extends MyClass
        {
        } */

        // 4. Encapsulation - CLOSURE
        NameSpace.MySubClass2 = function ()
        {
            // договоренность
            // this._с = ""private field"";

            var c = ""c"";

            this.getC = function() {

                // Context = Scopes
                // - Global
                // - local
                // - closure

                return c;
            }
        };
        
        console.log('end');
    </script>
    
</head>
<body>
    <script>
        console.log('body start');
        console.log(document.body);
    </script>

     <!-- HttpRequest -->
     <!-- GET url + ? form data-->
     <!-- Headers-->
     
     <!-- POST url -->
     <!-- Headers-->
     <!-- form data-->
    <form action="""" method=""post"">
        <div>
            <input name=""name"" type=""text""/>
        </div>
        <div>
        <input name=""gender"" value=""male"" type=""radio""/></div>
        <input name=""gender"" value=""female"" type=""radio""/></div>
        <div>
        <input name=""accept"" type=""checkbox""/></div>
        <div>   
        <input type=""submit""/></div>
    </form>


<!--<div class=""header"">
        <div class=""name-banner"">
            <h1><strong><em>Глеб Радывонюк</em></strong></h1>
            <div class=""line""></div> 
        </div>
    </div>

    <div class=""frame""> 
        <div class=""block contact"">
            <h2>Контактная информация</h2>
            <div class=""email"">
                <h3>Почта:</h3>
                <p><strong><em><a href=""mailto:amigozzq@gmail.com"">amigozzq@gmail.com</a></em></strong></p>
            </div>
            <div class=""phone"">
                <h3>Телефон:</h3>
                <p>+375297625064</p>
            </div>
        </div>

        <div class=""block work"">
            <h2>Work</h2>
            <div class=""company"">
                <h3>Компания - МГКЦТ </h3>
            </div>
            <div class=""project"">
                <h3>Проект - закончить колледж</h3>
            </div>
        </div>
    </div> -->

</body>
</html>
");
});

// 2) Middleware (ПО промежуточного уровня)

app.UseCors(options =>
{
    // настройка правил
});

// app.Urls.Clear();

// app.Urls.Add("http://localhost:5003");

app.UseStaticFiles();

// /it/is/my/path
//       |
//       V
// { action => it, controller => is  }

app.UseRouting();

// authorization for resources
// anonimous -> доступ всем
// User -> Role -> доступ по ролям 

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (httpContext, next) =>
{
    ClaimsPrincipal user = httpContext.User;

    // Principal -> User in the System (Interface)

    // Claims => набор ключ -> значение (ключ: claim type, значение: claim value
    //        - кто дал разрешение
    //        - какие права
    //          "roles": "admin,editor"...

    // httpContext.Request;

    // httpContext.Response; // потоковый

    // httpContext.Response.Headers

    // main logic

    await next(); // circuit breaker
    // Authenticated? -> next() else -> break

    // after logic
});

// Status
// Headers
// Body

app.Run();
