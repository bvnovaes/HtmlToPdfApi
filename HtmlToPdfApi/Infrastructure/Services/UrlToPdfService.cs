using HtmlToPdfApi.Core.Interfaces;
using System.Text;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace HtmlToPdfApi.Infrastructure.Services
{
    public class UrlToPdfService(IConverter converter) : IUrlToPdfService
    {
        private readonly IConverter _converter = converter;

        public async Task<byte[]> ConvertUrlToPdfAsync(string url, Orientation orientation, PaperKind paperKind)
        {
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = orientation,
                    PaperSize = paperKind,
                    Margins = new MarginSettings
                    {
                         Top = 5,
                         Bottom = 5,
                         Left = 5,
                         Right = 5
                    }
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8",
                            LoadImages = true,
                            PrintMediaType = true,
                            EnableIntelligentShrinking = false,
                            Background = false,
                            EnableJavascript = true,
                            enablePlugins = true,
                            MinimumFontSize = 10
                        },
                        PagesCount = true,
                        Encoding = Encoding.UTF8,
                        Page = url
                    }
                }
            };

            return await Task.Run(() =>
            {
                var result = _converter.Convert(doc);
                GC.Collect(); 
                return result;
            });
        }
    }
}
