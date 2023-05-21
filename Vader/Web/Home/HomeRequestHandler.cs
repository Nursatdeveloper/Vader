using Vader.Core.Web;
using Vader.Web.Home.WebPages;

namespace Vader.Web.Home {
    public class HomeRequestHandler: VaderRequestHandler {
        public class WebPageNames {
            public const string HomeWebPage = nameof(HomeWebPage);
        }
        public override VaderWebPage[] WebPages() {
            return new VaderWebPage[] {
                new HomeWebPage(WebPageNames.HomeWebPage, "Добро пожаловать!")
                    .OnRoute("/")
                    .AsCallback()
            };
        }
    }
}
