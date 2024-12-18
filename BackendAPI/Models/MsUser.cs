using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class MsUser
    {
        [Key]
        public long UserId { get; set; } 

        [MaxLength(20)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public bool IsActive { get; set; } 
    }
}
