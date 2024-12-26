namespace Entity_FrameWork_1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public UserProfile UserProfile { get; set; }
      
    }
}
