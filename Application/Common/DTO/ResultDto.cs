using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTO
{
    public class ResultDto<Data>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Data? Result { get; set; }

    }

    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
