using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace UtopiaCity.TagHelpers{
    public class ClockTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "time";
        var currentTime = DateTime.Now.ToString("hh:f");
        //string datetime = DateTime.Now.ToString("hh:f");
        //output.Attributes.SetAttribute("datetime=" + datetime);
        output.Content.SetContent(currentTime);
    }
}
}