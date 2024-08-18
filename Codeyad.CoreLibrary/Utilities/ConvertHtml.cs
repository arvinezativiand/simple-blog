using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.Utilities;

public static class ConvertHtml
{
    public static string ConverHtmlToText(this string text)
    {
        return Regex.Replace(text, "<.*?>", " ").Replace(":&nbsp;", " ");
    }
}
