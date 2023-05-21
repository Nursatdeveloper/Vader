using Vader.Core;
using Vader.Core.Web;
using Vader.Web.Person;
using Vader.Web.Person.WebPages;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.AddVaderFramework(new VaderRequestHandler[] {
    new PersonRequestHandler()
});

app.Run();
