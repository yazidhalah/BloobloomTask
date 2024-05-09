
using Core.Models;
using Entity.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public class ApplicationUser : IdentityUser<int>
        {
           
        }

        public class ApplicationRole : IdentityRole<int>
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedLookupPrescriptionType(modelBuilder);
            SeedLookupLensType(modelBuilder);
            SeedLookupCurrency(modelBuilder);


        }



        public DbSet<LookupFrame> LookupFrame { get; set; }
        public DbSet<LookupLens> LookupLens { get; set; }
        public DbSet<LookupCurrency> LookupCurrency { get; set; }
        public DbSet<TransactionCart> TransactionCart { get; set; }
        public DbSet<LookupPrescriptionType> LookupPrescriptionType { get; set; }
        public DbSet<LookupLensType> LookupLensType { get; set; }


        private void SeedLookupCurrency(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookupCurrency>().HasData(
               new LookupCurrency
               {
                   LookupCurrencyCurrencyCode = "USD",
                   LookupCurrencyConversionRateToUSD = 1.0M,
                   Status = BaseEntity.StatusEnum.Active,
                   CreateDate = DateTime.Now,
                   LookupCurrencyId = 1
               },
               new LookupCurrency
               {
                   LookupCurrencyCurrencyCode = "GBP",
                   LookupCurrencyConversionRateToUSD = 0.80M,
                   Status = BaseEntity.StatusEnum.Active,
                   CreateDate = DateTime.Now,
                   LookupCurrencyId = 2
               },
               new LookupCurrency
               {
                   LookupCurrencyCurrencyCode = "EUR",
                   LookupCurrencyConversionRateToUSD = 0.93M,
                   Status = BaseEntity.StatusEnum.Active,
                   CreateDate = DateTime.Now,
                   LookupCurrencyId = 3
               },
               new LookupCurrency
               {
                   LookupCurrencyCurrencyCode = "JOD",
                   LookupCurrencyConversionRateToUSD = 0.71M,
                   Status = BaseEntity.StatusEnum.Active,
                   CreateDate = DateTime.Now,
                   LookupCurrencyId = 4
               },
               new LookupCurrency
               {
                   LookupCurrencyCurrencyCode = "JPY",
                   LookupCurrencyConversionRateToUSD = 155.53M,
                   Status = BaseEntity.StatusEnum.Active,
                   CreateDate = DateTime.Now,
                   LookupCurrencyId = 5
               }
           );
        }
        private void SeedLookupLensType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookupLensType>().HasData(
             new LookupLensType
             {
                 LookupLensTypeName = "classic",
                 Status = BaseEntity.StatusEnum.Active,
                 CreateDate = DateTime.Now,
                 LookupLensTypeId = 1
             },
             new LookupLensType
             {
                 LookupLensTypeName = "blue_light",
                 Status = BaseEntity.StatusEnum.Active,
                 CreateDate = DateTime.Now,
                 LookupLensTypeId = 2
             },
             new LookupLensType
             {
                 LookupLensTypeName = "transition",
                 Status = BaseEntity.StatusEnum.Active,
                 CreateDate = DateTime.Now,
                 LookupLensTypeId = 3
             }
         );
        }
        private void SeedLookupPrescriptionType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookupPrescriptionType>().HasData(
                new LookupPrescriptionType
                {
                    LookupPrescriptionTypeName = "fashion",
                    Status = BaseEntity.StatusEnum.Active,
                    CreateDate = DateTime.Now,
                    LookupPrescriptionTypeId = 1
                },
                new LookupPrescriptionType
                {
                    LookupPrescriptionTypeName = "single_vision",
                    Status = BaseEntity.StatusEnum.Active,
                    CreateDate = DateTime.Now,
                    LookupPrescriptionTypeId = 2
                },
                new LookupPrescriptionType
                {
                    LookupPrescriptionTypeName = "varifocal",
                    Status = BaseEntity.StatusEnum.Active,
                    CreateDate = DateTime.Now,
                    LookupPrescriptionTypeId = 3
                }
            );
        }
    }
}
