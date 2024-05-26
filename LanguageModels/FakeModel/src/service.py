# В этом файле находится бизнес логика
from models import *
import time
import utils
import random


class FakeLanguageModel:
    def __init__(self) -> None:
        self.model_name = 'fake_model'
        self.device_type = ProcessingDeviceType.Cpu
        pass


    def get_an_abstract_by_theses_count(self, source_text: str, theses_count: int) -> LanguageModelResponse:
        """Получает необходимое кол-во тезисов из исходного текста"""

        start_time = time.time()
        
        # какая-то логика работы с языковой моделью
        if source_text is None or (len(source_text) == 0):
            end_time = time.time()
            response = self.__get_an_error_response(error_text='Неверный текст', working_time=end_time - start_time)
            return response
        if theses_count < 1:
            end_time = time.time()
            response = self.__get_an_error_response(error_text=f'Невозможно сгенерировать {theses_count} утверждений!', working_time=end_time - start_time)
        sentensies = source_text.split('.')
        if sentensies is None or len(sentensies) == 0:
            end_time = time.time()
            response = LanguageModelResponse(
                Abstract=source_text,
                ErrorText='',
                ModelName=self.model_name,
                IsSuccess=True,
                DeviceType=self.device_type,
                CpuMetrics=CpuMetrics(
                    CpuMemoryTotalBytes=utils.cpu_memory_total_bytes(),
                    CpuMemoryUsedBytes=random.randint(1, utils.cpu_memory_total_bytes()),
                    CpuUtilization=utils.cpu_utilization()
                ),
                GpuMetrics=GpuMetrics(
                    GpuMemoryTotalBytes=utils.gpu_memory_total_bytes(),
                    GpuUtilization=random.random(),
                    GpuMemoryUsedBytes=random.randint(1, utils.gpu_memory_total_bytes()),
                    GpuPower=random.randint(1, 100),
                    EnergyConsumption=random.randint(1, 700)
                ),
                SummaryMetrics=SummaryMetrics(
                    ComputeInputTime=0,
                    ComputeOutputTime=0,
                    RequestTime=0,
                    WorkingTime=end_time - start_time
                )
            )
            return response
        end_time = time.time()
        response = LanguageModelResponse(
            Abstract=sentensies[0],
            ErrorText='',
            ModelName=self.model_name,
            IsSuccess=True,
            DeviceType=self.device_type,
            CpuMetrics=CpuMetrics(
                CpuMemoryTotalBytes=utils.cpu_memory_total_bytes(),
                CpuMemoryUsedBytes=random.randint(1, utils.cpu_memory_total_bytes()),
                CpuUtilization=utils.cpu_utilization()
            ),
            GpuMetrics=GpuMetrics(
                GpuMemoryTotalBytes=utils.gpu_memory_total_bytes(),
                GpuUtilization=random.random(),
                GpuMemoryUsedBytes=random.randint(1, utils.gpu_memory_total_bytes()),
                GpuPower=random.randint(1, 100),
                EnergyConsumption=random.randint(1, 700)
            ),
            SummaryMetrics=SummaryMetrics(
                ComputeInputTime=0,
                ComputeOutputTime=0,
                RequestTime=0,
                WorkingTime=end_time - start_time
            )
        )
        return response
    

    def get_an_abstract_by_abstract_relative_volume(self, source_text, abstract_relative_volume: float) -> LanguageModelResponse:
        """Получает пересказ заданного объема от исходного текста"""
        start_time = time.time()
        if (source_text is None or len(source_text) == 0):
            end_time = time.time()
            response = self.__get_an_error_response(end_time - start_time, 'Неверный текст')
            return response
        if abstract_relative_volume < 0 or abstract_relative_volume > 1:
            end_time = time.time()
            response = self.__get_an_error_response(end_time - start_time, f'Неверная величина относительного объема текста: {abstract_relative_volume * 100} %')
            return response
        abstract = source_text * abstract_relative_volume
        end_time = time.time()
        response = LanguageModelResponse(
            Abstract=abstract,
            ErrorText='',
            ModelName=self.model_name,
            IsSuccess=True,
            DeviceType=self.device_type,
            CpuMetrics=CpuMetrics(
                CpuMemoryTotalBytes=utils.cpu_memory_total_bytes(),
                CpuMemoryUsedBytes=random.randint(1, utils.cpu_memory_total_bytes()),
                CpuUtilization=utils.cpu_utilization()
            ),
            GpuMetrics=GpuMetrics(
                GpuMemoryTotalBytes=utils.gpu_memory_total_bytes(),
                GpuUtilization=random.random(),
                GpuMemoryUsedBytes=random.randint(1, utils.gpu_memory_total_bytes()),
                GpuPower=random.randint(1, 100),
                EnergyConsumption=random.randint(1, 700)
            ),
            SummaryMetrics=SummaryMetrics(
                ComputeInputTime=0,
                ComputeOutputTime=0,
                RequestTime=0,
                WorkingTime=end_time - start_time
            )
        )
        return response


    def get_an_abstract_with_specified_words_count(self, source_text: str, words_count: int) -> LanguageModelResponse:
        """Получает пересказ с заданным кол-вом слов"""
        start_time = time.time()
        if source_text is None or len(source_text) == 0:
            end_time = time.time()
            response = self.__get_an_error_response(end_time - start_time, 'Неверный текст')
            return response
        if words_count < 1:
            end_time = time.time()
            response = self.__get_an_error_response(end_time - start_time, f'Неверное кол-во слов: {words_count}')
            return response
        words = source_text.split(' ')
        count = len(words_count)
        abstract = ''
        for _ in range(words_count):
            abstract = abstract + words[random.randint(0, count - 1)]
        end_time = time.time()
        response = LanguageModelResponse(
            Abstract=abstract,
            ErrorText='',
            ModelName=self.model_name,
            IsSuccess=True,
            DeviceType=self.device_type,
            CpuMetrics=CpuMetrics(
                CpuMemoryTotalBytes=utils.cpu_memory_total_bytes(),
                CpuMemoryUsedBytes=random.randint(1, utils.cpu_memory_total_bytes()),
                CpuUtilization=utils.cpu_utilization()
            ),
            GpuMetrics=GpuMetrics(
                GpuMemoryTotalBytes=utils.gpu_memory_total_bytes(),
                GpuUtilization=random.random(),
                GpuMemoryUsedBytes=random.randint(1, utils.gpu_memory_total_bytes()),
                GpuPower=random.randint(1, 100),
                EnergyConsumption=random.randint(1, 700)
            ),
            SummaryMetrics=SummaryMetrics(
                ComputeInputTime=0,
                ComputeOutputTime=0,
                RequestTime=0,
                WorkingTime=end_time - start_time
            )
        )
        return response 


    def get_an_abstract_with_specified_sentesies_count(self, source_text: str, sentensies_count: int) -> LanguageModelResponse:
        """Получает пересказ с заданным кол-вом предложений"""
        start_time = time.time()
        if source_text is None or len(source_text) == 0:
            end_time = time.time()
            response = self.__get_an_error_response(end_time - start_time, 'Неверный текст')
            return response
        sentensies = source_text.split('.')
        count = len(sentensies)
        if sentensies_count < 1 or sentensies_count > count:
            end_time = time.time()
            response = self.__get_an_error_response(end_time - start_time, f'Неверное кол-во предложений: {sentensies_count}')
            return response
        abstract = ''
        for _ in range(count):
            abstract = abstract + sentensies[random.randint(0, count - 1)]
        end_time = time.time()
        response = LanguageModelResponse(
            Abstract=abstract,
            ErrorText='',
            ModelName=self.model_name,
            IsSuccess=True,
            DeviceType=self.device_type,
            CpuMetrics=CpuMetrics(
                CpuMemoryTotalBytes=utils.cpu_memory_total_bytes(),
                CpuMemoryUsedBytes=random.randint(1, utils.cpu_memory_total_bytes()),
                CpuUtilization=utils.cpu_utilization()
            ),
            GpuMetrics=GpuMetrics(
                GpuMemoryTotalBytes=utils.gpu_memory_total_bytes(),
                GpuUtilization=random.random(),
                GpuMemoryUsedBytes=random.randint(1, utils.gpu_memory_total_bytes()),
                GpuPower=random.randint(1, 100),
                EnergyConsumption=random.randint(1, 700)
            ),
            SummaryMetrics=SummaryMetrics(
                ComputeInputTime=0,
                ComputeOutputTime=0,
                RequestTime=0,
                WorkingTime=end_time - start_time
            )
        )
        return response 



    def __get_an_error_response(self, working_time, error_text):
        """Возвращает стандартный ответ с указанной ошибкой и временем работы"""
        response = LanguageModelResponse(
                Abstract='',
                CpuMetrics=CpuMetrics(
                    CpuMemoryTotalBytes=utils.cpu_memory_total_bytes(),
                    CpuUtilization=utils.cpu_utilization(),
                    CpuMemoryUsedBytes=0
                ),
                DeviceType=self.device_type,
                IsSuccess=False,
                ErrorText=error_text,
                ModelName=self.model_name,
                GpuMetrics=GpuMetrics(
                    GpuMemoryTotalBytes=utils.gpu_memory_total_bytes(),
                    EnergyConsumption=0,
                    GpuPower=0,
                    GpuUtilization=0,
                    GpuMemoryUsedBytes=0
                ),
                SummaryMetrics=SummaryMetrics(
                    ComputeInputTime=0,
                    ComputeOutputTime=0,
                    RequestTime=0,
                    WorkingTime=working_time
                )
            )
        
