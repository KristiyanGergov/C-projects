using BazarCamera.Domain.Entity;
using System.Data.Entity;

namespace BazarCamera.Data
{
    public class BazarCameraContext : DbContext
    {
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}