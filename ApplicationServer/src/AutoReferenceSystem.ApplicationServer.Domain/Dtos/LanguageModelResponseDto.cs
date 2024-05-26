using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Dtos
{
    /// <summary>
    /// Ответ модели
    /// </summary>
    public class LanguageModelResponseDto
    {
        /// <summary>
        /// Имя модели
        /// </summary>
        public string ModelName { get; set; } = string.Empty;
        /// <summary>
        /// Текст пересказа
        /// </summary>
        public string Abstract { get; set; } = string.Empty;

        /// <summary>
        /// Общие метрики работы модели
        /// </summary>
        public SummaryMetricsDto SummaryMetrics { get; set; } = new SummaryMetricsDto();

        /// <summary>
        /// Признак успешной обработки
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        public string ErrorText { get; set; } = string.Empty;

        /// <summary>
        /// Метрики видеокарты
        /// </summary>
        public GpuMetricsDto GpuMetrics { get; set; } = new GpuMetricsDto();

        /// <summary>
        /// Метрики процессора
        /// </summary>
        public CpuMetricsDto CpuMetrics { get; set; } = new CpuMetricsDto();

        /// <summary>
        /// Тип устройства, на котором проиводились расчеты
        /// </summary>
        public ProcessingDeviceType DeviceType { get; set; } = ProcessingDeviceType.Unknown;
    }
}
