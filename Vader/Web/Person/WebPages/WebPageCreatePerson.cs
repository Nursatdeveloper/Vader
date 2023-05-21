using Vader.Core.UiComponents;
using Vader.Core.UiComponents.Base;
using Vader.Core.Web;

namespace Vader.Web.Person.WebPages {
    public class WebPageCreatePerson: VaderWebPage {
        public WebPageCreatePerson(string name, string title) : base(name, title) {
        }

        public override HtmlBase Render() {
            return new VaderForm("/user/create", Title)
                .Append(new PairedTag("div")
                    .Append(new PairedTag("label", "Name"))
                    .Append(new Input(InputType.text, "Name"))
                )
                .Append(new PairedTag("div")
                    .Append(new PairedTag("label", "Password"))
                    .Append(new Input(InputType.text, "Password"))
                );
        }

        public override ValidationResult Validate(IFormCollection form) {
            var password = form["Password"].ToString();
            if(password.Length < 3) {
                return new ValidationResult(false, new[] { "Length must be longer than 3" });
            }
            return new ValidationResult(true, new[] { "" });
        }

        public override bool Process(IFormCollection form) {
            var name = form["Name"].ToString();
            var password = form["Password"].ToString();
            Console.WriteLine($"{name} {password}");
            return true;
        }
    }
}
