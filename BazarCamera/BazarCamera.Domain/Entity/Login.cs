namespace BazarCamera.Domain.Entity
{
    public class Login
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}