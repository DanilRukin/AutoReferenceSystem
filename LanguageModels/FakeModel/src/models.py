# В этом файле описываются все модельки

from pydantic import BaseModel
from enum import Enum


class CpuMetrics(BaseModel):
    CpuUtilization: float
    CpuMemoryTotalBytes : int
    CpuMemoryUsedBytes : int


class GpuMetrics(BaseModel):
    """Метрики GPU"""

    GpuPower: float
    """Мощность (Вт)"""

    EnergyConsumption: float
    """Потребление энергии Дж"""

    GpuUtilization: float
    """Использование графического процессора [0.0, 1.0]"""

    GpuMemoryTotalBytes: int
    """Общее кол-во памяти  (байт)"""

    GpuMemoryUsedBytes: int
    """Используемый объем памяти GPU (байт)"""


class SummaryMetrics(BaseModel):
    """Сводные метрики"""
    
    RequestTime: int
    """Общее время обработки запроса (мс)"""
    
    ComputeInputTime: int
    """Время, потраченное на подготовку входных данных (мс)"""
    
    WorkingTime: int
    """Время вычислений (мс)"""
    
    ComputeOutputTime: int
    """Время, потраченное на подготовку выходных  (мс)"""


class ProcessingDeviceType(str, Enum):
    """Тип устройства, на котором происходили расчеты"""

    Unknown = 'none'
    Cpu = 'cpu'
    Gpu = 'cuda'



class LanguageModelResponse(BaseModel):
    """Ответ модели"""

    ModelName: str
    """Имя модели"""

    Abstract: str
    """Текст пересказа"""

    SummaryMetrics: SummaryMetrics
    """Общие метрики работы модели"""

    IsSuccess: bool
    """Признак успешной обработки"""

    ErrorText: str
    """Текст ошибки"""

    GpuMetrics: GpuMetrics
    """Метрики видеокарты"""

    CpuMetrics: CpuMetrics
    """Метрики процессора"""

    DeviceType: ProcessingDeviceType
    """Тип устройства, на котором проиводились расчеты"""


class RequestText(BaseModel):
    """Текст для пересказа"""

    SourceText: str
    """Текст для пересказа"""
