using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Vader.Core.Layout;
using Vader.Core.UiComponents;
using Vader.Core.Web;

namespace Vader.Core {
    public static class VaderExtensions {
        public static IApplicationBuilder AddVaderFramework(this IApplicationBuilder app, VaderRequestHandler[] handlers) {
            var webpages = new Dictionary<string, VaderWebPage>();
            foreach(var handler in handlers) {
                var handlerWebpages = handler.WebPages();
                foreach(var webpage in handlerWebpages) {
                    webpages.Add(webpage.Route, webpage);
                }
            }


            var _routeBuilder = new RouteBuilder(app);
            foreach(var route in webpages) {
                _routeBuilder.MapRoute(route.Key,
                    async context => {
                        
                        var baseUri = new UriBuilder(context.Request.Scheme, context.Request.Host.Host, context.Request.Host.Port ?? -1).Uri.AbsoluteUri;
                        var route = context.Request.Path.Value.TrimIf(context.Request.Path.Value != "/", '/');
                        context.Response.ContentType = "text/html;charset=utf-8";
                        var webForm = webpages[route];
                        if(webForm != null) {
                            if(!context.Request.HasFormContentType)
                                await context.Response.WriteAsync(VaderLayout.Render(baseUri, webpages, webForm, errors: Array.Empty<string>()));
                            else {
                                var formCollection = context.Request.Form;
                                var validationResult = webForm.Validate(formCollection);
                                if(validationResult.IsValid) {
                                    webForm.Process(formCollection);
                                } else {
                                    await context.Response.WriteAsync(VaderLayout.Render(baseUri, webpages, webForm, validationResult.Errors));
                                }
                            }

                        } else {
                            await context.Response.WriteAsync("<div>Not found</div>");
                        }
                    });
            }

            app.UseRouter(_routeBuilder.Build());

            return app;
        }

    }
}
