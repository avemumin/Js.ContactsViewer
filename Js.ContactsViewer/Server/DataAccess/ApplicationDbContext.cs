using Microsoft.EntityFrameworkCore;

namespace Js.ContactsViewer.Server.DataAccess;

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
            .Property(c => c.Phone)
            .HasMaxLength(17);

        modelBuilder.Entity<Contact>()
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(128);

        modelBuilder.Entity<Contact>()
            .Property(x => x.BirthDay)
            .HasColumnType("date");


   /*Category configuration*/

        modelBuilder.Entity<Category>()
            .Property(ct => ct.CategoryName)
            .IsRequired()
            .HasMaxLength(30);

        modelBuilder.Entity<Category>()
            .Property(ct => ct.CategoryDescription)
            .HasMaxLength(250);


        modelBuilder.Entity<Category>()
            .HasMany(e => e.Contacts)
            .WithOne(d => d.Category)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


        /*SubCategory configuration*/



        modelBuilder.Entity<SubCategory>()
            .Property(sct => sct.SubCatName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<SubCategory>()
            .Property(sct => sct.SubCatDescription)
            .HasMaxLength(50);


        //obsluga usuwania subgategorii w momencie gdy
        //ma relację jako FK do innego obiektu
        //pozwoli to podczas usuwania ustawic NULL gdy pole jest nullable
        modelBuilder.Entity<SubCategory>()
            .HasMany(e => e.Contacts)
            .WithOne(d => d.SubCategory)
            .HasForeignKey(e => e.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        //fake data na potrzeby developerskie

        modelBuilder.Entity<SubCategory>()
            .HasData(
                new SubCategory
                {
                    Id = 1,
                    SubCatName = "Szef",
                    SubCatDescription = "Szef i wsio co z nim zwiazane"
                },
                new SubCategory
                {
                    Id = 2,
                    SubCatName = "Klient",
                    SubCatDescription = "Co tam klient chciał"
                }
            );

        modelBuilder.Entity<Category>()
    .HasData(
        new Category
        {
            Id = 1,
            CategoryName = "Business",
            CategoryDescription = "wszystko zwiazane z biznesem"
        },
        new Category
        {
            Id = 2,
            CategoryName = "Private",
            CategoryDescription = "Twoje prywaty"
        },
        new Category
        {
            Id = 3,
            CategoryName = "Inne",
            CategoryDescription = "Gdy wybrane można utworzyć swoje widzi mi się"
        }
    );


        modelBuilder.Entity<Contact>()
            .HasData(
                new Contact
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    Email = "john.doe@kukuryku.pl",
                    Phone = "12345678",
                    BirthDay = DateTime.Now.AddYears(-40),
                    Password = "1234",
                    SubCategoryId = 1,
                    CategoryId = 1

                },
                  new Contact
                  {
                      Id = 2,
                      Name = "Sabina",
                      LastName = "Doe",
                      Email = "sabinka.doe@kukuryku.pl",
                      Phone = "22233344",
                      BirthDay = DateTime.Now.AddYears(-42).AddDays(-83),
                      Password = "sabina",
                      SubCategoryId = null,
                      CategoryId = 1
                  }
            );
    }
}
