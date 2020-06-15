using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using BigScreen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BigScreen.Data
{
    //    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    public class BigScreenContext: IdentityDbContext<ApplicationUser,IdentityRole, string>
    {
        public BigScreenContext (DbContextOptions<BigScreenContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseSqlite(@"Data Source=BigScreenDB.db;");
        }


        public DbSet<BigScreen.Models.Tifo> Tifo { get; set; }

        public DbSet<BigScreen.Models.TifoPartScreen> TifoPartScreen { get; set; }

        public DbSet<BigScreen.Models.Arena> Arena { get; set; }
        public DbSet<BigScreen.Models.ArenaEvent> ArenaEvent { get; set; }
        public DbSet<BigScreen.Models.Seat> Seat { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tifo>().ToTable("Tifo");
            modelBuilder.Entity<TifoPartScreen>().ToTable("TifoPartScreen");
            modelBuilder.Entity<Arena>().ToTable("Arena");
            
            modelBuilder.Entity<Seat>().ToTable("Seat");
            modelBuilder.Entity<ArenaEvent>().ToTable("ArenaEvent");

            modelBuilder.Entity<ArenaEventTifoPartScreen>()
                .HasKey(at => new { at.ArenaEventId, at.TifoPartScreenId });

            modelBuilder.Entity<ArenaEventTifoPartScreen>()
                .HasOne(at => at.ArenaEvent)
                .WithMany(a => a.ArenaEventTifoPartScreen)
                .HasForeignKey(at => at.TifoPartScreenId);
            modelBuilder.Entity<ArenaEventTifoPartScreen>()
               .HasOne(at => at.TifoPartScreen)
               .WithMany(t => t.ArenaEventTifoPartScreen)
               .HasForeignKey(at => at.ArenaEventId);

            modelBuilder.Entity<ArenaEventSeat>()
           .HasKey(bs => new { bs.ArenaEventId, bs.SeatId });

            modelBuilder.Entity<ArenaEventSeat>()
                .HasOne(bs => bs.ArenaEvent)
                .WithMany(a => a.ArenaEventSeat)
                .HasForeignKey(bs => bs.SeatId);
            modelBuilder.Entity<ArenaEventSeat>()
               .HasOne(bs => bs.Seat)
               //.WithMany(s => s.ArenaEventSeat)
                 .WithMany()
               .HasForeignKey(bs => bs.ArenaEventId);




            modelBuilder.Entity<UserSeat>()
                .HasKey(ub => new { ub.UserId, ub.SeatId });

            modelBuilder.Entity<UserSeat>()
                .HasOne(ub => ub.ApplicationUser)
                .WithMany(au => au.UserSeats)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<UserSeat>()
                .HasOne(ub => ub.Seat)
                .WithMany(b => b.UserSeats) // If you add `public ICollection<UserBook> UserBooks { get; set; }` navigation property to Book model class then replace `.WithMany()` with `.WithMany(b => b.UserBooks)`
                .HasForeignKey(ub => ub.SeatId);
          

        }
        public DbSet<BigScreen.Models.ArenaEventTifoPartScreen> ArenaEventTifoPartScreen { get; set; }
        public DbSet<BigScreen.Models.UserSeat> UserSeat { get; set; }
        public DbSet<BigScreen.Models.ArenaSection> ArenaSection { get; set; }
        public DbSet<BigScreen.Models.ArenaEventSeat> ArenaEventSeat { get; set; }
        public DbSet<BigScreen.Models.TifoGroup> TifoGroup { get; set; }
        public DbSet<BigScreen.Models.Ticket> Ticket { get; set; }


    }
}
/*
 * Solution-1: If you have no problem to keep ApplicationUser's primary key Id of type string, then just change the UserId type to string in UserBook model class as follows:
public class UserBook
{
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
}
Solution-2: If you want to change ApplicationUser's primary key Id from default string type to int, then specify the key type as int while you are inheriting IdentityUser as follows:
public class ApplicationUser : IdentityUser<int>
{
   public ICollection<UserBook> UserBooks { get; set; }
}
Now you have to make changes in ConfigureServices method of the Startup class as follows:
services.AddDefaultIdentity<IdentityUser<int>>() // here replace `IdentityUser` with `IdentityUser<int>`
        .AddDefaultUI()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
Now finally your model configuration (for both Solution-1 and Solution-2) using Fluent Api should be as follows:
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<UserBook>()
        .HasKey(ub => new { ub.UserId, ub.BookId });

    modelBuilder.Entity<UserBook>()
        .HasOne(ub => ub.ApplicationUser)
        .WithMany(au => au.UserBooks)
        .HasForeignKey(ub => ub.UserId);

    modelBuilder.Entity<UserBook>()
        .HasOne(ub => ub.Book)
        .WithMany() // If you add `public ICollection<UserBook> UserBooks { get; set; }` navigation property to Book model class then replace `.WithMany()` with `.WithMany(b => b.UserBooks)`
        .HasForeignKey(ub => ub.BookId);
}
 */
