using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ToyRobotSimBlazor
{
    public static class HtmlHelper
    {
        public static MarkupString RenderMultiline(string textWithLineBreaks)
        {
            var encodedLines = (textWithLineBreaks ?? string.Empty)
                .Split(new char[] { '\r', '\n' })
                .Select(line => HttpUtility.HtmlEncode(line))
                .ToArray();

            return (MarkupString)string.Join("<br />", encodedLines);
        }
        public static MarkupString RenderMultilineN(string textWithLineBreaks)
        {
            var encodedLines = (textWithLineBreaks ?? string.Empty)
                .Split(new char[] { '\n' })
                .Select(line => HttpUtility.HtmlEncode(line))
                .ToArray();

            return (MarkupString)string.Join("<br />", encodedLines);
        }
    }
}
