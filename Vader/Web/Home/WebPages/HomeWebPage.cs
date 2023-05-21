using Vader.Core.UiComponents.Base;
using Vader.Core.Web;

namespace Vader.Web.Home.WebPages {
    public class HomeWebPage: VaderWebPage {
        public HomeWebPage(string webPageName, string webPageTitle) : base(webPageName, webPageTitle) {
        }

        public override HtmlBase Render() {
            return new PairedTag("div", cssClass: "text-center")
                    .Append(new PairedTag("h3", text: "Welcome to VaderDemoApplication"))
                    .Append(new PairedTag("p", text: "Vader Framework is a brand new ASP.NET framework developed by Nursat Zeinolla."));
        }

        public override ValidationResult Validate(IFormCollection form) {
            throw new NotImplementedException();
        }
        public override bool Process(IFormCollection form) {
            throw new NotImplementedException();
        }
    }
}
