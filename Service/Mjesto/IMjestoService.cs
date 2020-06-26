using System;
using System.Collections.Generic;
using System.Text;
using Dto;

namespace Service
{
    public interface IMjestoService
    {
        List<MjestoDto> GetAllMjesta();
    }
}
