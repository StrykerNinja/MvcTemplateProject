namespace CareDope.Infrastructure.Tags
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Routing;
    using HtmlTags;
    using MVC;

    public static class HtmlHelperExtensions
    {
        public static HtmlTag Link<TController>(this HtmlHelper helper, Expression<Action<TController>> action) where TController : Controller
        {
            var linkText = ((MethodCallExpression)action.Body).Method.Name;

            return helper.Link(action, linkText);
        }

        public static HtmlTag Link<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText) where TController : Controller
        {
            var url = LinkBuilder.BuildUrlFromExpression(helper.ViewContext.RequestContext, RouteTable.Routes, action);
            return Link(helper, linkText, url);
        }

        private static HtmlTag Link(HtmlHelper helper, string linkText, string url)
        {
            url = "~/" + url;
            url = UrlHelper.GenerateContentUrl(url, helper.ViewContext.HttpContext);

            return new HtmlTag("a", t =>
            {
                t.Text(linkText);
                t.Attr("href", url);
            });
        }
    }
}