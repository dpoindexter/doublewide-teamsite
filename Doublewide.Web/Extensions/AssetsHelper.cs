﻿using System.Collections.Generic;
using System.Text;
using Nancy.ViewEngines.Razor;
using IHtmlString = Nancy.ViewEngines.Razor.IHtmlString;

namespace Doublewide.Web.Extensions
{
    public class AssetsHelper
    {
        public static AssetsHelper GetInstance<TModel>(HtmlHelpers<TModel> htmlHelper)
        {
            const string instanceKey = "AssetsHelperInstance";

            var context = htmlHelper.RenderContext.Context;
            if (context == null) return null;

            var assetsHelper = (AssetsHelper)context.Items[instanceKey];

            if (assetsHelper == null)
                context.Items.Add(instanceKey, assetsHelper = new AssetsHelper());

            return assetsHelper;
        }

        public ItemRegistrar Styles { get; private set; }
        public ItemRegistrar Scripts { get; private set; }

        public AssetsHelper()
        {
            Styles = new ItemRegistrar(ItemRegistrarFormatters.StyleFormat);
            Scripts = new ItemRegistrar(ItemRegistrarFormatters.ScriptFormat);
        }
    }

    public class ItemRegistrar
    {
        private readonly string _format;
        private readonly IList<string> _items;

        public ItemRegistrar(string format)
        {
            _format = format;
            _items = new List<string>();
        }

        public ItemRegistrar Add(string url)
        {
            if (!_items.Contains(url))
                _items.Insert(0, url);

            return this;
        }

        public IHtmlString Render()
        {
            var sb = new StringBuilder();

            foreach (var item in _items)
            {
                var fmt = string.Format(_format, item);
                sb.AppendLine(fmt);
            }

            return new NonEncodedHtmlString(sb.ToString());
        }
    }

    public class ItemRegistrarFormatters
    {
        public const string StyleFormat = "<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />";
        public const string ScriptFormat = "<script src=\"{0}\" type=\"text/javascript\"></script>";
    }
}