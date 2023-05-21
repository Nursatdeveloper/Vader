using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Vader.Core.UiComponents.Base;

namespace Vader.Core.UiComponents {
    public class VaderForm: HtmlBase {
        private string _action;
        private string _method;
        private string _title;
        private string[] _validationErrors = Array.Empty<string>();
        public VaderForm(string action, string title, string method = "post") {
            _action = action;
            _method = method;
            _title = title;
        }

        public VaderForm SetErrors(string[] errors) {
            _validationErrors = errors;
            return this;
        }

        public override string ToHtml() {
            var sb = new StringBuilder();
            sb.Append($"<h2>{_title}</h2>");
            sb.Append($"<form action='{_action}' method='{_method}' >");
            foreach(var error in _validationErrors) {
                sb.Append($"<span style='color:red;'>Error: {error}</span>");
            }
            if(!string.IsNullOrEmpty(CssClass)) {
                sb.Append($"class='{CssClass}'>");
            }
            if(Children.Count > 0) {
                Children.ForEach(x => sb.Append(x.ToHtml()));
            } else {
                sb.Append(Text);
            }
            sb.Append($"<input type='hidden' name='env' value='r'/>");
            sb.Append($"<input type='submit' value='Submit'/>");
            sb.Append($"</form>");
            return sb.ToString();
        }

        public override HtmlBase Append(HtmlBase html) {
            Children.Add(html);
            return this;
        }
    }
}
