using System;

namespace LearningSystem.Domain.Entity
{
    public class Login
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public virtual Student Student { get; set; }
        public bool IsActive { get; set; }
        public int StudentId { get; set; }
    }
}
