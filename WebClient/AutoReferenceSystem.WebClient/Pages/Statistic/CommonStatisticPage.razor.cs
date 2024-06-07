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
        private ICollection<ServerData> _servers = new List<ServerData>();

        private ITable _table;

        [Inject]
        protected IMessageNotificator MessageNotificator { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadInferenceRequestsChart();
                await LoadCpuUtilizationChart();
                await LoadGpuUtilizationChart();
                await LoadMemoryUtilizationChart();


                await base.OnInitializedAsync();
            }
            catch (Exception ex)
            {
                MessageNotificator.ShowError(ex.Message);
            }     
        }

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

        /// <summary>
        /// График - среднее время обработки запроса
        /// </summary>
        private IChartComponent _averageRequestProcessingTimeChart;




        

    }
}
