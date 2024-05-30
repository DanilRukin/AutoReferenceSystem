namespace FakeModelApi.Data
{
    /// <summary>
    /// Метрики GPU
    /// </summary>
    public class GpuMetricsDto
    {
        /// <summary>
        /// Мощность (Вт)
        /// </summary>
        public double GpuPower { get; set; }

        /// <summary>
        /// Потребление энергии Дж
        /// </summary>
        public double EnergyConsumption { get; set; }

        /// <summary>
        /// Использование графического процессора [0.0, 1.0]
        /// </summary>
        public double GpuUtilization { get; set; }

        /// <summary>
        /// Общее кол-во памяти  (байт)
        /// </summary>
        public long GpuMemoryTotalBytes { get; set; }

        /// <summary>
        /// Используемый объем памяти GPU (байт)
        /// </summary>
        public long GpuMemoryUsedBytes { get; set; }
    }
}
