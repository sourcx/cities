using Microsoft.AspNetCore.Mvc;

// Every public method in a controller is callable as an HTTP endpoint. In the sample above, both methods return a string. Note the comments preceding each method.
namespace AspNetCoreApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index(string? a)
        {
            a = (a == null) ? "hoi" : a;
            return View("Index", a);
        }

        // GET: /HelloWorld/Welcome
        // Content-type: "text/plain"
        public string Welcome()
        {
            return "<html><center>This is the Welcome action method...</center></html>";
        }
    }
}
