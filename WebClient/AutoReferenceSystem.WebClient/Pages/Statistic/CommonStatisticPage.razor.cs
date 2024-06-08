using AntDesign;
using AntDesign.Charts;
using AutoReferenceSystem.WebClient.Infrastructure.Services;
using AutoReferenceSystem.WebClient.Logic.Extensions;
using AutoReferenceSystem.WebClient.Logic.Statistics.Queries;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AutoReferenceSystem.WebClient.Pages.Statistic
{
    public partial class CommonStatisticPage
    {
        [Inject]
        protected IMessageNotificator MessageNotificator { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadServers();
                await LoadInferenceRequestsChart();
                await LoadCpuUtilizationChart();
                await LoadGpuUtilizationChart();
                await LoadMemoryUtilizationChart();
                await LoadAverageRequestProcessingTimeChart();
                await LoadAbstractionMethodQueriesSplitChart();

                await base.OnInitializedAsync();
            }
            catch (Exception ex)
            {
                MessageNotificator.ShowError(ex.Message);
            }     
        }

        #region Сервера моделей
        private IList<ServerData> _servers = new List<ServerData>();

        private IEnumerable<ServerData> _selectedServers;

        private ITable _table;

        private async Task LoadServers()
        {
            GetServersDataQuery query = new GetServersDataQuery();
            var response = await Mediator.Send(query);
            if (response.IsSuccess)
            {
                _servers = response.Value;
                await MessageNotificator.ShowSuccess("Данные о серверах моделей успешно загружены");
            }
            else
            {
                await MessageNotificator.ShowError("Не удалось получить данные о серверах моделей");
            }
        }
        #endregion

        #region График - "Запросы на инференс"
        /// <summary>
        /// График - "Запросы на инференс"
        /// </summary>
        private IChartComponent _inferenceRequestsChart;

        private InferenceRequestsData[] _inferenceAllRequests;

        private LineConfig _inferenceRequestsChartConfig = new LineConfig
        {
            Padding = "auto",
            XField = "checkDate",
            YField = "requestsCount",
            Legend = new Legend
            {
                Visible = true,
                Position = "right-top",
                Title = new LegendTitle() { Visible = true, Text = "Обозначения" },
            },
            Color = new string[] { "#000000", "#d62728", "#2ca02c" },
            Smooth = true,
            SeriesField = "type"
        };

        private async Task LoadInferenceRequestsChart()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddHours(1);
            GetInferenceRequestsStatisticsQuery inferenceRequestsStatistic = new(1, 1, startDate, endDate);
            var inferenceStatisticResponse = await Mediator.Send(inferenceRequestsStatistic);
            if (inferenceStatisticResponse.IsSuccess)
            {
                _inferenceAllRequests = inferenceStatisticResponse.Value.ToArray();
                await MessageNotificator.ShowSuccess("График \"Запросы на инференс\" загружен");
            }
            else
            {
                await MessageNotificator.ShowError(inferenceStatisticResponse.Errors.AsOneString());
            }
            await _inferenceRequestsChart.ChangeData(_inferenceAllRequests);
        } 
        #endregion

        #region График - "Средняя (общая) загрузка ЦП"
        /// <summary>
        /// График - "Средняя (общая) загрузка ЦП"
        /// </summary>
        private IChartComponent _cpuUtilizationChart;
        private CpuUtilizationData[] _cpuUtilizationData;

        private LineConfig _cpuUtilizationChartConfig = new LineConfig
        {
            Padding = "auto",
            XField = "interval",
            YField = "cpuUtilization",
            Legend = new Legend
            {
                Visible = true,
                Position = "right-top",
                Title = new LegendTitle() { Visible = true, Text = "Обозначения" },
            },
            Smooth = true,
        };

        private async Task LoadCpuUtilizationChart()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddHours(1);
            GetCpuUtilizationStatisticsQuery cpuUtilizationStatistic = new(1, 1, 60000, startDate, endDate);
            var cpuUtilizationStatisticResponse = await Mediator.Send(cpuUtilizationStatistic);
            if (cpuUtilizationStatisticResponse.IsSuccess)
            {
                _cpuUtilizationData = cpuUtilizationStatisticResponse.Value.ToArray();
                await MessageNotificator.ShowSuccess("График \"Средняя (общая) загрузка ЦП\" загружен");
            }
            else
            {
                await MessageNotificator.ShowError(cpuUtilizationStatisticResponse.Errors.AsOneString());
            }
            await _cpuUtilizationChart.ChangeData(_cpuUtilizationData);
        } 
        #endregion

        #region График - "Средняя нагрузка на ОЗУ"
        /// <summary>
        /// График - "Средняя нагрузка на ОЗУ"
        /// </summary>
        private IChartComponent _memoryUtilizationChart;
        private MemoryUtilizationData[] _memoryUtilizationData;

        private LineConfig _memoryUtilizationChartConfig = new LineConfig
        {
            Padding = "auto",
            XField = "interval",
            YField = "amountInBytes",
            Legend = new Legend
            {
                Visible = true,
                Position = "right-top",
                Title = new LegendTitle() { Visible = true, Text = "Обозначения" },
            },
            Smooth = true,
        };

        private async Task LoadMemoryUtilizationChart()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddHours(1);
            GetMemoryUtilizationStatisticsQuery memoryUtilizationStatistic = new(1, 1, 60000, startDate, endDate);
            var memoryUtilizationStatisticResponse = await Mediator.Send(memoryUtilizationStatistic);
            if (memoryUtilizationStatisticResponse.IsSuccess)
            {
                _memoryUtilizationData = memoryUtilizationStatisticResponse.Value.ToArray();
                await MessageNotificator.ShowSuccess("График \"Средняя нагрузка на ОЗУ\" загружен");
            }
            else
            {
                await MessageNotificator.ShowError(memoryUtilizationStatisticResponse.Errors.AsOneString());
            }
            await _memoryUtilizationChart.ChangeData(_memoryUtilizationData);
        } 
        #endregion

        #region График - "Средняя (общая) загрузка видеокарты"
        /// <summary>
        /// График - "Средняя (общая) загрузка видеокарты"
        /// </summary>
        private IChartComponent _gpuUtilizationChart;
        private GpuUtilizationData[] _gpuUtilizationData;

        private LineConfig _gpuUtilizationChartConfig = new LineConfig
        {
            Padding = "auto",
            XField = "interval",
            YField = "gpuUtilization",
            Legend = new Legend
            {
                Visible = true,
                Position = "right-top",
                Title = new LegendTitle() { Visible = true, Text = "Обозначения" },
            },
            Smooth = true,
        };

        private async Task LoadGpuUtilizationChart()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddHours(1);
            GetGpuUtilizationStatisticsQuery gpuUtilizationStatistic = new(1, 1, 60000, startDate, endDate);
            var gpuUtilizationStatisticResponse = await Mediator.Send(gpuUtilizationStatistic);
            if (gpuUtilizationStatisticResponse.IsSuccess)
            {
                _gpuUtilizationData = gpuUtilizationStatisticResponse.Value.ToArray();
                await MessageNotificator.ShowSuccess("График \"Средняя (общая) загрузка видеокарты\" загружен");
            }
            else
            {
                await MessageNotificator.ShowError(gpuUtilizationStatisticResponse.Errors.AsOneString());
            }
            await _gpuUtilizationChart.ChangeData(_gpuUtilizationData);
        } 
        #endregion

        #region График - среднее время обработки запроса
        /// <summary>
        /// График - среднее время обработки запроса
        /// </summary>
        private IChartComponent _averageRequestProcessingTimeChart;

        private AverageRequestProcessingTimeData[] _averageRequestProcessingTimeData;

        private PieConfig _averageRequestProcessingTimeChartConfig = new PieConfig
        {
            Radius = 0.8,
            AngleField = "averageProcessingTimeInMilliseconds",
            ColorField = "processingTimeType",
            Label = new PieLabelConfig
            {
                Visible = true,
                Type = "inner"
            },
            Legend = new Legend
            {
                Visible = true,
                Position = "right-top",
                Title = new LegendTitle() { Visible = true, Text = "Обозначения" },
            },
            Name = "Name"
        };

        private async Task LoadAverageRequestProcessingTimeChart()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddHours(1);
            AverageRequestProcessingTimeStatisticQuery averageRequestProcessingTimeStatistic = new(1, 1, startDate, endDate);
            var averageRequestProcessingTimeStatisticResponse = await Mediator.Send(averageRequestProcessingTimeStatistic);
            if (averageRequestProcessingTimeStatisticResponse.IsSuccess)
            {
                _averageRequestProcessingTimeData = averageRequestProcessingTimeStatisticResponse.Value.ToArray();
                await MessageNotificator.ShowSuccess("График \"Среднее время обработки запроса (детализация)\" загружен");
            }
            else
            {
                await MessageNotificator.ShowError(averageRequestProcessingTimeStatisticResponse.Errors.AsOneString());
            }
            await _averageRequestProcessingTimeChart.ChangeData(_averageRequestProcessingTimeData);
        }
        #endregion

        #region График - Разбиение запросов по методу реферирования
        /// <summary>
        /// График - Разбиение запросов по методу реферирования
        /// </summary>
        private IChartComponent _abstractionMethodQueriesSplitChart;

        private AbstractionMethodQueriesSplitData[] _abstractionMethodQueriesSplitData;

        private PieConfig _abstractionMethodQueriesSplitChartConfig = new PieConfig
        {
            Radius = 0.8,
            AngleField = "queriesCount",
            ColorField = "abstractionMethodName",
            Label = new PieLabelConfig
            {
                Visible = true,
                Type = "inner"
            },
            Legend = new Legend
            {
                Visible = true,
                Position = "right-top",
                Title = new LegendTitle() { Visible = true, Text = "Обозначения" },
            },
            Name = "Name"
        };

        private async Task LoadAbstractionMethodQueriesSplitChart()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddHours(1);
            AbstractionMethodQueriesSplitStatisticQuery abstractionMethodQueriesSplitStatistic = new(1, 1, startDate, endDate);
            var abstractionMethodQueriesSplitStatisticResponse = await Mediator.Send(abstractionMethodQueriesSplitStatistic);
            if (abstractionMethodQueriesSplitStatisticResponse.IsSuccess)
            {
                _abstractionMethodQueriesSplitData = abstractionMethodQueriesSplitStatisticResponse.Value.ToArray();
                await MessageNotificator.ShowSuccess("График \"Разбиение запросов по методу реферирования\" загружен");
            }
            else
            {
                await MessageNotificator.ShowError(abstractionMethodQueriesSplitStatisticResponse.Errors.AsOneString());
            }
            await _abstractionMethodQueriesSplitChart.ChangeData(_abstractionMethodQueriesSplitData);
        }
        #endregion
    }
}
