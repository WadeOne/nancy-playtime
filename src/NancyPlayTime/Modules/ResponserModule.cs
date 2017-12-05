using System.Linq;
using Nancy;
using NancyPlayTime.Logging;

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
//
//            After += ctx => _logger.LogInfo("Request ended");
            
            Get("/give/back/{something}", parameters => parameters.something);
        }
    }
}