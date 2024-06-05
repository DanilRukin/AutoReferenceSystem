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


        [HttpPut("abstract/with_theses/{count:int}/{abstractionMethod}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractByThesesCount(
            [FromRoute]int count,
            [FromRoute] string abstractionMethod,
            [FromBody]string requestText)
        {
            try
            {
                if (Enum.TryParse(typeof(AbstractionMethod), abstractionMethod, true, out object? method))
                {
                    if (method != null)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var response = await _languageModel.GetAnAbstractByThesesCount(requestText, count, (AbstractionMethod)method);
                        stopwatch.Stop();
                        response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                    }
                }
                else
                {
                    return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }           
        }

        [HttpPut("abstract/by_abstract_relative_volume/{relativeVolume:double}/{abstractionMethod}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractByAbstractRelativeVolume(
            [FromRoute] double relativeVolume,
            [FromRoute] string abstractionMethod,
            [FromBody] string requestText)
        {
            try
            {
                if (Enum.TryParse(typeof(AbstractionMethod), abstractionMethod, true, out object? method))
                {
                    if (method != null)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var response = await _languageModel.GetAnAbstractByAbstractRelativeVolume(requestText, relativeVolume, (AbstractionMethod)method);
                        stopwatch.Stop();
                        response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                    }
                }
                else
                {
                    return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("abstract/with_specified_words_count/{count:int}/{abstractionMethod}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractWithSpecifiedWordsCount(
            [FromRoute] int count,
            [FromRoute] string abstractionMethod,
            [FromBody] string requestText)
        {
            try
            {
                if (Enum.TryParse(typeof(AbstractionMethod), abstractionMethod, true, out object? method))
                {
                    if (method != null)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var response = await _languageModel.GetAnAbstractWithSpecifiedWordsCount(requestText, count, (AbstractionMethod)method);
                        stopwatch.Stop();
                        response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                    }
                }
                else
                {
                    return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("abstract/with_specified_sentesies_count/{count:int}/{abstractionMethod}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractWithSpecifiedSentesiesCount(
            [FromRoute] int count,
            [FromRoute] string abstractionMethod,
            [FromBody] string requestText)
        {
            try
            {
                if (Enum.TryParse(typeof(AbstractionMethod), abstractionMethod, true, out object? method))
                {
                    if (method != null)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var response = await _languageModel.GetAnAbstractWithSpecifiedSentesiesCount(requestText, count, (AbstractionMethod)method);
                        stopwatch.Stop();
                        response.SummaryMetrics.RequestTime = (int)stopwatch.ElapsedMilliseconds;
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                    }
                }
                else
                {
                    return BadRequest($"Невозможно преобразовать метод реферирования: {abstractionMethod}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
