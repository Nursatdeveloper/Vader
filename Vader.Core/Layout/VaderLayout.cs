using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vader.Core.UiComponents.Base;

namespace Vader.Core.Layout {
    public static class VaderLayout {
        public static string Render(HtmlBase htmlBase) {
            return
            $"<!DOCTYPE html>\r\n" +
                $"<html lang=\"en\">\r\n" +
                $"  <head>\r\n    " +
                $"      <meta charset=\"UTF-8\">\r\n    " +
                $"      <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    " +
                $"      <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                $"      <title>Document</title>\r\n    " +
                $"      <link rel=\"stylesheet\" href=\"/css/vader.css\">\r\n" +
                $"  </head>\r\n" +
                $"  <body>\r\n    " +
                $"      <div id=\"viewport\">\r\n        " +
                $"      <!-- Sidebar -->\r\n        " +
                $"      <div id=\"sidebar\">\r\n          " +
                $"          <header>\r\n            " +
                $"              <a href=\"#\">My App</a>\r\n          " +
                $"          </header>\r\n          " +
                $"          <ul class=\"nav\">\r\n            " +
                $"              <li class=\"sidevar-element\">\r\n              " +
                $"                  <a href=\"#\">\r\n " +
                $"                      <i class=\"zmdi zmdi-view-dashboard\"></i> Dashboard\r\n              " +
                $"                  </a>\r\n            " +
                $"              </li>\r\n            " +
                $"              <li class=\"sidevar-element\">\r\n              " +
                $"                  <a href=\"#\">\r\n                " +
                $"                      <i class=\"zmdi zmdi-link\"></i> Shortcuts\r\n              " +
                $"                  </a>\r\n            " +
                $"              </li>\r\n                        " +
                $"          </ul>\r\n        " +
                $"      </div>\r\n        " +
                $"      <!-- Content -->\r\n        " +
                $"      <div id=\"content\">\r\n          " +
                $"          <nav class=\"navbar navbar-default\">\r\n            " +
                $"              <div class=\"container-fluid\">\r\n              " +
                $"                  <ul class=\"nav navbar-nav navbar-right\">\r\n                " +
                $"                      <li>\r\n                  " +
                $"                          <a href=\"#\">" +
                $"                              <i class=\"zmdi zmdi-notifications text-danger\"></i>\r\n                  " +
                $"                          </a>\r\n                " +
                $"                      </li>\r\n                " +
                $"                      <li><a href=\"#\">Test User</a></li>\r\n              " +
                $"                  </ul>\r\n            " +
                $"              </div>\r\n          " +
                $"          </nav>\r\n          " +
                $"          <div class=\"container-fluid\">\r\n            " +
                $"{htmlBase.ToHtml()}" +
                $"          </div>\r\n        " +
                $"      </div>\r\n        " +
                $"      <footer class=\"footer\">(c) Vader Inc. 2023</footer>\r\n\r\n      " +
                $"  </div>\r\n" +
                $"  </body>\r\n" +
                $"</html>";
        }
    }
}
