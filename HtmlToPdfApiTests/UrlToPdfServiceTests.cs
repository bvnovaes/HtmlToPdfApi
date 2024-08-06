using HtmlToPdfApi.Core.Interfaces;
using Moq;
using WkHtmlToPdfDotNet;

namespace HtmlToPdfApiTests
{
    public class UrlToPdfServiceTests
    {
        [Fact]
        public async Task ConvertUrlToPdf_ShouldReturnPdfBytes()
        {
            // Arrange
            var mockService = new Mock<IUrlToPdfService>();
            var expectedPdfBytes = new byte[] { 1, 2, 3 };
            var orientation = Orientation.Portrait;
            var paperKind = PaperKind.A4;
            var url = "https://www.google.com";

            mockService.Setup(c => c.ConvertUrlToPdfAsync(It.IsAny<string>(), orientation, paperKind)).ReturnsAsync(expectedPdfBytes);

            // Act
            var urlConverter = mockService.Object;
            var pdfBytes = await urlConverter.ConvertUrlToPdfAsync(url, orientation, paperKind);

            // Assert
            Assert.NotNull(pdfBytes);
            Assert.Equal(expectedPdfBytes, pdfBytes);
        }
    }
}
