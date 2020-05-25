using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Helpers
{
    [HtmlTargetElement("HyperLink")]
    public class HyperLinkTagHelper : TagHelper
    {
        #region Proprietes
        public string AspAction { get; set; }
        public string AspController { get; set; }
        public Method Method { get; set; } = Method.Get;
        public string Class { get; set; }


        public string Style { get; set; }

        private IDictionary<string, string> _routeValues;

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get => _routeValues ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            set => _routeValues = value;
        }

        [HtmlAttributeName("dataconfirm")]
        public string DataConfirm { get; set; }

        [HtmlAttributeName("faclass")]
        public string faClass { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="urlHelper"></param>
        public HyperLinkTagHelper()
        {
        }

        /// <summary>
        /// Render output 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            var linkName = (await output.GetChildContentAsync()).GetContent();
            var builder = new StringBuilder();
            var method = Method.ToString().ToLower();
           // var faClass = context.AllAttributes["faClass"].Value;
            builder.AppendFormat("<form method='{0}' dataconfirm ='{1}' role='form' action='/{2}/{3}'>", method, DataConfirm, AspController, AspAction);
            foreach (var (key, value) in _routeValues)
            {
                builder.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", key, value);
            }
            if (faClass != null)
            {
                builder.AppendFormat("<button type='submit' value='{0}' class='{1}' style='{2}'>", linkName, Class, Style);
                builder.AppendFormat("<i class='{0}' ></i>", faClass);
                builder.AppendFormat("</button>");
            }
            else
            {
                builder.AppendFormat("<input type='submit' value='{0}' class='{1}' style='{2}'/>", linkName, Class, Style);
            }
            builder.Append("</form>");
            output.Content.SetHtmlContent(builder.ToString());
        }


        
    }
    public enum Method
    {
        Get,
        Post,
        Delete,
        Put
    }
}
