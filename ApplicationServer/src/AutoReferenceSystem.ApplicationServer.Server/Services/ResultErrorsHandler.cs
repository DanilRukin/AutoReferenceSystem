using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using Microsoft.AspNetCore.Mvc;

namespace AutoReferenceSystem.ApplicationServer.Server.Services
{
    internal static class ResultErrorsHandler
    {
        internal static ActionResult<T> Handle<T>(Result<T> result)
        {
            if (result.ResultStatus == ResultStatus.NotFound)
                return new NotFoundObjectResult(result.Errors);
            else if (result.ResultStatus == ResultStatus.Error)
                return new BadRequestObjectResult(result.Errors);
            else
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        internal static ActionResult Handle(Result result)
        {
            if (result.ResultStatus == ResultStatus.NotFound)
                return new NotFoundObjectResult(result.Errors);
            else if (result.ResultStatus == ResultStatus.Error)
                return new BadRequestObjectResult(result.Errors);
            else
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
