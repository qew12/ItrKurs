#pragma checksum "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a45745de464b7a4b2d5f63af9265bf3a51b0206a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collection_Main), @"mvc.1.0.view", @"/Views/Collection/Main.cshtml")]
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
#line 1 "F:\ItrKurs\ItrKurs\Views\_ViewImports.cshtml"
using ItrKurs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\ItrKurs\ItrKurs\Views\_ViewImports.cshtml"
using ItrKurs.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a45745de464b7a4b2d5f63af9265bf3a51b0206a", @"/Views/Collection/Main.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d20681ee69729f86e62720c04280372581e44af", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_Main : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ItrKurs.Models.Collection>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml"
  
    ViewBag.Title = "Все коллекции";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 8 "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml"
 foreach (var c in ViewBag.item)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml"
Write(c.Item1);

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml"
Write(c.Item2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml"
Write(c.Item3);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr/>\r\n");
#nullable restore
#line 14 "F:\ItrKurs\ItrKurs\Views\Collection\Main.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ItrKurs.Models.Collection>> Html { get; private set; }
    }
}
#pragma warning restore 1591
