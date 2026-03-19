using Microsoft.EntityFrameworkCore;
using tinyUrl.Domain.Entities;

namespace tinyUrl.Domain.Context
{
    public class tinyUrlContext : DbContext
    {

        public tinyUrlContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ShortenedUrl> ShortUrls { get; set; }

    }
}
