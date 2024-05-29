using FakeModelApi.Data;
using FakeModelApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FakeModelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private ILogger<ModelController> _logger;
        private FakeLanguageModel _languageModel;

        public ModelController(FakeLanguageModel languageModel, ILogger<ModelController> logger)
        {
            _languageModel = languageModel ?? throw new ArgumentNullException(nameof(languageModel));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("healthcheck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult HealthCheck() => Ok();


        [HttpPut("abstract/with_theses/{count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponse>> GetAnAbstractByThesesCount([FromRoute]int count, [FromBody]string requestText)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = await _languageModel.GetAnAbstractByThesesCount(requestText, count);
                stopwatch.Stop();
                response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }           
        }

        [HttpPut("abstract/by_abstract_relative_volume/{relativeVolume:double}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponse>> GetAnAbstractByAbstractRelativeVolume([FromRoute] double relativeVolume,
            [FromBody] string requestText)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = await _languageModel.GetAnAbstractByAbstractRelativeVolume(requestText, relativeVolume);
                stopwatch.Stop();
                response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("abstract/with_specified_words_count/{count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponse>> GetAnAbstractWithSpecifiedWordsCount([FromRoute] int count,
            [FromBody] string requestText)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = await _languageModel.GetAnAbstractWithSpecifiedWordsCount(requestText, count);
                stopwatch.Stop();
                response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("abstract/with_specified_sentesies_count/{count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponse>> GetAnAbstractWithSpecifiedSentesiesCount([FromRoute] int count,
            [FromBody] string requestText)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = await _languageModel.GetAnAbstractWithSpecifiedSentesiesCount(requestText, count);
                stopwatch.Stop();
                response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
