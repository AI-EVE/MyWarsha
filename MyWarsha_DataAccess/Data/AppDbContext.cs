using Microsoft.EntityFrameworkCore;
using MyWarsha_Models.Models;

namespace MyWarsha_DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarImage> CarImage { get; set; }
        public DbSet<CarInfo> CarInfo { get; set; } 
        public DbSet<CarMaker> CarMaker { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<CarGeneration> CarGeneration { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductToSell> ProductToSell { get; set; }
        public DbSet<ProductBought> ProductBought { get; set; }
        public DbSet<RelevantDataToTheBought> RelevantDataToTheBought { get; set; }
        public DbSet<ServiceFee> ServiceFee { get; set; }
        public DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarInfo>(entity =>
            {
                entity.HasOne(ci => ci.CarMaker)
                      .WithMany()
                      .HasForeignKey(ci => ci.CarMakerId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ci => ci.CarModel)
                      .WithMany()
                      .HasForeignKey(ci => ci.CarModelId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ci => ci.CarGeneration)
                      .WithMany()
                      .HasForeignKey(ci => ci.CarGenerationId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

             modelBuilder.Entity<Service>()
                .HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Car)
                .WithMany()
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}