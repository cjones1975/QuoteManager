using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace QuoteManager.Helpers
{
    public static class MvcHelpers
    {
        public static string RenderPartialView(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))

                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }

        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

    }
}