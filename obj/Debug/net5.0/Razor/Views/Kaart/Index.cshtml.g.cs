#pragma checksum "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b644f7d06b7823c6f0304294c74fc95be8d1fce1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kaart_Index), @"mvc.1.0.view", @"/Views/Kaart/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\_ViewImports.cshtml"
using WdprPretparkDenhaag;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\_ViewImports.cshtml"
using WdprPretparkDenhaag.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b644f7d06b7823c6f0304294c74fc95be8d1fce1", @"/Views/Kaart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d70041b0c1e96b7a7755585082411e0daebc7b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Kaart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KaartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
  
    ViewData["Title"] = "Kaart titel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Kies een activiteit</h1>\r\n    \r\n    ");
#nullable restore
#line 9 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
Write(Html.DropDownList("Attractie", new SelectList(Model.Attracties.Select(k => k.Naam)), "Kies Attractie"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 10 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
Write(Html.DropDownList("Tijdslot", new SelectList(Model.Tijdsloten.Select(k => k.EindTijd)), "Kies Tijdslot"));

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n\r\n<h2>Huidige planning</h2>\r\n\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <th>Attractie</th>\r\n        </tr>\r\n        <tr>\r\n            <th>Tijdslot</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
         foreach(var item in Model.PlanningItems)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>                    \r\n                    ");
#nullable restore
#line 28 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.AttractieId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>                    \r\n                    ");
#nullable restore
#line 31 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TijdSlotId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Tahir\OneDrive\Bureaublad\WdprPretparkDenhaag\Views\Kaart\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>    \r\n\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KaartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591