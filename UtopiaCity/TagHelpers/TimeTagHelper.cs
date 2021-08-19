using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace UtopiaCity.TagHelpers
{
    public class TimeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "div";
            output.Content.SetContent($"{DateTime.Now:HH:mm:ss}");
        }
    }
}
