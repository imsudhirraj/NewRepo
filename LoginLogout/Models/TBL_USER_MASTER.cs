using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginLogout.Models
{
    public partial class TBL_USER_MASTER
    {
        public decimal ID { get; set; }
        public string? NAME { get; set; }
        public string? GENDER { get; set; }
        public string? AGE { get; set; }
        public string? EMAIL { get; set; }
        [DataType(DataType.Password)]
        public string? USER_PASSWORD { get; set; }
    }
}
