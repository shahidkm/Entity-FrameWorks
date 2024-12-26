using System.ComponentModel.DataAnnotations;

namespace Entity_FrameWork_1.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        [Key]
        public int PrifoleId { get; set; }
        public string Bio { get; set; }
        public User User { get; set; }

    }
}
