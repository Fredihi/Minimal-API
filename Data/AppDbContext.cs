using Microsoft.EntityFrameworkCore;
using Minimal_API.Models;

namespace Minimal_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    ID = 1,
                    Name = "Braveheart and Battles",
                    Author = "Robert McLeod",
                    ReleaseYear = new DateTime(2022, 01, 20),
                    Genre = "Scottish Military History",
                    Description = "Dive into the heroic stories of Scottish warriors throughout the history, chronicling their bravery and sacrifices on the battlefield."
                });
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    ID = 2,
                    Name = "Clan Conflicts",
                    Author = "Fiona Campbell",
                    ReleaseYear = new DateTime(2019, 06, 05),
                    Genre = "Scottish Clan Warfare",
                    Description = "Explore the intricate web of clan conflicts that shaped Scotland's history, from ancient feuds to power struggles."
                });
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    ID = 3,
                    Name = "Culloden: Last Stand of the Highlanders",
                    Author = "Angus MacGregor",
                    ReleaseYear = new DateTime(2020, 09, 12),
                    Genre = "Jacobite Uprising",
                    Description = "Examine the events leading up to the Battle of Culloden  in 1746, the tragic culmination of the Jacobite uprising, and it's impact on Scotland"
                });
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    ID = 4,
                    Name = "From Bannockburn to Flodden",
                    Author = "Isobel Fraser",
                    ReleaseYear = new DateTime(2017, 03, 08),
                    Genre = "Medieval Scottish Warfare",
                    Description = "Trace the battle that defined medieval Scotland, including the iconinc Battle of Bannockburn and the devastating Battle of Flodden."
                });
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    ID = 5,
                    Name = "Forgotten Frontlines: World War I",
                    Author = "Malcolm Sinclair",
                    ReleaseYear = new DateTime(2023, 04, 30),
                    Genre = "Scottish Involvement in WWI",
                    Description = "Shed light on the lesser-known stories of Scottish soldiers and their contributions during World War I, highlighting their sacrifices on the global stage."
                });
        }
    }
}
