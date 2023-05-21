using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vader.Core.UiComponents.Base {

    public abstract class HtmlBase {
        public string Text { get; set; }
        public string CssClass { get; set; }
        public List<HtmlBase> Children { get; set; }
        public HtmlBase() {
            Children = new List<HtmlBase>();
        }

        public abstract string ToHtml();
        public abstract HtmlBase Append(HtmlBase html);
    }

}
