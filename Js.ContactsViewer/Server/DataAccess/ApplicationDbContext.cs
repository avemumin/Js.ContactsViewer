using Microsoft.EntityFrameworkCore;

namespace Js.ContactsViewer.Server.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //definicja modelu dla bazy danych 
            //w tym pól wymaganych jak i w miarę sensowne ograniczenie długości dla typu 
            //nvarchar Pamiętajmy ze rygor długości zawsze można zwiększyć w razie potrzeby
            //(zmiejszyć też jeśli będziemy pewni ze nie utracimy danych)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.LastName)
                .HasMaxLength(70);

            modelBuilder.Entity<Contact>()
                .Property(x => x.Phone)
                .HasMaxLength(17);

            modelBuilder.Entity<Contact>()
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(128);


            modelBuilder.Entity<Category>()
                .Property(ct => ct.CategoryName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Category>()
                .Property(ct => ct.CategoryDescription)
                .HasMaxLength(250);




            modelBuilder.Entity<SubCategory>()
                .Property(sct => sct.SubCatName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<SubCategory>()
                .Property(sct => sct.SubCatDescription)
                .HasMaxLength(50);
           
        }
    }
}
