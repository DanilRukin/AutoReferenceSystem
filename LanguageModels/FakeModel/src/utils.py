# В этом файле содержатся вспомогательные утилиты

import psutil
import constants


def cpu_memory_total_bytes():
    return constants.CPU_MEMORY_TOTAL_BYTES

def gpu_memory_total_bytes():
    return constants.GPU_MEMORY_TOTAL_BYTES

def cpu_utilization():
    psutil.cpu_percent()
