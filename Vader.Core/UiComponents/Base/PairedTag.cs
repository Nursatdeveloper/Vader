using System.Text;

namespace Vader.Core.UiComponents.Base {

    public class PairedTag: HtmlBase {
        private string _tag;
        public PairedTag(string tag,  string text = "", string cssClass = "") {
            _tag = tag;
            Text = text;
            CssClass = cssClass;
        }
        public override string ToHtml() {
            var sb = new StringBuilder();
            sb.Append($"<{_tag} ");
            if(!string.IsNullOrEmpty(CssClass)) {
                sb.Append($"class='{CssClass}'");
            }
            sb.Append(">");
            if(Children.Count > 0) {
                Children.ForEach(x => sb.Append(x.ToHtml()));
            } else {
                sb.Append(Text);
            }
            sb.Append($"</{_tag}>");
            return sb.ToString();
        }


        public override HtmlBase Append(HtmlBase html) {
            Children.Add(html);
            return this;
        }
    }
}
