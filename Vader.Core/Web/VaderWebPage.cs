using Microsoft.AspNetCore.Http;
using Vader.Core.UiComponents.Base;

namespace Vader.Core.Web {
    public abstract class VaderWebPage {
        private string _route;
        private string _name;
        private string _title;
        private bool _isCallback = false;
        public string Route { get { return _route; } }
        public string Name { get { return _name; } }
        public string Title { get { return _title; } }
        public bool IsCallBack { get { return _isCallback; } }
        public VaderWebPage(string webPageName, string webPageTitle) {
            _name = webPageName;
            _title = webPageTitle;
        }

        public VaderWebPage OnRoute(string route) {
            _route = route;
            return this;
        }

        public VaderWebPage AsCallback() {
            _isCallback = true;
            return this;
        }

        public abstract HtmlBase Render();

        public abstract ValidationResult Validate(IFormCollection form);
        public abstract bool Process(IFormCollection form);

    }

    public record ValidationResult(bool IsValid, string[] Errors);

}
