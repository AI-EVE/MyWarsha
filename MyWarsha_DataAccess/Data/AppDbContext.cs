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
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CarInfoProduct> CarInfoProduct { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductToSell> ProductToSell { get; set; }
        public DbSet<ProductBought> ProductBought { get; set; }
        public DbSet<RelevantDataToTheBought> RelevantDataToTheBought { get; set; }
        public DbSet<ServiceFee> ServiceFee { get; set; }
        public DbSet<Service> Service { get; set; }
        public IEnumerable<object> CarImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarInfoProduct>()
                .HasKey(cp => new { cp.CarInfoId, cp.ProductId });

            modelBuilder.Entity<CarInfoProduct>()
                .HasOne(cp => cp.CarInfo)
                .WithMany(c => c.CarInfoProduct)
                .HasForeignKey(cp => cp.CarInfoId);

            modelBuilder.Entity<CarInfoProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CarInfoProduct)
                .HasForeignKey(cp => cp.ProductId);

            modelBuilder.Entity<CarInfo>(entity =>
            {
                entity.HasOne(ci => ci.CarMaker)
                      .WithMany()
                      .HasForeignKey(ci => ci.CarMakerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.CarModel)
                      .WithMany()
                      .HasForeignKey(ci => ci.CarModelId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.CarGeneration)
                      .WithMany()
                      .HasForeignKey(ci => ci.CarGenerationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            

             modelBuilder.Entity<Service>(entity => 
             {
                entity.HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Car)
                .WithMany()
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.Restrict);
             });

            modelBuilder.Entity<Product>(entity =>
            {
                 entity.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.ProductType)
                    .WithMany()
                    .HasForeignKey(p => p.ProductTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.ProductBrand)
                    .WithMany()
                    .HasForeignKey(p => p.ProductBrandId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            
                

            

               
        }
    }
}