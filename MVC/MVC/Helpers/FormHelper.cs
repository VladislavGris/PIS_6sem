using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public static class FormHelper
    {
        public static MvcHtmlString RenderAddForm(this HtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.Attributes.Add("action", "/dict/addsave");
            form.Attributes.Add("method", "post");

            TagBuilder nameLabel = new TagBuilder("label");
            nameLabel.Attributes.Add("for", "name");
            nameLabel.SetInnerText("Name:");

            TagBuilder nameInput = new TagBuilder("input");
            nameInput.Attributes.Add("type", "text");
            nameInput.Attributes.Add("name", "name");

            TagBuilder br = new TagBuilder("br");

            TagBuilder phoneLabel = new TagBuilder("label");
            phoneLabel.Attributes.Add("for", "phone");
            phoneLabel.SetInnerText("Phone:");

            TagBuilder phoneInput = new TagBuilder("input");
            phoneInput.Attributes.Add("type", "tel");
            phoneInput.Attributes.Add("name", "phone");

            TagBuilder submitInput = new TagBuilder("input");
            submitInput.Attributes.Add("type", "submit");
            submitInput.Attributes.Add("name", "Add");
            submitInput.Attributes.Add("value", "Add");

            form.InnerHtml += nameLabel;
            form.InnerHtml += nameInput;
            form.InnerHtml += br;
            form.InnerHtml += phoneLabel;
            form.InnerHtml += phoneInput;
            form.InnerHtml += br;
            form.InnerHtml += submitInput;
            return new MvcHtmlString(form.ToString());
        }
    }
}