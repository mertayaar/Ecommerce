using Ecommerce.Review.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Review.Context
{
    public class ReviewContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ReviewContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<UserReview> UserReviews { get; set; }

        }
}
