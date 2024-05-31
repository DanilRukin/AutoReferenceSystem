using FakeModelApi.Data;
using System.Diagnostics;
using System.Text;


namespace FakeModelApi.Model
{
    public class FakeLanguageModel
    {
        public string ModelName { get; set; }
        public ProcessingDeviceType DeviceType { get; set; }

        private const long GPU_MEMORY_TOTAL_BYTES = 1000000000;
        private const long CPU_MEMORY_TOTAL_BYTES = 100000;

        public FakeLanguageModel(string modelName, ProcessingDeviceType deviceType)
        {
            ModelName = modelName ?? throw new ArgumentNullException(nameof(modelName));
            DeviceType = deviceType;
        }



        /// <summary>
        /// Получает необходимое кол-во тезисов из исходного текста
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="thesesCount"></param>
        /// <returns></returns>
        public Task<LanguageModelResponseDto> GetAnAbstractByThesesCount(string sourceText, int thesesCount, AbstractionMethod abstractionMethod)
        {
            // какая-то логика работы с языковой моделью
            return Task.Factory.StartNew(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (sourceText is null || sourceText.Length == 0)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, "Неверный текст", abstractionMethod);
                    return response;
                }
                if (thesesCount < 1)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, $"Невозможно сгенерировать {thesesCount} утверждений!", abstractionMethod);
                    return response;
                }
                string[] sentensies = sourceText.Split('.', StringSplitOptions.RemoveEmptyEntries);
                if (sentensies == null || sentensies?.Length == 0)
                {
                    stopwatch.Stop();
                    var response = GetSuccessResponse($"1. {sourceText}", (int)stopwatch.ElapsedMilliseconds, abstractionMethod);
                    return response;
                }
                stopwatch.Stop();
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                for (int i = 0; i < sentensies.Length; i++)
                {
                    builder.Append($"{i + 1}. {sentensies[random.Next(0, sentensies.Length - 1)]}\r\n");
                }
                return GetSuccessResponse(builder.ToString(), (int)stopwatch.ElapsedMilliseconds, abstractionMethod);
            });            
        }

        /// <summary>
        /// Возвращает стандартный ответ с указанным пересказом и временем работы
        /// </summary>
        /// <param name="abstract"></param>
        /// <param name="workingTime"></param>
        /// <returns></returns>
        private LanguageModelResponseDto GetSuccessResponse(string @abstract, int workingTime, AbstractionMethod abstractionMethod)
        {
            Random random = new Random();
            return new LanguageModelResponseDto()
            {
                Abstract = @abstract,
                ErrorText = "",
                IsSuccess = true,
                ModelName = this.ModelName,
                DeviceType = this.DeviceType,
                UsedAbstractionMethod = abstractionMethod,
                CpuMetrics = new CpuMetricsDto()
                {
                    CpuMemoryTotalBytes = CPU_MEMORY_TOTAL_BYTES,
                    CpuMemoryUsedBytes = random.Next(1, (int)CPU_MEMORY_TOTAL_BYTES),
                    CpuUtilization = random.NextDouble()
                },
                GpuMetrics = new GpuMetricsDto()
                {
                    EnergyConsumption = random.Next(1, 700),
                    GpuMemoryTotalBytes = GPU_MEMORY_TOTAL_BYTES,
                    GpuMemoryUsedBytes = random.Next(1, (int)GPU_MEMORY_TOTAL_BYTES),
                    GpuPower = random.Next(1, 100),
                    GpuUtilization = random.NextDouble()
                },
                SummaryMetrics = new SummaryMetricsDto()
                {
                    ComputeInputTime = 0,
                    ComputeOutputTime = 0,
                    RequestTime = workingTime,
                    WorkingTime = workingTime
                }
            };
        }

        /// <summary>
        /// Возвращает стандартный ответ с указанной ошибкой и временем работы
        /// </summary>
        /// <param name="workingTime"></param>
        /// <param name="errorText"></param>
        /// <returns></returns>
        private LanguageModelResponseDto GetAnErrorResponse(int workingTime, string errorText, AbstractionMethod abstractionMethod)
        {
            Random random = new Random();
            var response = new LanguageModelResponseDto()
            {
                Abstract = "",
                DeviceType = this.DeviceType,
                ErrorText = errorText,
                IsSuccess = false,
                ModelName = this.ModelName,
                UsedAbstractionMethod = abstractionMethod,
                CpuMetrics = new CpuMetricsDto()
                {
                    CpuMemoryTotalBytes = CPU_MEMORY_TOTAL_BYTES,
                    CpuMemoryUsedBytes = random.Next(1, (int)CPU_MEMORY_TOTAL_BYTES),
                    CpuUtilization = random.NextDouble()
                },               
                GpuMetrics = new GpuMetricsDto()
                {
                    EnergyConsumption = random.Next(1, 700),
                    GpuMemoryTotalBytes = GPU_MEMORY_TOTAL_BYTES,
                    GpuMemoryUsedBytes = random.Next(1, (int)GPU_MEMORY_TOTAL_BYTES),
                    GpuPower = random.Next(1, 100),
                    GpuUtilization = random.NextDouble()
                },
                SummaryMetrics = new SummaryMetricsDto()
                {
                    ComputeInputTime = 0,
                    ComputeOutputTime = 0,
                    RequestTime = workingTime,
                    WorkingTime = workingTime
                }
            };
            return response;
        }



        /// <summary>
        /// Получает пересказ заданного объема от исходного текста
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="abstract_relative_volume"></param>
        /// <returns></returns>
        public Task<LanguageModelResponseDto> GetAnAbstractByAbstractRelativeVolume(string sourceText, double abstractRelativeVolume, AbstractionMethod abstractionMethod)
        {
            // какая-то логика работы с языковой моделью
            return Task.Factory.StartNew(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (sourceText is null || sourceText.Length == 0)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, "Неверный текст", abstractionMethod);
                    return response;
                }
                if (abstractRelativeVolume < 0 || abstractRelativeVolume > 1)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds,
                        $"Неверная величина относительного объема текста: {abstractRelativeVolume * 100} %",
                        abstractionMethod);
                    return response;
                }
                int length = (int)(sourceText.Length * abstractRelativeVolume);
                if (length == 0)
                    length = 1;
                string @abstract = sourceText.Substring(0, length);
                stopwatch.Stop();
                return GetSuccessResponse(@abstract, (int)stopwatch.ElapsedMilliseconds, abstractionMethod);
            });
        }

        /// <summary>
        /// Получает пересказ с заданным кол-вом слов
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="wordsCount"></param>
        /// <returns></returns>
        public Task<LanguageModelResponseDto> GetAnAbstractWithSpecifiedWordsCount(string sourceText, int wordsCount, AbstractionMethod abstractionMethod)
        {
            return Task.Factory.StartNew(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (sourceText is null || sourceText.Length == 0)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, "Неверный текст", abstractionMethod);
                    return response;
                }
                if (wordsCount < 1)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, $"Неверное кол-во слов: {wordsCount}", abstractionMethod);
                    return response;
                }
                string[] words = sourceText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int count = words.Length;
                StringBuilder @abstract = new StringBuilder();
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    @abstract.Append($"{words[random.Next(0, count - 1)]} ");
                }
                stopwatch.Stop();
                return GetSuccessResponse(@abstract.ToString(), (int)stopwatch.ElapsedMilliseconds, abstractionMethod);
            });
        }


        /// <summary>
        /// Получает пересказ с заданным кол-вом предложений
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="sentensiesCount"></param>
        /// <returns></returns>
        public Task<LanguageModelResponseDto> GetAnAbstractWithSpecifiedSentesiesCount(string sourceText, int sentensiesCount, AbstractionMethod abstractionMethod)
        {
            return Task.Factory.StartNew(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (sourceText is null || sourceText.Length == 0)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, "Неверный текст", abstractionMethod);
                    return response;
                }
                string[] sentensies = sourceText.Split('.', StringSplitOptions.RemoveEmptyEntries);
                int count = sentensies.Length;
                if (sentensiesCount < 1 || sentensiesCount > count)
                {
                    stopwatch.Stop();
                    var response = GetAnErrorResponse((int)stopwatch.ElapsedMilliseconds, $"Неверное кол-во предложений: {sentensiesCount}", abstractionMethod);
                    return response;
                }
                StringBuilder @abstract = new StringBuilder();
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    @abstract.Append($"{sentensies[random.Next(0, count - 1)]} ");
                }
                stopwatch.Stop();
                return GetSuccessResponse(@abstract.ToString(), (int)stopwatch.ElapsedMilliseconds, abstractionMethod);
            });
        }         
    }
}
