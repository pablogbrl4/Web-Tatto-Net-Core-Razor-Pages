#pragma checksum "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "942ba252f69c03033cd163fb1ab1d6676bfe42cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Estudio_ContratoMenor), @"mvc.1.0.view", @"/Views/Estudio/ContratoMenor.cshtml")]
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
#line 1 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\_ViewImports.cshtml"
using Tatto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\_ViewImports.cshtml"
using Tatto.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\_ViewImports.cshtml"
using Tatto.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"942ba252f69c03033cd163fb1ab1d6676bfe42cc", @"/Views/Estudio/ContratoMenor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e77394e751736486e92ff4845e3341227d7f20f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Estudio_ContratoMenor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tatto.Models.Estudio>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/cep.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tatto.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/navdark.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myfrm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
   ViewData["Title"] = "Contrato para Menor";
    Layout = "/Views/Shared/_LayoutAdminEstudio.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style>
    .h3-custom {
        text-align: center;
    }

    .p-custom {
        text-align: justify;
        font-size: 20px;
        line-height: 2.5;
    }

    #end {
        text-align: center;
    }

    .span-custom {
        font-weight: bold;
        background-color: mistyrose;
        text-decoration: underline;
        padding: 8px;
    }
</style>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "942ba252f69c03033cd163fb1ab1d6676bfe42cc6788", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "942ba252f69c03033cd163fb1ab1d6676bfe42cc7887", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "942ba252f69c03033cd163fb1ab1d6676bfe42cc9044", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"bg-white my-10\">\r\n    <div class=\"container\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "942ba252f69c03033cd163fb1ab1d6676bfe42cc10238", async() => {
                WriteLiteral(@"

            <h2 class=""mt-5"">Contrato para Menor de Idade</h2>

            <div class=""card card-default"">
                <div class=""card-body"">

                    <h3 class=""h3-custom"" >
                        TERMO DE AUTORIZAÇÃO DE TATUAGEM
                    </h3><br />

                    <h3 class=""h3-custom"" >
                        <span class=""span-custom"" contentEditable=""true"">NOME DO ESTÚDIO</span class=""span-custom"">
                    </h3><br />

                    <p class=""p-custom"">
                        Eu,
                        <span class=""span-custom"" contentEditable=""true"">""Nome do Responsável""</span class=""span-custom""> nascido em
                        <span class=""span-custom"" contentEditable=""true"">00/00/0000</span class=""span-custom"">, Idade
                        <span class=""span-custom"" contentEditable=""true"">00</span class=""span-custom""> anos, Estado Civil
                        <span class=""span-custom"" contentEditable=""true"">Solteiro(a)");
                WriteLiteral(@"/Casado(a)/Divorciado(a)</span class=""span-custom"">, RG:
                        <span class=""span-custom"" contentEditable=""true"">00.000.000</span class=""span-custom"">, Residente e domiciliado na
                        <span class=""span-custom"" contentEditable=""true"">Rua/Av</span class=""span-custom"">, Bairro
                        <span class=""span-custom"" contentEditable=""true"">NOME DO BAIRRO</span class=""span-custom"">, cep
                        <span class=""span-custom"" contentEditable=""true"">00000-000</span class=""span-custom"">, Telefone
                        <span class=""span-custom"" contentEditable=""true"">(00) 0 0000-0000</span class=""span-custom"">, no gozo pleno de minhas faculdades mentais e psíquicas, pelo presente e na melhor forma de direito, autorizo o estúdio
                        <span class=""span-custom"" contentEditable=""true"">");
#nullable restore
#line 65 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                    Write(Model.NomeEstudio);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span class=\"span-custom\"> estabelecido na\r\n                        <span class=\"span-custom\" contentEditable=\"true\">");
#nullable restore
#line 66 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                    Write(Model.Endereco);

#line default
#line hidden
#nullable disable
                WriteLiteral(", N: ");
#nullable restore
#line 66 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                                        Write(Model.Numero);

#line default
#line hidden
#nullable disable
                WriteLiteral(", Bairro: ");
#nullable restore
#line 66 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                                                               Write(Model.Bairro);

#line default
#line hidden
#nullable disable
                WriteLiteral(",");
#nullable restore
#line 66 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                                                                             Write(Model.Complemento);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 66 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                                                                                                 Write(Model.Cidade);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 66 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                                                                                                                 Write(Model.UF);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span class=""span-custom""> a executar sobre a pele de meu dependente:
                        <span class=""span-custom"" contentEditable=""true"">Nome do filho(a) Neto(a) ou sobrinho(a)</span class=""span-custom"">, menor de idade, nascida(o) em
                        <span class=""span-custom"" contentEditable=""true"">00/00/0000</span class=""span-custom"">,
                        <span class=""span-custom"" contentEditable=""true"">Cidade / UF</span class=""span-custom"">, portador do RG
                        <span class=""span-custom"" contentEditable=""true"">00.000.000</span class=""span-custom"">,
                        que em minha companhia reside e pelo qual sou inteiramente responsável, a gravação da tatuagem representada pelo desenho
                        <span class=""span-custom"" contentEditable=""true"">DIGITE O NOME DO DESENHO DESEJADO</span class=""span-custom"">,
                        assumo ainda, na qualidade do genitor do menor, plena responsabilidade pela gravação, eximindo de qualquer responsabili");
                WriteLiteral("dade civil ou criminal o agente elaborador.\r\n                    </p>\r\n\r\n                    <p class=\"p-custom\" id=\"end\">\r\n                        <span class=\"span-custom\" contentEditable=\"true\">");
#nullable restore
#line 77 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                    Write(Model.Cidade);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span class=\"span-custom\">,\r\n                        <span class=\"span-custom\" contentEditable=\"true\">");
#nullable restore
#line 78 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                    Write(DateTime.Today.Day);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span class=\"span-custom\"> do\r\n                        <span class=\"span-custom\" contentEditable=\"true\">");
#nullable restore
#line 79 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                    Write(DateTime.Today.Month);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span class=\"span-custom\"> de\r\n                        <span class=\"span-custom\" contentEditable=\"true\">");
#nullable restore
#line 80 "C:\Users\Eddy Moura\Documents\Tatto 28_09_20\Tatto\Views\Estudio\ContratoMenor.cshtml"
                                                                    Write(DateTime.Today.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span class=""span-custom"">
                    </p>

                    <p class=""p-custom"" id=""end"">
                        Ass. Do Tatuador: ______________________________________________________
                    </p>

                    <p class=""p-custom"" id=""end"">
                        Ass. Do Menor: _________________________________________________________
                    </p>

                    <p class=""p-custom"" id=""end"">
                        Ass. Do Responsável: ___________________________________________________
                    </p>

                </div>
            </div>

        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        <h2 class=""mt-5"">Conclusão</h2>

        <div class=""card card-default"">
            <div class=""row card-body"">
                <div class=""form-group col-md-3 mb-1"">
                    <button type=""submit"" class=""btn btn-success btn-block px-4"" onclick=""myPrint('myfrm')"">&nbsp;&nbsp; Imprimir &nbsp;&nbsp;</button>
                </div>
                <div class=""form-group col-md-6 mb-0"">

                </div>
                <div class=""form-group col-md-3 mb-1"">
                    <button type=""submit"" class=""btn btn-danger btn-block px-4 pull-right""> &nbsp; Voltar &nbsp;</button>
                </div>
            </div>
        </div>

    </div>

</div>

<script>
    function myPrint(myfrm) {
        var printdata = document.getElementById(myfrm);
        newwin = window.open("""");
        newwin.document.write(printdata.outerHTML);
        newwin.print();
        newwin.close();
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tatto.Models.Estudio> Html { get; private set; }
    }
}
#pragma warning restore 1591
