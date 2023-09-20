using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using quantbeApplication.Controllers;

namespace QuantbeTest
{
    public class QuantbeOAControllerTests
    {
        [Fact]
        public void EncUrl_ValidRequest_ReturnsShortUrl()
        {
            var controller = new QuantbeOAController();
            var request = new QuantbeOAController.RequestModel
            {
                LongUrl = "http://testtest.com",
                MaxLength = 6
            };

            var result = controller.EncUrl(request) as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<string>(result.Value);
            Assert.True(result.Value.ToString().Length <= 6);
            Assert.True(result.Value.ToString() == "7C8ani");
        }

        [Fact]
        public void EncUrl_InvalidUrlFormat_ReturnsBadRequest()
        {
            // Arrange
            var controller = new QuantbeOAController();
            var request = new QuantbeOAController.RequestModel
            {
                LongUrl = "invalid_url",
                MaxLength = 6
            };

            // Act
            var result = controller.EncUrl(request) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid original URL format.", result.Value);
        }

        [Fact]
        public void EncUrl_nullurl_ReturnsBadRequest()
        {
            // Arrange
            var controller = new QuantbeOAController();
            var request = new QuantbeOAController.RequestModel
            {
                LongUrl = null,
                MaxLength = 6
            };

            // Act
            var result = controller.EncUrl(request) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Original URL cannot be null or empty.", result.Value);
        }
    }
}
