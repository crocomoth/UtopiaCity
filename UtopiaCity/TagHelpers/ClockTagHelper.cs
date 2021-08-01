using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Globalization;

namespace UtopiaCity.TagHelpers
{
    public class ClockTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ///
            output.TagName = "time";
            CultureInfo cultureInfo = new CultureInfo("ru-Ru");
            var currentTime = DateTime.Now.ToString("hh:mm", cultureInfo);
            output.Content.SetContent(currentTime);
        }
    }
}