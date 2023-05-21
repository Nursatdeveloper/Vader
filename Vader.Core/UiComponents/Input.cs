using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vader.Core.UiComponents.Base;

namespace Vader.Core.UiComponents {
    public class Input: HtmlBase {
        public InputType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Input(InputType type, string name, string value = "") {
            Type = type;
            Name = name;
            Value = value;
        }
        public override string ToHtml() {
            return $"<input type='{Type.ToString()}' name='{Name}' value='{Value}' />";
        }

        public override HtmlBase Append(HtmlBase html) {
            throw new NotImplementedException();
        }
    }
    public enum InputType {
        text,
        date
    }
}
