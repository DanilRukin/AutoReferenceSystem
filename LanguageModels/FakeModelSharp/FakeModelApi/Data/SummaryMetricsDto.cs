namespace FakeModelApi.Data
{
    /// <summary>
    /// Сводные метрики
    /// </summary>
    public class SummaryMetricsDto
    {
        /// <summary>
        /// Общее время обработки запроса (мс)
        /// </summary>
        public long RequestTime { get; set; }

        /// <summary>
        /// Время, потраченное на подготовку входных данных (мс)
        /// </summary>
        public long ComputeInputTime { get; set; }

        /// <summary>
        /// Время вычислений (мс)
        /// </summary>
        public long WorkingTime { get; set; }

        /// <summary>
        /// Время, потраченное на подготовку выходных  (мс)
        /// </summary>
        public long ComputeOutputTime { get; set; }
    }
}
