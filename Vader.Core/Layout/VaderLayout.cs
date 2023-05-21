using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vader.Core.UiComponents;
using Vader.Core.UiComponents.Base;
using Vader.Core.Web;

namespace Vader.Core.Layout {
    public static class VaderLayout {
        private static string getSidebarHtml(string baseUri, Dictionary<string, VaderWebPage> webPages) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class=\"nav\">\r\n");
            foreach(var page in webPages) {
                if(page.Value.IsCallBack == false) {
                    sb.Append($"<li class=\"sidevar-element\"><a href=\"{baseUri}{page.Key}\"><i class=\"zmdi zmdi-view-dashboard\"></i>{page.Value.Title}</a></li>");
                }
            }

            sb.Append("</ul>\r\n");
            return sb.ToString();
        }
        public static string Render(string baseUri, Dictionary<string, VaderWebPage> webPages, VaderWebPage renderPage, string[] errors) {
            var sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang=\"en\">");
            sb.Append("<head>");
            sb.Append("<meta charset=\"UTF-8\">");
            sb.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            sb.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.Append("<link rel=\"stylesheet\" href=\"/css/vader.css\">");
            sb.Append("<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ\" crossorigin=\"anonymous\">");
            sb.Append("<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css\">");
            sb.Append("<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe\" crossorigin=\"anonymous\"></script>");
            sb.Append($"<title>{renderPage.Title}</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<div id=\"viewport\">");
            sb.Append("    <div id=\"sidebar\">");
            sb.Append($"    <header class='fs-5'><a href='{baseUri}'>VaderDemoApplication</a></header>");
            sb.Append("    <ul>");
            sb.Append($"{getSidebarHtml(baseUri, webPages)}");
            sb.Append("    </ul>");
            sb.Append("    </div>");
            sb.Append("    <div class='content'>");
            sb.Append("      <div class=\"container-fluid\" style=\"background-color: #f2f2f2; height: 52px;\">");
            sb.Append("        <div class=\"d-flex\">");
            sb.Append($"          <div><h5 class=\"p-3\">{renderPage.Title}</h5></div>");
            sb.Append("           <div class=\"position-absolute\" style=\"right:20px; margin-top:5px;\"><i class=\"bi bi-person-circle fs-3\"></i></div>");
            sb.Append("         </div>");
            sb.Append("       </div>");
            sb.Append("       <div class=\"container-fluid\">");
            sb.Append("         <div class=\"card m-3 p-3\">");
            if(errors.Length > 0) {
                var formComponent = (VaderForm)renderPage.Render();
                formComponent.SetErrors(errors);
                sb.Append($"{formComponent.ToHtml()}");
            } else {
                sb.Append(renderPage.Render().ToHtml());
            }
            sb.Append("         </div>");
            sb.Append("       </div>");
            sb.Append("     </div>");
            sb.Append("     <footer class=\"footer\">(c) Vader Inc. 2023</footer>");
            sb.Append("    </div>");
            sb.Append("    </body>");
            sb.Append("    </html>");

            return sb.ToString();
        }
    }
}
