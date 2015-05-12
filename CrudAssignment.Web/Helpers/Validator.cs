using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CrudAssignment.Web.Helpers
{
    public static class Validator
    {
        public static MvcHtmlString CustomValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var containerDivBuilder = new TagBuilder("div");
            containerDivBuilder.GenerateId("validation-message");

            var leftDivBuilder = new TagBuilder("div");
            leftDivBuilder.AddCssClass("error-left");

            var innerDivBuilder = new TagBuilder("div");
            innerDivBuilder.AddCssClass("error-inner");
            innerDivBuilder.InnerHtml = helper.ValidationMessageFor(expression).ToString();

            containerDivBuilder.InnerHtml += leftDivBuilder.ToString(TagRenderMode.Normal);
            containerDivBuilder.InnerHtml += innerDivBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(containerDivBuilder.ToString(TagRenderMode.Normal));
        }
    }
}