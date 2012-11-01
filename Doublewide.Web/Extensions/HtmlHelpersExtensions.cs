using System;
using System.Linq;
using MarkdownDeep;
using Nancy.ViewEngines.Razor;

namespace Doublewide.Web.Extensions
{
    public static class HtmlHelpersExtensions
    {
        public static string CssClasses<TModel>(this HtmlHelpers<TModel> htmlHelper, params string[] args)
        {
            var nonEmpty = args.Where(x => !string.IsNullOrEmpty(x));
            return String.Join(" ", nonEmpty);
        }

        public static IHtmlString Markdown<TModel>(this HtmlHelpers<TModel> htmlHelper, string content)
        {
            var md = new Markdown();
            return htmlHelper.Raw(md.Transform(content));
        }

        public static AssetsHelper Assets<TModel>(this HtmlHelpers<TModel> htmlHelper)
        {
            return AssetsHelper.GetInstance(htmlHelper);
        }
    }
}