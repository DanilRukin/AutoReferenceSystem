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


        [HttpPut("abstract/with_theses/{count:int}/{modelId:int}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetAnAbstractByThesesCount(
            [FromRoute] int count,
            [FromRoute] int modelId,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractByThesesCountQuery query = new(modelId, requestText, count, userId);
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        [HttpPut("abstract/by_abstract_relative_volume/{relativeVolume:double}/{modelId:int}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetRouteForAnAbstractByAbstractRelativeVolume(
            [FromRoute] double relativeVolume,
            [FromRoute] int modelId,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractByAbstractRelativeVolumeQuery query = new(modelId, requestText, relativeVolume, userId);
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        [HttpPut("abstract/with_specified_words_count/{count:int}/{modelId:int}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetRouteForAnAbstractWithSpecifiedWordsCount(
            [FromRoute] int count,
            [FromRoute] int modelId,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractWithSpecifiedWordsCountQuery query = new(modelId, requestText, count, userId);
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }

        [HttpPut("abstract/with_specified_sentesies_count/{count:int}/{modelId:int}/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LanguageModelResponseDto>> GetRouteForAnAbstractWithSpecifiedSentesiesCount(
            [FromRoute] int count,
            [FromRoute] int modelId,
            [FromRoute] Guid userId,
            [FromBody] string requestText)
        {
            GetAnAbstractWithSpecifiedSentesiesCountQuery query = new(modelId, requestText, count, userId);
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
                return Ok(response.Value);
            return ResultErrorsHandler.Handle(response);
        }
    }
}
