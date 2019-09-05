using System.Web;
using System.Web.Mvc;

namespace AspNET_TESTE {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
