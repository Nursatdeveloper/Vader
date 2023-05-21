using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vader.Core {
    public static class CsharpExtensions {
        public static string TrimIf(this string text, bool condition, char trimChar) {
            if(condition) {
                return text.Trim(trimChar);
            }
            return text;
        }
    }
}
