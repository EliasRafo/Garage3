using Garage3.Core.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System.Text.Encodings.Web;

namespace Garage3.Web.TagHelpers
{
    [HtmlTargetElement("message")]
    public class MessageTagHelper : TagHelper
    {
        public string message { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Feedback x = JsonConvert.DeserializeObject<Feedback>(message);

            output.TagName = "div";
            output.AddClass("alert", HtmlEncoder.Default);
            output.Attributes.Add("id", "hideDiv");

            if (x.status == "ok")
            {
                output.AddClass("alert-success", HtmlEncoder.Default);
            }
            else
            {
                output.AddClass("alert-danger", HtmlEncoder.Default);
            }

            output.Content.SetHtmlContent(x.message);
        }
    }
}
