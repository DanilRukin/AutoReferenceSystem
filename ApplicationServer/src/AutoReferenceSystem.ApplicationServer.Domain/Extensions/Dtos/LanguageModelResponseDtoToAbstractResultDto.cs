using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Extensions.Dtos
{
    public static class LanguageModelResponseDtoToAbstractResultDto
    {
        public static AbstractResultDto ToAbstractResultDto(this LanguageModelResponseDto dto)
        {
            return new AbstractResultDto
            {
                Text = dto.Abstract,
                WorkingTime = dto.WorkingTime
            };
        }
    }
}
