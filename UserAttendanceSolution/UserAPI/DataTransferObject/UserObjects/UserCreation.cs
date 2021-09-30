using System.ComponentModel.DataAnnotations;

namespace UserAPI.DataTransferObject.UserObjects
{
    public class UserCreation
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
