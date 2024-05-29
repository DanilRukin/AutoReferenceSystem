namespace FakeModelApi.Data
{
    /// <summary>
    /// Ответ модели
    /// </summary>
    public class LanguageModelResponse
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
        public SummaryMetrics SummaryMetrics { get; set; } = new SummaryMetrics();

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
        public GpuMetrics GpuMetrics { get; set; } = new GpuMetrics();

        /// <summary>
        /// Метрики процессора
        /// </summary>
        public CpuMetrics CpuMetrics { get; set; } = new CpuMetrics();

        /// <summary>
        /// Тип устройства, на котором проиводились расчеты
        /// </summary>
        public ProcessingDeviceType DeviceType { get; set; } = ProcessingDeviceType.Unknown;
    }
}
