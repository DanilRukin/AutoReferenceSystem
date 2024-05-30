using AutoReferenceSystem.ApplicationServer.Application.Services;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.Referencing.Queries
{
    internal class GetAnAbstractByAbstractRelativeVolumeQueryHandler :
        IRequestHandler<GetAnAbstractByAbstractRelativeVolumeQuery, Result<LanguageModelResponseDto>>
    {

        private ILoadBalanser _loadBalancer;
        private HttpClient _client;

        public GetAnAbstractByAbstractRelativeVolumeQueryHandler(ILoadBalanser loadBalancer, IHttpClientFactory factory)
        {
            _loadBalancer = loadBalancer ?? throw new ArgumentNullException(nameof(loadBalancer));
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            _client = factory.CreateClient();
        }

        public async Task<Result<LanguageModelResponseDto>> Handle(GetAnAbstractByAbstractRelativeVolumeQuery request, CancellationToken cancellationToken)
        {
            BaseApiQuery baseApiQuery = new();
            return await baseApiQuery.GetResponse(
                client: _client,
                loadBalancer: _loadBalancer,
                sourceText: request.SourceText,
                modelId: request.ModelId,
                token: cancellationToken,
                query: request,
                routeConstructor: (address, query) => ApiHelper.GetRouteForAnAbstractByAbstractRelativeVolume(address, query.RelativeVolume)
             );
        }
    }
}
