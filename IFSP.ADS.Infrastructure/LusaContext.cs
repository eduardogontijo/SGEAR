using IFSP.ADS.Models;
using System.Data.Entity;
using System.Diagnostics;
using System.Configuration;

namespace IFSP.ADS.Infrastructure
{
    public class LusaContext: DbContext
    {
        public LusaContext() : base("Context")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Address> Addresse { get; set; }
        public DbSet<Athlete> Athlete { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Federation> Federation { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Foundation> Foundation { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<MatchItem> MatchItem { get; set; }
        public DbSet<MatchItemType> MatchItemType { get; set; }
        public DbSet<MatchStatus> MatchStatus { get; set; }
        public DbSet<Modality> Modality { get; set; }
        //public DbSet<Suggestion> Suggestion { get; set; }
        //public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<User> User { get; set; }
        

    }
}
