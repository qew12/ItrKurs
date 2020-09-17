using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItrKurs.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
