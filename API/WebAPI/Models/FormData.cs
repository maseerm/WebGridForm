using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class FormData
    {
        public int FormDataId { get; set; }
        public int FormId { get; set; }
        public string FormItem { get; set; }
    }
}
