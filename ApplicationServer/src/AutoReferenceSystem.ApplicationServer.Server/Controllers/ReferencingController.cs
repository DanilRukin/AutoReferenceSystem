using AutoReferenceSystem.ApplicationServer.Application.Referencing.Queries;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.Server.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoReferenceSystem.ApplicationServer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferencingController : ControllerBase
    {
        private IMediator _mediator;

        public ReferencingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("healthcheck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult HealthCheck() => Ok();


        [HttpPut("abstract/with_theses/{count:int}/{modelId:int}/{abstractionMethod}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractByThesesCount(
            [FromRoute] int count,
            [FromRoute] int modelId,
            [FromRoute] string abstractionMethod,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractByThesesCountQuery query = new(modelId, requestText, count, userId, AbstractionMethodFromString(abstractionMethod));
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        [HttpPut("abstract/by_abstract_relative_volume/{relativeVolume:double}/{modelId:int}/{abstractionMethod}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractByAbstractRelativeVolume(
            [FromRoute] double relativeVolume,
            [FromRoute] int modelId,
            [FromRoute] string abstractionMethod,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractByAbstractRelativeVolumeQuery query = new(modelId, requestText, relativeVolume, userId, AbstractionMethodFromString(abstractionMethod));
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        [HttpPut("abstract/with_specified_words_count/{count:int}/{modelId:int}/{abstractionMethod}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractWithSpecifiedWordsCount(
            [FromRoute] int count,
            [FromRoute] int modelId,
            [FromRoute] string abstractionMethod,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractWithSpecifiedWordsCountQuery query = new(modelId, requestText, count, userId, AbstractionMethodFromString(abstractionMethod));
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        [HttpPut("abstract/with_specified_sentesies_count/{count:int}/{modelId:int}/{abstractionMethod}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractWithSpecifiedSentesiesCount(
            [FromRoute] int count,
            [FromRoute] int modelId,
            [FromRoute] string abstractionMethod,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractWithSpecifiedSentesiesCountQuery query = new(modelId, requestText, count, userId, AbstractionMethodFromString(abstractionMethod));
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        private AbstractionMethod AbstractionMethodFromString(string abstractionMethod)
        {
            AbstractionMethod result = AbstractionMethod.Unknown;
            if (Enum.TryParse(typeof(AbstractionMethod), abstractionMethod, out object? method))
            {
                if (method != null)
                {
                    result = (AbstractionMethod)method;
                }
            }
            return result;
        }
    }
}
