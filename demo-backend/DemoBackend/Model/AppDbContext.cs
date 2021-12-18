using Microsoft.EntityFrameworkCore;

namespace DemoBackend.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            if (Database.EnsureCreated())
            {
                for (int i = 0; i < 5; i++)
                {
                    var company = new Company() { Name = $"Company{i}", Website = $"WebSite{i}" };
                    for (int j = 0; j < 3; j++)
                    {
                        var customer = new Customer()
                        {
                            Name = $"Customer{i}{j}",
                            Address = $"Address{i}{j}",
                            Email = $"Email{i}{j}@mail.ru",
                            Phone = $"99999{i}{j}",
                            Company = company
                        };
                        Add(customer);
                    }
                    Add(company);
                }
                SaveChanges();
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"data source=localhost;integrated security=True; Database=DemoBackend; MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customer = modelBuilder.Entity<Customer>();
            customer.HasKey(s => s.Id);
            customer.HasOne(s => s.Company).WithMany(s => s.Customers).HasForeignKey(s => s.CompanyId);

            var company = modelBuilder.Entity<Company>();
            company.HasKey(s => s.Id);
            company.HasMany(s => s.Customers).WithOne(s => s.Company).HasForeignKey(s => s.CompanyId);
        }
    }
}
