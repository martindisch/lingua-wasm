using Microsoft.AspNetCore.Mvc;

namespace DetectionApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class DetectionController : ControllerBase
    {
        [HttpPost("v1/detect-language")]
        public DetectionResponse DetectLanguage(
            [FromBody] DetectionRequest request)
        {
            return new DetectionResponse(request.Text);
        }
    }

    public record DetectionRequest(string Text);

    public record DetectionResponse(string DetectedLanguage);
}
