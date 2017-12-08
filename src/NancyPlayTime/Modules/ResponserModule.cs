using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using NancyPlayTime.Logging;
using NancyPlayTime.Models;

namespace NancyPlayTime.Modules
{
    public class ResponserModule : NancyModule
    {
        private readonly ILogger _logger = new ConsoleLogger();
        public ResponserModule()
        {
            Before += ctx =>
            {
                var correlationId = ctx.Request.Headers["CorrelationId"].FirstOrDefault();
                _logger.LogInfo($"Correlation Id: {correlationId}");
                return ctx.Response;
            };

//            After += ctx => _logger.LogInfo("Request ended");
            
            Get("id", _ => "value");
            
            Get("/give/back/{something?}", parameters => parameters.something);
            
            Get("/give/{id}", parameters => parameters.id);
            
            Post("/person", _ =>
            {
                var person = this.Bind<Person>();
                return person;
            });

            Get("/enum/{enumvalue:ResidenceType}", parameters => this.Bind<ResidenceType>());
        }
    }
}