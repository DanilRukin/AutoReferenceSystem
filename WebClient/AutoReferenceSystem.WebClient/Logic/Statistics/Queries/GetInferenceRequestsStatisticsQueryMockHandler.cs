using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetInferenceRequestsStatisticsQueryMockHandler : IRequestHandler<GetInferenceRequestsStatisticsQuery, Result<List<InferenceRequestsData>>>
    {
        public async Task<Result<List<InferenceRequestsData>>> Handle(GetInferenceRequestsStatisticsQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            return Result.Success(new List<InferenceRequestsData>
                {
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(1).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 125, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(1).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 100, Type = "С ошибкой" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(1).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 25, Type = "Успешно" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(2).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 9, Type = "С ошибкой" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(2).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 21, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(2).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 30, Type = "Всего" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(3).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 48, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(3).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 40, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(3).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 8, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(4).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 46, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(4).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 10, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(4).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 36, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(5).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 35, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(5).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 35, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(5).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 0, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(6).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 87, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(6).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 87, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(6).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 0, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(7).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 53, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(7).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 50, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(7).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 3 , Type = "С ошибкой" },
                });
        }
    }
}
