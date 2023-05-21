using Vader.Core;
using Vader.Core.Web;
using Vader.Web.Home;
using Vader.Web.Person;
using Vader.Web.Person.WebPages;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.AddVaderFramework(new VaderRequestHandler[] {
    new HomeRequestHandler(),
    new PersonRequestHandler()
});

app.Run();
