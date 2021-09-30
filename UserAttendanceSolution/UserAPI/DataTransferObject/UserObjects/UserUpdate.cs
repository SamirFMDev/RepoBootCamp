using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.DataTransferObject.UserObjects
{
    public class UserUpdate
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string NickName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string RealName { get; set; }
    }
}
