#pragma checksum "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bcba8d39a4107b32ce77386d35c219f6594d81b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collection_Details), @"mvc.1.0.view", @"/Views/Collection/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bcba8d39a4107b32ce77386d35c219f6594d81b", @"/Views/Collection/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d20681ee69729f86e62720c04280372581e44af", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ItrKurs.Models.Collection>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
  
    ViewBag.Title = Model.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Item ");
#nullable restore
#line 5 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9bcba8d39a4107b32ce77386d35c219f6594d81b3384", async() => {
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onload", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 115, "ShowFieldTable(", 115, 15, true);
#nullable restore
#line 6 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
AddHtmlAttributeValue("", 130, Model.bitMask, 130, 14, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 144, ");", 144, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<table class=\"table table-hover home-content table-bordered \">\r\n    <thead class=\"thead-light\">\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Description</th>\r\n            <th>Tags</th>\r\n            <th>DateCreate</th>\r\n");
#nullable restore
#line 15 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
             for (int i = 0; i < @ViewBag.m_additionalFields.Length; ++i)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th");
            BeginWriteAttribute("id", " id=\"", 500, "\"", 513, 1);
#nullable restore
#line 17 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
WriteAttributeValue("", 505, i+"a", 505, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 18 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
               Write(ViewBag.m_additionalFields[@i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n");
#nullable restore
#line 20 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n            <td>");
#nullable restore
#line 25 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
           Write(Model.Discription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
           Write(Model.Tags);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
           Write(Model.DateCreate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"0\">");
#nullable restore
#line 29 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            \r\n            <td id=\"2\">");
#nullable restore
#line 31 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Int2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"3\">");
#nullable restore
#line 32 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Int3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"4\">");
#nullable restore
#line 33 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Bool1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"5\">");
#nullable restore
#line 34 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Bool2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"6\">");
#nullable restore
#line 35 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Bool3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"7\">");
#nullable restore
#line 36 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Longtext1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"8\">");
#nullable restore
#line 37 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                  Write(Model.Longtext2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td id=\"9\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1213, "\"", 1285, 1);
#nullable restore
#line 39 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
WriteAttributeValue("", 1219, Model.ImgSrc!=null ? Model.ImgSrc : "\\uploadedfiles\\item.png", 1219, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"250\" alt=\"\\uploadedfiles\\item.png\">\r\n            </td>\r\n\r\n\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
#nullable restore
#line 48 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Коментарии</h4>\r\n    <hr />\r\n");
#nullable restore
#line 52 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
     foreach ((string, string) s in ViewBag.Comments)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""container"">
            <div class=""row"">

                <div class=""col-sm-2"">
                    <div class=""container"">
                        <div class=""col-xl-9 px-0""><img src=""\uploadedfiles\avatar-user.png"" class=""img-fluid"" alt=""\uploadedfiles\item.png""></div>
                    </div>
                </div>
                <div class=""col-sm-9"">
                    <div class=""col "">

                        <div class=""row""><p class=""font-weight-bold"">");
#nullable restore
#line 65 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                                                                Write(s.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></div>\r\n\r\n                        <div class=\"row\"><p class=\"font-italic\">");
#nullable restore
#line 67 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
                                                           Write(s.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n        <hr />\r\n");
#nullable restore
#line 74 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container"">
        <div class=""row"">
            <div class=""col-xl-12 "">
                <textarea class=""form-control"" rows=""2"" placeholder=""Comment here...."" aria-label=""Comment here"" id=""CommentId""></textarea>
            </div>
            <div class=""col-sm-1 "">
                <div class=""align-bottom"">
                    <button class=""btn btn-outline-info "" type=""submit""");
            BeginWriteAttribute("onclick", " onclick=\"", 2667, "\"", 2709, 3);
            WriteAttributeValue("", 2677, "comment(\'CommentId\',\'", 2677, 21, true);
#nullable restore
#line 83 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
WriteAttributeValue("", 2698, Model.Id, 2698, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2707, "\')", 2707, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Send</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 88 "F:\ItrKurs\ItrKurs\Views\Collection\Details.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ItrKurs.Models.Collection> Html { get; private set; }
    }
}
#pragma warning restore 1591
