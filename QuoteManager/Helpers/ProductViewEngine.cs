using System.Web.Mvc;

namespace QuoteManager.Helpers
{
    public class ProductViewEngine : RazorViewEngine
    {
        public ProductViewEngine()
        {
            ViewLocationFormats = new string[]
            {
                "~/Views/Product/{1}/{0}.cshtml"
            };
            PartialViewLocationFormats = ViewLocationFormats;
        }
    }
}