namespace Owin.FirstApp.Middleware
{
    public static class DebugMiddlewareExtension
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();
            app.Use<DebugMiddleware>(options);
        }
    }
}