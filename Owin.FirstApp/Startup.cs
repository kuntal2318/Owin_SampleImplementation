using Owin.FirstApp.Middleware;
using System.Diagnostics;

namespace Owin.FirstApp
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(new DebugMiddlewareOptions());
            app.UseNancy();
            app.Use(async (ctx, next) => await ctx.Response.WriteAsync("<html><head></head><body>Hello World</body></html>"));
        }
    }
}