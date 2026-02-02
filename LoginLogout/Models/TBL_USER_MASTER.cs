using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginLogout.Models
{
    public partial class TBL_USER_MASTER
    {
        [Required]
        public decimal ID { get; set; }
        [Required]
        public string? NAME { get; set; }
        [Required]
        public string? GENDER { get; set; }
        [Required]
        public string? AGE { get; set; }
        [Required]
        public string? EMAIL { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? USER_PASSWORD { get; set; }
    }
}
