using Microsoft.AspNetCore.Mvc;
using System;

namespace quantbeApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuantbeOAController : Controller
    {
        [HttpPost]
        public IActionResult EncUrl([FromBody] RequestModel request)
        {
            try
            {
                // check if the url in body is null or empty, throw exception
                if (string.IsNullOrWhiteSpace(request.LongUrl))
                {
                    throw new ArgumentException("Original URL cannot be null or empty.");
                }
                // check if the url is in correct format, throw exception
                Uri uriResult;
                bool isValidUrl = Uri.TryCreate(request.LongUrl, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (!isValidUrl)
                {
                    throw new FormatException("Invalid original URL format.");
                }

                // encrypt longUrl from req body
                string longUrl = request.LongUrl;
                int maxLen = request.MaxLength.HasValue ? request.MaxLength.Value : 6;
                string shortUrl = Encrypter.EncryptUrl(longUrl, maxLen);
                // res encrypted url to frontend
                return Ok(shortUrl);
            }
            // url null or empty ex
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            // url format error ex
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            // general ex
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        // req model for this particular route
        public class RequestModel
        {
            public int? MaxLength { get; set; }
            public string? LongUrl { get; set; }
        }
    }
}
