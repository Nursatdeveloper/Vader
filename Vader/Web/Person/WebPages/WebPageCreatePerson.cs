using Vader.Core.UiComponents;
using Vader.Core.UiComponents.Base;
using Vader.Core.Web;

namespace Vader.Web.Person.WebPages {
    public class WebPageCreatePerson: VaderWebPage {
        public WebPageCreatePerson(string name, string title) : base(name, title) {
        }

        public override HtmlBase Render() {
            return new VaderForm("/user/create", Title)
                .Append(new PairedTag("div", cssClass: "mb-3 row")
                    .Append(new PairedTag("label", text: "Name", cssClass: "col-sm-2 col-form-label"))
                    .Append(new PairedTag("div", cssClass: "col-sm-10")
                        .Append(new Input(InputType.text, "Name", cssClass: "form-control"))
                    )
                )
                .Append(new PairedTag("div", cssClass: "mb-3 row")
                    .Append(new PairedTag("label", text: "Password", cssClass: "col-sm-2 col-form-label"))
                    .Append(new PairedTag("div", cssClass:"col-sm-10")
                        .Append(new Input(InputType.text, "Password", cssClass: "form-control"))
                    )
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
