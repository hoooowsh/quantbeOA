using Microsoft.VisualStudio.TestTools.UnitTesting;
using quantbeApplication.Controllers;

[TestClass]
public class QuantbeOAControllerTests
{
    [TestMethod]
    public void EncUrl_ValidUrl_ShouldReturnShortUrl()
    {
        var controller = new QuantbeOAController();
        var request = new QuantbeOAController.RequestModel
        {
            LongUrl = "https://www.quantbe.com/welcome/canada/logs/validate",
            MaxLength = 6
        };
        var result = controller.EncUrl(request) as OkObjectResult;

        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);

        var shortUrl = result.Value as string;
        Assert.IsNotNull(shortUrl);
    }

    [TestMethod]
    public void EncUrl_NullUrl_ShouldReturnBadRequest()
    {
        var controller = new QuantbeOAController();
        var request = new QuantbeOAController.RequestModel
        {
            LongUrl = null,
            MaxLength = 6
        };

        var result = controller.EncUrl(request) as BadRequestObjectResult;

        Assert.IsNotNull(result);
        Assert.AreEqual(400, result.StatusCode);
    }
}