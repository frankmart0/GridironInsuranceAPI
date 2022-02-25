using GridironInsuranceAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace GridironInsuranceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Insured> Insureds { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
