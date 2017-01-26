using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.Mvc;

namespace ASPizza.Helpers
{
    public static class LabelHelper

    {
        public static string Label(string target)
        {
            return String.Format("<img src = \"images/{0}\" alt = \"Photo\" position: absolute; style = \"bacground; width: 100%;\" />", target);
        }
    }
}
