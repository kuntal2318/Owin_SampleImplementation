using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
>;
namespace Owin.FirstApp.Middleware
{
    public class DebugMiddleware
    {
        private readonly AppFunc _next;
        private readonly DebugMiddlewareOptions _options;
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;
            if (_options.OnIncomingRequest == null)
                _options.OnIncomingRequest = (ctx) => { Debug.WriteLine("Incoming Request: " + ctx.Request.Path); };

            if (_options.OnOutgoingRequest == null)
                _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine("Outgoing Request: " + ctx.Request.Path); };

        }

        public async Task Invoke(IDictionary<string, object> enviroment)
        {
            var ctx = new OwinContext(enviroment);

            _options.OnIncomingRequest(ctx);
            await _next(enviroment);
            _options.OnOutgoingRequest(ctx);
        }
    }
}