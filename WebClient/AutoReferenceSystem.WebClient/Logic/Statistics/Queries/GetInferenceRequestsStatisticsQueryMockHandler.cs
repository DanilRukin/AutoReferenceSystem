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
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(1).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 25, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(1).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 23, Type = "С ошибкой" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(1).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 2, Type = "Успешно" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(5).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 9, Type = "С ошибкой" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(5).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 21, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(5).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 30, Type = "Всего" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(10).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 15, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(10).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 14, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(10).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 1, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(15).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 40, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(15).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 40, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(15).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 0, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(20).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 35, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(20).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 35, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(20).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 0, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(25).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 27, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(25).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 23, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(25).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 4, Type = "С ошибкой" },

                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(30).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 21, Type = "Всего" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(30).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 21, Type = "Успешно" },
                    new InferenceRequestsData { CheckDate = DateTime.Now.AddMinutes(30).ToString("dd.MM.yyyy:HH:mm"), RequestsCount = 3 , Type = "С ошибкой" },
                });
        }
    }
}
