using Microsoft.EntityFrameworkCore;

namespace OfferProject.Data.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<UpdateOfOffer> UpdatesOfOffer { get; set; }        
        
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {            
        }
    }
}
