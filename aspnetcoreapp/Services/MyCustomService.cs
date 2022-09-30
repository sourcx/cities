namespace AspNetCoreApp.Services
{
    // In dependency injection terminology, a service:
    // - Is typically an object that provides a service to other objects, such as the IMyDependency service.
    public class MyCustomService : IMyCustomService
    {
        private readonly ILogger<MyCustomService> _logger;

        public MyCustomService(ILogger<MyCustomService> logger)
        {
            _logger = logger;
        }

        public string DoThings()
        {
            _logger.LogInformation("I did my thing");
            return "ok";
        }
    }
}
