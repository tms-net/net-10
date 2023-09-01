using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using WebApp.MVC.Models;
using WebApp.MVC.Services;

namespace WebApp.MVC.Controllers
{
    // https://host/path1/path2?par1=val1&par2=val2
    // HEADERS:
    //    Cookie to model
    // BODY:
    //   - form url encoded (par1=val1&par2=val2)
    //   - json ({par1: "par2", par2: "val2"})

    // MVC = Middleware
    //  Model ~ ViewModel
    //  MVVM (Model View View Model) -> Frontend

    // asp.net routing

    // path => controller + action + params

    // "home" => HomeController
    // "privacy" => Privacy() -> /home/new-privacy

    // app.MapGet("/home/privacy", () => { GenerateHomeHtml()})

    // ActionResult
    //   - HTTP RESPONSE -> Response CODE

    // generic filter
    // - authorization filter
    // 1. routing to action

    // Model Binding

    // AOP - Aspect Oriented Programming
    // action filter
    //  before action -> action() -> after action()

    // 2. action to action result

    // result filter
    //  before result -> result() -> after result
    // 3. action result to response

    //    3.1 if ViewResult -> Razor Engine
    //    3.2 else other logic

    //[Authorize("editor")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseRepository _repository;

        public HomeController(ILogger<HomeController> logger, IDatabaseRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [Authorize("editor")]
        //[Route("index/{id}")]
        //[ActionFilter]
        //[ResultFilter]
        public IActionResult Index(string id = "")
        {
            // Обработка запроса
            // 1. Action result
            // 2. Формирование модели
            // 3. Рендеринг View


            // запрос в базу данных
            // использование конфигурации
            // запрос на вспомогательные сервисы

            var model = new BlogPost();

            return View(model);
        }

        public IActionResult Privacy([FromHeader] PrivacyRequest request)
        {
            // Validation

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Values");
            }

            return View();

            return Json(new { title = "title", date = DateTime.UtcNow }); // 

            return Content("just text"); // 200

            return Redirect("/home/new-privacy"); // 302

            return BadRequest(); // 400
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}