using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4._07._23_2_.Models
{
    public class DataContext : IdentityDbContext<IdentityUser,IdentityRole,string>

    /*IdentityDbContext<IdentityUser>*/
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<JobSeeker> Seekers { get; set; }
        public DbSet<IsSahibi> isSahibis { get; set; }

        public DbSet<IsBakanMeslek> ısBakanMesleks { get; set; }

        public DbSet<IsBakanIlan> ısBakanIlans { get; set; }

        public DbSet<CalismaTuru> calismaTuru { get; set; }
        public DbSet<Ilan> Ilans { get; set; }

        public DbSet<Meslek> mesleks { get; set; }

        public DbSet<Deneyim> deneyims { get; set; }

        public DbSet<Firma> firmas { get; set; }

        public DbSet<Sektor> sektors { get; set; }

        public DbSet<FirmaSektor> firmaSektors { get; set; }

        public DbSet<Login> logins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-R4FS9SS\\MSSQL;Database=DataDb;User Id=berkan;Password=1234;TrustServerCertificate=True"/*,*/
               /* options=>options.EnableRetryOnFailure()*/);
        }

    }
}
