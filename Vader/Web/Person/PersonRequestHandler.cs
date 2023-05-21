using Vader.Core.Web;
using Vader.Web.Person.WebPages;

namespace Vader.Web.Person {
    public class PersonRequestHandler: VaderRequestHandler {
        public override VaderWebPage[] WebPages() {
            return new VaderWebPage[] {
                new WebPageCreatePerson(nameof(WebPageCreatePerson), "Создать человека")
                    .OnRoute("user/create")
            };
        }
    }
}
