using Lingua;
using Microsoft.AspNetCore.Mvc;

namespace DetectionApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class DetectionController : ControllerBase
    {
        private readonly Detector detector;

        public DetectionController(Detector detector)
        {
            this.detector = detector;
        }

        [HttpPost("v1/detect-language")]
        public DetectionResponse DetectLanguage(
            [FromBody] DetectionRequest request)
        {
            var detectedLanguageCode = detector.DetectLanguage(request.Text);
            var detectedLanguage = Detector.GetLanguage(detectedLanguageCode);
            return new DetectionResponse(detectedLanguage);
        }
    }

    public record DetectionRequest(string Text);

    public record DetectionResponse(string DetectedLanguage);
}
