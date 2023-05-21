using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Vader.Core.Layout;
using Vader.Core.UiComponents;
using Vader.Core.Web;

namespace Vader.Core {
    public static class Extensions {
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
                        var route = context.Request.Path.Value.Trim('/');
                        context.Response.ContentType = "text/html;charset=utf-8";
                        var webForm = webpages[route];
                        if(webForm != null) {
                            if(!context.Request.HasFormContentType)
                                await context.Response.WriteAsync(VaderLayout.Render(webForm.Render()));
                            else {
                                var formCollection = context.Request.Form;
                                var validationResult = webForm.Validate(formCollection);
                                if(validationResult.IsValid) {
                                    webForm.Process(formCollection);
                                } else {
                                    var formComponent = (VaderForm)webForm.Render();
                                    formComponent.SetErrors(validationResult.Message);
                                    await context.Response.WriteAsync(VaderLayout.Render(formComponent));
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
