namespace FakeModelApi.Data
{
    /// <summary>
    /// Метрики процессора
    /// </summary>
    public class CpuMetrics
    {
        /// <summary>
        /// Загрузка ЦП [0.0 - 1.0]
        /// </summary>
        public double CpuUtilization { get; set; }

        /// <summary>
        /// Общий объем памяти ЦП (байт)
        /// </summary>
        public long CpuMemoryTotalBytes { get; set; }

        /// <summary>
        /// Используемая память ЦП
        /// </summary>
        public long CpuMemoryUsedBytes { get; set; }
    }
}
