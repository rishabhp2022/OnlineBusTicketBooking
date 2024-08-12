using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineBusTicketBooking.Models
{
    public class BusContext : DbContext
    {
        public BusContext (DbContextOptions<BusContext> options) : base(options)
        {
            
        }
        public DbSet<AddBusDetails> AddBusDetails { get; set; }

        public DbSet<RefreshmentsDetails> RefreshmentsDetails { get; set; }

        public DbSet<TicketDetails> TicketDetails { get; set; }

        public DbSet<FeedDetails> FeedDetails { get; set; }

        public DbSet<Userdetails> Userdetails { get; set; }


        public BusContext(DbSet<AddBusDetails> addBusDetail)
        {
            AddBusDetails = addBusDetail;
        }

        public BusContext(DbSet<RefreshmentsDetails> refreshmentDetail)
        {
            RefreshmentsDetails = refreshmentDetail;
        }

        public BusContext(DbSet<TicketDetails> TicketDetail)
        {
            TicketDetails = TicketDetail;
        }
        
        public BusContext(DbSet<FeedDetails> FeedDetail)
        {
            FeedDetails = FeedDetail;
        }

        public BusContext(DbSet<Userdetails> Userdetail)
        {
            Userdetails = Userdetail;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AddBusDetails>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.BusNumber

                });
            });
        }
    }

}
