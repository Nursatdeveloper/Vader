using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vader.Core.Web {
    public abstract class VaderRequestHandler {
        public VaderRequestHandler() {

        }

        public abstract VaderWebPage[] WebPages();


    }
}
