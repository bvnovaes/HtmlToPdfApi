using HtmlToPdfApi.Infrastructure.Services;
using Moq;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace HtmlToPdfApiTests
{
    public class HtmlToPdfServiceTests
    {
        [Fact]
        public async Task ConvertHtmlToPdf_ShouldReturnPdfBytes()
        {
            // Arrange
            var mockConverter = new Mock<IConverter>();
            var htmlToPdfService = new HtmlToPdfService(mockConverter.Object);
            var orientation = Orientation.Portrait;
            var paperKind = PaperKind.A4;

            // Simule a conversão (substitua pelo comportamento real do DinkToPdf)
            var expectedPdfBytes = new byte[] { 1, 2, 3 };
            mockConverter.Setup(c => c.Convert(It.IsAny<HtmlToPdfDocument>()))
                         .Returns(expectedPdfBytes);

            var htmlContent = "<html><body><h1>Hello, world!</h1></body></html>";

            // Act
            var pdfBytes = await htmlToPdfService.ConvertHtmlToPdfAsync(htmlContent, orientation, paperKind);

            // Assert
            Assert.NotNull(pdfBytes);
            Assert.Equal(expectedPdfBytes, pdfBytes);
        }
    }
}
