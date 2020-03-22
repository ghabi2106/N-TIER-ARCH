using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_Business_Objects_Layer_
{
    public class ResultApiDto<T>
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public bool Success { get; set; }
    }
}
