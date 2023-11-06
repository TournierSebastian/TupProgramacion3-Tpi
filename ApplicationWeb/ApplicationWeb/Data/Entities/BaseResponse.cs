using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWeb.Data.Entities
{
    public class BaseResponse
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
