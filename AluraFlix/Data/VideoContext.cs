using AluraFlix.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
    }
}
