#pragma checksum "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c4de87249b1250fec937d20eeb1437d917bda83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Error), @"mvc.1.0.view", @"/Views/Home/Error.cshtml")]
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
#line 1 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\_ViewImports.cshtml"
using LoginApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\_ViewImports.cshtml"
using LoginApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c4de87249b1250fec937d20eeb1437d917bda83", @"/Views/Home/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4a32ff8657134ff9fe6ab9173f38fd625d8162", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c4de87249b1250fec937d20eeb1437d917bda834242", async() => {
                WriteLiteral(@"
    <!-- Simple HttpErrorPages | MIT License | https://github.com/HttpErrorPages -->
    <meta charset=""utf-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    <title>We&#39;ve got some trouble | 401 - Unauthorized</title>
    <style type=""text/css"">
        /*! normalize.css v5.0.0 | MIT License | github.com/necolas/normalize.css */

        html {
            font-family: sans-serif;
            line-height: 1.15;
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%
        }

        body {
            margin: 0
        }

        article, aside, footer, header, nav, section {
            display: block
        }

        h1 {
            font-size: 2em;
            margin: .67em 0
        }

        figcaption, figure, main {
            display: block
        }

        figure {
            margin: 1em 40px
        }

        hr {
            bo");
                WriteLiteral(@"x-sizing: content-box;
            height: 0;
            overflow: visible
        }

        pre {
            font-family: monospace,monospace;
            font-size: 1em
        }

        a {
            background-color: transparent;
            -webkit-text-decoration-skip: objects
        }

            a:active, a:hover {
                outline-width: 0
            }

        abbr[title] {
            border-bottom: none;
            text-decoration: underline;
            text-decoration: underline dotted
        }

        b, strong {
            font-weight: inherit
        }

        b, strong {
            font-weight: bolder
        }

        code, kbd, samp {
            font-family: monospace,monospace;
            font-size: 1em
        }

        dfn {
            font-style: italic
        }

        mark {
            background-color: #ff0;
            color: #000
        }

        small {
            font-size: 80%
        }

       ");
                WriteLiteral(@" sub, sup {
            font-size: 75%;
            line-height: 0;
            position: relative;
            vertical-align: baseline
        }

        sub {
            bottom: -.25em
        }

        sup {
            top: -.5em
        }

        audio, video {
            display: inline-block
        }

            audio:not([controls]) {
                display: none;
                height: 0
            }

        img {
            border-style: none
        }

        svg:not(:root) {
            overflow: hidden
        }

        button, input, optgroup, select, textarea {
            font-family: sans-serif;
            font-size: 100%;
            line-height: 1.15;
            margin: 0
        }

        button, input {
            overflow: visible
        }

        button, select {
            text-transform: none
        }

        [type=reset], [type=submit], button, html [type=button] {
            -webkit-appearance: button
        }");
                WriteLiteral(@"

            [type=button]::-moz-focus-inner, [type=reset]::-moz-focus-inner, [type=submit]::-moz-focus-inner, button::-moz-focus-inner {
                border-style: none;
                padding: 0
            }

            [type=button]:-moz-focusring, [type=reset]:-moz-focusring, [type=submit]:-moz-focusring, button:-moz-focusring {
                outline: 1px dotted ButtonText
            }

        fieldset {
            border: 1px solid silver;
            margin: 0 2px;
            padding: .35em .625em .75em
        }

        legend {
            box-sizing: border-box;
            color: inherit;
            display: table;
            max-width: 100%;
            padding: 0;
            white-space: normal
        }

        progress {
            display: inline-block;
            vertical-align: baseline
        }

        textarea {
            overflow: auto
        }

        [type=checkbox], [type=radio] {
            box-sizing: border-box;
        ");
                WriteLiteral(@"    padding: 0
        }

        [type=number]::-webkit-inner-spin-button, [type=number]::-webkit-outer-spin-button {
            height: auto
        }

        [type=search] {
            -webkit-appearance: textfield;
            outline-offset: -2px
        }

            [type=search]::-webkit-search-cancel-button, [type=search]::-webkit-search-decoration {
                -webkit-appearance: none
            }

        ::-webkit-file-upload-button {
            -webkit-appearance: button;
            font: inherit
        }

        details, menu {
            display: block
        }

        summary {
            display: list-item
        }

        canvas {
            display: inline-block
        }

        template {
            display: none
        }

        [hidden] {
            display: none
        }
        /*! Simple HttpErrorPages | MIT X11 License | https://github.com/AndiDittrich/HttpErrorPages */

        body, html {
            width: 100");
                WriteLiteral(@"%;
            height: 100%;
            background-color: #21232a
        }

        body {
            color: #fff;
            text-align: center;
            text-shadow: 0 2px 4px rgba(0,0,0,.5);
            padding: 0;
            min-height: 100%;
            -webkit-box-shadow: inset 0 0 100px rgba(0,0,0,.8);
            box-shadow: inset 0 0 100px rgba(0,0,0,.8);
            display: table;
            font-family: ""Open Sans"",Arial,sans-serif
        }

        h1 {
            font-family: inherit;
            font-weight: 500;
            line-height: 1.1;
            color: inherit;
            font-size: 36px
        }

            h1 small {
                font-size: 68%;
                font-weight: 400;
                line-height: 1;
                color: #777
            }

        a {
            text-decoration: none;
            color: #fff;
            font-size: inherit;
            border-bottom: dotted 1px #707070
        }

        .lead {
 ");
                WriteLiteral(@"           color: silver;
            font-size: 21px;
            line-height: 1.4
        }

        .cover {
            display: table-cell;
            vertical-align: middle;
            padding: 0 20px
        }

        footer {
            position: fixed;
            width: 100%;
            height: 40px;
            left: 0;
            bottom: 0;
            color: #a0a0a0;
            font-size: 14px
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c4de87249b1250fec937d20eeb1437d917bda8312040", async() => {
                WriteLiteral("\r\n    <div class=\"cover\">\r\n        <h1>Unauthorized <small>401</small></h1>\r\n        <p class=\"lead\">The requested resource requires an authentication.</p>\r\n\r\n");
#nullable restore
#line 292 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
         if (@ViewBag.AdminID > 0)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <p>");
#nullable restore
#line 294 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
          Write(ViewBag.AdminLastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 294 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
                                 Write(ViewBag.AdminFirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(";</p>\r\n            <p>You are Admin. Do Not Acces User Page!</p>\r\n");
#nullable restore
#line 296 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <p>");
#nullable restore
#line 299 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
          Write(ViewBag.UserLastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 299 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
                                Write(ViewBag.UserFirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(";</p>\r\n            <p>You are User. Do Not Acces Admin Page!</p>\r\n");
#nullable restore
#line 301 "C:\Users\gkadi\source\repos\LoginApplication\LoginApplication\Views\Home\Error.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <p>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c4de87249b1250fec937d20eeb1437d917bda8314395", async() => {
                    WriteLiteral("Home");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
